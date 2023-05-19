```
# PowerShell(管理者)を開く

# chocolateyをインストール
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))

# gitをインストール
choco install -y git

# Git Bashを起動

# Azure CLIでログイン
az login

# リソースグループを取得
group=$(az group list  --query '[0].name' -otsv)

# Cognitive Servicesリソース名を生成
name=cog$(date|md5sum|head -c10)

# Cognitive Servicesリソースを作成
az cognitiveservices account create -g "$group" --kind CognitiveServices -l eastus -n "$name" --custom-domain "$name" --sku S0 --yes

# エンドポイントを取得
endpoint=$(az cognitiveservices account show -g "$group" -n "$name" --query 'properties.endpoint' -otsv)

# キーを取得
key=$(az cognitiveservices account keys list -g "$group" -n "$name" --query 'key1' -otsv)

# サンプルコードをクローン
git clone https://github.com/MicrosoftLearning/AI-102-AIEngineer.git

# サンプルコードのエンドポイントとキーの置換
grep -rl YOUR_COGNITIVE_SERVICES_ENDPOINT AI-102-AIEngineer | xargs sed -i "s|YOUR_COGNITIVE_SERVICES_ENDPOINT|$endpoint|g"

grep -rl YOUR_COGNITIVE_SERVICES_KEY AI-102-AIEngineer | xargs sed -i "s/YOUR_COGNITIVE_SERVICES_KEY/$key/g"

# Visual Studio Codeでサンプルプロジェクトを開く
code AI-102-AIEngineer/01-getting-started/C-Sharp/sdk-client

# Visual Studio Codeでターミナル（bash）を開く

# パッケージを追加
dotnet add package Azure.AI.TextAnalytics

# プロジェクトを実行(`quit`で終了)
dotnet run

# 独自プロジェクト


# PowerShell(管理者)を開き、dotnet sdkをインストール
choco install -y dotnet-8.0-sdk --pre

mkdir myclient
cd myclient
dotnet new worker
dotnet add package ConsoleAppFramework
dotnet add package Azure.AI.TextAnalytics
dotnet user-secrets init
dotnet user-secrets set endpoint "$endpoint"
dotnet user-secrets set key "$key"
dotnet user-secrets list

rm Worker.cs
code .
```

```cs
using Azure;
using Azure.AI.TextAnalytics;
ConsoleApp.CreateBuilder(args).
ConfigureServices((context, services) =>
{
    var cfg = context.Configuration;
    var key = cfg["key"] ?? "";
    var endpoint = new Uri(cfg["endpoint"] ?? "");
    var cred = new AzureKeyCredential(key);
    var client = new TextAnalyticsClient(endpoint, cred);
    services.AddSingleton(client);
}).Build().AddRootCommand(Command).Run();

void Command(TextAnalyticsClient client, string text)
{
    DetectedLanguage detectedLanguage = client.DetectLanguage(text);
    Console.WriteLine("Detected language:");
    Console.WriteLine($"\tName: {detectedLanguage.Name}");
    Console.WriteLine($"\tISO 639-1: {detectedLanguage.Iso6391Name}");
}```
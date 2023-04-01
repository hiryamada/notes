# ラボ01 言語サービス（言語の検出）

Cognitive Servicesを使用して、入力された文章が何語で書いてあるか判定する（言語の検出）。

## Cognitive Services マルチサービスアカウントの作成

Azure portalで作成

## プロジェクトの作成

```sh
dotnet new worker
rm Worker.cs
```

## パッケージの追加

```sh
dotnet add package Microsoft.Extensions.Configuration.UserSecrets
dotnet add package Azure.AI.TextAnalytics
dotnet add package CognitiveServices.Translator.Client
```

## キーとエンドポイントの追加

```sh
dotnet user-secrets set 'CognitiveServices:SubscriptionKey' '...'
dotnet user-secrets set 'CognitiveServices:Name' '...'
dotnet user-secrets set 'CognitiveServices:Endpoint' '...'
dotnet user-secrets set 'CognitiveServices:SubscriptionRegion' '...'
```

## `.editorconfig`の作成

https://learn.microsoft.com/ja-jp/dotnet/fundamentals/code-analysis/quality-rules/ca1822

```
root = true

[*.cs]
# supress 'Member ... does not access instance data and can be marked as static'
dotnet_diagnostic.CA1822.severity = none
```

## `Properties/launchSettings.json`の設定

https://stackoverflow.com/questions/65923063/purpose-of-dotnetrunmessages-in-launchsettings-json

```json
{
    ...
      "dotnetRunMessages": false,
    ...
}
```

## `Program.cs` のコーディング

```cs
using Azure;
using Azure.AI.TextAnalytics;
using CognitiveServices.Translator.Extension;

ConsoleApp
.CreateBuilder(args)
.ConfigureServices((context, services) =>
{
    var key = context.Configuration["CognitiveServices:SubscriptionKey"] ?? "";
    var endpoint = new Uri(context.Configuration["CognitiveServices:Endpoint"] ?? "");
    var cred = new AzureKeyCredential(key);
    var client = new TextAnalyticsClient(endpoint, cred);
    services.AddSingleton(client);
    services.AddCognitiveServicesTranslator(context.Configuration);
})
.Build()
.AddCommands<TranslateCommands>()
.AddCommands<LanguageCommands>()
.Run();
```

## `LanguageCommands.cs` のコーディング

```cs
using Azure.AI.TextAnalytics;

class LanguageCommands : ConsoleAppBase
{
    public void Detect(TextAnalyticsClient client, string text)
    {
        DetectedLanguage detectedLanguage = client.DetectLanguage(text);
        Console.WriteLine("Language:");
        Console.WriteLine($"\t{detectedLanguage.Name},\tISO-6391: {detectedLanguage.Iso6391Name}\n");
    }
}
```

## 実行

```sh
dotnet run detect-language --text 'おはようございます'
Language:
        Japanese,       ISO-6391: ja
```


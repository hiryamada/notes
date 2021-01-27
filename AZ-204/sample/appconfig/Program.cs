/*

document: https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/quickstart-dotnet-core-app
document: https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/use-key-vault-references-dotnet-core

# 事前準備（ユーザー）
- Azure ADユーザーを追加 
- VSCodeに Azure Account拡張機能を追加 https://marketplace.visualstudio.com/items?itemName=ms-vscode.azure-account
- VSCodeで F1, Azure: Sign In を選択、作成したAzure ADユーザーでサインイン

# 事前準備 (Key Vault)
- Key Vaultを作成
- Key Vaultにシークレットを追加。キー=key1, 値:任意
- Key Vaultアクセスポリシーにて、Azure ADユーザーにシークレットの「取得」を許可（このとき保存を忘れないこと）

# 事前準備（App Configuration）
- App Configurationを作成
- App Configurationの「構成エクスプローラー」で、「キー値」を適当にいくつか作成
- App Configurationの「構成エクスプローラー」で、「キーコンテナー参照」を作成。上記シークレットを指定。
- App ConfigurationのURIを取得（コード中に書き込む）

dotnet new console -n appcfgsample
cd appcfgsample
dotnet add package Microsoft.Extensions.Configuration.AzureAppConfiguration
dotnet add package Azure.Identity
code .

*/

using System;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Azure.Identity;

void Print(object value)
{
    Console.WriteLine(value);
}

var builder = new ConfigurationBuilder();

builder.AddAzureAppConfiguration(options => {
    var cred = new DefaultAzureCredential();
    options.Connect(new Uri("https://appcfg1234.azconfig.io"), cred);
    options.ConfigureKeyVault(kv => {
        kv.SetCredential(cred);
    });
});

var config = builder.Build();

foreach (var kv in config.AsEnumerable()) {
    Print(kv);
}


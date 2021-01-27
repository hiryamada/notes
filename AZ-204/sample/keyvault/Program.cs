/*

# 事前準備（ユーザー）
- Azure ADユーザーを追加 
- VSCodeに Azure Account拡張機能を追加 https://marketplace.visualstudio.com/items?itemName=ms-vscode.azure-account
- VSCodeで F1, Azure: Sign In を選択、作成したAzure ADユーザーでサインイン

# 事前準備（Key Vault）
- Key Vaultを作成
- Key Vaultにシークレットを追加。キー=key1, 値:任意
- Key Vaultアクセスポリシーにて、Azure ADユーザーにシークレットの「取得」を許可（このとき保存を忘れないこと）
- Key VaultのURIを取得（コード中に記入）

dotnet new console --name keyvaultsample
cd keyvaultsample
dotnet add package Azure.Identity
dotnet add package Azure.Security.KeyVault.Secrets
code .
dotnet run

*/

using System;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

void Print(object value)
{
    Console.WriteLine(value);
}

var keyVaultEndpoint = "https://mykv923784.vault.azure.net/";

var uri = new Uri(keyVaultEndpoint);
var cred = new DefaultAzureCredential();
var kv = new SecretClient(uri, cred);

var secret = kv.GetSecret("key1");

Print(secret.Value.Id);
Print(secret.Value.Name);
Print(secret.Value.Value);

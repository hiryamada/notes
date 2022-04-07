# ハンズオン: Key Vaultからシークレットを取得するクライアント

Key Vaultの「概要」の「コンテナーのURI」を調べておく。

![](images/ss-2022-04-07-14-58-07.png)

Visual Studio Code (Windows VM）のターミナルで以下を実行。

```
cd ~/Documents
dotnet new console -n kvapp1
code -r kvapp1
```

![](images/ss-2022-04-07-14-41-32.png)

![](images/ss-2022-04-07-14-42-31.png)

![](images/ss-2022-04-07-14-43-07.png)

ターミナルを起動

![](images/ss-2022-04-07-14-43-32.png)

以下のコマンドを投入
```
dotnet add package azure.identity
dotnet add package azure.security.keyvault.secrets
```

`Program.cs` を開き、中身を以下のように書き換える。

Uri("")の部分に、Key Vaultの「概要」の「コンテナーのURI」をセットする。

```c#
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;

var cred = new DefaultAzureCredential();
var uri = new Uri(""); // Key Vaultの「概要」の「コンテナーのURI」をセット
var secretClient = new SecretClient(uri, cred);
var result = secretClient.GetSecret("StorageAccountConnectionString");
Console.WriteLine(result.Value.Value);
```

ターミナルで `dotnet run`を実行。

Key Vaultのシークレットにセットした「接続文字列」が取得できればOK。

![](images/ss-2022-04-07-14-59-28.png)
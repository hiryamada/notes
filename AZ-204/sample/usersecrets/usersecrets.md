# ユーザーシークレットの使い方

■プロジェクト作成（dotnet new console）後のフォルダで以下のコマンドを実行:

```sh
# プロジェクトのユーザーシークレットを初期化
dotnet user-secrets init

# ユーザーシークレットにシークレットを格納
dotnet user-secrets set connectionString 接続文字列

# 格納したシークレットの確認
dotnet user-secrets list
```
■パッケージを追加:

```sh
dotnet add package Microsoft.Extensions.Configuration.UserSecrets
```
■コード例:
```cs
using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;

var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
var connectionString = config["connectionString"];
Console.Write("ConnectionString: " + connectionString);
```

■参考

https://docs.microsoft.com/ja-jp/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows

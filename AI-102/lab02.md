# ラボ02 Azure Key Vault

Cognitive Servicesに接続するための情報（特に「キー」などの機密情報）を格納するには、[Azure Key Vault](https://learn.microsoft.com/ja-jp/azure/key-vault/general/overview)を使用する。


Azure Key Vaultのリソースは「キー コンテナー」という。

※「キー コンテナー」には、（「キー」だけではなく）「[キー](https://learn.microsoft.com/ja-jp/azure/key-vault/keys/about-keys)」「[シークレット](https://learn.microsoft.com/ja-jp/azure/key-vault/secrets/about-secrets)」「[証明書](https://learn.microsoft.com/ja-jp/azure/key-vault/certificates/about-certificates)」の3種類の機密情報を格納できる。

```
Key Vault
├キー
├シークレット
└証明書
```

※「Azure Key Vault」の「キー」は、「Cognitive Services」の「キー」とは別のものであることに注意。たとえばデータベース、ストレージアカウント、VMのディスクなど、Azureサービス上のユーザーのデータを暗号化するための[「暗号化キー」（カスタマーマネージドキー）](https://learn.microsoft.com/ja-jp/azure/storage/common/customer-managed-keys-overview)を表す。

※「Cognitive Services」の「キー」のようなものは、「Azure Key Vault」的には「シークレット」として扱われる。

※各シークレットは「シークレット名」と「シークレット値」で構成される。

```
Azure Key Vault
└シークレット
  ├CognitiveServices--SubscriptionRegion = ...
  ├CognitiveServices--SubscriptionKey = ...
  ├CognitiveServices--Name = ...
  └CognitiveServices--Endpoint = ...
    ↑↓
     VM
    ↓
Cognitive Services
```

## シークレットの階層構造

 [名前で `--` （2つのダッシュ）を使用すると、シークレット名を（仮想的に）階層構造にすることができる](https://learn.microsoft.com/ja-jp/aspnet/core/security/key-vault-configuration?view=aspnetcore-7.0#secret-storage-in-the-production-environment-with-azure-key-vault)。要するに、以下のような構造を表現している。

```
CognitiveServices
├Name
├SubscriptionKey
├Endpoint
└SubscriptionRegion
```

今回のラボは必ずしもシークレット名で階層構造を取る必要はなく、フラットな構造でも十分であるが、シークレット名や設定名のような部分はよく階層構造で扱うことが多く、その慣習に従っている。

たとえば`CognitiveServicesA` と `CognitiveServicesB` のような複数のCognitive Servicesのキー等を同時に扱うことを考えた場合、階層構造になっていたほうがわかりやすい。

```
CognitiveServicesA
├Name
├SubscriptionKey
├Endpoint
└SubscriptionRegion

CognitiveServicesB
├Name
├SubscriptionKey
├Endpoint
└SubscriptionRegion
```

## Azure Key Vaultにアクセスするためのロール

|割り当て先のID|割り当てるロール|できること|
|-|-|-|
|開発者ユーザー|[キー コンテナー シークレット責任者(Key Vault Secrets Officer)](https://learn.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#key-vault-secrets-officer)|シークレットの読み書き|
|VMのマネージドID|[キー コンテナー シークレット ユーザー(Key Vault Secrets User)](https://learn.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#key-vault-secrets-user)|シークレットの読み取り|

※Key Vaultの「キーコンテナー」は、英語では「Key Vault」という。シークレット責任者は英語では「Secrets Officer」、シークレットユーザーは英語では「Secrets User」という。

```
開発者
↓ Cognitive Servicesのキー等を書き込み
Key Vault {開発者: シークレット管理者、VM: シークレットユーザー}
↓ Cognitive Servicesのキー等を読み取り
VM
↓ Cognitive Servicesのキー等を使用してCognitive Servicesにアクセス
Cognitive Services
```

開発者は、あらかじめ、Cognitive Servicesのキーなどを調べて、Key Vaultにそれらを書き込む。

VM（アプリ）は、Cognitive Servicesのキーなどを読み込んで、Cognitive Servicesにアクセスするために使用する。アプリは（通常）Key Vaultに書き込みをする必要がないため、読み取りの権限だけを与える（[最小権限の原則](https://ja.wikipedia.org/wiki/%E6%9C%80%E5%B0%8F%E6%A8%A9%E9%99%90%E3%81%AE%E5%8E%9F%E5%89%87)）。

## Cognitive Services リソースを作成（または作成済みのリソースを利用）

作成済みの「言語サービス」リソースや「マルチサービスアカウント」リソースがあれば、それらを使用。

リソースがない場合は「言語サービス」リソースを作成。

リソース名・エンドポイント・キー(キー1の値)・場所/地域（リージョン）の4情報をコピーし、メモ帳などに控えておく。

## Windows VMに「マネージドID」を割り当てる

Azureのリソース（特にVMやApp Serviceなどの、アプリをホスティングする（実行する）「コンピューティング」のサービス）では、マネージドIDを割り当てることができる。

VMに、マネージドIDを割り当てることで、VMで、マネージドIDを使用したAzure AD認証を実行できるようになる。

また、このマネージドIDにAzure RBACロールを割り当てできるようになる。

画面上部の検索ボックスで「vm」と入力し「Virtual Machines」を表示。

一覧で、演習用のVM「labvm」をクリック。

画面左メニューの「ID」をクリック。

「システム割り当て済み」タブ内の「状態」を「オン」にして「保存」をクリック。

「システム割り当てマネージドIDを有効化する」の確認が出る。「はい」をクリック。

## Azure Key Vaultの「キー コンテナー」を作成

機密情報を一元管理するためのサービス「Azure Key Vault」のリソース「キーコンテナー」を作成する。

今回のラボでは4情報を「シークレット」としてここに格納していく。

画面上部で「key vault」と検索し「キー コンテナー」を選ぶ。

「＋作成」をクリック

リソースグループ、リソース名、リージョンは適当なものを指定・選択。特にVMやCognitive Servicesリソースと同じリージョンである必要はない（が、通常なにかのシステムを運用する場合は、通信のレイテンシーを考慮して、1つのリージョンにリソースを作っていくことが多い）。

「次へ」をクリック

「アクセス許可モデル」で「Azure ロールベースのアクセス制御」を選択。データプレーン（Key Vault内の「シークレット」「キー」「証明書」のアクセス）に、Azureロールが使用されるようになる。

「確認および作成」、「作成」をクリック。

しばらくして「デプロイが完了しました」と表示されたら「リソースに移動」をクリック。

## Azure Key Vault「キー コンテナー」のスコープで、必要なロールを割り当てる

ロールを割り当てる場所のことを「スコープ」という。

Azure Key Vault「キー コンテナー」のスコープで、ユーザー（Azure portalにサインインしているユーザー）と、Windows VM「labvm」のマネージドIDに、ロールを割り当てる。

|割り当て先のID|割り当てるロール|できること|
|-|-|-|
|ユーザー|キー コンテナー シークレット責任者|シークレットの読み書き|
|VMのマネージドID|キー コンテナー シークレット ユーザー|シークレットの読み取り|

Key Vaultの画面左のメニュー「アクセス制御（IAM）」をクリック。

「＋追加」＞「ロールの割り当ての追加」。

割り当ての種類「職務ロール」、「次へ」

名前: 「キー コンテナー シークレット責任者」の行をクリック、「次へ」

アクセスの割り当て先: ユーザー、グループ、またはサービス プリンシパル

メンバー: 「＋メンバーを選択する」、画面右上に表示されているユーザー（Azure portalにサインインしているユーザー）と同じものをメンバーとして選択、「選択」をクリック。

「レビューと割り当て」を2回クリック。

もう一度同じように操作して、今度はWindows VM「labvm」のマネージドIDに、ロールを割り当てる。

「＋追加」＞「ロールの割り当ての追加」。

割り当ての種類「職務ロール」、「次へ」

名前: 「キー コンテナー シークレット責任者」の行をクリック、「次へ」

アクセスの割り当て先: マネージドID

メンバー: 「＋メンバーを選択する」をクリック、「マネージドID」プルダウンで「仮想マシン」を選択、一覧の「labvm」をクリックして選択、「選択」をクリック。

「レビューと割り当て」を2回クリック。

以上のロール割り当てにより、ユーザー（Azure portalにサインインしているユーザー）はKey Vaultにシークレットを設定できるようになった。また、演習用のVM「labvm」は、Key Vaultからシークレットを読み取りできるようになった。

## Azure Key Vault「キー コンテナー」にシークレットを追加

Key Vaultの画面左のメニュー「シークレット」をクリック。

「＋生成/インポート」をクリックし、以下の「名前」「値」を設定していく。

|シークレット名|シークレット値|
|-|-|
|CognitiveServices--Name|Cognitive Services リソース名|
|CognitiveServices--SubscriptionKey|キー|
|CognitiveServices--Endpoint|エンドポイント|
|CognitiveServices--SubscriptionRegion|場所/地域（リージョン）|

## .NET (C#) プロジェクトの作成

新しく「lab02」というプロジェクトを作成する。

```
cd ~/Documents
mkdir lab02
cd lab02
dotnet new worker
rm Worker.cs
dotnet add package Azure.Extensions.AspNetCore.Configuration.Secrets
dotnet add package Azure.AI.TextAnalytics
dotnet add package ConsoleAppFramework
dotnet add package Azure.Identity
echo "root = true
[*.cs]
# supress 'Member ... does not access instance data and can be marked as static'
dotnet_diagnostic.CA1822.severity = none
" > .editorconfig
code .
```

※ワーカーサービス（`dotnet new console`）のプロジェクトを使用している。これは、コンソールアプリプロジェクト（`dotnet new console`）と近い構造になるが、設定ファイル`appsettings.json`がデフォルトで準備されたりする点が、コンソールアプリのプロジェクトよりちょっと便利なので、こちらを使用している。

## .NETの「構成」

Key Vaultからシークレット値を読み取る方法はいくつかあるが、今回は [Azure.Extensions.AspNetCore.Configuration.Secrets](https://www.nuget.org/packages/Azure.Extensions.AspNetCore.Configuration.Secrets) という[NuGetパッケージ](https://learn.microsoft.com/ja-jp/nuget/what-is-nuget)を使用する。これを使用すると、[.NETの構成](https://learn.microsoft.com/ja-jp/dotnet/core/extensions/configuration)のソースの一つとして Key Vaultを使用できる。

今回は構成ソースとしてKey Vaultを使用するので、以下のような形となる。

```
Key Vault ... 構成ソース
↓
.NETの構成
↓
IConfiguration インターフェース
↓
.NETアプリ
```


[.NETの構成](https://learn.microsoft.com/ja-jp/dotnet/core/extensions/configuration)を使用すると、設定ファイル、環境変数、プログラム（コマンド）起動時に指定される引数、App Configuration、Key Vaultといった複数の「構成ソース」を組み合わせて、共通的なインターフェースで、構成（設定）を読み取ることができるので便利。

```
A  B  C  D ... 構成ソース
↓ ↓ ↓ ↓
.NETの構成
↓
IConfiguration インターフェース
↓
.NETアプリ
```

「構成ソース」に接続するためのしくみを「[構成プロバイダー](https://learn.microsoft.com/ja-jp/dotnet/core/extensions/configuration#configuration-providers)」という。

## `Properties/launchSettings.json`の変更

dotnetRunMessagesの値をfalseに変更し、保存。

```json
{
...
      "dotnetRunMessages": false,
...
}
```

## `appsettings.json`の変更

以下のように`vaultUri`の行を追加する。その前の行の末尾にも`,`を付ける必要があることに注意。

`...` の部分に、Key VaultのURI （ `https://kv9287342.vault.azure.net/` のようなKey Vaultのエンドポイント）を記入して保存。

```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "vaultUri": "..."
}
```

## `Program.cs`のコーディング

```cs
using Azure;
using Azure.AI.TextAnalytics;
using Azure.Identity;

ConsoleApp
.CreateBuilder(args)
.ConfigureAppConfiguration(config =>
{
    var credential = new DefaultAzureCredential();
    var vaultUri = new Uri(config.Build()["vaultUri"] ?? "");
    config.AddAzureKeyVault(vaultUri, credential);
})
.ConfigureServices((context, services) =>
{
    var key = context.Configuration["CognitiveServices:SubscriptionKey"] ?? "";
    var endpoint = new Uri(context.Configuration["CognitiveServices:Endpoint"] ?? "");
    var cred = new AzureKeyCredential(key);
    var client = new TextAnalyticsClient(endpoint, cred);
    services.AddSingleton(client);
})
.Build()
.AddCommands<LanguageCommands>()
.Run();
```

解説:

`ConfigureAppConfiguration`の部分で、Key Vaultを「構成ソース」として追加している。
```cs
    var credential = new DefaultAzureCredential();
    var vaultUri = new Uri(config.Build()["vaultUri"] ?? "");
    config.AddAzureKeyVault(vaultUri, credential);
```

`ConfigureServices`の部分で、「構成」（`context.Configuration`）から、シークレット名を指定して、シークレット値を取り出している。なお .NETの「構成」的には、シークレット名の階層構造の区切りは `:` を使用して表す（`--`ではない）。

```cs
    var key = context.Configuration["CognitiveServices:SubscriptionKey"] ?? "";
    var endpoint = new Uri(context.Configuration["CognitiveServices:Endpoint"] ?? "");
```

取り出した、Cognitive Servicesの「キー」と「エンドポイント」の2情報を使用して、クライアント`TextAnalyticsClient`を作成する。これを[DIコンテナー](https://learn.microsoft.com/ja-jp/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-7.0)に「シングルトン」として登録する。シングルトンは、アプリの中でただ1つだけ作られるオブジェクト。

今回のクライアントの作成には4情報のうち2情報だけを使用すれば十分であるが、Speech APIなど、別の種類のCognitive Servicesのクライアントによっては、4つすべての情報を使用する場合がある。

```cs
    var cred = new AzureKeyCredential(key);
    var client = new TextAnalyticsClient(endpoint, cred);
    services.AddSingleton(client);
```
## `LanguageCommands.cs`のコーディング


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

解説:

Detectというメソッドを定義している。これを小文字化した`detect`で、このメソッドをコマンドから呼び出すことができるようになる（`dotnet run detect`）。これは、このプロジェクトに組み込んだ [ConsoleAppFramework](https://github.com/Cysharp/ConsoleAppFramework) というフレームワークによって提供される機能である。

引数として、Cognitive Servicesのテキスト分析を行うための `TextAnalyticsClient`
を取っている。これはDIコンテナーから「注入」される。

また、このプログラムを呼び出す際のコマンドライン引数（`dotnet run detect --text 'おはようございます'` といった形）の`--text`で指定した文字列が、`text`引数の値となる。

```cs
    public void Detect(TextAnalyticsClient client, string text)
```

クライアントの`DetectLanguage`メソッドを呼び出して、「言語の検出」を行う。（実際にはここでCognitive ServicesのAPIが呼び出される）

結果を`DetectedLanguage`型のオブジェクトで受け取り、検出された言語の一般的な名前と、ISO 639-1 の言語コード（`ja`など）を表示する。

```cs
        DetectedLanguage detectedLanguage = client.DetectLanguage(text);
        Console.WriteLine("Language:");
        Console.WriteLine($"\t{detectedLanguage.Name},\tISO-6391: {detectedLanguage.Iso6391Name}\n");
```


## 実行

ターミナル内から以下を実行します。

```
dotnet run detect --text 'おはようございます'
```

`--text`部分に指定した文章の言語が判定されます。

実行結果例:
```sh
Language:
        Japanese,       ISO 639-1: ja
```

![](images/ss-2023-04-02-10-50-05.png)

他にもいくつかの言語で試してみてください。

```
# 中国語で「ありがとう」
dotnet run detect --text '谢谢'

# フランス語で「今何時？」
dotnet run detect --text 'Quelle heure est-il'
```

![](images/ss-2023-04-02-10-52-44.png)
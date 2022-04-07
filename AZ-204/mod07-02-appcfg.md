# Azure App Configuration

アプリケーション設定、機能フラグを一元管理。

製品ページ
https://azure.microsoft.com/ja-jp/services/app-configuration/

価格
https://azure.microsoft.com/ja-jp/pricing/details/app-configuration/

ドキュメント
https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/

■Azure App Configurationで管理できるもの

- アプリケーション設定
  - 「構成エクスプローラー」で設定
- 機能フラグ
  - 「機能マネージャー」で設定

■機能フラグの「機能フィルター」

App Configuraiton の機能マネージャーで、機能フラグの設定の中に「機能フィルターを使用する」があります。
ここにチェックをつけると、グループとユーザーを入力するテキストボックスが出現します。
グループやユーザーに何かテキストを入力をすると新しいグループやユーザーの入力ボックスが出てきますので、ここでは複数のグループやユーザーを設定できます。

たとえばグループaには50%, グループbは100%, ユーザーxには50%, ユーザーyには100% といったように、機能を有効化する確率を指定できます。
（一度、ユーザーがサイトにアクセスして、有効/無効が決まったら、そのユーザーに対して、セッション中ではずっとその有効/無効状態が維持されます）

ここで指定するグループ名やユーザー名は、Webアプリケーションのコード内で、何らかの方法で、各ユーザーから生成します。

以下にサンプルがあります。

https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/howto-targetingfilter-aspnet-core

少し省略したものが下記となります。
```
    public class TestTargetingContextAccessor
    {

        public TargetingContext GetContextAsync()
        {
            List<string> groups = new List<string>();
            groups.Add(ユーザーのメールアドレスの@より後ろの部分);
            return new TargetingContext
            {
                UserId = ユーザーのメールアドレス,
                Groups = groups
            };
        }
    }
```

ここでは、たとえば user@example.com というユーザーがサインインしたとすると、
```
TargetContext { UserId = "user@example.com", Groups = [ "example.com" ] }
```

といったオブジェクトが返されるようになっています。
これはあくまで実装例の一つであり、コード次第でいかようにでも、ユーザーIDとグループを決定できます。

App Configurationは、この情報をもとに、ユーザー名とユーザーのグループを判別します。

TargetingContextクラスのマニュアル
https://docs.microsoft.com/en-us/dotnet/api/microsoft.featuremanagement.featurefilters.targetingcontext?view=azure-dotnet-preview



■ハンズオン: Azure App Configurationの設定

- 「App Configuration」を検索
- ＋作成
- リソースグループ、リソース名、場所（リージョン）を入力/選択
- 価格レベル: Standard
- 確認および作成、作成
- デプロイが完了したら、リソースに移動
- 画面左 構成エクスプローラー
  - ＋作成、キー値
  - 鍵: LogLevel
  - 値: Information
  - ラベル: Production
  - 適用
  - ＋作成、キー値
  - 鍵: LogLevel
  - 値: Debug
  - ラベル: Development
  - 適用
  - ＋作成、キー値
  - 鍵: ItemsPerPage
  - 値: 30
  - ラベル: （指定しない）
  - 適用
- 画面左 機能マネージャー
  - 機能フラグを有効にする: チェック
  - 機能フラグ名: ShowRecommendedItems
  - ラベル: （指定しない）
  - 説明: 前回の購入履歴に基づいておすすめ商品を表示する
  - 機能フィルター: （チェックしない）
  - 適用

■ハンズオン: Azure App Configurationからの値の取得

Cloud Shell を開き、Bashを選択して、以下を実行してみましょう.

「YOURAPPCFGNAME」の部分には、前の手順で作成したApp Configurationのリソース名を指定してください。

```
name=YOURAPPCFGNAME
az appconfig kv list --name $name --output table
az appconfig kv show --name $name --output table --key LogLevel --label Production
az appconfig kv show --name $name --output table --key LogLevel --label Development
az appconfig kv show --name $name --output table --key ItemsPerPage
az appconfig feature show --name $name --feature ShowRecommendedItems
```

※通常は、C#などのコード内で、[SDK](https://docs.microsoft.com/ja-jp/dotnet/api/overview/azure/data.appconfiguration-readme)を使用して、設定値を取得して利用します。

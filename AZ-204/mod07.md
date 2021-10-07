# Azure Key Vault

シークレット、キー、証明書を一元管理。

製品ページ
https://azure.microsoft.com/ja-jp/services/key-vault/

価格
https://azure.microsoft.com/ja-jp/pricing/details/key-vault/

ドキュメント
https://docs.microsoft.com/ja-jp/azure/key-vault/

呼び方に注意
- 英語: Azure Key Vault / Key Vault(s)
- 日本語: Azure Key Vault / キー コンテナー

■参考: Azure Key Vaultの仲間たち

- [Azure Key Vault](https://azure.microsoft.com/ja-jp/services/key-vault/)
  - Standard レベル - ソフトウェア, FIPS 140-2 Level 1
  - Premium レベル - HSM, FIPS 140-2 Level 2
- [Azure key Vault Managed HSM](https://docs.microsoft.com/ja-jp/azure/key-vault/managed-hsm/)
  - Standard B1 - FIPS 140-2 Level 3
- [Azure Dedicated HSM](https://azure.microsoft.com/ja-jp/services/azure-dedicated-hsm/) 
  - FIPS 140-2 Level 3

[比較表](pdf/mod07/キー管理サービス.pdf)

■Azure Key Vaultで管理できるもの

- [シークレット](https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/)
  - トークン、パスワード、接続文字列、APIキーなど
    - [ストレージアカウントのアクセスキー](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-account-keys-manage?tabs=azure-portal)
    - [Cosmos DBのキー](https://docs.microsoft.com/ja-jp/azure/cosmos-db/access-secrets-from-keyvault)
  - アクセス制御
  - アクティブ化する日/有効期限
  - バージョン管理
- [キー](https://docs.microsoft.com/ja-jp/azure/key-vault/keys/)
  - データの暗号化に使用される暗号化キーの作成と制御
  - [ストレージ アカウントのデータの保護](https://docs.microsoft.com/ja-jp/azure/storage/common/customer-managed-keys-overview)
  - [Cosmos DBのデータ保護](https://docs.microsoft.com/ja-jp/azure/cosmos-db/how-to-setup-cmk)
  - [Azure SQL Databaseのデータの保護](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/always-encrypted-azure-key-vault-configure?tabs=azure-powershell)
    - [Always Encrypted](https://docs.microsoft.com/ja-jp/sql/relational-databases/security/encryption/always-encrypted-database-engine?view=sql-server-ver15) - クライアントサイド暗号化
    - [TDE](https://docs.microsoft.com/ja-jp/sql/relational-databases/security/encryption/transparent-data-encryption?view=sql-server-ver15) - サーバーサイド暗号化
- [証明書](https://docs.microsoft.com/ja-jp/azure/key-vault/certificates/)
  - SSL/TLS証明書をインポート
  - 自動更新
    - [DigiCertおよびGlobalSignの証明書の自動更新](https://docs.microsoft.com/ja-jp/azure/key-vault/certificates/overview-renew-certificate#renew-an-integrated-ca-certificate)
    - [自己署名証明書の自動更新](https://docs.microsoft.com/ja-jp/azure/key-vault/certificates/overview-renew-certificate#renew-a-self-signed-certificate)
  - Let's Encrypt
    - [Azureに対応したACMEクライアント実装](https://letsencrypt.org/ja/docs/client-options/#clients-microsoft-azure)
    - [運用自動化例](https://blog.shibayan.jp/entry/20180927/1537974023)
  - [Windows VMでの利用](https://docs.microsoft.com/ja-jp/azure/virtual-machines/windows/tutorial-secure-web-server)
  - [Linux VMでの利用](https://docs.microsoft.com/ja-jp/azure/virtual-machines/linux/tutorial-secure-web-server)
  - [Application Gatewayでの利用](https://docs.microsoft.com/ja-jp/azure/application-gateway/key-vault-certs)
  - [App Serviceでの利用](https://docs.microsoft.com/ja-jp/azure/app-service/configure-ssl-certificate#import-a-certificate-from-key-vault)
  - [Azure Front Doorでの利用](https://docs.microsoft.com/ja-jp/azure/frontdoor/front-door-custom-domain-https)

※ACME: Automated Certificate Management Environment
https://ja.wikipedia.org/wiki/Automated_Certificate_Management_Environment

■ハンズオン: Azure Key Vaultの設定

- 「ストレージ アカウント」を検索
- 適当なストレージアカウントを作成
- 作成したストレージアカウントを表示
- 画面左 アクセスキー
- キーの表示
- key1とkey2の「接続文字列」をコピーし、それぞれ、メモ帳などに記録しておく
- 「Key Vault」を検索（「キー コンテナー」をクリック）
- ＋作成
- リソースグループ、Key Vault名、地域（リージョン）を入力/選択
- 価格レベル: 標準
- 確認および作成、作成
- デプロイが完了したら、リソースに移動
- 画面左 シークレット
  - ＋生成/インポート
  - 名前: StorageAccountConnectionString
  - 値: 前の手順でコピーした、key1の「接続文字列」を貼り付け
  - 作成

■ハンズオン: Azure Key Vaultからのシークレットの取得

Cloud Shell を開き、Bashを選択して、以下を実行してみましょう.

「YOURKEYVAULTNAME」の部分には、前の手順で作成したKey Vaultの名前を指定してください。

```
vaultname=YOURKEYVAULTNAME
az keyvault secret show --vault-name $vaultname --name StorageAccountConnectionString
```

※通常は、C#などのコード内で、[SDK](https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/quick-create-net)を使用して、シークレットの値を取得して利用します。

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


# マネージドID

- ユーザー割り当てマネージドID
  - スタンドアロン（単独）のリソースとして作成される
- システム割り当てマネージドID
  - Azureリソース（VM、App Serviceアプリ、関数アプリなど）の一部として作成される

作成したマネージドIDに、RBACロールを割り当てることができる。

■ハンズオン: マネージドIDの利用

- 検索で「vm」と検索して「Virtual Machines」をクリック
- 適当な仮想マシン（Azure VM）を作成する
- ＋作成、＋仮想マシン
  - 画面上部「基本」タブ
    - リソースグループ、仮想マシン名を適当に指定/選択
    - イメージ: Ubuntu Server 20.04 LTS
- 確認および作成、作成
- 秘密キーのダウンロードとリソースの作成

# ラボ7

- ソースコードをまだダウンロードしていない場合は[こちらからダウンロード](https://github.com/MicrosoftLearning/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/archive/refs/heads/master.zip)します。
- まず[参考資料](lab/lab07.md)を見て、概要を把握します
- 次に[手順書](https://microsoftlearning.github.io/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_lab_07.html)を見ながら演習を行います。



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



# Azure Key Vault

シークレット、キー、証明書を一元管理。

https://docs.microsoft.com/ja-jp/azure/key-vault/

※表記:

- 英語
  - サービス: Azure Key Vault
  - リソース: Key Vault(s)
- 日本語
  - サービス: Azure Key Vault 
  - リソース: キー コンテナー

2015/6/24 Azure Key Vault 一般提供開始 https://azure.microsoft.com/ja-jp/updates/general-availability-azure-key-vault/

2018/8/11 Azure Dedicated HSM 一般提供開始 https://azure.microsoft.com/ja-jp/blog/announcing-azure-dedicated-hardware-security-module-availability/

2021/6/21 Azure Key Vault Managed HSM 一般提供開始 https://azure.microsoft.com/ja-jp/updates/akv-managed-hsm-ga/

2021/5/17 Azure Key Vault の [SLA](https://azure.microsoft.com/en-au/support/legal/sla/key-vault/v1_0/) が 99.9% から 99.99% に引き上げられた。https://azure.microsoft.com/ja-jp/updates/akv-sla-raised-to-9999/

[比較表PDF](../AZ-204/pdf/mod07/キー管理サービス.pdf)

■参考: HSM (ハードウェア セキュリティ モジュール)

参考: [HSM(Google画像検索)](https://www.google.com/search?q=hsm+luna&tbm=isch)

参考: [HSMのわかりやすい解説](https://www.intellilink.co.jp/business/security/thales_luna_nw_hsm.aspx)

- [Azure Key Vault](https://azure.microsoft.com/ja-jp/services/key-vault/)
  - Standard レベル - ソフトウェア, FIPS 140-2 Level 1
  - Premium レベル - **HSM**, FIPS 140-2 Level 2
- [Azure key Vault Managed HSM](https://docs.microsoft.com/ja-jp/azure/key-vault/managed-hsm/)
  - Standard B1 - FIPS 140-2 Level 3
- [Azure Dedicated HSM](https://azure.microsoft.com/ja-jp/services/azure-dedicated-hsm/) 
  - FIPS 140-2 Level 3


■概要

以下のものを管理。

- [シークレット](https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/)
- [キー](https://docs.microsoft.com/ja-jp/azure/key-vault/keys/)
- [証明書](https://docs.microsoft.com/ja-jp/azure/key-vault/certificates/)

その他の特徴:
- サービスエンドポイント、プライベートエンドポイントをサポート

■ Key Vault へのアクセス

- コントロールプレーン
  - キーコンテナーそのものの作成・削除・一覧・アクセスポリシーの更新などの操作
  - **RBAC** を使用して、権限を割り当てる
- データプレーン
  - キーコンテナーに格納されているシークレットなどのデータの作成・削除・一覧・取得などの操作
  - **RBAC** または **アクセスポリシー** を使って、権限を割り当てる

参考: RBACによるデータプレーンの承認(authorization)は、あとから追加された仕組み。

- [2020/10 Preview](https://azure.microsoft.com/ja-jp/updates/azure-rolebased-access-control-rbac-for-azure-key-vault-data-plane-authorization-is-now-in-preview/)
- [2021/2 GA](https://azure.microsoft.com/ja-jp/updates/azure-rolebased-access-control-rbac-for-azure-key-vault-data-plane-authorization-is-now-available/)
- [RBACのガイド](https://docs.microsoft.com/ja-jp/azure/key-vault/general/rbac-guide)
- [RBACへの移行についてのガイド](https://docs.microsoft.com/ja-jp/azure/key-vault/general/rbac-migration)


■シークレット

- [シークレット](https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/)
  - トークン、パスワード、接続文字列、APIキーなど
    - [ストレージアカウントのアクセスキー](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-account-keys-manage?tabs=azure-portal)
    - [Cosmos DBのキー](https://docs.microsoft.com/ja-jp/azure/cosmos-db/access-secrets-from-keyvault)

作成の際に指定する主なプロパティ:

- 名前
- 値
- コンテンツの種類(contentType)
  - オプション
  - 取得されるときのシークレット データの解釈を支援
  - 255 文字まで
- アクティブ化する日
  - nbf (not before: 有効期間開始日時)
  - 省略可能、既定値は 現在
- 有効期限
  - exp (expiration time: 有効期限)
  - 省略可能、既定値は 無期限
- 有効
  - はい: 値が読み取れる
  - いいえ: 値は読み取れない

値の取得例:

```
$ az keyvault secret show --name secret1 --vault-name keycontainer1092387423
{
  "attributes": {
    "created": "2021-08-19T10:25:51+00:00",
    "enabled": true,
    "expires": "2021-12-01T10:24:59+00:00",
    "notBefore": "2021-10-01T10:24:59+00:00",
    "recoveryLevel": "Recoverable+Purgeable",
    "updated": "2021-08-19T10:30:15+00:00"
  },
  "contentType": "aaa",
  "id": "https://keycontainer1092387423.vault.azure.net/secrets/secret1/42b7a4b5382249aea343974f735e3b73",
  "kid": null,
  "managed": null,
  "name": "secret1",
  "tags": {
    "x": "1",
    "y": "2",
    "z": "3"
  },
  "value": "hello"
}
```

バージョン:
- シークレットを保存すると「バージョン」が作られ、値は変更不可能となる。
- バージョンは「42b7a4b5382249aea343974f735e3b73」といったランダムな文字列が自動で割り当てられる。
- 同じシークレットの新しい「バージョン」として、新しい値を保存できる。
- シークレットを取得する際に「バージョン」を指定しなければ、最新版の値が取り出される。「バージョン」を指定すればそのバージョンの値が取り出される。

バージョンの指定例:
```
az keyvault secret show --name secret1 --vault-name keycontainer1092387423 --version 42b7a4b5382249aea343974f735e3b73
```

■キー

Key Vault の暗号化キーは、[JSON Web Key (JWK)](https://datatracker.ietf.org/doc/html/draft-ietf-jose-json-web-key) オブジェクトとして表される。

- [キー](https://docs.microsoft.com/ja-jp/azure/key-vault/keys/)
  - データの暗号化に使用される暗号化キーの作成と制御
  - [ストレージ アカウントのデータの保護](https://docs.microsoft.com/ja-jp/azure/storage/common/customer-managed-keys-overview)
  - [Cosmos DBのデータ保護](https://docs.microsoft.com/ja-jp/azure/cosmos-db/how-to-setup-cmk)
  - [Azure SQL Databaseのデータの保護](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/always-encrypted-azure-key-vault-configure?tabs=azure-powershell)
    - [Always Encrypted](https://docs.microsoft.com/ja-jp/sql/relational-databases/security/encryption/always-encrypted-database-engine?view=sql-server-ver15) - クライアントサイド暗号化
    - [TDE](https://docs.microsoft.com/ja-jp/sql/relational-databases/security/encryption/transparent-data-encryption?view=sql-server-ver15) - サーバーサイド暗号化

■キーとシークレットのローテーション

https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/tutorial-rotation

シークレットのローテーションの自動化シナリオ例。

- SQL Serverに接続するためにパスワードを使用している
- パスワードはKey Vaultのシークレットとして格納している
- パスワードを定期的に更新したい

このとき、Event GridとAzure Functionを使用して、キーのローテーションを自動化することができる。

- シークレットの有効期限の30日前になると、Key VaultからEvent Gridにイベントが発行される
  - [SecretNearExpiry イベント](https://docs.microsoft.com/ja-jp/azure/event-grid/event-schema-key-vault)
  - 現在のバージョンのシークレットが有効期限切れになろうとしているときにトリガーされる。
  - イベントは、有効期限の 30 日前にトリガーされる。
- イベントにより、Event GridからAzure Function（関数アプリ）が起動される
- Azure Function（関数アプリ）は以下の処理を行う
  - 新しいパスワードを生成
  - パスワードをKey Vaultのシークレットとして格納
  - SQL Serverのパスワードを更新

■証明書

[X.509証明書](https://ja.wikipedia.org/wiki/X.509)の管理。

※X.509: ITU-Tの公開鍵基盤の規格。

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

■Key Vault の安全性と回復機能

論理的な削除(soft-delete):

https://docs.microsoft.com/ja-jp/azure/key-vault/general/soft-delete-overview

- 削除されたコンテナー、削除されたキー コンテナー オブジェクト (キー、シークレット、証明書など) を回復できる。
- 削除されると、7 日から 90 日の保有期間（デフォルト 90 日、一度設定すると変更不可）にわたって、回復可能な状態が維持される。
- デフォルトで有効となる
- 無効化することは推奨されていない。

消去保護(Purge protection):

https://docs.microsoft.com/ja-jp/azure/key-vault/general/soft-delete-overview#purge-protection

- 消去: purge(パージ): コンテナー、シークレット、キー、証明書を完全に削除する操作。
- 消去保護
  - 無効
    - 保持期間中のキー コンテナーおよびオブジェクトの消去を許可
    - デフォルト
  - 有効
    - 削除されたコンテナーおよびコンテナー オブジェクトに必須の保持期間を適用する.
      - つまり、保持期限の間は復元ができることを確実にする。
    - 論理的な削除が有効な場合にのみ、消去保護を有効にすることができる。
    - いったん有効にすると無効化することはできない

つまり・・・:

以下の3パターンの設定を取りうる。

- 論理削除: 無効、消去保護: 無効: 削除から回復できない。非推奨. 
- 論理削除: 有効、消去保護: 無効: 削除から回復ができる。削除してさらに消去すると回復できない。デフォルト設定. 
- 論理削除: 有効、消去保護: 有効: 削除から回復ができる。保持期限の間、消去できない。

■バックアップ

https://docs.microsoft.com/ja-jp/azure/key-vault/general/backup

- キー コンテナー オブジェクト (シークレット、キー、証明書など) をバックアップすると、暗号化された BLOB としてダウンロードされる
- Azure の外部でこの BLOB の暗号化を解除することはできない
- この BLOB から、同じ Azure サブスクリプションと Azure 地域内のキー コンテナーに BLOB を復元することができる
- Azure portalから、または、コマンドから、バックアップと復元を実行できる
- 現時点では、個々のオブジェクトのバックアップが可能。コンテナー全体のバックアップはできない。


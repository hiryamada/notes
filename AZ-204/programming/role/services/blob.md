■概要

```
Azure Key Vault
└キー
  ↑ (3)キー（CMK）の利用
ストレージアカウント ← (1)管理（ストレージアカウントの作成等）
└Blobコンテナー    ← (2)操作（コンテナーの作成等）
  └Blob           ← (2)操作（Blobのアップロード等）
```

(1)[ストレージアカウントの管理の権限](https://docs.microsoft.com/ja-jp/azure/storage/common/authorization-resource-provider?toc=/azure/storage/blobs/toc.json)

ストレージアカウントの管理を行うユーザー等に、コントロールプレーンの組み込みロールを割り当てる。

(2)[BlobコンテナーやBlobの操作の操作の権限](https://docs.microsoft.com/ja-jp/azure/storage/common/authorize-data-access?toc=/azure/storage/blobs/toc.json)

- アクセスキーを使用する
- データプレーンの組み込みロールを使用する
- SASを利用する
- Blobコンテナーで、パブリック読み取りアクセスを構成する
  - BLOB に限定したパブリック読み取りアクセス
  - コンテナーとその BLOB に対するパブリック読み取りアクセス

(3)ストレージアカウントをCMKで暗号化する場合

- ストレージアカウントにマネージドIDを割り当てる。
  - Azure Key Vault
    - データプレーンをアクセスポリシーで制御する場合
      - ストレージアカウントのマネージドIDによるアクセスをアクセスポリシーで承認する。
    - データプレーンをRBACで制御する場合
      - Key Vaultの「アクセス制御（IAM）」で、「キー コンテナー暗号化サービスの暗号化」ロールを、ストレージアカウントのマネージドIDに割り当てる

■REST API

2種類のREST APIがある。

- Azure Storage リソース プロバイダー REST API
  - ストレージ アカウントと関連リソースを操作
- Azure Storage REST API
  - ストレージ アカウントのデータ (BLOB、キュー、ファイル、テーブル データなど) を操作

■コントロールプレーンの組み込みロール

https://docs.microsoft.com/ja-jp/azure/storage/common/authorization-resource-provider

https://docs.microsoft.com/ja-jp/azure/storage/common/authorization-resource-provider#built-in-roles-for-management-operations

- Owner ★
- Contributor ★
- Reader
- Storage Account Contributor ★
- User Account Administrator ★
- Virtual Mahcine Contributor ★

★: ストレージ アカウント キーへのアクセスが含まれる。ユーザーがストレージ アカウント キーにアクセスできる場合は、そのアカウント キーを使用して、 **共有キー認証を介してAzure Storage データにアクセスできる**。

■データプレーンの組み込みロール

https://docs.microsoft.com/ja-jp/azure/storage/blobs/assign-azure-role-data-access?tabs=portal

- ストレージ BLOB データ共同作成者
  - Azure Storage コンテナーと BLOB の読み取り、書き込み、削除を行います
- ストレージ BLOB データ所有者
  - Azure Storage Blob コンテナーとデータに対するフル アクセスを提供します
- ストレージ BLOB データ閲覧者
  - Azure Storage コンテナーと BLOB の読み取りと一覧表示を行います
- Storage Blob デリゲータ
  - 「共有アクセス署名(SAS)」を作成するために使用できる[ユーザー委任キー](https://docs.microsoft.com/ja-jp/rest/api/storageservices/create-user-delegation-sas)を取得します

■共有キーによる承認（アクセスキー）

https://docs.microsoft.com/ja-jp/rest/api/storageservices/authorize-with-shared-key

■共有アクセス署名 (SAS)

https://docs.microsoft.com/ja-jp/rest/api/storageservices/delegate-access-with-shared-access-signature

■マネージドIDの割り当て

https://docs.microsoft.com/ja-jp/cli/azure/storage/account?view=azure-cli-latest#az_storage_account_create

Azure Key Vault などのキー管理サービスで使用するために、このストレージアカウントの新しい Storage アカウント ID を生成して割り当てます。

```
az storage account create --assign-identity
az storage account update --assign-identity 
```

https://docs.microsoft.com/ja-jp/azure/storage/common/customer-managed-keys-overview
ストレージアカウントを、カスタマーマネージドキー（CMK）で暗号化して保護する際、ストレージアカウントにマネージドIDが作成される。
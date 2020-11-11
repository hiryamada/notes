# ストレージのセキュリティ


ストレージ アカウントのデータにアクセスするたびに、クライアントは HTTP/HTTPS 経由で Azure Storage に要求を行います。 

匿名アクセス許可（パブリック アクセス）を除き、リソースに対するすべての要求が**承認**される必要があります。

アクセスの承認の方式はいくつか存在します。ストレージのサービスによって、[使用することができるアクセス承認の方式が異なります](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-auth)。

ポイント
- 共有キーは、すべてのストレージ サービス（Blob、Files、キュー、テーブル）で使用できます。
- 匿名アクセス許可は、Blobだけで使用できます。
- Azure ADによる承認は、Blobとキューでのみサポートされています。
- Azure Filesでは、SASをサポートしていませんが、AAD ドメインサービス、オンプレミスAD DSによる承認をサポートしています。

## [匿名読み取りアクセス](https://docs.microsoft.com/ja-jp/azure/storage/blobs/anonymous-read-access-configure?tabs=portal)

コンテナーと BLOB へのオプションの匿名パブリック読み取りアクセスがサポートされています。

匿名アクセスを許可するようにコンテナーのパブリック アクセス レベル設定を構成すると、クライアントは要求の承認なしでそのコンテナー内のデータを読み取ることができます。

## 「承認」と「委任」

- 承認(authorize): 
  - [共有キーによる承認](https://docs.microsoft.com/ja-jp/rest/api/storageservices/authorize-with-shared-key) - ストレージ アカウント アクセス キーを使用
  - [Azure ADによる承認](https://docs.microsoft.com/ja-jp/rest/api/storageservices/authorize-with-azure-active-directory) - Azure ロールを使用
- 委任(delegate): 
  - [アクセスの委任](https://docs.microsoft.com/ja-jp/rest/api/storageservices/delegate-access-with-shared-access-signature) - SASを利用


## [共有キーによる承認](https://docs.microsoft.com/ja-jp/rest/api/storageservices/authorize-with-shared-key) - ストレージ アカウント アクセス キーを使用

ストレージ アカウントを作成すると、Azure により 512 ビットのストレージ アカウント アクセス キーが 2 つ生成されます。 

これらのキーは、共有キー承認を使用してストレージ アカウント内のデータへのアクセスする際、承認に使用されます。

※承認の流れ
- クライアントは、アクセス キーを使用して、Authorizationヘッダー（HMAC）を生成し、リクエストに含めて、ストレージ サービスに送信することで、アクセスが承認されます。

**BLOB およびキュー**のデータに対する要求を承認するには、共有キーではなく、可能であれば Azure Active Directory (Azure AD) を使用することをお勧めします。 

## [Azure AD による承認](https://docs.microsoft.com/ja-jp/rest/api/storageservices/authorize-with-azure-active-directory) - Azure ロールを使用

Azure Storage は、**Blob およびキュー**に対する要求の id ベースの認可にAzure Active Directory (Azure AD)との統合を提供します。

Azure AD では、ロールベースのアクセス制御 (RBAC) を使用して、ユーザー、グループ、またはアプリケーションへの **blob およびキュー**へのアクセスを許可できます。 

[使用できるロールの一覧](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-auth-aad?toc=/azure/storage/blobs/toc.json#azure-built-in-roles-for-blobs-and-queues)

※承認の流れ
- クライアントは、Azure ADからOAuth 2.0アクセストークンを取得します。
- クライアントは、リクエストにOAuth 2.0アクセストークンを含めて、ストレージサービスへ送信することで、アクセスが承認されます。

## [アクセスの委任](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-sas-overview) - SASを使用

Shared Access Signature (SAS) により、データのセキュリティを損なうことなく、ストレージ アカウント内のリソースへのセキュリティ保護された委任アクセスが提供されます。

SAS を使用すると、クライアントがデータにアクセスする方法をきめ細かく制御できます。 

クライアントがアクセスできるリソース、それらのリソースに対して持つアクセス許可、SAS の有効期間などを制御できます。

※承認の流れ
- 第1のクライアントは、ストレージ アカウント キーを使用して、Authenticationヘッダー（HMAC）を作り、ストレージ サービスにSASトークンの生成をリクエストします。（※）
- 第1のクライアントは、第2のクライアントにSASキーを渡します（委任）。
- 第2のクライアントは、ストレージ サービスへ、SASトークンを含めてリクエストすることで、アクセスが承認されます。

※Azure AD 資格情報で署名された SASトークンを作成することも[可能](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-sas-overview)です。（ユーザー委任SAS）

- SASの種類
  - アカウントSAS
  - サービスSAS
  - ユーザー委任SAS
- SASの形式
  - アドホックSAS
  - 保存されているアクセスポリシーによるサービスSAS

※ユーザー委任 SAS またはアカウント SAS はアドホック SAS である必要があります。 保存されているアクセス ポリシーは、ユーザー委任 SAS またはアカウント SAS ではサポートされていません。

※[SASトークンに署名する方法](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-sas-overview#sas-signature-and-authorization)
- Azure Active Directory (Azure AD) 資格情報を使用して作成された ユーザー委任キー
- ストレージ アカウント キー（共有キー）

## [Storage Service Encryption(SSE)](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-service-encryption)

Azure Storage では、データがクラウドに永続化されるときに自動的に暗号化されます。

Azure Storage 暗号化によってデータは保護され、組織のセキュリティおよびコンプライアンス コミットメントを満たすのに役立ちます。

Azure Storage 内のデータは、利用可能な最強のブロック暗号の 1 つである 256 ビット AES 暗号化を使って透過的に暗号化および暗号化解除され、FIPS 140-2 に準拠しています。

既定では、新しいストレージ アカウント内のデータは Microsoft マネージド キーで暗号化されます。 

引き続き Microsoft マネージド キーを利用してデータを暗号化することも、独自のキー（カスタマー マネージド キーなど）で暗号化を管理することもできます。

## [カスタマー マネージド キー](https://docs.microsoft.com/ja-jp/azure/storage/common/customer-managed-keys-overview)

独自の暗号化キーを使用して、ストレージ アカウントのデータを保護できます。

カスタマー マネージド キーを指定すると、データを暗号化するキーへのアクセスを保護および制御するために、そのキーが使用されます。 

カスタマー マネージド キーを使用すると、アクセス制御をより柔軟に管理できます。

カスタマー マネージド キーを格納するには、Azure Key Vault または Azure Key Vault Managed Hardware Security Model (HSM) (プレビュー) のいずれかを使用する必要があります。

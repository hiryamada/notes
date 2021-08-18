ストレージ アカウントのセキュリティ

# 暗号化

■保存時の暗号化

https://docs.microsoft.com/ja-jp/azure/security/fundamentals/encryption-atrest#azure-storage

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-service-encryption

Azure Storage に書き込まれるすべてのデータは、[Storage Service Encryption (SSE) ](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-service-encryption)を使用して自動的に暗号化される。

- 暗号化を無効にすることはできない。
- コストはかからない。

暗号化に使用するキーの管理方式を選ぶことができる。

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-service-encryption#about-encryption-key-management

- Microsoft のマネージド キー(デフォルト)
  - キーの管理: Microsoft
  - 対象サービス: すべて
- カスタマー マネージド キー
  - キーの管理: Azure Key Vault
  - 対象サービス: Blob Storage, Azure Files
- カスタマー指定のキー
  - キーの管理: お客様独自のキーストア
  - 対象サービス: Blob Storageのみ

■転送中の暗号化

(1)ストレージアカウントの「安全な転送が必須」
- デフォルトで有効になっている
- すべてのクライアントが転送中の暗号化を使用するように強制できる
- HTTPSや、暗号化ありのSMB 3.0を使用するクライアント要求は許可される
- その他(HTTP, 暗号化なしのSMB)を使用するクライアント要求は拒否される

OSごとのSMBのサポート状況:

- [Windows](https://docs.microsoft.com/ja-jp/azure/storage/files/storage-how-to-use-files-windows)
- [Linux](https://docs.microsoft.com/ja-jp/azure/storage/files/storage-how-to-use-files-linux?tabs=smb311)
- [macOS](https://docs.microsoft.com/ja-jp/azure/storage/files/storage-how-to-use-files-mac)

(2)クライアント側の暗号化の利用（オプション）

- [.NET等のコードとクライアントライブラリ(SDK)を使用して、アップロード前にクライアント側でデータを暗号化](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-client-side-encryption)することができる。
- クライアントアプリケーション側への暗号化・複合処理の組み込みが必要

■ディスクの暗号化 

- Azure VMが使用するディスクを暗号化することができる。
- モジュール4の[Azure Disk Encryption](mod04-05-encryption.md)で解説済み。


# 認証と承認

- 認証(authentication): ユーザーの本人確認をすること
- 承認(authorization): 特定の操作を許可すること

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-introduction

※上記ドキュメントでは「承認」「認証」という言葉が用いられているが、原文（英語）では「authorization」となっている。

Azure Storage に対するすべての要求は、以下のいずれかの方法で承認される必要がある。

- Azure AD統合
  - Azure ADでユーザー認証し、RBACロールで承認
  - 対象: [Blob](https://docs.microsoft.com/ja-jp/azure/storage/blobs/assign-azure-role-data-access?tabs=portal), [Queue](https://docs.microsoft.com/ja-jp/azure/storage/queues/assign-azure-role-data-access?tabs=portal), [Table](https://docs.microsoft.com/ja-jp/azure/storage/tables/authorize-access-azure-active-directory)
- SMB
  - オンプレミスAD DSまたは[AAD DS](https://docs.microsoft.com/ja-jp/azure/active-directory-domain-services/overview)を使用した、SMB経由のIDベース承認
  - 対象: Azure Filesのみ
- 共有キー (アクセス キー)
  - クライアントにアクセスキーを持たせる
  - アクセスキーを使ってリクエストに署名を行う
  - 対象: すべて(Blob, Files, Table, Queue)
- 共有アクセス署名（SAS）
  - セキュリティトークンを含む文字列（SASトークン）をURIに追加してアクセス
  - クライアントに、アクセスを「委任」することができる
  - （詳しい説明は後述）
  - 対象: すべて(Blob, Files, Table, Queue)
- [匿名パブリック読み取りアクセス](https://docs.microsoft.com/ja-jp/azure/storage/blobs/anonymous-read-access-configure?tabs=portal)
  - 個々のBlobの読み込みを許可
  - または、個々のBlobの読み込み＋Blobコンテナー内のBlobの一覧表示を許可
  - 対象: Blobコンテナー

# 共有アクセス署名（SAS）

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-sas-overview

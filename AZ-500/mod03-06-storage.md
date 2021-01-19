# データ主権


# ストレージアカウントのアクセス制御

- 共有キー
- SAS
- 匿名アクセス

# RBACによるストレージアカウントの認証

BLOBとQueueのみ。

# [Storage Service Encryption](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-service-encryption)

Azure Storage では、データがクラウドに永続化されるときに自動的に暗号化されます。

利用可能な最強のブロック暗号の 1 つである 256 ビット AES 暗号化を使って透過的に暗号化および暗号化解除され、FIPS 140-2 に準拠しています。

無効にすることはできません。

データは既定で保護されるので、Azure Storage 暗号化を利用するために、コードまたはアプリケーションを変更する必要はありません。

既定では、新しいストレージ アカウント内のデータは Microsoft マネージド キーで暗号化されます。 引き続き Microsoft マネージド キーを利用してデータを暗号化することも、独自のキーで暗号化を管理することもできます。

- BLOB ストレージと Azure Files のデータの暗号化と復号化に使用する "カスタマーマネージド キー" を指定できます。
  - カスタマーマネージド キーは、Azure Key Vault または Azure Key Vault Managed Hardware Security Model (HSM) に格納する必要があります。
- BLOB ストレージの操作では、"カスタマー指定のキー" を指定できます。 BLOB ストレージ に対して読み取りまたは書き込み要求を行うクライアントは、BLOB データの暗号化と暗号化解除の方法を細かく制御するために、要求に暗号化キーを含めることができます。


# BLOB データ保持（リテンション）ポリシー

[不変BLOB](https://docs.microsoft.com/ja-jp/azure/storage/blobs/storage-blob-immutable-storage)

Azure Blob Storage の不変ストレージを使用すると、ユーザーはビジネスに不可欠なデータ オブジェクトを WORM (Write Once Read Many) 状態で保存できます。

保持間隔の間、BLOB の作成と読み取りは可能ですが、変更や削除を行うことはできません。

コンテナー＞アクセスポリシー＞不変BLOBストレージ＞「＋ポリシーの追加」で、ポリシーを追加します。

ポリシーの種類: 
- 時間ベースのリテンション ポリシー: ユーザーは、指定した期間、データを保存するポリシーを設定できます。
- 訴訟ホールド: 訴訟ホールドを設定することで、訴訟ホールドがクリアされるまで不変データを保存できます。

これらのポリシーは、コンテナー内の既存および新規のすべての BLOB に適用されます。

# Azure Filesの認証

Azure Files では、オンプレミス Active Directory Domain Services (AD DS) と Azure Active Directory Domain Services (Azure AD DS) という 2 種類の Domain Services を使用した、サーバー メッセージ ブロック (SMB) 経由の ID ベースの認証がサポートされます。


2020/6/11 [オンプレミス Active Directory Domain Services 認証の一般提供開始(General availability)](https://azure.microsoft.com/ja-jp/blog/general-availability-of-azure-files-onpremises-active-directory-domain-services-authentication/)

# [ストレージアカウントの「安全な転送が必須」プロパティ](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-require-secure-transfer)


セキュリティで保護された接続からの要求のみを受け入れるようにストレージ アカウントを構成できます。

ストレージ アカウントを作成すると、デフォルトで、 「安全な転送が必須」 プロパティが有効になります。

安全な転送を要求すると、セキュリティで保護されていない接続から送信される要求はすべて拒否されます。

安全な転送が必要な場合、

- Azure Storage REST API 操作の呼び出しは HTTPS を介して行う必要があります。 HTTP を介して行われた要求はすべて拒否されます。
- 暗号化なしの SMB 経由で Azure ファイル共有に接続しても失敗します。



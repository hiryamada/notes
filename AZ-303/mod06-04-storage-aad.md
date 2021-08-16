# Azure AD を使用して BLOB, Queue, Tableのアクセスを承認する

- 承認に Azure AD を使用する
- 認可に Azure RBAC を使用する

■Blob

https://docs.microsoft.com/ja-jp/azure/storage/blobs/assign-azure-role-data-access

スコープ:
- 管理グループ
- サブスクリプション
- リソースグループ
- ストレージアカウント
- 各コンテナー

RBACロール:

- [Storage Blob Data Contributor](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#storage-blob-data-contributor)
- [Storage Blob Data Owner](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#storage-blob-data-owner)
- [Storage Blob Data Reader](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#storage-blob-data-reader)
- [Storage Blob Delegator](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#storage-blob-delegator)

■Queue

https://docs.microsoft.com/ja-jp/azure/storage/queues/authorize-access-azure-active-directory


スコープ:
- 管理グループ
- サブスクリプション
- リソースグループ
- ストレージアカウント
- 各キュー

RBACロール:


- [Storage Queue Data Contributor](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#storage-queue-data-contributor)
- [Storage Queue Data Message Processor](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#storage-queue-data-message-processor)
- [Storage Queue Data Message Sender](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#storage-queue-data-message-sender)
- [Storage Queue Data Reader](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#storage-queue-data-reader)

■Table ※現在preview

https://docs.microsoft.com/ja-jp/azure/storage/tables/authorize-access-azure-active-directory

スコープ:
- 管理グループ
- サブスクリプション
- リソースグループ
- ストレージアカウント
- 各テーブル

RBACロール:
- Storage Table Data Contributor
- Storage Table Data Reader

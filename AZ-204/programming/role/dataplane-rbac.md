
# データプレーンに対するRBACロール



■ストレージアカウント全体


Azure Storage アカウントの共有キーによる承認を禁止する
https://docs.microsoft.com/ja-jp/azure/storage/common/shared-key-authorization-prevent

Azure Active Directory で承認する
https://docs.microsoft.com/ja-jp/rest/api/storageservices/authorize-with-azure-active-directory

■Blob

BLOB データにアクセスするための Azure ロールを割り当てる
https://docs.microsoft.com/ja-jp/azure/storage/blobs/assign-azure-role-data-access

Azure Active Directory を使用して BLOB へのアクセスを認可する
https://docs.microsoft.com/ja-jp/azure/storage/blobs/authorize-access-azure-active-directory

BLOB 用の Azure 組み込みロール
https://docs.microsoft.com/ja-jp/azure/storage/blobs/authorize-access-azure-active-directory#azure-built-in-roles-for-blobs

ストレージ BLOB データ共同作成者
ストレージ BLOB データ所有者
ストレージ BLOB データ閲覧者
Storage Blob デリゲータ


■Queue

キュー用の組み込みロール
https://docs.microsoft.com/ja-jp/azure/storage/queues/authorize-access-azure-active-directory#azure-built-in-roles-for-queues


ストレージ キュー データ共同作成者
ストレージ キュー データのメッセージ プロセッサ
ストレージ キュー データ閲覧者


■Table

テーブル用の組み込みロール
https://docs.microsoft.com/ja-jp/azure/storage/tables/authorize-access-azure-active-directory#azure-built-in-roles-for-tables

ストレージ テーブル データ共同作成者
ストレージ テーブル データ閲覧者

■Key Vault

Key Vault データ プレーン操作のための Azure の組み込みロール
https://docs.microsoft.com/ja-jp/azure/key-vault/general/rbac-guide?tabs=azure-cli#azure-built-in-roles-for-key-vault-data-plane-operations

コンテナー アクセス ポリシーから Azure ロールベースのアクセス制御のアクセス許可モデルへの移行
https://docs.microsoft.com/ja-jp/azure/key-vault/general/rbac-migration

■Cosmos DB

※適用対象はSQL APIのみ

組み込みロール
https://docs.microsoft.com/ja-jp/azure/cosmos-db/how-to-setup-rbac#built-in-role-definitions

Cosmos DB 組み込みデータ リーダ
Cosmos DB 組み込みデータ共同作成者

唯一の認証方法としての RBAC の適用
https://docs.microsoft.com/ja-jp/azure/cosmos-db/how-to-setup-rbac#enforcing-rbac-as-the-only-authentication-method


■


# App Service

Web Plan Contributor
https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#web-plan-contributor

Website Contributor
https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#website-contributor

# Azure Functions

（存在しない？）




# ACI

（存在しない？）


# AKS


# ACR


# Logic App

Logic App Contributor
https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#logic-app-contributor

Logic App Operator
https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#logic-app-operator

# Managed ID

Managed Identity Contributor
https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#managed-identity-contributor

Managed Identity Operator
https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#managed-identity-operator


# 
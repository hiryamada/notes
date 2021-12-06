■概要

```
Azure Key Vault
└キー
  ↑ キー（CMK）の利用
Cosmos DBアカウント
└データベース
  └コンテナー
    └項目
```

(x)Azure Key Vaultに格納したキー（CMK）で暗号化する場合

Azure Key Vault側で、以下のいずれかのIDに対し、 [取得] 、 [キーの折り返しを解除] 、および [キーを折り返す] アクセス許可を選択します。

- Cosmos DBアカウントが持っている「ファーストパーティID」
- マネージドID（システム割り当て or ユーザー割り当て）


■コントロールプレーンのロール

https://docs.microsoft.com/ja-jp/azure/cosmos-db/role-based-access-control

- [DocumentDB Account Contributor（DocumentDB Account Contributor）](https://docs.microsoft.com/en-us/azure/role-based-access-control/built-in-roles#documentdb-account-contributor)
- [Cosmos DB アカウント閲覧者（Cosmos DB Account Reader Role）](https://docs.microsoft.com/en-us/azure/role-based-access-control/built-in-roles#cosmos-db-account-reader-role)
- [Cosmos バックアップ オペレーター （CosmosBackupOperator）](https://docs.microsoft.com/en-us/azure/role-based-access-control/built-in-roles#cosmosbackupoperator)
- [CosmosRestoreOperator](https://docs.microsoft.com/en-us/azure/role-based-access-control/built-in-roles#cosmosrestoreoperator)	
- [Cosmos DB オペレーター （Cosmos DB Operator）](https://docs.microsoft.com/en-us/azure/role-based-access-control/built-in-roles#cosmos-db-operator)

※Document DBはCosmos DBの昔の名前。

■Cosmos DB における、データへのアクセスを制御する方法

https://docs.microsoft.com/ja-jp/azure/cosmos-db/secure-access-to-data

- プライマリキー・セカンダリキー
- RBAC
- リソーストークン

■プライマリキーとセカンダリキー

※ドキュメント上では「主キー」とも

https://docs.microsoft.com/ja-jp/azure/cosmos-db/database-security?tabs=sql-api#primarysecondary-keys

主/セカンダリ キーにより、データベース アカウントのすべての管理リソースへのアクセスが提供されます。

- アカウント、データベース、ユーザー、およびアクセス許可へのアクセスを提供します。
- コンテナーとドキュメントへのきめ細かいアクセスを提供するために使用することは**できません**。
- アカウントの作成時に作成されます。
- いつでも再生成することができます。

アクティビティログを使用すると、キーの再生成操作を追跡できる。
https://docs.microsoft.com/ja-jp/azure/cosmos-db/database-security?tabs=sql-api#track-the-status-of-key-regeneration

■データプレーンのロール（Azure Cosmos DB データ プレーン RBAC）

**※対象: SQL APIのみ**

https://docs.microsoft.com/ja-jp/azure/cosmos-db/secure-access-to-data?tabs=using-primary-key#role-based-access-control

https://docs.microsoft.com/ja-jp/azure/cosmos-db/how-to-setup-rbac

- Cosmos DB 組み込みデータ リーダー
- Cosmos DB 組み込みデータ共同作成者

これらのロールは、Azure portalの「アクセス制御（IAM）」や、`az role definition list` コマンドの実行結果などには**表示されない**。ロールの割り当てやカスタムロールの定義はCosmos DBアカウント（SQL API）レベルで実施する。

```
$ az cosmosdb sql role --help

Group
    az cosmosdb sql role : Manage Azure Cosmos DB SQL role resources.

Subgroups:
    assignment : Manage Azure Cosmos DB SQL role assignments.
    definition : Manage Azure Cosmos DB SQL role definitions.
```

■リソーストークン


https://docs.microsoft.com/ja-jp/azure/cosmos-db/secure-access-to-data?tabs=using-primary-key#resource-tokens

**ネイティブな Azure Cosmos DB のユーザー**とアクセス許可に基づく、きめ細かいアクセス許可モデル。



■マネージドID（または「ファーストパーティID」）

https://docs.microsoft.com/ja-jp/azure/cosmos-db/how-to-setup-cmk#using-a-managed-identity-in-the-azure-key-vault-access-policy

- Azure Cosmos DB のファーストパーティ ID
  - Azure Cosmos DB サービスへのアクセス権を付与するために使用できます。
- Azure Cosmos DB アカウントのマネージド ID
  - ご使用のアカウントへのアクセス権を明示的に付与するために使用できます。


AZ CLIでCosmos DBアカウントを作成する際にマネージドIDを割り当てることもできる。

```
Command
    az cosmosdb create : Creates a new Azure Cosmos DB database account.

Arguments
    --assign-identity                  [Preview] : Assign system or user assigned
                                                   identities separated by spaces. Use '[system]' to
                                                   refer system assigned identity.
        Argument '--assign-identity' is in preview and under development. Reference and support
        levels: https://aka.ms/CLI_refstatus

```

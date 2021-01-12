# サブスクリプション

[Azureサブスクリプション(Microsoft Learn)](https://docs.microsoft.com/ja-jp/learn/modules/azure-architecture-fundamentals/management-groups-subscriptions)

[Azure サブスクリプションと Azure AD](https://jpasms.z11.web.core.windows.net/Azure%E3%82%B5%E3%83%96%E3%82%B9%E3%82%AF%E3%83%AA%E3%83%97%E3%82%B7%E3%83%A7%E3%83%B3%E3%81%A8AzureAD%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6.html)

[サブスクリプションの作成](https://docs.microsoft.com/ja-jp/azure/cost-management-billing/manage/create-subscription)

EA契約からサブスクリプションを切り出すことができる
AADの「アカウントオーナーロール」のユーザーは、サブスクリプションを払い出しできる

# 管理グループ

https://docs.microsoft.com/ja-jp/azure/governance/management-groups/overview

# ポリシー / イニシアチブ

https://docs.microsoft.com/ja-jp/azure/governance/policy/overview

- スコープ（管理グループ、サブスクリプション、リソースグループ、個々のリソース）に割り当てる
- [サブスコープは必要に応じて除外できる](https://docs.microsoft.com/ja-jp/azure/governance/policy/concepts/exemption-structure)
- 7種類の[効果](https://docs.microsoft.com/ja-jp/azure/governance/policy/concepts/effects)が利用できる
  - Deny: 要求が送信されないようにする
  - DeployIfExists: 条件が満たされたときにテンプレートのデプロイを実行
  - Append: リソースにフィールドを追加(タグ以外のプロパティで使用)
  - Modify: リソースのプロパティまたはタグを追加、更新、または削除
  - Audit: アクティビティ ログに警告イベントが作成
  - AuditIfNotExists:  関連するリソースがない場合、または ExistenceCondition によって定義されたリソースが true と評価されない場合、監査が発生します
  - Disabled: 

# ロール (Azure RBAC)

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/overview

# リソース ロック

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/lock-resources

- 読み取り専用
- 削除



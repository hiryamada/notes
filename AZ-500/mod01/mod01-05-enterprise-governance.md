# mod1-5 エンタープライズガバナンス

## 共同責任モデル(Shared responsibility model)

https://docs.microsoft.com/ja-jp/azure/security/fundamentals/shared-responsibility

■共同責任モデルとは？

「お客様」が責任を持つべきセキュリティの範囲と、「Microsoft」が責任を持つべきセキュリティの範囲を定めたモデル。

サービスの種類により、「お客様」または「Microsoft」が責任を持つ範囲が異なる。

IaaSよりもPaaS、PaaSよりもSaaSのほうが、Microsoftの責任範囲が大きくなる（お客様の責任範囲が小さくなるため、セキュリティ対策の手間やコストが、より削減される）。

注意:「データ」「エンドポイント」「アカウント(ID)」「アクセス管理」については、常に「お客様」が責任を持つ範囲となる。

具体的には・・・

- 「データ」に適切なアクセス制限やバックアップを設定する
- サービスの「エンドポイント」に適切なネットワーク制限などを設定する
- 「アカウント」を適切に管理する（Azure ADのユーザー等を適切に管理する）
- 「アクセス管理」を適切に行う（ユーザーに適切なロールを割り当てる）

## Azure クラウドセキュリティ の利点

https://docs.microsoft.com/ja-jp/azure/security/fundamentals/shared-responsibility#cloud-security-advantages

- オンプレミス
  - セキュリティに投資できるリソース（人、予算、機材）は限られている
  - セキュリティのすべての面を、お客様が管理する必要がある
  - 脆弱性が発生しやすい
- クラウド
  - クラウドが提供するセキュリティ機能を活用できる
  - サービスによっては、責任範囲をクラウドプロバイダーにシフトできる

クラウドに移行することで、これまでセキュリティに費やしてきたリソースを、アプリケーションへの新機能の追加など、より優先度の高い事項に割り当てることができる。

## Azure 階層

■Azure Resource Manager

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/overview

- Azure のデプロイおよび管理サービス
- 一貫性のある、リソースの管理レイヤーを提供
- 「Azure Resource Manager テンプレート」を使ってリソースをデプロイできる

■ARMテンプレート

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/overview

- JavaScript Object Notation (JSON) ファイル
- デプロイを自動化できる
  - 繰り返しのデプロイが正確・容易になる
- インフラストラクチャをコードで表現
  - [Infrastructure as Code (IaC)](https://docs.microsoft.com/ja-jp/dotnet/architecture/cloud-native/infrastructure-as-code)

■スコープ

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/overview#understand-scope

```
管理グループ
  └サブスクリプション
    └リソースグループ
      └リソース
```

- 各スコープで、ユーザーなどに、ロール(Azure RBACロール)を割り当てできる
- 各スコープにポリシー(Azure Policy)を設定できる
- サブスクリプション、リソースグループ、リソースに、リソースロックを設定できる

■リソースグループ

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/overview#resource-groups

サブスクリプションの下にリソースグループを作成できる。

- リソースは、リソースグループに所属する
- リソースグループにはいつでもリソースを作成（追加）できる
- リソースグループを削除すると、リソースグループ以下のリソースがすべて削除される

■管理グループ

https://docs.microsoft.com/ja-jp/azure/governance/management-groups/overview

## Azure Policy

https://docs.microsoft.com/ja-jp/azure/governance/policy/overview

## Azure ロール ベースのアクセス制御 (RBAC)

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/overview


## Azure RBAC と Azure Policy の比較

## Azure の組み込みロール

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles

## リソース ロック

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/lock-resources?tabs=json

## Azure Blueprints

https://docs.microsoft.com/ja-jp/azure/governance/blueprints/overview

## Azure サブスクリプション管理

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-how-subscriptions-associated-directory

# ラボ 01: ロールベースのアクセス制御

# ラボ 02: Azure Policy

# ラボ 03: Resource Manager ロック
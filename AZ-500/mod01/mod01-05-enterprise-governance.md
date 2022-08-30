# mod1-5 エンタープライズガバナンス

## 共同責任モデル(Shared responsibility model)

https://docs.microsoft.com/ja-jp/azure/security/fundamentals/shared-responsibility

■共同責任モデルとは？

[→共同責任モデル](../../SC/shared-responsibility-model.md)

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

Azureのデータセンターは極めて高度なセキュリティで守られており、国際的な第三者機関により監査を受け、多数のセキュリティ認証を取得している。

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

[ARMテンプレートの例](https://github.com/hiryamada/labvm/blob/main/azuredeploy.json)

- Windows VMをデプロイする
- VMに、Microsoft Edge, .NETの開発ツールなどをインストールする

■スコープ

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/overview#understand-scope

```
管理グループ 2018年~
  └サブスクリプション
    └リソースグループ
      └リソース
```

- 各スコープで、ユーザーなどに、ロール(Azure RBACロール)を割り当てできる
- 各スコープにポリシー(Azure Policy)を設定できる
- サブスクリプション、リソースグループ、リソースに、リソースロックを設定できる

[スコープ/ロール/ポリシー/ロックのまとめ](../../AZ-104/pdf/mod02/ロール・ポリシー全体像.pdf)


■リソースグループ

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/overview#resource-groups

サブスクリプションの下にリソースグループを作成できる。

- リソースは、リソースグループに所属する
- リソースグループにはいつでもリソースを作成（追加）できる
- リソースグループを削除すると、リソースグループ以下のリソースがすべて削除される
- リソースグループ間でリソースを移動できる
  - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/move-resource-group-and-subscription)
  - [Azure Resource Mover](https://docs.microsoft.com/ja-jp/azure/resource-mover/)
    - VM等を、リージョン間で移動する

■管理グループ

https://docs.microsoft.com/ja-jp/azure/governance/management-groups/overview

- 管理グループで、組織の構造を表現することができる
  - 階層構造（入れ子）が可能
- サブスクリプションを管理グループに移動することができる
- 管理グループで、複数のサブスクリプションに対する共通の設定を行える

## Azure Policy

https://docs.microsoft.com/ja-jp/azure/governance/policy/overview

- リソースに対するルールを設定できる
- 組織のコンプライアンスを達成することができる

ポリシーの例:
- 特定のリージョンにしかリソースを作れないようにする
- 特定のサイズのVMしか作れないようにする
- リソースへのタグ付けを強制する

## Azure ロール ベースのアクセス制御 (RBAC)

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/overview

注意: Azure ADのロールとは別のもの。

[スコープ/ロール/ポリシー/ロックのまとめ](../../AZ-104/pdf/mod02/ロール・ポリシー全体像.pdf)


## Azure RBAC と Azure Policy の比較

Azure RBAC:
- ユーザーに対して権限を割り当てる仕組み
- デフォルトで拒否
  - ロールが割り当てられていないユーザーは一切の権限を持たない
- 加算式
  - ユーザーにロールAとロールBを割り当てると、両方の権限が利用できる

ポリシー:
- リソースに対してルールを設定する仕組み
- デフォルトで許可
  - ポリシーで明示的に拒否
- 「効果」（Effect）により、動作が変わる
  - ポリシーに沿わないリソースの作成を[拒否](https://docs.microsoft.com/ja-jp/azure/governance/policy/concepts/effects#deny)（Effect=Deny）
  - ポリシーに準拠するようにリソースを自動で[修復](https://docs.microsoft.com/ja-jp/azure/governance/policy/how-to/remediate-resources)（Effect=Modify）

## Azure の組み込みロール

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles

## リソース ロック

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/lock-resources

- 削除ロック: リソースの削除を禁止
- 読み取り専用ロック: リソースの削除・変更を禁止

## Azure Blueprints

https://docs.microsoft.com/ja-jp/azure/governance/blueprints/overview

- ARMテンプレート、Azure RBACロール、ポリシーなどを単一のブループリント定義にパッケージ化
  - テンプレートのデプロイ、ユーザーへのロールの割り当て、リソースグループ等へのポリシーの割り当てを一度に実行できる
- クラウド アーキテクトは組織の標準とベスト プラクティスに準拠した環境を設計できる
- アプリ チームはより迅速に実稼働環境をデプロイできる
- 作成したブループリントは管理グループやサブスクリプションに保存される。

## Azure サブスクリプション管理

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-how-subscriptions-associated-directory

- [リソースプロバイダーの登録](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/resource-providers-and-types)
- [クォータの管理](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/azure-subscription-service-limits)
  - [Azureサポートに、クォータ制限の引き上げを依頼する](https://github.com/hiryamada/notes/blob/main/AZ-104/pdf/mod99-closing/support.pdf)
- [コスト管理](https://docs.microsoft.com/ja-jp/azure/cost-management-billing/cost-management-billing-overview)
- テナントにサブスクリプションを追加することができる

[→ コスト管理の解説](../../AZ-304/mod12-01-cost-management.md)

# ラボ01～03

- 60min
- Azure Passサブスクリプションを使用します
- 手順書: https://microsoftlearning.github.io/AZ-500JA-AzureSecurityTechnologies/

# ラボ 01: ロールベースのアクセス制御

https://github.com/hiryamada/notes/blob/main/AZ-500/lab/lab01.md

# ラボ 02: Azure Policy

https://github.com/hiryamada/notes/blob/main/AZ-500/lab/lab02.md

# ラボ 03: Resource Manager ロック

https://github.com/hiryamada/notes/blob/main/AZ-500/lab/lab03.md

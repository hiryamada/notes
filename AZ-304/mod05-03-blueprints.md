# Azure Blueprints

Azure Resource Manager テンプレート、Azure ロールベースのアクセス制御 (Azure RBAC)、ポリシーなどの成果物を単一のブループリント定義にパッケージ化するしくみ。

組織内のチームは、「ブループリント」を使用して、新しい環境を迅速に立ち上げることができる

https://docs.microsoft.com/ja-jp/azure/governance/blueprints/

2018/9/24 プレビュー https://azure.microsoft.com/ja-jp/updates/azure-blueprints-in-public-preview/

（2021/10現時点でもプレビューとなっている）

※ブループリント: [青図（あおず）](https://ja.wikipedia.org/wiki/%E9%9D%92%E5%9B%B3)。青焼き。図面。設計図。転じて、完成予想図。
https://www.google.com/search?q=%E3%83%96%E3%83%AB%E3%83%BC%E3%83%97%E3%83%AA%E3%83%B3%E3%83%88+%E8%A8%AD%E8%A8%88%E5%9B%B3&tbm=isch

■ブループリントとは？

ARMテンプレート、RBACロール割り当て、ポリシー割り当てを一つにまとめることができるしくみ。

■アーティファクト

ブループリントに含まれるもの。

- リソースグループ
- ARMテンプレート
- ポリシーの割り当て
- ロールの割り当て

■ブループリントの「作成」

管理者は、ブループリントを作成し、管理グループやサブスクリプションに保存することができる。

ブループリントの作成: https://docs.microsoft.com/ja-jp/azure/governance/blueprints/create-blueprint-portal

■ブループリントの「発行」

https://docs.microsoft.com/ja-jp/azure/governance/blueprints/concepts/lifecycle#creating-and-editing-a-blueprint

ブループリントを「発行」すると、ブループリントの利用者がそれを利用する（「割り当て」する）ことができるようになる。

一度発行を行うと、バージョン番号が付けられ、変更はできなくなる。

新しいバージョンのブループリントを発行することは可能。

■ブループリントの「割り当て」(assignments)

ブループリントの利用者（Azureユーザー）は、ブループリントを使って、ARMテンプレートをデプロイし、ロールやポリシーを割り当てることができる。

Azure PowerShellやAzure CLIを使って、コマンドから「割り当て」を行うこともできる。

Azure PowerShell: https://docs.microsoft.com/ja-jp/azure/governance/blueprints/how-to/manage-assignments-ps#create-blueprint-assignments

Azure CLI: https://docs.microsoft.com/ja-jp/cli/azure/blueprint/assignment?view=azure-cli-latest

■GitHub サンプルリポジトリ

https://github.com/Azure/azure-blueprints


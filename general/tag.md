# タグ

ドキュメント: タグを使用して Azure リソースを整理する
https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/tag-resources?tabs=json

- Azure リソース、リソース グループ、サブスクリプションにタグを追加できる。
- 1 つのリソースまたはリソース グループにつき最大 50 個のタグがサポートされ
- タグは名前と値で構成される。名前の大文字・小文字は区別されないが、値は指定された大文字・小文字がそのまま記録される。
- 値はプレーンテキストとして記録される（暗号化されない）ので、機密性の高い情報（パスワード等）は設定すべきではない。

# タグの例

```
VM
├ owner: Yamada
├ project: ProjectX
├ environment: Development (/Staging/Production)
└ costcenter: A
```

タグは、リソースの動作には特に影響を及ぼさないが、ユーザーがリソースにタグを付けることで、リソースに必要な情報を付け足すことができる。

# タグの応用例


- 特定のタグがつけられたリソースの一覧を取得する
  - [az resource list --tag)](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/tag-resources?tabs=json#list-by-tag-1)
- 特定のタグがつけられたVMを一斉に起動または停止する
  - [Azure Automationを使用](https://docs.microsoft.com/ja-jp/azure/automation/automation-solution-vm-management)
- タグを使用して、コストを集計する（後述）

# タグを使用したコストの集計

タグを使用して課金データをグループ化できる。たとえば「コストセンター」（部署など）や、プロジェクト別、環境別にコストを集計できる。

```
サブスクリプション
├リソース1 (タグ: CostCenter=A) 10$
├リソース2 (タグ: CostCenter=A) 30$
├リソース3 (タグ: CostCenter=B) 50$
└リソース4 (タグ: CostCenter=B) 70$
```

- リソース1とリソース2のコストはAとして集計できる。10 + 30 = 40
- リソース3とリソース4のコストはBとして集計できる。50 + 70 = 120

# タグの「継承」

リソース グループまたはサブスクリプションに適用されたタグは、リソースに継承されない。

ただし、Azureポリシーを使用すると、リソースグループやサブスクリプションからタグを継承するように指定することができる。

# タグ関連のポリシー

タグ付けのルールと規則を強制するには、Azure Policy を使用する。

タグの継承や、特定のタグの付与を必須とするといったポリシーを利用できる。

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/tag-policies

# 組織としてのタグ付け戦略

タグ付けのルールがないと、組織内のユーザーが、タグを付けなかったり、バラバラなタグ付けをしたりしてしまう。

タグを適切に付与して運用するためには、「タグ付け戦略」（タグ付けの方式、ルール）を決めて、組織内で一貫して適用する。

https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/azure-best-practices/naming-and-tagging


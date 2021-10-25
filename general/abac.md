# Attribute Based Access Control(ABAC)

2021/5/13 Attribute Based Access Control(ABAC) パブリックプレビュー https://techcommunity.microsoft.com/t5/azure-active-directory-identity/introducing-attribute-based-access-control-abac-in-azure/ba-p/2147069

■（一般的に）ABACとは

※ABACはAzure特有のしくみではない。

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/conditions-overview

属性(Attribute)に基づいて、リソースへのアクセス権を付与できる。

（一般的な意味でのABACにおいて）属性は「セキュリティプリンシパル」（ユーザー等）や「リソース」などに関連付けられる。


ABACのイメージ:
```
ユーザー（属性project = x）
  ↓ ABACによってアクセスが許可される
リソース（属性project = x）
```


■Azure RBACとの関係

AzureのもつABACの仕組みは「Azure ABAC」と呼ばれる。

Azure ABACは、Azure RBAC を基盤としている。

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-auth-abac?toc=/azure/storage/blobs/toc.json#supported-attributes-and-operations

ABACはRBACに置き換わるというものではなく、RBACと組み合わせて、より細かいアクセス制御を行うという位置づけである。

■Azure ABAC のしくみ

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/conditions-overview#what-are-role-assignment-conditions

ロールの割り当ての「条件」を追加することにより構築される。

条件を追加することで、ロールによる権限の割り当てを**絞り込む**。

■ロール割り当ての「条件」（role assignment conditions）

「ロールの割り当て」にオプションで追加することができるチェック。さらにきめ細かなアクセス制御を可能にする。

（A **role assignment condition** is an **additional check** that you can **optionally add to your role assignment** to provide more fine-grained access control.）

条件は、ロールの定義とロールの割り当ての一環として、**付与されたアクセス許可を絞り込む**もの。

たとえば、特定のタグが設定されたオブジェクトしか読み取れない、という条件を設定できる。

条件を使用して特定のリソースに対するアクセスを明示的に拒否することは**できない**。

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/conditions-overview#where-can-conditions-be-added

条件は、ロールの割り当てと同じスコープに追加される。

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/conditions-overview#what-does-a-condition-look-like

条件は、新規または既存のロールの割り当てに追加できる。

■条件

「操作」と「式」で構成される。

- 操作: 
  - 「Delete a blob」「Read a blob」「Write to a blob」など
- 式:
  - 「属性ソースと属性」「演算子」「値」で構成される。
  - 属性ソース: Resource等
  - 属性: Container name等
  - 演算子: StringEquals等
  - 値: test等

■属性(Attribute)

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-auth-abac?toc=/azure/storage/blobs/toc.json#supported-attributes-and-operations

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-auth-abac-attributes#attributes

@Resource または @Request

- @Resource
  - アクセスされているストレージ リソースの既存の属性 (ストレージ アカウント、コンテナー、BLOB など) を参照
- @Request
  - ストレージ操作要求に含まれる属性

```
@Resource[Microsoft.Storage/storageAccounts/blobServices/containers:name] StringEquals 'blobs-example-container'
```

■Azure RBACが使用できるロール

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/conditions-overview#where-can-conditions-be-added

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-auth-abac?toc=/azure/storage/blobs/toc.json#supported-attributes-and-operations

以下の組み込みロール、または、カスタムロール。

- [ストレージ BLOB データ共同作成者](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#storage-blob-data-contributor)
- [ストレージ BLOB データ所有者](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#storage-blob-data-owner)
- [ストレージ BLOB データ閲覧者](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#storage-blob-data-reader)

現状この3種類だけ。

■Blobでの利用例

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-auth-abac?toc=/azure/storage/blobs/toc.json

■ハンズオン

事前準備: 
- Azure ADのユーザーを追加
- ストレージアカウントを作成

ロールの割り当て（ABACの使用）

- 追加＞ロールの割り当ての追加
- ロール「ストレージ BLOB データ共同作成者」、「次へ」
- 「＋メンバーを選択する」、作成したAzure ADのユーザーを選択、「次へ」
- 「＋条件を追加する」
- 「操作の選択」で「Delete a blob」をチェック、「選択」
- 「＋式の追加」で属性ソース「Resource」、属性「Container name」、演算子「StringEquals」、値「test」、「保存」
- 「レビューと割り当て」

割り当てが反映されるまで10分ほど待つ必要がある。

割り当てを実施後、そのAzure ADのユーザーでAzure portalにサインイン。

ストレージアカウントにてBlobコンテナーを作成し、Blobをアップロードする。

testという名前のコンテナーでない場合は、Blobの削除ができないことが確認できる。



■エンタイトルメント管理とは？

https://learn.microsoft.com/ja-jp/azure/active-directory/governance/entitlement-management-overview

エンタイトルメント管理は、ID とアクセスのライフサイクルを大規模に管理できる、ID ガバナンス機能。

Azure ADの一部。

[Azure Active Directory] ＞ [Identity Governance] ＞ [エンタイトルメント管理]

- 「アクセス パッケージ」や「カタログ」を管理する。
- ユーザーに「アクセス パッケージ」を割り当てる・剥奪する

■「アクセス パッケージ」とは？

https://learn.microsoft.com/ja-jp/azure/active-directory/governance/entitlement-management-overview#what-are-access-packages-and-what-resources-can-i-manage-with-them

ユーザーがプロジェクトで作業したりタスクを遂行するために必要となるすべてのリソースと、そのアクセス権をバンドルしたもの（束ねたもの）。

https://jpazureid.github.io/blog/azure-active-directory/access-management-with-access-package/
例:

- 新規ユーザーに、アクセス権を付与する（グループに入れる、アプリを割り当てる）のが大変
- 新規ユーザーに、 Sharepoint のアクセス権を割り当てするのが面倒
- ユーザーに割り当てたアクセス権の剥奪を忘れてしまう

「アクセス パッケージ」を活用することで、必要なアクセス権の付与もしくは剥奪を一括して行うことができ、管理者の負荷を減らすことができる。

```
アクセス パッケージA
├グループ
├アプリ
└SharePoint サイト

アクセス パッケージB
├グループ
├アプリ
└SharePoint サイト
```

「アクセス パッケージ」が割り当てられたユーザーは、

- 指定したグループに追加される。
- アプリにアクセスできる（アプリが割り当てされる）。
- SharePointサイトにアクセスできる。

※SharePoint = イントラネットでファイル共有、情報共有（Wikiなど）の機能を提供するしくみ。

■「カタログ」とは？

「カタログ」は、「アクセス パッケージ」で利用される「リソース」（グループ、アプリ、SharePointサイト）を定義するもの。

```
カタログ
├グループ
├アプリ
└SharePoint サイト
```

「アクセス パッケージ」を作成するには、事前に「リソース」を「カタログ」に定義しておく必要がある。



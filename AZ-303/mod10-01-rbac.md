# Azure RBAC (Role-based access control)

- Azure Resource Manager 上に構築された承認システム
- Azure リソースに対するアクセスをきめ細かく管理
- ユーザーに権限を与える

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/overview

2014/4/2～、Microsoft Build 2014(イベント)にて「Azure Resource Manager」（ARM）が導入された。

※それより以前は「Azure Service Manager」（ASM）が使用されていた。ポータルは manage.windowsazure.com だった。

以下が導入された。

- リソース グループ
- ARMテンプレート（当時 Azure Templates）
- [新しいポータル portal.azure.com](https://www.publickey1.jp/blog/14/microsoft_azuremonacobuild_2014.html) 

2014/9/10 Azure RBAC プレビュー https://azure.microsoft.com/ja-jp/updates/role-based-access-control-in-azure-preview-portal/

2015/11/12 Azure RBAC 一般提供開始 https://azure.microsoft.com/ja-jp/updates/general-availability-role-based-access-control/

2015/12/2 [新しいポータルが正式版に](https://atmarkit.itmedia.co.jp/ait/articles/1512/24/news016.html)

2018/7/31 管理グループ 一般提供開始 https://azure.microsoft.com/ja-jp/blog/azure-management-groups-now-in-general-availability/

2021/5/13 Attribute Based Access Control(ABAC) パブリックプレビュー https://techcommunity.microsoft.com/t5/azure-active-directory-identity/introducing-attribute-based-access-control-abac-in-azure/ba-p/2147069

■スコープ

ロールの割り当ては、基本的に、以下の4つのスコープのいずれかで行う。

```
管理グループ
└サブスクリプション
  └リソースグループ
    └リソース
```

[モジュール6](mod06-04-storage-aad.md)で学習したように、リソースによっては、Blobコンテナー、テーブル、キューなどの（追加の）スコープを持つ場合がある。

```
管理グループ
└サブスクリプション
  └リソースグループ
    └ストレージアカウント
     ├Blobコンテナー
     ├テーブル
     └キュー
```

ロールの割り当ては下位のスコープへ継承される。



■アクセス制御（IAM）

IAM = Identity and Access Management

Azure portalにおいて、ロールの割り当ては、各スコープの画面左に表示されるメニュー「アクセス制御（IAM）」から管理する。

■セキュリティ プリンシパル

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/overview#security-principal

「セキュリティ プリンシパル」は以下のいずれか。

- ユーザー
- グループ
- サービス プリンシパル
  - [マネージドID](https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/overview): サービス プリンシパルの一種。

セキュリティ プリンシパルに、ロールを割り当てることができる。

プリンシパル(Principal):
- [バレエ団における主役級のダンサー](https://ja.wikipedia.org/wiki/%E3%83%97%E3%83%AA%E3%83%B3%E3%82%B7%E3%83%91%E3%83%AB)
- [プリンシパルエンジニア](https://recruit.pepabo.com/environment/engineer/)のように、[役職において「上級～」「主席～」「最高～」を表す](https://chewy.jp/businessmanner/27359/)
- セキュリティ プリンシパル(Windows): ユーザー、プロセス、セキュリティグループなど、[OSによって認証される任意のエンティティ](https://docs.microsoft.com/ja-jp/windows/security/identity-protection/access-control/security-principals#what-are-security-principals)。一位のSID(セキュリティ識別子)によって区別される。
- Azureの[ユーザープリンシパル名（UPN）](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/plan-connect-userprincipalname#what-is-userprincipalname)。インターネット形式のログイン名。[RFC 822](https://www.wdic.org/w/WDIC/RFC%20822)(電子メールの標準)に準拠。Azure ADのサインインにはUPNが用いられる。

複数のロールの割り当てが可能。権限は加算方式で追加される。ロールAとロールBをユーザーに割り当てると、ユーザーはロールAとロールBの両方の権限が利用できる。

■ロール（ロールの定義）

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/role-definitions

- Actions: ロールで実行できる管理操作
- NotActions: Actionから **除外** される管理操作
- DataActions: ロールで実行できるデータ操作
- NotDataActions: DataActionから **除外** されるデータ操作
- AssignableScopes: このロール定義を使用できるスコープ

※NotActions, NotDataActionsは「このロールの定義から **除外** する操作」であり、 **禁止** ではない。

例: ロール1のActions/NotActions
```
Actions: [Microsoft.Compute/virtualMachines/*]
NotActions: [Microsoft.Compute/virtualMachines/delete]
```

仮想マシンのすべての操作を許可（ただし削除を **除外** ）。

※「削除を禁止」では **ない**。

例: ロール2のActions/NotActions
```
Actions: [Microsoft.Compute/virtualMachines/delete]
NotActions: []
```

仮想マシンの削除を許可。

※ここで、ユーザーに上記ロール1とロール2を割り当てると、ユーザーは仮想マシンのすべての操作が可能となる。

■操作の一覧

Actions 等に指定できる操作の一覧。

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/resource-provider-operations

■ロールの種類

- Azure AD管理者ロール
- 従来のサブスクリプション管理者ロール
- Azure RBACロール

[まとめPDF](../AZ-104/pdf/mod02/ロール・ポリシー全体像.pdf)


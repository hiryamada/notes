
# 管理グループ

※注意: Azure ADの機能ではない

https://docs.microsoft.com/ja-jp/azure/governance/management-groups/overview


- 「管理グループ」と呼ばれるコンテナーにサブスクリプションを整理することができる。
- 最上位には「ルート管理グループ」が存在する
- 6段まで階層構造にできる
- 複数のサブスクリプションに対するロールやポリシーの設定をまとめることができる
- 単一の管理グループ内のすべてのサブスクリプションは、同じ Azure Active Directory テナントを信頼する必要がある。
  - つまり、テナント1のサブスクリプションとテナント2のサブスクリプションを1つの管理グループに入れることはできない。


■初期状態

```
ルート管理グループ
└ サブスクリプション
```
■管理グループ「mg1」を作成

```
ルート管理グループ
├ mg1
└ サブスクリプション
```

■サブスクリプションを「mg1」に移動

```
ルート管理グループ
└ mg1
  └ サブスクリプション
```

■4種類の「スコープ」

```
管理グループ
└ サブスクリプション
  └ リソースグループ
    └ リソース
```

■昇格

https://docs.microsoft.com/ja-jp/azure/role-based-access-control/elevate-access-global-admin

- Azure AD の全体管理者（グローバル管理者）には、テナントのすべてのサブスクリプションと管理グループにアクセスする権限が与えられていない場合がある。
- Azure AD の全体管理者は、自分自身を「昇格」できる。
- 「昇格」を行うと、その管理者に、ルート管理グループのレベルで、[ユーザーアクセス管理者ロール（User Access Administrator）](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#user-access-administrator)が割り当てされる。


■ハンズオン: 昇格

- Azure portalの画面上部の検索で「Azure Active Directory」を検索し、「Azure Active Directory」へ移動
- 画面左側のメニュー「プロパティ」をクリック
- 画面下部の「Azure リソースのアクセス管理」を「はい」に設定
- 画面上部の「保存」をクリック

■ハンズオン: 管理グループの作成

- Azure portalの画面上部の検索で「管理」を検索し、「管理グループ」へ移動
- 「管理グループの使用を開始します」をクリック
- 「管理グループID」と「管理グループの表示名」両方に「mg1」と入力し、画面下の「Submit」をクリック
- Webブラウザーで、ページをリロードする（Ctrl + R）
- 「mg1」をクリック
- 画面上部「サブスクリプションの追加」をクリック
- 「サブスクリプション」に、「Azure Pass - スポンサー プラン」が表示されていることを確認し、画面下部「保存」をクリック
- 画面上部の「ホーム ＞ 管理グループ」の「管理グループ」リンクをクリックして、管理グループのトップ画面に戻る
- 画面上部の「更新」をクリック
- Tenant Root Groupのツリー内の「＞」をクリックして展開し
- 以下のような構成になっていればOK。


```
Tenant Root Group（ルート管理グループ）
└mg1 （新しく作成した管理グループ）
  └Azure Pass スポンサー プラン
```

# サブスクリプション

■クォータ

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/azure-subscription-service-limits

サブスクリプション等には、作成できるリソース数などの上限値（クォータ）がある。

例: サブスクリプションには最大980個まで、リソースグループを作成できる など。

Azureサポートに問い合わせて、クォータの「引き上げ」を要求することができる。

例: Azure VMのvCPUクォータ制限の引き上げを要求する
https://docs.microsoft.com/ja-jp/azure/azure-portal/supportability/per-vm-quota-requests#request-a-standard-quota-increase-from-help--support

※「引き上げ」ができない「ハードリミット」も存在する。サブスクリプションのハードリミットに近づいた場合は、サブスクリプションそのものを追加して対応する。


# リソース グループ

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/manage-resource-groups-portal#what-is-a-resource-group

- リソース グループは、Azure ソリューションの関連するリソースを保持するコンテナー
- リソースをリソースグループにまとめることができる
- リソースグループを削除すると、中のリソースは同時に削除される
- 複数のリソースに対するロールやポリシーの設定をまとめることができる
- 入れ子にすることはできない


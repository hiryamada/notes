# 参考: ゼロトラストモデル

■ゼロトラストとは？ 

以下のような「原則」を組織に適用し、セキュリティを強化するという概念。

- (1)常に認証・承認を実施。
- (2)最小特権アクセスを使用。
- (3)セキュリティ侵害を想定して対策。

参考: [Microsoft Learn 組織にゼロトラストを構築する](https://docs.microsoft.com/ja-jp/learn/modules/m365-identity-zero-trust/)

# 参考: Microsoft Identity Manager

■Microsoft Identity Managerとは？

[Microsoft Identity Manager (MIM) 2016](https://docs.microsoft.com/ja-jp/microsoft-identity-manager/microsoft-identity-manager-2016): 以前のForefront Identity Manager (FIM)。複数システム間でのID/パスワード管理を一元化。Active Directory, Lotus Notes, Novel Directoryなど。[大塚商会様のわかりやすい紹介](https://www.otsuka-shokai.co.jp/products/microsoft/active-directory/forefront-identity-manager/).[「コネクタ」を使って、さまざまなシステムと接続できる。](https://docs.microsoft.com/ja-jp/microsoft-identity-manager/supported-management-agents)

- Active Directory Domain Services (AD DS)
- Novell eDirectory
- IBM DB2
- Oracle Databas
- Microsoft SQL Server
- 汎用LDAPコネクタ
- Lotus Domino (Lotus Notes)
- など

# Azure AD Privileged Identity Management (PIM)

https://docs.microsoft.com/ja-jp/azure/active-directory/privileged-identity-management/pim-configure

■PIMとは？

時間/承認ベースで、特権アクセスのロールをJIT(ジャストインタイム, 必要な時間だけ)でユーザーに割り当てる仕組み。

- Azure ADロールとAzure RBACロールに対応
- ロールを有効化できる開始日と終了日を指定できる
- 監査履歴を利用できる

ロールの利用時に以下のアクションを実施:
- ロールを利用する理由を入力させる
- 管理者に通知する
- 管理者による承認を行う
- ロールを有効化（アクティベーション）できる時間を指定する
- MFAを強制する

定期的に以下を実施:

- 「アクセスレビュー」を実施し、不要なロール割り当てを取り除くことができる。


■PIMのスコープ

Azure ADロール
https://docs.microsoft.com/ja-jp/azure/active-directory/privileged-identity-management/pim-how-to-add-role-to-user?tabs=new

Azureリソースロール
https://docs.microsoft.com/ja-jp/azure/active-directory/privileged-identity-management/pim-resource-roles-assign-roles

■PIM用語の説明（たとえ）

サーバールームに出入りするための「鍵」がいくつかあるとします。

担当者Aには、いつでも鍵を使えるように、鍵を持たせます。鍵を持たせる期間を決めることができますが、特に期間を決めず、退職するまでずっと鍵を持たせたままにすることもできます。

担当者Bには、鍵を借りる権限があります。必要なときに、申請して、鍵を借りてもらいます。鍵を借りた場合は、数時間以内に返さなければなりません。鍵を借りることができる期間を決めることができますが、特に期間を決めず、退職するまでずっと鍵を借りられるようにすることもできます。

担当者Cは、鍵を持っておらず、鍵を借りる権限もありません。

鍵: ロール

鍵を持たせる: 「アクティブな割り当て」

鍵を借りる権限がある: 「資格のある割り当て」

鍵を借りる: 「アクティブ化」

鍵を持たせる期間 / 鍵を借りることができる期間 : 「割り当ての開始日時・終了日時」

退職するまでずっと鍵を持たせたままにする: 「永続するアクティブな割り当てを許可する」

退職するまでずっと鍵を借りられるようにする: 「永続的な資格のある割り当てを許可する」

鍵を借りる権利がある: 「資格のある」「対象」「Eligible」

借りた鍵を利用できる時間（返却までの時間）: 「アクティブ化の最大期間（時間）」

担当者A、担当者B：割り当てされている（割り当てのメンバーとなっている）Azure ADユーザー

担当者C: 割り当てされていない（割り当てのメンバーとなっていない）Azure ADユーザー

注意: 「アクティブな割り当て」と「アクティブ化」は別のもの

■PIMオンボーディング (PIMの利用を開始する)

※PIMでAzureサブスクリプションの管理などを開始することを「オンボード」と呼んだりする。

https://docs.microsoft.com/ja-jp/azure/active-directory/roles/security-planning#general-preparation


ユーザーへのロールの割り当て:
- Azure portalで「PIM」を検索→Privileged Identity Management 
- 管理＞Azure ADロール
- 資格の割り当て（クリックできるようになるまで若干時間がかかる）
- ＋割り当ての追加
- ロールを選択。例: グローバル管理者
- メンバーを選択。例: user1
- 次へ
- 割り当ての種類
  - 対象(Eligible): ロールを利用する際にアクション（承認など）が必要
  - アクティブ(Active): ロールを利用するためにアクションは不要
- 割り当ての期間
  - 永続
  - 開始日と終了日

割り当ての確認:
- Azure portalで「PIM」を検索→Privileged Identity Management 
- 管理＞割り当て

アクティビティ（アクティブ化の履歴）の確認:
- Azure portalで「PIM」を検索→Privileged Identity Management 
- 管理＞割り当て
- 「資格のある割り当て」でユーザーをクリック

■特権ロール管理者

https://docs.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference#privileged-role-administrator

このロールが割り当てられたユーザーは、
- Azure Active Directory と Azure AD Privileged Identity Management 内でロールの割り当てを管理できる
- Azure AD ロールに割り当てることができるグループの作成と管理が可能
- Privileged Identity Management と管理単位のすべての側面を管理できる

■PIM構成設定

https://docs.microsoft.com/ja-jp/azure/active-directory/privileged-identity-management/pim-how-to-change-default-settings?tabs=new

ロールごとの設定の確認/編集:
- Azure portalで「PIM」を検索→Privileged Identity Management 
- 管理＞Azure ADロール
- ロール
- ロールを選択。例: グローバル管理者
- ロールの設定＞編集
  - 「アクティブ化」タブ
    - アクティブ化の最大時間
    - アクティブ化にMFAが必要
    - アクティブ化に理由が必要
    - アクティブ化に承認が必要
  - 「割り当て」タブ
    - 永続的に資格のある割り当てを許可 / ～ヶ月後に有効期限が切れる
  - 「通知」タブ

# ラボ5

- 60min
- Azure Passサブスクリプションを使用します
- 手順書: https://microsoftlearning.github.io/AZ-500JA-AzureSecurityTechnologies/
- 解説: https://github.com/hiryamada/notes/blob/main/AZ-500/lab/lab05.md

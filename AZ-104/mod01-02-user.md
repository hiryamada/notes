
# ユーザーの種類

[通常、Azure AD は次の 3 つの方法でユーザーを定義します。](https://docs.microsoft.com/ja-jp/learn/modules/manage-users-and-groups-in-aad/3-users)

- クラウドID（Cloud identities）: Azure ADにのみ存在するユーザーです。

- ディレクトリ同期ID（Directory-synchronized identities）: オンプレミスのAD DSに存在するユーザーです。[Azure AD Connect](https://docs.microsoft.com/ja-jp/learn/modules/manage-users-and-groups-in-aad/6-azure-ad-connect)によってIDが同期されます。

- ゲストユーザー（Guest users）: 組織とコラボレーションするユーザーをゲスト ユーザーとして追加し、ディレクトリに招待できます。招待するユーザーは、他のテナントにアカウントがあってもなくてもかまいません。招待されたユーザーにはメールが送信されます。メール内の「Accept Invitation」をクリックして、招待を受け入れます。

# ユーザー管理を実行できる管理者

ユーザーを追加または一括追加するには、[ユーザー管理者](https://docs.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference#user-administrator)または[グローバル(全体)管理者](https://docs.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference#global-administrator--company-administrator)である必要があります。

# ユーザーの追加

ユーザーの追加は、Azure portal や PowerShell から実行することができます。

- [Azure portal](https://docs.microsoft.com/ja-jp/azure/active-directory/external-identities/b2b-quickstart-add-guest-users-portal)
- [PowerShell](https://docs.microsoft.com/ja-jp/azure/active-directory/external-identities/b2b-quickstart-invite-powershell)

# ユーザーの一括追加

大量のユーザーを一括で追加するには、Azure portalからCSVファイルのテンプレートをダウンロードし、ユーザーの行を追加して保存し、アップロードします。

- [Azure Portal, CSVファイルを使用した一括作成](https://docs.microsoft.com/ja-jp/azure/active-directory/enterprise-users/users-bulk-add#to-create-users-in-bulk)

CSVファイルには初期パスワードを指定します。ユーザーは、初期パスワードでサインインし、その後パスワードを変更できます。

# ユーザーの削除

[ユーザーを削除した後、アカウントは 30 日間、中断(suspended)状態のままになります。](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-users-restore)

削除されてからまだ 30 日が経過していないユーザーはすべて表示することができます。 これらのユーザーは復元することができます。

30 日間の期間が経過すると、完全削除のプロセスが自動的に開始されます。

# グループ

Azure ADでは、[グループ](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-manage-groups?context=azure/active-directory/enterprise-users/context/ugr-context)を使用して、クラウド ベースのアプリ、オンプレミスのアプリ、およびリソースへのアクセスの管理できます。

Azure ADには、[2種類のグループ](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-groups-create-azure-portal?context=azure/active-directory/enterprise-users/context/ugr-context#group-types)があります。

- セキュリティグループ: グループのユーザーに共有リソース（例：Salesforce）へのアクセス許可を割り当てることができます。
- Office 365グループ: 共有メールボックス、カレンダー、ファイル、SharePoint サイトなどへのアクセスをメンバーに付与することで、共同作業の機会を提供します。

# グループへのユーザーの割り当て

割り当て方法を[メンバーシップ](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-groups-create-azure-portal?context=azure/active-directory/enterprise-users/context/ugr-context#membership-types)といいます。

- 割り当て済み: 手動でユーザーをグループに追加・削除します。
- 動的ユーザー: ルールを使用して、自動的にユーザーをグループに追加・削除します。

# 動的メンバーシップ（動的グループ）

セキュリティ グループまたは Microsoft 365 グループに対し、ルールを作成して、[グループの動的メンバーシップ](https://docs.microsoft.com/ja-jp/azure/active-directory/enterprise-users/groups-dynamic-membership)を有効にすることができます。

ユーザーがルールを満たしている場合、それらはそのグループのメンバーとして追加されます。ルールを満たさなくなると、削除されます。

動的グループのメンバーを手動で追加または削除することはできません。

この機能を使うには、少なくとも 1 つの動的グループのメンバーである一意のユーザーごとに [Azure AD Premium P1 ライセンス](https://azure.microsoft.com/ja-jp/pricing/details/active-directory/)が必要です。 ユーザーを動的グループのメンバーにするために、そのユーザーにライセンスを割り当てる必要はありませんが、少なくともそのすべてのユーザーを対象にできるだけのライセンス数が Azure AD 組織に含まれている必要があります。

:bulb: グループの作成の際に、「メンバーシップの種類」を「動的ユーザー」とし、「動的クエリの追加」でルールを編集します。ルールの編集画面では、「ルールの検証」を使用して、ルールで選択される・されないユーザーの確認ができます。

:bulb: 動的グループの作成後、実際に動的グループにメンバーが反映されるまで、若干（数分）の遅れが発生するようです。

# テナント（ディレクトリ）の管理

[各テナントは完全に独立しています。](https://docs.microsoft.com/ja-jp/azure/active-directory/enterprise-users/licensing-directory-independence)
テナントに親子関係はありません。リソース、管理、[Azure AD Connect](https://docs.microsoft.com/ja-jp/learn/modules/manage-users-and-groups-in-aad/6-azure-ad-connect)を使用した同期について独立しています。つまり、あるテナントへの操作は、別のテナントへ影響を与えません。

[グローバル(全体)管理者](https://docs.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference#global-administrator--company-administrator)は、[新しいテナントを追加することができます。](https://docs.microsoft.com/ja-jp/azure/active-directory/enterprise-users/licensing-directory-independence#add-an-azure-ad-organization)

[Azure portalから、新しいテナントを作成することができます。](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-access-create-new-tenant)

# Azure ADへのサインイン・変更の監視

- [サインイン ログ](https://docs.microsoft.com/ja-jp/azure/active-directory/reports-monitoring/concept-sign-ins#download-sign-in-activities) - ユーザー サインイン アクティビティに関する情報を提供します。

- [監査ログ（監査レポート）](https://docs.microsoft.com/ja-jp/azure/active-directory/reports-monitoring/concept-audit-logs) - ユーザーの追加など、Azure AD 内のさまざまな機能によって行われたすべての変更についてログによる追跡可能性を提供します。

これらのログは、[診断設定を追加](https://docs.microsoft.com/ja-jp/azure/active-directory/reports-monitoring/howto-integrate-activity-logs-with-log-analytics#send-logs-to-azure-monitor)することで、[Azure Monitor ログ](https://docs.microsoft.com/ja-jp/azure/azure-monitor/platform/data-platform-logs#sources-of-data-for-azure-monitor-logs)に送信し、詳細な分析を行ったり、長期保存したりすることができます（詳細はモジュール11で学習します）。

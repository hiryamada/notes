# ロールの種類

大きく分けて、「Azure ADロール」「従来のサブスクリプション管理者」「Azureロール」という3種類のロールがあります。

ロールはたくさんありますが、まずは、下記の10種類のロールを覚えましょう。

[Azure ADロール](https://docs.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference): Azure ADディレクトリにおいて、ユーザーやグループに適用される。

- [グローバル(全体)管理者(Global Administrator)](https://docs.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference#global-administrator--company-administrator) - Azure AD のすべての管理を行います。
- [ユーザー管理者(User Administrator)](https://docs.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference#user-administrator) - ユーザーやグループを作成します
- [課金管理者(Billing Administrator)](https://docs.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference#billing-administrator) - サブスクリプションの管理など

[従来のサブスクリプション管理者ロール](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/rbac-and-directory-admin-roles)：サブスクリプションのレベルで、ユーザーに適用される。

- アカウント管理者(Account Administrator) - アカウントに1人。課金・サブスクリプションの管理
- サービス管理者(Service Administrator) - サブスクリプションに1人。サブスクリプションのフルアクセスを持ち、共同管理者を割り当て可能。
- 共同管理者(Co-Administrator) - サブスクリプションあたり200人。サービス管理者に近い権限を持つが、サービス管理者の変更はできない。

[Azureロール](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/rbac-and-directory-admin-roles#azure-roles)（RBACロール）：管理グループ、サブスクリプション、リソースグループで、ユーザー・グループ・サービスプリンシパル・マネージドIDに適用される。

- 所有者(Owner) - Azure RBAC でロールを割り当てる権限を含め、すべてのリソースを管理するためのフル アクセスを付与します
- 共同作成者(Contributor) - すべてのリソースを管理するためのフル アクセスを付与しますが、Azure RBACでのロール割り当ては許可されません。
- 閲覧者(Reader) - すべてのリソースを表示しますが、変更することはできません。
- ユーザーアクセス管理者(User Access Administrator) - Azure リソースに対するユーザー アクセスを管理できます。

ポイント：
- Azure portalやドキュメントで、表記がゆれていたり、日・英の表記が混在しているがあります。「全体管理者」は「グローバル管理者」とも表記されます。また、「共同開発者」が「Contributor」と表記される場合があります。不安な場合は、Azure portalやドキュメントを一時的に英語表示にして確認するとよいでしょう。
- 「グローバル管理者」「アカウント管理者」「所有者」は、最初はどれも同じような「最上位の管理者」に感じられると思いますが、割り当て可能なスコープや、役割が全く異なります。
- 同様に、「共同管理者」と「共同作成者」も、割り当て可能なスコープや、役割が全く異なります。
- Azure へのサインアップに使用されたアカウントは、Azure ADの「グローバル管理者」となり、かつ、サブスクリプションで「従来のサブスクリプション管理者ロール」の「アカウント管理者」と「サービス管理者」の両方として設定されます。

詳しくは[ドキュメント](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/rbac-and-directory-admin-roles)を参照してください。


# Azure RBAC(Role Base Access Control)

Azure RBAC は [Azure Resource Manager](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/overview) 上に構築された承認システムであり、Azure リソースに対するアクセスをきめ細かく管理できます。

# セキュリティ プリンシパル

Azure リソースへのアクセスを要求するオブジェクトです。
- ユーザー
- グループ
- サービス プリンシパル
- マネージド ID

# [サービスプリンシパルとマネージドID](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/role-assignments-steps)

- サービス プリンシパル: 特定の Azure リソースにアクセスするためにアプリケーションまたはサービスによって使用されるセキュリティ ID です。 アプリケーションに対する "ユーザー ID" (ユーザー名とパスワード、または証明書) と考えることができます。

- マネージド ID: Azure によって自動的に管理される Azure Active Directory 内の ID。 通常、マネージド ID は、Azure サービスに対する認証を受けるための資格情報を管理するクラウド アプリケーションを開発するときに使用します。

Microsoft Learn: [Azure リソースのサービス プリンシパルとマネージド ID を使用して Azure サービスにアプリを認証する](https://docs.microsoft.com/ja-jp/learn/modules/authenticate-apps-with-managed-identities/)

# [ロールの定義](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/role-definitions)

アクセス許可のコレクションです。

- Actions: ロールで実行できる管理操作を指定する文字列の配列
- NotActions: Actions から除外される管理操作を指定する文字列の配列。
- DataActions: 対象のオブジェクト内のデータに対して、ロールで実行できるデータ操作を指定する文字列の配列。
- NotDataActions: 許可された DataActions から除外されるデータ操作を指定する文字列の配列。
- AssignableScopes: 割り当てにロールを使用できるスコープを指定する文字列の配列。

:blub: NotActionsとNotDataActionsは、「禁止する操作」ではなく、「このロール定義の中でActionsやDataActionsから除外する操作」を指定します。

# [スコープ](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/scope-overview)

アクセスが適用されるリソースのセットです。管理グループ、サブスクリプション、リソース グループ、リソースでスコープを指定できます。

# [ロールの割り当て](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/role-assignments-steps)

アクセスの許可を目的として、特定のスコープで、ユーザー、グループ、サービス プリンシパル、またはマネージド ID にロールの定義をアタッチするプロセスです。

# RBAC認証（Azure ADディレクトリとサブスクリプションの関係）

認証と認可がどこで行なわれるかを意識しましょう。

Azure ADで、ユーザーの追加などの操作が行なわれる場合：
- Azure ADディレクトリにて、IDの認証が行なわれます。
- Azure ADのディレクトリにて、ユーザーのAzure ADロールにより、操作の認可が行なわれます。
- この場合サブスクリプションは特に使用されません。

サブスクリプションで、ユーザーによる何らかの操作が行なわれる場合：
- Azure ADディレクトリを使用して、IDの認証が行なわれます。
- サブスクリプションのAzure RBACロールで、操作の認可が行なわれます。

# Azure RBACロール

# 参考: 拒否割り当て

2018年9月頃より、[拒否割り当て](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/deny-assignments)が使用できるようになりました。

[Azure Feedback](https://feedback.azure.com/forums/169401-azure-active-directory/suggestions/10855878-deny-access-control-in-the-rbac)

[GitHub](https://github.com/MicrosoftDocs/azure-docs/commit/20d4bc4947664fe00cdb6c45b06605033c4a7a8b#diff-a0eb974cd5ed4a908675e4fa3f25dc36366c64647e3295cbd9b6d487118c8ce5)

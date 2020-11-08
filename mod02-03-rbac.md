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

# [スコープ](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/scope-overview)

アクセスが適用されるリソースのセットです。管理グループ、サブスクリプション、リソース グループ、リソースでスコープを指定できます。

# [ロールの割り当て](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/role-assignments-steps)

アクセスの許可を目的として、特定のスコープで、ユーザー、グループ、サービス プリンシパル、またはマネージド ID にロールの定義をアタッチするプロセスです。


# Azure RBAC vs Azure ADロール

Azure ADロール

- グローバル管理者
- ユーザー管理者
- 課金管理者

従来のサブスクリプション管理者

- アカウント管理者
- サービス管理者
- 共同管理者

Azureロール

- 所有者
- Contributor
- Reader
- ユーザーアクセス管理者

# RBAC認証

# Azure RBACロール

# 参考: 拒否割り当て

2018年9月頃より、[拒否割り当て](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/deny-assignments)が使用できるようになりました。

[Azure Feedback](https://feedback.azure.com/forums/169401-azure-active-directory/suggestions/10855878-deny-access-control-in-the-rbac)

[GitHub](https://github.com/MicrosoftDocs/azure-docs/commit/20d4bc4947664fe00cdb6c45b06605033c4a7a8b#diff-a0eb974cd5ed4a908675e4fa3f25dc36366c64647e3295cbd9b6d487118c8ce5)

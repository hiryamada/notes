# アプリケーション管理のためのAzure ADロール

■「アプリケーション管理者」ロール

https://learn.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference#application-administrator

アプリの登録と、エンタープライズ アプリのすべての側面を作成および管理できる。

■「クラウド アプリケーション管理者」ロール

https://learn.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference#cloud-application-administrator

アプリの登録と、エンタープライズ アプリのすべての側面 (アプリケーション プロキシを除く) を作成および管理できる。

※アプリケーション プロキシ:
https://learn.microsoft.com/ja-jp/azure/active-directory/app-proxy/application-proxy

Azure ADでサインインしたユーザーに、オンプレミスで稼働しているアプリケーションへのアクセスを提供するしくみ。

■「アプリケーション開発者」ロール

https://learn.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference#application-developer

[ユーザーはアプリケーションを登録できる] の設定とは無関係に、「アプリの登録」を作成できる。

■カスタム ロール

https://learn.microsoft.com/ja-jp/azure/active-directory/roles/delegate-app-roles#create-and-assign-a-custom-role-preview

https://learn.microsoft.com/ja-jp/azure/active-directory/roles/custom-overview

Azure ADにあらかじめ用意された「組み込みのロール」に加えて、「カスタム ロール」を定義できる。

「カスタム ロール」には、任意の「アクション」（アクセスの許可）を追加できる。

■ロール割り当てのスコープ

ロールは、組織全体のスコープで割り当てることも、単一の Azure AD オブジェクト（「アプリ登録」など）に対して割り当てることもできる。


# シングルサインオン(SSO)

※Azure AD Connectの「sSSO」とは別の話題なので注意。

https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/plan-sso-deployment

（まだAzure ADと統合していない）アプリケーションを、Azure ADに統合する際の、SSO方式の選択について。

■SSOとは？

一回Azure ADにサインインするだけで、テナントに登録されたアプリケーションにアクセスすることができるしくみ。

■ライセンス

Azure ADのSSO機能は無料で利用できる（Azure AD Premium等のライセンスが不要）

■Azure ADにおけるSSOの方法

- フェデレーションSSO
  - Azure ADアカウントを使用
  - アプリケーションに対するユーザー認証をAzure ADが実行する
  - SAML、OIDC/OAuth 2.0などのプロトコルをサポート
  - 基本的にはこちらを利用
- パスワード ベースのSSO
  - 初回アクセス時にユーザー名とパスワードを入力してアプリにサインイン
  - ユーザー名とパスワードがAzure ADに記録される
  - 以降のサインインでは、ユーザーに代わって、Azure ADが、ユーザー名とパスワードをアプリに提供
  - フェデレーションSSOがサポートされていない場合はこちらを利用

■最適なSSO方法の選択

https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/sso-options#choosing-a-single-sign-on-method

最適なSSO方法を選択するためのフローチャートが提供されている。


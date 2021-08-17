# シングルサインオン(SSO)

※Azure AD Connectの「sSSO」とは別の話題なので注意!

- [Azure AD ConnectのsSSO（シームレスSSO）](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sso)
  - 会社のデバイスにサインインすると、自動的にAzure ADにもサインインが行われるしくみ。
- （ここで説明する）[Azure ADのSSO](https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/plan-sso-deployment)
  - Azure ADにサインインすると、Azure ADテナントに登録されたアプリケーションにサインインなしでアクセスできるしくみ。


（まだAzure ADと統合していない）アプリケーションを、Azure ADに統合する際の、SSO方式の選択について。

■SSOとは？

一回Azure ADにサインインするだけで、テナントに登録されたアプリケーションにアクセスすることができるしくみ。

■ライセンス

Azure ADのSSO機能は無料で利用できる（Azure AD Premium等のライセンスが不要）

■Azure ADにおけるSSOの方法

- フェデレーションSSO
  - Azure ADアカウントを使用
  - アプリケーションに対するユーザー認証をAzure ADが実行する
  - [SAML](https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/sso-options#saml-sso)、[OIDC/OAuth 2.0](https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/sso-options#openid-connect-and-oauth)などのプロトコルをサポート
  - 基本的にはこちらを利用
- [パスワード ベースのSSO](https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/sso-options#password-based-sso)
  - 初回アクセス時にユーザー名とパスワードを入力してアプリにサインイン
  - ユーザー名とパスワードがAzure ADに記録される
  - 以降のサインインでは、ユーザーに代わって、Azure ADが、ユーザー名とパスワードをアプリに提供
  - フェデレーションSSOがサポートされていないアプリケーションの場合に利用

■最適なSSO方法の選択

https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/sso-options#choosing-a-single-sign-on-method

最適なSSO方法を選択するためのフローチャートが提供されている。


# シングルサインオン(SSO)

※Azure AD Connectの「sSSO」とは別の話題なので注意!

- [Azure AD ConnectのsSSO（シームレスSSO）](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sso)
  - ユーザーが会社のデバイスにサインインすると、自動的にAzure ADにもサインインが行われるしくみ。
- （ここで説明する）[Azure ADのSSO](https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/plan-sso-deployment)
  - Azure ADにサインインすると、以降、Azure ADテナントに登録されたアプリケーションにサインインなしでアクセスできるしくみ。

（まだAzure ADと統合していない）アプリケーションを、Azure ADに統合する際の、SSO方式の選択について。

■SSOとは？

一回Azure ADにサインインするだけで、テナントに登録されたアプリケーションにアクセスすることができるしくみ。

||ユーザー|ユーザー管理者|
|-|-|-|
|SSOを使わない場合|各アプリケーションでサインインが必要<br>各アプリケーションでIDとパスワードを使い分ける必要がある|各アプリケーションでユーザー管理が必要|
|SSOを使う場合|Azure ADにサインインするだけで各アプリケーションを利用できる|Azure ADで一元的にユーザーを管理できる|

■ライセンス

Azure ADのSSO機能は無料で利用できる（Azure AD Premium等のライセンスが不要）。

■Azure ADにおけるSSOサポート

https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/plan-sso-deployment#single-sign-on-options

- クラウド アプリケーション
  - [OpenID Connect / OAuth 2.0](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/active-directory-v2-protocols)
  - [SAML](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/single-sign-on-saml-protocol)
  - [パスワードベース](https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/configure-password-single-sign-on-non-gallery-applications)
  - [リンク](https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/configure-linked-sign-on)
- オンプレミス アプリケーション
  - [パスワードベース](https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/configure-password-single-sign-on-non-gallery-applications)
  - [統合Windows認証](https://docs.microsoft.com/ja-jp/azure/active-directory/app-proxy/application-proxy-configure-single-sign-on-with-kcd)
  - [ヘッダーベース](https://docs.microsoft.com/ja-jp/azure/active-directory/app-proxy/application-proxy-configure-single-sign-on-with-headers)
  - [リンク](https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/configure-linked-sign-on)

■最適なSSO方法の選択

https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/plan-sso-deployment#single-sign-on-options

最適なSSO方法を選択するためのフローチャートが提供されている。

■参考: パスワードベースとは？

https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/configure-password-single-sign-on-non-gallery-applications

- 初回アクセス時にユーザー名とパスワードを入力してアプリにサインイン
- ユーザー名とパスワードがAzure ADに記録される
- 以降のサインインでは、ユーザーに代わって、Azure ADが、ユーザー名とパスワードをアプリに提供

■チュートリアル

https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/tutorial-list

さまざまなクラウドアプリケーションと と Azure AD を統合する場合に使用することができるチュートリアルが用意されている。

例: Adobe Creative Cloud - SAML

https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/adobe-creative-cloud-tutorial

例: Slack - SAML
https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/slack-tutorial

例: Qiita - SAML
https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/qiita-team-tutorial

例: Facebook - SAML
https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/facebook-work-accounts-tutorial

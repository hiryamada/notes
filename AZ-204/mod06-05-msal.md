# MSAL (Microsoft Authentication Libraries)

■MSALとは？

Microsoft Authentication Libraries

- Microsoft ID プラットフォームにアクセスするためのライブラリ
  - 開発者はOAuth/OpenID Connectのコードを直接書く必要がない
- 多数の言語、プラットフォームに対応
  - .NET/Java/JavaScript/Node.js/Python/Go
  - Android/iOS
  - Angular/React/React Native
  - Microsoft Identity Web (ASP.NET Core用のライブラリ）
- さまざまなアーキテクチャ、シナリオに対応
  - シングルページアプリ (SPA)、Webアプリ、モバイルアプリ、デスクトップアプリ、デーモン(バックエンドサービス)など

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/msal-overview

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/microsoft-identity-web

■参考：MSALにおけるアプリケーションの種類

MSALでは、アプリケーションを以下の2つに分類している。

- パブリック クライアント アプリケーション: 「シークレット」を安全に格納「できない」とみなされるアプリケーション。クライアントサイドのアプリ。
  - シングルページアプリケーション(SPA)
  - デスクトップアプリケーション
  - モバイルアプリケーション
- 機密クライアント アプリケーション: 「シークレット」を安全に格納「できる」とみなされるアプリケーション。サーバーサイドのアプリ。
  - Webアプリケーション
  - Web API
  - サービス/デーモン

「機密クライアント アプリケーション」には、「シークレット」を持たせる事ができる。

シークレット:
- クライアントID
- クライアント シークレット


https://docs.microsoft.com/ja-jp/azure/active-directory/develop/msal-client-applications

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/reference-v2-libraries


■参考: 「開発者向け Azure Active Directory (v1.0)」とは？

「Azure AD v1.0 エンドポイント」とも。

「Microsoft IDプラットフォーム」以前に使われていたプラットフォーム（のエンドポイント）。

学校及び職場（Azure AD）アカウントがサポートされるが、その他（個人アカウント）はサポートされない。

新しいプロジェクトには使用しないでください。「Microsoft IDプラットフォーム」を使用する。

https://docs.microsoft.com/ja-jp/azure/active-directory/azuread-dev/v1-overview

https://docs.microsoft.com/ja-jp/azure/active-directory/azuread-dev/azure-ad-endpoint-comparison

■参考: 「ADAL」とは？

Azure Active Directory Authentication Library

今後の開発では「MSAL」を利用することが推奨されている。
https://docs.microsoft.com/ja-jp/azure/active-directory/develop/msal-migration

2022 年 6 月 30 日以降、ADAL の重要なセキュリティ修正プログラムは提供されない。

```
「開発者向け Azure Active Directory (v1.0)」 + ADAL
 ↓
「Microsoft IDプラットフォーム v2.0」 + MSAL
```

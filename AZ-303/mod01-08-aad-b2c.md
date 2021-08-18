# Azure Active Directory B2C (Azure AD B2C)

※B2C = business-to-customer

Youtubeビデオ（英語）
https://www.youtube.com/watch?v=GmBKlXED9Ug

わかりやすい解説
https://www.sigmact.com/updated/azure/azureadb2c/azureadb2c/

■Azure AD B2Cとは？

Azure AD B2C は、認証ソリューション。

Azure AD B2Cを使用すると、顧客は、好みのソーシャル アカウント(Google, Twitter, Facebook等)、エンタープライズ(Azure AD等)、またはローカル アカウント ID(メールアドレス/電話番号/任意のID ＋ パスワード) を使用して、アプリケーションにサインインすることができる。

■シングルサインオンに対応

Azure AD B2Cでサインインしたユーザーは、Azure AD B2Cを使用する複数のアプリケーションでシングルサインオンを利用することができる。

■「ホワイトラベルの認証ソリューション」

Azure AD B2C は、「ホワイトラベル」の（つまり、デザイン可能な）認証ソリューション。

サインイン画面など、Azure AD B2C によって表示されるすべてのページをカスタマイズできる。

■参考: 「ホワイトラベル」とは？

ラベル部分に何も書いていない宣伝・サンプル用のレコード。

また、ラベル部分が白色で、盤面をユーザーがデザインできるCD-Rなど。

ホワイトラベル製品 https://en.wikipedia.org/wiki/White-label_product

ホワイトラベル https://en.wikipedia.org/wiki/White_label

■参考: Azure ADのサインインページのカスタマイズ

Azure ADでも、サインインページに企業のロゴなどを適用してカスタマイズすることができる（が、B2Cのように完全にカスタマイズすることはできない）。

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/customize-branding

■普通のAzure ADとの違い（使い分け）

https://docs.microsoft.com/ja-jp/azure/active-directory-b2c/technical-overview

自社の社員に、自社テナント（のアプリ等）へのアクセスを許可する場合は、（普通の）「Azure AD」を使う。

組織外のユーザー(外部ユーザー)に、自社テナント（のアプリ等）へのアクセスを許可する場合は、「Azure AD External Identities」の「Azure AD B2Bコラボレーション」（ゲストユーザー）を使う。外部ユーザーのIDは、Azure ADテナントで管理されていなくてもよい。

Google、Facebook、Twitter等のアカウントを持つ一般の顧客に、アプリへのアクセスを許可する場合は、「Azure AD External Identities」の「Azure AD B2C」を使う。

■参考: B2BとB2C

- Business-to-Business(B2B): 企業間
- Business-to-Customer(B2C) 企業-消費者間

■参考: Azure AD の「外部ID（External Identities）」

https://docs.microsoft.com/ja-jp/azure/active-directory/external-identities/

External Identities は、組織が、顧客やパートナーなどの外部ユーザーをセキュリティで保護して管理できるようにする一連の機能。

```
外部ID
├Azure AD B2Bコラボレーション（ゲストユーザー）
└Azure AD B2C
```

■プロトコル

Azure AD B2Cでは、OpenID Connect、OAuth 2.0、SAML などのプロトコルが使用される。

Azure AD B2Cは、任意のSAMLプロバイダー、OIDCプロバイダーと連携することができる。

※OpenID Connect (OIDC) = 認証プロトコル。https://ja.wikipedia.org/wiki/OpenID#OpenID_Connect

※OAuth 2.0 = 認可プロトコル。https://ja.wikipedia.org/wiki/OAuth

※SAML = シングルサインオンやID連携で仕様されるマークアップ言語。 https://ja.wikipedia.org/wiki/Security_Assertion_Markup_Language

■カスタム属性

Azure AD B2C で提供されているテナント（ディレクトリ）には、ユーザーごとに 100 個のカスタム属性を保持できる。

※ユーザーの属性は、必ずしもAzure AD B2Cテナント（ディレクトリ）に保存する必要はない。Azure AD B2Cの外部に保存する場合もある。

■デモアプリ

https://woodgrovedemo.com/

Microsoftによって開発された、Azure AD B2Cのデモンストレーション用アプリケーション。



■Azure AD B2Cテナントの作成

※事前にサブスクリプションでリソースプロバイダー「Microsoft.AzureActiveDirectory」を登録しておく。

Azure AD＞テナントの管理＞＋作成

テナントの種類: Azure Active Directory B2C

- 組織名
- 初期ドメイン名 ～.onmicrosoft.com
- 国
- サブスクリプション
- リソースグループ


1つのサブスクリプションの下に複数のAzure AD B2Cテナントにリンクすることができる。



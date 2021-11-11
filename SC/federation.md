# フェデレーション

https://docs.microsoft.com/ja-jp/learn/modules/describe-identity-principles-concepts/5-describe-concept-federated-services

各ドメインの ID プロバイダー(IdP)間で信頼関係を確立する

■フェデレーションの例

```
ドメインA
├IDプロバイダーA
└アプリ    ↓
            ↓
            ↓ 信頼
            ↓ （IDプロバイダーAは
            ↓   IDプロバイダーBを信頼する）
            ↓
ドメインB   ↓
└IDプロバイダーB
  └ユーザー

    ユーザーがIDプロバイダーBで認証されると、
    ドメインAのアプリケーションにアクセスできる

    ユーザーはIDプロバイダーAにアカウントを作成する必要がない
```


```
サードパーティのサイト
└Azure AD（IDプロバイダー）
        ↓
        ↓ 信頼
        ↓
Twitter（IDプロバイダー）
└ユーザー（Twitterアカウント）


サードパーティのサイトではAzure ADをIDプロバイダーとして使用している。

Azure ADとTwitterの間には信頼関係がある
（Azure ADはTwitterを信頼している）。

よって、ユーザーはTwitterでサインインし、その認証情報で、サードパーティのサイトにアクセスできる。
```

```
Azure AD
↓  └アプリ
↓
↓ 信頼
↓
オンプレミスAD FS ＋ オンプレミスAD DS
                       └ユーザー

ユーザーはオンプレミスAD DSで認証される。
ユーザーはその認証情報を使用して、Azure ADのアプリにアクセスできる。
```

■フェデレーションではない例


```
Azure ADテナント（IDプロバイダー）
├アプリ1
├アプリ2
│
└ユーザー

ユーザーはAzure ADテナントで認証されると、その認証情報で、
テナントに登録されているアプリケーションを利用できる。

これはフェデレーションではなく、シングルサインオン。
```



■わかりやすい解説

https://azuread.net/archives/2875

- AD DSで認証が完了すると、Kerberosチケットが発行される。
- Kerberosチケットには、クラウドアプリケーション（Office 365等）にアクセスするためのトークンが含まれて**いない**
- AD FSは、Kerberosチケットと引き換えて、トークンを発行する
- ユーザーは、トークンを使用して、クラウドアプリケーションにアクセスすることができる。

https://azuread.net/archives/1674

- オンプレミスのAD DS（ドメインコントローラー）で認証すると、社内のサーバーを利用する際に、それぞれのサーバーで認証を行う必要がなくなる。
- ただし、**AD DSだけでは、クラウドのアプリの認証を行うことはできない。**
- あらかじめクラウドのアプリと、オンプレミスのAD FSサーバーで信頼関係を設定しておく
- ユーザーは、AD FSのフェデレーションを使用して、社内のサーバーだけではなく、クラウドのアプリにアクセスする際、認証を行う必要がなくなる

https://docs.microsoft.com/ja-jp/windows-server/identity/ad-fs/deployment/how-to-connect-fed-azure-adfs

- AD FSは、単純かつ安全な **ID フェデレーション**と **Web シングル サインオン (SSO)** 機能を実現します
- 
# Azure AD Connectのフェデレーション


Azure AD Connectを使用した認証

- PHS（パスワードハッシュ同期）
- PTA（パススルー認証）
- [フェデレーション](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-fed-whatis)
  - [Azure AD が、別の信頼された認証システム (オンプレミスの ADFS/PingFederate) に、ユーザーのパスワードを検証する認証プロセスを引き継ぐ認証方式。](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/choose-ad-authn#federated-authentication)
  - AD DSで認証され、AD FSがトークンを発行する。


# External Identitiesのフェデレーション

外部ユーザー（ゲストユーザー）が、**自分が普段使っているIDプロバイダー**を使用して認証するしくみ。

- [Google フェデレーション](https://docs.microsoft.com/ja-jp/azure/active-directory/external-identities/google-federation)
- [Facebook フェデレーション](https://docs.microsoft.com/ja-jp/azure/active-directory/external-identities/facebook-federation)
- [SAML/WS-Fed IdPフェデレーション](https://docs.microsoft.com/ja-jp/azure/active-directory/external-identities/direct-federation)
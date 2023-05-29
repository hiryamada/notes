https://learn.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-whatis#terminology

# まとめ

- 認証
  - IDプロバイダー側の「動作」
    - または本人確認の「方式」（パスワードレス認証、多要素認証、レガシ認証など）
  - IDプロバイダーは、（サインインしてくる）ユーザーやアプリを認証する
  - ユーザーやアプリはIDプロバイダーによって認証される。
  - IDプロバイダーはトークンを発行する
- サインイン
  - ユーザー側やアプリ側の動作
  - ユーザーやアプリは、自分の資格情報を使用して、IDプロバイダーにサインインする
  - Webブラウザーやアプリは、IDプロバイダーから発行されたトークンをキャッシュする
- ID
  - 認証を受けることができるもの
  - ユーザー、アプリ
- 資格情報
  - credential
  - ユーザー: ユーザー名とパスワード
  - アプリ: アプリIDとパスワード / アプリIDと証明書

※[ワークロードID](https://learn.microsoft.com/ja-jp/azure/active-directory/identity-protection/concept-workload-identity-risk?toc=%2Fazure%2Factive-directory%2Fworkload-identities%2Ftoc.json&bc=%2Fazure%2Factive-directory%2Fworkload-identities%2Fbreadcrumb%2Ftoc.json): アプリケーションまたはサービス プリンシパルが (場合によってはユーザーのコンテキストで) リソースにアクセスすることを可能にする ID。多要素認証を実行できない。資格情報またはシークレットをどこかに保存する必要がある。

# 利用例

- Microsoft Authenticator
- Azure ADサインインログ
- サインインページ
- サインインの状態を維持する
- Azure AD認証
- レガシ認証
- パスワードレス認証（オプション）
- az loginコマンドでサインインする
- 多要素認証 / 2要素認証
- コマンド ラインで、Azure ユーザー資格情報(=ユーザーID,パスワード)を指定
- マネージドIDでは、資格情報(=アプリID、パスワード、テナントID)を自ら管理する必要がない
- マネージド ID を使用すると、独自のアプリケーションを含む、Azure AD 認証をサポートするあらゆるリソースに対して認証を行うことができる。

# 誤用

- アクセス先のサービスに（サインイン / 認証) する→アプリはIDプロバイダー(Azure AD)にサインインすることで認証される。

# 認証

- 認証する authenticate
  - authenticate an app to Azure
- 認証される authenticated
  - application must be authenticated to Azure.
- 認証 authentication
- 本人性の確認
- IDプロバイダーの動作

# 資格情報

- credential(s)
- ユーザーIDとパスワード
- ユーザーだけが持つ情報

# サインイン

- sign in
- ユーザーの動作を表す
- ユーザーや顧客は、各自の Microsoft ID やソーシャル アカウントを使用してサインインする

# サインアップ

- sign up

# IDプロバイダー

- Azure AD
- 認証を行う
- IdP
- IDを管理および検証するサービス。

# OAuth 2.0

- OAuth 2.0 authorization code flow
  - 認可コードフロー
- OAuth 2.0 device authorization grant flow
  - デバイスコードフロー
  - デバイス許可付与
  - デバイス認可付与
  - デバイスフロー

# App Service 簡易認証

https://learn.microsoft.com/ja-jp/azure/app-service/overview-authentication-authorization

アプリで Microsoft ID プラットフォーム (Azure AD) を認証プロバイダーとして使ってユーザーがサインインするように、Azure App Service または Azure Functions の認証を構成する

```
Microsoft ID プラットフォーム (Azure AD)
↑登録      ↑認証
アプリ ← ユーザー
```

- 開発者はAzure ADにアプリを登録する
- ユーザーはアプリを使用する際にAzure ADでサインインする

<!--


■Azure Identity client library for .NET

パッケージ: Azure.Identity
https://www.nuget.org/packages/Azure.Identity

Azure ADトークン authentication をサポートするAzure SDKクライアント向けに
Azure ADトークン認証サポートを提供
TokenCredential の実装を提供


■MSAL

パッケージ MSAL.NET
Microsoft Authentication Library for .NET
https://www.nuget.org/packages/Microsoft.Identity.Client

■Azure Identity client library for .NET と MSAL の関係


https://github.com/Azure/azure-sdk-for-net/blob/Azure.Identity_1.9.0/sdk/identity/Azure.Identity/src/Azure.Identity.csproj

■Credentials（認証情報 / 資格）

A credential is a class which contains or can obtain the data needed for a service client to authenticate requests. 

クレデンシャルとは、関連するまたは事実上の権限を持つ第三者によって個人に発行された資格、能力、または権限、またはそうするための想定される権限を詳述する文書の一部

〔仕事・任務などの遂行に必要な〕資格、資質、経歴

クレデンシャルとは、資格、経歴、認定証、信任状などの意味を持つ英単語。情報セキュリティの分野では、認証などに用いられるID、ユーザー名、暗証番号、パスワード、生体パターンなどの識別情報の総称を指す。

■SSO

Single sign-on is an authentication method that allows users to sign in using one set of credentials to multiple independent software systems. 

Using SSO means a user doesn't have to sign in to every application they use. 

With SSO, users can access all needed applications without being required to authenticate using different credentials. 

For a brief introduction, see Azure Active Directory single sign-on.

■接続文字列を使った認証 / トークンベース認証

https://learn.microsoft.com/en-us/dotnet/azure/sdk/authentication?tabs=command-line

トークンベース認証が推奨されている。


■トークンベース認証

token-based authentication

token-based sign-in とは言わない

-->

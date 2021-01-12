# 認証

# 認可


# OAuth(オーオース): 認可

参考

https://www.buildinsider.net/enterprise/openid/oauth20

https://www.buildinsider.net/enterprise/openid/connect

https://www.slideshare.net/ngzm/oauth-10-oauth-20-openid-connect

## OAuth 1.0

- 2010/4 RFC5849制定
- サーバーサイドWebアプリに対応
- アプリに認証情報を与えず、アクセストークンでリソースへアクセスさせることができる仕組み
- 「OAuth Server」は「リソースオーナー」(ユーザー)の認証後、「OAuth Client」(アプリ)に「アクセストークン」を発行する
- 「OAuth Client」(アプリ)は「アクセストークン」を使って「リソースエンドポイント」にアクセスできる

## OAuth 2.0

- 2012/10 RFC6749制定
- OAuth 1.0とは後方互換性を持たない（共存は可能）
- サーバーサイドWebアプリに対応（Client Type: Confidential)
- デスクトップアプリ、スマホアプリ、SPAに対応(Client Type: Public)
- TSLによる暗号化が前提、署名不要
- リソースアクセス時のTokenをAuthorization HeaderのBearer スキームに付与 (RFC6750)

# OpenID Connect: 認証

- 2014年2月に発行, 同年11月にアップデート
- OAuth 2.0を拡張しており、おおよその特徴を継承(TLS必須、Bearerスキーム）
- フロントエンド＋バックエンド構成のアプリに対応(Hybrid Flow)
- ID tokenによるID連携(ソーシャルログイン、シングル サインオン)が可能(JWT: RFC7519)

# OAuth 2.0/OIDC で使用される「トークン」

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/active-directory-v2-protocols#tokens

主に 3 種類あります。

- アクセストークン
  - リソース サーバーがクライアントから受け取るトークンで、クライアントに付与されているアクセス許可が含まれます。
- IDトークン
  - クライアントが承認サーバーから受け取るトークンで、ユーザーをサインインさせ、ユーザーに関する基本情報を取得するために使用されます。
- 更新トークン
  - 時間の経過と共にクライアントが新しいアクセス トークンと ID トークンを取得するために使用されます。
  - 不透明な文字列であり、承認サーバーによってのみ理解可能です。

# Authorization Header

- RFC7235内で定義されている
- Authorization: `<type> <credentials>`
- `<type>`にはBasic, Digest, Bearer, OAuthなどが指定される

# Basic認証

- `<credentials>`部分に、「ユーザー名:パスワード」をBase64で変換したものを指定する。

# Digest認証

- ユーザー名とパスワードから計算したハッシュ文字列を送信する。

# Bearer（ベアラー）認証

- RFC6750内で定義されている
- Bearer（ベアラー）は、「持参人」トークンを持ってきた人、という意味。

# JWT (JSON Web Token, ジョット)

- RFC7519で定義されている
- {base64エンコードしたheader}.{base64エンコードしたclaims}.{署名}
- これは「eyJ...」という文字列になる。
- ヘッダーには署名アルゴリズムやトークンタイプが指定される
- クレームには、ユーザーの情報が含まれる
- Authorization: Bearer eyJ... といった形式でリクエストヘッダに付与される

# ベアラートークン

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/active-directory-v2-protocols#tokens

> OAuth 2.0 と OpenID Connect では、ベアラー トークンが頻繁に使用され、一般に JWT (JSON Web トークン) で表されます。
> ベアラー トークンは、TLSなどのセキュリティで保護されたチャネルで転送する必要があります。

# デバイスコード認証

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/v2-oauth2-device-code

https://auth0.com/blog/jp-oauth-device-flow-no-hassle-authentication-as-seen-on-tv/
↑わかりやすい！！！

- 基本的にAzure AD認証はWebブラウザ上で対話的に実行される。
- しかし、デバイスがWebブラウザを提供できない場合は、デバイスコードフロー認証を利用する。
- ユーザーは自分の携帯電話などのWebブラウザを用いて、デフォルトでは15分以内に、認証を行う。
- デバイスは「デバイスコード」と呼ばれる短い文字列を表示する。
- ユーザーは、認証の際にデバイスコードを入力する（続いて、ユーザーの認証を行う）。
- 認証が完了すると、デバイスにトークン（アクセストークン、リフレッシュトークン、IDトークン）が返される。

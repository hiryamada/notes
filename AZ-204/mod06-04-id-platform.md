# Microsoft ID プラットフォーム

アプリケーションにサインイン機能を持たせるには「Microsoft IDプラットフォーム」を使用する。
- アプリケーションをAzure ADに登録する
- アプリケーションにMSALを組み込む

ドキュメント
https://docs.microsoft.com/ja-jp/azure/active-directory/develop/

用語集
https://docs.microsoft.com/ja-jp/azure/active-directory/develop/developer-glossary

ビデオ（英語）
https://docs.microsoft.com/ja-jp/Azure/active-directory/develop/identity-videos

■「Microsoft IDプラットフォーム」とは？

アプリケーション開発者向けのIDプラットフォーム。

以下のものが提供される。

- 認証サービス
  - OAuth 2.0 / OpenID Connectに準拠
- ライブラリ
  - MSAL (Microsoft Authentication Libraries)
- アプリケーション管理ポータル(Azure portal)
  - Azure ADにアプリを登録（手動）
- アプリケーション構成API / PowerShell
  - Azure ADにアプリを登録（自動）
- 開発者向けコンテンツ
  - ドキュメント
  - クイックスタート
  - チュートリアル など

Microsoft ID プラットフォームは、The OpenID Foundationの認定 OpenID プロバイダー(Certified OpenID Providers)の一つである。
https://docs.microsoft.com/ja-jp/azure/active-directory/develop/reference-v2-libraries

■参考: IDプロバイダーとは？

ID プロバイダー:

- ユーザー ID またはクライアント ID を認証し、使用可能な「セキュリティ トークン」を発行する。
- ユーザー認証をサービスとして提供する。(IDaaS)
- シングルサインオンの機能を提供する。ユーザーは一度、IDプロバイダーでサインインすると、対応する複数のアプリケーションにアクセスすることができる。

Azure ADは、IDプロバイダーとしての機能を提供する。

https://docs.microsoft.com/ja-jp/azure/bot-service/bot-builder-concept-identity-providers

■「Microsoft IDプラットフォーム」で実現できること

- アプリケーションに、Microsoft ID やソーシャル アカウントを使用したサインイン機能を追加できる
  - ユーザーは、そのアプリケーションに、ユーザー登録を行う必要がなくなる
- 「Microsoft Graph」 などの API へのアクセスを提供できる
  - 「Microsoft IDプラットフォーム」で認証が完了すると、アプリケーションに「セキュリティ トークン」が発行される
  - アプリケーションは「セキュリティ トークン」（内のアクセストークン）を利用して、「Microsoft Graph」APIなどのAPIを利用することができる

■「Microsoft IDプラットフォーム」では、どのような種類のIDをサインインに利用できるのか？

- 学校および職場のアカウント (Azure AD): 自分のテナントのみ（シングルテナント） / 他のテナントも含む（マルチテナント）
- Microsoft アカウント (outlook.com, live.com, skype, xbox, hotmail など)
- ソーシャル アカウント (Azuer AD B2C)
  - Google
  - Facebook
  - Twitter など
- ローカルアカウント (Azuer AD B2C)
  - メールアドレス、ユーザー名、電話番号など

※ローカルアカウント
https://docs.microsoft.com/ja-jp/azure/active-directory-b2c/identity-provider-local

※ローカルアカウントの電話番号でのサインアップ
https://docs.microsoft.com/ja-jp/azure/active-directory-b2c/phone-authentication-user-flows

■「Microsoft IDプラットフォーム」は、どんなアプリケーションで利用できるのか？

- Webアプリケーション
- シングルページアプリ (SPA) - Azure portal、Skillpipeなど。
- Web API
- モバイルアプリ
- デスクトップアプリ
- デーモン(バックエンドサービス)
- コンソールアプリ

※デーモン: daemon（守護神） バックグランドで稼働するプロセス。httpdやsyslogdなど。demon（悪魔）ではない。

https://ja.wikipedia.org/wiki/%E3%83%87%E3%83%BC%E3%83%A2%E3%83%B3_(%E3%82%BD%E3%83%95%E3%83%88%E3%82%A6%E3%82%A7%E3%82%A2)

※シングルページアプリケーション: ブラウザー上で完全に実行され、ページ データ (HTML、CSS、JavaScript) を動的に、またはアプリケーションの読み込み時にフェッチする。 Web API を呼び出して、バックエンド データ ソースとやり取りする。Angular(Google)、React(Facebook)などのフレームワークを使用して開発される。

https://docs.microsoft.com/ja-jp/dotnet/architecture/modern-web-apps-azure/choose-between-traditional-web-and-single-page-apps

Azure Portal - The Largest SPA in the World
https://channel9.msdn.com/Events/Visual-Studio/Visual-Studio-Live-Redmond-2016/T15

Azure Portal – Building Large Scale Single Page Applications
https://channel9.msdn.com/Events/Ignite/Australia-2017/ARC122

■認証（authentication, AuthN）と承認（authorization, AuthZ）

- 認証: ユーザーが身元を証明するプロセス
- 承認: 認証された利用者に対し、何かを実行する権限を付与する行為

「Microsoft ID プラットフォーム」では、認証の処理に OpenID Connect プロトコル、承認の処理に OAuth 2.0 プロトコルを使用する。

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/authentication-vs-authorization

■セキュリティ トークン

「Microsoft ID プラットフォーム」は、ユーザーを認証し、「セキュリティ トークン」を発行する。

セキュリティトークンには以下が含まれる。

- ID トークン: 認証されたユーザーの情報などを含むトークン。
- アクセス トークン: Web API やその他の保護されたリソースにアクセスするためのトークン。
- リフレッシュ（更新）トークン: 新しいセキュリティ トークンを取得するためのトークン。

これらは、通常、JWT形式となる。

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/id-tokens

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/access-tokens

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/refresh-tokens

https://qiita.com/TakahikoKawasaki/items/8f0e422c7edd2d220e06

■参考: JWT

JSON Web Token（ジェイソン・ウェブ・トークン）は、JSONデータに署名や暗号化を施す方法を定めたオープン標準 (RFC 7519) である。

https://ja.wikipedia.org/wiki/JSON_Web_Token

https://jwt.ms/ を使用して、デコードすることができる。

[サンプル](https://jwt.ms/#id_token=eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjFMVE16YWtpaGlSbGFfOHoyQkVKVlhlV01xbyJ9.eyJ2ZXIiOiIyLjAiLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vOTEyMjA0MGQtNmM2Ny00YzViLWIxMTItMzZhMzA0YjY2ZGFkL3YyLjAiLCJzdWIiOiJBQUFBQUFBQUFBQUFBQUFBQUFBQUFJa3pxRlZyU2FTYUZIeTc4MmJidGFRIiwiYXVkIjoiNmNiMDQwMTgtYTNmNS00NmE3LWI5OTUtOTQwYzc4ZjVhZWYzIiwiZXhwIjoxNTM2MzYxNDExLCJpYXQiOjE1MzYyNzQ3MTEsIm5iZiI6MTUzNjI3NDcxMSwibmFtZSI6IkFiZSBMaW5jb2xuIiwicHJlZmVycmVkX3VzZXJuYW1lIjoiQWJlTGlAbWljcm9zb2Z0LmNvbSIsIm9pZCI6IjAwMDAwMDAwLTAwMDAtMDAwMC02NmYzLTMzMzJlY2E3ZWE4MSIsInRpZCI6IjkxMjIwNDBkLTZjNjctNGM1Yi1iMTEyLTM2YTMwNGI2NmRhZCIsIm5vbmNlIjoiMTIzNTIzIiwiYWlvIjoiRGYyVVZYTDFpeCFsTUNXTVNPSkJjRmF0emNHZnZGR2hqS3Y4cTVnMHg3MzJkUjVNQjVCaXN2R1FPN1lXQnlqZDhpUURMcSFlR2JJRGFreXA1bW5PcmNkcUhlWVNubHRlcFFtUnA2QUlaOGpZIn0.1AFWW-Ck5nROwSlltm7GzZvDwUkqvhSQpm55TQsmVo9Y59cLhRXpvB8n-55HCr9Z6G_31_UbeUkoz612I2j_Sm9FFShSDDjoaLQr54CreGIJvjtmS3EkK9a7SJBbcpL1MpUtlfygow39tFjY7EVNW9plWUvRrTgVk7lYLprvfzw-CIqw3gHC-T7IK_m_xkr08INERBtaecwhTeN4chPC4W3jdmw_lIxzC48YoQ0dB1L9-ImX98Egypfrlbm0IBL5spFzL6JDZIRRJOu8vecJvj1mq-IUhGt0MacxX8jdxYLP-KUu2d9MbNKpCKJuZ7p8gwTL5B7NlUdh_dmSviPWrw)

トークンには「クレーム」が含まれる。

■参考: クレーム

トークンに含まれているエンティティーについて記述した情報。

https://www.ibm.com/docs/ja/sva/10.0.0?topic=concepts-openid-connect

たとえば「name」には、人間が読むことができる、ユーザーの名前の情報が含まれる。

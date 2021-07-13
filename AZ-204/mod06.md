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


■参考: 「開発者向け Azure Active Directory (v1.0)」とは？

「Azure AD v1.0 エンドポイント」とも。

「Microsoft IDプラットフォーム」以前に使われていたプラットフォーム（のエンドポイント）。

学校及び職場（Azure AD）アカウントがサポートされるが、その他（個人アカウント）はサポートされない。

新しいプロジェクトには使用しないでください。「Microsoft IDプラットフォーム」を使用してください。

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

■MSALとは？

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

- パブリック クライアント アプリケーション: シークレットを安全に格納「できない」とみなされるアプリケーション。クライアントサイドのアプリ。
  - シングルページアプリケーション(SPA)
  - デスクトップアプリケーション
  - モバイルアプリケーション
- 機密クライアント アプリケーション: シークレットを安全に格納「できる」とみなされるアプリケーション。サーバーサイドのアプリ。
  - Webアプリケーション
  - Web API
  - サービス/デーモン

「機密クライアント アプリケーション」には、「シークレット」を持たせる事ができる。

シークレット:
- クライアントID
- クライアント シークレット


https://docs.microsoft.com/ja-jp/azure/active-directory/develop/msal-client-applications

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/reference-v2-libraries

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

■アプリケーションの登録

アプリケーションが「Microsoft ID プラットフォーム」を利用するには、アプリケーションを Azure AD のテナントに登録する必要がある。

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/quickstart-register-app

アプリケーションをテナントに登録すると、アプリケーションと 「Microsoft ID プラットフォーム」との間の信頼関係が確立される。（つまり、アプリケーションは「Microsoft IDプラットフォーム」を信頼し、そこで行われた認証の結果を受け入れるということになる）

■参考: Azure ADの「テナント」

テナントは、Azure ADのインスタンス。つまり、Azure ADの機能は、テナントにより提供される。

テナントは組織（会社や学校）を表す。組織ごとにテナントが作られる。

基本的には1組織1テナントを使う。ただし、開発用の新しいテナントを作成することもできる。

テナントには、Azure ADのユーザー、グループ、アプリが登録される。

テナントは、初期ドメイン domainname.onmicrosoft.com を持つ。※ domainname の部分はテナントごとに異なる

新しくAzureサブスクリプションにサインアップすると、Azure ADテナントが作成される。

アプリの登録は、Azure ADのテナント内で行う。

テナントには、専用の「ディレクトリ」が作られる。テナントとディレクトリは1対1の関係。テナント≒ディレクトリとみなしてよい。（「ディレクトリ」という言葉が出てきた場合は、「テナント」と読み替えてよい）

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/quickstart-create-new-tenant

■アプリケーションの登録方法

Azure AD＞アプリの登録＞新規登録

ここで、登録に必要な情報を入力する。

- アプリケーションの表示名
- サポートされるアカウントの種類（どのアカウントがこのアプリにアクセスできるか）
  - この組織のディレクトリ内のアカウントのみ: シングル テナント (自分のテナント内のアカウントからのみアクセス可能) 
  - 任意の組織のディレクトリ内のアカウント: マルチテナント (任意のテナントのアカウントからアクセス可能) 
  - 任意の組織のディレクトリ内のアカウントと、個人用の Microsoft アカウント:
  - 個人用 Microsoft アカウント
- リダイレクト URI (セキュリティ トークンの送信先) 

※「Azure AD B2Cテナント」を使用すると、ソーシャル アカウントやローカル アカウントも使用できる。

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/quickstart-register-app#register-an-application

登録が完了すると「アプリケーション（クライアント）ID」が割り当てられる。各アプリケーションはこのIDにより、グローバル（世界中）で、一意に識別される。たとえば「990bcc60-6de0-4456-bdfc-b241260a4886」のような文字列。この文字列は、アプリケーションのコード内に転記する必要がある。

また、「ディレクトリ（テナント）ID」も表示される。これは、Azure ADテナントを区別するためのID。この文字列も、アプリケーションのコード内に転記する必要がある。

※「オブジェクトID」というものも割り当てられる。オブジェクトIDは、アプリケーションだけではなく、Azure ADのユーザーやグループにも割り当てられる、グローバルに一意なIDである。テナント内のさまざまな「オブジェクト」を識別するためのIDである。

■ハンズオン: 「アプリの登録」をやってみよう

これから新しいアプリを開発し、それをAzure ADに登録する、というつもりで実施してみてください。

Azure AD＞アプリの登録＞新規登録
- 名前: test1
- サポートされているアカウントの種類: デフォルト（この組織ディレクトリのみに含まれるアカウント）
- リダイレクトURI: 省略
- 「登録」をクリック
- 「アプリケーション（クライアント）ID」と、「ディレクトリ（テナント）ID」の表示を確認してください。
- 画面上部「エンドポイント」をクリックして、OAuth 2.0などのエンドポイントが作成されていることを確認してください。
  - エンドポイントのURLには、「ディレクトリ（テナント）ID」が含まれていることが確認できます
  - つまりエンドポイントは、登録した各アプリではなく、テナントに対して作られています
- 画面左「クイックスタート」をクリックして、「Webアプリ＞ASP.NET」などのように選択し、画面に表示される内容を確認してください
  - 「この変更を行う」で、各アプリを動作させるために必要な設定変更が行えることを確認します
  - 「コードサンプルをダウンロードする」から、コードサンプルを入手できることを確認します
- 画面左「統合アシスタント」をクリックして、適当なアプリの種類を選び、「アプリの登録を評価する」をクリックします
  - 選択したアプリを登録する際に必要な設定がされているかどうかがチェックされます
- 画面左「ブランド」で、登録時に指定した名前が変更できることを確認します
- 画面左「認証」で、登録時に指定した「サポートされているアカウントの種類」を変更できることを確認します。
- 画面左「証明書とシークレット」で、「＋新しいクライアントシークレット」をクリックし、適当な説明を入力して「追加」をクリックします
  - アプリの「クライアントシークレット」を追加できます。このシークレットIDと値は、「機密クライアント アプリケーション」で使用できます。
- 画面左「APIのアクセス許可」で、「＋アクセス許可の追加」をクリックし、アプリに割り当てできるAPIを確認します。
  - 「Microsoft Graph」をクリックし、「send」で検索すると、Mail.Sendというアクセス許可（の要求）を追加することができます。
  - また、Azure Cosmos DB、Azure Storage、OneNote、SharePointなど、さまざまなAPIのアクセス許可（の要求）を追加できます。
 
■リダイレクトURIとは

リダイレクト URI は、ID プロバイダーがセキュリティ トークンを送り返す URI です。

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/msal-client-application-configuration#redirect-uri

Webアプリなどの場合は、そのWebアプリのデプロイ先のURLを設定することで、Webアプリがセキュリティトークンを受け取る。

■参考：特別なリダイレクトURI

ネイティブ アプリやモバイル アプリの場合、以下を指定する。

- 埋め込みのブラウザーを使用するアプリ: https://login.microsoftonline.com/common/oauth2/nativeclient
- システム ブラウザーを使用するアプリ: http://localhost

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/v2-oauth2-auth-code-flow

.NET Coreアプリの場合: https://localhost を指定. 今のところ、埋め込み Web ビュー用の UI が .NET Core には存在しないため、これによって、ユーザーはシステム ブラウザーを使用して対話型認証を実行できるようになります。

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/msal-client-application-configuration#redirect-uri-for-public-client-apps

デーモン アプリの場合は、リダイレクト URI を指定する必要はありません。
https://docs.microsoft.com/ja-jp/azure/active-directory/develop/msal-client-application-configuration#redirect-uri-for-confidential-client-apps

■アプリケーションの「ホーム テナント」

アプリケーションの登録先である Azure AD テナントのこと。

■アプリケーションオブジェクト

Azureポータルでアプリケーションを登録すると、そのテナント（ホーム テナント）に「アプリケーション オブジェクト」が作成され、「アプリケーション（クライアント）ID」が割り当てられる。

「Azure ADテナントにアプリを登録する」＝「そのテナントにアプリケーション オブジェクトを作る」といえる。

アプリケーションオブジェクトは、グローバルに一意なインスタンスである。

■サービスプリンシパル

Azureポータルでアプリケーションを登録した場合は、さらに、そのテナントに「サービス プリンシパル」も作成される。

サービス プリンシパルは、テナントによってセキュリティ保護されているリソースにアクセスするための ID。

サービス プリンシパル:
- アプリケーションが使用される各テナントで作成される
- 「アプリケーション オブジェクト」を参照する（つまり、プロパティの一部として「アプリケーション（クライアント）ID」を持つ）
- テナント内でアプリが実際に実行できることを定義する。
- アプリにアクセスできるユーザーを定義する。

サービスプリンシパルは、Azure ADの「エンタープライズアプリケーション」で確認することができる。

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/app-objects-and-service-principals

■ハンズオン: サービスプリンシパルを確認してみよう

Azure AD＞エンタープライズ アプリケーション

前のハンズオンで作成したアプリケーションが一覧に表示されるので、それをクリックする。
- 画面左「アクセス許可」をクリック
- 「規定のディレクトリ に管理者の同意を与えます」をクリック。
  - この操作により、このテナントにおいて、管理者として、アプリケーションが要求するアクセスを許可することになる。
- 30秒ほど待って、画面上「更新」をクリック
- Microsoft.Graph という行が追加される。それをクリック
- 「クレームの値」で「User.Read」などが表示される。

■アプリケーションオブジェクトとサービスプリンシパルの違い

作成の順序が違う
- まず、アプリケーションオブジェクトが、あるテナントに登録される。
- 次に、そのアプリを使用する各テナントで、そのアプリケーションオブジェクトに対応するサービスプリンシパルが作成される。

数が違う
- アプリケーションオブジェクト: グローバルに一意なインスタンス。（世界中に1つだけ）
- サービスプリンシパル: アプリケーションを使用する各テナント内に作成される。（多数のテナント内に存在し得る）
- アプリケーションオブジェクトとサービスプリンシパルは1対多の関係となる。

表すものが違う
- アプリケーションオブジェクト: アプリケーションそのもの。
- サービスプリンシパル: 各テナントにおける、アプリケーションのプリンシパル（ID）。

名前の扱い方が違う
- アプリケーションオブジェクト: 「表示名」を設定できる。（ブランド＞名前 で、変更可能。）
- サービスプリンシパル: アプリケーションオブジェクトに設定された「表示名」を引き継ぐ。（プロパティ＞名前 で、そのテナントでの表示名を変更可能）

Azure portalでのアクセス方法（表示場所）が違う
- アプリケーションオブジェクト: Azure AD＞アプリの登録
- サービスプリンシパル: Azure AD＞エンタープライズ アプリケーション

オブジェクトIDが違う
- アプリケーションオブジェクト: 独自のオブジェクトIDを持つ
- サービスプリンシパル: 独自のオブジェクトIDを持つ
- この2つのオブジェクトIDは別の文字列となる。つまり、Azure AD的に、この2つは異なるオブジェクトである。

アクセス許可の扱い方が違う
- アプリケーションオブジェクトでは、このアプリが動作するために必要なアクセス許可を**宣言**する。（「APIのアクセス許可」画面）
- サービスプリンシパルは、各テナントにて、アプリに対し、アクセス許可を**与える**。（「アクセス許可」画面）
- たとえば、アプリケーションオブジェクト側では、「このアプリがMicrosoft Graphを使ってメールを送信したい」と**宣言**し、各テナントのサービスプリンシパル側では、その宣言に対して実際に許可を**与える**。
- 許可は、管理者が与えることも、アプリを使用するユーザーが与えることもできる。アプリを初めて使用する際にダイアログが出る。
- 許可を与えることを「委任する」とも言う。

リダイレクトURI
- アプリケーションオブジェクト: リダイレクトURIを設定できる。つまり、発行されたセキュリティトークンをアプリに渡す方法を設定できる。
- サービスプリンシパル: リダイレクトURIの設定はない。

ユーザー/グループの割り当て
- アプリケーションオブジェクト: 割り当てはない。
- サービスプリンシパル: 各テナントで、そのアプリを使用できるユーザーやグループを割り当てできる。

■たとえ

オブジェクト指向
- アプリケーションオブジェクトは、「クラス」に相当する。
- サービスプリンシパルは、そのクラスを使って作られる「インスタンス」に相当する。

免許証
- アプリケーションオブジェクトは、「車の免許証」に相当する。
- サービスプリンシパルは、その免許証を使って作った、さまざまな「会員登録」に相当する。

■デバイスコード認証

スマート TV、IoT デバイス、プリンターなど、入力に制限がある（キーボードやマウスなどを持っておらず）デバイスを使用していて、そのデバイス上でユーザーが直接認証を行うことが難しい場合に、別のデバイスを使って認証を行う仕組み。

- デバイス（の中のプログラム）は、「Microsoft IDプラットフォーム」にアクセスして、デバイスコードを受け取る。
- デバイスは、デバイスコードをユーザーに表示する
- ユーザーは、自分のスマホなどを使用して、https://aka.ms/devicelogin にアクセスし、デバイスコードを入力し、サインインを行う
- サインインが完了すると、デバイスに、トークンが渡される。

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/v2-oauth2-device-code

■ハンズオン: Azure CLIで、デバイスコード認証を使用してサインインする

Azure CLIで`az login`を実行すると、通常、Webブラウザーが開いて、ユーザーはそのWebブラウザーを使用してサインインを行う。SSHの使用中など、Webブラウザーを起動できない状況では、Azure CLIはデバイスコード認証を行う。`--use-device-code`オプションを使用すると、強制的にデバイスコード認証を行わせることができる。
```
az login --use-device-code
```

# Microsoft Graph API

公式サイト
https://developer.microsoft.com/ja-jp/graph

Microsoft Learn: Microsoft Graph の基礎
https://docs.microsoft.com/ja-jp/learn/paths/m365-msgraph-fundamentals/

■Microsoft Graphとは？

以下のデータや機能にアクセスするためのAPI。

- Microsoft 365
- Windows 10
- Enterprise Mobility + Security

■Microsoft Graph でできること

たとえば、以下のことができる。

- Azure ADのユーザー情報の参照、作成、削除、写真の取得・更新
- ユーザーの予定表の表示、照会、更新、イベントの作成
- メールの送信、一覧表示
- 連絡先の一覧表示・作成
- ユニバーサル印刷

https://docs.microsoft.com/ja-jp/graph/overview#what-can-you-do-with-microsoft-graph

https://docs.microsoft.com/ja-jp/graph/universal-print-concept-overview

■Graphエクスプローラー

Microsoft Graphの機能をかんたんに試すことができるサイト。

https://developer.microsoft.com/ja-jp/graph/graph-explorer

■Graph SDK

アプリからMicrosoft Graph にアクセスするためのライブラリ。各言語用のSDKが提供されている。

https://docs.microsoft.com/ja-jp/graph/sdks/sdks-overview

■チュートリアル

各言語によるチュートリアルが利用できる。

https://docs.microsoft.com/ja-jp/graph/tutorials

■ハンズオン: Graphエクスプローラーを使用してみよう

- https://developer.microsoft.com/ja-jp/graph/graph-explorer にアクセス
- 画面左に「現在、サンプル アカウントを使用しています...」と表示されていることを確認
- 画面左「はじめに」内の「自分のプロファイル」をクリック。サンプルのユーザー（Megan Bowen ミーガン=ボーエン）の情報が表示される。
  - ほかにもいろいろ見てみましょう
  - はじめに＞自分の上司
  - ユーザー＞自分のスキル
  - Outlookメール＞来週の自分の予定
  - OneDrive＞自分のOneDriveを検索
  - セキュリティ＞アラート
- 画面左「Microsoftの職場または学校のアカウント」をクリック
- トレーニング開始時に作成したMicrosoft アカウントでサインイン
- 「このアプリがあなたの情報にアクセスすることを許可しますか？」画面で「はい」をクリック
- 画面左「はじめに」内の「自分のプロファイル」をクリック。自分の名前などの情報が表示されることを確認。

なお、トレーニング開始時に作成したMicrosoft アカウントでは、Microsoft 365の契約が行われていないため、その他の操作はほぼエラーとなってしまう。

※Megan Bowenの[Twitter](https://twitter.com/meganbowenm365), [LinkedIn](https://www.linkedin.com/in/megan-bowen-b511a7192/)

■ラボ6: アプリの登録、MSALによるトークンの取得、デバイスコードフロー認証の導入、Microsoft Graphの利用

- まず[参考資料](lab/lab06.md)を見て、概要を把握します
- 次に[手順書](https://microsoftlearning.github.io/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_06_lab_ak.html)を見ながら演習を行います。


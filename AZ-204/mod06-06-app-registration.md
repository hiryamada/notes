# アプリケーションの登録

アプリケーションが「Microsoft ID プラットフォーム」を利用するには、アプリケーションを Azure AD のテナントに登録する必要がある。

https://docs.microsoft.com/ja-jp/azure/active-directory/develop/quickstart-register-app

アプリケーションをテナントに登録すると、アプリケーションと 「Microsoft ID プラットフォーム」との間の信頼関係が確立される。（つまり、アプリケーションは「Microsoft IDプラットフォーム」を信頼し、そこで行われた認証の結果を受け入れるということになる）

■参考: Azure ADの「テナント」

[PDF解説: Azure ADのテナント](../AZ-104/pdf/mod01/テナント.pdf)

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



■リダイレクトURIとは

リダイレクト URI は、ID プロバイダーがセキュリティ トークンを送り返す URI 。

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

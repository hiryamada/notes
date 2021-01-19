# [TLS 相互認証(クライアント証明書認証)](https://docs.microsoft.com/ja-jp/azure/app-service/app-service-web-configure-tls-mutual-auth)

さまざまな種類の認証を有効にすることで、Azure App Service アプリへのアクセスを制限できます。

その方法の 1 つとして、クライアント要求が TLS/SSL を経由するときにクライアント証明書を要求し、その証明書を検証することが挙げられます。

このメカニズムは TLS 相互認証(TLS mutual authentication) または クライアント証明書認証(client certificate authentication) と呼ばれます。

HTTPS ではなく HTTP 経由でサイトにアクセスする場合は、クライアント証明書を受信しません。 したがって、アプリケーションにクライアント証明書が必要な場合は、HTTP 経由でのアプリケーションへの要求を許可しないでください。

# 必要なApp Serviceプラン

カスタム TLS/SSL バインディングを作成したり、App Service アプリのクライアント証明書を有効にしたりするには、App Service プランが Basic、Standard、Premium、または Isolated のいずれかのレベルである必要があります。

# 設定方法

構成 ＞ 全般設定を選択します。「Client certificate mode」(クライアント証明書モード) を 「必須」 に設定します。

アプリケーションで相互認証を有効にすると、そのアプリのルート下のすべてのパスで、アクセスにクライアント証明書が必要になります。

# 除外パス

特定のパスでこの要件を削除するには、アプリケーション構成の一部として除外パスを定義します。

# アプリからの証明書へのアクセス

App Service では、要求の TLS 終了がフロントエンドのロード バランサー側で行われます。クライアント証明書を有効にした状態で要求をアプリ コードに転送すると、App Service によって X-ARR-ClientCert 要求ヘッダーにクライアント証明書が挿入されます。 App Service がこのクライアント証明書に対して行うのは、この証明書をアプリに転送する処理だけです。

クライアント証明書の検証はアプリ コードが行います。

ASP.NET の場合は、HttpRequest.ClientCertificate プロパティを通じてクライアント証明書を使用できます。

他のアプリケーション スタック (Node.js や PHP など) の場合は、X-ARR-ClientCert 要求ヘッダー内の base64 エンコード値を通じて、アプリでクライアント証明書を使用できます。

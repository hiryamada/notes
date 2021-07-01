# ラボ6

## 重要ポイント

- 演習1 アプリを登録する [参考](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/scenario-desktop-app-registration)
  - 名前: graphapp
  - リダイレクトURIに http://localhost を指定
    - Webアプリなどの場合は、本番環境のURIを指定。認証完了後、このURIにトークンが送られてくる
    - コンソールアプリ等では http://localhost を指定する
  - パブリック クライアント フローを許可する
    - デバイスコードフロー認証を使うために選択
  - アプリケーション（クライアント）IDをコピー
  - ディレクトリ (テナント) IDをコピー

- 演習2 MSALでトークンを取得する
  - コンソールアプリ GraphClient を作成 
    - dotnet new console
  - MSALパッケージの追加
    - dotnet add package Microsoft.Identity.Client
  - アプリケーション内に、以下を埋め込み
    - アプリケーション（クライアント）ID
    - ディレクトリ (テナント) ID
  - MSALを使用して、トークンをインタラクティブに取得
    - IPublicClientApplication app = PublicClientApplicationBuilder...Build()
    - List<string> scopes
      - "user.read"
    - AuthenticationResult result = app.AcquireTokenInteractive(scopes).ExecuteAsync()

- 演習3 前半 デバイスコードフロー認証の導入
  - dotnet add package Microsoft.Graph
  - DeviceCodeProvider provider = new DeviceCodeProvider(app, scopes)

- 演習3 後半 Microsoft Graph で、自分の名前とIDを取得する
  - GraphServiceClient client = new GraphServiceClient(provider);
  - User myProfile = client.Me.Request()
  - myProfile.DisplayName
  - myProfile.Id


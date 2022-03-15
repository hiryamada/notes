# ハンズオン2: GitHub Action による、GitHub から Azure Static Web Appへのデプロイ

- テンプレートを使用してGitHubリポジトリを作成
  - https://github.com/staticwebdev/blazor-starter に移動
  - Use this template をクリック
  - Repository nameに適当なリポジトリ名を入力
  - Create repository from template
  - (この時点ではGitHub Actionsはセットアップされていない)
- Azure Static Web Appを作成
  - Azure portalに移動 https://portal.azure.com/#home
  - 画面上部の検索で「静的」または「static」で検索し「静的 Web アプリ」をクリック
  - 作成
  - リソースグループを新規作成（名前は適当に）
  - 名前を適当に入力
  - GitHubアカウントでサインイン をクリック
  - Authorize Azure-App-Servicce-Web-Appsをクリック
  - Passwordの入力が出た場合はGitHubのパスワードを入力してConfirm passwordをクリック
  - 組織: GitHubのアカウント名
  - リポジトリ: 上の手順で作ったリポジトリ名
  - 分岐: main
  - ビルドのプリセット: Blazor
  - 確認および作成
  - 作成
- アクションの実行を確認
  - GitHubのリポジトリに戻る
  - 画面上部の Actionsをクリック
  - ci: add Azure Static Web Apps workflow... の実行が終わるまで待つ
- デプロイされたWebアプリを確認
  - Azure portalに移動
  - 画面上部の検索で「静的」または「static」で検索し「静的 Web アプリ」をクリック
  - 作成した静的アプリをクリック
  - 画面上部「参照」
  - Static Web Apps の Hello world! という画面が出ればデプロイ成功。
  - Your Azure Static Web App is live and waiting for your contentと表示される場合は、まだアクションの実行が終わっておらず、デフォルトのStatic Web Appsの画面が出ている状況。しばらく待ってリロードボタンを押す。

※Blazorアプリの解説: https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/try


# ハンズオン1: GitHub Action を利用する

- GitHubアカウントの準備
  - 今回用のMicrosoftアカウントでGitHubアカウントをまだ作っていなければ、作成する。手順
- GitHubリポジトリの準備
  - https://github.com/new へ移動
  - Repository nameに適当なリポジトリ名を入れる
  - Create repository
- GitHub Actionsの構成
  - 画面上の「Actions」をクリック
  - Simple workflow の 「Set up this workflow」をクリック
  - YAMLファイルが作成される。内容をチェックしてください
  - Start commitをクリック
  - Commit new fileをクリック
  - blank.yml というファイルが リポジトリ/.github/workflows/ ディレクトリに作成される
- アクションの実行を確認
  - 画面上部の Actionsをクリック
  - There are no workflow runs yet. と表示された場合は、しらばく待つ。自動的に画面が遷移する
  - Create blank.yml に 緑色の点 または くるくる回転するもの が表示される場合、しばらく待つ。
  - Create blank.yml に 緑色の丸アイコン（中に白いチェックマーク）が付く
  - Create blank.yml をクリック
  - build をクリック
  - いくつかのスクリプトが実行されていることが確認できる。

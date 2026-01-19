# 演習の概要

## 演習1 GitHubの概要

ブランチ、コミット、プルリクエスト、マージなどを練習します
https://github.com/skills/introduction-to-github
- Start Courseをクリック
- （リポジトリ名が重複する場合）リポジトリ名を適当に変更
- Create Repositoryをクリック
- 30秒ほど待って、ページをリロード
- READMEファイルが書き換わって「Step 1: Create a branch」が出ればOK。
- 表示される指示に沿って操作してください
- 必要な場合はWebブラウザーの翻訳機能を使ってください
 
## 演習2 GitHub Codespaces

https://github.com/skills/code-with-codespaces

コードスペースの作成と操作、カスタマイズ

setup.sh 作成後、コードスペースを作成し、最初に表示されるターミナルを閉じ、新しいターミナルを開いて、sl コマンドを実行してください。

参考: [slコマンド(Wikipedia)](https://ja.wikipedia.org/wiki/Sl_(UNIX))

## 演習3 Markdownを使用する

https://github.com/skills/communicate-using-markdown

ヘッダー、画像、コードサンプル、タスクリストの作成を行います

## 演習4 プルリクエストをレビューし、変更を提案・コミットし、マージする

https://github.com/skills/review-pull-requests

- Step 1: （ユーザーBの立場で）プルリクエストを作成する
- Step 2: （以降、ユーザーAの立場で）プルリクエストの担当者に自分自身を割り当てる
- Step 3: プルリクエストにコメントする。例: よい提案ですね、ただし絵文字は不要だと思います。
- Step 4: プルリクエストの変更を提案する（絵文字を削除）
- Step 5: プルリクエストの変更の提案をコミットする
- Step 6: プルリクエストをマージする
 
## 演習5: シークレットスキャン

https://github.com/skills/introduction-to-secret-scanning

- Step 1, Activity 1.1: シークレットスキャンは現在デフォルトで有効になっているため、ここはスキップ。（Securityタブで、Secret scanning alertsがEnabledになっているのを確認できる。）
- Step 1, Activity 1.2: AWSのアクセスキーIDなどをファイルに書き込んでコミット
- Step 2: Revokedとしてアラートをクローズ（この「シークレット」すでに無効化されており、使用できない状態である。アラートを閉じてよい）
- Step 3: プッシュ保護は、誰かがGitHubにコード変更を送信しようとしたとき、シークレットをチェックする。シークレットスキャンは検出されたシークレットをリスト化し、作成者がシークレットを確認して削除するか、必要に応じてプッシュを許可できるようにします。
- Step 3, Activity 3.1: プッシュ保護は、すべてのパブリックリポジトリでデフォルトで有効になっている。
- Step 3, Activity 3.2: シークレットを書き込んでコミットしようとする。アラートが出る。
- Step 3, Activity 3.3: テストとしてアラートを消し、コミットを行う
 
## 演習6: GitHub Actions

https://github.com/skills/hello-github-actions

- Step 1: Create a workflow file
  - プルリクエスト「Welcome workflow」の作成
  - .github/workflows/welcome.ymlファイルの作成
- Step 2: Add a job to your workflow file
  - .github/workflows/welcome.ymlファイルにjobsを追加
- Step 3: Add a step to your workflow file
  - .github/workflows/welcome.ymlファイルにstepsを追加
- Step 4: Merge your workflow file
  - プルリクエスト「Welcome workflow」をマージする
  - 「welcome-workflow」ブランチを削除
- Step 5: Trigger the workflow
  - 「test-workflow」ブランチを作成
  - 「test-workflow」ブランチでREADME.mdを更新しコミット
  - 「test-workflow」からプルリクエストを新規作成
  - GitHub Actionsにより、プルリクエストに「Welcome to the repository!」というコメントが自動的に追加される


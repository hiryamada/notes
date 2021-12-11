
## GitHubの概要

Microsoft Learn: [GitHub の基礎](https://docs.microsoft.com/ja-jp/learn/paths/github-administration-products/)

[GitHub Learning Lab](https://lab.github.com/)

### GitHubをAzure Boardsにリンクする

[Azure Boards](https://github.com/marketplace/azure-boards)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/boards/github/)

- 無料で利用可能
- コードの管理をGitHubで実施し、タスク管理をAzure Boardで実施したい場合に便利。
- GitHub側
  - Issuesのメッセージ内に `AB#123` などと記述すると、Azure Boardsの作業項目にリンクできる。
  - コミットやプルリクエストメッセージ内に `Fixed AB#123` などと記入することで、対応するAzure Boardの作業項目を `done` 状態にすることができる。
  - READMEファイルに、Azure Boardsのかんばんボードの「ステータスバッジ」を表示できる。
- Azure Boards側
  - 作業項目の「リンクの追加」から、GitHubのコミット、プルリクエスト、Issueなどへリンクを設定できる。

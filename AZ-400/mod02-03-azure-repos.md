# Azure Repos

[製品ページ](https://azure.microsoft.com/ja-jp/services/devops/repos/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/repos/get-started/what-is-repos?view=azure-devops)


- 無料のプライベート Git リポジトリ
- 容量無制限
- 任意のGitクライアントのサポート


## TFVCからAzure Reposへの移行

TFVC(Team Foundation バージョン管理)から、Azure Reposへ、[移行ツールを利用して移行できる](https://docs.microsoft.com/ja-jp/devops/develop/git/migrate-from-tfvc-to-git)


## プルリクエストを作成する（Azure DevOps）

https://docs.microsoft.com/en-us/cli/azure/repos/pr

ブランチを作ってチェックアウトし、コミット、プッシュを行ってから以下を実行

	az login
	az repos pr create 

初回実行時、extension azure-devopsをインストールするか確認が入るので、エンターを押して受け入れる。

## プルリクエストを一覧表示する（Azure DevOps）

    az repos pr list -o table

## プルリクエストをマージする

    az repos pr update --id プルリクエストのID --auto-complete


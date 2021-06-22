# gitコマンド / Azure Reposコマンド(az repos pr)

## リポジトリの作成

	（特定のフォルダで）
	git init

## ワーキングツリーのステータスを表示

	git status

## コミット

	git add ステージングエリアに追加するファイル
	git commit -m 'コミットメッセージ'

## コミットのログを確認

    git log

    git log --oneline # 各コミットを1行で表示

    git log --oneline --graph # 各コミットを1行で, コミットグラフ付きで表示

## リモートにプッシュ

Azure Reposでリポジトリを空で(README.mdや.gitignoreなしで)作成しておく。

	git remote add origin リモートリポジトリのアドレス
	git push -u origin HEAD

(以降git pushだけでよい)

※何もコミットしていない状態でプッシュするとエラーとなる

	error: src refspec main does not match any
	error: failed to push some refs to ...

※リポジトリにREADME.mdなどが入っていても強制的に上書きするには -f オプション（使用注意）

    git push -u origin HEAD -f

## リモートリポジトリを一覧表示

	git remote -v

## リモートからプル

	git pull

## ブランチの一覧表示

	git branch

	git branch -v # コミットハッシュとコミットコメントも表示

	git branch -vv # コミットハッシュとコミットコメント、upstreamのブランチも表示

## ブランチの作成

	git branch ブランチ名

## ブランチへの切り替え

	git checkout ブランチ名

## ブランチの作成と切り替えを一度に行う

	git checkout -b ブランチ名

## ブランチのリネーム

(masterをmainに変更する例)

	git branch -m master main

## 現在のブランチに別のローカルのブランチをマージする

	git merge ブランチ名

## ブランチを削除

	git branch -d ブランチ名

## 作成したブランチをリモートに反映させる

名前で指定したブランチを反映させるには

	git push -u origin ブランチ名

現在チェックアウトしているブランチを反映させるには

	git push -u origin HEAD

## フェッチ（リモート側で作成したブランチを取得）

	git fetch

## フェッチ（リモート側でのブランチ削除をローカルに反映）

	git fetch --prune

※prune プルーン 枝を切り落とす, 剪定する

## コミットした変更を取り消し、リモートに反映させる

直前の1コミット

	git reset --hard HEAD~
	git push -f

指定したコミットハッシュまで

    git reset --hard コミットハッシュ
    git push -f

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


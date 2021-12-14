# Azure Reposの操作

[PDF解説資料](pdf/Azure%20Repos.pdf)


## リポジトリ
- デフォルトでは、プロジェクトに、プロジェクト名と同じGitリポジトリが作成される
- 新しいリポジトリを作成することもできる
  - 画面上部プルダウン→New Repository
- 外部のバージョン管理システムからインポートを行うこともできる
- リポジトリの管理はProject Settings＞Repos＞Respsitoriesから行える
  - リポジトリごとの設定
  - リポジトリの名前変更・削除

## ブランチ

- デフォルトでは、リポジトリ内にmainブランチが作成される。
- デフォルトでは、ファイルを編集し、mainブランチに対して直接コミットできる。
- 新しいブランチを作成できる。
  - 画面上部ブランチ名→New Branch
- 新しいブランチに対してコミットしたら、直後に（mainブランチに対する）プルリクエストを作成できる。
  - 画面左Pull Requestsで、後からでもプルリクエストを作成できる。
  - mainブランチにコミットした場合は、プルリクエストは作成できない。


## ファイル一覧（画面左Files)

- 新しいファイルやフォルダの作成ができる
  - 画面内「...」→New→File/Folder
- 空のフォルダは作成できない。
  - ファイルを伴う必要がある。またファイルをコミットする必要がある。
- ファイルをアップロードできる。
- ファイルをダウンロードできる
  - ファイル単体、または、複数ファイルZip
- ファイルの編集/リネーム/削除できる
  - 各ファイル右側の...より
- Markdownファイルのプレビューができる。
  - ただしここでは::: mermaid ～ ::: で記述してもレンダリングはされない。

## コミット（画面左Commits)

- 各ブランチに行われたコミットを確認することができる。
- 画面の上の方に表示されているものほど新しい。
- 各コミットのつながりを表すコミットグラフが表示される。
  - 画面上部のアイコンで表示をON/OFFできる
- コミットID、Author、From date等で検索を行うことができる

## ブランチ（画面左Branches)

- ブランチの一覧を確認することができる
- 各ブランチの「...」＞Branch Policiesでブランチごとのポリシーの設定ができる

## ブランチのポリシー（★重要★）

- Branch Policiesで設定
- いずれかのRequired Policyが有効になっている場合:
  - **プルリクエストを介して変更を加える必要がある。**
  - ブランチは削除できない
  - ポリシーが設定された状態で、ブランチに直接コミットしようとすると「TF402455: Pushes to this branch are not permitted; you must use a pull request to update this branch.」といったエラーになる。
- Require a minimum number of reviewers:
  - 必要な最小のレビュアー人数を指定できる（1～10）
  - プルリクエスト作成者が、自分自身の変更をApproveできるように設定できる（デフォルト: No）
- Check for linked work items
  - RequiredまたはOptional
  - Requiredの場合、プルリクエストに、関連するWork Itemをリンクしなければ、Completeできなくなる。
  - Optionalの場合、プルリクエストに、関連するWork Itemがリンクされていない場合に警告を出すが、Completeは可能。
  - デフォルトでは、関連するWork Itemは、このプルリクエストのCompleteとともにDoneに設定される。
- Check for comment resolution
  - RequiredまたはOptional
  - Requiredの場合、プルリクエストに追加されたコメントが一つでもアクティブの場合（正確にはActiveまたはPendingの場合）、Completeできなくなる
    - コメントの状態
      - Active
      - Pending
      - Resolved
      - Won't fix
      - Closed
  - Optionalの場合、プルリクエストに追加されたコメントが一つでもアクティブになっている場合、警告を出すが、Completeはできる
- 

## プルリクエスト

- 新しいブランチで変更を行い、そのプルリクエストを作成できる。
- プルリクエストに対し、Approve（承認）/Reject（拒否）ができる
  - https://docs.microsoft.com/ja-jp/azure/devops/repos/git/review-pull-requests?view=azure-devops&tabs=browser#vote-on-changes
- Approve/Rejectすると、そのユーザーがreviewerとしてそのプルリクエストに参加する。
- プルリクエストのReviewersに、各ユーザーのApproved/Rejectedが表示される。
- デフォルトでは、Approved/Rejectedの数に関係なく、プルリクエストのComplete(完了)/Avandon(破棄)ができる
  - https://docs.microsoft.com/ja-jp/azure/devops/repos/git/complete-pull-requests?view=azure-devops&tabs=browser

## プルリクエストのコメント

- https://docs.microsoft.com/ja-jp/azure/devops/repos/git/review-pull-requests?view=azure-devops&tabs=browser#make-comments
- プルリクエストにコメントを付けることができる
- コメントの状態は初め「Active」となる。
- コメントに返信（Reply）をつけることができる。Replyすると同時に状態を「Resolved」にすることもできる。
- コメントに「いいね」を付けることができる。

## クローン

- リポジトリをクローンできる（画面右側のClone)
- HTTPS: 
  - https://test2021-1213@dev.azure.com/test2021-1213/project-e/_git/project-e
  - Generate Git Credentials（ユーザー名＋パスワードが生成される)
- SSH:
  - git@ssh.dev.azure.com:v3/test2021-1213/project-e/project-e
  - 新しいpublic keyのアップロードができる。
- Visual Studio Code等のIDEとの連携:
  - AzureAD認証などを使用

## フォーク

- https://docs.microsoft.com/ja-jp/azure/devops/repos/git/forks?view=azure-devops&tabs=visual-studio
- リポジトリをフォークができる（画面右側のCloneの脇の...から)
- デフォルトではフォーク先として「プロジェクト名.ユーザー名」のような名前のリポジトリが作られる
- プロジェクトは自分がアクセスできる場所であれば選択できる。
- デフォルトブランチ(main)のみ、または、すべてのブランチをフォークできる。
- （GitHubのように）フォークしたプロジェクトで変更を行い、元のリポジトリへのプルリクエストを作成することができる。
- Azure DevOpsの画面上では、（GitHubのように）元のリポジトリとのコミットの差を簡単に確認することはできない。
  - Commitsの画面を表示してコミットを確認する必要がある。
- Azure DevOpsの画面上では、（GitHubのように）フェッチ&マージを行うことはできない。
  - いったんローカル開発環境などにクローンし、コマンドを使って、フェッチ&マージに相当する操作を実行する必要がある。
```
git remote add upstream {upstream_url}
git fetch upstream main
git rebase upstream/main
git push origin
```
- 参考:
  - https://docs.microsoft.com/ja-jp/azure/devops/repos/git/forks?view=azure-devops&tabs=command-line#clone-your-fork-locally
  - https://docs.microsoft.com/ja-jp/azure/devops/repos/git/forks?view=azure-devops&tabs=command-line#sync-your-fork-to-latest

## vscode.devからのアクセス

- 現在プレビュー。読み取り専用。
- 解説: https://qiita.com/uikou/items/b5f6a0cd4228c46159dc#azure-repos-%E3%83%97%E3%83%AC%E3%83%93%E3%83%A5%E3%83%BC

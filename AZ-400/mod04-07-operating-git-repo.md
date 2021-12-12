
# Gitリポジトリの管理

## 大きなリポジトリの操作

■クローンのサイズを小さくする

開発者がリポジトリをローカルに「クローン」する際に、リポジトリで利用可能なすべての履歴を必要としない場合、クローンする履歴の深さを指定したり、単一のブランチのみクローンしたりすることができる。

```
git clone --depth
```

■参考: MicrosoftのGit Virtual File System（GVFS）

[解説記事](https://jp.techcrunch.com/2017/05/25/20170524microsoft-now-uses-git-and-gvfs-to-develop-windows/)

- WindowsのソースコードはGitで行われるようになった
- トータルサイズは300GBとなる
- 巨大なリポジトリをGitで扱えるように、GVFSというものを開発した
- [Microsoft Git](https://github.com/Microsoft/git)として公開されている。

## リポジトリデータの消去

Gitリポジトリの履歴から特定のファイルを完全に削除するには。

大きなファイルや、機密ファイルをGitにコミットしてしまい、あとからそれを削除したい場合。

[GitHubの解説](https://docs.github.com/ja/github/authenticating-to-github/keeping-your-account-and-data-secure/removing-sensitive-data-from-a-repository)がわかりやすい。

なお上記解説にもあるが、機密情報をGitHubにアップロードしてしまった場合、機密情報を削除するだけでは不十分。

- 誤ってアップロードしてしまった機密情報の無効化を行う必要がある。
  - パスワードの変更、キーのローテーションなどを行う
- 流出した機密情報ですでに攻撃が行われた可能性も考慮する。
  - アクセスログなどを確認

■git filter-branch

git [filter-branch](https://www.google.com/search?q=filter-branch) を使用して、Gitの履歴から特定のファイルを削除することができる。

■BFG Repo-Cleaner

BFG Repo-Cleanerでも同様のことができ、より高速に動作する。

- [公式サイト](https://rtyley.github.io/bfg-repo-cleaner/)
- [BFGの由来](https://github.com/rtyley/bfg-repo-cleaner/issues/348)


## ソース管理システムの種類

- 集中ソース管理
  - [TFVC(Team Foundation Version Control)](https://docs.microsoft.com/ja-jp/azure/devops/repos/tfvc/?view=azure-devops)
  - [CVS](https://ja.wikipedia.org/wiki/Concurrent_Versions_System)
  - [Subversion](https://ja.wikipedia.org/wiki/Apache_Subversion)
  - など
- 分散型ソース管理
  - [Git](https://ja.wikipedia.org/wiki/Git)
  - [Mercurial](https://ja.wikipedia.org/wiki/Mercurial)
  - [Bazaar](https://ja.wikipedia.org/wiki/Bazaar)
  - など

集中ソース管理 vs 分散型ソース管理

- 分散型ソース管理のメリット
  - ローカルでコミットできる（ネットワーク接続が不要）
  - コミットをまとめてプッシュできる
  - 各プログラマーが、リポジトリの完全なコピーを持つ
    - （GitHubでフォークした個人リポジトリにおいて）必要なユーザーにだけ変更を共有できる
- デメリット
  - バイナリファイルの履歴が大きくなりがち
    - → [大きくなったリポジトリを作り直す・不要ファイルを履歴から取り除く](https://gomiba.co/archives/2017/11/1323/)
  - 多くの変更セットを持つ履歴全体のダウンロードに時間がかかる
    - [→ shallow clone で、履歴全体ではなく最新履歴のみ取得ができる](https://qiita.com/usamik26/items/7bfa61b31344206077fb)


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
  - 多くの変更セットを持つ履歴全体のダウンロードに時間がかかる


## ソース管理とは

### ソース管理の概要

DevOpsにおいてソース管理はなぜ必要か。

Puppet 社とCircleCI 社 が毎年発行している、DevOpsに関するレポート「State of DevOps Report」によれば、DevOps変革を達成するためには、ソース管理(バージョン管理)の活用が必要不可欠である。

- [State of DevOps Reportの歴史](https://gkuga.hatenablog.com/entry/2020/02/28/142316)
- 2018年度版
  - [レポート](https://puppet.com/resources/report/2018-state-devops-report)
- 2019年度版
  - [レポート](https://puppet.com/resources/report/2019-state-of-devops-report)
- 2020年度版
  - [レポート](https://puppet.com/resources/report/2020-state-of-devops-report)
  - [概要](https://www.infoq.com/jp/news/2021/01/2020-devops-report/)
  - [解説](https://www.tc3.co.jp/2020stateofdevopsreport_platformmodel/)
- 2021年度版
  - [レポート](https://puppet.com/resources/report/2021-state-of-devops-report)
  - [日本語解説1](https://www.tc3.co.jp/state-of-devops-report-2021-team-topologies/)
  - [日本語解説2](https://blog.kengo-toda.jp/entry/2021/07/26/212706)

[DevOps進化(変革)モデル](https://www.tc3.co.jp/2020stateofdevopsreport_platformmodel/#%E2%97%86_DevOps%E3%81%AE%E9%80%B2%E5%8C%96%E3%83%A2%E3%83%87%E3%83%AB)：DevOps変革のステージが上がる（DevOps変革が進む）につれて、プログラムのソースコードだけではなく、システム構成、インフラ構成、アプリ構成などもバージョン管理されるようになる。

- [2020 年版 State of DevOps レポート](https://circleci.com/ja/resources/state-of-devops-report-2020/)
  - 10ページに、DevOps 変革モデル（DevOps Evolution Mode）のステージ1～5の解説がある
  - STAGE 1 Normalization(正規化)
    - Application development teams use **version control**
    - Teams deploy on a standard set of operating systems
  - STAGE 2 Standardization(標準化)
    - Teams deploy on a single standard operating system
    - Teams build on a standard set of technologies
  - STAGE 3 Expansion(拡張)
    - Individuals can do work without manual approval from outside the team
    - Deployment patterns for building apps/services are reused
    - Infrastructure changes are tested before deploying to production
  - STAGE 4 Automated infrastructure delivery(自動的なインフラ提供)
    - System configurations are automated
    - Provisioning is automated
    - System configs are in **version control**
    - Infrastructure teams use **version control**
    - Application configs are in **version control**
    - Security policy configs are automated
  - STAGE 5 Self-service(セルフサービス)
    - Incident responses are automated
    - Resources are available via self-service 
    - Applications are rearchitected based on business needs
    - Security teams are involved in technology design and deployment


### ソース管理とは？

[ソース管理システム(バージョン管理システム)](https://ja.wikipedia.org/wiki/%E3%83%90%E3%83%BC%E3%82%B8%E3%83%A7%E3%83%B3%E7%AE%A1%E7%90%86%E3%82%B7%E3%82%B9%E3%83%86%E3%83%A0) の特徴とは。

- 復数の開発者による共同作業を支援
- 変更をトラッキング
- 以前のバージョンにロールバックできる
- 災害などからのソースコードを保護する
  - Azure DevOps: [参考](https://docs.microsoft.com/ja-jp/azure/devops/organizations/security/data-protection?view=azure-devops)
    - Azure DevOpsのデータはAzureデータセンターに格納される
    - 同じ地域内の2つのリージョンでレプリケーション（冗長化）される
      - GRS(Geo Redundancy Storage)を使用して合計6重に冗長化
  - Azure DevOps Server
    - [オンプレミス（お客様が管理する拠点・データセンター内）で運用される](https://docs.microsoft.com/ja-jp/azure/devops/user-guide/about-azure-devops-services-tfs?view=azure-devops-2020)
    - [バックアップを構成可能](https://docs.microsoft.com/ja-jp/azure/devops/server/admin/backup/back-up-restore?view=azure-devops-2020)
  - GitHub: [参考](https://news.mynavi.jp/article/20160923-githubuniverse5/)
    - 米国にある3箇所のデータセンター内のサーバー内で3重にレプリケーション
    - GitHub内部のレプリケーションシステム: Spoke
      - [以前はDGit(Distributed Git)と呼ばれていた](https://github.blog/2016-04-05-introducing-dgit/)
      - [現在はSpokeと呼ばれている](https://github.blog/2016-09-07-building-resilience-in-spokes/)
- 誰が、いつ、どこを、どのように変更したかがわかる

## ソース管理の利点

ソース管理の利点とは。ソース管理のベストプラクティスとは。

- ワークフローを利用して作業する
  - Gitで使用される[いくつかの「ワークフロー」](https://www.atlassian.com/ja/git/tutorials/comparing-workflows)がある。
    - 代表的なものは[フィーチャー（機能）ブランチ](https://www.google.com/search?q=%E3%83%95%E3%82%A3%E3%83%BC%E3%83%81%E3%83%A3%E3%83%BC%E3%83%96%E3%83%A9%E3%83%B3%E3%83%81)
    - ブランチモデルについては[モジュール4](mod04.md)で解説
- バージョンを操作
  - 1つ～複数のファイルの変更に対してバージョニングする
  - [各バージョンにコメントを付与できる](https://www.google.com/search?q=git+%E3%82%B3%E3%83%9F%E3%83%83%E3%83%88%E3%83%A1%E3%83%83%E3%82%BB%E3%83%BC%E3%82%B8)
- コラボレーション
  - [競合の発見と解決ができる](https://www.google.com/search?q=git+%E3%82%B3%E3%83%B3%E3%83%95%E3%83%AA%E3%82%AF%E3%83%88)
- 変更履歴の保持
  - [変更履歴の確認ができる](https://www.google.com/search?q=git+%E5%B1%A5%E6%AD%B4)
    - git log
  - [ロールバックができる](https://www.google.com/search?q=git+%E3%83%AD%E3%83%BC%E3%83%AB%E3%83%90%E3%83%83%E3%82%AF)
    - [git reset](https://www.atlassian.com/ja/git/tutorials/undoing-changes/git-reset)
    - [git revert](https://www.atlassian.com/ja/git/tutorials/undoing-changes/git-revert)
- タスクの自動化
  - コミット（プッシュ）と同時に、ローカルでカスタムスクリプトを実行したり、パイプライン上でビルドやテストを行ったりすることができる。
  - [Gitフック](https://git-scm.com/book/ja/v2/Git-%E3%81%AE%E3%82%AB%E3%82%B9%E3%82%BF%E3%83%9E%E3%82%A4%E3%82%BA-Git-%E3%83%95%E3%83%83%E3%82%AF)
  - [Azure Pipelines](https://azure.microsoft.com/ja-jp/services/devops/pipelines/)
  - [GitHub Action](https://github.co.jp/features/actions)

ソース管理のベストプラクティス

- 小さくコミットする
  - 意味のある小さい単位で、より頻繁にコミットする
- 個人のファイルをコミットしない
  - アプリケーション設定
  - 機密情報
  - [.gitignoreを使用して、バージョン管理しないファイルを指定](https://www.atlassian.com/ja/git/tutorials/saving-changes/gitignore)
  - [gitignore.ioで、.gitignoreを簡単に生成できる](https://www.toptal.com/developers/gitignore)
  - [コマンドからも生成できる](https://qiita.com/dhun/items/adcae139b5ba1da56c81)
- プッシュ前にプルする
- プッシュ前に、コンパイルが通ることを確認
- コミットメッセージを書く
- コミットメッセージと作業項目をリンクさせる
- チームの規約に従う

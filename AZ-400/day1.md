# [ラーニング パス1: DevOps 変換の過程を開始する](https://docs.microsoft.com/ja-jp/learn/paths/az-400-get-started-devops-transformation-journey/)

## [モジュール1: DevOps の概要](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-devops/)

- [ ] DevOpsの定義:
  - ✅**エンド ユーザーに対して継続的に価値を提供するための、人、プロセス、および製品の組み合わせ**
- ✅**継続的インテグレーション**
  - コードのマージとテストを継続的に行うこと
- ✅**コードとしてのインフラストラクチャ (IaC)**
  - ✅環境をコードで定義し、自動的に作成できるようにする
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-devops/6-knowledge-check)

## [モジュール2: 適切なプロジェクトを選択する](https://docs.microsoft.com/ja-jp/learn/modules/choose-right-project/)

- 技術的負債
- ✅プロジェクトの種類
  - グリーンフィールド
  - ✅ブラウンフィールド
    - ✅多くの技術的負債が含まれている場合がある
  - ※「ブルーフィールド」という言葉はない
- ✅システムの種類
  - ✅**Systems of Record**
    - 企業の情報を正確に記録するシステム
    - 安定性・信頼性が重視される
    - ✅**倉庫の在庫を管理するシステム** などが該当
  - Systems of Engagement
    - 顧客との結びつき・つながりを深めるシステム（CRM、チャットボット等）などが該当
    - 「正しい設計」が存在しない場合があり、試行錯誤が必要
  - ※[他に「Systems of Insight」などもある](https://www.cyzen.cloud/magazine/soe_sor)
  - ※「Systems of History」という言葉はない
- ✅ユーザーの種類
  - ✅カナリア
  - ✅早期導入者（アーリーアダプター）
  - ✅（一般）ユーザー
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/choose-right-project/7-knowledge-check)

## [モジュール3: チーム構造を記述する](https://docs.microsoft.com/ja-jp/learn/modules/describe-team-structures/)

- ✅**かんばんボード**
  - ✅ステージ（列）の左から右に、タスクを移動し、作業を管理および視覚化
- ✅ウォーターフォールとアジャイル
  - ウォーターフォールを採用している組織は、アジャイルに移行する（プロジェクト管理の方法を進化させる）ことができる。
  - ✅**すでにアジャイルを採用している組織が、ウォーターフォールを利用する必要は特に無い。**
- ✅アジャイルに対応するサービス（ツール）: 
  - Azure DevOps, GitHub等。
  - ✅**画面をキャプチャ（録画）するツール「Camstasia」は、開発やテストで役に立つ場合があるが、アジャイルのためのツールではない。**
- 知識チェック

## [モジュール4: DevOps への移行](https://docs.microsoft.com/ja-jp/learn/modules/migrate-to-devops/)

## [モジュール5: ソース管理の概要](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-source-control/)

## [モジュール6: ソース管理システムの種類について説明する](https://docs.microsoft.com/ja-jp/learn/modules/describe-types-of-source-control-systems/)

## [モジュール7: Azure Repos と GitHub を操作する](https://docs.microsoft.com/ja-jp/learn/modules/work-azure-repos-github/)

# [ラーニング パス2: エンタープライズ DevOps 用の Git を使用する](https://docs.microsoft.com/ja-jp/learn/paths/az-400-work-git-for-enterprise-devops/)

## [モジュール1: Git リポジトリを構成する](https://docs.microsoft.com/ja-jp/learn/modules/structure-your-git-repo/)

- ✅リポジトリの構成（戦略）:
  - 「マルチリポ」:
    - プロジェクトごとにリポジトリをつくる
    - 別のプロジェクトの参照や修正が素早く実行できる
  - ✅「モノリポ」:
    - すべてのプロジェクトを1つのリポジトリに入れる
    - 別のプロジェクトの参照や修正が素早く実行できる
    - ✅**チームがシステムで一緒に作業を迅速に行うことができる。**
  - ✅**「機能リポジトリ」というものはない。**
- ✅変更ログ
  - ✅変更ログを作成する一般的なツール
    - ✅**gitchangelog**
    - github-changelog-generator
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/structure-your-git-repo/4-knowledge-check)

## [モジュール2: Git ブランチとワークフローの管理](https://docs.microsoft.com/ja-jp/learn/modules/manage-git-branches-workflows/)

- ブランチ ワークフローの種類
  - 「SmartFlow」というものはない
- ブランチ モデル
- git-flow拡張機能
  - 機能ブランチの作成
    - 

## [モジュール3: Azure Repos で pull request を使用して共同作業する](https://docs.microsoft.com/ja-jp/learn/modules/collaborate-pull-requests-azure-repos/)

## [モジュール4: Git フックを探索する](https://docs.microsoft.com/ja-jp/learn/modules/explore-git-hooks/)

## [モジュール5: 内部ソースの推進を計画する](https://docs.microsoft.com/ja-jp/learn/modules/plan-fostering-inner-source/)

## [モジュール6: Git リポジトリの管理](https://docs.microsoft.com/ja-jp/learn/modules/manage-git-repositories/)
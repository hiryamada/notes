# ラーニングパスとモジュールの概要

- 1日目
  - ラーニングパス1: DevOpsの概要
    - モジュール1～4: DevOps
    - ハンズオン: Azure DevOps Services 組織の作成
    - ハンズオン: GitHubアカウントの作成
    - モジュール5～7: ソース管理 / バージョン管理
  - ラーニングパス2: Git

# [ラーニング パス1: DevOps 変換の過程を開始する](https://docs.microsoft.com/ja-jp/learn/paths/az-400-get-started-devops-transformation-journey/)

※DevOps**変換**: DevOps **transformation**, DevOpsを採用していない組織がDevOpsを使用するようになること. 参考: [DX(デジタル トランスフォーメーション)](https://www.google.com/search?q=dx)

※DevOps変換の**過程**: DevOps transformation **journey**, DevOps transformationの導入には、組織における多数の変革が必要（ある程度の時間がかかり、困難も伴う。）
- 人の変革: Dev(開発チーム)とOps(運用チーム)が協力する
- プロセスの変革: ウォーターフォールからアジャイルへ移行する
- ツールの変革: さまざまなDevOps製品を活用する

※journey（ジャーニー）: 長旅。[TripやTravelと比べ、Journeyは少し「長旅」のイメージ。](https://www.r-pics.com/success/column/_62dx.html)

## [モジュール1: DevOps の概要](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-devops/)

- 講義: [DevOpsとは](mod01-01-devops.md)
- 講義: [参考: MicrosoftにおけるDevOpsの導入](mod01-10-microsoft-devops.md)
- ↓「★」は重要ポイント
- ★DevOpsの定義:
  - ★**エンド ユーザーに対して継続的に価値を提供するための、人、プロセス、および製品の集まり**
  - 「継続的インテグレーション(CI)」や「コードとしてのインフラストラクチャ（IaC）」を活用する
- ★**継続的インテグレーション**
  - コードのマージとテストを継続的に行うこと
  - ※詳細はDay2前半に解説
- ★**コードとしてのインフラストラクチャ (IaC)**
  - ★環境をコードで定義し、自動的に作成できるようにする
  - ※詳細はDay3後半に解説
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-devops/6-knowledge-check)

## [モジュール2: 適切なプロジェクトを選択する](https://docs.microsoft.com/ja-jp/learn/modules/choose-right-project/)

- 講義: [適切なプロジェクトを選択する](mod01-08-devops-team-project.md)
- 講義: [参考: Microsoftにおけるアジャイルの導入](mod01-11-microsoft-agile.md)
- 講義: [技術的負債の管理](mod03.md)
- 技術的負債
- ★プロジェクトの種類
  - グリーンフィールド
  - ★ブラウンフィールド
    - ★多くの技術的負債が含まれている場合がある
  - ※「ブルーフィールド」という言葉はない
- ★システムの種類
  - ★**Systems of Record**
    - 企業の情報を正確に記録するシステム
    - 安定性・信頼性が重視される
    - ★**倉庫の在庫を管理するシステム** などが該当
  - Systems of Engagement
    - 顧客との結びつき・つながりを深めるシステム（CRM、チャットボット等）などが該当
    - アジャイル開発に向く場合がある
  - ※[他に「Systems of Insight」などもある](https://www.cyzen.cloud/magazine/soe_sor)
  - ※「Systems of History」という言葉はない
- ★継続的デリバリーにおける一般的なユーザーのカテゴリー
  - ★カナリア
  - ★早期導入者（アーリーアダプター）
  - ★（一般）ユーザー
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/choose-right-project/7-knowledge-check)

## [モジュール3: チーム構造を記述する](https://docs.microsoft.com/ja-jp/learn/modules/describe-team-structures/)

- 講義: [かんばんボード](mod01-13-kanban.md)
- 講義: [アジャイルなソフトウェア開発](mod01-12-agile.md)
- ★**かんばんボード**
  - ★ステージ（列）の左から右に、タスクを移動し、作業を管理および視覚化
- ★ウォーターフォールとアジャイル
  - ウォーターフォールを採用している組織は、アジャイルに移行する（プロジェクト管理の方法を進化させる）ことができる。
  - ★**すでにアジャイルを採用している組織が、ウォーターフォールを利用する必要は特に無い。**
- ★アジャイルに対応するサービス（ツール）: 
  - Azure DevOps, GitHub等。
  - ★**画面をキャプチャ（録画）するツール「[Camtasia](https://www.techsmith.co.jp/camtasia.html)」は、開発やテストで役に立つ場合があるが、アジャイルのためのツールではない。**
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/describe-team-structures/8-knowledge-check)

## [モジュール4: DevOps への移行](https://docs.microsoft.com/ja-jp/learn/modules/migrate-to-devops/)

- 講義: [Azure DevOps Services](mod01-02-azure-devops.md)
- 講義: [Azure DevOps Server](mod01-03-devops-server.md)
- 講義: [GitHub](mod01-04-github.md)
- 講義: [価格](mod01-07-license.md)
- ★[Azure DevOps Services](https://azure.microsoft.com/ja-jp/services/devops/#overview) - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/devops/user-guide/what-is-azure-devops?view=azure-devops)
  - ★[Azure Boards](https://azure.microsoft.com/ja-jp/services/devops/boards/)
  - ★[Azure Repos](https://azure.microsoft.com/ja-jp/services/devops/repos/)
  - [Azure Pipelines](https://azure.microsoft.com/ja-jp/services/devops/pipelines/)
  - [Azure Artifacts](https://azure.microsoft.com/ja-jp/services/devops/artifacts/)
  - [Azure Test Plans](https://azure.microsoft.com/ja-jp/services/devops/test-plans/)
  - ★※[Azure Monitor](https://docs.microsoft.com/ja-jp/azure/azure-monitor/overview)はAzure DevOps Servicesの一部ではない
  - ★Azure DevOps Servicesの（エンタープライズレベル）認証
    - ★Microsoftアカウント
      - [個人のMicrosoftアカウントでサインアップ](https://docs.microsoft.com/ja-jp/azure/devops/user-guide/sign-up-invite-teammates?view=azure-devops#sign-up-with-a-personal-microsoft-account)
    - ★Azure Active Directory
      - [Azure DevOps 組織を Azure ADに接続することで、Azure ADのユーザーを使用してAzure DevOpsにサインインできる](https://docs.microsoft.com/en-us/azure/devops/organizations/accounts/connect-organization-to-azure-ad?view=azure-devops)
    - ★GitHubアカウント
      - [GitHub アカウントを使用してサインアップ](https://docs.microsoft.com/ja-jp/azure/devops/user-guide/sign-up-invite-teammates?view=azure-devops#sign-up-with-a-github-account)
- [GitHub](https://github.com/) - [ドキュメント](https://docs.github.com/ja)
  - [リポジトリ](https://docs.github.com/ja/repositories)
  - [イシュー](https://docs.github.com/ja/issues)
  - [プルリクエスト](https://docs.github.com/ja/pull-requests/collaborating-with-pull-requests/proposing-changes-to-your-work-with-pull-requests/about-pull-requests)
    - [参考: GitHubのプルリクエストはGitのpull-request moduleの劣化版(by Linus Torvalds)](https://github.com/torvalds/linux/pull/17)
  - [プロジェクト(GitHub Projects)](https://docs.github.com/ja/issues/trying-out-the-new-projects-experience/about-projects)
  - [アクション(GitHub Actions)](https://github.co.jp/features/actions)
  - [GitHub Packages](https://docs.github.com/ja/packages)
  - [GitHub Codespaces](https://github.co.jp/features/codespaces)
- ★オンプレミス向けのオプション
  - ★[Azure DevOps Server](https://azure.microsoft.com/ja-jp/services/devops/server/)
  - ★[GitHub Enterprise](https://github.co.jp/enterprise.html)
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/migrate-to-devops/8-knowledge-check)

## ハンズオン(演習)

- Azure DevOps
  - Azure DevOps組織とプロジェクトを作成しましょう
  - お手元のブラウザから [Azure portal](https://portal.azure.com/) にアクセスします
  - トレーニング開始時に作成したMicrosoftアカウントでサインインします
  - 手順書: [Azure DevOpsの使用を開始する](pdf/Azure%20DevOpsの使用を開始する.pdf)
- GitHub
  - GitHubアカウントを作成しましょう
  - 手順書: [GitHubアカウントの作成](github-account.md)

## [モジュール5: ソース管理の概要](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-source-control/)

- 講義: [ソース管理の重要性](mod02-01-source-management.md)
- ソース管理システム
  - Source Control System = Version Control System と定義されている。
    - [Microsoft Learn](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-source-control/3-what-source-control)
    - [Azure DevOpsのドキュメント](https://docs.microsoft.com/en-us/azure/devops/user-guide/source-control?view=azure-devops)
      - 具体的にはGitやTeam Foundation Version Controlのことを指す。
  - ★バージョンコントロールとは
    - ★ファイル（資産）の変更を管理する機能
    - ★必要な場合には、過去のバージョンにロールバックできる
    - ★「デプロイのたびにバージョン番号を自動的に増やすソリューション」ではない
- ★ソース管理の利点
  - 管理の容易さ
  - 効率性
  - ★※アカウンタビリティ（説明責任）はソース管理の利点には含まれない
- ★ソース管理のベストプラクティス
  - ★小さな変更をコミットする
  - ★[コードの変更を作業項目にリンクする](https://docs.microsoft.com/ja-jp/azure/devops/notifications/add-links-to-work-items?view=azure-devops)
    - 参考: [コミットの粒度をどのくらいにするべきかについてはいろいろな意見がある](https://qiita.com/jnchito/items/40e0c7d32fde352607be#sonicgarden%E3%81%AE%E3%83%A1%E3%83%B3%E3%83%90%E3%83%BC%E3%81%AB%E8%81%9E%E3%81%84%E3%81%A6%E3%81%BF%E3%81%9F0200)
  - ★※個人用のファイルやパスワード等の認証情報が書かれたファイル（セキュアファイル）はコミットしない
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-source-control/6-knowledge-check)

## [モジュール6: ソース管理システムの種類について説明する](https://docs.microsoft.com/ja-jp/learn/modules/describe-types-of-source-control-systems/)

- 講義: [ソースコード管理システムの種類](mod02-06-scm-type.md)
- 講義: [Git](mod02-02-git.md)
- 講義: [Gitのコマンド](mod02-02-01-git-commands.md)
- ソース管理とは
  - コードに対する変更を追跡および管理する方法
- [分散型ソース（バージョン）管理](https://docs.microsoft.com/ja-jp/learn/modules/describe-types-of-source-control-systems/3-understand-distributed) - Git
  - 完全なオフライン サポート
  - ポータブル履歴
  - pull request を使用できる
  - ※排他的ファイル ロック（「[チェックアウト](https://docs.microsoft.com/ja-jp/azure/devops/repos/tfvc/check-out-edit-files?view=azure-devops#check-out-items-manually)」）はできない
- [集中型ソース（バージョン）管理](https://docs.microsoft.com/ja-jp/learn/modules/describe-types-of-source-control-systems/2-understand-centralized) - Team Foundation Version Control
  - 排他的ファイル ロックが可能
  - コードベースに応じたサーバーのスケーリングを行う（「[マルチスケーリング](https://docs.microsoft.com/ja-jp/azure/devops/server/requirements?view=azure-devops-2020#multi-server-deployments)」）
  - ※pull request は使用できない
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/describe-types-of-source-control-systems/8-knowledge-check)

## [モジュール7: Azure Repos と GitHub を操作する](https://docs.microsoft.com/ja-jp/learn/modules/work-azure-repos-github/)

- 講義: [Azure Repos](mod02-03-azure-repos.md)
- 講義: [GitHub](mod02-04-github.md)
- ★Azure Repos がサポートする形式
  - Git
  - Team Foundation Version Control
  - ★※Visual Source Safe (VSS) はサポートしない
- ★Azure DevOpsとGitHubの統合
  - ★Azure Boards は Azure Repos と直接統合されている
  - ★GitHub と統合して作業リンクのコミット、PR、問題を計画および追跡することもできる
- ★Azure DevOps の リポジトリのインポート
  - 外部のリポジトリの取り込みができる
  - ★制限
    - 1 つのブランチのみ
    - ★180 日分の履歴のみ
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/work-azure-repos-github/8-knowledge-check)

# [ラーニング パス2: エンタープライズ DevOps 用の Git を使用する](https://docs.microsoft.com/ja-jp/learn/paths/az-400-work-git-for-enterprise-devops/)

## [モジュール1: Git リポジトリを構成する](https://docs.microsoft.com/ja-jp/learn/modules/structure-your-git-repo/)

- 講義: [モノレポ vs 複数リポジトリ](mod04-01-monorepo.md)
- 講義: [プロジェクトの変更ログ（CHANGELOG.md）](mod04-02-changelog.md)
- ★リポジトリの構成（戦略）:
  - 「マルチリポ」:
    - プロジェクトごとにリポジトリをつくる
    - 別のプロジェクトの参照や修正が素早く実行できる
  - ★「モノリポ」:
    - すべてのプロジェクトを1つのリポジトリに入れる
    - 別のプロジェクトの参照や修正が素早く実行できる
    - ★ **チームがシステムで一緒に作業を迅速に行うことができる。**
  - ★ **「機能リポジトリ」というものはない**
- ★変更ログ
  - ★変更ログを作成する一般的なツール
    - ★**gitchangelog**
    - github-changelog-generator
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/structure-your-git-repo/4-knowledge-check)

## [モジュール2: Git ブランチとワークフローの管理](https://docs.microsoft.com/ja-jp/learn/modules/manage-git-branches-workflows/)

- 講義: [ブランチの運用](mod04-03-branch.md)
- 講義: [GitHubにおけるフォーク、プルリクエスト、マージ](pdf/GitHub%E3%81%AE%E3%83%95%E3%82%A9%E3%83%BC%E3%82%AF.pdf)
- ブランチ ワークフローの種類（いわゆる「[ブランチ戦略](https://www.google.com/search?q=%E3%83%96%E3%83%A9%E3%83%B3%E3%83%81%E6%88%A6%E7%95%A5)」）
  - [機能ブランチ ワークフロー](https://docs.microsoft.com/ja-jp/learn/modules/manage-git-branches-workflows/3-explore-feature-branch-workflow)
    - 機能開発を専用のブランチで行う
  - ★[Gitflow ワークフロー](https://docs.microsoft.com/ja-jp/learn/modules/manage-git-branches-workflows/5-explore-gitflow-branch-workflow)
    - ★プロジェクトのリリースを中心に設計されている
    - [git-flow拡張機能](https://docs.microsoft.com/ja-jp/learn/modules/manage-git-branches-workflows/5-explore-gitflow-branch-workflow)
      - [拡張機能のGitHubリポジトリ](https://github.com/petervanderdoes/gitflow-avh)
      - ★機能ブランチの作成: `git flow feature start feature_branch`
    - [Gitflowは難しすぎる説](https://itnews.org/news_contents/please-stop-recommending-git-flow)
  - [Forking ワークフロー](https://docs.microsoft.com/ja-jp/learn/modules/manage-git-branches-workflows/6-explore-fork-workflow)
    - ※GitHubのやりかた
    - リポジトリを「フォーク」して自分のリポジトリを作成
    - 自分のリポジトリ側で作業
    - プルリクエストを作成して、元のリポジトリに変更をマージしてもらう
  - [トランクベース開発](https://www.atlassian.com/ja/continuous-delivery/continuous-integration/trunk-based-development)
    - 開発者が細かく頻繁なアップデートを main ブランチ（「[トランク](https://tracpath.com/bootcamp/learning_subversion_tutorial1.html#trunk)」）にマージするバージョン管理手法
    - Gitflowワークフローよりも単純
  - ★※「SmartFlowワークフロー」というものはない
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/manage-git-branches-workflows/7-knowledge-check)

## [モジュール3: Azure Repos で pull request を使用して共同作業する](https://docs.microsoft.com/ja-jp/learn/modules/collaborate-pull-requests-azure-repos/)

- 講義: [プルリクエストの運用](mod04-04-pr.md)
- ★プルリクエスト
  - ★共同作業するチームや組織でよく使用される
  - ★全員が 1 つのリポジトリを共有し、機能を開発したり、変更を分離したりするためにトピック ブランチが使用される
  - ★プルリクエストに対してフィードバック（ディスカッション）を行うことができる
- ★ブランチの保護
  - ★ブランチ ポリシーを使用してブランチを保護する
    - あるブランチに、直接コミットができないように（プルリクエストのマージのみ可能なように）設定することができる
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/collaborate-pull-requests-azure-repos/5-knowledge-check)

## [モジュール4: Git フックを探索する](https://docs.microsoft.com/ja-jp/learn/modules/explore-git-hooks/)

- 講義: [Gitフック](mod04-05-git-hooks.md)
- ★[Gitフック](https://git-scm.com/book/ja/v2/Git-%E3%81%AE%E3%82%AB%E3%82%B9%E3%82%BF%E3%83%9E%E3%82%A4%E3%82%BA-Git-%E3%83%95%E3%83%83%E3%82%AF)の種類
  - post-checkout
  - pre-commit
  - post-commit
  - update
  - 他、多数
  - ※★pre-～,post-～というものはあるが、after-～というものはない
- ★Gitフックの利用例
  - ★[チームのチャット（Teams、Slack等）に通知を送信](https://softwarenote.info/p2488/)
  - ★コミットメッセージのチェック
    - ★commit-msgイベントにフックを設定
      - コミットメッセージが推奨される形式に従っていることを確認
      - ★[作業項目に関連付けられていることを確認](https://qiita.com/tbpgr/items/222030af9cc266f9781e)
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/explore-git-hooks/4-knowledge-check)

## [モジュール5: 内部ソースの推進を計画する](https://docs.microsoft.com/ja-jp/learn/modules/plan-fostering-inner-source/)

- 講義: [インナーソース（内部ソース）](mod04-06-inner-source.md)
- ★フォークとは
  - ★リポジトリのコピー
  - ★フォークの目安
    - ★小規模なチーム (2 から 5 人の開発者)での開発ではフォークせず、1つのリポジトリを使用
    - 中規模～大規模チームの場合はフォークを使用。
- ★[フォークの手順](https://docs.microsoft.com/ja-jp/azure/devops/repos/git/forks?view=azure-devops&tabs=visual-studio)
  - フォークを作成してローカルで複製
  - ローカルで変更を加えてブランチにプッシュ
  - アップストリームに PR を作成
  - フォークをアップストリームから最新版に同期
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/plan-fostering-inner-source/5-knowledge-check)

## [モジュール6: Git リポジトリの管理](https://docs.microsoft.com/ja-jp/learn/modules/manage-git-repositories/)

- 講義: [Gitリポジトリの運用](mod04-07-operating-git-repo.md)
- ★Git LFS
  - ★リポジトリで大規模なファイルを扱う場合に使用
- ★Gitリポジトリの履歴からのファイルの削除
  - ★削除が必要になる場合
    - 履歴を削除して、リポジトリのサイズを大幅に縮小する必要がある
    - 誤ってアップロードされた巨大なファイルを削除する
    - アップロードされるべきではなかった機密ファイルを削除する必要がある
    - ★※誤って機密ファイル等をアップロードした場合に「非表示にする」ことはできない
  - 方法
    - ★[git filter-branch](https://qiita.com/Spring_MT/items/f60c391b5dbf569a1d12)
    - BFG Repo-Cleaner
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/manage-git-repositories/4-knowledge-check)


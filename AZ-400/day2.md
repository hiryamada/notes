# ラーニングパスとモジュールの概要

- 2日目
  - ラーニングパス3: CI
    - モジュール1～6: Azure Pipelines
    - モジュール7～8: GitHub Actions
  - ラーニングパス4: CD その1

# 講義とハンズオン

- CI/CDの基礎
  - 講義: [DevOps のCI/CDパイプラインの概念](mod05-01-cicd.md)
- Azure Pipelines
  - 講義: [Azure Pipelines](mod05-02-azure-pipeline.md)
  - ハンズオン:[基本的なパイプライン](mod06-hands-on-basic-azure-pipeline.md)
  - ハンズオン:[基本的なWebアプリのデプロイ](mod06-hands-on-web-app-deploy.md)
  - 参考資料: [Azure Pipelines (YAMLパイプライン)の入門資料集](yaml-intro.md)
  - PDF資料: [基本的なWebアプリのデプロイ](pdf/Azure%20Pipelines%20web%20app%20deploy.pdf)
  - 講義: [エージェント](mod05-03-agent.md)
  - 講義: [エージェントプール](mod05-04-agent-pool.md)
  - 講義: [ジョブ](mod05-05-job.md)
  - ハンズオン:[複数のジョブ](mod06-hands-on-multiple-jobs.md)
  - 講義: [継続的インテグレーション(CI)](mod06-01-ci.md)
  - 講義: [ビルド戦略の実装](mod06-02-build.md)
  - 講義: [Azure Pipelinesとの統合(YAMLパイプライン詳細)](mod06-03-yaml.md)
  - ハンズオン:[ビルド・リリースパイプライン](mod06-hands-on-build-and-release-pipeline.md)
  - 講義: [外部ソース管理をAzure Pipelinesと統合する](mod06-04-scm-integration.md)
  - 講義: [セルフホステッド エージェントの設定](mod06-05-self-hosted-agent.md)
- GitHub Actions
  - 講義: [GitHub Actions](mod08.md)
  - ハンズオン: [基本的な使い方](mod08-handson-basic-github-actions.md)
  - ハンズオン: [App Serviceへのデプロイ](mod08-handson-deploy-to-azure-app-service.md)
  - ハンズオン: [発展](mod08-hands-on-options.md)


# [ラーニング パス3: Azure Pipelines と GitHub Actions での CI の実装](https://docs.microsoft.com/ja-jp/learn/paths/az-400-implement-ci-azure-pipelines-github-actions/)

## [モジュール1: Azure Pipelines について確認する](https://docs.microsoft.com/ja-jp/learn/modules/explore-azure-pipelines/)

- ★パイプラインの特徴
  - 信頼性が高い
  - 反復可能
  - ★変更が**できる**
- ★Azure Pipelines
  - ★（C#専用・デスクトップアプリ専用といったことなく）任意の言語・プラットフォームで利用できる
  - Azure DevOps Serverを使用することで、オンプレミスでも運用できる
- 継続的インテグレーション（CI）の利点
  - ★壊れたコードを出荷しないよう、ビルド・テストを自動化できる
  - ★※CIでは、コードのビルド・テストまで。
    - 運用環境にコードをデプロイするところまで自動化するものは「継続的デプロイ」（CD）と呼ばれる
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/explore-azure-pipelines/5-knowledge-check)

[モジュール2: Azure Pipelines エージェントとプールを管理する](https://docs.microsoft.com/ja-jp/learn/modules/manage-azure-pipeline-agents-pools/)

- ★エージェント
  - ★セルフホステッド
  - ★Microsoftホステッド
- ★エージェントプール
  - ★組織全体が対象範囲であり、組織内のプロジェクト間で共有できる。
- ★ロール
  - ★管理者
    - ★エージェントプールのすべてのロールのメンバーシップを管理できる
  - 共同作成者
  - ユーザー
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/manage-azure-pipeline-agents-pools/8-knowledge-check)

[モジュール3: パイプラインとコンカレンシーについて説明する](https://docs.microsoft.com/ja-jp/learn/modules/describe-pipelines-concurrency/)

- ★Azure Pipelineの定義
  - YAML（新）
  - ビジュアルデザイナー（旧）
  - ★※XMLは使用されない
- ★ビジュアルデザイナーのメリット
  - ★ビルド結果と同じハブ内にあり、切り替えや変更が簡単にできる
- ★YAMLのメリット
  - ★パイプラインの定義は、コードと共にバージョン管理される（コードと同じGitブランチに入る）
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/describe-pipelines-concurrency/7-knowledge-check)

[モジュール4: 継続的インテグレーションを調べる](https://docs.microsoft.com/ja-jp/learn/modules/explore-continuous-integration/)

- ★継続的インテグレーション（CI）の柱
  - バージョンコントロールシステム
  - 自動ビルドプロセス
  - ★※自動デプロイはCDであり、CIではない
- ★ビルドパイプラインの状態
  - ★一時停止
    - ★新しいビルド要求をキューに入れても、開始はされない
- ★ビルドプロパティ
  - ★ビルド番号の形式を変更することができる
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/explore-continuous-integration/6-knowledge-check)

[モジュール5: パイプライン戦略を実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-pipeline-strategy/)

- システム機能
  - Agent.ComputerName
  - Agent.OS
- ★ユーザー機能
  - ★ContosoApplication.Path など（システム機能で定義されていないもの）
- ★組織スコープ（組織レベル）では、使用できるようにする並列ジョブの数を構成できる
- ★YAMLパイプラインでサポートされているリポジトリの種類
  - Azure Repos Git
  - BitBucket Cloud
  - GitHub
  - GitHub Enterprise Server
  - ★※Azure Repos TFVC、その他のGitはサポート対象外
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-pipeline-strategy/5-knowledge-check)

[モジュール6: Azure Pipelines と統合する](https://docs.microsoft.com/ja-jp/learn/modules/integrate-azure-pipelines/)

- ステージ、ジョブ、タスク
- ★[依存関係: dependsOn](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml#dependencies)
  - 1 つのステージで複数のジョブを定義する場合、ジョブ間の依存関係を指定できる
- ★Azure Pipelines とそのエージェントの間の通信は、常にエージェント側から開始される
- ★エージェントの実行方式
  - サービス型
    - 自動化されたテストの実行など
  - ★対話型（対話モード）
    - ★人手によるUIテストの実行など
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/integrate-azure-pipelines/10-knowledge-check)

[モジュール7: GitHub Actions の概要](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-github-actions/)

- ★ジョブの実行
  - 複数のジョブは、デフォルトでは並列で実行される
  - ★[needsキーワード](https://docs.github.com/ja/enterprise-cloud@latest/actions/using-workflows/workflow-syntax-for-github-actions#jobs) を使用することで、ジョブ間の依存関係を指定できる
- ★セルフホステッド ランナー
  - エンタープライズ内の異なる複数のレベルで追加できる
    - エンタープライズ レベル (1 つのエンタープライズ全体に複数の組織)
    - 組織レベル (1 つの組織内に複数のリポジトリ)
    - リポジトリ レベル (単一リポジトリ) 
    - ★※「プロジェクトレベル」では追加できない
- ★ワークフローは `.github/workflows` に格納される
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-github-actions/10-knowledge-check)
  - ※（第1問については翻訳がおかしいので [英語版](https://docs.microsoft.com/en-us/learn/modules/introduction-to-github-actions/10-knowledge-check) を参照いただくか、下記訂正をご利用ください）
  - 第1問
    - 次のうち、あるジョブに別のジョブの完了を待機させるためのキーワードはどれですか。
      - 訂正:  ~~。~~ → `on`
      - 訂正:  ~~についても説明します。~~ → `needs`
      - `uses`

[モジュール8: GitHub Actions を使用した継続的インテグレーションについて学習する](https://docs.microsoft.com/ja-jp/learn/modules/learn-continuous-integration-github-actions/)

- ★「暗号化されたシークレット」
  - ★CI パイプラインで必要となるパスワード等を格納する場合に使用
- ★アクションのメタデータ
  - ★action.yml に格納される
- ★バッジ
  - ★リポジトリでのワークフローの状態を表示するために使用される
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/learn-continuous-integration-github-actions/10-knowledge-check)

# [ラーニング パス4: リリース戦略の設計と実装](https://docs.microsoft.com/ja-jp/learn/paths/az-400-design-implement-release-strategy/)

[モジュール1: 継続的デリバリーの概要](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-continuous-delivery/)

- ★継続的デリバリー(CD)とは
  - ★継続的なソフトウェアの開発と **提供（デリバリー）** を行うための一連のプロセス、ツール、および手法
  - 顧客により早く価値を届けるための仕組み。
    - （技術的には）1日に数回といったリリースも可能にする
    - CDが使われる以前は、リリースは人手で慎重に行い、数ヶ月～数年に1回というペースだった
  - 継続的インテグレーション（CD）との違い
    - ※CIは、ビルド・単体テストまで自動化。
    - ※CDは、ビルド・単体テストされた成果物をステージング環境や本番環境にデプロイするところまで自動化。
- ★フィードバック ループ
  - ★ソースの自動ビルド・単体テスト
  - ★テスト環境での自動テスト(E2Eテスト等)
  - サーバー上での監視
  - ※「Azure Boardとリポジトリの接続」をすることで、リポジトリでのコミットコメントに応じて、Azure Boardの作業項目を関連付ける・操作する（クローズにする）といったことができるが、これは「継続的デリバリー」における「フィードバックループ」には含まれない。
- Azure Pipelineの「リリースパイプライン」における「ステージ」「リリース」「デプロイ」「環境」
  - 「リリースパイプライン」
    - 少なくとも1つの「ステージ」が含まれる
    - 「ビルド」が完了すると「リリース」が作成される
    - 「リリース」の「デプロイ」方法
      - 「リリース」を自動的に「デプロイ」する
      - 「リリース」作成後、管理者が承認を行い、その後「デプロイ」する
    - 「デプロイ」は、VMやApp Serviceなどの「環境」に対して行われる
      - 「ステージング環境」・「本番環境」などの複数の「環境」を使用する場合は、複数の「ステージ」で表現する
      - 例
        - 「QAステージ」で「ステージング環境」に「デプロイ」する
        - 「QAステージ」のデプロイが成功したら、「Productionステージ」で「本番環境」に「デプロイ」する
  - [リリースとデプロイ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/release/releases?view=azure-devops)
  - ★リリース
    - CI/CD プロセスのリリース パイプラインで指定された、一連のバージョン付き成果物を含む、**パッケージまたはコンテナー**
  - ★デプロイ
    - ★1 つのステージのタスクを実行する **アクション** 。
    - ★ステージに指定された、テスト済みでデプロイ済みのアプリケーション（および他のアクティビティ）が作成される。
      - ※他のアクティビティ: デプロイ完了の通知など
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-continuous-delivery/6-knowledge-check)

[モジュール2: リリース戦略の推奨事項を確認する](https://docs.microsoft.com/ja-jp/learn/modules/explore-release-strategy-recommendations/)
- [リリース トリガー](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/release/triggers?view=azure-devops)
  - アプリケーションをデプロイする自動化ツール
  - トリガー条件が満たされると、パイプラインによって、指定した環境/ステージに成果物がデプロイされる。
    - [リリーストリガーの種類](https://docs.microsoft.com/ja-jp/learn/modules/explore-release-strategy-recommendations/8-understand-delivery-cadence-three-types-of-triggers)
      - 「手動トリガー」: 担当者が手作業でリリースを開始
      - 「スケジュールされたトリガー」: 特定の時刻にリリースを開始。
      - 「継続的デプロイ（継続的配置）トリガー」: 別のイベントによってリリースを開始。
      - ★※「機能トリガー」は「リリーストリガー」ではない。
- リリースゲート
  - デプロイ パイプラインの開始と完了をさらに制御
  - セキュリティ テスト ツールでコンプライアンスの問題が検出された場合に Azure DevOps でのデプロイを防ぐ など。
- 作業項目
- 手動トリガー
- ステージ
  - リリース パイプラインの論理的な境界
  - パイプラインを一時停止してさまざまなチェックを実行できる
- トリガー
- 品質ゲート
- 知識チェック

[モジュール3: 高品質なリリース パイプラインの構築](https://docs.microsoft.com/ja-jp/learn/modules/build-high-quality-release-pipeline/)

- リリース プロセス
  - プロセスであるため、品質を直接測定することはできない
- リリース ノート
  - 顧客にリリースされた情報を伝達する必要がある場合に不可欠
- リリース管理ツール
  - Azure Pipeline
  - Jenkins
  - ※Azure Reposはソース管理ツール
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/build-high-quality-release-pipeline/8-knowledge-check)

[モジュール4: デプロイ パターンの概要](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-deployment-patterns/)

- マイクロサービス
  - 自律的で、独立してデプロイできる、スケーラブルなソフトウェア コンポーネント
  - あるマイクロサービスの仕様の変更が、それを使用する他のマイクロサービスに影響を与えてはならない
    - つまり、APIを変更してはならない
- （マイクロサービス以前の）従来型のデプロイパターン
  - 開発、テスト、ステージング、運用
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-deployment-patterns/5-knowledge-check)

[モジュール5: ブルーグリーン デプロイとフィーチャー トグルの実装](https://docs.microsoft.com/ja-jp/learn/modules/implement-blue-green-deployment-feature-toggles/)

- App Serviceのデプロイスロット
  - ブルーグリーンデプロイ
    - デプロイスロットとして本番環境スロットとステージングスロットを利用
    - スワップ
  - A/Bテスト
    - デプロイスロットとして「A」と「B」の2パターンを利用
    - 「A」に60%、「B」に40%のトラフィックを流すといったように、各スロットにアクセスする割合を指定できる
- App Configurationの機能フラグ
  - 新しく追加した機能の有効・無効を切り替えることができる
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-blue-green-deployment-feature-toggles/7-knowledge-check)

[モジュール6: カナリア リリースとダーク ローンチを実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-canary-releases-dark-launching/)

- [Azure Traffic Manager](https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-overview)
  - Webトラフィックの一部を新しいバージョンのWebサイトへ転送できる（[荷重トラフィックルーティング](https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-routing-methods#weighted-traffic-routing-method)）
  - ※Azure Load Balancer、Azure Application Gatewayは、到着したトラフィックをバックエンドに負荷分散することができるが、一定の割合のトラフィックを別のWebサイトに転送する機能はない。
- カナリア デプロイ（「カナリア」ユーザー）
  - ユーザーが、問題に対して許容できることが必要（問題があっても新機能を使いたいといったようなユーザー向け）
- ダークローンチ（機能フラグ、フィーチャーフラグとも）
  - フロントエンド（ユーザーが直接触れることができる機能）に対する反応を調べるために使用する
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-canary-releases-dark-launching/5-knowledge-check)

[モジュール7: A/B テストと段階的公開型デプロイを実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-test-progressive-exposure-deployment/)

- ★段階的公開デプロイ（Progressive Exposure deployment）
  - 「リングベース デプロイ（ring-based deployment）」とも
  - 中央のリング、その外側のリング、全ユーザーのリング、・・といった順で、新機能をデプロイしていく
  - 実質的に「カナリアリリース（Canary Release）」に近い。
    - ★（カナリアリリースの「拡張版」といえる）
- A/Bテスト（A/B testing）
  - 1 つの Web ページまたはアプリの 2 つのバージョンを公開
    - どちらのバージョンが適している（より収益を上げるか・コンバージョンレートが高いか等）かを判断
  - ★「分割テスト（Split testing）」「バケットテスト（Bucket testing）」とも呼ばれる
  - ★継続的デリバリーの一部または前提条件ではない
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-test-progressive-exposure-deployment/5-knowledge-check)

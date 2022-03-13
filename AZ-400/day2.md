- 2日目
  - ラーニングパス3: CI
    - モジュール1～5: Azure Pipelines
    - モジュール6～7: GitHub Actions
  - ラーニングパス4: CD その1

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
  - ※（第1問については翻訳がおかしいので [英語版](https://docs.microsoft.com/en-us/learn/modules/introduction-to-github-actions/10-knowledge-check) を参照してください）
  - 第1問
    - 次のうち、あるジョブに別のジョブの完了を待機させるためのキーワードはどれですか。
      - ~~。~~ → `on`
      - ~~についても説明します。~~ → `needs`
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

- 知識チェック

[モジュール2: リリース戦略の推奨事項を確認する](https://docs.microsoft.com/ja-jp/learn/modules/explore-release-strategy-recommendations/)

- 知識チェック

[モジュール3: 高品質なリリース パイプラインの構築](https://docs.microsoft.com/ja-jp/learn/modules/build-high-quality-release-pipeline/)

- 知識チェック

[モジュール4: デプロイ パターンの概要](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-deployment-patterns/)

- 知識チェック

[モジュール5: ブルーグリーン デプロイとフィーチャー トグルの実装](https://docs.microsoft.com/ja-jp/learn/modules/implement-blue-green-deployment-feature-toggles/)

- 知識チェック

[モジュール6: カナリア リリースとダーク ローンチを実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-canary-releases-dark-launching/)

- 知識チェック

[モジュール7: A/B テストと段階的公開型デプロイを実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-test-progressive-exposure-deployment/)

- 知識チェック

# モジュール10: リリース戦略の設計

モジュール説明前の注意：モジュール10, 11では、再びパイプライン（Azure Pipeline）の話題に戻り、継続的デリバリー(CD)やデプロイについて解説していく。

[モジュール5](mod05.md)で解説したように、Azure Pipelinesでは、「YAML」と「クラシック」と呼ばれる2種類のパイプラインを利用できる。

[2019年9月10日より、YAMLパイプラインが利用可能になり](https://docs.microsoft.com/ja-jp/azure/devops/release-notes/2018/sep-10-azure-devops-launch#configure-builds-using-yaml)、それまでのGUIで設定するパイプラインは「クラシック」と呼ばれるようになった。

- [クラシック](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops#define-pipelines-using-the-classic-interface)
  - ビジュアルデザイナー（GUI）で編集できる
  - **ビルドパイプライン**
  - **リリースパイプライン**
- [YAML](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/get-started/pipelines-get-started?view=azure-devops#define-pipelines-using-yaml-syntax)(azure-pipelines.yml)
  - YAMLファイルを使用してパイプラインを定義
  - YAMLファイルは、コードと一緒に、リポジトリに格納できる

上記のように、「クラシック」のパイプラインでは、「**ビルドパイプライン**」と「**リリースパイプライン**」という2種類のパイプラインを組み合わせていた。一方、新しい「YAML」のパイプラインでは、「**ビルドパイプライン**」と「**リリースパイプライン**」といった区別はなく、一つのパイプラインの中でビルドとリリースを実行するようになった。

[2020/6現時点で、クラシックパイプラインは、廃止になる予定はないが、Azure Pipelinesの新機能はYAMLパイプラインに先に追加されるとされている](https://github.com/MicrosoftDocs/azure-devops-docs/issues/6828)。実際、「[コンテナージョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/container-phases?view=azure-devops)
」や「[テンプレート](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/templates?view=azure-devops)」といったいくつかの便利な機能は、YAMLパイプラインでしか利用できない。

クラシックのパイプラインは[YAMLパイプラインに移行](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/migrate/from-classic-pipelines?view=azure-devops)することができる。

これらのことから、**新規のプロジェクトでは、YAMLパイプラインを使用すべき**と思われる。

以上の理由により、以降、本資料では、Azure Pipelineについて取り上げる場合、**「クラシック」のパイプラインの説明は省略し**、新しい「YAML」のパイプラインだけを説明する。

## 継続的デリバリーの紹介

### 従来の IT 開発サイクル

■DevOps以前の、**サイロ化**した「部門」

- 開発部門（Dev）
  - 顧客に新たな価値（新機能）を届けることを望む。
- 運用部門（Ops）※Skillpipe資料では「IT(-Pro)部門」と表記
  - 変化はリスクと考える。
  - 安定した運用を望む。

「[サイロ化](https://www.itmedia.co.jp/im/articles/0609/30/news018.html)」は、部門が縦割りになっていて、適切な連携ができていない状態。

■DevOps以前の開発スタイル：「サイロベース開発」

※Skillpipe資料では「サイロベースの開発」という言葉が登場する（一般的なIT用語ではない模様）。これは、サイロ化された部門にまたがって、ソフトウェアを開発・運用することの困難さを表している。

※Skillpipe資料で「値」と書いてあるものは、顧客に届けられる「価値」（Value）のこと。

たくさんの変更を一度にリリースするには時間がかかり、顧客に届けられる「価値」は少なくなる。

### 継続的デリバリーへの移行

※Skillpipe資料で「大理石」「緑と赤のコンセント」と言っている部分は意味不明。図が欠落しているものと思われる。要するに、ここでは、顧客に、**継続的に「価値」を届ける**必要がある、ということを説明している。

- ソフトウェア開発プラクティスを改善する優れた方法は、[スクラム開発](https://ja.wikipedia.org/wiki/%E3%82%B9%E3%82%AF%E3%83%A9%E3%83%A0_(%E3%82%BD%E3%83%95%E3%83%88%E3%82%A6%E3%82%A7%E3%82%A2%E9%96%8B%E7%99%BA))の導入である。
- スクラム開発では、多くのチームが 2 週間または 3 週間でスプリントを実行する。
  - [スプリント](https://ja.wikipedia.org/wiki/%E3%82%B9%E3%82%AF%E3%83%A9%E3%83%A0_(%E3%82%BD%E3%83%95%E3%83%88%E3%82%A6%E3%82%A7%E3%82%A2%E9%96%8B%E7%99%BA))ごとに、新しい「価値」（新機能など）がリリースされる。
- ソフトウェアの開発ではなく、動作ソフトウェアのデリバリーが**ボトルネック**（制約）となってくる。
- ボトルネックを解消するには、継続的デリバリーが必要である。

※スプリント：スクラムでは開発プロジェクトを数週間程度の短期間ごとに区切り、その期間内に分析、設計、実装、テストの一連の活動を行い、一部分の機能を完成させるという作業を繰り返しながら、段階的に動作可能なシステムを作り上げる。スクラム開発における反復の単位を「スプリント」という。

### 継続的デリバリーとは

■継続的デリバリーとは。

継続的デリバリー (CD) は、ソフトウェアの迅速かつ信頼性の高い継続的な開発と提供のための一連のプロセス、ツール、および技術。

継続的デリバリー（CD）の8個の原則

- デプロイのプロセスは繰り返し可能で信頼性が高い必要がある
  - 組織でノウハウを蓄積・共有
  - オンプレミスのCI/CDサーバーは、可用性や性能が問題になりやすい
    - クラウドのSaaS型CI/CDへの移行
- すべてを自動化する
- 困難なことはより頻繁に実行する 
  - (If something is difficult or painful, do it more often.)
  - 問題を小さな塊に分割する
  - すべてを一度に解決しようとせず、少しずつ解決していく
- すべてをソース管理に保管する
  - パイプラインの設定ファイル「azure-pipelines.yml」
  - インフラの定義ファイル（ARMテンプレート等）
- デリバリーは「リリース」を持って完了とする
  - 価値を「継続的に」提供することを目指す
- 品質を構築する
  - 後付けで品質を考えるのではなく、初めから品質を計画し、「作り込み」します。
- リリースプロセスに対してチーム全員が責任を持つ
- 継続的に改善する


■継続的デプロイメントとは。

CI/CDで、エンドユーザーに対して新機能をリリースすることを[継続的デプロイ（継続的デプロイメント）](https://azure.microsoft.com/ja-jp/overview/continuous-delivery-vs-continuous-deployment/)と呼ぶ場合もある。

- 継続的デリバリー
  - エンドユーザーに対する新機能のリリースを自動的には行わない
  - 手動でトリガーする（担当者が「承認」を行う）
  - 特定の「リリース日」がある
- 継続的デプロイ
  - 継続的デリバリーよりもさらに自動化が進んだ状態
  - エンドユーザーに対する新機能のリリースを自動的に行う
  - プロセス全体を自動化
  - 「リリース日」はない（エンドユーザーが使うソフトウェアが勝手に最新化されていく）

### リリースとデプロイ

**「クラシック」のパイプラインの説明となるが、概要のみ説明**

[リリースとデプロイ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/release/releases?view=azure-devops)

- リリース
  - CI/CD パイプラインで指定された成果物のバージョン管理されたセットを保持する構造
  - 1つのパイプラインで複数のリリースが作られる場合がある
  - 指定された期間、Azure Pipelinesに保持される
- デプロイ
  - デプロイ は、自動テストの実行、ビルド成果物の配置、そのステージに対して指定されている他のすべてのアクションなど、1つのステージのタスクを実行するアクション

リリースのあとにデプロイがある。

### ディスカッション: 組織における継続的デリバリーの必要性

講師（山田）は継続的デリバリーについて、昔、開発案件にて、デプロイによるダウンタイムを抑えながら、運用環境を最新化するため、[AWS CodePipeline](https://aws.amazon.com/jp/codepipeline/)を使用していました。複数のEC2インスタンス（仮想サーバー）に対するローリングデプロイを構成したことがあります。複数の仮想サーバーに対して、一度にデプロイするのではなく、少しずつ仮想サーバーを更新していく方法です。なお、[同様の機能はAzure Pipelinesにも存在します](https://docs.microsoft.com/ja-jp/azure/virtual-machines/linux/tutorial-devops-azure-pipelines-classic)。みなさんはいかがですか？

なにか思い出や教訓などがございましたら、ぜひチャットに書き込んでください。

## リリース戦略の推奨事項

**「クラシック」のパイプラインの説明のため、本節は省略**

参考：[チュートリアル:Azure DevOps Services と Azure Pipelines を使用して Azure の Linux 仮想マシンにアプリをデプロイする](https://docs.microsoft.com/ja-jp/azure/virtual-machines/linux/tutorial-build-deploy-azure-pipelines?tabs=java)

大まかな流れは以下の通り。

- Azure Pipelinesの「環境」を作る
- 環境にVMを加える
- Azure PipelinesのYAMLに[デプロイ ジョブ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/deployment-jobs?view=azure-devops)を追加する
- パイプラインが実行されると、環境のVMにデプロイが行われる
- 環境のデプロイ履歴で、デプロイの結果を確認できる。

参考：[Azure PipelinesでYAMLを使って仮想マシンにアプリケーションをデプロイする](https://tsuna-can.hateblo.jp/entry/2020/01/19/011155)

- 環境へのVM登録時、Azure Pipelinesで発行されるスクリプトをVMで実行する
- この例では[「RunOnce」デプロイ戦略](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/deployment-jobs?view=azure-devops&preserve-view=true#runonce-deployment-strategy)を使って、環境のすべてのVMに対し一度にデプロイを行っている。
  - Azure Pipelinesのデプロイジョブでは、他に、[ローリングデプロイ戦略](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/deployment-jobs?view=azure-devops&preserve-view=true#rolling-deployment-strategy)、[カナリアデプロイ戦略](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/deployment-jobs?view=azure-devops&preserve-view=true#canary-deployment-strategy)を使用することもできる。

## 高品質のリリース パイプラインの構築

**「クラシック」のパイプラインの説明のため、本節は省略**

なお、YAMLパイプラインでは「ステージ」を使用して、ジョブを分割したり、ステージ間の依存関係を指定したり、ステージから別のステージに進むための条件を指定したりすることができる。[マニュアル](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/stages?view=azure-devops&tabs=yaml)（画面内で「YAML」タブを選択してください）

人による承認をはさんでデプロイを行う場合は[承認](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/approvals?view=azure-devops&tabs=check-pass)の機能を利用する。承認はYAMLファイル（ステージ）には定義されない。

## 適切なリリース管理ツールの選択

リリースを関係者に連携する方法がいくつかある。

- ドキュメントストア
  - OneDrive等
- Wiki
- コードベース
  - リリース内のChangelog.md等
- Azure DevOpsの「作業項目」として保存する
- [リリースノートを生成する拡張機能](https://marketplace.visualstudio.com/items?itemName=richardfennellBM.BM-VSTS-XplatGenerateReleaseNotes)

### リリース管理ツールの選択に関する考慮事項

- 成果物（アーティファクト）との連携
  - Azure DevOpsでは、Azure Pipelinesで生成した成果物をAzure Artifactsに格納できる。
- トリガー
  - Azure DevOpsでは、コマンドからのパイプライン起動、Azure Repos等のリポジトリへのプッシュやプルリクエストによるパイプライン起動、定期的なパイプライン起動などをトリガーとして使用できる
- 承認
  - Azure DevOpsでは、ステージの実行に[承認](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/approvals?view=azure-devops&tabs=check-pass)を設けることができる。
- ステージ
  - Azure DevOpsでは、[複数のステージ](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/stages?view=azure-devops&tabs=yaml)を利用することができる。
    - アプリをビルドする
    - テストを実行する
    - デプロイする
    - などのステージに構成できる
    - ステージから次のステージへ進むための条件を設定することができる


### 一般的なリリース管理ツール

- Azure Pipelines
- Jenkins
- Circle CI
- GitLab
- など

## ラボ

**「クラシック」のパイプラインの説明のため、本節は省略**

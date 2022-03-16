- 3日目
  - ラーニングパス1 補足 Azure Boards
  - ラーニングパス5: CD その2
    - モジュール1～4: Azure Pipelines リリースパイプライン
    - モジュール5: セキュリティ
    - モジュール6: Key Vault
    - モジュール7: 認証、アプリの登録、マネージドID
    - モジュール8: App Configuration
  - ラーニングパス6: IaC
    - モジュール1: IaCと構成管理
    - モジュール2: ARM
    - モジュール3: Azure CLI
    - モジュール4: Aure Automation
    - モジュール5: DSC
    - モジュール6: Chef, Puppet
    - モジュール7: Ansible
    - モジュール8: Terraform

# 講義とハンズオン

- 講義: [Azure Boards](mod01-09-azure-board.md)
- ハンズオン: [Azure Boards](mod01-14-handson-board.md)
- 講義: [セキュリティの設計](mod07-01-security.md)
- 講義: [設定値や機密情報の扱い方](mod07-02-configuration.md)
- 講義: [インフラストラクチャと構成の管理(IaC)](mod13.md)
- 講義: [Chef/Puppet/Ansible/Terraform](mod14.md)
- ハンズオン: [Ansible](mod14-handson-ansible.md)
- ハンズオン: [Terraform](mod14-handson-terraform.md)

# [ラーニング パス5: Azure Pipelines を使用して、セキュリティで保護された継続的配置を実装する](https://docs.microsoft.com/ja-jp/learn/paths/az-400-implement-secure-continuous-deployment/)

## [モジュール1: リリース パイプラインを作成する](https://docs.microsoft.com/ja-jp/learn/modules/create-release-pipeline-devops/)

- [実行できるジョブの種類](https://docs.microsoft.com/ja-jp/learn/modules/create-release-pipeline-devops/5-explore-multi-configuration-multi-agent)
  - 複数構成 - [（ドキュメント）](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/process/phases?view=azure-devops&tabs=yaml#multi-job-configuration)
  - 複数エージェント
    - 指定された数のエージェントを使用して、複数エージェントで同じタスクのセットを実行
  - なし
- エージェントでは同時に 1 つのジョブのみを実行できる
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/create-release-pipeline-devops/6-knowledge-check)

## [モジュール2: 環境の構成とプロビジョニング](https://docs.microsoft.com/ja-jp/learn/modules/configure-provision-environments/)

- サーバーを構成するためのテクノロジやツール
  - DSC (Desired State Configuration)
  - Chef
  - ※Azure App Configurationは、サーバー構成ツールではない
- サービスコネクション（サービス接続）
  - パイプラインから、リソース（App Service等）にアクセスする場合に使用
  - 事前に構成し、名前を付け、パイプラインでその名前を指定して使用する
  - 「サービスプリンシパル」を使用した認証が推奨される
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-provision-environments/7-knowledge-check)

## [モジュール3: タスクとテンプレートを管理してモジュール化する](https://docs.microsoft.com/ja-jp/learn/modules/manage-modularize-tasks-templates/)

- カスタム ビルド
- リリース タスク
- 変数グループ
  - 複数のビルドとリリース パイプラインで使用できるようにする値を格納する
- 独自のタスクを作成する利点
  - 組織全体に安全かつ効率的に配布dケイル
  - ターゲット サーバーへのセキュリティで保護されたエンドポイントを使用できる
  - ユーザーに、実装の詳細を表示**しなくてよい**
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/manage-modularize-tasks-templates/8-knowledge-check)

## [モジュール4: 正常性の検査を自動化する](https://docs.microsoft.com/ja-jp/learn/modules/automate-inspection-health/)

- [リリースゲート](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/release/approvals/?view=azure-devops)
  - 外部サービスから正常性シグナルを自動的に収集
  - すべてのシグナルが同時に成功した場合にリリースしたり、タイムアウトでデプロイを停止したりすることができる
- [イベント](https://docs.microsoft.com/ja-jp/azure/devops/notifications/concepts-events-and-notifications?view=azure-devops)
  - 特定のアクション（リリースの開始時やビルドの完了時）に生成される
- [通知](https://docs.microsoft.com/ja-jp/azure/devops/notifications/oob-built-in-notifications?view=azure-devops)
  - サブスクライブしているイベントが発生した際に、電子メールで受信
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/automate-inspection-health/6-knowledge-check)

## [モジュール5: セキュリティ開発プロセスの概要](https://docs.microsoft.com/ja-jp/learn/modules/introduction-security-development-process/)

- SQLインジェクション
- Microsoft セキュリティ開発ライフサイクル (SDL)
  - 脅威のモデリング
    - 脅威のモデリングの 5 つのステップ
      - セキュリティ要件の定義
      - アプリケーション ダイアグラムの作成
      - 脅威の特定
      - 脅威の軽減
      - 脅威の軽減が行われたことの検証
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/introduction-security-development-process/7-knowledge-check)

## [モジュール6: アプリケーション構成データを管理する](https://docs.microsoft.com/ja-jp/learn/modules/manage-application-configuration-data/)

- [構成（Key Vault？App Configuration？）の利用者の分類](https://docs.microsoft.com/ja-jp/learn/modules/manage-application-configuration-data/3-explore-separation-of-concerns)（？）（知識チェックに出題されているが、これらはRBACのロールでもなく、Key VaultやApp Configurationの用語でもない。一般的に「構成を行う側」「その構成を読み取って利用する側」という、システム運営上の役割が考えられる、という概念を説明するものと思われる。暗記する必要はないと思われる）
  - 構成管理人(Configuration custodian)
    - 構成値の生成とライフ サイクルの保守を担当
  - 構成コンシューマー(Configuration consumer)
    - 構成値を利用
  - 開発者
- Azure Key Vault
  - アプリケーションが使用するシークレットを一元管理
  - アプリケーションがシークレットを直接管理する必要がない
  - シークレットのセキュリティとコントロールを向上させる
  - Azure Key Vaultが管理するもの
    - シークレット
    - キー
    - 証明書
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/manage-application-configuration-data/8-knowledge-check)

## [モジュール7: ID 管理システムと統合する](https://docs.microsoft.com/ja-jp/learn/modules/integrate-identity-management-systems/)

- シングルサインオン（SSO） を使用するには、ID プロバイダーを **組織レベル** で GitHub に接続する必要がある
- Azure ADテナントに登録したアプリを利用できるユーザー
  - アプリを「シングルテナント」として登録した場合
    - 同じテナント（組織）内のAzure ADユーザー
  - アプリを「マルチテナント」として登録した場合
    - 任意のテナント（組織）内のAzure ADユーザーとMicrosoftアカウント
    - または
    - Microsoftアカウントのみ
  - ※Azure DevOpsグループのユーザーは無関係
- マネージドIDの種類
  - システム割り当てマネージドID
  - ユーザー割り当てマネージドID
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/integrate-identity-management-systems/5-knowledge-check)

## [モジュール8: アプリケーション構成を実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-application-configuration/)

- Azure App Configuration
  - 構成データの管理を一元化
  - アプリケーションを再デプロイしたり再起動したりせずに、アプリケーションの設定を動的に変更できる
  - ※パッケージ管理はApp Configurationの機能ではない
  - キーの名前付けの方法
    - フラット
      - 「sales=true」のように「:」を使わずにキー名をつける
    - 階層的
      - 「password:minlength=8」のように「:」を使って階層的なキー名をつける
    - ※「クロスキー」という名前付け方法はない
- 「構成フラグ」に関連するコンポーネント
  - 「構成フラグ」を設定する「App Configuration」
  - 「App Configuration」から「構成フラグ」を読み取って使用するアプリケーション
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-application-configuration/5-knowledge-check)

# [ラーニング パス6: Azure、DSC、サードパーティ製ツールを使用したインフラストラクチャのコード化の管理](https://docs.microsoft.com/ja-jp/learn/paths/az-400-manage-infrastructure-as-code-using-azure/)

## [モジュール1: コードとしてのインフラストラクチャと構成管理を調べる](https://docs.microsoft.com/ja-jp/learn/modules/explore-infrastructure-code-configuration-management/)

- IaCのアプローチ
  - 命令型
  - 宣言型
  - ※「感嘆型」というものはない
- 「べき等」（idempodent）
  - リソースの作成といった操作を1回実行しても複数回実行しても同じ結果が得られる（リソースが作成される）に収束するという考え方
- IaCのメリット
  - 必要に応じていつでもリソースを作成（プロビジョニング）・削除できる（オンデマンド）
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/explore-infrastructure-code-configuration-management/6-knowledge-check)

## [モジュール2: Azure Resource Manager テンプレートを使用して Azure リソースを作成する](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resources-using-azure-resource-manager-templates/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resources-using-azure-resource-manager-templates/7-knowledge-check)

## [モジュール3: Azure CLI を使用して Azure リソースを作成する](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resources-by-using-azure-cli/)


- ARM テンプレートのデプロイモード
  - 増分
  - 完全
  - ※「トランザクション」「検証」といったモードはない
- [ARMテンプレートのセクション](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/syntax#template-format)
  - $schema
  - contentVersion
  - apiProfile
  - parameters
  - variables
  - functions
  - resources
  - outputs
  - ※「シークレット」というものはない
- dependsOn
  - あるリソース（の作成）が、別のリソース（の作成）に依存するということを指定
  - リソースの作成順を定義する
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resources-by-using-azure-cli/5-knowledge-check)

## [モジュール4: DevOps での Azure Automation を探索する](https://docs.microsoft.com/ja-jp/learn/modules/explore-azure-automation-devops/)

- Runbookの作成方法
  - Runbookギャラリー
  - Runbookの作成/インポート
  - ※Azure Artifactはパッケージ管理の仕組みでありRunbookとは無関係
- Runbookでサポートされているソース管理
  - Azure DevOps
  - GitHub
  - ※Bitbucketは対象外
- 「[PowerShellワークフロー](https://docs.microsoft.com/ja-jp/system-center/sma/overview-powershell-workflows?view=sc-sma-2019#basic-structure)」の最初のキーワード
  - `Workflow`
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/explore-azure-automation-devops/12-knowledge-check)

## [モジュール5: Desired State Configuration (DSC) を実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-desired-state-configuration-dsc/)

- [構成ドリフト](https://www.google.com/search?q=%E6%A7%8B%E6%88%90%E3%83%89%E3%83%AA%E3%83%95%E3%83%88)（構成のずれ）
  - 元のデプロイ状態（テンプレート）から構成がずれる（変更される）こと
- DSCの主要なコンポーネント
  - 構成
  - リソース
  - [ローカル構成マネージャ（LCM）](https://github.com/OpenLocalizationOrg/PowerShell-Docs.ja-jp/blob/master/dsc/metaConfig.md)
- [DSCのモード](https://www.infoq.com/jp/news/2014/01/powershell-dsc-push-and-pull/)
  - プルモード
  - プッシュモード
  - ※フェッチモードというものはない
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-desired-state-configuration-dsc/10-knowledge-check)

## [モジュール6: Chef と Puppet の概要](https://docs.microsoft.com/ja-jp/learn/modules/introduction-chef-puppet/)

- ★Chefのコンポーネント
  - Chefサーバー
  - Chefクライアント
  - Chefワークステーション
  - ★Knife（Chefクライアント管理用のコマンド）
  - ★※「Chefファクト」というものはない
- ★Chef Automate
  - Azure Marketplaceからイメージを入手できる
  - HabitatとInSpecが含まれる
  - ★※Console Servicesは含まれない
- ★[Puppet](https://docs.oracle.com/cd/E62101_01/html/E77933/gqqvw.html)
  - ★Puppet Master
    - ★エージェント カタログを作成するためのコードのコンパイルを担当
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/introduction-chef-puppet/9-knowledge-check)

## [モジュール7: Ansible を実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-ansible/)

- Ansible
  - エージェントレス
  - Pythonを使用
  - [制御マシン](https://www.finddevguides.com/Ansible-environment-setup)
    - Ansible構成が実行されるマシン
- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-ansible/10-knowledge-check)

## [モジュール8: Terraform を実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-terraform/)

- [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-terraform/9-knowledge-check)


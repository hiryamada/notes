# AZ-400 学習内容の振り返り

※わかりやすいように分野別に整理しています

■DevOpsと周辺技術

- 概要
  - DevOpsの定義
  - SOR/SOE、グリーン/ブラウンプロジェクト
  - カナリア、アーリーアダプター
  - 技術的負債、コードの臭い
- アジャイルソフトウェア開発
  - かんばんボード
  - Wiki
- バージョン管理
  - Git
  - リポジトリ、ブランチ、フック
  - インポート、クローン、フォーク、プルリクエスト
  - インナーソース
- CI/CD
  - パイプライン
  - ビルド、ビルド番号、セマンティックバージョニング、変更ログ
  - リリース、機能フラグ
- IaC
  - Chef/Puppet/Ansible/Terraform
  - ARMテンプレート、Bicep
- セキュリティ
  - DevSecOps
  - Microsoft SDL
  - 脅威モデリング, TMT
- コンテナー型仮想化
  - Docker
  - Kubernetes
- 依存関係（パッケージ）管理
- 継続的フィードバック
- サイト信頼性エンジニアリング
- ブレイムレス レトロスペクティブ
- オープンソースソフトウェア、ライセンス
- 静的コード解析、脆弱性調査

■Azure DevOps Service

- 概要
  - Azure DevOps ServiceとAzure DevOps Server
  - 組織とプロジェクト
  - 料金
  - ユーザーの追加
- Azure DevOps Serviceに含まれるサービス
  - Azure Repos
  - Azure Boards
  - Azure Pipelines
	- YAMLパイプラインとクラシックパイプライン
	- エージェント
	- ステージ、ジョブ、ステップ（スクリプトとタスク）
	- 環境
  - Azure Artifacts
  - Azure Test Plans (試験範囲外)
  - 拡張機能 Marketplace

■GitHub

- GitHubとMicrosoftの関係（買収、今後、Azure DevOpsとの関係）
- Azure DevOps Serviceとの比較
- リポジトリ
- Issues
- GitHub Actions
- Wiki
- GitHub Packages
- GitHub Codespaces

■Azure / マイクロソフトのサービス

- App Service
- Key Vault（シークレット・キー・証明書）
- App Configuration（構成、機能フラグ、Key Vault参照）
- 認証と承認（Azure AD認証、ロールによる承認）
- Azure AD（ユーザー、グループ、サービスプリンシパル、マネージドID）
- Azure Automation - Runbook / State Configuration / Update Management
- Azure Kubernetes Service
- Azure Monitor / Log Analytics / Application Insights
- Visual Studio App Center

■サードパーティのサービスとツール（特に重要なもの）

- Git
- SonarCloud
- Mend Bolt
- GitHub Dependabot
- CodeQL
- OWASP ZAP
- Nexus
- Artifactory
- Apache Archiva
- Docker
- Kubernetes

■プログラミング言語と関連ツール

- .NET(C#), NuGet
- Java, Ant, Maven, Gradle
- JavaScript, npm
- Python, pip

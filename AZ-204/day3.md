# 3日目

- ラーニングパス 5: IaaS (VM, ACI, ACR)
- ラーニングパス 6: ユーザー認証（Azure AD, Microsoft Graph）

# ラーニングパス: AZ-204: サービスとしてのインフラストラクチャ ソリューションを実装する

https://docs.microsoft.com/ja-jp/learn/paths/az-204-implement-iaas-solutions/

■モジュール: Azure で仮想マシンをプロビジョニングする

- ★仮想マシンの種類 https://azure.microsoft.com/ja-jp/pricing/details/virtual-machines/series/
  - ★汎用（General Purpose）: Av2 シリーズ、Dv5 シリーズなど。★開発・テストにもおすすめ。
  - コンピューティング最適化: Fsv2 シリーズ、FX シリーズなど
  - ストレージ最適化: Lsv2 シリーズなど
- ★可用性セットとは？ https://docs.microsoft.com/ja-jp/azure/virtual-machines/availability-set-overview
  - ★データセンター内の、VMの論理的なグループ
  - 可用性を向上させる。単一VMのSLA 99.9% -> 可用性セットのVMのSLA 99.95%
  - 可用性セットの簡単な作り方
    - 可用性セットを作る
    - 仮想マシンの起動時に、可用性セットを指定する
  - 可用性セットの実際の使い方
    - 可用性セットの中に2台以上のVMを入れる
    - Web, AP等のレイヤーごとにセットを作成する
- Azure CLIを使った仮想マシンの作成 https://docs.microsoft.com/ja-jp/azure/virtual-machines/windows/quick-create-cli
  - az vm create
- 知識チェック: 仮想マシンの種類 / 可用性セット

■モジュール: Azure Resource Manager テンプレートを作成してデプロイする

- ARMテンプレートとは？ https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/overview
  - JSONによるAzureリソース定義
  - たくさんのリソースをまとめて定義、デプロイできるので便利
  - 人手によるデプロイにくらべて正確・高速
  - テンプレートをGit等でバージョン管理できる
  - Visual Studio Code等で作成する
- テンプレートのセクション
  - resourcesセクション
  - outputセクション https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/template-tutorial-add-outputs?tabs=azure-powershell
- デプロイモードとは？ https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/deployment-modes
  - 増分（incremental）
  - 完全（complete, 知識チェックでは「完了」）
- 知識チェック: outputセクション / デプロイモード

■（前知識）コンテナー型仮想化

- Dockerとは？ https://docs.microsoft.com/ja-jp/dotnet/architecture/microservices/container-docker-introduction/
  - コンテナー型の仮想化を提供するソフトウェア
  - サーバー仮想化よりも「軽い」「速い」「可搬性が高い」「高密度で運用できる」
  - Dockerエンジン https://thinkit.co.jp/story/2015/07/29/5382
  - dockerコマンド https://docs.docker.jp/engine/reference/commandline/index.html
  - Dockerfile https://docs.docker.jp/get-started/part2.html#id11
  - ★.NETコンテナーのDockerfile
  - イメージ, コンテナー https://hacknote.jp/archives/56650/
- レジストリとは？
  - Dockerイメージを格納するサービス
  - Docker Hub https://hub.docker.com/
  - プル: イメージの取り出し - docker pull
  - プッシュ: イメージの格納 - docker push
- デモ: .NETアプリをDockerコンテナー化する

■モジュール: Azure Container Registry (ACR) でコンテナー イメージを管理する

- Azure Container Registryとは？ https://docs.microsoft.com/ja-jp/azure/container-registry/container-registry-intro
  - Azure内で運用できる、プライベートなレジストリ
  - プロジェクト関係者などにアクセスを限定できる
  - Dockerイメージのビルド機能も持っている - ACRタスク https://docs.microsoft.com/ja-jp/azure/container-registry/container-registry-tasks-overview
- ★ACRの3つの「サービス階層」（「サービスレベル」や「SKU」とも） https://docs.microsoft.com/ja-jp/azure/container-registry/container-registry-skus
  - Basic
  - Standard
  - Premium: Geoレプリケーションをサポート.
- 知識チェック: サービス階層
- デモ: DockerコンテナーをACRに格納する

■モジュール: Azure Container Instances (ACI) でコンテナー イメージを実行する

- ACIとは？ https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-overview
  - Azure上でコンテナーを実行するためのシンプルなサービス
  - 単純な作業（タスク）を実行するのに向く。
  - ネットワークも使える
  - Azure ファイル共有を「マウント」できる
  - メモリ、vCPUを指定できる
  - セキュリティ: VMと同レベル（ハイパーバイザーで分離）
- コンテナーグループとは？ https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-container-groups
  - ACIの（トップレベルの）リソース
  - 1つ以上のコンテナーの集まり
  - 例「Webサーバーコンテナー＋DBサーバーコンテナー」など。
- コンテナーグループの作成方法
  - Azure portal （コンテナー インスタンス）
  - Azure CLI (az container create)
  - YAMLファイル（ACI専用フォーマット）: ACIコンテナーのみ定義可能 https://docs.microsoft.com/ja-jp/azure/container-instances/container-instances-reference-yaml
  - ARMテンプレート: ACIコンテナー＋その他のAzureリソースを定義可能 https://docs.microsoft.com/ja-jp/azure/templates/microsoft.containerinstance/containergroups?tabs=bicep
- 知識チェック: コンテナーグループの作成方法
- デモ: ACRに格納したDockerコンテナーをACIで実行する

■ラボ5


■ランチ 12:00-13:00

# ラーニングパス: AZ-204: ユーザー認証と承認を実装する

https://docs.microsoft.com/ja-jp/learn/paths/az-204-implement-authentication-authorization/

■（前知識）Azure AD

- Azure ADとは？ https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-whatis
  - Azure, Microsoft 365、その他のクラウドアプリケーションで利用される認証プラットフォーム
- テナント、ディレクトリ、サブスクリプション https://github.com/hiryamada/notes/blob/main/AZ-104/pdf/mod01/%E3%83%86%E3%83%8A%E3%83%B3%E3%83%88.pdf
- ユーザー、グループ
  - デモ: ユーザー、グループの作成
- アプリ
  - シングルテナントのアプリ
    - アプリを登録したテナントに属するユーザーのみ、そのアプリを利用できる
    - 社員のみ使用する社内業務用のアプリなど
  - マルチテナントのアプリ
    - アプリを登録したテナント以外のユーザーも、そのアプリを利用できる
    - 一般公開されるアプリなど
- アプリの登録
  - デモ: アプリの登録
- Azure ADの「条件付きアクセス」で、アプリにアクセスする際の条件を指定できる。多要素認証必須,等
  - デモ: 「条件付きアクセス」の設定
- アプリケーションオブジェクト
  - アプリを登録したテナントには「アプリケーションオブジェクト」が作られる。
  - https://docs.microsoft.com/ja-jp/azure/active-directory/develop/active-directory-how-applications-are-added#what-are-application-objects-and-where-do-they-come-from
- サービスプリンシパル
  - アプリを利用するテナントには「アプリケーションオブジェクト」に対応する「サービスプリンシパル」が作られる
  - https://docs.microsoft.com/ja-jp/azure/active-directory/develop/active-directory-how-applications-are-added#what-are-service-principals-and-where-do-they-come-from
- アプリケーションオブジェクトとサービスプリンシパルの関係の図
  - https://docs.microsoft.com/ja-jp/azure/active-directory/develop/active-directory-how-applications-are-added#how-are-application-objects-and-service-principals-related-to-each-other

■モジュール: Microsoft ID プラットフォームを調べる

- 「Microsoft ID プラットフォーム」とは？ https://docs.microsoft.com/ja-jp/azure/active-directory/develop/v2-overview
  - 任意のアプリに対し、Azure ADを使用した認証機能を提供するしくみ。
  - アプリに認証機能を組み込む必要がある開発者向けのプラットフォーム。
  - 認証/認可プロトコル: OAuth 2.0 / OpenID Connect に準拠
  - MSAL（Microsoft Authentication Libraries）というライブラリを提供している。
    - プログラマが直接 OAuth 2.0 / OpenID Connect を処理するコードを書く必要はない
- ★MSALの主な種類 https://docs.microsoft.com/ja-jp/azure/active-directory/develop/msal-overview
  - ★MSAL.js: シングルページアプリ(SPA)向け
  - MSAL.NET: .NET向け
  - MSAL Node: Node.js向け
- 「Microsoft ID プラットフォーム」を利用できるアプリの種類
  - Webアプリ
  - モバイルアプリ
  - デスクトップアプリ
  - サーバーアプリ（デーモン）
- 「Microsoft ID プラットフォーム」の使い方の概要
  - アプリをAzure ADテナントに登録する
  - アプリに「MSAL」を組み込む
    - MSALの機能を呼び出して、認証・認可を処理する
- ★アプリによる「アクセス許可」の要求
  - ★デリゲート（委任）されたアクセス許可:
    - ★一般ユーザーがサインインして使用するタイプのアプリ（Webアプリ等）で使用。
    - サインインしたユーザーが、アプリに、自分の代理として振る舞う権限を与える（委任）。例: 自分に代わって、アプリが、Outlookからメールを送信する、など。
  - アプリケーションのアクセス許可: 
    - 管理者が、必要な権限をアプリに与える
- Azure ADの「条件付きアクセス」
  - Microsoft ID プラットフォームでも使用できる
  - ★「on-behalf-ofフロー」を実行するアプリでは「条件付きアクセス」チャレンジを処理するコードの追加が必要
  - 「on-behalf-ofフロー」:
    - OAuth 2.0 の しくみ
    - アプリケーションがサービス/Web API を呼び出し、それがさらに別のサービス/Web API を呼び出す状況
    - ユーザーがサービスXにアクセスした際に、サービスXがMicrosof IDプラットフォームから
      サービスY用のアクセストークンを取得し、それをサービスYに渡して処理をするような状況
    - サービスYで「条件付きアクセス」が有効になっていると、認証が失敗する可能性がある。
    - サービスXでは、その失敗をユーザーに表示し、ユーザーに対処してもらう必要がある（多要素認証を行う等）
- 知識チェック: 
  - デリゲート（委任）されたアクセス許可を使用するアプリは？
    - ユーザーがサインインして使用するタイプのアプリ
  - 「条件付きアクセス」チャレンジを処理するコードが必要なアプリは？
    - 「on-behalf-ofフロー」を実行するアプリ

■モジュール: Microsoft 認証ライブラリ (MSAL) を使用して認証を実装する

- ※（MSALの概要は前モジュールで解説済み）
- 知識チェック: シングルページ Web アプリをサポートしている MSAL ライブラリ


■モジュール: Shared Access Signature を実装する

- SASとは？
  - 「委任」（限定的なアクセスの提供）を行うためのしくみ
  - ホテルのカードキーに例えることができる
- ★SASの種類
  - ★ユーザー委任SAS
    - Azure ADの資格情報とSASに指定されたアクセスを使用して作成
    - ★Blobストレージにのみ適用される
    - ★セキュリティのベストプラクティスとして推奨されている方法
  - サービスSAS
    - ストレージアカウントを使用して作成
    - Blob、Files、Table、Queueのサービス内のリソースへのアクセスを委任
  - アカウントSAS
    - ストレージアカウントを使用して作成
    - 1つ以上のストレージサービスのリソースへのアクセスを委任
- 知識チェック:
  - Blobストレージにのみ適用されるSASの種類
  - SASのベストプラクティス

■モジュール: Microsoft Graph を調べる

- Microsoft Graphとは？ https://docs.microsoft.com/ja-jp/graph/overview
  - Microsoft 365, Windows 10, EMS(Enterprise Mobility + Security)に接続するためのAPI
  - Microsoft 365のデータを読み書きしたり、操作を自動化したりすることができる
  - できることの例: Outlookカレンダーの操作など https://docs.microsoft.com/ja-jp/graph/overview#what-can-you-do-with-microsoft-graph
- .NETからの操作例 https://docs.microsoft.com/ja-jp/graph/tutorials/dotnet-core
  - dotnet add package Microsoft.Graph
- HTTP REST APIの基本 https://developer.mozilla.org/ja/docs/Web/HTTP/Methods
  - GET: データの読み取り
  - POST: 新しいリソースの作成 / アクションの実行
  - PATCH: 新しい値でリソース（の一部）を更新
  - PUT : リソースの置換
  - DELETE: リソースの削除
- 知識チェック:
  - 新しい値でリソースを更新するために使用するHTTPメソッド: PATCH
  - Azureの外部のデータをMicrosoft Graphに送るためのコンポーネント: コネクタ
  - Microsoft Graph .NET SDKの、認証ライブラリ（MSAL）のラッパーは? : Microsoft.Graph.Auth

■ラボ6

# ラーニングパス: AZ-204: セキュリティで保護されたクラウド ソリューションを実装する

https://docs.microsoft.com/ja-jp/learn/paths/az-204-implement-secure-cloud-solutions/

■モジュール: Azure Key Vault を実装する

- Azure Key Vaultとは？ https://docs.microsoft.com/ja-jp/azure/key-vault/general/overview
  - キー
  - シークレット
  - 証明書
- Azure Key Vaultへのアクセスの許可
  - コントロールプレーン
    - Azure RBAC  https://docs.microsoft.com/ja-jp/azure/key-vault/general/security-features#managing-administrative-access-to-key-vault
      - 組み込みロール: Key Vault Contributor
  - データプレーン
    - 昔: アクセスポリシー https://docs.microsoft.com/ja-jp/azure/key-vault/general/assign-access-policy?tabs=azure-portal
    - 現在: Azure RBAC https://docs.microsoft.com/ja-jp/azure/key-vault/general/rbac-guide?tabs=azure-cli#azure-built-in-roles-for-key-vault-data-plane-operations
      - 組み込みロール: Key Vault Secrets User, Key Vault Secrets Officer 等
- マネージドIDとは？
  - サービスプリンシパルの一種
  - Azure のリソースに対して割り当てることができる
  - システム割り当てマネージドID
  - ユーザー割り当てマネージドID
- 知識チェック
  - 推奨される Azure Key Vaultへの認証方法: マネージドID
  - Azure Key Vaultとクライアント間の通信の暗号化方式: TLS

■モジュール: マネージド ID を実装する

- VMへのマネージドIDの割り当て方法(Azure CLI)
- アクセストークン
- 知識チェック
  - ユーザー割り当てマネージドIDの特徴: 独立したライフサイクル
  - トークンの基となっているものは？（トークンは何に対して発行されるか？）: サービスプリンシパル

■モジュール: Azure App Configuration を実装する

- Azure App Configurationとは？ https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/overview
- 構成エクスプローラ(configuration explorer)
  - 「キーと値」(key and value)を管理
  - キー
    - 多数のキーが有る場合「:」を使用して階層構造で定義すると、管理しやすい
  - ラベル
    - 「prod」「dev」「（ラベルなし）」などのラベルを付与することで、環境ごとに異なる値を設定できる
- 機能マネージャ(feature manager)
  - 「機能フラグ」を管理
  - 管理者が任意のタイミングで機能をon/offできる
    - アプリのリリースと機能のリリースのタイミングを分離することができる
- 知識チェック

■ラボ7

# ラーニングパス 5: [AZ-204: サービスとしてのインフラストラクチャ ソリューションを実装する](https://docs.microsoft.com/ja-jp/learn/paths/az-204-implement-iaas-solutions/)
## モジュール 1: [Azure で仮想マシンをプロビジョニングする](https://docs.microsoft.com/ja-jp/learn/modules/provision-virtual-machines-azure/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/provision-virtual-machines-azure/1-introduction)
- ユニット 2: [Azure Virtual Machines を調べる](https://docs.microsoft.com/ja-jp/learn/modules/provision-virtual-machines-azure/2-azure-virtual-machines-overview)
- ユニット 3: [仮想マシンの可用性オプションを比較する](https://docs.microsoft.com/ja-jp/learn/modules/provision-virtual-machines-azure/3-azure-virtual-machine-availability-options)
- ユニット 4: [仮想マシンの適切なサイズを決定する](https://docs.microsoft.com/ja-jp/learn/modules/provision-virtual-machines-azure/4-azure-virtual-machine-sizes)
- ユニット 5: [演習: Azure CLI を使用して仮想マシンを作成する](https://docs.microsoft.com/ja-jp/learn/modules/provision-virtual-machines-azure/5-azure-virtual-machine-azure-cli)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/provision-virtual-machines-azure/6-knowledge-check)
- ユニット 7: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/provision-virtual-machines-azure/7-summary)
## モジュール 2: [Azure Resource Manager テンプレートを作成してデプロイする](https://docs.microsoft.com/ja-jp/learn/modules/create-deploy-azure-resource-manager-templates/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/create-deploy-azure-resource-manager-templates/1-introduction)
- ユニット 2: [Azure Resource Manager について調べる](https://docs.microsoft.com/ja-jp/learn/modules/create-deploy-azure-resource-manager-templates/2-azure-resource-manager-overview)
- ユニット 3: [多層ソリューションをデプロイする](https://docs.microsoft.com/ja-jp/learn/modules/create-deploy-azure-resource-manager-templates/3-azure-resource-manager-templates)
- ユニット 4: [条件付きデプロイについて調べる](https://docs.microsoft.com/ja-jp/learn/modules/create-deploy-azure-resource-manager-templates/4-azure-resource-manager-conditional-deployment)
- ユニット 5: [適切なデプロイ モードを設定する](https://docs.microsoft.com/ja-jp/learn/modules/create-deploy-azure-resource-manager-templates/5-azure-resource-manager-deployment-modes)
- ユニット 6: [演習: Visual Studio Code を使用して、Azure Resource Manager テンプレートを作成してデプロイする](https://docs.microsoft.com/ja-jp/learn/modules/create-deploy-azure-resource-manager-templates/6-create-deploy-resource-manager-template)
- ユニット 7: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/create-deploy-azure-resource-manager-templates/7-knowledge-check)
- ユニット 8: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/create-deploy-azure-resource-manager-templates/8-summary)
## モジュール 3: [Azure Container Registry でコンテナー イメージを管理する](https://docs.microsoft.com/ja-jp/learn/modules/publish-container-image-to-azure-container-registry/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/publish-container-image-to-azure-container-registry/1-introduction)
- ユニット 2: [Azure Container Registry の概要](https://docs.microsoft.com/ja-jp/learn/modules/publish-container-image-to-azure-container-registry/2-azure-container-registry-overview)
- ユニット 3: [ストレージ機能を調べる](https://docs.microsoft.com/ja-jp/learn/modules/publish-container-image-to-azure-container-registry/3-azure-container-registry-storage)
- ユニット 4: [タスクを使用したコンテナーのビルドと管理](https://docs.microsoft.com/ja-jp/learn/modules/publish-container-image-to-azure-container-registry/4-azure-container-registry-tasks)
- ユニット 5: [Dockerfile の要素を調べる](https://docs.microsoft.com/ja-jp/learn/modules/publish-container-image-to-azure-container-registry/5-dockerfile-components)
- ユニット 6: [演習: Azure Container Registry タスクを使用してコンテナー イメージをビルドして実行する](https://docs.microsoft.com/ja-jp/learn/modules/publish-container-image-to-azure-container-registry/6-build-run-image-azure-container-registry)
- ユニット 7: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/publish-container-image-to-azure-container-registry/7-knowledge-check)
- ユニット 8: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/publish-container-image-to-azure-container-registry/8-summary)
## モジュール 4: [Azure Container Instances でコンテナー イメージを実行する](https://docs.microsoft.com/ja-jp/learn/modules/create-run-container-images-azure-container-instances/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/create-run-container-images-azure-container-instances/1-introduction)
- ユニット 2: [Azure Container Instances について調べる](https://docs.microsoft.com/ja-jp/learn/modules/create-run-container-images-azure-container-instances/2-azure-container-instances-overview)
- ユニット 3: [演習: Azure CLI を使ってコンテナー インスタンスをデプロイする](https://docs.microsoft.com/ja-jp/learn/modules/create-run-container-images-azure-container-instances/3-run-azure-container-instances-cloud-shell)
- ユニット 4: [再起動ポリシーによるコンテナー化タスクの実行](https://docs.microsoft.com/ja-jp/learn/modules/create-run-container-images-azure-container-instances/4-run-containerized-tasks-restart-policies)
- ユニット 5: [コンテナー インスタンスで環境変数を設定する](https://docs.microsoft.com/ja-jp/learn/modules/create-run-container-images-azure-container-instances/5-set-environment-variables-azure-container-instances)
- ユニット 6: [Azure Container Instances に Azure ファイル共有をマウントする](https://docs.microsoft.com/ja-jp/learn/modules/create-run-container-images-azure-container-instances/6-mount-azure-file-share-azure-container-instances)
- ユニット 7: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/create-run-container-images-azure-container-instances/7-knowledge-check)
- ユニット 8: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/create-run-container-images-azure-container-instances/8-summary)
# ラーニングパス 6: [AZ-204: ユーザー認証と承認を実装する](https://docs.microsoft.com/ja-jp/learn/paths/az-204-implement-authentication-authorization/)
## モジュール 1: [Microsoft ID プラットフォームを調べる](https://docs.microsoft.com/ja-jp/learn/modules/explore-microsoft-identity-platform/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/explore-microsoft-identity-platform/1-introduction)
- ユニット 2: [Microsoft ID プラットフォームを調べる](https://docs.microsoft.com/ja-jp/learn/modules/explore-microsoft-identity-platform/2-microsoft-identity-platform-overview)
- ユニット 3: [サービス プリンシパルを調べる](https://docs.microsoft.com/ja-jp/learn/modules/explore-microsoft-identity-platform/3-app-service-principals)
- ユニット 4: [アクセス許可と同意について探索する](https://docs.microsoft.com/ja-jp/learn/modules/explore-microsoft-identity-platform/4-permission-consent)
- ユニット 5: [条件付きアクセスについて探索する](https://docs.microsoft.com/ja-jp/learn/modules/explore-microsoft-identity-platform/5-conditional-access)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/explore-microsoft-identity-platform/6-knowledge-check)
- ユニット 7: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/explore-microsoft-identity-platform/7-summary)
## モジュール 2: [Microsoft 認証ライブラリを使用して認証を実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-authentication-by-using-microsoft-authentication-library/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/implement-authentication-by-using-microsoft-authentication-library/1-introduction)
- ユニット 2: [Microsoft 認証ライブラリを調査する](https://docs.microsoft.com/ja-jp/learn/modules/implement-authentication-by-using-microsoft-authentication-library/2-microsoft-authentication-library-overview)
- ユニット 3: [クライアント アプリケーションを初期化する](https://docs.microsoft.com/ja-jp/learn/modules/implement-authentication-by-using-microsoft-authentication-library/3-initialize-client-applications)
- ユニット 4: [演習: MSAL.NET を使用して対話型認証を実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-authentication-by-using-microsoft-authentication-library/4-interactive-authentication-msal)
- ユニット 5: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-authentication-by-using-microsoft-authentication-library/5-knowledge-check)
- ユニット 6: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/implement-authentication-by-using-microsoft-authentication-library/6-summary)
## モジュール 3: [Shared Access Signature を実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-shared-access-signatures/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/implement-shared-access-signatures/1-introduction)
- ユニット 2: [Shared Access Signature を検出する](https://docs.microsoft.com/ja-jp/learn/modules/implement-shared-access-signatures/2-shared-access-signatures-overview)
- ユニット 3: [Shared Access Signature を使用する場合を選ぶ](https://docs.microsoft.com/ja-jp/learn/modules/implement-shared-access-signatures/3-shared-access-signatures)
- ユニット 4: [保存されているアクセス ポリシーを調べる](https://docs.microsoft.com/ja-jp/learn/modules/implement-shared-access-signatures/4-stored-access-policies)
- ユニット 5: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-shared-access-signatures/5-knowledge-check)
- ユニット 6: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/implement-shared-access-signatures/6-summary)
## モジュール 4: [Microsoft Graph を調べる](https://docs.microsoft.com/ja-jp/learn/modules/microsoft-graph/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/microsoft-graph/1-introduction)
- ユニット 2: [Microsoft Graph について](https://docs.microsoft.com/ja-jp/learn/modules/microsoft-graph/2-microsoft-graph-overview)
- ユニット 3: [REST を使って Microsoft Graph に対してクエリを実行する](https://docs.microsoft.com/ja-jp/learn/modules/microsoft-graph/3-microsoft-graph-api)
- ユニット 4: [SDK を使って Microsoft Graph に対してクエリを実行する](https://docs.microsoft.com/ja-jp/learn/modules/microsoft-graph/4-microsoft-graph-sdk)
- ユニット 5: [Microsoft Graph にベスト プラクティスを適用する](https://docs.microsoft.com/ja-jp/learn/modules/microsoft-graph/5-microsoft-graph-best-practices)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/microsoft-graph/6-knowledge-check)
- ユニット 7: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/microsoft-graph/7-summary)
# ラーニングパス 7: [AZ-204: セキュリティで保護されたクラウド ソリューションを実装する](https://docs.microsoft.com/ja-jp/learn/paths/az-204-implement-secure-cloud-solutions/)
## モジュール 1: [Azure Key Vault を実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-key-vault/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-key-vault/1-introduction)
- ユニット 2: [Azure Key Vault の探索](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-key-vault/2-key-vault-overview)
- ユニット 3: [Azure Key Vault のベスト プラクティスを確認する](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-key-vault/3-key-vault-concepts)
- ユニット 4: [Azure Key Vault に対する認証](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-key-vault/4-key-vault-authentication)
- ユニット 5: [演習 - Azure CLI を使用して Azure Key Vault からシークレットを設定および取得する](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-key-vault/5-set-retrieve-secret-azure-key-vault)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-key-vault/6-knowledge-check)
- ユニット 7: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-key-vault/7-summary)
## モジュール 2: [マネージド ID を実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-managed-identities/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/implement-managed-identities/1-introduction)
- ユニット 2: [マネージド ID を調べる](https://docs.microsoft.com/ja-jp/learn/modules/implement-managed-identities/2-managed-identities-overview)
- ユニット 3: [マネージド ID の認証フローを調べる](https://docs.microsoft.com/ja-jp/learn/modules/implement-managed-identities/3-managed-identities-auzre-virtual-machines)
- ユニット 4: [マネージド ID の構成](https://docs.microsoft.com/ja-jp/learn/modules/implement-managed-identities/4-configure-managed-identities)
- ユニット 5: [アクセス トークンの取得](https://docs.microsoft.com/ja-jp/learn/modules/implement-managed-identities/5-acquire-access-token)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-managed-identities/6-knowledge-check)
- ユニット 7: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/implement-managed-identities/7-summary)
## モジュール 3: [Azure App Configuration を実装する](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-app-configuration/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-app-configuration/1-introduction)
- ユニット 2: [Azure App Configuration サービスを調べる](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-app-configuration/2-app-configuration-overview)
- ユニット 3: [ペアのキーと値を作成する](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-app-configuration/3-keys-values)
- ユニット 4: [アプリケーションの機能を管理する](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-app-configuration/4-app-configuration-feature-management)
- ユニット 5: [アプリ構成データをセキュリティで保護する](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-app-configuration/5-secure-app-configuration-data)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-app-configuration/6-knowledge-check)
- ユニット 7: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/implement-azure-app-configuration/7-summary)



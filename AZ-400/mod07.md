# モジュール7 アプリケーション構成とシークレットの管理

前半: セキュリティの設計

- DevOpsにおけるセキュリティ（DevSecOps）とは。
- Microsoft Security Development Lifecycle （SDL）とは。
- Microsoft Security Development Lifecycle （SDL）はなんの役に立つのか。
- 脅威（Threat）とは。
- 脅威モデリングとは。
- Threat Modeling Toolとは。
- 継続的インテグレーションにおける静的コード解析とは。

後半: 設定値や機密情報の扱い方

- アプリケーションにおける設定値や機密情報の適切な扱い方とは。
- サービスプリンシパルとは。
- マネージドIDとは。
- Azure Key Vaultとは。
- Azure App Configurationとは。

## セキュリティの概要

重要ポイント

- DevOpsの速度に合わせ、セキュリティ対策も速度を上げる必要がある。
  - **DevSecOps**（DevOpsへのセキュリティ対策の組み込み、自動化）を行う。
- セキュリテイ対策では**多層防御**を行う必要がある

### セキュリティの概要

DevOpsにおけるセキュリティ（DevSecOps）とは。

- 多層防御 
  - これは、DevOpsに限らない、セキュリティ対策の基本的な考え方。
  - [複数の防衛線を用意する](https://ascii.jp/elem/000/004/040/4040381/)。
  - [ベストプラクティス](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/best-practices-and-patterns)に従う。
- DevOpsにセキュリティを組み込む 
  - [DevSecOps](https://azure.microsoft.com/ja-jp/solutions/devsecops/)
- セキュリティ対策はチーム全体の責任。
  - [DevOps は開発チームや運用チームだけのものではありません(Red Hat)](https://www.redhat.com/ja/topics/devops/what-is-devsecops)。
  - セキュリティを常に意識して「作り込む」（あとから対策を付け足すのではない）
- セキュリティ対策を自動化する
  - コードの脆弱性スキャン - [SonarQube](https://marketplace.visualstudio.com/items?itemName=SonarSource.sonarqube)をAzure Pipelineに組み込むなど
  - Dockerコンテナの脆弱性スキャン - Azure Container Registryで[Qualysスキャナ](https://azure.microsoft.com/ja-jp/updates/vulnerability-scanning-for-images-in-azure-container-registry-is-now-generally-available/)を使用
  - プロジェクトでの脆弱性があるパッケージの使用のチェック - Azure Pipelines[WhiteSource](https://marketplace.visualstudio.com/items?itemName=whitesource.whitesource)

※Azureのセキュリティの学習については[AZ-500 Security Technologies](https://docs.microsoft.com/ja-jp/learn/certifications/courses/az-500t00)というコースもご利用いただけます。

### SQL インジェクション攻撃

SQLインジェクション攻撃（SQL Injection、SQLi）とは何か。

悪意のあるSQLステートメントの実行を可能にする攻撃。
- [SQLインジェクション（Wikipedia）](https://ja.wikipedia.org/wiki/SQL%E3%82%A4%E3%83%B3%E3%82%B8%E3%82%A7%E3%82%AF%E3%82%B7%E3%83%A7%E3%83%B3)
- [OWASPのドキュメント](https://owasp.org/www-community/attacks/SQL_Injection)

対策
- [OWASPのドキュメント](https://owasp.org/www-community/attacks/SQL_Injection)のガイドに従う
  - プリペアードステートメントを使う
  - ストアドプロシージャを使う
  - 許可リストを使う
  - ユーザーの入力すべてをエスケープする
- [Azure Web アプリケーション ファイアウォール（Azure WAF）](https://azure.microsoft.com/ja-jp/services/web-application-firewall/)で防ぐ
- [IPA「安全なウェブサイトの作り方」](https://www.ipa.go.jp/security/vuln/websecurity.html)の別冊[「安全なSQLの呼び出し方」](https://www.ipa.go.jp/files/000017320.pdf)

※このページに書かれた「シミュレーション」手順についてはラボで実施

## 安全な開発プロセスの実装

重要ポイント

- セキュリティ対策は、組織の開発プロセスの中に組み込む必要がある。
- 開発プロセスにおけるセキュリティを考慮する際に、**Microsoft SDL**を参考にすることができる。
- **Microsoft SDL**の設計フェーズには、**脅威モデリング**の使用が含まれる。
- **脅威モデリング**を使用して、アプリケーションの各部分の潜在的な脅威を調べ、対策を検討することができる。
- **Microsoft Threat Modeling Tool**（Windowsアプリ）で、**脅威モデリング**を実施することができる。

### 脅威モデリング

■Microsoft Security Development Lifecycle （SDL）とは。

- 2004年頃からMicrosoftで利用されている、開発におけるセキュリティ対策。
  - 開発プロセスのすべてのフェーズでセキュリティとプライバシーに関する考慮事項を導入
  - 開発者が安全性の高いソフトウェアを構築できるようにする
  - セキュリティコンプライアンス要件に対応できるようにする
  - 開発コストを削減できるようにする
- プロセスは、トレーニング、要件、設計、実装、検証、リリース、対応の7つのフェーズに分かれている。
- Microsoftが自社開発する製品のセキュリティ対策
- [すべての Microsoft ソフトウェア開発チームは、SDL の要件に従う必要がある](https://docs.microsoft.com/ja-jp/compliance/assurance/assurance-security-development-and-operation)
- 2009年、アジャイル開発にも対応した

- [Microsoft SDL](https://www.microsoft.com/en-us/securityengineering/sdl)
- [Azure での安全な開発のベスト プラクティス(SDLの解説を含む)](https://docs.microsoft.com/ja-jp/azure/security/develop/secure-dev-overview)
- [セキュリティの開発と運用の概要](https://docs.microsoft.com/ja-jp/compliance/assurance/assurance-security-development-and-operation)
- [解説記事（publickey）](https://www.publickey1.jp/blog/09/security_development_lifecycle.html)
- [マイクロソフトセキュリティ開発ライフサイクル（Microsoft SDL）](https://ja.continuousdev.com/23582-microsoft-security-development-lifecycle-microsoft-sdl-6205)
- [Microsoft SDL の簡単な実装](https://www.microsoft.com/ja-jp/download/details.aspx?id=12379)


```
DevOpsは、サイロ化された開発と運用に取って代わり、共有された効率的なプラクティス、ツール、およびKPIと連携する学際的なチームを作成しました。この動きの速い環境で安全性の高いソフトウェアとサービスを提供するには、セキュリティが同じ速度で動くことが重要です。
```

※サイロ化＝チームが分断されている状態

■Microsoft Security Development Lifecycle （SDL）がなぜ重要か。

[セキュリティ開発ライフサイクル](https://docs.microsoft.com/ja-jp/azure/security/develop/secure-dev-overview#security-development-lifecycle)より:
```
開発ライフサイクルでの問題の解決が遅くなるほど、その修正にかかるコストが増えます。 セキュリティの問題も例外ではありません。 ソフトウェア開発の初期フェーズでセキュリティの問題を無視すると、前のフェーズの脆弱性がその後の各フェーズに継承される可能性があります。 さまざまなセキュリティの問題と侵害の可能性が、最終製品に累積されることになります。 開発ライフサイクルの各フェーズにセキュリティを組み込むことで、問題を早い段階でキャッチでき、開発コストを削減することができます。
```

■Microsoft Security Development Lifecycle （SDL）はなんの役に立つのか。

Microsoft SDLは、一般公開されており、一般の組織や開発者が自由に利用することができる。自社の開発プロセスにおけるセキュリティ対策の際に、SDLを参考にすることができる。

- 現在は[一般公開されている](https://www.microsoft.com/en-us/securityengineering/sdl)
- [Microsoft SDL の簡単な実装](https://www.microsoft.com/ja-jp/download/details.aspx?id=12379)より:
  - Microsoft SDLは、自由に使用することができる。
  - 「Microsoft SDL の簡単な実装」では、Microsoftの**外部のグループ**が一般的に使用している**開発プラクティスにMicrosoft SDLを適用する**場合を中心に解説している。
  - 「Microsoft SDL最適化モデル」で、4段階の「成熟度」（基本、標準、高度、動的）を定義している。


具体的な例: [Microsoft Security Code Analysis](https://docs.microsoft.com/ja-jp/azure/security/develop/security-code-analysis-overview)

Microsoft Security Code Analysis 拡張機能を使用すると、チームは Azure DevOps の継続的インテグレーションと継続的配信 (CI/CD) パイプラインにセキュリティ コード分析を追加できます。**これは Microsoft の Microsoft セキュリティ開発ライフサイクル (SDL) の専門家が推奨する分析です**。

■脅威（[Threat](https://ejje.weblio.jp/content/threat)）とは

[情報資産にダメージを与えるもの、現象。（IPA）](https://www.ipa.go.jp/files/000013297.pdf)

脅威の例
- 漏洩
- 暴露
- 改ざん
- 破壊

脅威の原因となるもの
- 不正アクセス
- 盗聴
- マルウェア（コンピューターウイルス等）
- 内部犯行

■脅威モデリング（Threat Modeling）とは

[SDLの「デザイン」（設計）フェーズには、「脅威モデリングの使用」が含まれている](https://docs.microsoft.com/ja-jp/azure/security/develop/secure-design#design)。

```
SDL には、潜在的な問題の解決が比較的容易でコスト効率に優れている場合は、設計フェーズでチームが脅威モデリングに参加すべきと規定されています。設計フェーズで脅威モデリングを使用すれば、開発の総コストを大幅に削減できます。
```

アプリケーションの設計フェーズで行い、各領域の脅威を特定すること。特定された脅威に対し、保護・軽減策を確認する。

- 設計フェーズで脅威モデリングを使用すれば、開発の総コストを大幅に削減できます。
- アプリケーションの設計をモデリングし、**脅威を列挙する**ことは、早い段階で設計エラーを検出するための効果的な方法であると証明されています。

[アプリケーション設計時に脅威モデリングを使用する](https://docs.microsoft.com/ja-jp/azure/security/develop/secure-design#use-threat-modeling-during-application-design)

手順

- 「モデル」（図）を作る（システムにどのようなリソースがあるか？）
- モデルの各要素に対する脅威を特定する（リソースにどんな脅威があるか？）

脅威モデリングの手順

- ダイアグラムの作成 (creating a diagram)
- 脅威の特定 (identifying threats)
- 脅威の軽減 (mitigating)
- 各軽減策の検証 (validating each mitigation)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/security/develop/threat-modeling-tool-getting-started)

※Skillpipeには「セキュリティ要件の定義」をあわせて5つの手順と説明している。

■Threat Modeling Toolとは

脅威モデリングを行うためのツール。Windows用。

[Microsoft Threat Modeling Tool](https://docs.microsoft.com/ja-jp/azure/security/develop/threat-modeling-tool) は、Microsoft セキュリティ開発ライフサイクル (SDL) の主要な要素です。 これを使用すると、ソフトウェア アーキテクトは早い段階で潜在的なセキュリティの問題を特定し、危険を軽減することができます。

### デモンストレーション: 脅威モデリング

※このページに書かれた「デモンストレーション」手順についてはラボで実施

### 重要な検証ポイント

開発から本番までの各段階で、セキュリティ検証を行う。

- IDEでのコード開発、プルリクエスト
- CI（ビルド、単体テスト、パッケージング）
- ステージング環境へのデプロイ

※Skillpipeのこのページの図で「筆記試験」とある部分は、「Pen Test」（[ペネトレーションテスト](https://ja.wikipedia.org/wiki/%E3%83%9A%E3%83%8D%E3%83%88%E3%83%AC%E3%83%BC%E3%82%B7%E3%83%A7%E3%83%B3%E3%83%86%E3%82%B9%E3%83%88)、侵入テスト）を表している。[ドキュメントの図](https://docs.microsoft.com/ja-jp/azure/devops/migrate/security-validation-cicd-pipeline?view=azure-devops)を参照のこと。

※図の「Passive Pen Test」（パッシブな侵入テスト）とは、システムの可用性に影響を与えない（DoS攻撃やデータの改ざんまでは行わない）テストのこと。「Active Pen Test」（アクティブな侵入テスト）とは、実際の攻撃に近い侵入テスト。

### 継続的インテグレーション

継続的インテグレーションにおける静的コード解析とは。

Azure Pipelineに組み込んで使用することができる「静的コード解析ツール」が多数存在する。

- [SonarQube](https://marketplace.visualstudio.com/items?itemName=SonarSource.sonarqube)
- [Visual Studio Code Analysis](https://docs.microsoft.com/ja-jp/azure/security/develop/security-code-analysis-overview)
  - **これは Microsoft の Microsoft セキュリティ開発ライフサイクル (SDL) の専門家が推奨する分析です**。
- [Checkmarx](https://marketplace.visualstudio.com/items?itemName=checkmarx.cxsast)
- [BinSkim Binary Analyzer](https://github.com/microsoft/binskim)
  - [BinSkimタスク](https://docs.microsoft.com/ja-jp/azure/security/develop/security-code-analysis-customize#binskim-task)として利用できる


## アプリケーション構成データの再考

### アプリケーション構成データの再考

機密情報はファイルに書き込まないようにしましょう。

### 懸念事項の分離

アプリケーションにおける設定値や機密情報の適切な扱い方とは。

「設定値や機密情報を設定する管理者」と「設定値や機密情報の利用者」に分けて運用することで、セキュリティを高めることができる。
- 管理者は、設定値や機密情報を一元的に管理する。
- 利用者は、設定値や機密情報を直接取り扱う必要がなくなる。

※この資料における「構成」とはConfiguration（設定）のこと。

例として、以下のような「構成」が考えられる。
- 開発環境では「DBServer=dev.consoto.com」
- 本番環境では「DBServer=prod.consoto.com」

※この資料における「ストア（Store）」とは、構成情報や機密情報を一元的に格納するサービスを表す。具体的には以下のようなサービス。

- [Azure App Configuration](https://azure.microsoft.com/ja-jp/services/app-configuration/) - アプリケーション構成情報を管理する「構成ストア」
- [Azure Key Vault](https://azure.microsoft.com/ja-jp/services/key-vault/) - 機密情報を管理する「シークレットストア」

- 構成管理者
  - 構成の生成・維持を担当する人。
  - 構成ストア・シークレットストアの管理
  - 構成、シークレットの管理
- 構成コンシューマ
  - 構成を読み取って利用するプログラム。
- 構成ストア
  - 構成情報を一元管理するサービス。App Configurationなど
- シークレットストア
  - アクセスキーなどの機密情報を一元管理するサービス。Key Vaultなど。

### 外部構成ストア パターン

[Microsoft Azure Well-Architected Frameworkの「外部構成ストア」パターン](https://docs.microsoft.com/ja-jp/azure/architecture/patterns/external-configuration-store)

```
アプリケーション展開パッケージから、一元管理される場所に構成情報を移動します。 こうすることで、構成データの管理と制御が簡単になり、構成データをアプリケーションとアプリケーション インスタンス全体で共有できるようになります。
```

つまり、アプリケーションの設定を「設定ファイル」のような形でアプリケーション自身にもたせるのをやめて、外部の「構成ストア」から適宜設定値を読み込んで利用するようにする。読み込んだ設定値はアプリケーション側でキャッシュする。

この考え方は、[Twelve-Factor App](https://12factor.net/ja/)の「[III. 設定](https://12factor.net/ja/config)」でも触れられている。

※Twelve-Factor Appは、モダンなWebアプリケーションのためのベストプラクティス。

### Azure Key Vault と Azure Pipeline の統合

※Azure Key Vaultについては後述

機密情報はAzure PipelinesのYAMLの中に書いたり、リポジトリにプッシュしたりしないようにしましょう。

- Azure Key Vaultに機密情報（アクセスキーなど）を格納することができる
- Azure Pipelinesのパイプライン内で、Azure Key Vaultの機密情報を取り出して変数に入れることができる
  - [Azure Key Vaultタスク](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/tasks/deploy/azure-key-vault?view=azure-devops)を使用する
- 変数の機密情報を、後続のタスクで利用できる。

## 秘密、トークン、および証明書を管理する

### シークレット、トークン、および証明書の管理

Azure Key Vaultとは。

[Key Vaultの講義ノート](../AZ-204/mod07-01-keyvault.md)を参照。

- 機密情報（キー、シークレット、証明書）の管理に特化。
- [FIPS 140-2](https://ja.wikipedia.org/wiki/FIPS_140)に対応した[HSM（ハードウェアセキュリティモジュール）](https://www.google.com/search?q=luna+sa+hsm&tbm=isch)を利用できる。

Key Vault周辺サービスとの比較については[まとめPDF](../AZ-204/pdf/mod07/キー管理サービス.pdf)を参照。

### DevOps の内側と外側のループ

（再掲）
「設定値や機密情報を設定する管理者」と「設定値や機密情報の利用者」に分けて運用することで、セキュリティを高めることができる。
- 管理者は、設定値や機密情報を一元的に管理する。
- 利用者は、設定値や機密情報を直接取り扱う必要がなくなる。

参考：[KubernetesとAzure key Vaultの利用](https://docs.microsoft.com/ja-jp/azure/key-vault/general/key-vault-integrate-kubernetes)

## ID 管理システムとの統合

AzureやGitHubにおけるID（認証）の管理方法

### GitHub とシングル サインオン (SSO) の統合

### サービス プリンシパル

サービスプリンシパルとは。

■サービスプリンシパルとは

サービス プリンシパルは、リソース/サービス レベルの**無人操作を実行する**目的でテナント内で作成する Azure Active Directory アプリケーション リソースです。

リソースへのアクセスや変更を行う必要があるアプリケーション、ホステッド サービス、または自動化されたツールがある場合は、アプリの ID を作成できます。この ID は、サービス プリンシパルと呼ばれます。

セキュリティ上の理由から、自動化ツールにはユーザー ID でのログインを許可するのではなく、常にサービス プリンシパルを使用することを推奨します。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-create-service-principal-portal)

■なぜここでサービスプリンシパル（やマネージドID）を学習するのか？

- Azure DevOpsのパイプライン内で、Azure key Vaultからパスワードを取得し、後続のタスクで使用する、といったシナリオで必要になるため。
- Azureのタスクをスクリプト等を使用して自動化・無人化する際に必要になるため。

■サービスプリンシパルの作成方法

- [Azure portal](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-create-service-principal-portal)
- [Azure PowerShell](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-authenticate-service-principal-powershell)
- [Azure CLI](https://docs.microsoft.com/ja-jp/cli/azure/create-an-azure-service-principal-azure-cli)

■サービスプリンシパルの利用

- [Azure PowerShell](https://docs.microsoft.com/ja-jp/powershell/azure/authenticate-azureps?view=azps-2.8.0#sign-in-with-a-service-principal)
- [Azure CLI](https://docs.microsoft.com/en-us/cli/azure/authenticate-azure-cli#sign-in-with-a-service-principal)
- .NET (Azure.Identityパッケージ)
  - [ClientCertificateCredential](https://docs.microsoft.com/en-us/dotnet/api/azure.identity.clientcertificatecredential?view=azure-dotnet)
  - [ClientSecretCredential](https://docs.microsoft.com/en-us/dotnet/api/azure.identity.clientsecretcredential?view=azure-dotnet)
- [Java](https://docs.microsoft.com/ja-jp/azure/developer/java/sdk/identity-service-principal-auth)
- [Python](https://docs.microsoft.com/ja-jp/azure/developer/python/azure-sdk-authenticate#using-serviceprincipalcredentials-azurecommon)

■サービスプリンシパルへのAzure RBACロールの割り当て

「サービスプリンシパル」に対して、RBACロールを設定して、Blobデータの読み書き、Key Vaultからのシークレットの利用などの権限を設定することができる。

### 管理サービス ID → 「マネージドID」

※現在は管理サービス ID（MSI）は「マネージドID」と呼ばれている。

マネージドIDとは。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/overview)

「マネージドID」を使用することで、Azure仮想マシン（VM）などのリソースにIDを割り当てることができる。

「マネージドID」に対して、RBACロールを設定して、Blobデータの読み書き、Key Vaultからのシークレットの利用などの権限を設定することができる。

■マネージドIDとサービスプリンシパルの共通点

- 人ではなく、**VMなどのリソースで動くプログラム**や、**オンプレミスで動くスクリプト**等で使用するIDである。
- **プログラムが**Azureのリソースにアクセスする際に必要。
  - 単にプログラムをAzureにデプロイして動かすだけなら不要。
- どちらもAzure ADのID（プリンシパル）である。
- Azure RBACロールを割り当てできる。

■マネージドIDとサービスプリンシパルの違い

- マネージド ID は、Azure リソースでのみ使用できる特殊なタイプのサービス プリンシパルです
- マネージド ID が削除されると、対応するサービス プリンシパルが自動的に削除されます。
- マネージドIDのほうがかんたんに扱える。
  - 作成・削除がかんたんにできる。
  - プログラムからの利用もかんたんにできる。

マネージドIDが使える状況ではマネージドIDを使うべき。

※Azureのリソース（VMなど）の上で動くプログラムの場合、そのリソースにマネージドIDを使用する。Azureのリソースではない場所（オンプレミスのサーバー等）で動くプログラムでは、マネージドIDが使用できないので、サービスプリンシパルを使用する。

※マネージドIDは、サービスプリンシパルの一種だが、サービスプリンシパルを直接作成・削除する必要がないという点が便利。

■マネージドIDの種類

- システム割り当てマネージドID
  - リソースに対して直接関連付けられるID。
- ユーザー割り当てマネージドID
  - 複数のAzureリソース（VM）に関連付けて利用できるID。
  - スタンドアロンのリソース。

■マネージドIDをサポートするサービス

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/services-support-managed-identities)

- Azure VM
- Azure VMSS
- Azure App Service
- Azure Functions
- ACI
- AKS
- Logic Apps
- Azure Event Grid トピック
  - トピックがService Bus, Blob, Queue, Event Hubsなどにデータを送信する際に利用
- など

## アプリケーション構成の実装

Azure App Configurationについて学ぶ。

### Azure App Configuration の概要

■Azure App Configurationとは。

[App Configurationの講義ノート](../AZ-204/mod07-03-app-configuration.md)を参照。

キーと値の形でアプリケーションの設定を管理するサービス。アプリケーションを再起動・再デプロイしなくても、アプリケーションの設定を動的に変更することができる。

- [アプリケーションを再起動させることなく必要に応じて構成を更新できる](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/enable-dynamic-configuration-dotnet-core)。
- [「機能フラグ」を利用して、特定のユーザーやグループに対して機能を有効化することができる](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/concept-feature-management)。
- 各言語・プラットフォーム用のクライアントライブラリが用意されている。

■Azure Key Vaultとの関係

- Azure Key Vault: 
  - 機密情報（キー、シークレット、証明書）の管理に特化。
  - [FIPS 140-2](https://ja.wikipedia.org/wiki/FIPS_140)に対応したHSM（ハードウェアセキュリティモジュール）を利用できる。
- Azure App Configuration
  - アプリケーションの設定情報の管理に特化。
  - [アプリケーションを再起動させることなく必要に応じて構成を更新できる](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/enable-dynamic-configuration-dotnet-core)。
  - [「機能フラグ」を利用して、特定のユーザーやグループに対して機能を有効化することができる](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/concept-feature-management)。

Azure App ConfigurationとAzure Key Vaultは補完関係にあるサービスである（得意分野が違うので、必要に応じて組み合わせて使用する）。Azure App Configurationに、[Azure key Vaultの「参照」を追加する](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/use-key-vault-references-dotnet-core?tabs=cmd%2Ccore2x)ことができる。つまり、アプリケーションで、Key Vaultのどのシークレットを読み込むかを、App Configuration側でコントロールすることができる。

### キーと値のペア

- キーと値を使って設定を記録する。
- キーは「:」などを使って階層構造で記録することもできる。
- キーと値に「ラベル」をつけることができる。
  - 「開発環境」「テスト環境」「本番環境」などの設定値を区別するために使用できる。

### App Configuration 機能の管理

[「機能フラグ」を利用して、特定のユーザーやグループに対して機能を有効化することができる](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/concept-feature-management)。

通常の「キーと値」の設定との違い
- 有効期限（開始・終了）を設定できる
- 特定のユーザー・グループがアプリを利用する際にのみ、特定の機能を有効化することができる。
- コード内でif-elseを使用した分岐ができる
- ASP.NET Coreと連携することができる。
  - [アクションの有効化/無効化](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/use-feature-flags-dotnet-core?tabs=core5x#controller-actions)
  - [MVCビュー内の特定の区画を描画する/しない](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/use-feature-flags-dotnet-core?tabs=core5x#mvc-views)
  - [MVCフィルターの有効化/無効化](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/use-feature-flags-dotnet-core?tabs=core5x#mvc-filters)

## ラボ

(1) Skillpipe モジュール7 「アプリケーション構成とシークレットの管理 / セキュリティの概要 / SQLインジェクション攻撃」のページを参照しながら、実際にSQLインジェクション攻撃をシミュレーションしてしてみましょう。

(2) Skillpipe モジュール7 「アプリケーション構成とシークレットの管理 / 安全な開発プロセスの実装 / デモンストレーション: 脅威モデリング」のページを参照しながら、Threat Modeling Toolを使用してしてみましょう。

(3)[チュートリアル: Azure Pipelines で Azure Key Vault シークレットを使用する](https://docs.microsoft.com/ja-jp/azure/devops/pipelines/release/azure-key-vault?view=azure-devops#create-a-project) を実施してみましょう。


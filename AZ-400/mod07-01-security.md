# セキュリティの設計

- DevOpsにおけるセキュリティ（DevSecOps）とは。
- Microsoft Security Development Lifecycle （SDL）とは。
- Microsoft Security Development Lifecycle （SDL）はなんの役に立つのか。
- 脅威（Threat）とは。
- 脅威モデリングとは。
- Threat Modeling Toolとは。
- 継続的インテグレーションにおける静的コード解析とは。


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


> DevOpsは、サイロ化された開発と運用に取って代わり、共有された効率的なプラクティス、ツール、およびKPIと連携する学際的なチームを作成しました。この動きの速い環境で安全性の高いソフトウェアとサービスを提供するには、セキュリティが同じ速度で動くことが重要です。


※サイロ化＝チームが分断されている状態

■Microsoft Security Development Lifecycle （SDL）がなぜ重要か。

[セキュリティ開発ライフサイクル](https://docs.microsoft.com/ja-jp/azure/security/develop/secure-dev-overview#security-development-lifecycle)より:

> 開発ライフサイクルでの問題の解決が遅くなるほど、その修正にかかるコストが増えます。 セキュリティの問題も例外ではありません。 ソフトウェア開発の初期フェーズでセキュリティの問題を無視すると、前のフェーズの脆弱性がその後の各フェーズに継承される可能性があります。 さまざまなセキュリティの問題と侵害の可能性が、最終製品に累積されることになります。 開発ライフサイクルの各フェーズにセキュリティを組み込むことで、問題を早い段階でキャッチでき、開発コストを削減することができます。


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

■Threat Modeling Toolとは

脅威モデリングを行うためのツール。Windows用。

[Microsoft Threat Modeling Tool (TMT)](https://docs.microsoft.com/ja-jp/azure/security/develop/threat-modeling-tool) を使用し、ソフトウェア アーキテクトは早い段階で潜在的なセキュリティの問題を特定し、危険を軽減することができる。

簡単な使い方:

- TMTを起動する https://aka.ms/threatmodelingtool
- Create A Model
- 画面右側のStencilから、「Azure App Service Web App」と「Azure Storage」をドラッグ・ドロップして、Diagramに入れる
- Diagram内で、Shiftを押しながら、上記2つのアイコンをクリックして選択状態にして、右クリックで「Connect」を選択
- ViewメニューのAnalysis Viewを選択
- 画面下部のThreat Listに、想定されるThreat（脅威）、「STRIDE脅威分析モデル」（[参考1](https://www.ipa.go.jp/files/000013812.pdf)）（[参考2](https://www.ffri.jp/assets/files/monthly_research/MR201609_Introduction_of_Threat_Analysis_Methods_JPN.pdf)）による分類、説明、軽減策などが表示される。
  - Ensure that communication to Azure Storage is over HTTPS. It is recommended to enable the secure transfer required option to force communication with Azure Storage to be over HTTPS. Use Client-Side Encryption to store sensitive data in Azure Storage.（Azure Storageへの通信が HTTPS を介していることを確認してください。 Azure Storageとの通信をHTTPS経由で強制するために、「[セキュリティで保護された転送が必要](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-require-secure-transfer)」オプションを有効にすることをお勧めします。 「[クライアント側の暗号化](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-client-side-encryption?tabs=dotnet)」を使用して、機密データをAzure Storageに保存します。）


### 重要な検証ポイント

開発から本番までの各段階で、セキュリティ検証を行う。

- IDEでのコード開発、プルリクエスト
- CI（ビルド、単体テスト、パッケージング）
- ステージング環境へのデプロイ

※「Pen Test」は（[ペネトレーションテスト](https://ja.wikipedia.org/wiki/%E3%83%9A%E3%83%8D%E3%83%88%E3%83%AC%E3%83%BC%E3%82%B7%E3%83%A7%E3%83%B3%E3%83%86%E3%82%B9%E3%83%88)、侵入テスト）を表している。[ドキュメントの図](https://docs.microsoft.com/ja-jp/azure/devops/migrate/security-validation-cicd-pipeline?view=azure-devops)を参照のこと。

※「Passive Pen Test」（パッシブな侵入テスト）とは、システムの可用性に影響を与えない（DoS攻撃やデータの改ざんまでは行わない）テストのこと。「Active Pen Test」（アクティブな侵入テスト）とは、実際の攻撃に近い侵入テスト。

### 継続的インテグレーション

継続的インテグレーションにおける静的コード解析とは。

Azure Pipelineに組み込んで使用することができる「静的コード解析ツール」が多数存在する。

- [SonarQube](https://marketplace.visualstudio.com/items?itemName=SonarSource.sonarqube)
- [Microsoft Security Code Analysis](https://docs.microsoft.com/ja-jp/azure/security/develop/security-code-analysis-overview)
  - 2022 年 7 月 1 日より、Microsoft Security Code Analysis (MSCA) 拡張機能は廃止される予定
- [Checkmarx](https://marketplace.visualstudio.com/items?itemName=checkmarx.cxsast)
- [BinSkim Binary Analyzer](https://github.com/microsoft/binskim)
  - [BinSkimタスク](https://docs.microsoft.com/ja-jp/azure/security/develop/security-code-analysis-customize#binskim-task)として利用できる

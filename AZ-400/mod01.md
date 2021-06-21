# モジュール1 DevOpsの計画

- DevOpsとは何か。なぜ必要なのか。
- DevOpsの導入(変革: Transformation)するには何をすればよいのか。
- DevOpsをどのプロジェクトに導入するか。
- 組織にどのようにDevOpsを導入するか。
- DevOpsのプロジェクトの成果物（新機能）をどのように顧客へリリースするか。
- Azure DevOpsとは何か。
- Azure DevOpsの組織へユーザーを追加する方法。
- GitHubとは何か。
- Azure Boardとは。
- ラボ: Azure DevOpsを使い始める
  - DevOps組織の作成
  - ユーザーの追加
  - Azure Boards

## 変革の計画 (plan for transformation)

DevOps変革(DevOps transformation): DevOpsをチームや組織（会社）に導入すること。

### DevOpsとは？

DevOpsとは何か。なぜ必要なのか。

参考: [DevOpsとはなにか](https://medium.com/@yuhattor/devops%E3%81%A8%E3%81%AF%E3%81%AA%E3%81%AB%E3%81%8B-601c68005371)

- DevOpsとは、**顧客に継続的に価値を届ける**ための、人、プロセス、テクノロジの集まり
- サイクルをなるべく早く回す。
- 各サイクルで、データに基づく学習を行う
  - [OODA(ウーダ)ループ](https://ja.wikipedia.org/wiki/OODA%E3%83%AB%E3%83%BC%E3%83%97)：Observe(観察) — Orient(判断) — Decide(決断) — Act(実行)
    - [PDCA(Plan-Do-Check-Act)との違い](https://data.wingarc.com/what-is-ooda-11126): OODAは相手の観察から始まる。PDCAは自己計画から始まる。
  - [Validated Learning](https://en.wikipedia.org/wiki/Validated_learning)
    - Skillpipeテキストでは「検証済みの学習」
    - 各サイクルで目標を設定し、アイデアを試行し、データを集め、目標に近づいたことを確認する
    - Validated Learningは、リーンスタートアップにおける考え方。
  - [リーンスタートアップ](https://ja.wikipedia.org/wiki/%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B9%E3%82%BF%E3%83%BC%E3%83%88%E3%82%A2%E3%83%83%E3%83%97)
    - 起業の方法論の一つ。
    - リーン(lean) （1）もたれる。傾く。（2）**無駄のない**。ひきしまった。
    - MVP（Minimum Viable Product）を作る。
    - MVPをアーリーアダプターに提供して意見を求める。
    - MVPを改良する。またはピボット（方向転換）する。

[DevOps (Wikipedia)](https://ja.wikipedia.org/wiki/DevOps)

[DevOps とは (Microsoft Docs)](https://docs.microsoft.com/ja-jp/devops/what-is-devops)

DevOpsの八の字のループの意味: [DevOps (Atlassian社)](https://www.atlassian.com/ja/devops)

- ループの左側: **開発**に必要なプロセス、機能、ツール
- ループの右側: **運用**に必要なプロセス、機能、ツール

DevOpsのプロセスは繰り返される（反復的）。運用からはフィードバックが得られる。フィードバックをもとに次の開発を行う。

### DevOpsの体験（実践）

DevOpsを実践するとは、具体的にどういうことなのか。

参考: [DevOpsとはなにか](https://medium.com/@yuhattor/devops%E3%81%A8%E3%81%AF%E3%81%AA%E3%81%AB%E3%81%8B-601c68005371)

- [継続的インテグレーション(CI)](https://docs.microsoft.com/ja-jp/devops/develop/what-is-continuous-integration)
  - チーム メンバーがバージョン管理 に変更をコミットするたび、コードのビルドとテストを自動的に行う
- [継続的デリバリー(CD)](https://docs.microsoft.com/ja-jp/devops/deliver/what-is-continuous-delivery)
  - ビルドされた成果物のデプロイを自動的に行う。
  - デプロイ先はステージング環境や本番環境
  - CI/CDで、エンドユーザーに対して新機能をリリースすることを[継続的デプロイ](https://azure.microsoft.com/ja-jp/overview/continuous-delivery-vs-continuous-deployment/)と呼ぶ場合もある
- バージョンコントロール
  - [Git (Wikipedia)](https://ja.wikipedia.org/wiki/Git)
  - [Gitとは (Microsoft Docs)](https://docs.microsoft.com/ja-jp/devops/develop/git/what-is-git)
  - [Microsoft Learn: Gitでのバージョンコントロール](https://docs.microsoft.com/ja-jp/learn/paths/intro-to-vc-git/)
  - [Git for Windows](https://gitforwindows.org/)
- アジャイルな計画とリーンなプロジェクト手法
  - [アジャイルソフトウェア開発宣言](https://agilemanifesto.org/iso/ja/manifesto.html)
  - [リーンスタートアップ](https://ja.wikipedia.org/wiki/%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B9%E3%82%BF%E3%83%BC%E3%83%88%E3%82%A2%E3%83%83%E3%83%97)
  - [アジャイル開発の進め方（IPA）](https://www.ipa.go.jp/files/000065606.pdf)
- モニタリング
  - [Azure Monitor](https://docs.microsoft.com/ja-jp/azure/azure-monitor/overview)
  - [Application Insights](https://docs.microsoft.com/ja-jp/azure/azure-monitor/app/app-insights-overview)
- クラウド
- IaC
  - [IaC (Microsoft Docs)](https://docs.microsoft.com/ja-jp/dotnet/architecture/cloud-native/infrastructure-as-code)
- マイクロサービスアーキテクチャ
  - [マイクロサービス アーキテクチャ (Microsoft Docs)](https://docs.microsoft.com/ja-jp/azure/architecture/guide/architecture-styles/microservices#what-are-microservices)
- コンテナー
  - [イメージとコンテナ](https://docs.docker.jp/get-started/index.html#images-and-containers)
  - [Docker とは (Red Hat社)](https://www.redhat.com/ja/topics/containers/what-is-docker)

参考: [The Twelve-Factor App](https://12factor.net/ja/): SaaSのための方法論、技術の利用原則。

### 変革チームの分離

DevOps変革(DevOps transformation)とは: DevOpsをチームや組織（会社）に導入すること。

変革のためのアドバイス: チームの分離

全社いっせいではなく、一部のチームからDevOpsを導入する。

- 既存のスタッフが変革を行うのは困難な場合が多い
  - 日常業務とDevOps変革を同時に達成するのは難しい
- DevOps変革を達成するためのチームを別に作る
  - 日常業務には関与しない
  - 高い評価を持ち、幅広い知識を持つスタッフをチームメンバーとする
  - チームに、外部のDevOps専門家を含める

### 共有目標の定義

- 測定可能な目標が必要
- 顧客に価値を届けるための目標に焦点を当てる

### 目標に向けたタイムラインの設定

長いタイムラインと短いタイムラインを設定する。

- 長いタイムライン
  - DevOps変革(DevOps transformation)には1年～2年の期間が必要である
- 短いタイムライン
  - 数週間単位での、測定可能な目標を設定し、レビューを行う
  - 必要に応じてプランや優先順位の変更を行う
  - 肯定的な結果が得られると、組織のサポートを維持しやすい

参考: [Microsoft社内におけるDevOps導入](https://medium.com/@yuhattor/microsoft-%E3%81%AE-devops-%E3%81%B8%E3%81%AE%E9%81%93%E3%81%AE%E3%82%8A-db59c0848d78)

- 2014年頃からDevOpsの導入を開始
- 2017年には、75000人の社員がDevOpsを利用（3年で約3倍に）
- Azure DevOpsという製品自体が、Azure DevOpsを使用して開発されている。
  - 3週間のスプリントを設定。
    - つまり新機能や改善が3週間ごとに出てくる
    - 3週間ごとに、**継続して、顧客に新しい価値を届ける**
  - 最初のスプリントは2010/8に開始
  - https://docs.microsoft.com/en-us/azure/devops/release-notes/features-timeline

## プロジェクトの選択

- どのようなプロジェクトにDevOpsを導入すべきか
  - グリーン vs ブラウン
  - SoR vs SoE
- DevOpsプロジェクトの成果物をどのようにリリースしていくか
  - 利用者
  - リリース粒度

### プロジェクトの種類（定義と選択）

DevOpsを、新規プロジェクト（グリーンフィールド）に導入すべきか、既存プロジェクト（ブラウンフィールド）に導入すべきか。

グリーンフィールド/ブラウンフィールド: ソフトウェアサービスや製品の分類方法の一種。もともと都市計画やビルの建築プロジェクトで使われていた用語。グリーン：草が生えた土地、ブラウン：工業目的で使われた土地。

結論：多くの組織は、DevOpsを、グリーンフィールドのプロジェクトで導入する。ただし、ブラウンフィールドで導入することも可能。

### プロジェクトで開発しているシステムの種類（記録システムとエンゲージメント システムの選択）

DevOpsを、SoRプロジェクトに導入すべきか、SoEプロジェクトに導入すべきか。

- SoR: 記録システム (System of Record)
  - 情報を正しく記録する/業務を省力化するためのシステム、いわゆる基幹システム
  - 正しい仕様が存在
  - 開発においてはスケジュールと品質が優先される
- SoE: エンゲージメントシステム (System of Engatement)
  - [ジェフリー・ムーア氏が2011年に提唱した考え方](https://www.google.com/search?q=%E3%82%B8%E3%82%A7%E3%83%95%E3%83%AA%E3%83%BC%E3%83%BB%E3%83%A0%E3%83%BC%E3%82%A2+soe)
  - ユーザーや取引先との「絆」を作るシステム
    - ショッピングサイト
    - コミュニケーションツール
    - スマホアプリ、ゲーム
    - など
  - 正しい仕様が存在しないことがある
  - 変化が早い
  - トライ&エラー

[参考](https://speakerdeck.com/naoya/system-of-record-to-system-of-engagement?slide=4)

結論：DevOpsは、SoEのプロジェクトで導入する方が容易である。ただし、DevOpsはSoRでも適用は可能。

### リリース: 利用者とリリース粒度（初期抵抗を最小限に抑えるためのグループの選択）

DevOpsの成果物（新機能）を、どのグループの利用者にリリースするか。

- カナリア: とても積極的な人々。
- アーリーアダプター: 積極的な人々。
- 一般ユーザー: 積極的ではないな人々。安定を望む。

参考：[カナリアリリース](https://www.google.com/search?q=%E3%82%AB%E3%83%8A%E3%83%AA%E3%82%A2%E3%83%AA%E3%83%AA%E3%83%BC%E3%82%B9)：新機能を一部のユーザーにリリースし、問題がないことを確認しながら段階的に全体に向けてリリースしていく。上記の「カナリア」とは、カナリアリリースのターゲットとなるユーザー。生理学者の John Scott Haldane 氏が、一酸化炭素をすばやく検出するためにカナリア（鳥）を炭鉱に連れて行ったことに由来。カナリアは一酸化炭素に弱く、カナリアを観察することで一酸化炭素の危険を素早く発見できたという。[参考](https://cloud.google.com/blog/ja/products/gcp/how-release-canaries-can-save-your-bacon-cre-life-lessons)

参考：[Azure App Configurationの「機能フラグ」](https://docs.microsoft.com/ja-jp/azure/azure-app-configuration/concept-feature-management)を利用すると、**リリースしたソフトウェアにおいて**、特定のユーザーやグループに対して、特定の機能を有効化することができる。

リリースの粒度: 新機能をどの程度の粒度でリリースするか。

- 変更を一度にリリースする（ビッグバン）
- 変更を段階的にリリースする

結論：変更は段階的にリリースしたほうがよい。大規模なリリースは失敗することが多い。

### プロジェクト メトリックと主要業績評価指標 (KPI) を識別する

DevOpsができているかどうかは、どうやって評価するか？

- メトリック: プロジェクトの活動を測定し、数値化する。
- 目標(KPI)を確立し、合意する

結論：プロジェクトのメトリックを集める。KPIを定める。

## チーム構造

チームにアジャイルソフトウェア開発を導入することは、DevOpsのプラクティスの一つ。

### アジャイル開発プラクティスの定義

ウォーターフォール型 vs アジャイル型

- ウォーターフォール型
  - 明確なフェーズがある（要件定義、設計、開発、テスト）
  - 変更は想定しない
  - プロジェクトを完了させることを重視
- アジャイル型
  - 反復的（スプリントを繰り返す）
  - 要件の変更に柔軟に対応
  - 顧客の要求に答えることを重視

**継続的に**価値を届けるにはアジャイル型が適している。

アジャイルについて学ぶ

- [アジャイルとは（Microsoft Docs）](https://docs.microsoft.com/ja-jp/devops/plan/what-is-agile)
- [アジャイル開発とは（Microsoft Docs）](https://docs.microsoft.com/ja-jp/devops/plan/what-is-agile-development)
- [アジャイルソフトウェア開発（Wikipedia）](https://ja.wikipedia.org/wiki/%E3%82%A2%E3%82%B8%E3%83%A3%E3%82%A4%E3%83%AB%E3%82%BD%E3%83%95%E3%83%88%E3%82%A6%E3%82%A7%E3%82%A2%E9%96%8B%E7%99%BA)
- [アジャイル手法](https://www.microsoft.com/ja-jp/microsoft-365/business-insights-ideas/resources/how-to-choose-the-best-agile-methodology-for-your-project)


参考: [Microsoft Officeは、20年間、ウォーターフォール型で開発されていた](https://codezine.jp/article/detail/7677)

- プランを立ててから動くものができるまで1年、外部へのリリースに1年かかっていた
- プランの誤りや、プラットフォームやデバイスの変化により、開発したものが無駄になるリスクが増大
- 2013年頃に、アジャイル型に転換
- （現在）Microsoft は、世界最大規模のアジャイル企業の1つ


### アジャイルの原則

アジャイル開発のマインドセット（心構え）。

- [アジャイルソフトウェア開発宣言](https://agilemanifesto.org/iso/ja/manifesto.html)
- [アジャイル宣言の背後にある原則](https://agilemanifesto.org/iso/ja/principles.html)

- [アジャイルソフトウェア開発宣言の読みとき方(IPA: 情報処理推進機構)](https://www.ipa.go.jp/files/000065601.pdf)

### 組織構造

水平型チームと垂直型チームとは。

- 水平型
  - 役割別のチーム
  - デザインチーム(UI)、アプリ開発チーム(API)、DBチーム(Data)、など
- 垂直型
  - 製品別のチーム
  - 製品Aのチーム、製品Bのチーム、製品Cのチーム、など

垂直型のメリット
- より大きい成果を提供できる
- チームを追加することでスケーリングできる
  - 機能別のチームなど

[Microsoftでのチーム構成の事例](https://docs.microsoft.com/ja-jp/devops/plan/how-microsoft-plans-devops#makeup-of-teams)

- 以前は水平型だった
- 現在は垂直型をめざしている

### 理想的な チーム メンバー

アジャイル開発における理想的なチームメンバーとは。

- DevOpsの必要性を理解している
- 変革の必要性を感じ、変革する力を持っている
- 組織内で尊敬を集めている
- 組織内で幅広い知識を持つ

### チームメンバーの指導

チームメンバーをどうやって教育するか。

- トレーニングは望ましいが、実践がより重要である
- 多くのチームが外部のコーチやメンターを雇う
- 時間が経つにつれて、チーム メンバーがお互いを指導する能力を身に着ける

### チームのコラボレーション

アジャイルに適した仕事のスタイル。

- 不要な会議を減らす
- チャットなど、非同期的なコミュニケーションを活用する
- タスクに集中できる時間をつくる
- リモートワークに対応する
- ヒューマンスキルのトレーニングもあるとよい

機能横断型チームとは。

- クロスファンクショナルチーム（CFT）とも
- 部門の枠を超えたチーム
- 部署や役職にとらわれない
- 場合によっては社外からも必要な人材を集めて構成
- [スクラム](https://docs.microsoft.com/ja-jp/devops/plan/what-is-scrum)のチーム
  - https://scrumguides.org/docs/scrumguide/v2020/2020-Scrum-Guide-US.pdf
  - スクラムのチームはクロスファンクショナルチーム
  - チームは、各スプリントで価値を創造するスキルを持つ


### ツール

コラボレーションに使うことができるツール

- Teams
- Slack
- その他

アジャイルプラクティスのためのツール

- Azure DevOps
- GitHub
- その他


## DevOpsへの移行

### Azure DevOps でできること

https://azure.microsoft.com/ja-jp/services/devops/



- [Azure DevOpsの概要](pdf/Azure%20DevOpsの概要.pdf)
- [Azure DevOpsの機能の連携](pdf/Azure%20DevOps機能の連携.pdf)

```
Azure DevOpsの画面 (dev.azure.com)
└Azure DevOps組織 ←ユーザー
 └プロジェクト - 概要, wiki, dashboard
  ├Azure Boards - 「エピック」,「作業項目」,「タスク」
  ├Azure Repos リポジトリ
  ├Azure Pipelines パイプライン
  └Azure Artifacts フィード
※ユーザー：Azure ADユーザー, Microsoftアカウント, GitHubアカウント
```

### GitHub でできること

https://github.co.jp/features

### 認可およびアクセス戦略の設計

#### 開発者がAzure DevOps/GitHubにサインインのためのアカウント

- Azure DevOps Services
  - Microsoft アカウント、GitHub アカウント、または Azure Active Directory (AAD) のいずれかを使用
- GitHub
  - GitHubアカウントを使用

#### 外部のサービスやツールがAzure DevOpsにアクセスするための認証

- Azure DevOps
  - [SSH認証](https://docs.microsoft.com/ja-jp/azure/devops/repos/git/use-ssh-keys-to-authenticate)
  - [Git Credential Manager コア](https://docs.microsoft.com/ja-jp/azure/devops/repos/git/set-up-credential-managers)
  - 個人用アクセストークン（PAT: Personal Access Token）
    - 外部ツールからAzure DevOpsに接続する場合に利用することがある。
    - 例：[GitHub Desktop](https://desktop.github.com/) から、[Azure DevOpsに接続](https://blog.beachside.dev/entry/2021/05/17/083000)
- GitHub
  - 個人用アクセストークン（PAT: Personal Access Token）
    - GitHub API またはコマンドラインを使用するときに GitHub への認証でパスワードの代わりに使用
    - https://docs.github.com/ja/github/authenticating-to-github/keeping-your-account-and-data-secure/creating-a-personal-access-token


#### Azure DevOpsのセキュリティグループ

ユーザーがAzure DevOps内で実行可能な操作は、[セキュリティグループ](https://docs.microsoft.com/ja-jp/azure/devops/organizations/security/change-individual-permissions)で設定できる。デフォルトのセキュリティグループが定義されている。カスタムのセキュリティグループも定義可能。

たとえば「共同作成者」セキュリティグループのメンバーであるユーザーは、プロジェクトの Wiki ページを追加または編集することができる。

- 組織レベルの設定
  - Azure DevOps / Project Settings / Neneral - Permissions / Groups
- プロジェクトレベルの設定
  - Azure DevOps / Organization Settings / Security - Permissions / Groups

#### 多要素認証

※Azure DevOpsの機能ではなく、Azure ADの機能。

Azure ADのユーザーは、Azure ADを使用してサインインを完了し、Azure DevOpsにアクセスする。

ユーザーがAzure ADにサインインする際に[Azure AD の MFA](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/howto-mfa-getstarted)を利用することを強制することができる。


### 既存の作業管理ツールの移行または統合

[Azure DevOps 拡張機能](https://marketplace.visualstudio.com/) では、[既存の作業管理ツールとの移行/統合のための拡張機能](https://marketplace.visualstudio.com/search?term=migration&target=AzureDevOps&category=All%20categories&sortBy=Relevance)が提供されている。

- [Trello](https://trello.com/ja) - かんばんツール
  - [Trello と Azure DevOps Boardの統合](https://marketplace.visualstudio.com/items?itemName=ms-vsts.services-trello)
- [Jira](https://www.atlassian.com/ja/software/jira) - プロジェクト管理ツール
  - [JiraからAzure DevOps Boardへの「作業項目（Work Item）」の移行](https://marketplace.visualstudio.com/items?itemName=solidify.jira-devops-migration)
- など

### 既存のテスト管理ツールの移行または統合

[Azure DevOps 拡張機能](https://marketplace.visualstudio.com/) では、[既存のテスト管理ツールとの連携するための拡張機能](https://marketplace.visualstudio.com/search?term=test&target=AzureDevOps&category=All%20categories&sortBy=Relevance)が提供されている。

- [Apache JMeter](https://jmeter.apache.org/)
  - [JMeter](https://marketplace.visualstudio.com/items?itemName=AlexandreGattiker.jmeter-tasks)
- [Pester](https://github.com/pester/Pester)
  - [Pester Test Runner Build Task](https://marketplace.visualstudio.com/items?itemName=richardfennellBM.BM-VSTS-PesterRunner-Task)
- など

### ライセンス管理戦略の設計

Azure DevOpsとGitHubの価格は公式サイトで確認。

#### Azure DevOps

https://azure.microsoft.com/ja-jp/pricing/details/devops/azure-devops-services/

Azure DevOps Servicesの価格

- Basic
  - 最初の5名まで無料
  - 6名以降は、672 円/ユーザー/月
- Basic + Test
  - すべてのBasic機能＋テスト機能
  - 5,824 円/ユーザー/月

■ユーザーの追加(招待)

Azure DevOpsでは、以下の種類のユーザーを追加(招待)することができる。

- 「Azure DevOps組織」がAzure ADに接続されている場合:
  - Azure ADユーザー(組織のユーザー)のメールアドレス
- 「Azure DevOps組織」がAzure ADに接続されていない場合:
  - 個人のMicrosoftアカウントのメールアドレス
  - GitHubユーザー名

```
Azure Active Directory (Azure AD)を使用してユーザーを認証し、組織のアクセスを制御する予定がない場合は、GitHub アカウントの個人用 Microsoft アカウントと id の電子メールアドレスを追加します。 ユーザーが Microsoft または GitHub のアカウントを持っていない場合は、 Microsoft アカウント または github アカウントにサインアップするようにユーザーに依頼します。
```

■具体的な追加の流れ
- [メンバーの追加（招待）](pdf/メンバーの追加（招待）.pdf)
  - 組織にメンバーを追加する方法

参考
- [チームメンバーの招待](https://docs.microsoft.com/ja-jp/azure/devops/user-guide/sign-up-invite-teammates?view=azure-devops#invite-team-members)
- [Azure DevOpsにおけるユーザーの管理](https://docs.microsoft.com/ja-jp/azure/devops/organizations/accounts/add-organization-users?view=azure-devops&tabs=preview-page)

##### Azure DevOps の地域

Azure DevOps は次の「地域」で利用できる。

- オーストラリア
- ブラジル
- カナダ
- ヨーロッパ
- インド
- イギリス
- 米国
- アジア太平洋
  - 2021年3月まで: East Asia (香港)
  - 2021年3月以降: Southeast Asia (シンガポール) に順次移行

■地域の指定

組織の作成時に、地域を指定できる。

地域の変更は画面上からはできないが、以下の画面から問い合わせを行って変更することができる。

https://azure.microsoft.com/ja-jp/support/devops/

■アジア太平洋の移行について

2021年3月以降、アジア太平洋のすべての Azure DevOps 組織とその関連するサービス資産を、東アジアリージョン (香港) から東南アジアリージョン (シンガポール) に移行する予定。

この移行によるパフォーマンス影響はなく、ユーザー側で実施すべきことはない。

https://docs.microsoft.com/ja-jp/azure/devops/migrate/migration?view=azure-devops

#### GitHub

https://github.co.jp/pricing.html

- Free
- Team: $4 /ユーザー/月
- Enterprise: $21 /ユーザー/月

## Azure Board

- [Azure Boards.pdf](pdf/Azure%20Boards.pdf)
  - Azure Boardsの解説

## ラボ（ハンズオン演習）

- [Azure DevOpsの使用を開始する](pdf/Azure%20DevOpsの使用を開始する.pdf)
  - 組織とプロジェクトを作成する

- GitHubアカウントの作成
  - [作成手順](../prep/github.md)

- 基本編: Microsoft Learn: [ソフトウェア開発にアジャイル アプローチを選ぶ](https://docs.microsoft.com/ja-jp/learn/modules/choose-an-agile-approach/) のユニット3～4に沿って、Azure Boardを使ってみましょう。
  - Azure Board
    - プロジェクトの作成
    - チームの作成
    - チームメンバーの追加
    - 作業項目の追加
    - スプリントの定義
    - 作業項目の所有者（Owner）の設定
  - ユニット4が終わったら、プロジェクトや、組織に追加したユーザーは削除します。

- 応用編(英語のみ、オプション): Azure DevOps Labs: [Agile Planning and Portfolio Management with Azure Boards](https://azuredevopslabs.com//labs/azuredevops/agile/)
  - Edgeブラウザの翻訳機能でページの翻訳ができます。
  - または、[Google翻訳](https://translate.google.co.jp/?hl=ja&sl=auto&tl=en&op=translate)や[Bing翻訳](https://www.bing.com/translator?to=ja&setlang=ja)の左側のテキストボックスにアクセス先のサイトのURLを貼り付けると、翻訳されたページが表示されます。
  - Azure Board
    - エリア
    - ダッシュボード
    - Epicの作成
    - キャパシティ
    - Boardのカスタマイズ
    - ダッシュボードの作成
    - プロセスのカスタマイズ


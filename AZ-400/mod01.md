# DevOpsの計画

- DevOpsとはなにか。なぜ必要なのか。
- DevOpsの導入(変革: Transformation)のためのヒント。

## 変革の計画 (plan for transformation)

DevOps変革(DevOps transformation): DevOpsをチームや組織（会社）に導入すること。

### DevOpsとは？

DevOpsとはなにか。なぜ必要なのか。

参考: [DevOpsとはなにか](https://medium.com/@yuhattor/devops%E3%81%A8%E3%81%AF%E3%81%AA%E3%81%AB%E3%81%8B-601c68005371)

- DevOpsとは、**顧客に継続的に価値を届ける**ための、人、プロセス、テクノロジの集まり
- サイクルをなるべく早く回す。
- 各サイクルで、データに基づく学習を行う
  - [Validated Learning](https://en.wikipedia.org/wiki/Validated_learning)
  - [リーン(無駄のない)スタートアップ](https://ja.wikipedia.org/wiki/%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B9%E3%82%BF%E3%83%BC%E3%83%88%E3%82%A2%E3%83%83%E3%83%97)

[DevOps (Wikipedia)](https://ja.wikipedia.org/wiki/DevOps)

[DevOps とは (Microsoft Docs)](https://docs.microsoft.com/ja-jp/devops/what-is-devops)

DevOpsの八の字のループの意味: [DevOps (Atlassian社)](https://www.atlassian.com/ja/devops)

- ループの左側: **開発**に必要なプロセス、機能、ツール
- ループの右側: **運用**に必要なプロセス、機能、ツール

無限ループとなっていて、プロセスが繰り返されることを表している。運用からはフィードバックが得られる。フィードバックをもとに次の開発を行う。

### DevOpsの体験

DevOpsを実践するとは、具体的にどういうことなのか。

参考: [DevOpsとはなにか](https://medium.com/@yuhattor/devops%E3%81%A8%E3%81%AF%E3%81%AA%E3%81%AB%E3%81%8B-601c68005371)

- [継続的インテグレーション](https://docs.microsoft.com/ja-jp/devops/develop/what-is-continuous-integration)
- [継続的デリバリー](https://docs.microsoft.com/ja-jp/devops/deliver/what-is-continuous-delivery)
- バージョンコントロール
  - [Git (Wikipedia)](https://ja.wikipedia.org/wiki/Git)
  - [Gitとは (Microsoft Docs)](https://docs.microsoft.com/ja-jp/devops/develop/git/what-is-git)
  - [Microsoft Learn: Gitでのバージョンコントロール](https://docs.microsoft.com/ja-jp/learn/paths/intro-to-vc-git/)
  - [Git for Windows](https://gitforwindows.org/)
- アジャイルな計画とリーンなプロジェクト手法
  - [アジャイルソフトウェア開発宣言](https://agilemanifesto.org/iso/ja/manifesto.html)
  - [リーンスタートアップ](https://ja.wikipedia.org/wiki/%E3%83%AA%E3%83%BC%E3%83%B3%E3%82%B9%E3%82%BF%E3%83%BC%E3%83%88%E3%82%A2%E3%83%83%E3%83%97)
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

### 変革チームの分離

DevOps変革(DevOps transformation): DevOpsをチームや組織（会社）に導入すること。

変革のヒント:

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

- 長いタイムライン
  - DevOps変革(DevOps transformation)には1年～2年の期間が必要である
- 短いタイムライン
  - 数週間単位での、測定可能な目標を設定し、レビューを行う
  - 必要に応じてプランや優先順位の変更を行う
  - 肯定的な結果が得られると、組織のサポートを維持しやすい

参考: [Microsoft社内におけるDevOps導入](https://medium.com/@yuhattor/microsoft-%E3%81%AE-devops-%E3%81%B8%E3%81%AE%E9%81%93%E3%81%AE%E3%82%8A-db59c0848d78)

- 2014年頃からDevOpsの導入を開始
- 2017年には、75000人の社員がDevOpsを利用（3年で約3倍に）
- Azure DevOps自体が、Azure DevOpsを使用して開発されている。
  - 3週間のスプリントを設定。
    - つまり新機能や改善が3週間ごとに出てくる
    - 3週間ごとに、**継続して、顧客に新しい価値を届ける**
  - 最初のスプリントは2010/8に開始

## プロジェクトの選択

- どのようなプロジェクトにDevOpsを導入すべきか
  - グリーン vs ブラウン
  - SoR vs SoE
- DevOpsプロジェクトの成果物をどのようにリリースしていくか
  - 利用者
  - リリース粒度

### プロジェクトの種類

DevOpsを、新規プロジェクト（グリーンフィールド）に導入すべきか、既存プロジェクト（ブラウンフィールド）に導入すべきか。

グリーンフィールド/ブラウンフィールド: ソフトウェアサービスや製品の分類方法の一種。もともと都市計画やビルの建築プロジェクトで使われていた用語。グリーン：草が生えた土地、ブラウン：工業目的で使われた土地。

### プロジェクトで開発しているシステムの種類

DevOpsを、SoRプロジェクトに導入すべきか、SoEプロジェクトに導入すべきか。

- SoR: 記録システム (System of Record)
  - 情報を正しく記録するためのシステム
  - 正しい仕様が存在
  - スケジュールと品質が優先
- SoE: エンゲージメントシステム (System of Engatement)
  - ユーザーや取引先との「絆」を作るシステム
  - 正しい仕様が存在しない
  - トライ&エラー

[参考](https://speakerdeck.com/naoya/system-of-record-to-system-of-engagement?slide=4)

### リリース: 利用者とリリース粒度

DevOpsの成果物（製品やサービス）を、どのグループの利用者にリリースするか。

- カナリア: 開発版を利用
- アーリーアダプター: 最新の安定版を利用
- 一般ユーザー: 安定版を利用

リリースの粒度: 新機能をどの程度の粒度でリリースするか。

- 変更を一度にリリースする
- 変更を段階的にリリースする

### プロジェクト メトリックと主要業績評価指標 (KPI) を識別する

- メトリック: プロジェクトの活動を測定し、数値化する。
- 目標(KPI)を確立し、合意する

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

どちらも、顧客に価値を届けるためのものだが、**継続的に**価値を届けるにはアジャイル型が適している。

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
  - 役割別
  - デザインチーム、アプリ開発チーム、DBチーム、など
- 垂直型
  - 製品
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
  - チームは、各スプリントで価値を想像するスキルを持つ


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
## ラボ
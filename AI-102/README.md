# AI-102

Designing and Implementing a Microsoft Azure AI Solution（Microsoft AI ソリューションの設計と実装）

https://learn.microsoft.com/ja-jp/training/courses/ai-102t00

4日間

Azure AI Services（旧 Azure Cognitive Services）、Azure AI Search（旧 Azure AI Search）、および Microsoft Bot Framework を利用して、AIを組み込んだアプリケーションを構築したいソフトウェア開発者を対象としています。

なお、4日目の内容はコース「AI-050」と同じです。

<!--
> ※AI-100:
> https://docs.microsoft.com/ja-jp/learn/certifications/exams/ai-100
> 2021年6月30日に廃止
-->

# 認定試験

https://learn.microsoft.com/ja-jp/certifications/exams/ai-102

Microsoft Certified: Azure AI Engineer Associate: アソシエイトレベル

AIエンジニアの認定パス
https://learn.microsoft.com/ja-jp/certifications/roles/ai-engineer


# 講義ノート

■オープニング

- [トレーニングご受講方法のご案内](../opening.md)

■1日目

テーマ: AzureのAIサービスの全体像を理解する。

- AzureのAI/Machine Learningサービスの概要
  - [ラーニングパス01 AI エンジニアリングへの準備](lp01.md)
- Azure AI Services の基礎知識
  - [ラーニングパス02 Azure AI Services のプロビジョニングと管理](lp02.md)

ラボ(オプション)
- [インタラクティブラボシミュレーション(※おすすめ)](https://mslabs.cloudguides.com/guides/AI-102%20Lab%20Simulations%20-%20Designing%20and%20implementing%20a%20Microsoft%20Azure%20AI%20solution)
  - 1 Get started with Azure Cognitive Services
  - 2 Manage Cognitive Services security
  - 3 Monitor Cognitive Services
  - 4 User a Cognitive Services container
- [ラボ環境(※難しい)](https://esi.learnondemand.net/User/Login)
  - [ラボ環境の利用方法](../ラボ環境の利用方法.pdf)
  - ※トレーニングキーは、講師より連絡いたします
  - ※トレーニングキーの入力はトレーニング期間中に実施する必要があります
  - ※ラボ環境はご受講より半年後までご利用いただけます
  - 1 Get Started with Azure AI Services (JA) / Azure AI サービスの使用を開始する

■2日目

テーマ(1): Azure AI Servicesに含まれる言語と音声のサービスを理解する。
- Azure AI Services ＞ 言語(Language API) ＞ 翻訳
  - [ラーニングパス03 Azure AI Services を使用してテキストを処理して翻訳する](lp03.md)
- Azure AI Services ＞ 音声(Speech API)
  - [ラーニングパス04 Azure AI Speech Services を使用し、音声を処理して翻訳する](lp04.md)
- Azure AI Services ＞ 言語(Language API) ＞ 会話言語理解（CLU）
  - [ラーニングパス05 Azure AI Services を使用して会話言語理解ソリューションを作成する](lp05.md)
- Azure AI Services ＞ 言語(Language API) ＞ 質問応答
  - [ラーニングパス06 質問応答ソリューションを構築する](lp06.md)
- Azure AI Services ＞ 言語(Language API) > カスタム テキスト分類
  - [ラーニングパス07 カスタム テキスト分析ソリューションを構築する](lp07.md)

テーマ(2): Azureのチャットボットのサービス、チャットボットの作成方法を理解する。

- Azure Bot Service
  - [ラーニングパス08 会話 AI ソリューションを作成する](lp08.md)

ラボ(オプション)

- [インタラクティブラボシミュレーション](https://mslabs.cloudguides.com/guides/AI-102%20Lab%20Simulations%20-%20Designing%20and%20implementing%20a%20Microsoft%20Azure%20AI%20solution)
  - 5 Analyze text
  - 6 Translate text
  - 7 Recognize and synthesize speech
  - 8 Translate speech
  - 9 Create a conversational language understanding model
  - 10 Create a Language service client application
  - 11 Use speech and Language Understanding services
  - 12 Create a question answering solution
  - 13 Create a bot with the Bot Framework SDk
  - 14 Create a bot with Bot Framework Composer
- [ラボ環境](https://esi.learnondemand.net/User/Login)
  - 5 Analyze Text (JA) / テキストの分析
  - 6 Create a Question Answering Solution (JA) / 質問応答ソリューションを作成する
  - 7 Create a language understanding model with the Language service (JA) / 言語サービスで言語理解モデルを作成する

■3日目

テーマ(1): Azure AI Servicesに含まれる画像/動画のサービスの利用方法を理解する。

- Azure AI Services ＞ 画像(Vision API)
  - [ラーニングパス09 Azure AI Services でコンピューター ビジョン ソリューションを作成する](lp09.md)
- Azure AI Services ＞ 画像(Vision API) ＞ 光学式文字認識(OCR)
  - [ラーニングパス10 画像およびドキュメントからテキストを抽出する](lp10.md)
- [Azure AI Video Indexer]([azure-ai-video-indexer.md](../AI-3004-vision/lp05-analyze-video.md)

テーマ(2): ドキュメント（PDFなど）に対する検索を行うサービスの利用方法を理解する。

- Azure AI Search
  - [ラーニングパス11 Azure AI Search でのナレッジ マイニングの実装](lp11.md)

<!--
おまけ: [Azure OpenAI Serviceの「on your data」（内部でAzure AI Searchを使用）](../AI-050-2024/pdf/AI-050-mod6-onyourdata.pdf)
-->

テーマ(3): その他のAzure AIサービスについて概要を理解する

- [Azure AI Content Moderator / Azure AI Content Safety](azure-ai-content-moderator.md)
- [Azure AI Personalizer(※廃止予定)](azure-ai-personalizer.md)
- [Azure AI Document Intelligence](azure-ai-document-intelligence.md)
- [Azure AI Immersive Reader](azure-ai-immersive-reader.md)

ラボ(オプション)
- [インタラクティブラボシミュレーション](https://mslabs.cloudguides.com/guides/AI-102%20Lab%20Simulations%20-%20Designing%20and%20implementing%20a%20Microsoft%20Azure%20AI%20solution)
  - 15 Analyze images with Computer Vision
  - 16 Analyze video with Azure Video Indexer
  - 17 Classify images with Custom Vision
  - 18 Detect objects in images with Custom Vision
  - 19 Detect and analyze faces
  - 20 Read text in images
  - 21 Extract data from forms
  - 22 Create an Azure Cognitive Search solution
  - 23 Create a custom skill for Azure Cognitive Search
  - 24 Create a knowledge store with Azure Cognitive Search
- [ラボ環境](https://esi.learnondemand.net/User/Login)
  - 2 Analyze Images with Azure AI Vision (JA) / Azure AI Vision を使用して画像を分析する
  - 3 Read Text in Images (JA) / 画像内のテキストの読み取り
  - 4 Classify images with a Azure AI Vision custom model (JA) / Azure AI Vision カスタム モデルを使用して画像を分類する
  - 8 Recognize and synthesize speech (JA) / 音声の認識と合成
  - 12 Create a Custom Skill for Azure AI Search (JA) / Azure AI Search のカスタム スキルを作成する
  - 13 Extract Data from Forms (JA) / フォームからデータを抽出する


■4日目

テーマ: Azure OpenAI Service（生成AI）について理解する（コース AI-050と同じ内容です）

- Azure OpenAI Service
  - [AI-050](../AI-050-2024/README.md)

ラボ(オプション)
- [インタラクティブラボシミュレーション](https://mslabs.cloudguides.com/guides/AI-102%20Lab%20Simulations%20-%20Designing%20and%20implementing%20a%20Microsoft%20Azure%20AI%20solution)
  - Azure OpenAI> 1. Get started with Azure OpenAI Service
  - Azure OpenAI> 2. Build natural language solutions with Azure OpenAI Service
  - Azure OpenAI> 3. Apply prompt engineering with Azure OpenAI Service
  - Azure OpenAI> 4. Generate code with Azure OpenAI Service
  - Azure OpenAI> 5. Generate images with Azure OpenAI Service
  - Azure OpenAI> 6. Use your own data with Azure OpenAI Service
  - Azure OpenAI> Explore content filters in Azure OpenAI Service
- [ラボ環境](https://esi.learnondemand.net/User/Login)
  - 9 Integrate Azure OpenAI into your app (JA) / Azure OpenAI をアプリに統合する
  - 10 Utilize prompt engineering in your app (JA) / アプリでプロンプト エンジニアリングを利用する
  - 11 Use your own data with Azure OpenAI (JA) / Azure OpenAI で独自のデータを使用する
  - ※9,10,11の手順書は以下をご参照ください
    - https://microsoftlearning.github.io/mslearn-openai/
    - 9 → Use Azure OpenAI SDKs in your app
    - 10 → Utilize prompt engineering in your app
    - 11 → Implement Retrieval Augmented Generation (RAG) with Azure OpenAI Service


■クロージング

- [このコースで学習したサービス・機能のまとめ](matome.md)
- [AI-102 試験対策](exam.md)
  - ※AI-050 (Azure OpenAI Services)だけの認定試験はありません。
  - ※Azure OpenAI ServicesはAI-102の出題範囲の一部です。
- [クロージング(終了時のご案内)](../closing-cloudslice.md)
- アンケート

<!--
※おまけ（AI-102範囲外、時間があれば解説）
- [Microsoft Security Copilot](../microsoft-security-copilot/microsoft-security-copilot.md) (セキュリティ専門家を支援するAIアシスタント, 2023/3/28～)
-->


<!--
# ラボ

■ ラボ手順書

英語版（最新。ブラウザの翻訳機能で日本語化して閲覧できます）
https://github.com/MicrosoftLearning/AI-102-AIEngineer

日本語翻訳版（若干古い可能性があります）
https://github.com/MicrosoftLearning/AI-102-AIEngineer.ja-jp

ラボのファイル（ダウンロードして展開すると Allfiles フォルダ以下にラボで使用するファイルがあります）
https://github.com/MicrosoftLearning/AI-102-AIEngineer/archive/refs/heads/master.zip

■ ラボの概要

- ラボ01 AI Servicesを使用する(言語の検出)
- ラボ02 セキュリティ
- ラボ03 モニタリング
- ラボ04 コンテナー
- ラボ05 テキスト分析（感情分析・キーフレーズ抽出）
- ラボ06 翻訳
- ラボ07 スピーチ
- ラボ08 スピーチ翻訳
- ラボ09 LUISアプリ
- ラボ10 LUISクライアント
- ラボ11 LUISスピーチ
- ラボ12 QandA
- ラボ13 ボット(TimeBot)の作成(Bot Framework Emulatorを使用)
- ラボ14 ボット(WeatherBot)の作成(Bot Framework Composerを使用)
- ラボ15 コンピュータビジョン
- ラボ16 ビデオインデクサー
- ラボ17 イメージ分類
- ラボ18 オブジェクト検出
- ラボ19 フェース
- ラボ20 OCR
- ラボ21 カスタムフォーム
- ラボ22 検索ソリューションの開発
- ラボ23 カスタムサーチスキル
- ラボ24 ナレッジストア
-->

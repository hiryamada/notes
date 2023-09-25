# AI・LLMメモ

■一般知識

- [「埋め込みモデル」について](embeddings.md)
  - どのようなものか？どうやって使うのか？
  - 文書のベクトル化
  - コサイン類似度
- [「基盤モデル」(fundation models)について](foundation-models.md)
  - (Amazon BedrockなどではLLMではなく「基盤モデル」という言い方をしている)
  - LLMとは何が違うのか？
- [グラウンディング（接地）について](grounding.md)
  - 記号（symbol）を現実世界に接地（ground）する（ことができない）問題
- [RAG (Retrieval Augmented Generation 検索拡張生成)について](rag.md)
  - ナレッジベースの外部化パターン
  - LLM に根拠の情報 (e.g. 独自データに対する検索、Web 検索、等) に基づかせて回答を行うこと
- [生成AIによる動画の処理(動画の説明文の生成)](youtube.md)

■OpenAI社

- [OpenAI社について](openai.md)
- [ChatGPTについて](chatgpt.md)
  - ChatGPTとはなにか？
  - Azure で ChatGPTは動くのか？
- [GPTのようなLLMを構築するためのインフラ（スーパーコンピューター）について](infra.md)
- [Code Interpreter](code-interpreter.md)
  - OpenAI の ChatGPT の機能。

■マイクロソフト

- [検索エンジン Microsoft Bingについて](bing.md)
  - GPT4のカスタマイズモデルを使用
- [「コパイロット」について](copilot.md)
  - どんな「コパイロット」があるのか？
  - マイクロソフト製品で生成AIがどのように使われているのか？
- [GPTの独占的ライセンス契約について](license.md)
  - （GPT-4については情報がない）

■Azure OpenAI Service

- [コンテンツフィルター](content-filter.md)
  - 禁止ワードを含む回答を出力しないようにする
- [function calling](function-calling.md)
  - モデルの外にある外部を呼び出す機能
- [On your data](on-your-data.md)
  - 外部データに対する検索が用意に。
  - RAGパターンを素早く実装。
- Whisper APIの利用
  - [2023/9 public preview](https://learn.microsoft.com/en-us/azure/ai-services/openai/whats-new#whisper-public-preview)
  - [手順](https://learn.microsoft.com/ja-jp/azure/ai-services/openai/whisper-quickstart?tabs=command-line)

■画像生成AI

- [画像生成AI](graphics-ai.md)
  - 入力されたテキストから画像を生成
  - Stable Diffusionなど
  - イラスト風、実写（写真）風、絵画風、アニメ風などいろいろ生成できる
  - 一般ユーザー向けアプリ（モバイルアプリ等）もたくさんある

■音楽・サウンド生成AI

- [音楽・サウンド生成AI](sound-ai.md)

■一般ユーザー向けアプリケーション

- [ノート系アプリでの利用](noteapps.md)
- [CRM(顧客関係管理)での利用](crm.md)

■開発者向けツール・ライブラリ・フレームワーク等

- [IDE/エディターからの利用](editors.md)
- [LLMを活用するためのフレームワーク](frameworks.md)
- [Open Interpreter](open-interpreter.md)
  - ※ChatGPTのCode Interpreterとは別のもの。


■AIエンリッチメントとは

https://learn.microsoft.com/ja-jp/azure/search/cognitive-search-concept-intro

生の形式ではフルテキスト検索ができない（難しい）コンテンツをAIで処理し、検索を可能にすること。コンテンツの有用性が高まる。

たとえば、PDFの中に含まれる画像について、Azure AI の Computer Visionを使用して説明文を生成することで、テキストによる検索が可能となる。

また、検索対象ドキュメントに含まれる「人」「場所」「価格」などの情報（エンティティ）を、Azure AI の LanguageサービスのNER（Named Entity Recognition）を使用して抽出することで、より正確な検索が実行できるようになる。

■スキル

AIエンリッチメントを実行するしくみ。

- 組み込みスキル
  - すぐに使用できる、Microsoftが提供するスキル。
  - https://learn.microsoft.com/ja-jp/azure/search/cognitive-search-predefined-skills
- カスタムスキル
  - 外部でホストされるスキル。
  - https://learn.microsoft.com/ja-jp/azure/search/cognitive-search-custom-skill-interface
- ユーティリティスキル
  - Azure AI Search の内部にあるスキル
  - 外部リソースや送信接続に依存しない
  - ほとんどのユーティリティスキルは課金対象外
  - 例(2023/11に追加された最新のユーティリティスキル):
    - [Azure OpenAI 埋め込みスキル (プレビュー)](https://learn.microsoft.com/ja-jp/azure/search/cognitive-search-skill-azure-openai-embedding)
    - [テキスト分割スキル (プレビュー)](https://learn.microsoft.com/ja-jp/azure/search/cognitive-search-skill-textsplit)

■Azure AI Search Power Skills

デプロイしてすぐに使えるカスタムスキル集。

https://github.com/Azure-Samples/azure-search-power-skills

■スキルセット

https://learn.microsoft.com/ja-jp/azure/search/cognitive-search-defining-skillset

複数のスキルの集まり。

スキル1→スキル2→スキル3といったように複数のスキルを連携させて複雑なエンリッチメントを実行できる。



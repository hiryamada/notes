# スキル

Azure AI Searchで提供されるスキル
https://learn.microsoft.com/ja-jp/azure/search/cognitive-search-predefined-skills

スキルセットを作成する
https://learn.microsoft.com/ja-jp/azure/search/cognitive-search-defining-skillset

## AIエンリッチメント

AIによるデータの「強化」。

AIを使用してデータの質を向上させる。

## スキル

スキルは、コンテンツを何らかの方法で変換するアトミック操作を提供する。

スキルは、多くの場合はテキストを認識または抽出する。

## スキルの種類

- 組み込みスキル
  - Azure AIサービスを呼び出すスキルなど
  - モデルはトレーニングできない
- カスタムスキル
  - Azure AI Searchの外部で実行されるカスタムコード
  - URIを介してアクセス
  - 多くの場合Azure Functionsで実装される
- ユーティリティスキル
  - Azure AI Search でのみ実行され、主にエンリッチメント キャッシュ内のノードで反復処理を行う
  - ほとんどが課金対象ではない。
  - データの分割、結合、条件分岐など。
    - 例外は Microsoft.Skills.Util.DocumentExtractionSkill	（ファイルからコンテンツを抽出）

一部のスキルは非推奨となっている。
https://learn.microsoft.com/ja-jp/azure/search/cognitive-search-skill-deprecated

## 組み込みスキルの例

Azure AI ServiceやAzure OpenAI Serviceを呼び出す。

- Azure AIを呼び出すスキル
  - Microsoft.Skills.Vision.ImageAnalysisSkill
  - Microsoft.Skills.Text.V3.SentimentSkill
  - Microsoft.Skills.Text.TranslationSkill
  - 他多数
- Azure OpenAIを呼び出すスキル
  - Microsoft.Skills.Text.AzureOpenAIEmbeddingSkill

## カスタムスキル

カスタム スキルはWeb APIやAzure Machine Learning モデルをラップする。

- Microsoft.Skills.Custom.WebApiSkill
  - Web APIを呼び出す
- Microsoft.Skills.Custom.AmlSkill
  - Azure Machine Learning モデルに接続する

## カスタムスキルのホスティング

https://learn.microsoft.com/ja-jp/training/modules/build-form-recognizer-custom-skill-for-azure-cognitive-search/3-build-custom-skill

カスタム スキルは Web API サービスであるため、それをホストする方法には多くの選択肢があります。 たとえば、Azure 内でスキルをホストする場合は、スキルを次のものとしてホストできます。

- Azure Functions
- Azure Container Instance (ACI) サービスのコンテナー
- Azure Kubernetes Services (AKS) のコンテナー


## スキルセット

画像ファイル上のテキストや 光学式文字認識 (OCR) の翻訳など、エンリッチメントを実行する 1 つ以上の "スキル" の配列。

スキルはスキルセットに入れることができる。

スキルセットは、インデクサーにアタッチされる。

スキルは、独立して並列に実行することも、あるスキルの出力を別のスキルにフィードする場合は順番に実行することもできる。

たとえばスキル1で長文テキストを5000バイトごとのページに区切り、スキル2では各ページの感情分析を実行する、など。

※スキルは元のJSONデータのinputsで指定された部分を受け取り、エンリッチメントを実行し、結果を元のJSONデータのoutputsで指定された新しいノードに追加する。

エンリッチされたドキュメントをキャッシュしたりナレッジストアに送信したりできる。

API、またはAzure portalなどを使用して、Azure AI Searchにスキルセットを追加できる。

## Document cracking

データソースから、ファイルやデータベースを開き、そこからテキストや画像を抽出するプロセス。

例:

データベースのレコードやJSONドキュメントから列やフィールドのテキストを取り出す。

PDFからテキスト、画像、メタデータを抽出する。

取り出したデータはスキルセットへと送られる。スキルセットからはエンリッチされたドキュメントが返される。

## スキルセットのデバッグ - デバッグ セッション

https://learn.microsoft.com/ja-jp/azure/search/cognitive-search-tutorial-debug-sessions

デバッグ セッションは、スキルセットの包括的な視覚化を提供する Azure portal ツール。

このツールを使用することで、特定の手順にドリルダウンし、アクションが失敗していると考えられる場所が簡単にわかる。

## Power Skills

A collection of useful functions to be deployed as custom skills for Azure Cognitive Search

https://github.com/Azure-Samples/azure-search-power-skills/tree/main

Hello Worldというテンプレートスキルが用意されている。これを起点として独自のカスタムスキルを開発できる。
https://github.com/Azure-Samples/azure-search-power-skills/blob/main/Template/HelloWorld/README.md

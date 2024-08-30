# モジュール1 Azure AI Language を使用してテキストを分析する

```
Azure AI services
├ Azure AI Language
│ ├ ★ Text analysys / テキスト分析 ... M1 (モジュール1)
│ │ ├ Language detection / 言語検出
│ │ ├ Key phraze extraction / キー フレーズ抽出
│ │ ├ Sentiment analysis / 感情を分析する
│ │ ├ Named Entity Recognition (NER) / エンティティの抽出(「固有表現認識」とも)
│ │ └ Entity linking / リンクされたエンティティを抽出する
│ ├ Question Answering / 質問応答 ... M2
│ ├ Conversational Language Understanding (CLU) / 会話言語理解 ... M3
│ ├ Custom text classification / カスタムテキスト分類 ... M4
| └ Custom Named Entity Recognition (NER) / カスタムNER ... M5
├ Azure AI Translator / 翻訳 ... M6
└ Azure AI Speech
  ├ Text-to-speech, Speech-to-Text / 音声認識・テキスト読み上げ ... M7
  └ Speech translation / 音声翻訳 ... M8
```

## Text Analytics (テキスト分析) とは？

言語検出、キーフレーズ抽出、感情分析、エンティティ抽出（固有表現認識）、エンティティリンキングなどの自然言語処理を実行する。

## Language detection / 言語検出

https://learn.microsoft.com/ja-jp/azure/ai-services/language-service/language-detection/overview

ドキュメントを書くのに使われている言語を検出できる。

言語の名前（Japanese, Englishなど）・言語コード（ja, enなど）が返される。

※言語コードの一覧: https://so-zou.jp/web-app/tech/data/code/language.htm

## Key phraze extraction / キー フレーズ抽出

https://learn.microsoft.com/ja-jp/azure/ai-services/language-service/key-phrase-extraction/overview

テキスト内の主要な概念をすばやく特定。

https://www.ogis-ri.co.jp/otc/hiroba/technical/similar-document-search/part5.html

「文章からその主題を良く表現している句を抽出する技術」

```
"食事はどれもとても美味しく、最高でした！スタッフの方の対応も素晴らしかったです。"
↓
"美味しい食事", "素晴らしいスタッフ"
```

## Sentiment analysis / 感情を分析する

https://learn.microsoft.com/ja-jp/azure/ai-services/language-service/sentiment-opinion-mining/overview

テキストをマイニングして「ポジティブ」「ネガティブ」「ニュートラル」といった分析を行う。人々がブランドやトピックについてどう考えているかを知ることができる。

文章に対して 0 と 1 の間の信頼度スコアを返す。

## Named Entity Recognition (NER) / エンティティの抽出(「固有表現認識」とも)

https://learn.microsoft.com/ja-jp/azure/ai-services/language-service/named-entity-recognition/overview

テキスト内のエンティティを識別および分類できます。 たとえば、人名、地名、組織、数量、日時など。

```
I had a wonderful trip to Seattle last week.
↓
trip (Event)
Seattle (Location)
last week (DateTime)
```

## Entity linking / リンクされたエンティティを抽出する

https://learn.microsoft.com/ja-jp/azure/ai-services/language-service/entity-linking/overview

テキストで見つかったエンティティを識別し、Wikipedia の詳細情報へのリンクを付与する。

たとえば「Apple」という言葉はいろいろな意味を持つが、以下のような文脈では意味が異なる。

- 私はスーパーマーケットで Apple を購入した。
  - Apple: https://en.wikipedia.org/wiki/Apple
- 私は Apple の最新のスマートフォンを購入した。
  - Apple: https://en.wikipedia.org/wiki/Apple_Inc.

Entity linkingでは、このような、文章の中の単語の適切な意味を判断して、英語版Wikipediaの適切なリンクを付与する。

<!--
たとえば「ヴィーナス」（Venus）という単語は、太陽系の惑星「金星」や、ローマ神話の女神「ヴィーナス（ビーナス）」などに解釈できる。

「空に輝くヴィーナス」という文章の中では、「ヴィーナス」は「女神」ではなく「金星」と解釈するのが適切である。

Entity linkingでは、このような、文章の中の単語の適切な意味を判断して、英語版Wikipediaの適切なリンクを付与する。

```
"私は空に輝くヴィーナスを見た"
↓
Venus: https://en.wikipedia.org/wiki/Venus
```
-->

## 使用するリソース

以下のいずれかを使用。

- 「言語サービス」リソース
- 「Azure AI Servicesマルチサービスアカウント」

## Language Studio

https://language.cognitive.azure.com/


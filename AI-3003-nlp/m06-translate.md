# モジュール6 Azure AI 翻訳サービスを使用してテキストを翻訳する

```
Azure AI services
├ Azure AI Language
│ ├ Text analysys / テキスト分析 ... M1 (モジュール1)
│ ├ Question Answering / 質問応答 ... M2
│ ├ Conversational Language Understanding (CLU) / 会話言語理解 ... M3
│ ├ Custom text classification / カスタムテキスト分類 ... M4
| └ Custom Named Entity Recognition (NER) / カスタムNER ... M5
├ ★ Azure AI Translator / 翻訳 ... M6
│ ├ Detect / 言語検出
│ ├ Text translation / 翻訳
│ └ Transliterate / 音訳
└ Azure AI Speech
  ├ Text-to-speech, Speech-to-Text / 音声認識・テキスト読み上げ ... M7
  └ Speech translation / 音声翻訳 ... M8
```

## Detect / 言語検出

https://learn.microsoft.com/ja-jp/azure/ai-services/translator/reference/v3-0-detect

指定したテキストの言語（日本語、英語など）を判定する。

※Azure AI Languageの「Text analysys」の「Language Detection」と似ているが、Azure AI Translatorの「Detect」のレスポンスには以下のように「isTranslationSupported」「isTransliterationSupported」というプロパティが含まれており、指定したテキストがAzure AI Translatorによって翻訳可能か・音訳可能か、という情報も返される。

```json
[
    {
        "language": "ja",
        "score": 1.0,
        "isTranslationSupported": true,
        "isTransliterationSupported": false
    }
]
```

## Text translation / 翻訳

https://learn.microsoft.com/ja-jp/azure/ai-services/translator/reference/v3-0-translate

指定したテキストを別の言語に翻訳する。

## Transliterate / 音訳

https://learn.microsoft.com/ja-jp/azure/ai-services/translator/reference/v3-0-transliterate

指定したテキストを「音訳」する。たとえば「こんにちは」「さようなら」を「音訳」すると以下のようなレスポンスが返される。

```
[
    {"text":"konnnichiha","script":"Latn"},
    {"text":"sayounara","script":"Latn"}
]
```

※「音訳」とは、書籍等を正確に読み上げて収録する音声化作業（視覚障害者の方向けのボランティア作業など）を指す言葉でもあるが、これはAzureの「音訳」とは異なるもの。[Wikipedia](https://ja.wikipedia.org/wiki/%E9%9F%B3%E8%A8%B3)


## 使用するリソース

- Translator
- Azure AI Servicesマルチサービスアカウント

※PDFなどのドキュメントをまるごと変換する「ドキュメント翻訳」という機能もあるが、これはマルチサービスアカウントではサポートされない。


<!--
## Language Studio

https://language.cognitive.azure.com/

## 参考: Custom Translator

https://learn.microsoft.com/ja-jp/azure/ai-services/translator/custom-translator/overview

https://portal.customtranslator.azure.ai/

-->

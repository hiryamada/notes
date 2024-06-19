# モジュール8 Azure AI 音声サービスで音声を翻訳する

```
Azure AI services
├ Azure AI Language
│ ├ Text analysys / テキスト分析 ... M1 (モジュール1)
│ ├ Question Answering / 質問応答 ... M2
│ ├ Conversational Language Understanding (CLU) / 会話言語理解 ... M3
│ ├ Custom text classification / カスタムテキスト分類 ... M4
| └ Custom Named Entity Recognition (NER) / カスタムNER ... M5
├ Azure AI Translator / 翻訳 ... M6
└ Azure AI Speech
  ├ Text-to-speech, Speech-to-Text / 音声認識・テキスト読み上げ ... M7
  └ ★ Speech translation / 音声翻訳 ... M8
```

## 音声翻訳

https://learn.microsoft.com/ja-jp/azure/ai-services/speech-service/speech-translation

マイクなどから入力された音声を文字起こしして、指定された言語に変換する。

## 処理の流れ

```
音声データ（英語）
↓
文字起こし（英語）
↓
文字起こしの翻訳（日本語）
```

処理結果のレスポンスには「文字起こし（英語）」と「文字起こしの翻訳（日本語）」が含まれる。

※「音声翻訳」は、音声の元の言語の「文字起こし」と、その「翻訳テキスト」を生成するところまでを担当。「翻訳テキスト」を読み上げる処理は含まれない。必要に応じて、アプリ側で、「翻訳テキスト」を別途 Text-to-speech で読み上げさせる処理を行う。

## 具体的な例

```
「Hello」（英語音声）
↓
Hello（英語テキスト）
↓
こんにちは（日本語テキスト）
```

## リソース

以下のいずれかを使用。

- 「音声」リソース
- 「AI services マルチサービス アカウント」リソース

## Speech Studio

https://aka.ms/speechstudio/speechtranslation


## 参考: ビデオ翻訳

※今回の解説の範囲外

※2024/6現在、プレビューとして提供中

https://learn.microsoft.com/ja-jp/azure/ai-services/speech-service/video-translation-overview

「ビデオ翻訳」を使用すると、動画の音声の「自動吹き替え」が可能。

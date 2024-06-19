# モジュール7 Azure AI サービスを使用して音声対応アプリを作成する

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
  ├ ★ Text-to-speech, Speech-to-Text / 音声認識・テキスト読み上げ ... M7
  └ Speech translation / 音声翻訳 ... M8
```

## リソース

以下のいずれかを使用。

- 「音声」リソース
- 「AI services マルチサービス アカウント」リソース

## Speech Studio

https://aka.ms/speechstudio/

音声サービスのAPIをすばやく試すことができるWebアプリ。

## 音声テキスト変換 speech to text (STT)

https://learn.microsoft.com/ja-jp/azure/cognitive-services/speech-service/speech-to-text

オーディオをテキストにリアルタイムまたはオフラインで文字起こしできる。

リアルタイム変換（マイクなど）、またはバッチ変換（ファイルなど）が利用できる。

## テキスト読み上げ text to speech (TTS)

https://learn.microsoft.com/ja-jp/azure/cognitive-services/speech-service/text-to-speech

テキストを人間のような合成音声に変換。

様々な音声（男性、女性など）が用意されている。

[voiceNameの一覧](https://learn.microsoft.com/ja-jp/azure/cognitive-services/speech-service/language-support?tabs=tts#supported-languages) （「テキスト読み上げ」タブ内の`ja-JP`の行）

```
ja-JP-AoiNeural (女性)
ja-JP-DaichiNeural (男性)
ja-JP-KeitaNeural (男性)
ja-JP-MayuNeural1 (女性)
ja-JP-NanamiNeural (女性)
ja-JP-NaokiNeural (男性)
ja-JP-ShioriNeural (女性)
```

## SSML (Speech Synthesis Markup Language)による制御

https://learn.microsoft.com/ja-jp/training/modules/transcribe-speech-input-text/6-speech-synthesis-markup

音声合成マークアップ言語 (SSML) を使用すると、音声出力をより細かく制御できる。

```
<speak version="1.0" xmlns="http://www.w3.org/2001/10/synthesis" 
                     xmlns:mstts="https://www.w3.org/2001/mstts" xml:lang="en-US"> 
    <voice name="en-US-AriaNeural"> 
        <mstts:express-as style="cheerful"> 
          I say tomato 
        </mstts:express-as> 
    </voice> 
</speak>
```

たとえば`<mstts:express-as style="cheerful"> `で、「肯定的で幸せそうな語調」となる。

https://learn.microsoft.com/ja-jp/azure/cognitive-services/speech-service/speech-synthesis-markup-voice#speaking-styles-and-roles


## 参考: カスタム ニューラル音声

カスタム ニューラル音声 (CNV) は、アプリケーション用に独自にカスタマイズした合成音声を作成できるようにするテキスト読み上げ機能。

カスタム ニューラル音声を使用すると、人間の発話サンプルをトレーニング データとして提供することで、ブランドやキャラクターの音声を非常に自然な音声で作成できる。


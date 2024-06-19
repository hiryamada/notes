# モジュール3 会話言語理解(CLU)モデルを構築する

```
Azure AI services
├ Azure AI Language
│ ├ Text analysys / テキスト分析 ... M1 (モジュール1)
│ ├ Question Answering / 質問応答 ... M2
│ ├ ★ Conversational Language Understanding (CLU) / 会話言語理解 ... M3
│ ├ Custom text classification / カスタムテキスト分類 ... M4
| └ Custom Named Entity Recognition (NER) / カスタムNER ... M5
├ Azure AI Translator / 翻訳 ... M6
└ Azure AI Speech
  ├ Text-to-speech, Speech-to-Text / 音声認識・テキスト読み上げ ... M7
  └ Speech translation / 音声翻訳 ... M8
```

## CLU (Conversational Language Understanding) とは？

https://learn.microsoft.com/ja-jp/azure/ai-services/language-service/conversational-language-understanding/overview

CLUは、ユーザーの発話（utterance）から、その「意図」と「エンティティ」を認識する部分の処理を担当する。

例1: ユーザーの発話（utterance）:「 **3分** のタイマーを設定して。」

```
ユーザーの意図（インテント、ユーザーがやりたいこと）: タイマーのセット
エンティティ: 時間 = 3分
```

例2: ユーザーの発話（utterance）「**品川** に移動するには？」

```
ユーザーの意図（インテント）: 交通手段の検索
エンティティ: 場所 = 品川
```

例3: ユーザーの発話（utterance）「 **シーフードのピザ** を **2枚** 注文して。」

```
ユーザーの意図: ピザの注文
エンティティ: 商品 = シーフードピザ、 数量 = 2枚
```

CLUは、会話の意図（タイマーのセット、交通手段の検索、ピザの注文など）と、そこに含まれるエンティティを認識するところまでを担当する。

意図に対応する実際の処理は、モデルではなく、別の部分で（たとえばC#を使用したり、外部のAPIを呼び出したりして）実装する。

## 必要なリソース

「言語サービス」リソースを作成する。「言語サービス」に、「会話言語理解(CLU)」が含まれている。

ただし、リソースを作成するリージョンに注意。

https://learn.microsoft.com/ja-jp/azure/ai-services/language-service/concepts/regional-support#conversational-language-understanding-and-orchestration-workflow

上記のページの表で「Authoring」にチェックがついているリージョンでは、プロジェクトの作成・編集・トレーニング・デプロイが可能。「予測(Prediction)」にチェックがついているリージョンでは、デプロイされたモデルを使用して、予測(Prediction)を取得する（つまり、発話から意図とエンティティを識別する）処理を実行可能。

## トレーニング

CLUでは、意図やエンティティは、あらかじめ多数の「発話」でトレーニングしておく。

たとえば、「GetTime」という「意図」を定義し、そこに以下のような、サンプルの「発話」を与えて、モデルをトレーニングする。

- 何時？
- 何時何分？
- 今何時？
- 今何時ですか？
- 何時ですか？
- 現在時刻
- 現在時刻は？
- 現在時刻を教えてください

すると、トレーニングされたモデルは、ユーザーから、上記と同じ、または **これらに近い** 「発話」を受け取った場合に、それが「GetTime」という「意図」だと、認識できるようになる。

```
ユーザー「今、何時でしょうか？」（発話）
↓
トレーニングされたモデル
↓
意図 =「GetTime」
```

CLUは意図を特定するところまでを担当する。意図「GetTime」に対応する（現在時刻を取得して表示するなど）実際の処理は、モデルではなく、別の部分で（たとえばC#を使用したりして）実装する。

## トレーニングはどのようにして実行するのか？

トレーニングは、「Language Studio」を使用して実行できる。

https://language.cognitive.azure.com

このWebサイトにアクセスし、画面右上をクリックしてサインインを行う。また、作成済みの「言語リソース」を選択する。


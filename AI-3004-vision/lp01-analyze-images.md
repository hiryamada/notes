# 画像分析 - Image Analysis

```
Azure AI services
 └ Azure AI Vision (Computer Vision)
   └ Image Analysis service (画像分析)
      ├ Image captions
      ├ Dense Captions
      ├ Image tagging
      ├ Object detection
      └ People detection
```

## 画像分析でできること

- 画像キャプション - Image captions
  - 画像コンテンツに対して 1 文の説明を生成
- 高密度キャプション - Dense Captions
  - 画像全体の説明に加えて、画像の最大 10 個の領域について 1 文の説明を生成
  - 説明の対象になっている画像領域の境界ボックスの座標も返される
- 画像のタグ付け - Image tagging
  - 画像に表示される家具、道具、植物、動物、アクセサリ、小物、生物などのタグを返す
- オブジェクト検出 - Object detection
- 人物検出 - People detection

### 画像キャプション - Image captions

[公式ドキュメント](https://learn.microsoft.com/ja-jp/azure/ai-services/computer-vision/concept-describe-images-40?tabs=image)

画像コンテンツに対して 1 文の説明を生成。

### 高密度キャプション - Dense Captions

[公式ドキュメント](https://learn.microsoft.com/ja-jp/azure/ai-services/computer-vision/concept-describe-images-40?tabs=image)

画像全体の説明に加えて、画像の最大 10 個の領域について 1 文の説明が生成され、より詳細な情報が提供される。説明の対象になっている画像領域の境界ボックスの座標も返される。

### 画像のタグ付け - Image tagging

[公式ドキュメント](https://learn.microsoft.com/ja-jp/azure/ai-services/computer-vision/concept-tag-images-40)

画像に表示される家具、道具、植物、動物、アクセサリ、小物、生物、景色などを認識し、そのタグを返す。

### オブジェクト検出 - Object detection

[公式ドキュメント](https://learn.microsoft.com/ja-jp/azure/ai-services/computer-vision/concept-object-detection-40)

「画像のタグ付け」に似ているが、イメージに検出された各オブジェクトの境界ボックスの座標 (ピクセル単位) が取得できる。

### 人物検出 - People detection

[公式ドキュメント](https://learn.microsoft.com/ja-jp/azure/ai-services/computer-vision/concept-people-detection)

画像に表示された人物を検出。

## 画像分析を行うためのAzureリソース

画像の分析には以下のいずれかのリソースを使用。

- 「Computer vision」リソース
- 「Azure AI services マルチサービスアカウント」リソース

## Vision Studio

Computer Visionの「画像の分析」などの機能を簡単に試すことができるサイト。

https://portal.vision.cognitive.azure.com/

## 画像分析のAPI - Image Analysis API

2022/10/12 Computer Vision Image Analysis 4.0 プレビュー開始
https://azure.microsoft.com/ja-jp/updates/public-preview-computer-vision-image-analysis-40/

- すべてのComputer Vision機能を 1 つのエンドポイントで使用できる
- 1 回の API 呼び出しで、画像のキャプション、タグ付け、読み取り (OCR)、人の検出、スマート トリミング、オブジェクト検出を一度に実行できる
- Read (OCR) では、キリル語、アラビア語、ヒンディー語を含む 164 の言語がサポートされるようになった

## 画像分析のための公式ライブラリ - Image Analysis SDK

※SDK = Software Development Kit

https://learn.microsoft.com/ja-jp/azure/ai-services/computer-vision/sdk/overview-sdk

最新バージョンは 4.0 （以前のバージョンは 3.2）

C#/Python/Java/JavaScriptの4言語のSDKが提供されている。

## クイックスタート

Image Analysisを使用してアプリを開発するための手順は「クイックスタート」のドキュメントで解説されている。

https://learn.microsoft.com/ja-jp/azure/ai-services/computer-vision/quickstarts-sdk/image-analysis-client-library-40?tabs=visual-studio%2Cwindows&pivots=programming-language-csharp

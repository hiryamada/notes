# 全体のまとめ

## このコースで学習したサービス

```
Azure AI services
├ Azure AI Vision (画像処理)
│  ├ Image Analysis (画像分析)
│  ├ Custom Image Analysis (カスタムモデルによる画像分析)
│  ├ Face (画像に含まれる人の顔の検出)
│  └ OCR (画像に含まれるテキストの読み取り)
└ Azure AI Video Indexer （ビデオの分析）
```

|サービス名|概要|
|-|-|
|Azure AI Vision / [Image Analysis](https://learn.microsoft.com/ja-jp/azure/ai-services/computer-vision/overview-image-analysis?tabs=4-0)	|画像のキャプション（説明文）生成、画像内のオブジェクト検出、タグ付け、カテゴリ分類などを行う|
|Azure AI Vision / [Custom Image Analysis](https://learn.microsoft.com/ja-jp/azure/ai-services/computer-vision/how-to/model-customization?tabs=studio)|カスタムトレーニングされたモデルを使用して、画像内のオブジェクトの分類や検出を行う|
|Azure AI Vision / [Face](https://learn.microsoft.com/ja-jp/azure/ai-services/computer-vision/overview-identity)|	画像内の人の顔を検出し、顔認識を行う|
|Azure AI Vision / [OCR](https://learn.microsoft.com/ja-jp/azure/ai-services/computer-vision/overview-ocr)	|画像内のテキストを読み取り、文字に変換する|
|[Azure AI Video Indexer](https://learn.microsoft.com/ja-jp/azure/azure-video-indexer/video-indexer-overview)|ビデオ内の人物、オブジェクト、シーン、音声、テキストなどを分析し、字幕をつける|

## ポータル・スタジオ

|名称|URL|概要|
|-|-|-|
|Azure portal| https://portal.azure.com/ | Azureリソースの管理 |
|Vision Studio| https://portal.vision.cognitive.azure.com/ | 画像分析、カスタムモデルのトレーニングとテスト、Face、OCRなどの利用 |
|Azure AI Video Indexer portal| https://www.videoindexer.ai/ | 動画のアップロードと分析 |

## SDK

.NET (C#/F#/Visual Basic)用

- [Image Analysis SDK - Azure.AI.Vision.ImageAnalysis](https://www.nuget.org/packages/Azure.AI.Vision.ImageAnalysis)
- [Face SDK - Microsoft.Azure.CognitiveServices.Vision.Face](https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Vision.Face)
- [OCR SDK - Microsoft.Azure.CognitiveServices.Vision.ComputerVision](https://www.nuget.org/packages/Microsoft.Azure.CognitiveServices.Vision.ComputerVision)
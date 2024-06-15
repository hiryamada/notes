# AI-3004: Azure AI サービスを使用して Azure AI Vision ソリューションを構築する

https://learn.microsoft.com/ja-jp/credentials/applied-skills/build-azure-ai-vision-solution/

画像分析、画像からのテキストの読み取り、動画の分析などの、Azure AI Vision の主要な機能を学び、それを使用するC#/Pythonアプリを構築します。

```
Azure AI services
├ Azure AI Vision (画像処理)
│  ├ Image Analysis (画像分析): LP(ラーニングパス)1
│  ├ Custom Image Analysis (カスタムモデルによる画像分析): LP2
│  ├ Face (画像に含まれる人の顔の検出): LP3
│  └ OCR (画像に含まれるテキストの読み取り) : LP4
└ Azure AI Video Indexer （ビデオの分析）: LP5
```

1日コース（前半講義、後半演習）

ラボ（演習）あり。（現在英語版のみ）

注意: このコースの内容は「[AI-102 Azure AI エンジニア](https://learn.microsoft.com/ja-jp/credentials/certifications/azure-ai-engineer/)」の一部と同じです。

## 講義

- 講師自己紹介
- [オープニング（開始時のご案内）](../opening.md)
- [ラーニングパス1: 画像を分析する](lp01-analyze-images.md)
  - ラボ（オプション） / 講師デモ 1 画像の分析 (Analyze Images with Azure AI Vision)
- [ラーニングパス2: カスタムモデルを使用した画像分類](lp02-classify-images-custom-model.md)
  - ラボ（オプション） / 講師デモ 2 画像の分類 (Classify images with an Azure AI Vision custom model)
- [ラーニングパス3: 顔を検出、分析、認識する](lp03-face.md)
- [ラーニングパス4: 画像やドキュメント内のテキストを読み取る](lp04-read-text.md)
  - ラボ（オプション） / 講師デモ 3 テキストの読み取り (Read Text in Images)
- [ラーニングパス5: 動画を分析する](lp05-analyze-video.md)
- [全体のまとめ](matome.md)
- [認定試験（アセスメント）のご案内](assessment.md)
- [クロージング（終了時のご案内）](../closing-cloudslice.md)
- 満足度アンケート

## ラボ（オプション） / 講師デモ

実際にAzureを操作するラボ（演習）です。Azureやソフトウェア開発の経験がある方向け。

- [ラボ環境](https://esi.learnondemand.net/)
  - [ラボ環境の利用方法](../ラボ環境の利用方法.pdf)

このコースでは以下の3つのラボを実施します。
- ラボ1 画像の分析 (Analyze Images with Azure AI Vision)
  - 英語版 https://microsoftlearning.github.io/mslearn-ai-vision/Instructions/Exercises/01-analyze-images.html
  - 日本語版 https://microsoftlearning.github.io/mslearn-ai-vision.ja-jp/Instructions/Exercises/01-analyze-images.html
- ラボ2 画像の分類 (Classify images with an Azure AI Vision custom model)
  - 英語版 https://microsoftlearning.github.io/mslearn-ai-vision/Instructions/Exercises/02-image-classification.html
  - 日本語版 https://microsoftlearning.github.io/mslearn-ai-vision.ja-jp/Instructions/Exercises/02-image-classification.html
- ラボ3 テキストの読み取り (Read Text in Images)
  - 英語版 https://microsoftlearning.github.io/mslearn-ai-vision/Instructions/Exercises/05-ocr.html
  - 日本語版 https://microsoftlearning.github.io/mslearn-ai-vision.ja-jp/Instructions/Exercises/05-ocr.html

<!--
- 手順書
  - 英語版 https://microsoftlearning.github.io/mslearn-ai-vision/
  - 日本語版 https://microsoftlearning.github.io/mslearn-ai-vision.ja-jp/

-->

## インタラクティブ ラボ シミュレーション（オプション）

Azureの操作を疑似体験できるシミュレーションです。Azureやソフトウェア開発の経験がない方向け。

- [インタラクティブ ラボ シミュレーション（英語のみ）](https://mslabs.cloudguides.com/guides/AI-102%20Lab%20Simulations%20-%20Designing%20and%20implementing%20a%20Microsoft%20Azure%20AI%20solution)
  - LP（ラーニングパス）1: 15 Analyze images with Computer Vision
  - LP2: 17 Classify images with Custom Vision
  - LP3: 19 Detect and analyze faces
  - LP4: 20 Read text in images
  - LP5: 16 Analyze video with Azure Video Indexer

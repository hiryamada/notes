# Azure AI Document Intelligence ソリューションを計画する

## Azure AI Document Intelligenceとは？

Document Intelligence を使用することで、特定のドキュメントに含まれる情報をすばやく正確に抽出できる。

たとえばスキャナから読み込んだ領収書の画像などをAzure AI Document Intelligenceで分析することで、領収書に書かれた内容を抽出できる。

## Azure AI Document Intelligence では、どのようなドキュメントから情報を抽出できるのか？

https://learn.microsoft.com/ja-jp/azure/ai-services/document-intelligence/choose-model-feature

領収書、請求書、納税申告書、パスポート、クレジットカード、契約書、手紙、レポートなどから、情報を抽出できる。

※「カスタムモデル」を利用すると、独自の種類のドキュメントから情報を抽出することもできる。たとえばある企業で使用している独自のフォーマットのアンケート用紙、伝票など。

## Azure AI Document Intelligence では、どのような画像データ形式に対応しているのか？

https://learn.microsoft.com/ja-jp/azure/ai-services/document-intelligence/concept-model-overview?view=doc-intel-4.0.0#input-requirements

- PDF
- JPEG
- PNG
- BMP
- TIFF
- [HEIF(High Efficiency Image File Format, ヒーフ)](https://ja.wikipedia.org/wiki/High_Efficiency_Image_File_Format)
- Word (DOCX)
- Excel (XLSX)
- PowerPoint (PPTX)
- HTML

## Azure AI Document Intelligenceのリソースとは？

Azure AI Document Intelligenceを使用するには、まずAzureサブスクリプション内に「Azure AI Document Intelligence」のリソースを作成する。

東日本リージョン・西日本リージョンを含む、世界60以上のリージョンでリソースを作成できる。

## Azure AI Document Intelligenceの料金は？

リソースを作成する際に「価格レベル」を選択する。それにより、読み取り可能なページ数や料金が異なる。

価格レベル:
- Free F0: 無料
  - 「1ヶ月に500ページまで」といった制限がある。
  - あとでStandard S0にアップグレードが可能
- Standard S0: 有料
  - ページ数制限なし、1000ページごとに $1.5 など。

詳しくは以下を参照:

- 料金表 https://azure.microsoft.com/ja-jp/pricing/details/ai-document-intelligence/
- Free F0とStandard S0の違い: https://learn.microsoft.com/ja-jp/azure/ai-services/document-intelligence/service-limits?view=doc-intel-4.0.0

## Azure AI VisionのOCRとの違いは？

Azureには多数のAIサービスがあり、その中の一つに「Azure AI Vision」というものがある。これは画像の分析を行うサービスである。

Azure AI VisionのOCR（Optical Character Reader）機能を使用して、画像から文字情報を読み取ることもできる。

例: 名刺の読み取り

- Azure AI VisionのOCR機能:
  - 「○✕株式会社」
  - 「営業部」
  - 「山田太郎」
  - 「090-xxxx-xxxx」
- Azure AI Document Intelligence: 
  - 会社名:「○✕株式会社」
  - 部署: 「営業部」
  - 氏名:「山田太郎」
  - 電話番号:「090-xxxx-xxxx」

Azure AI VisionのOCR機能の場合は、画像の中に含まれる文字を読み取って、複数の文字列を返す。それぞれの文字列がどのようなデータ項目なのかまでは認識できない。

それに対し、Azure AI Document Intelligenceの場合は、それぞれの文字列がどのようなデータ項目なのかを認識できる（会社名、氏名、電話番号など）。したがって、その後のデータ処理（たとえばデータベースへのデータの登録など）がしやすくなる。

※Azure AI Document Intelligenceでは、たとえば名刺の場合「読み取った画像の中央に大きく書かれている人名っぽい文字列」を「氏名」として認識する。このような認識処理は、Azure AI Document Intelligenceの「機械学習モデル」によって実行される。

## Azure AI Document Intelligenceの「モデル」とは？

一般的に、機械学習の「モデル」とは、分析・分類などを行うための数学的な表現のこと。世の中にはさまざまな「機械学習モデル」が存在する。

Azure AI Document Intelligenceでも、機械学習モデルを使用して、画像から文字情報を読み取る。

Azure AI Document Intelligenceでは、以下の3種類の機械学習モデルが使用される。

- 事前構築済みモデル
- カスタム モデル
- 構成済みモデル

## Azure AI Document Intelligenceの「事前構築済みモデル」とは？

https://learn.microsoft.com/ja-jp/azure/ai-services/document-intelligence/overview?view=doc-intel-4.0.0#prebuilt-models

請求書や領収書、名刺など、一般的な種類のドキュメントを処理するために、事前構築済みモデルのセットが提供されている。

これらのモデルはあらかじめマイクロソフトによってトレーニングが済ませてあるため、ユーザーがトレーニングを実施する必要がない。

## Azure AI Document Intelligenceの「カスタム モデル」とは？

https://learn.microsoft.com/ja-jp/azure/ai-services/document-intelligence/overview?view=doc-intel-4.0.0#custom-models

自社のみで使用している独自の書類・伝票など、事前構築済みモデルでは対応できないドキュメントを読み取るには、カスタム モデルを作成し、それをトレーニングして使用する。

## Azure AI Document Intelligenceの「構成済みモデル」とは？

複数のカスタム モデルで構成されるもの。

ユーザーが構成済みモデルにフォームを送信すると、Document Intelligence はそれを自動的に分類し、その分析においてどのカスタム モデルを使用するべきかを決定する。ドキュメントの種類が事前にわからない場合や、ドキュメントに複数のバリエージョンがある場合に利用する。

1 つの構成済みモデルに、最大で 100 個のカスタム モデルを追加できる。

## APIとは？

一般的にAPI(Application Programming Interface)とは、あるサービスの機能にアクセスするためのしくみ。AzureのサービスのほとんどはAPI経由で利用する。

Azure AI Document IntelligenceのAPIリファレンス:
https://learn.microsoft.com/en-us/rest/api/aiservices/document-models

## SDKとは？

https://learn.microsoft.com/ja-jp/azure/ai-services/document-intelligence/sdk-overview-v4-0

C#などのプログラミング言語からAPIを呼び出すための公式ライブラリ。SDKは内部的にAPIを呼び出して必要な処理を行う。

通常、APIを直接呼び出す（HTTPリクエストを送りHTTPレスポンスを受信する）よりも、SDKを使用したほうが、プログラムコードが簡潔でわかりやすくなり、開発効率が上がり、メンテナンス性も向上するので、実際の開発ではSDKを使用する場合がほとんどである。

Azure AI Document Intelligenceでは以下の言語に対応するSDKが利用できる。

- .NET (C#/F#/Visual Basic)
- Java
- JavaScript
- Python

## Document Intelligence Studioとは？

https://learn.microsoft.com/ja-jp/azure/ai-services/document-intelligence/studio-overview?view=doc-intel-4.0.0

Azure AI Document Intelligence の機能を視覚的に探索、理解するためのオンライン ツール。コードを書かずに、Azure AI Document Intelligenceの一通りの機能を試すことができる。

以下のURLからアクセスできる。
https://documentintelligence.ai.azure.com/studio/

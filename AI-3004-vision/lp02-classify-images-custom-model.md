# カスタムモデルによる画像分類 - Image Analysis

[公式ドキュメント](https://learn.microsoft.com/ja-jp/azure/ai-services/computer-vision/how-to/model-customization?tabs=studio)

```
Azure AI services
 └ Azure AI Vision (Computer Vision)
   ├ Create custom models (カスタムモデルの作成)
   └ Custom Image Analysis (カスタムモデルによる画像分析)
```

## カスタムモデルとは？

独自のトレーニング画像を使用して「カスタム モデル」（カスタム画像分類モデル）をトレーニングできる。

トレーニングが完了した「カスタム モデル」を使用することで、Azure AI Vision標準の画像分析では実行できない分類や検出が可能となる。

例えば、Azure AI Vision標準の画像分析では「犬」「猫」といった動物を認識できるが、「ペルシャ」「アメリカンショートヘア」「ロシアンブルー」「ラグドール」といった「猫の種類」までは分類・検出できない。

ユーザーが大量の猫画像を用意し、それを使用して「カスタム モデル」をトレーニングし、それを使用することで、「猫の種類」の分類・検出ができるようになる。[実際の事例](https://zenn.dev/mochan_tk/articles/9a25dd3e0863d2)

「カスタム モデル」を使用して、画像にカスタム タグを適用したり (画像分類)、カスタム オブジェクトを検出したり (物体検出) できる。

## COCO (Common Objects in Context)ファイル

画像のラベル情報を表現するには COCO ファイルを使用する。

```json
{
	"info": {...},
	"licenses": [
		{...},{...}
	],
	"images": [
		{...},{...},{...},{...}
	],
	"annotations": [
		{...},{...},{...},{...},{...},{...},{...},{...},{...}
	],
	"categories": [
		{...},{...},{...}
	]
}
```

`images`に画像のURLなどを記載する。たとえば、球場で野球選手がバットを振ってボールを打っているシーンの画像のURL。

`annotations`に、その画像に含まれるオブジェクトの座標と、オブジェクトのカテゴリー、キャプション説明文）を指定する。たとえば、画像の中の野球選手の座標、カテゴリー（1=personなど）、キャプション（`"a batter after he has hit a pitched ball before he is going to run`（打者がボールを打ち、走ろうとするところ）など）


参考: Microsoftの「COCOデータセット」: 約33万枚のカラー写真の画像データセット。モデルのトレーニング用の素材として利用できる。

COCO データセットの公式サイト
https://cocodataset.org/#home

わかりやすい解説
https://atmarkit.itmedia.co.jp/ait/articles/2109/08/news026.html

MS COCO datasetのフォーマットまとめ
https://qiita.com/kHz/items/8c06d0cb620f268f4b3e

## カスタムモデルのトレーニングとテスト

Vision Studio ( https://portal.vision.cognitive.azure.com/ )を用いて、カスタムモデルのトレーニングとテストを実行できる。



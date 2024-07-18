# Azure Document Intelligence を使用してフォームからデータを抽出する

※カスタムモデルを構築して、カスタムモデルによりドキュメントの読み取りを実行する手順を解説。

## 大まかな手順

- Document Intelligence Studio を開く
- ドキュメントのサンプル画像をアップロードする
- ラベル付けを行う（ラベル付けされたデータセットが作成される）
- データセットを使って、カスタムモデルをトレーニングする
- トレーニングが完了したカスタムモデルを使用して、ドキュメントの読み取りを行う。

## 用語: ドキュメントのサンプル画像（sample documents）

JSONやPDFの形式で、サンプルのドキュメントの画像をたくさん準備する。

例:

- Form_1.jpg
- Form_2.jpg
- Form_3.jpg
- Form_4.jpg
- Form_5.jpg

※これらのファイルはどれも同じドキュメント形式とする。

## 用語: フィールド（field）

たとえば、各ドキュメントの中に「氏名」と「電話番号」という2種類のデータが含まれている場合、「氏名」フィールド、「電話番号」フィールド、の2つのフィールドがある、という。

## 用語: フィールドリスト（field list）

「氏名」フィールド、「電話番号」フィールド、のような、フィールドの集まりのことを、フィールドリストという。

フィールドリストは fields.json というファイルに記録される。

## 用語: ラベル付け（labeling）

サンプルのドキュメントをDocument Intelligence Studioで表示する。

そして、抽出したい各フィールドの座標情報を、クリックで指定する。この作業を「ラベル付け」という。

## 用語: ラベルファイル（label file）

ラベル付けの結果を記録したファイル。「～.labels.json」という名前で記録される。

## 用語: フィールドの読み取り結果（layout response）

ラベル付けを行うと、Document Intelligence Studio の OCR 機能により、サンプルのドキュメントからフィールドが読み込まれて、文字が認識される。

たとえば「氏名」フィールドの読み取りを行うと「山田太郎」、「電話番号」フィールドの読み取りを行うと「090-9999-9999」といった読み取り結果が生成される。

この読み取り結果（layout response）は「～.ocr.json」に記録される。

## 用語: ラベル付けされたデータセット（labeled dataset）

ドキュメントのサンプル画像（～.jpg）、フィールドリスト（fields.json）、ラベル付けの結果（～.labels.json）、読み取り結果（～.ocr.json）を1つのフォルダにまとめたもの。

## ラベル付けがされたデータセットの例

- fields.json ... フィールドリスト
- Form_1.jpg ... サンプル画像ファイル
- Form_1.jpg.labels.json ... 各フィールドのラベルの座標の情報
- Form_1.jpg.ocr.json ... 各フィールドの読み取り結果の情報
- Form_2.jpg
- Form_2.jpg.labels.json
- Form_2.jpg.ocr.json
- Form_3.jpg
- Form_3.jpg.labels.json
- Form_3.jpg.ocr.json
- Form_4.jpg
- Form_4.jpg.labels.json
- Form_4.jpg.ocr.json
- Form_5.jpg
- Form_5.jpg.labels.json
- Form_5.jpg.ocr.json

※～.jpg はユーザーが準備する。

※その他の ～.json は、ユーザーが Document Intelligence Studio 上でラベル付け作業を行った結果、Document Intelligence Studio が生成する。

## モデルのトレーニング

「ラベル付けがされたデータセット」を使って、カスタムモデルをトレーニングする。

## カスタムモデルを使用したドキュメントの読み取り

トレーニングが完了したカスタムモデルを使用して、ドキュメントの読み取りを行う。
# ラボ09 「会話言語理解(CLU)」リソースの作成

Cognitive Servicesリソースを作成し、それを使用して「Clock」というプロジェクトを作成する。

このプロジェクトにモデル「Clock」を作成し、現在の日付や時刻を尋ねる質問の文章を理解できるように、トレーニングする。

■Cognitive Servicesリソースの作成

「言語サービス」に、「会話言語理解(CLU)」が含まれているので、「言語サービス」リソースを作成する。

![](images/ss-2023-06-06-14-38-48.png)

![](images/ss-2023-06-06-14-39-56.png)

![](images/ss-2023-06-06-14-40-50.png)

![](images/ss-2023-06-06-14-41-10.png)

作成したら「キーとエンドポイント」画面に移動し、「キー1」の値と「エンドポイント」の値をコピーして、メモ帳などに控えておく。次のラボで使用する。

■Language Studioにアクセス

https://language.cognitive.azure.com

画面右上でサインイン、リソースを選択。

![](images/ss-2023-06-06-14-42-41.png)

![](images/ss-2023-06-06-14-43-22.png)

![](images/ss-2023-06-06-14-44-03.png)

日本語化

![](images/ss-2023-06-06-14-45-01.png)

■「会話言語理解」プロジェクトの作成

![](images/ss-2023-06-06-14-45-28.png)

プロジェクト名: `Clock` ※大文字で始める

![](images/ss-2023-06-06-14-49-11.png)

![](images/ss-2023-06-06-14-49-39.png)

■「意図」(intent)を追加

<!--
参考: https://learn.microsoft.com/ja-jp/azure/cognitive-services/language-service/conversational-language-understanding/how-to/build-schema#add-intents
-->

意図「GetDate」を追加

![](images/ss-2023-06-06-14-50-35.png)

「発話の例」を書き込む

![](images/ss-2023-06-06-14-51-17.png)


- 今日は何日？
- 今日は？
- 何日ですか？
- 何日？
- 今日の日付は？
- 日付は？
- 何月何日？
- 今何日？
- 日付

![](images/ss-2023-06-06-14-54-21.png)
![](images/ss-2023-06-06-14-56-03.png)


意図「GetTime」を追加し、「発話の例」を書き込む

![](images/ss-2023-06-06-14-57-27.png)
![](images/ss-2023-06-06-14-57-55.png)
![](images/ss-2023-06-06-14-58-49.png)

- 何時？
- 何時何分？
- 今何時？
- 今何時ですか？
- 何時ですか？
- 現在時刻
- 現在時刻は？
- 現在時刻を教えてください

![](images/ss-2023-06-06-15-00-03.png)
![](images/ss-2023-06-06-15-00-19.png)

最後に「変更の保存」をクリック。

![](images/ss-2023-06-06-15-00-35.png)

■トレーニング ジョブの開始

<!--
参考: https://learn.microsoft.com/ja-jp/azure/cognitive-services/language-service/conversational-language-understanding/how-to/train-model?tabs=language-studio#training-modes
-->

![](images/ss-2023-06-06-15-01-53.png)

![](images/ss-2023-06-06-15-02-09.png)

![](images/ss-2023-06-06-15-02-27.png)

- モデル名: `Clock` ※大文字で始める
- トレーニングモード: 高度なトレーニング ※「標準トレーニング」は英語の場合のみ使用可能。

![](images/ss-2023-06-06-15-03-12.png)

![](images/ss-2023-06-06-15-04-11.png)

トレーニングジョブが「キュー」に入ると、「Job in queue. Starting soon ...」 などと表示される。

![](images/ss-2023-06-06-15-04-28.png)

※トレーニングジョブが「キュー」に入ると、あとはトレーニングは自動で進行する。始まるまで10分ほど時間がかかる（ここで休憩をおとりください。）

![](images/ss-2023-06-06-15-13-09.png)

<!-- 15:04 start -->

トレーニングが開始されると、「Training - 0% complete, Evaluation - 0% complete.」などと表示される。

トレーニングが完了（成功）すると、「トレーニングに成功しました」などと表示される。

■モデルのデプロイ

画面左「モデルのデプロイ」をクリック

「デプロイの追加」をクリック

「新しいデプロイ名を作成する」、デプロイ名「production」 ※小文字で始める

モデル: 「Clock」

「デプロイ」

数秒ほどでデプロイが完了する。

<!--
■モデルのエンドポイントとキーの取得

一覧で「production」を選択し、「予測URLの取得」をクリック。「予測URL」が表示される。

例:
```
https://eastusclu9283742.cognitiveservices.azure.com/language/:analyze-conversations?api-version=2022-10-01-preview
```

この文字列も、メモ帳などにコピーする。末尾の部分を削除し、`.cognitiveservices.azure.com/`で終わるようにする。

例:
```
https://eastusclu9283742.cognitiveservices.azure.com/
```

この「予測URL」も、メモ帳などに控えておく。次のラボで使用する。

※メモ帳には「言語サービス」の「キー」と、「モデル」の「予測URL」の2つの情報が記録されている。
-->

## 次のステップ

ここで準備したリソース、モデル、情報は、次のラボ([ラボ10](lab10.md))で使用する。
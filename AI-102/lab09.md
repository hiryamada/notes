# ラボ09 「会話言語理解(CLU)」リソースの作成

Cognitive Servicesリソースを作成し、それを使用して「Clock」というプロジェクトを作成する。

このプロジェクトにモデル「Clock」を作成し、現在の日付や時刻を尋ねる質問の文章を理解できるように、トレーニングする。

■Cognitive Servicesリソースの作成

「言語サービス」に、「会話言語理解(CLU)」が含まれているので、「言語サービス」リソースを作成する。

https://learn.microsoft.com/ja-jp/azure/cognitive-services/language-service/conversational-language-understanding/service-limits#regional-availability

上記のページの表で「Authoring」にチェックがついているリージョンを確認する。

そのリージョン（例: 米国東部）に「言語サービス」を作成する。

作成したら「キーとエンドポイント」画面に移動し、「キー1」の値と「エンドポイント」の値をコピーして、メモ帳などに控えておく。次のラボで使用する。

■Language Studioにアクセス

https://language.cognitive.azure.com

画面右上でサインイン、リソースを選択。

■「会話言語理解」プロジェクトの作成

プロジェクト名: `Clock` ※大文字で始める

■「意図」(intent)を追加

参考: https://learn.microsoft.com/ja-jp/azure/cognitive-services/language-service/conversational-language-understanding/how-to/build-schema#add-intents

意図「GetDate」を追加し、「発話の例」を書き込む

- 今日は何日？
- 今日は？
- 何日ですか？
- 何日？
- 今日の日付は？
- 日付は？
- 何月何日？
- 今何日？
- 日付

意図「GetTime」を追加し、「発話の例」を書き込む

- 何時？
- 何時何分？
- 今何時？
- 今何時ですか？
- 何時ですか？
- 現在時刻
- 現在時刻は？
- 現在時刻を教えてください

最後に「変更の保存」をクリック。

■トレーニング ジョブの開始

参考: https://learn.microsoft.com/ja-jp/azure/cognitive-services/language-service/conversational-language-understanding/how-to/train-model?tabs=language-studio#training-modes

モデル名: `Clock` ※大文字で始める

「高度なトレーニング」を実行。

※「標準トレーニング」は英語の場合のみ使用可能。

トレーニングジョブが「キュー」に入ると、「Job in queue. Starting soon ...」 などと表示される。

※トレーニングジョブが「キュー」に入ると、あとはトレーニングは自動で進行しますが、30分ほど時間がかかります。ここで休憩をおとりください。

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
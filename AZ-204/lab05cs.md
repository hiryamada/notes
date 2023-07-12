# ラボ 05: イメージとコンテナーを使用してコンピューティング ワークロードをデプロイする

- Cloud Shell内で、`ipcheck`という簡単なサンプルアプリを作成します。このアプリは、自分が動作している環境のIPアドレスを表示します。
- アプリ一式を「Azure Container Registry」に送信し、イメージをビルドします。
- ビルドしたイメージを「Azure Container Instances」上で実行します。

**注意: このラボには演習1, 2, 3が含まれていますが、現在、演習3は実施できません。演習1, 2を実施してください。**

## ラボ環境の利用方法

→ [ラボ環境の利用方法](lab00cs.md)

## 動画

ラボの実施手順を記録した動画です。音声はありません。

AZ-204 ラボ05 イメージとコンテナーを使用してコンピューティング ワークロードをデプロイする
https://youtu.be/UlV1q45SCjw

## 手順書

日本語版:
https://microsoftlearning.github.io/AZ-204-DevelopingSolutionsforMicrosoftAzure.ja-jp/Instructions/Labs/AZ-204_lab_05.html

英語版:
https://microsoftlearning.github.io/AZ-204-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_lab_05.html

## 概要


- 演習 1: ACR
  - タスク 1: Azure portal を開く
  - タスク 2: リソース グループを作成する
  - タスク 3: Cloud Shell とエディターを開く
  - タスク 4: .NET アプリケーションを作成してテストする
  - タスク 5: Container Registry リソースを作成する
  - タスク 6: Container Registry のメタデータを格納する
  - タスク 7: Container Registry にイメージをデプロイする
  - タスク 8: Container Registry のコンテナー イメージを検証する
- 演習 2: ACI
  - タスク 1: コンテナー レジストリで管理者ユーザーを有効にする
  - タスク 2: コンテナーイメージをACIに自動でデプロイする
  - タスク 3: コンテナーイメージをACIに手動でデプロイする
  - タスク 4: コンテナー インスタンスが正常に実行されたことを検証する
- 演習 3: ACA **注意: 実施できません**
  - タスク 1: 環境を準備する
  - タスク 2: 環境を作成する
  - タスク 3: コンテナー アプリを作成する

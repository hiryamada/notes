# ラボ01 Cognitive Services を使用した AI アプリの開発

Cognitive Servicesを使用して、入力されたテキストの言語を判定するプログラムを作成します。

## YouTube動画

AI-102 ラボ01 Cognitive Services を使用した AI アプリの開発
https://youtu.be/JbRbQPi-GXs

## 概要

このラボのねらいは、Cognitive Servicesを利用するアプリの基本的な開発の流れを理解することです。

このラボでは、以下の2パターンを作成します。

- `rest-client`: REST APIを使用(Azure SDKを使用しない)
  - JSONの組み立てとHTTPによる送受信などのコードが必要です。
- `sdk-client`: Azure SDKを使用
  - JSONの組み立てとHTTPによる送受信はSDKが担当します。
  - 一般的に、REST APIを使用するよりもプログラムが簡潔になります。

特にラボ手順書で指定がない場合、以下を使用します。

- リソースの作成には`eastus`リージョンを使用
- Cognitive Servicesのリソースとしては「Cognitive Servicesマルチサービスアカウント」

■大まかな流れ

- ラボ1番を起動
- 仮想デスクトップにサインイン
- Azure portalにサインイン
  - （オプション）Azure portalを日本語化
- Cognitive Servicesマルチサービスアカウントを作成
  - リージョン: East US
  - リソースグループ: 作成済みの ResourceGroup1 を選択
  - 名前: cog902387423 など適当に
- キーとエンドポイントをコピー
- VSCodeを起動
- リポジトリをクローン
  - https://github.com/MicrosoftLearning/AI-102-AIEngineer
- ファイル内の文字列を置換
  - YOUR_COGNITIVE_SERVICES_ENDPOINT
  - →コピーしたエンドポイント
  - YOUR_COGNITIVE_SERVICES_KEY
  - →コピーしたキー
- 統合ターミナルで `01-getting-started/C-Sharp/rest-client` を開く
- `dotnet run`
- 「Hello」、「Bonjour」、「Gracias」などを入力し、対応する言語「English」「French」「Spanish」が表示されることを確認
- 統合ターミナルで `01-getting-started/C-Sharp/sdk-client` を開く
- `dotnet add package Azure.AI.TextAnalytics`
- `dotnet run`
- 「Hello」、「Bonjour」、「Gracias」などを入力し、対応する言語「English」「French」「Spanish」が表示されることを確認

## ラボの起動

- ラボ環境にアクセス https://esi.learnondemand.net/
- Microsoftアカウントでサインイン
- ラボ 01 を起動
- 以降、ラボ環境の右側に表示される手順書に従って操作
- 詳しくは以下を参照
  - [ラボ環境の利用方法](https://github.com/hiryamada/notes/blob/main/cloudslice/README.md)
  - [ラボの操作](https://github.com/hiryamada/notes/blob/main/cloudslice/CloudSliceLab.pdf)

## 手順書

日本語:
https://microsoftlearning.github.io/AI-102-AIEngineer.ja-jp/Instructions/01-get-started-cognitive-services.html

英語:
https://microsoftlearning.github.io/AI-102-AIEngineer/Instructions/01-get-started-cognitive-services.html

<!--

```
az login

location='eastus'

group=ResourceGroup1

name=cog`date|md5sum|head -c6`

az cognitiveservices account create --kind CognitiveServices -l $location -n $name -g $group --sku s0 --custom-domain $name --yes

endpoint=$(az cognitiveservices account show -n $name -g $group --query properties.endpoint -otsv)

key=$(az cognitiveservices account keys list -n $name -g $group --query 'key1' -otsv)

cd ~/Documents

git clone --depth 1 https://github.com/MicrosoftLearning/AI-102-AIEngineer

cd AI-102-AIEngineer

grep -rl YOUR_COGNITIVE_SERVICES_ENDPOINT . | xargs sed -i "s|YOUR_COGNITIVE_SERVICES_ENDPOINT|$endpoint|g"

grep -rl YOUR_COGNITIVE_SERVICES_KEY . | xargs sed -i "s/YOUR_COGNITIVE_SERVICES_KEY/$key/g"

code -r 01-getting-started/C-Sharp

cd sdk-client

dotnet add package Azure.AI.TextAnalytics

dotnet run
```

-->

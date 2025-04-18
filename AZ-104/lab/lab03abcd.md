# ラボ3a/b/c/d

想定時間: 60分

ラボ3のa/b/c/dを連続で実施していただきます。

（まだ準備していない場合）事前に[ラボのファイル](https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/archive/master.zip)をダウンロードして展開しておきましょう。



## ラボの重要ポイント

- ラボ3a Azure portal を使用してリソースを管理する
  - タスク1 
    - VMで使用するリソースである「ディスク」を単体で作成します。
    - このラボでは、「ディスク」は、比較的かんたんに作成できるリソースとして採用されています。このラボでは、ディスクそのものについて理解する必要はあまりありません。ディスクについてはモジュール8で解説します。
  - タスク2
    - リソースは、リソースグループ間で移動できることを理解しましょう
  - タスク3
    - リソースに削除ロックを設定します
    - 削除ロックがついていても、リソースの設定は変更できる（ディスクのタイプとサイズを変更できる）ということに着目しましょう
  - （クリーンアップは3dで実施します）

- ラボ3b ARM テンプレート を使用してリソースを管理する
  - タスク1
    - テンプレートを準備します。
  - タスク2
    - テンプレートから不要な部分を削除しています。
    - 削除する部分は、**既存の VHD ファイルから** Azure ディスクを作成する際に必要な記述です。今回のラボでは不要な部分なので削除しています。
    - テンプレートをデプロイします。
  - タスク3
    - デプロイされたリソースを確認しています。
  - （クリーンアップは3dで実施します）

- ラボ3c Azure PowerShell を使用してリソースを管理する
  - タスク1
    - Cloud Shellを起動し、PowerShellを使用できる状態にします
    - ここに打ち込んだコマンドはAzure上で実行されます
  - タスク2
    - ディスクの作成や、作成したディスクの情報の取得を行います
  - タスク3
    - ディスクを更新しています
  - （クリーンアップは3dで実施します）

- ラボ3d Azure CLI を使用してリソースを管理する
  - タスク1
    - Cloud Shellを起動し、Azure CLIを使用できる状態にします
  - タスク2
    - ディスクの作成や、作成したディスクの情報の取得を行います
  - タスク3
    - ディスクを更新しています
  - クリーンアップ
    - ラボ3a/3b/3c/3dのリソースをすべて削除します


## ラボ3全体の補足事項

Cloud Shellの注意：
- 複数行のコマンドをコピーしてCloud Shellに貼り付けする際は、**貼付け後にエンターキーを押して**、最終行が確実に実行されるようにしてください。
- Windows の場合、貼り付けはCtrl + Shift + V または Shift + Insert で実行できます。


Dのラボの一番最後にリソースのクリーンアップの手順があります。
A、B、CのいずれかのラボをやったあとにDをやらない場合でも、
最後のリソースのクリーンアップの手順（クラウドシェルでBashで実行）は行ってください。
予期せぬ料金がかかる場合があります。

## ラボ3a 補足事項


タスク1の3
リージョン：「米国東部」（eastus）

タスク1の6
Standard HDD 32Gが失敗する場合は、Premium SSD LRSの32Gで行う

タスク2の3
ツールバーの 「移動」 をクリックし→画面サイズの関係で表示されていない場合は「・・・」をクリック

タスク2の5
「OK」→「移動」

タスク3の2
Standard HDD 32Gが失敗する場合は、Premium SSD LRSの32Gで行う

タスク3の6
ロックのタイプ：削除

タスク3の8
yes→はい

タスク3の11
「サイズ＋パフォーマンス」→「サイズおよびパフォーマンス」

リソースのクリーンアップ
1　「削除」が画面サイズの関係で表示されていない場合は右に画面をスクロールします。

## ラボ3b 補足事項

タスク1の7
ラボコンピューター → お使いのコンピューターです。

タスク2の3


ラボ2aのリソース作成をPremium SSD LRSの32Gで実行した方は、手順書の通り、ポータルからDLしたものをお使いください。

ラボ2aのリソース作成をStandard HDD 32Gで実行した方: [こちら](https://raw.githubusercontent.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/master/Allfiles/Labs/03/az104-03b-md-template.json)を開き、Ctrl + Sでいったんローカルに保存します。それから、Azure portalでこのファイルを読み込ませてください。


タスク2の7

ラボ2aのリソース作成をPremium SSD LRSの32Gで実行した方は、手順書の通り、ポータルからDLしたものをお使いください。

ラボ2aのリソース作成をStandard HDD 32Gで実行した方は、[こちら](https://raw.githubusercontent.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/master/Allfiles/Labs/03/az104-03b-md-parameters.json)を開き、Ctrl + Sでいったんローカルに保存します。それから、Azure portalでこのファイルを読み込ませてください。

## ラボ3c 補足事項

基本はコピペで実行してください。
また、Cloud Shellの画面をできるだけ大きくしてからやると見やすいです。

## ラボ3d 補足事項

Cloud Shellの左上のプルダウンでPowerShellを選択します。
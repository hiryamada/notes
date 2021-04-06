# ラボ3a/b/c/d

ラボ3のa/b/c/dを連続で実施していただきます。

- ラボ3a Azure portal を使用してリソースを管理する
- ラボ3b ARM テンプレート を使用してリソースを管理する
- ラボ3c Azure PowerShell を使用してリソースを管理する
- ラボ3d Azure CLI を使用してリソースを管理する


## ラボ3全体の補足事項

Dのラボの一番最後にリソースのクリーンアップの手順があります。
A、B、CのいずれかのラボをやったあとにDをやらない場合でも、
最後のリソースのクリーンアップの手順（クラウドシェルでBashで実行）は行ってください。
予期せぬ料金がかかる場合があります。

## ラボ3a 補足事項


タスク1の3
リージョン：東日本

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
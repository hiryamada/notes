# ラボ 08 - 仮想マシンと仮想マシンスケールセットを管理する


- 前半(タスク1-3): 仮想マシンの管理
  - [前半の解説資料PDF](pdf/ラボ8タスク1-3.pdf)
- 後半(タスク4-7): 仮想マシンスケールセット(VMSS)の管理

## 動画

ラボの実施手順を記録した動画です。音声はありません。

- AZ-104 ラボ8 タスク1-3 https://youtu.be/jr15Mm-JcPw
- AZ-104 ラボ8 タスク4-7 https://youtu.be/jr15Mm-JcPw?t=1279

## 起動するラボの番号

ラボ12番を起動します。**8番ではありませんのでお気をつけください。**

## 手順書

日本語版:
https://microsoftlearning.github.io/AZ-104-MicrosoftAzureAdministrator.ja-jp/Instructions/Labs/LAB_08-Manage_Virtual_Machines.html

英語版:
https://microsoftlearning.github.io/AZ-104-MicrosoftAzureAdministrator/Instructions/Labs/LAB_08-Manage_Virtual_Machines.html

## 概要

- 準備
  - ラボ環境の「リソース」タブに表示されたユーザーID・パスワードでAzure portalにサインイン
- タスク1
  - Azure portalを使用して、ゾーン1に仮想マシンを作成します。
  - ARMテンプレートを使用して、ゾーン2に仮想マシンを作成します。
- タスク2
  - カスタムスクリプト拡張機能を使用して、仮想マシンにWebサーバーをセットアップします。
- タスク3
  - 仮想マシンをカスタマイズします。
- タスク4
  - サブスクリプションで、Microsoft.Insights リソース プロバイダー と Microsoft.AlertsManagement リソース プロバイダーを登録しています。この作業は、自動スケーリングを実行する際に必要となります。
- タスク5
  - 仮想マシンスケールセット(VMSS)をデプロイしています。
- タスク6
  - カスタムスクリプト拡張機能を使用して、VMSSのインスタンスにWebサーバーをセットアップします。
- タスク7
  - VMSSのインスタンスをカスタマイズします。
- クリーンナップ（省略）

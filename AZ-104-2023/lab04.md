# ラボ 04 - 仮想ネットワークを実装する


## ラボ環境の利用方法

→ [ラボ環境の利用方法](lab00.md)

## 手順書

https://microsoftlearning.github.io/AZ-104-MicrosoftAzureAdministrator.ja-jp/Instructions/Labs/LAB_04-Implement_Virtual_Networking.html

## 概要

- 準備
  - ラボ環境の「リソース」タブに表示されたユーザーID・パスワードでAzure portalにサインイン
- タスク1
  - Cloud Shellを起動（PowerShellを選択）
  - ARMテンプレートをCloud Shellにアップロード
  - ARMテンプレートを使用してVM（仮想マシン）をデプロイ
  - 仮想ネットワークを作成します
  - サブネットを追加します
- タスク2
  - 仮想マシンを仮想ネットワークにデプロイします
- タスク3
  - VMにパブリック IP アドレスを割り当てます
    - **パブリックIPアドレス`az104-04-pip0`は、あらかじめ作成して、NICに関連付けます。**
  - VM のプライベート IP アドレスの割り当て方法を「静的」に変更します
- タスク4
  - ネットワーク セキュリティ グループを作成します
  - VMのNICにネットワーク セキュリティ グループを関連付けます
  - リモートデスクトップでVMに接続できることを確認します
- タスク5
  - Azure DNS プライベートDNSゾーンを作成します
  - プライベートDNSゾーンを使用して、VM内で、VMのプライベートIPアドレスへの名前解決ができることを確認します
- タスク6
  - Azure DNS パブリックDNSゾーンを作成します
    - GoDaddyの「ドメイン名検索」（`https://www.godaddy.com/domains/domain-name-search`）は現在接続できないため、適当なドメイン名（`test29387249342.com`といった乱数を付与したもの）を使用します。
  - パブリックDNSゾーンを使用して、インターネットで、VMのパブリックIPアドレスの名前解決ができることを確認します
- クリーンナップ（省略）

## 動画

ラボの実施手順を記録した動画です。

音声はありません。

- AZ-104 ラボ4 タスク1-4 https://youtu.be/aW4-F7DQSMk
- AZ-104 ラボ4 タスク5-6 https://youtu.be/4eNIeEnXUa4

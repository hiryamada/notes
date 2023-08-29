# ラボ 04 - 仮想ネットワークを実装する

- 仮想ネットワークを作成して、VM（仮想マシン）をデプロイします。
- VMのNIC（ネットワークインターフェースカード）にパブリックIPアドレスを割り当てます。
- VMのNICにネットワークセキュリティグループを割り当てます。
- Azure DNSの「プライベートDNSゾーン」と「DNSゾーン」を作成し、名前解決の動作を検証します。

## 動画

ラボの実施手順を記録した動画です。音声はありません。

<!--
AZ-104 ラボ04 仮想ネットワークを実装する(CloudSlice)
https://youtu.be/GJrq0U39ig8
-->


az-104 ラボ4 仮想ネットワーク(CloudSlice)
https://youtu.be/c01LfooyKjo


## 起動するラボの番号

ラボ8番を起動します。**4番ではありませんのでお気をつけください。**

## 手順書

日本語版:
https://microsoftlearning.github.io/AZ-104-MicrosoftAzureAdministrator.ja-jp/Instructions/Labs/LAB_04-Implement_Virtual_Networking.html

英語版:
https://microsoftlearning.github.io/AZ-104-MicrosoftAzureAdministrator/Instructions/Labs/LAB_04-Implement_Virtual_Networking.html

## 概要

- 準備
  - ラボ環境の「リソース」タブに表示されたユーザーID・パスワードでAzure portalにサインイン
- タスク1
  - 仮想ネットワークとサブネット`subnet0`を作成
  - サブネット`subnet1`を追加
- タスク2
  - Cloud Shellを起動（PowerShellを選択）
  - ARMテンプレートをCloud Shellにアップロード
  - ARMテンプレートを使用してVM（仮想マシン）をデプロイ
    - **パスワードの指定は必要ありません。パラメータファイル内に記載されています**
- タスク3
  - VMにパブリック IP アドレスを割り当てます
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

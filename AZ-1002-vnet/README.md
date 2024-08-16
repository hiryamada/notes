# AZ-1002 Azure ネットワークを使用してワークロードへのセキュア アクセスを構成する

https://learn.microsoft.com/ja-jp/credentials/applied-skills/configure-secure-workloads-use-azure-virtual-networking/

1日コース

Azureの仮想ネットワーク(Virtual Network, VNet)について学習します。

- 仮想ネットワークを構成する
- Azure Virtual Network ピアリングを構成する
- ルートを使用してトラフィック フローを管理および制御する
- Azure DNS でドメインをホストする
- ネットワーク セキュリティ グループを構成する
- Azure Firewall の概要

## 講義

- 講師自己紹介
- [開始時のご案内](../opening.md)
- [講義: 仮想ネットワークの講義資料(PDF)](../AZ-104-2023/pdf/仮想ネットワークの概要.pdf)
- ラボの解説（講師によるAzure操作デモ）
- [認定試験対策](exam.md)
- [終了時のご案内](../closing-cloudslice.md)
- アンケート(満足度調査)
- オプション: ラボの実施

## ラボ (演習)

ラボ環境にアクセスし、ラボ「Azure 仮想ネットワーク サービスを使用してワークロードへの安全なアクセスを構成する」を起動します。

ラボを起動すると画面右側に手順書が表示されますので、以降は手順書に従い操作します。

- [ラボ環境 ( https://esi.learnondemand.net/ )](https://esi.learnondemand.net/)
- [ラボ環境の利用方法](../ラボ環境の利用方法.pdf)

注意: ラボは1時間程度放置すると勝手に終了してしまいます。その場合はまた最初からやり直しになります。

■手順書

日本語版
https://microsoftlearning.github.io/Configure-secure-access-to-workloads-with-Azure-virtual-networking-services.ja-jp/

英語版
https://microsoftlearning.github.io/Configure-secure-access-to-workloads-with-Azure-virtual-networking-services/

■ラボの概要

- Azure portalへのサインイン
- 仮想ネットワークの作成
  - hub-vnet 10.0.0.0/16
    - AzureFirewallSubnet 10.0.0.0/24
  - app-vnet 10.1.0.0/16
    - frontend 10.1.0.0/24 (vm1を配置)
    - backend 10.1.1.0/24 (vm2を配置)
- VNET ピアリングを構成する
- アプリケーションセキュリティグループを使用する
  - app-backend-asg ... vm2に関連付け
- ネットワークセキュリティグループを使用する
  - app-vnet-nsg ... app-vnet/backend に関連付け
  - 受信セキュリティ規則
    - ソース: 任意
    - 宛先: app-backend-asg
    - SSH 接続を許可
- Azure Cloud Shell (PowerShell) を起動
  - ARMテンプレートを使用してvm1, vm2を作成
- vm2のNICに app-backend-asg を関連付け
- Azure Firewallを作成する
  - app-vnetにAzureFirewallSubnetを作成
  - app-vnetにAzure Firewall (Standard SKU)を作成
  - アプリケーションルールコレクションを追加
    - dev.azure.com と www.microsoft.com へのHTTPアクセスを許可
  - ネットワークルールコレクションを追加
    - 1.1.1.1 と 1.0.0.1 （Cloudflare のパブリックDNSサーバ）へのDNSアクセスを許可
- ルートテーブルを作成する
  - トラフィックをAzure Firewallにルーティングする

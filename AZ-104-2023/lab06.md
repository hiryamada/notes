# ラボ 06 - トラフィック管理を実装する

前半: 「スポーク(vnet2/vm2)-ハブ(vnet01/vm0,vm1)-スポーク(vnet3/vm3)」という形のVNetをデプロイします。スポーク間の通信(vm2とvm3)ができるように、ハブに設置したvm0をルーターとして設定します。

後半: Azure Load BalanderとApplication Gatewayを使用してWebサイト(2つのVM)に対する負荷分散を行います。

## ラボ環境の利用方法

→ [ラボ環境の利用方法](lab00.md)

## 手順書

https://microsoftlearning.github.io/AZ-104-MicrosoftAzureAdministrator.ja-jp/Instructions/Labs/LAB_06-Implement_Network_Traffic_Management.html

## 概要

- 準備
  - ラボ環境の「リソース」タブに表示されたユーザーID・パスワードでAzure portalにサインイン
- タスク1
  - VNetとVMをデプロイします。
  - Network Watcher Agent 仮想マシン (VM) 拡張機能をインストールします。
    - これは、オンデマンドでネットワーク トラフィックをキャプチャするためと、Azure VM に関するその他の高度な機能を使用するために使用されます。
- タスク2
  - スポークとハブを接続する2つのピアリングを作成します。
- タスク3
  - Network Watcherを使用して、スポークとハブ間で通信ができることを確認します。
  - Network Watcherを使用して、スポーク間で通信ができないことを確認します。
- タスク4
  - vm0のNICでIP転送を有効にします（ルーターとして使用するため）
  - vm0にルーティング ロール サービスをインストールします
  - az104-06-rt23 ルートテーブル(vnet2のトラフィックをルーターvm0へ転送)を作成し、vnet2のサブネットに割り当てます。
  - az104-06-rt32 ルートテーブル(vnet3のトラフィックをルーターvm0へ転送)を作成し、vnet3のサブネットに割り当てます。
  - Network Watcherを使用して、スポーク間で通信ができるようになったことを確認します。
  - **nic0(ルータ部分)の警告が出ますが動作には問題ないようです。動画内ではこの問題の修正を試みていますが修正できませんでした。**
- タスク5
  - Azure Load Balancerをデプロイします。
  - Azure Load Balancer経由でWebサーバーにアクセスし、動作を確認します。
- タスク5
  - Azure Application Gatewayをデプロイします。
  - Azure Application Gateway経由でWebサーバーにアクセスし、動作を確認します。
- クリーンナップ（省略）

## 動画

ラボの実施手順を記録した動画です。

音声はありません。

- 前半
  - AZ-104 ラボ6 タスク1-4(ルーティング) https://youtu.be/zDqeIZWFhVU
- 後半
  - AZ-104 ラボ6 タスク5(Azure Load Balancer) https://youtu.be/zDqeIZWFhVU?t=1564
  - AZ-104 ラボ6 タスク6(Azure Application Gateway) https://youtu.be/zDqeIZWFhVU?t=1959


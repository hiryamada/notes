# ラボ7: VNet, サブネット, NSG, ASG

想定時間: 60min

（まだ準備していない場合は）事前に[ラボのファイル](https://github.com/MicrosoftLearning/AZ-500JA-AzureSecurityTechnologies/archive/master.zip)をダウンロードして展開しておきましょう。

## ラボの重要ポイント

- VNet、サブネットを作成します。
- アプリケーションセキュリティグループを2つ作成します。
  - myAsgWebServers: Webサーバー用
  - myAsgMgmtServers: 管理サーバー用
- ネットワークセキュリティグループを作成します。インバウンド規則にて、以下を許可します。
  - インターネットからmyAsgWebServersへのHTTP着信
  - インターネットからmyAsgMgmtServersへのRDP着信
- サブネットにネットワークセキュリティグループを関連付けます。
- VMを2つ作成します
  - myVmWeb: Webサーバー。NICにmyAsgWebServersを関連付けます。
  - myVMMgmt: 管理サーバー。NICにmyAsgMgmtServersを関連付けます。
- myVMMgmtにRDP接続ができることを確認します。
- myVmWebにWebサーバー（IIS）をインストールします
- myVmWebにHTTP接続ができることを確認します。

## 補足事項

### 演習1

タスク1-4 リージョン East US → 米国東部

タスク1-5 サブネット 規定 → default

タスク3-7 サブネット 規定 → default

タスク4-7 「追加」クリック後、一覧で「Allow-RDP-All」の左に、黄色い三角形の警告アイコンが表示されます。すべてのネットワークからのRDP接続を許可することは避けるべきであることを示しています。今回は演習につき、このままでもかまいません。

### 演習2

タスク1-3/タスク2-2/タスク4-3 ユーザー名 受講生 → Student

タスク1-3/タスク2-2 すでに Windows サーバーのライセンスを持っています → 既存の Windows Server ライセンスを使用しますか? （チェックしません）

タスク1-7/タスク2-6 「診断ストレージ アカウント: 既定値」 → （この項目は、「ブート診断」で「カスタムストレージアカウントで有効にする」を選択した場合にのみ表示されます。特に設定する必要はありません。

タスク4-5 「コマンドの実行」→「実行コマンド」

タスク4-6 `Install-WindowsFeature -name Web-Server -IncludeManagementTools` により、この VM に IIS (Webサーバー) がインストールされます。インストールには2分ほどかかります。以下の表示が出ればOKです。

```
Success Restart Needed Exit Code      Feature Result                               
------- -------------- ---------      --------------                               
True    No             Success        {Common HTTP Features, Default Document, D...
```
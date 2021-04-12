# ラボ8 Azure Firewall

想定時間: 60min

（まだ準備していない場合は）事前に[ラボのファイル](https://github.com/MicrosoftLearning/AZ-500JA-AzureSecurityTechnologies/archive/master.zip)をダウンロードして展開しておきましょう。

## ラボの重要ポイント

- 演習1
  - タスク1
    - ARMテンプレートを使用して、ラボで使用するVNet、VM 2台をデプロイします。
      - Srv-Jump: Jump-SNサブネットで稼働しています。
      - Srv-Work: Workload-SNサブネットで稼働しています。
  - タスク2 Azure Firewallをデプロイします。
  - タスク3 
    - ルートテーブルを作ります。
    - ルートテーブルをWorkload-SNサブネットに関連付けます。
    - ルートテーブルに、0.0.0.0/0 → Azure Firewall というルートを作成します。
    - 以上の設定により、Workload-SNサブネットからの通信がAzure Firewallに流れるようになります。
  - タスク4 Azure Firewallの「アプリケーションルール」を設定します。外向きの、bing.com へのアクセスを許可します。
  - タスク5 Azure Firewallの「ネットワークルール」を設定します。外向きの「209.244.0.3」と「209.244.0.4」の2つのDNSサーバーへのUDP 53番接続（DNS名前解決）を許可します。
  - タスク6 VMが使用するDNSサーバーのIPアドレスを指定します。
  - タスク7 Srv-JumpにRDPで接続し、さらにターミナルサービスを使用してSrv-Workに接続します。Srv-Work上でIEを起動し、bing.com へのアクセスが成功すること、microsoft.com へのアクセスが失敗することを確認しています。(bing.com に接続できるということは、DNSによる bing.com の名前解決ができている、ということでもあります)

タスク5で指定している2つのIPアドレスは「Level3」というフリーDNSサーバーのプライマリ/セカンダリアドレスです。[参考](http://jpcodetip.blogspot.com/2018/10/public-dns.html)

Azure Firewallは比較的高額なサービスなので、Azure Passサブスクリプションのクレジットが無駄にならないよう、演習が終わりましたら、なるべく早く削除（ラボ末尾のクリーンアップ）をすることをおすすめします。

## 補足事項

### 演習1

タスク1-6 East US → 米国東部

タスク2-3 リージョン: East US→米国東部

タスク2-3 Firewall policy の下の「add new」をクリックします。ポリシー名「fwpolicy」、リージョン「米国東部」、ポリシーレベル「Standard」として、「はい」をクリックします。

タスク3-5, 3-6 「ファイアウォールルート」→Firewall-route

タスク4-2 「Test-FW01」 ブレードの 「設定」 セクションで、「ルール」 をクリックします。→ Test-FW01の「概要」にて、「ファイアウォール ポリシー」の下の「fwpolicy」をクリックします。fwpolicy（ファイアウォールポリシー）のブレードが表示されます。「設定」の「Application Rules」をクリックします。

タスク4-3 アプリケーションルールコレクション→規則コレクション

タスク4-5 「http:80、 https:443」→「http:80,https:443」

規則コレクション追加後、追加したコレクションが一覧に表示されない場合は、ページをリロードします。

タスク5-2 「Test-FW01 | ルール」 ブレードで、「ネットワーク ルール コレクション」 タブをクリックし、「+ ネットワーク ルール コレクションを追加」 をクリックします。→ 「設定」セクションの「Network Rules」をクリックし、「規則コレクションの追加」をクリックします。

タスク5-4 宛先アドレス→ターゲット

タスク5-4 規則コレクショングループ→DefaultNetworkRuleCollectionGroupを選択します。

タスク6-5 テキストボックスに 209.244.0.3 を貼り付けると、もう一つのテキストボックスが出現するので、そこに 209.244.0.4 を貼り付けます。

タスク7-2 Srv-WorkではなくSrv-Jumpに接続します。お気をつけください。

タスク7-6 ここではSrv-Jump を経由して、Srv-Workに接続しています。

タスク7-7 「IE セキュリティ強化の構成」→ IE Enhanced Security Configuration




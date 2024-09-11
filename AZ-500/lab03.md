# ラボ8 Azure Firewall

想定時間: 60min

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

Level3は、2017年にCenturyLink（現Lumen）に買収された。
https://ja.wikipedia.org/wiki/Level_3_Communications



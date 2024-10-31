# ラボ3 Azure Firewall

想定時間: 60min

## ラボの重要ポイント

- 演習1
  - タスク1
    - ARMテンプレートを使用して、ラボで使用するVNet、VM 2台をデプロイし。
      - Srv-Jump: Jump-SNサブネットで稼働している。
      - Srv-Work: Workload-SNサブネットで稼働している。
  - タスク2 Azure Firewallをデプロイ。
  - タスク3 
    - ルートテーブルを作ります。
    - ルートテーブルをWorkload-SNサブネットに関連付け。
    - ルートテーブルに、0.0.0.0/0 → Azure Firewall というルートを作成。
    - 以上の設定により、Workload-SNサブネットからの通信がAzure Firewallに流れるようになる。
  - タスク4 Azure Firewallの「アプリケーションルール」を設定します。外向きの、bing.com へのアクセスを許可。
  - タスク5 Azure Firewallの「ネットワークルール」を設定します。外向きの「209.244.0.3」と「209.244.0.4」の2つのDNSサーバーへのUDP 53番接続（DNS名前解決）を許可。
  - タスク6 VMが使用するDNSサーバーのIPアドレスを指定。
  - タスク7 Srv-JumpにRDPで接続し、さらにターミナルサービスを使用してSrv-Workに接続。Srv-Work上でIEを起動し、bing.com へのアクセスが成功すること、microsoft.com へのアクセスが失敗することを確認。(bing.com に接続できるということは、DNSによる bing.com の名前解決ができている、ということでもある)

タスク5で指定している2つのIPアドレスは「Level3」というフリーDNSサーバーのプライマリ/セカンダリアドレス。[参考](http://jpcodetip.blogspot.com/2018/10/public-dns.html)

Level3は、2017年にCenturyLink（現Lumen）に買収された。
https://ja.wikipedia.org/wiki/Level_3_Communications



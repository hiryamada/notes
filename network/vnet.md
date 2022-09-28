# 仮想ネットワーク(Virtual Network, VNet)

■VNetとは？

https://learn.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-overview

[まとめ資料](https://github.com/hiryamada/notes/blob/main/AZ-104/pdf/mod04/VNet%E3%81%AE%E5%9F%BA%E6%9C%AC.pdf)

- Azure クラウド内のプライベートなネットワーク
- 他のVNetとは「論理的に」分離されている
  - ピアリングなどで明示的に接続をしない限り、他のVNetとはつながらない
- VPNや専用線（ExpressRoute）を使用して、オンプレミスと安全に接続できる
  - ExpressRouteを使用する場合、トラフィックはインターネットを経由しない
- 「ネットワークセキュリティグループ」(NSG)を使用して、セキュリティ規則を設定し、IPアドレスやポート番号などで通信規則を定義できる（許可・拒否）
- 「アプリケーションセキュリティグループ」（ASG）を使用して、VMをグループ化することができる。ASGで定義されたグループは、NSGのセキュリティ規則で、送信元・送信先として、IPアドレスの代わりに指定することができる。
- 「サービスエンドポイント」を使用して、VNet内から、ストレージアカウントなどのAzure サービスに安全に直接接続できる。
- 「Azure Private Link」を使用して、VNet内に作成される「プライベートエンドポイント」経由で、ストレージアカウントなどのAzure サービスに安全に直接接続できる。

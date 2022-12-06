# Azure Load Balancer

- Azure の最もパフォーマンスの高いロード バランサー
- 負荷分散アルゴリズムとして、タプルベースのハッシュを利用

製品ページ
https://azure.microsoft.com/ja-jp/products/load-balancer/#overview

ドキュメント
https://learn.microsoft.com/ja-jp/azure/load-balancer/load-balancer-overview

価格
https://azure.microsoft.com/ja-jp/pricing/details/load-balancer/


■Azure Load Balancer の SKU

- Basic
  - 可用性ゾーンに対応していない
  - [2025/9に廃止予定](https://azure.microsoft.com/ja-jp/updates/azure-basic-load-balancer-will-be-retired-on-30-september-2025-upgrade-to-standard-load-balancer/)
- Standard
  - 可用性ゾーンに対応

SKU(BasicとStandard)の比較
https://learn.microsoft.com/ja-jp/azure/load-balancer/skus#skus

■Azure Load Balancer の 「フロントエンドIP」

- クライアントがAzure Load Balancerに接続するためのIPアドレス
- 「パブリック IP アドレス」または「プライベート IP アドレス」

■Azure Load Balancer の 種類 (「パブリック」と「内部」)

- パブリック
  - インターネットからのトラフィックを受け付ける
  - フロントエンドIPは「パブリックIPアドレス」
- 内部
  - VNet内の他のVMからのトラフィックを受け付ける
  - VPNやExpressRouteで接続されたオンプレミスネットワークからのトラフィックを受け付ける
  - フロントエンドIPは「プライベート IP アドレス」

※「プライベート」や「外部」といった種類はない。


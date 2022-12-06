# ExpressRouteのSKU

■SKUとは？

- Stock Keeping Unit
- スキュー
- 物流用語。在庫管理単位
- Azureにおいて、リソースの機能や性能の違いを表すもの。
  - Basic, Standard, Premium といったもの。
    - BasicよりもStandard、StandardよりもPremiumのほうがより高機能・高性能となる。
    - 「松」「竹」「梅」のようなニュアンス。
  - リソースによってさまざま。

■ExpressRouteのSKU

- ExpressRoute Standard
  - 接続できる仮想ネットワーク数: 10
- ExpressRoute Premium
  - 接続できる仮想ネットワーク数: 20～100（[帯域による](https://learn.microsoft.com/ja-jp/azure/expressroute/expressroute-faqs#virtual-networks-links-allowed-for-each-expressroute-circuit-limit)）
  - 世界中のすべてのリージョンでホストされているすべての Microsoft クラウド サービスにアクセス可能
- ExpressRoute Local
  - [解説PDF: ExpressRoute Local](../network/ExpressRoute%20Local.pdf)

■ExpressRouteの仮想ネットワークゲートウェイのSKU

- Standard: 1 Gbps
- HighPerformance: 2 Gbps
- UltraPerformance: 10 Gbps

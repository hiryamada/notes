# ExpressRoute

- 接続プロバイダーが提供するプライベート接続を介して、オンプレミスのネットワークを Microsoft クラウドに拡張.
- 帯域: 50 Mbps ～ 10 Gbps

2014/2/20 ExpressRoute プレビュー
https://azure.microsoft.com/en-us/updates/expressroute-preview/

# ExpressRouteの仮想ネットワークゲートウェイのSKU

- Standard: 1 Gbps
- HighPerformance: 2 Gbps
- UltraPerformance: 10 Gbps

https://docs.microsoft.com/ja-jp/azure/expressroute/expressroute-about-virtual-network-gateways

`Resize-AzVirtualNetworkGateway` PowerShell コマンドレットを使用して変更。

# ExpressRoute Premium

- プライベート ピアリング用ルートの上限が 4,000 から 10,000 に増加されたルーティング テーブル。
- ExpressRoute 回線で有効にできる VNet と ExpressRoute Global Reach の接続数の増加 (既定は 10)。
- Microsoft 365 への接続
- Microsoft のコア ネットワーク経由のグローバル接続。
  - ある地理的リージョンにある VNET を別のリージョン内の ExpressRoute 回線に接続できる

2015/5/4 ExpressRoute Premium add-on package 一般提供開始
https://azure.microsoft.com/en-us/updates/general-availability-azure-expressroute-premium-add-on-package/

https://docs.microsoft.com/ja-jp/azure/expressroute/expressroute-faqs#what-is-expressroute-premium

# ExpressRoute Direct

グローバルな Microsoft のバックボーンに 100 Gbps で直接接続

2018/9/24 ExpressRoute Directプレビュー
https://azure.microsoft.com/ja-jp/updates/expressroute-direct-in-public-preview/

https://azure.microsoft.com/en-us/blog/azure-networking-fall-2018-update/

https://docs.microsoft.com/ja-jp/azure/expressroute/expressroute-faqs#expressRouteDirect

日本でも利用可能(アット東京様) https://cloud.watch.impress.co.jp/docs/news/1226413.html

# ExpressRoute Global Reach

ExpressRoute 回線を相互にリンクして、オンプレミス ネットワーク（拠点）間を接続し、拠点間でのプライベートな接続を構築。

2019/4/17
https://azure.microsoft.com/ja-jp/updates/expressroute-global-reach-is-now-available/

# ExpressRoute Local

ExpressRoute ピアリングの場所の Local 回線で、ユーザーが、同じ都市圏内またはその近くにある 1 つまたは 2 つの Azure リージョンにのみアクセスできる。送信料金不要、帯域は1Gbps以上。

Ignite 2019 (2019/11/4–11/8) にて、ExpressRoute Local が 一般提供開始
https://yonehub.y10e.com/2019/11/21/20191121_ignite2019_network/
https://aidanfinn.com/?p=21661

# ExpressRoute FastPath

- 仮想ネットワーク ゲートウェイが Ultra Performance または ErGw3AZ である場合は、ExpressRoute FastPath を有効にすることができる。
- オンプレミス ネットワークと仮想ネットワークの間のデータ パスのパフォーマンスを向上させる.
- ExpressRouteゲートウェイをバイパスしてトラフィックを直接VMに送信することで、オンプレミスネットワークとVNet間のデータパスパフォーマンスを改善する。
- すべての ExpressRoute 回線で使用できる。

2021/11/2 パブリックプレビュー
https://azure.microsoft.com/en-us/updates/public-preview-expressroute-fastpath-improvements/

# Bidirectional Forwarding Detection (BFD)

https://www.alaxala.com/jp/techinfo/archive/manual/AX7700R/HTML/10_10_/APGUIDE/0219.HTM

- 2台の装置間での経路の生存状況を調べ，いち早く障害を検出することを目的とした機能
- 両装置は定期的にBFDパケットを送受信し，対向装置から一定時間以上BFDパケットが到着しなかった場合は対向装置との経路に障害が発生したと見なす

https://docs.microsoft.com/ja-jp/azure/expressroute/expressroute-bfd

- ExpressRoute は、プライベート ピアリングと Microsoft ピアリングの両方で BFD (Bidirectional Forwarding Detection) をサポート
- Microsoft Enterprise edge (MSEE) デバイスと、ExpressRoute 回線が構成されているルーター (CE/PE) との間のリンク障害の検出速度が向上
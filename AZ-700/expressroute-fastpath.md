# ExpressRoute FastPath

- オンプレミス ネットワークと仮想ネットワークの間のデータ パスのパフォーマンスを向上させる.
- すべての ExpressRoute 回線で使用できるオプション。
- ExpressRouteゲートウェイをバイパスして、トラフィックを直接VMに送信することで、オンプレミスネットワークとVNet間のデータパスパフォーマンスを改善する。

2021/11/2 パブリックプレビュー
https://azure.microsoft.com/en-us/updates/public-preview-expressroute-fastpath-improvements/

ドキュメント
https://learn.microsoft.com/ja-jp/azure/expressroute/about-fastpath

■注意
- ExpressRoute FastPath を利用するには、ExpressRoute Gateway の SKU を UltraPerformance or ErGw3AZ にする必要がある
- 設定は Azure portalからは実施できない。Azure PowerShell か Azure CLI を使用して設定する。

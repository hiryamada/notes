# VNetピアリング

[ピアリング接続](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-peering-overview)


2つ以上のVNetを接続します。

VNet間の双方向通信が可能です。

サブスクリプションやリージョンを越えてピアリングできます。

ピアリングされた仮想ネットワーク内の仮想マシン間のトラフィックには、Microsoft のバックボーンインフラストラクチャが使用されます。 

# グローバルVNetピアリング

Azure では、次の種類のピアリングがサポートされています。
- 仮想ネットワーク ピアリング:同じ Azure リージョン内の仮想ネットワークを接続します。
- グローバル仮想ネットワーク ピアリング:Azure リージョン間で仮想ネットワークを接続します。

仮想ネットワークがグローバルにピアリングされている場合のみ、次の制約が適用されます。
- VNet内のリソースは、グローバルにピアリングされた仮想ネットワークの Basic 内部ロード バランサー (ILB) のフロントエンド IP アドレスと通信することはできません。
- Basic ロード バランサーを使用する[一部のサービス](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-faq#what-are-the-constraints-related-to-global-vnet-peering-and-load-balancers)は、グローバルな仮想ネットワーク ピアリングでは動作しません。 



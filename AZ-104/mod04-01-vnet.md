# 仮想ネットワーク コンポーネント

Azureには、広範なネットワークのサービスが用意されており、組織の要件に合ったインフラストラクチャを設計・ビルドするのに役立ちます。

一例
- [VNet](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-overview) - モジュール4で解説
- [VPN Gateway](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-about-vpngateways) - モジュール5で解説
- [Load Balancer](https://docs.microsoft.com/ja-jp/azure/load-balancer/load-balancer-overview) - モジュール6で解説
- [Application Gateway](https://docs.microsoft.com/ja-jp/azure/application-gateway/overview) - モジュール6で解説
- [Traffic Manager](https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-overview) - [DNSベースのトラフィック分散](https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-routing-methods)。
- [仮想WAN](https://docs.microsoft.com/ja-jp/azure/virtual-wan/virtual-wan-about) - ハブ&スポークアーキテクチャの統合ソリューション。「仮想ハブ」を中心として、複数のスポーク（オンプレミスやVNet）を接続。

# 仮想ネットワーク(VNet)

VNetは、クラウド内の、ユーザー独自の、論理的に分離された（閉じた）ネットワークです。

VPN接続のサポート：VNetに[VPN Gateway](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/) をデプロイすることで、[S2S（サイト間）VPN接続](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-howto-site-to-site-resource-manager-portal)と[P2S（ポイントつーサイト）接続](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/point-to-site-about)が可能。

[ピアリング接続](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-peering-overview)：2つ以上のVNetを接続。VNet間の双方向通信が可能。サブスクリプションやリージョンを越えてピアリングできます。

※VNetピアリングはモジュール5で解説。

クロスプレミス接続：VNetをオンプレミスに接続することです。VNetは、クロスプレミス接続を使用するようにも、[しないようにも](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-faq#can-i-use-vnets-without-cross-premises-connectivity)構成できます。[クロスプレミス接続のオプション](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-vpn-faq#what-are-my-cross-premises-connection-options)。

VNetと、他のVNetや、オンプレミスネットワークと接続する場合は、CIDRブロックが重複してはいけません。

例: 10.0.0.0/16 と 10.0.0.0/16 のネットワークは接続不可。

例: 10.0.0.0/16 と 10.1.0.0/16 のネットワークは接続可能。

# サブネット

VNetは、複数の[サブネット](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-vnet-plan-design-arm#subnets)に分割できます。

各サブネットには、仮想ネットワークのアドレス空間内に、CIDR 形式で指定された一意のアドレス範囲が必要です。 このアドレス範囲は、仮想ネットワーク内の他のサブネットと重複することはできません。

各サブネットには、0 個または 1 個のネットワーク セキュリティ グループを関連付けることができます。

VNetにデプロイするサービスでは、[専用のサブネット](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-for-azure-services#services-that-can-be-deployed-into-a-virtual-network)を必要とするものがあります。例：
- VPN Gatewayは「[GatewaySubnet](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-vpn-faq#do-i-need-a-gatewaysubnet)」という名前のサブネットにデプロイする必要があります。
- Azure Bastionは「[AzureBastionSubnet](https://docs.microsoft.com/ja-jp/azure/bastion/bastion-nsg#azurebastionsubnet)」という名前のサブネットにデプロイする必要があります。
- Azure Firewallは「[AzureFirewallSubnet](https://docs.microsoft.com/ja-jp/azure/firewall/tutorial-hybrid-portal#create-the-firewall-hub-virtual-network)」という名前のサブネットにデプロイする必要があります。


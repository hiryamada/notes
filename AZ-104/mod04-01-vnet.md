
# 仮想ネットワーク(VNet)

[PDF資料:ハブ・スポーク](../network/ハブ・スポーク.pdf)

```
VNet1 ............ 10.0.0.0/16
├サブネット1 .... 10.0.0.0/24
│└NIC .......... 10.0.0.4(プライベートIPアドレス), a.b.c.d(パブリックIPアドレス)
│  └VM1
└サブネット2 .... 10.0.1.0/24
  └NIC .......... 10.0.1.4(プライベートIPアドレス), e.f.g.h(パブリックIPアドレス)
    └VM2
```

VNetは、クラウド内の、ユーザー独自の、論理的に分離された（閉じた）ネットワークです。

VPN接続のサポート：VNetに[VPN Gateway](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/) をデプロイすることで、[S2S（サイト間）VPN接続](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-howto-site-to-site-resource-manager-portal)と[P2S（ポイントツーサイト）接続](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/point-to-site-about)が可能。

[ピアリング接続](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-peering-overview)：2つ以上のVNetを接続。VNet間の双方向通信が可能。サブスクリプションやリージョンを越えてピアリングできます。

クロスプレミス接続：VNetと、オンプレミス、ノートPC等（VPNデバイス）を接続すること。VNetは、クロスプレミス接続を使用するようにも、[しないようにも](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-faq#can-i-use-vnets-without-cross-premises-connectivity)構成できます。[クロスプレミス接続のオプション](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-vpn-faq#what-are-my-cross-premises-connection-options)。

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

# 専用サブネットの名前と最小サイズ

- GatewaySubnet(VPNのみの場合) 最小サイズ /29
- GatewaySubnet(ExpressRouteのみの場合) 最小サイズ /28
- GatewaySubnet(VPN/ExpressRoute併用の場合) 最小サイズ /27
- AzureBastionSubnet 最小サイズ /27
- AzureFirewallSubnet 最小サイズ /26

参考

- https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/azure-subscription-service-limits#azure-firewall-limits
- https://docs.microsoft.com/ja-jp/azure/bastion/quickstart-host-portal
- https://www.syuheiuda.com/?p=5311
# 仮想ネットワーク(Virtual Network, VNet)

- VNetは、Azureのプライベートなネットワーク。
- 仮想マシン（VM）はVNet（のサブネット内）に配置される。
- 分離性: 各VNetは論理的に隔離されている。

■アドレス空間

VNet作成時に、RFC 1918のプライベートアドレス空間を使用して、VNetで使用するアドレス空間を指定する。

他のVNetやオンプレミスネットワークとアドレス空間が重複してしまうと、ピアリングやVPNで接続することができなくなる。したがって、アドレス空間が重複しないように設計するとよい。


■インターネット接続

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-overview#communicate-with-the-internet

VNet 内のすべてのリソースにおいて、既定でインターネットへの送信方向の通信が可能。

■オンプレミス接続

- P2S(ポイント対サイト) VPN
  - オンプレミスの1台のコンピュータとVNetのVPN接続
- S2S(サイト間) VPN
  - オンプレミスのVPNルータとVNetのVPN接続
- Azure ExpressRoute
  - オンプレミスとの専用線接続
  - [まとめPDF](../AZ-500/pdf/mod2/ExpressRouteまとめ.pdf)

# サブネット

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-vnet-plan-design-arm#subnets

■分割

VNetは、複数のサブネットに分割できる。

- 各サブネットには、仮想ネットワークのアドレス空間内に、CIDR 形式で指定された一意のアドレス範囲が必要。
- このアドレス範囲は、仮想ネットワーク内の他のサブネットと重複することはできない。

■関連付け

サブネットには「ネットワークセキュリティグループ(NSG)」や「ルートテーブル」を関連付けることができる。

■専用のサブネット

VNetにデプロイするサービスでは、専用のサブネットを必要とするものがある。

一覧:
https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-for-azure-services#services-that-can-be-deployed-into-a-virtual-network


例：
- 仮想ネットワーク ゲートウェイ(VPNゲートウェイとExpressRoute用ゲートウェイ): 
  - 「[GatewaySubnet](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-vpn-faq#do-i-need-a-gatewaysubnet)」
  - VPNのみの場合 最小サイズ /29
  - ExpressRouteのみの場合 最小サイズ /28
  - VPN/ExpressRoute併用の場合 最小サイズ /27
  - [多数のExpressRoute回線を接続する場合は /26 が必要な場合がある](https://www.syuheiuda.com/?p=5311)
- [Azure Bastion](https://docs.microsoft.com/ja-jp/azure/bastion/quickstart-host-portal):
  - 「[AzureBastionSubnet](https://docs.microsoft.com/ja-jp/azure/bastion/bastion-nsg#azurebastionsubnet)」
  - 最小サイズ /27
- Azure Firewall:
  - 「AzureFirewallSubnet」
  - [最小サイズ /26](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/azure-subscription-service-limits#azure-firewall-limits)
- Application Gateway:
  - [専用サブネットが必要（名前はなんでもよい）](https://docs.microsoft.com/ja-jp/azure/application-gateway/configuration-infrastructure#virtual-network-and-dedicated-subnet)
  - 同じサブネット上に Standard_v2 と Standard Azure Application Gateway を混在できない
  - Standard または WAF SKU: 最小サイズ /26 推奨
  - Standard_v2 または WAF_v2 SKU: 最小サイズ /24 推奨


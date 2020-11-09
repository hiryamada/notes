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

# [仮想アプライアンス(NVA)](https://azure.microsoft.com/ja-jp/solutions/network-appliances/)

Network Virtual Appliance（NVA）は、下記のような機能を提供するAzure VMです。

- アプリケーション配信コントローラー(ADC)
- ファイアウォール
- 暗号化

製品例：Barracuda, Check Point, Cisco, Citrix, F5, Fortinet, NetApp, Paloalto, Trend Microなどの製品があります。

Azure Marketplaceからデプロイすることができます。

[NVAは、VNetにデプロイすることができます](https://docs.microsoft.com/ja-jp/learn/modules/control-network-traffic-flow-with-routes/)。


# [サービスエンドポイント](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-service-endpoints-overview)

サービス エンドポイントでは、Azure のバックボーン ネットワーク上で最適化されたルートを介して、Azure サービスに安全に直接接続できます。 

サービス エンドポイントを使用すると、VNet 内のプライベート IP アドレスは、VNet 上のパブリック IP アドレスを必要とせずに、Azure サービスのエンドポイントに接続できます。


[サービス エンドポイントを追加しても、パブリック エンドポイントは削除されません。 トラフィックがリダイレクトされるようになるだけです](https://docs.microsoft.com/ja-jp/learn/modules/secure-and-isolate-with-nsg-and-service-endpoints/4-vnet-service-endpoints)。

ストレージ アカウントでは、[ストレージアカウントのファイアウォール規則](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-network-security)を作成することで、指定したVNetのサブネット、指定したパブリックIPアドレス範囲からのみ、アクセスを許可することができます。

※ [サービスエンドポイントとAzure Private Linkとの使い分け](https://qiita.com/nakazax/items/937a512c0b69abdbd6cf#%E4%BD%BF%E3%81%84%E5%88%86%E3%81%91--%E4%BD%B5%E7%94%A8%E3%81%AE%E3%82%A2%E3%82%A4%E3%83%87%E3%82%A3%E3%82%A2)

# [ネットワーク セキュリティ グループ](https://docs.microsoft.com/ja-jp/azure/virtual-network/network-security-groups-overview)（NSG）

Azure 仮想ネットワーク内の Azure リソースが送受信するネットワーク トラフィックは、Azure ネットワーク セキュリティ グループを使ってフィルター処理できます。

NSGには0個以上のセキュリティ規則が含まれています。セキュリティ規則は、優先順位に従って処理され、数値が小さいほど優先順位が高くなります。トラフィックが規則に一致すると、処理が停止します。規則のアクションは、許可または拒否です。

ネットワーク セキュリティ グループはステートフルな処理を行います。たとえば、ポート 80 経由で任意のアドレスに送信セキュリティ規則を指定した場合、送信トラフィックへの応答に受信セキュリティ規則を指定する必要はありません。



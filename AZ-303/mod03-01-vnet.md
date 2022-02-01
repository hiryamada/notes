# 仮想ネットワーク(Virtual Network, VNet)

- VNetは、Azureのプライベートなネットワーク。
- 仮想マシン（VM）はVNet（のサブネット内）に配置される。
- 分離性: 各VNetは論理的に隔離されている。

■アドレス空間の選択

https://docs.microsoft.com/ja-jp/azure/virtual-network/manage-virtual-network#create-a-virtual-network

VNet作成時に、[RFC 1918](https://www.nic.ad.jp/ja/translation/rfc/1918.html)のプライベートアドレス空間を使用して、VNetで使用するアドレス空間を指定する。

- クラスA: 10.0.0.0～10.255.255.255 （10.0.0.0/8）
- クラスB: 172.16.0.0～172.31.255.255 （172.16.0.0/12）
- クラスC: 192.168.0.0～192.168.255.255 （192.168.0.0/16）

※上記以外のパブリックアドレス空間も指定可能。Microsoftは、プライベートアドレス空間、または、組織が所有するパブリックアドレス空間をVNetで使用することを推奨している。

他のVNetやオンプレミスネットワークとアドレス空間が重複してしまうと、ピアリングやVPNで接続することができなくなる。したがって、アドレス空間が重複しないように設計する。

■インターネット接続

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-overview#communicate-with-the-internet

VNet 内のすべてのリソースにおいて、既定でインターネットへの送信方向の通信が可能。

[インターネット接続を禁止する設定も可能](https://social.msdn.microsoft.com/Forums/Azure/en-US/09a91263-6fdf-4900-bf0b-89d1476fae9c/20206248191249312483124881252712540124631236312425124521253112?forum=windowsazureja)。

[すべてのインターネット接続トラフィックをオンプレミスに流すことも可能（強制トンネリング）](https://www.syuheiuda.com/?p=3685)。

■オンプレミス接続

- VPN
  - [S2S(サイト間) VPN](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/design#site-to-site)
    - オンプレミスのVPNルータとVNetのVPN接続
  - [P2S(ポイント対サイト) VPN](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/design#point-to-site-vpn)
    - 個々のクライアントコンピュータとVNetのVPN接続
- [Azure ExpressRoute](https://docs.microsoft.com/ja-jp/azure/expressroute/expressroute-introduction)
  - オンプレミスとの専用線接続
  - [まとめPDF](../AZ-500/pdf/mod2/ExpressRouteまとめ.pdf)

# サブネット

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-vnet-plan-design-arm#subnets

■分割

VNetは、複数のサブネットに分割できる。

- 各サブネットには、VNetのアドレス空間内に、CIDR 形式で指定された一意のアドレス範囲が必要。
- アドレス範囲は、VNet内の他のサブネットと重複することはできない。

例:
```
vnet1: 10.0.0.0/16
├subnet1: 10.0.0.0/24
└subnet2: 10.0.1.0/24
```

■関連付け

サブネットには「ネットワークセキュリティグループ(NSG)」や「ルートテーブル」を関連付けることができる。

例1:
```
vnet1
├subnet1 - nsg1
└subnet2 - nsg2
```

例2:
```
vnet1
├subnet1 - routetable1
└subnet2 - routetable2
```

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

■ハンズオン: VNetとサブネットの作成

```
az group create -l eastus -n rg1

az network vnet create \
	-n vnet1 \
	-g rg1 \
	--address-prefixes 10.0.0.0/16 \
	--subnet-name subnet1 \
	--subnet-prefix 10.0.0.0/24 

az network vnet create \
	-n vnet2 \
	-g rg1 \
	--address-prefixes 10.1.0.0/16 \
	--subnet-name subnet1 \
	--subnet-prefix 10.1.0.0/24 
```

■ハンズオン: VMの作成

```

az vm create \
	-n vm1 \
	-g rg1 \
	--vnet-name vnet1 \
	--subnet subnet1 \
	--size Standard_D2s_v5 \
	--image UbuntuLTS \
	--admin-username azureuser \
	--generate-ssh-keys \
	--public-ip-sku Standard \
	--private-ip-address 10.0.0.4

```

publicIpAddress が表示されるので、記録しておく。

ssh azureuser@(表示されたvm1のpublicIpAddress)
...
Are you sure you want to continue connecting (yes/no)? yes

azureuser@vm1:~$ exit

```

publicIpAddress が表示されるので、記録しておく。

ssh azureuser@(表示されたvm1のpublicIpAddress)
...
Are you sure you want to continue connecting (yes/no)? yes

azureuser@vm1:~$ exit

```
az vm create \
	-n vm2 \
	-g rg1 \
	--vnet-name vnet2 \
	--subnet subnet1 \
	--size Standard_D2s_v5 \
	--image UbuntuLTS \
	--admin-username azureuser \
	--generate-ssh-keys \
	--public-ip-sku Standard \
	--private-ip-address 10.1.0.4

publicIpAddress が表示されるので、記録しておく。
```

# ルートテーブル / UDR (ユーザー定義ルート)

■ルートテーブル
https://learn.microsoft.com/ja-jp/azure/virtual-network/manage-route-table

- 各サブネットには、0 個または 1 個のルート テーブルを関連付けることができます。
- ルート テーブルを作成し、0 個以上の仮想ネットワーク サブネットに関連付けます。

```
VNet
└サブネット
 └ルートテーブル
```

■UDR
https://learn.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-udr-overview#user-defined


ユーザー定義 (静的) のルートを作成して、Azure の既定のシステム ルートをオーバーライドしたり、サブネットのルート テーブルにルートを追加したりできます。

```
ルートテーブル
├ユーザー定義ルート(UDR)
├BGPのルート
└システム ルート
```

※システムルート: システム ルートが自動的に作成され、仮想ネットワークの各サブネットに割り当てられます。 システム ルートは作成することも削除することもできませんが、システム ルートをカスタム ルートでオーバーライドできます。 Azure では、サブネットごとに既定のシステム ルートが作成されます。また、Azure の特定の機能を使用するときは、特定のサブネットまたはすべてのサブネットにオプションの既定のルートが追加されます。https://learn.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-udr-overview#system-routes

※BGPのルート: BGP を使用して Azure とルートを交換すると、仮想ネットワークのすべてのサブネットのルート テーブルに、アドバタイズされた各プレフィックスの個別のルートが追加されます。 https://learn.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-udr-overview#border-gateway-protocol

■ルートの選択

- 送信トラフィックがサブネットから送信されると、Azure は最長プレフィックス一致アルゴリズムを使用して、宛先 IP アドレスに基づいてルートを選択します。
- 複数のルートに同じアドレス プレフィックスが含まれている場合は、次の優先順位に基づいてルートの種類が選択されます。

1. ユーザー定義のルート
2. BGP のルート
3. システム ルート

■ルートテーブル / UDRの使用例

例1: サブネットからのトラフィックをすべてVPN経由でオンプレミスに転送する

UDRのネクストホップ=VirtualNetworkGateway

```
VNet
├GatewaySubnet
│└仮想ネットワークゲートウェイ(type: VPN) - オンプレミス
└Subnet1
 ├VM
 └ルートテーブル (0.0.0.0->仮想ネットワークゲートウェイ)
```

例2: サブネットからのトラフィックをすべて「ネットワーク仮想アプライアンス」(NVA)や「Azure Firewall」経由でインターネットに送信する

※[NVA](https://azure.microsoft.com/ja-jp/solutions/network-appliances/): VMの形でデプロイされるファイアウォール、ルーター、ロードバランサー等


UDRのネクストホップ=VirtualAppliance(仮想アプライアンス)

```
VNet
├Subnet1
│└NVA - インターネット
└Subnet1
 ├VM
 └ルートテーブル (0.0.0.0->NVA)
```

UDRのネクストホップ=VirtualAppliance(仮想アプライアンス) [※Azure Firewallの場合もネクストホップはVirtualApplianceとする](https://learn.microsoft.com/ja-jp/azure/firewall/tutorial-firewall-deploy-portal#create-a-default-route)

```
VNet
AzureFirewallSubnet
│└Azure Firewall - インターネット
└Subnet1
 ├VM
 └ルートテーブル (0.0.0.0->Azure Firewall)
```

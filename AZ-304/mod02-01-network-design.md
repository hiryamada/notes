# 仮想ネットワークの設計

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-vnet-plan-design-arm

■アドレス空間

https://docs.microsoft.com/ja-jp/azure/virtual-network/manage-virtual-network#create-a-virtual-network

VNet作成時に、[RFC 1918](https://www.nic.ad.jp/ja/translation/rfc/1918.html)のプライベートアドレス空間を使用して、VNetで使用するアドレス空間を指定する。

- クラスA: 10.0.0.0～10.255.255.255 （10.0.0.0/8）
- クラスB: 172.16.0.0～172.31.255.255 （172.16.0.0/12）
- クラスC: 192.168.0.0～192.168.255.255 （192.168.0.0/16）

※上記以外のパブリックアドレス空間も指定可能。Microsoftは、プライベートアドレス空間、または、組織が所有するパブリックアドレス空間をVNetで使用することを推奨している。

他のVNetやオンプレミスネットワークとアドレス空間が重複してしまうと、ピアリングやVPNで接続することができなくなる。したがって、アドレス空間が重複しないように設計する。

■サブネット

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-vnet-plan-design-arm#subnets

VNetは、複数のサブネットに分割できる。

- 各サブネットには、VNetのアドレス空間内に、CIDR 形式で指定された一意のアドレス範囲が必要。
- アドレス範囲は、VNet内の他のサブネットと重複することはできない。

例:
```
vnet1: 10.0.0.0/16
├subnet1: 10.0.0.0/24
└subnet2: 10.0.1.0/24
```

■サブネットへの関連付け

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

■仮想ネットワークのリージョン

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-vnet-plan-design-arm#regions

仮想ネットワークのリージョンを決める必要がある。

仮想ネットワーク内のリソース（VM等）は、仮想ネットワークと同じリージョンに配置されなければならない。

仮想ネットワークを作成した時点で、その中に作成されるVMのリージョンも決まる。

リージョンによって以下が決まる。これらのものを考慮しながらリージョンを決定する。

- 利用者からのネットワーク待機時間（レイテンシ）。
  - 利用者から遠いリージョンになればなるほど、レイテンシが長くなる。
  - ただし、バッチ処理など、リアルタイム性が要求されないアプリケーションでは、レイテンシが長くなっても利用者に影響はない。
- 利用できるAzureサービスや機能、VMのサイズ
- データの保存場所
- 可用性ゾーンの有無
- リソースのコスト

■サブスクリプション

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-vnet-plan-design-arm#subscriptions

サブスクリプションの制限の範囲内で、仮想ネットワークやパブリックIPアドレスなどを作成できる。

1サブスクリプションあたり、1リージョン内
- 仮想ネットワーク: 最大1000個
- パブリックIPアドレス: 最大256個
- [その他の制限](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/azure-subscription-service-limits?toc=/azure/virtual-network/toc.json#networking-limits)

1つのサブスクリプションに多数のリソースをデプロイすると、サブスクリプションの制限に達する場合がある。

この場合は[複数のサブスクリプションを使い分ける（追加のサブスクリプションを使用する）](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/azure-best-practices/scale-subscriptions)か、（申請によって上限値が上げられる場合）[Azureサポートに上限緩和の申請を行う（無料）](https://docs.microsoft.com/ja-jp/azure/azure-portal/supportability/networking-quota-requests)。

■ネットワークリソースの名前付け

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-vnet-plan-design-arm#naming

[リソース名の規則](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/resource-name-rules#microsoftnetwork)に従い、名前をつける必要がある。

例: 仮想ネットワーク: 1 ～ 80文字、英数字、アンダースコア、ピリオド、およびハイフン。英数字で開始、英数字またはアンダースコアで終了。

「クラウド導入フレームワーク」に、一般的なAzureリソースの名前付けに関するベストプラクティス資料がある。
- [Azure リソースの名前付けおよびタグ付けの戦略](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/azure-best-practices/naming-and-tagging)
- [名前付け規則を定義する](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/azure-best-practices/resource-naming)
- [Azure リソースの種類に推奨される省略形](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/azure-best-practices/resource-abbreviations)
  - 例: 仮想ネットワーク: 「vnet-」という接頭辞を使用する

■セグメンテーション

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-vnet-plan-design-arm#segmentation

仮想ネットワークやサブネットをどのように分けるか。

以下のような事項について確認する。

- トラフィックを分割する必要があるか。
- リージョンを使い分ける必要があるか。
- オンプレミスや別の仮想ネットワークに接続する必要があるか。
- 異なる管理要件があるか（仮想ネットワークのアクセス権をどのように設定するか）。

■ネットワークセキュリティ

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-vnet-plan-design-arm#security

[ネットワークセキュリティグループ（NSG）](https://docs.microsoft.com/ja-jp/azure/virtual-network/network-security-groups-overview)、[Azure Firewall](https://docs.microsoft.com/ja-jp/azure/firewall/overview)、[NVA(ネットワーク仮想アプライアンス)](https://azure.microsoft.com/ja-jp/solutions/network-appliances/)などを使用して、仮想ネットワークに出入りするトラフィックを制御する。

■アクセス許可

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-vnet-plan-design-arm#permissions

[Azure RBACロール](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/overview)を使用して、仮想ネットワークのアクセス権を制御できる。

ネットワーク関連の「組み込みのロール」の例:

- [Network Contributor](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#network-contributor)
- [DNS Zone Contributor](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#dns-zone-contributor)
- [Private DNS Zone Contributor](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#private-dns-zone-contributor)
- [Traffic Manager Contributor](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#traffic-manager-contributor)
- [CDN Endpoint Contributor](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#cdn-endpoint-contributor)
- [CDN Endpoint Reader](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#cdn-endpoint-reader)
- [CDN Profile Contributor](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#cdn-profile-contributor)

より細かい権限割り当てが必要な場合は[カスタムロール](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/custom-roles)を作成する。

たとえば、必要に応じて「VPN管理者」といったカスタムロールを作成し、ユーザーに割り当てすることができる。

[カスタムロール内で指定できるアクションの一覧](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/resource-provider-operations#networking)


■ポリシー

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-vnet-plan-design-arm#policy

Azure Policyを使用して、組織のポリシーを割り当て、リソースが組織のコンプライアンスを遵守するようにすることができる。

例: サブスクリプション以下のリソースが、許可されたリージョン内にあることを強制するポリシーを割り当てる。

ポリシーは以下の場所（スコープ）にて割り当てすることができる。

```
管理グループ
└サブスクリプション
 └リソースグループ
  └リソース（VM等のみ）
```

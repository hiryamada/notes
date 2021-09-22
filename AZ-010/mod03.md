■Azureのグローバルインフラストラクチャー

https://azure.microsoft.com/ja-jp/global-infrastructure/

https://infrastructuremap.microsoft.com/

操作例
- Skip Intro
- Explore the globe
- 地球儀を回して日本を表示する
- マウスホイールで拡大・縮小
- 東日本リージョンをクリック

■Azureのデータセンター

データセンターの詳細な場所は公開されていない。

例: 東日本リージョンは東京と埼玉にデータセンターが存在。

https://docs.microsoft.com/ja-jp/azure/security/fundamentals/physical-security

バーチャルツアー
https://news.microsoft.com/stories/microsoft-datacenter-tour/

操作例
- Start Exploring
- Enter The Lobby
- Explore Lobby
- Enter Server Room
- Explore Server Room
- Server Blades


■Azureのリージョン

データセンターの集まり。

Azureのリージョン: 60箇所
https://azure.microsoft.com/ja-jp/global-infrastructure/services/

> 他のどのクラウド プロバイダーよりも多い 60 か所のリージョンを公表済み

各リージョンの詳細情報
https://azure.microsoft.com/ja-jp/global-infrastructure/geographies/#overview

リージョン別の利用可能な製品
https://azure.microsoft.com/ja-jp/global-infrastructure/services/

リージョンと、データの保存場所
https://azure.microsoft.com/ja-jp/global-infrastructure/data-residency/#select-geography

リージョン別の「Azureの状態」
https://status.azure.com/ja-jp/status

最近のニュース: 2021/6 アリゾナ州に新たなリージョンWest US 3を解説
https://www.google.com/search?q=microsoft+%E3%82%A2%E3%83%AA%E3%82%BE%E3%83%8A%E5%B7%9E

■リージョンのペア

https://docs.microsoft.com/ja-jp/azure/best-practices-availability-paired-regions

基本的に、同じ「地域」内に2つのリージョンがあり、「ペア」（Pair, 対）を形成している。

例: 「日本」という地域には、「東日本リージョン」と「西日本リージョン」が存在し、ペアを形成している。

Azureのサービスのいくつかでは、ペアのリージョンを使用して、サービスの可用性やデータの耐久性を高めている。

例: ストレージアカウントの作成時、レプリケーションオプションで「Geo冗長ストレージ」(Geo Redundancy Storage: GRS)を選択すると、データはペアのリージョンに自動的にレプリケーション（複製）される。

https://docs.microsoft.com/ja-jp/azure/storage/common/storage-redundancy

■可用性ゾーン

https://docs.microsoft.com/ja-jp/azure/availability-zones/az-overview#availability-zones

Azureのリージョンには、「可用性ゾーン」（Availability Zones）に対応しているものがある。

例: 東日本リージョンは可用性ゾーンに対応（3ゾーン）。西日本リージョンは可用性ゾーン非対応。

可用性ゾーンに対応しているリージョンには少なくとも3つのゾーンが存在する。

※ただし、現時点で3つより多いゾーンを持つリージョンは存在しない。

Azure仮想マシンなど、いくつかのサービス/リソースは、可用性ゾーンに対応している。

例1: 仮想マシンは、デプロイ時にゾーンを指定することができる。

例2: Azureロードバランサーは、ゾーンを指定したり、「ゾーン冗長」（複数のゾーンにまたがって1つのリソースをデプロイ）を指定したりすることができる。

例3: ストレージアカウントの作成時、レプリケーションオプションで「ゾーン冗長ストレージ」(Zone Redundancy Storage: ZRS)を選択すると、データはリージョン内の3つのゾーンに自動的にレプリケーション（複製）される。

■仮想ネットワーク Virtual Network, VNet

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-overview

それぞれのVNetは「論理的に」隔離されている。

VNetの利用例:

- 複数のシステムの運用。VNet1でシステムA、VNet2でシステムBを運用するなど。
- 複数の環境の運用。VNet1で本番環境、VNet2で開発環境を運用するなど。

```
VNet
└サブネット
```

VNet作成時に、「IPv4 アドレス空間」をCIDR形式で指定する。例: `10.0.0.0/16`

そのVNetを小さく区切る「サブネット」を1つ以上、同時に定義する。例: `10.0.0.0/24`

サブネットはあとから追加・削除することが可能。

AWSとは異なり、サブネットに対する可用性ゾーンの指定はない。（仮想マシンのデプロイ時に、仮想マシンに対して可用性ゾーンを指定することができる）

サブネットを作る理由:

- ネットワークセキュリティグループの関連付けにより、トラフィックを制御
- ルートテーブルの関連付けにより、ルーティングを制御
- VNetにデプロイするサービスでは、[専用のサブネット](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-for-azure-services#services-that-can-be-deployed-into-a-virtual-network)を必要とするものがある。例：
  - VPN Gatewayは「[GatewaySubnet](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-vpn-faq#do-i-need-a-gatewaysubnet)」という名前のサブネットにデプロイ
  - Azure Bastionは「[AzureBastionSubnet](https://docs.microsoft.com/ja-jp/azure/bastion/bastion-nsg#azurebastionsubnet)」という名前のサブネットにデプロイ
  - Azure Firewallは「[AzureFirewallSubnet](https://docs.microsoft.com/ja-jp/azure/firewall/tutorial-hybrid-portal#create-the-firewall-hub-virtual-network)」という名前のサブネットにデプロイ

■IPアドレス

パブリックIPアドレス:
https://docs.microsoft.com/ja-jp/azure/virtual-network/public-ip-addresses

パブリックIPアドレスは独立したリソース。AWSでいうElastic IPに近い。

- 動的: 関連付けられたVMが起動すると具体的なアドレスが割り当てられる。
- 静的: VMの状態に関係なく具体的なアドレスが割り当てられる。

プライベートIPアドレス:
https://docs.microsoft.com/ja-jp/azure/virtual-network/private-ip-addresses

- 動的: サブネットのアドレス範囲から自動で選択
- 静的: サブネットのアドレス範囲から明示的に指定

パブリックIPアドレス/プライベートIPアドレスは、仮想マシンのNIC（ネットワークインターフェースカード）などに関連付けられる。

```
VNet
└サブネット
 └NIC - パブリックIPアドレス/プライベートIPアドレス
   └VM
```

■ネットワークセキュリティグループ(Network Security Group, NSG)

https://docs.microsoft.com/ja-jp/azure/virtual-network/network-security-groups-overview

IPアドレス、ポート、プロトコル（TCP等）を指定して、受信・送信のネットワークトラフィックを許可・拒否するしくみ。

NICやサブネットに関連付けることができる。

たとえば、Webサーバーを運用する場合、TCP 80番の受信を許可したNSGを作成し、VMのNIC、または、VMがデプロイされているサブネットに関連付ける。

NSGは、ステートフルな制御を行う。例: 受信セキュリティ規則で許可されたトラフィックの戻りのトラフィックに対する送信のセキュリティ規則は不要。

構造:

- 名前
- セキュリティ規則
  - 受信セキュリティ規則
    - ユーザーが追加する規則...
    - デフォルトの規則...
  - 送信セキュリティ規則
    - ユーザーが追加する規則...
    - デフォルトの規則...

「セキュリティ規則」のプロパティ (Azure portalの表示順):

- ソース - Any / IPアドレス or CIDRブロック / サービス タグ / ASG
- ソースポート範囲 - * 等
- 宛先 - Any / IPアドレス or CIDRブロック / サービス タグ / ASG
- サービス - HTTP等 (選択すると、プロトコルと宛先ポートが自動入力される)
- プロトコル Any / TCP / UDP / ICMP
- 宛先ポートの範囲 80 / 80-81 / 80,81 / 80,81-82 / * など
- アクション: 許可 / 拒否
- 優先度 100～4096, 小さいほど優先度が高い
- 名前: 作成後の変更は不可!!
- 説明

関連付け:
- ネットワークインターフェース(NIC)
- サブネット

https://docs.microsoft.com/ja-jp/azure/virtual-network/network-security-group-how-it-works#intra-subnet-traffic

> 特別な理由がない限り、ネットワーク セキュリティ グループをサブネット **または** ネットワーク インターフェイスに関連付けることをお勧めします。**両方に** 関連付けることは、お勧めしません。 サブネットに関連付けられたネットワーク セキュリティ グループの規則が、ネットワーク インターフェイスに関連付けられたネットワーク セキュリティ グループの規則と競合する可能性があるため、予期しない通信の問題が発生し、トラブルシューティングが必要になることがあります。

受信トラフィックの規則の処理:
- サブネットに関連付けられているNSGがあれば、まずその規則を処理
- 次にNICに関連付けられているNSGがあれば、その規則を処理
- ※サブネットにもNICにもNSGの関連付けがない場合は、トラフィックはすべて許可される

送信トラフィックの規則の処理:
- NICに関連付けられているNSGがあれば、その規則を処理
- 次にサブネットに関連付けられているNSGがあれば、その規則を処理
- ※NICにもサブネットにもNSGの関連付けがない場合は、トラフィックはすべて許可される

サブネット内のトラフィック:
- サブネットに関連付けたNSGのセキュリティ規則は、サブネットの内部にあるVM間の接続に影響する。
- 例: SSH接続を拒否するルールを持つNSGをサブネットに関連付ける
  - サブネットの外からサブネットの中のVMにSSH接続ができなくなる。
  - **サブネット内での** 、あるVMから別のVMへのSSH接続もできなくなる。

参考: AWS VPCの[セキュリティグループ](https://docs.aws.amazon.com/ja_jp/vpc/latest/userguide/VPC_SecurityGroups.html#VPCSecurityGroups)との違い
- AWS: 拒否は指定できない Azure: 拒否を指定できる
- AWS: 送信元として別のセキュリティグループを指定できる。 Azure: 送信元として別のNSGを指定することはできない(ASGを使用)

■VNetピアリング

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-peering-overview

- VNet ピアリング: 同じ Azure リージョン内の2つのVNetを接続
- グローバルVNet ピアリング: 異なるAzure リージョン間の2つのVNetを接続

■VPNゲートウェイ

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-about-vpngateways

VNetとオンプレミスネットワークをVPN接続する際に利用する。

GatewaySubnetという名前の専用サブネットにデプロイする必要がある。

```
VNet
├サブネット
└GatewaySubnet
  └VPNゲートウェイ
    | VPN接続
   オンプレミス側のVPNルータ(ローカルゲートウェイ)
    |
   オンプレミスネットワーク
```

■ExpressRoute

https://docs.microsoft.com/ja-jp/azure/expressroute/expressroute-introduction

VNetとオンプレミスネットワークとの専用線接続。

[PDFまとめ](../AZ-500/pdf/mod2/ExpressRouteまとめ.pdf)

■Azure Load Balancer/Application Gateaway

Azure Load Balancer: L4(AWS NLBに相当)
https://docs.microsoft.com/ja-jp/azure/load-balancer/load-balancer-overview

Application Gateway: L7(AWS ALBに相当)
https://docs.microsoft.com/ja-jp/azure/application-gateway/overview

[PDF図解](../AZ-104/pdf/mod06/ロードバランサー.pdf)

■Network Watcher

https://docs.microsoft.com/ja-jp/azure/network-watcher/network-watcher-monitoring-overview

Azure Network Watcher は、Azure 仮想ネットワーク内のリソースの監視、診断、メトリックの表示、ログの有効化または無効化を行うツールを提供.

[PDFまとめ](../AZ-104/pdf/mod11/Network%20Watcher.pdf)

■ラボ4,6 仮想ネットワーク/トラフィック管理

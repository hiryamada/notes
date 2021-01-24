# IPアドレス

ドキュメント

- [パブリックIPアドレス](https://docs.microsoft.com/ja-jp/azure/virtual-network/public-ip-addresses)
- [プライベートIPアドレス](https://docs.microsoft.com/ja-jp/azure/virtual-network/private-ip-addresses)

- [パブリック IP アドレスの管理](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-public-ip-address)

Microsoft Learn

- [AZ-104:Azure 管理者向けの前提条件](https://docs.microsoft.com/ja-jp/learn/paths/az-104-administrator-prerequisites/)
  - [コンピューター ネットワークの基礎](https://docs.microsoft.com/ja-jp/learn/modules/network-fundamentals/)
    - [IP アドレスの標準とサービス](https://docs.microsoft.com/ja-jp/learn/modules/network-fundamentals/5-ip-tcp-basics)
- [AZ-104:Azure 管理者向けの仮想ネットワークの構成と管理](https://docs.microsoft.com/ja-jp/learn/paths/az-104-manage-virtual-networks/)
  - [Azure デプロイの IP アドレス指定スキーマを設計する](https://docs.microsoft.com/ja-jp/learn/modules/design-ip-addressing-for-azure/)
- [AZ-104:Azure のコンピューティング リソースのデプロイと管理](https://docs.microsoft.com/ja-jp/learn/paths/az-104-manage-compute-resources/)
  - [Azure で Linux 仮想マシンを作成する](https://docs.microsoft.com/ja-jp/learn/modules/create-linux-virtual-machine-in-azure/)
  - [Azure で Windows 仮想マシンを作成する](https://docs.microsoft.com/ja-jp/learn/modules/create-windows-virtual-machine-in-azure/)
- [Windows Server IaaS VM のネットワークを実装する](https://docs.microsoft.com/ja-jp/learn/paths/implement-windows-server-iaas-virtual-machine-networking/)

最新情報

- [Public IP SKU upgrade generally available](https://azure.microsoft.com/ja-jp/updates/public-ip-sku-upgrade-generally-available/) - Public IP(とLoad Balancer)について、IPアドレスを変更せず、BasicからStandardへのアップグレードが可能に。PowerShell, CLI, テンプレート、APIから。[参考](https://kogelog.com/2021/01/14/20210114-01/)

# プライベートIPアドレス

VNet内での通信に使用されます。

VPN GateawayやExpressRoute回線を使用してオンプレミスとVNetを接続している場合、オンプレミスとの通信でも使用されます。

# パブリックIPアドレス

インターネットとの通信に使用されます。

# 静的と動的

静的：固定のIPアドレスを割り当てます。

動的：IPアドレスを割り当てられたVMが起動したときに、IPアドレスの値が動的に決まります。VMを停止すると、IPアドレスの値はなくなります。

# [IPアドレスのSKU](https://docs.microsoft.com/ja-jp/azure/virtual-network/public-ip-addresses#sku)

BasicとStandardがあります。Standardは、可用性ゾーンのシナリオをサポートします。

ロード バランサー リソースとパブリック IP リソースには一致する SKU を使用する必要があります。 

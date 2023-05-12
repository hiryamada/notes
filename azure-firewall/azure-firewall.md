# Azure Firewall

Firewall as a Service (FWaaS)

2018/9/24 Azure Firewall 一般提供開始
https://azure.microsoft.com/ja-jp/updates/azure-firewall-generally-available/

2020/7/1 Azure Firewall Manager / ファイアウォール ポリシー 一般提供開始
https://azure.microsoft.com/ja-jp/blog/azure-firewall-manager-is-now-generally-available/

2021/7/19 Azure Firewall Premium 一般提供開始
https://azure.microsoft.com/ja-jp/updates/announcing-the-azure-firewall-premium-general-availability/

2023/3/15 Azure Firewall Basic 一般提供開始
https://azure.microsoft.com/en-us/updates/generally-available-azure-firewall-basic/

■サポートチームによる解説

NSG / WAF / IDS / IPSとの違い
https://jpaztech.github.io/blog/network/difference-nsg-fw/


■Azure Firewall の SKU

- Basic - スループット 250 Mbps まで
- Standard - スループット 30 Gbps まで
- Premium - スループット 100 Gbps まで

[機能の比較](https://learn.microsoft.com/ja-jp/azure/firewall/choose-firewall-sku)


Basicの利用例
https://zenn.dev/zukako/articles/54ff7c1c437fe4

■Azure Firewall Manager

https://learn.microsoft.com/ja-jp/azure/firewall/overview#azure-firewall-manager

複数のサブスクリプションにまたがる Azure Firewall を一元的に管理。

■脅威インテリジェンス ベース フィルター

脅威インテリジェンス: 情報セキュリティの専門家が分析・整理したサイバーセキュリティに関する情報の総称。
https://www.sompocybersecurity.com/column/glossary/threat-intelligence-definition

Microsoft の 脅威インテリジェンス フィード:

脅威インテリジェンスベースフィルター
https://learn.microsoft.com/ja-jp/azure/firewall/threat-intel

既知の悪意のある IP アドレス、FQDN、URL との間のトラフィックのアラートを発行し、拒否を行う。

■仮想ネットワーク

Azure Firewallは、仮想ネットワークの内部に配置する必要がある。

```
VNet
└AzureFirewallSubnet (/26)
  └Azure Firewall
```

AzureFirewallSubnetにはNSGは不要であり、適用しない。

- https://learn.microsoft.com/ja-jp/security/benchmark/azure/baselines/azure-firewall-security-baseline?toc=https%3A%2F%2Flearn.microsoft.com%2Fja-jp%2Fazure%2Farchitecture%2Ftoc.json&bc=https%3A%2F%2Flearn.microsoft.com%2Fja-jp%2Fazure%2Farchitecture%2Fbread%2Ftoc.json#network-security-group-support
- https://learn.microsoft.com/ja-jp/azure/firewall/firewall-faq#azurefirewallsubnet----------------------nsg--------------

■パブリックIPアドレス

Azure Firewallに、最大250個のパブリックIPアドレスを追加できる。

```
パブリックIPアドレス
|
Azure Firewall
```

パブリック IP アドレスを使用せずに Azure Firewall をデプロイすることもできるが、「強制トンネリング モード」でファイアウォールを構成する必要がある。
https://learn.microsoft.com/ja-jp/azure/firewall/firewall-faq#------ip------------azure-firewall-----------

■受信 (DNAT)

https://learn.microsoft.com/ja-jp/azure/firewall/tutorial-firewall-dnat

インターネットからのトラフィックをAzure Firewallで受信し、バックエンドサーバーに送信できる。

```
インターネット
↓
Azure Firewall
↓
VM
```


■送信 (SNAT)

https://jpaztech.github.io/blog/network/fw-snat/

VNet内部からのトラフィックをAzure Firewallからインターネットへ送信できる。

```
インターネット
↑
Azure Firewall
↑
VM
```

■NATゲートウェイの併用

https://jpaztech.github.io/blog/network/fw-snat/

https://learn.microsoft.com/ja-jp/azure/firewall/integrate-with-nat-gateway

NAT ゲートウェイ リソースが Azure Firewall サブネットに関連付けられている場合、すべての送信インターネット トラフィックで、NAT ゲートウェイのパブリック IP アドレスが自動的に使用される。

Azure Firewallのみ: 最大 250 個のパブリックIPアドレス x パブリックIPアドレス1個あたり2496個のSNATポート = 624,000 SNATポート

Azure Firewall + NAT ゲートウェイ: 最大 16 個のパブリックIPアドレス x パブリックIPアドレス1個あたり64,512個のSNATポート = 1,032,192 SNATポート

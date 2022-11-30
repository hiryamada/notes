# 境界セキュリティ

■多層防御

- [多層防御](../../network/defense-in-depth.md)
- 参考: [ゼロトラスト戦略](../../SC/zero-trust.md)
- 参考: [LAPS](../../network/laps.md)

■仮想ネットワーク(VNet)の基礎

- [PDF: ネットワークセキュリティ関連サービス全体像](../pdf/mod2/ネットワークセキュリティ関連サービス.pdf)
- [PDF: ハブ&スポーク トポロジー](../../network/ハブ・スポーク.pdf)
- [仮想ネットワーク(VNet)](../../network/vnet.md)
- [サブネット](../../network/subnet.md)
- [ネットワークインターフェースカード(NIC)](../../network/nic.md)
- [ルートテーブル / ユーザー定義のルート(UDR)](../../network/udr.md)
- [パブリック/プライベートIPアドレス](../../network/ip-address.md)
- [サービス タグ](../../network/service-tag.md)

■オンプレミス接続

- [仮想ネットワークゲートウェイ](../../network/virtual-network-gateway.md)
- [VPN](../../network/vpn.md)
- [ExpressRoute](../../network/er.md)
- [強制トンネリング](../../network/forced-tunneling.md)

■仮想ネットワークのトポロジ

- [ピアリング接続](../../AZ-104/mod05-01-peering.md)
- [ハブ スポーク トポロジ](../../network/hub-spoke.md)
- [Azure Virtual WAN](../../AZ-104/mod05-04-virtualwan.md)

# ネットワーク セキュリティ

■仮想ネットワーク(VNet)のセキュリティ

- [ネットワーク セキュリティ グループ (NSG)](../../AZ-700/nsg.md)
- [アプリケーション セキュリティ グループ (ASG)](../../network/asg.md)
- [ネットワーク仮想アプライアンス (NVA)](../../network/nva.md)
- [Azure Firewall](../../network/azure-firewall.md)
- [DDoS保護(Azure DDoS Protection)](../../network/ddos-protection.md)

[ラボ: NSG/ASG](https://github.com/MicrosoftLearning/AZ500-AzureSecurityTechnologies.ja-jp/blob/main/Instructions/Labs/LAB_07_NSGs.md)

[ラボ: Azure Firewall](https://github.com/MicrosoftLearning/AZ500-AzureSecurityTechnologies.ja-jp/blob/main/Instructions/Labs/LAB_08_AzureFirewall.md)

■VNet(VM)からAzureサービスへのプライベート接続

- [サービス エンドポイント](../../network/service-endpoint.md)
- [プライベート リンク](../../network/private-link.md)
- [PDF資料 サービスエンドポイントとプライベートエンドポイント設定例](../pdf/mod2/サービスエンドポイントとプライベートエンドポイント設定例.pdf)

■ロードバランサー（負荷分散）サービス

- [PDF: 負荷分散サービスまとめ](../pdf/mod2/負荷分散サービス.pdf)
- [Azure Application Gateway](../../network/appgw.md)
- [Azure Front Door](../../network/front-door.md)
- [Web アプリケーション ファイアウォール(Azure WAF)](../../AZ-303/mod05-07-waf.md)

# ホスト セキュリティ

■ホスト（エンドポイント）の保護

- [エンドポイント保護](../../SC/endpoint-protection/endpoint-protection.md)

■ホストへの管理アクセス

- Windows: RDP (TCP 3389)
- Linux: SSH (TCP 22)
- [Azure Bastion](azure-bastion.md)

■ホストの更新

- [Azure Automation](../../iac/azure-automation.md)

■ホストのデータの保護

- [ディスク暗号化(Azure Disk Encryption)](../../SC/encryption/azure-disk-encryption.md)

■Windowsホストの保護機能

- [Windows Defender](windows-defender.md)

■クラウドのホストの保護と監視

- [Microsoft Defender for Cloud](microsoft-defender-for-cloud.md)

■セキュリティベンチマーク

- [Microsoftクラウドセキュリティベンチマーク](../../SC/microsoft-security-benchmark.md)
  - 旧「Azure セキュリティベンチマーク」, 2022/10にリブランディング

# コンテナー セキュリティ

講義: [コンテナー セキュリティ](mod02-04.md)

- コンテナー型の仮想化
- Azure Container Instances (ACI)
- Azure Container Registry (ACR)
- Azure Kubernetes Service (AKS)
  - AKS アーキテクチャ
  - AKS ネットワーク
  - AKS のストレージ
  - AKS と Azure Active Directory
  - AKS と RBAC
- 各サービスにおけるセキュリティ対策のまとめ
  - [ACIのセキュリティ対策](../../computing/aci-security.md)
  - [ACRのセキュリティ対策](../../computing/acr-security.md)
  - [AKSのセキュリティ対策](../../computing/aks-security.md)


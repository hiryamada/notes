# 境界セキュリティ

■多層防御

- [多層防御](../../network/defense-in-depth.md)
- 参考: [ゼロトラスト戦略](../../SC/zero-trust.md)
- 参考: [LAPS](../../network/laps.md)

■仮想ネットワーク(VNet)の基礎

- [仮想ネットワーク(VNet)](../../network/vnet.md)
- [サブネット](../../network/subnet.md)
- [ネットワークインターフェースカード(NIC)](../../network/nic.md)
- [ルートテーブル / ユーザー定義のルート(UDR)](../../network/udr.md)
- [パブリック/プライベートIPアドレス](../../network/ip-address.md)
- [サービス タグ](../../network/service-tag.md)

■オンプレミス接続

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

■ロードバランサー（負荷分散）サービス

- [Azure Application Gateway](../../network/appgw.md)
- [Azure Front Door](../../network/front-door.md)
- [Web アプリケーション ファイアウォール(Azure WAF)](waf.md)

# ホスト セキュリティ

講義: [ホスト セキュリティ](mod02-03.md)

- エンドポイント保護
- 特権アクセス デバイス戦略
- 特権アクセス ワークステーション(PAW)
- 仮想マシン テンプレート
- リモート アクセス管理
- 仮想マシンの更新
- ディスクの暗号化
- Windows Defender
- Microsoft Defender for Cloud の推奨事項
- Azure セキュリティ ベンチマークによる Azure ワークロードのセキュリティ保護

# コンテナー セキュリティ

講義: [コンテナー セキュリティ](mod02-04.md)

- コンテナー型の仮想化
- Azure Container Instances (ACI)
- Azure Container Registry (ACR)
- Azure Kubernetes Service (AKS)
  - AKS アーキテクチャ
  - AKS ネットワーク
  - AKS のストレージ
  - AKS と Active Directory
  - AKS と RBAC

# 仮想ネットワークゲートウェイ

VNetをオンプレミスにプライベート接続したり、パソコン等からVNetにVPN接続したりする場合に使用するリソース。

■仮想ネットワークゲートウェイの種類

https://docs.microsoft.com/ja-jp/azure/expressroute/expressroute-about-virtual-network-gateways#gateway-types

2種類の仮想ネットワークゲートウェイがある。

仮想ネットワークゲートウェイ作成時に以下のタイプを指定する。

- Vpn
- ExpressRoute

1つのVNetに、これらのゲートウェイを共存させることができる。
https://docs.microsoft.com/ja-jp/azure/vpn-gateway/about-zone-redundant-vnet-gateways#can-i-deploy-both-vpn-and-express-route-gateways-in-same-virtual-network

■ゲートウェイサブネット

VNetに「GatewaySubnet」という名前の、仮想ネットワークゲートウェイ専用のサブネットが必要。

プレフィックスは/27以上（/26, /25）が推奨される。最小は/29（推奨されない）。

**ゲートウェイ サブネットにはネットワーク セキュリティ グループ (NSG) を関連付けない**。関連付けると正常な動作が妨げられる場合がある。

**※AZ-303としては以降、VPNゲートウェイについて説明する。**

# VPNゲートウェイ

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-about-vpngateways

■SKU

※「サイズ」とも。

VPNゲートウェイのSKUにより、使用できる機能や性能が決まる。


接続数はP2S IKEv2/OpenVPN接続。S2SトンネルはBasic: 10まで、その他: 30まで。

- Generation1
  - Basic - 100 Mbps, (非サポート)
  - VpnGw1 - 650 Mbps, 250
  - VpnGw2 - 1 Gbps, 500
  - VpnGw3 - 1.25 Gbps, 1000
  - VpnGw1AZ - 650 Mbps, 250
  - VpnGw2AZ - 1 Gbps, 500
  - VpnGw3AZ - 1.25Gbps, 1000
- Generation2
  - VpnGw2 - 1.25Gbps, 500
  - VpnGW3 - 2.5 Gbps, 1000
  - VpnGW4 - 5 Gbps, 5000
  - VpnGW5 - 10 Gbps, 10000
  - VpnGw2AZ - 1.25Gbps, 500
  - VpnGw3AZ - 2.5 Gbps, 1000
  - VpnGw4AZ - 5 Gbps, 5000
  - VpnGw5AZ - 10 Gbps, 10000

特徴
- Generation1よりもGeneration2のほうが、帯域幅が広く、P2S同時接続数が多い
- Basic,VpnGw1はGeneration1でのみサポート。
- VpnGw2,3はGeneration1,2両方でサポート。
- VpnGw4,5はGeneration2でのみサポート。
- 末尾の数字が大きいほうが、帯域幅が広く、P2S同時接続数が多い
- 「AZ」が付くものはゾーン冗長に対応


■SKUの変更（「サイズの変更」とも）

SKUはVPNゲートウェイ作成後に変更することもできる。

同じ世代（Generation）内で、SKUを変更できる。

ダウンタイムは「あまり」ない。(there is not much downtime) 

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-about-vpn-gateway-settings#resizechange



■VPNゲートウェイにおけるゾーンの利用

VPN接続を、ゾーン レベルの障害から保護することができる。

VPNゲートウェイの2つのVMを可用性ゾーンに配置する方法は2種類ある。

- ゾーン冗長（Zone-redundant）ゲートウェイ
  - 2つのVMを、別の可用性ゾーンに配置。
- ゾーン（Zonal）ゲートウェイ
  - 2つのVMを、同じ可用性ゾーンに配置。

これらはSKUに「AZ」と付くものを選択した場合に利用可能。

※AZが付かないVPNゲートウェイは、可用性ゾーンの選択が不可能。

※ゾーン（Zonal）ゲートウェイの場合、どの可用性ゾーンにVPNゲートウェイを配置するかを選択できる。

■VPNの種類

- ルート ベース(デフォルト)
  - BGPの構成を有効化できる
  - ほとんどの構成で、こちらが使用される
- ポリシー ベース
  - Basicでのみ利用可能

■BGP

有効または無効に設定。ルートベースのVPNゲートウェイでのみ有効に設定できる。

■パブリックIPアドレス

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/tutorial-create-gateway-portal

パブリック IP アドレスは、VPN ゲートウェイの作成時に、このオブジェクトに対して動的に割り当てらる。

パブリック IP アドレスが変わるのは、ゲートウェイが削除され、再度作成されたときのみ。 VPN ゲートウェイのサイズ変更、リセット、その他の内部メンテナンス/アップグレードでは、IP アドレスは変わらない。

SKUにAZが付くものの場合はStandard, そうでない場合はBasicのパブリックIPアドレスが付与される。

■VPNゲートウェイのインスタンス

1つの「VPNゲートウェイ」は、内部的には2つのVMで構成される。

これらのVMに直接接続して構成することはできない。

アクティブなインスタンスのリセットを行うことが可能。
https://docs.microsoft.com/ja-jp/azure/vpn-gateway/tutorial-create-gateway-portal#reset-a-gateway

アクティブ/スタンバイ モード、またはアクティブ/アクティブ モードで運用できる。

アクティブ/スタンバイ モード:

```
VPNゲートウェイの内部VM1: アクティブ: IPアドレス＋トンネル
VPNゲートウェイの内部VM2: スタンバイ
```

アクティブ/アクティブ モード:
```
VPNゲートウェイの内部VM1: アクティブ: IPアドレス＋トンネル
VPNゲートウェイの内部VM2: アクティブ: IPアドレス＋トンネル
```

■アクティブ/スタンバイ モード

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-highlyavailable

- アクティブなインスタンスに対して計画的なメンテナンス（または計画外の中断）が発生すると、スタンバイ インスタンスが自動的に引き継ぎ (フェールオーバーし)、S2S VPN または VNet 間接続が再開される。
- 切り替わる際に、**短い中断が発生**します。
- 計画的なメンテナンスの場合は、**10 ～ 15 秒以内**に接続が復元される。 

■アクティブ/アクティブ モード

- 「より高い可用性」を実現できる。
  - ※ダウンタイム等は仕様として明記されていない
- プロダクション環境向け。
- VPN接続を2重に冗長化できる。

登場時の紹介記事:
https://japan.zdnet.com/article/35090208/6/

登場時のブログ:
https://azure.microsoft.com/en-us/blog/azure-networking-announcements-for-ignite-2016/

動作:
- 1 つのゲートウェイ インスタンスに対して計画的なメンテナンス（または計画外のイベント）が発生すると、そのインスタンスからオンプレミスの VPN デバイスへの IPsec トンネルが切断される。
- VPN デバイスの対応するルートは自動的に削除または無効にされ、トラフィックはもう一方のアクティブな IPsec トンネルに切り替えられる。
- Azure 側では、影響を受けるインスタンスからアクティブ インスタンスに自動的に切り替わる。

※Basicでは利用不可

有効または無効に設定。

有効にした場合は2番目のパブリックIPアドレスを作成して割り当てる。

アクティブ/アクティブ セットアップのコストは、アクティブ/パッシブの場合と同じ。

■コスト

https://azure.microsoft.com/ja-jp/pricing/details/vpn-gateway/

- 仮想ネットワーク ゲートウェイに対する時間単位のコンピューティング コスト
- 仮想ネットワーク ゲートウェイからのエグレス (送信) データ転送のコスト
  - オンプレミスの VPN デバイスにトラフィックを送信する場合は、インターネット エグレス データ転送率を使用して課金
  - 異なるリージョンに属する仮想ネットワーク間でトラフィックを送信する場合は、リージョンごとの価格に基づいて課金
  - 同じリージョンに属する仮想ネットワーク間でトラフィックを送信する場合は、データ コストはかからない
- トンネル数に応じたコスト(無償枠あり)

■Azureで検証済みの対向VPNデバイス

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-about-vpn-devices#validated-vpn-devices-and-device-configuration-guides

■参考: VPNゲートウェイのよくあるお問い合わせ by Azureサポートチーム

https://jpaztech.github.io/blog/network/vpngw-FAQ1/

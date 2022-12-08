# VPN接続

VNetとオンプレミスをプライベート接続。また、VNetとPC等をプライベート接続。

トラフィックは暗号化され、インターネットを流れる。

■Site-to-Site(S2S)接続: VNetとオンプレミスの接続

```
VNet
└GatewaySubnet
 └VPNゲートウェイ
    |VPN接続 (IPsecトンネル)
オンプレミス
```

※オンプレミスとの接続は「クロスプレミス接続」とも呼ばれる

■Point-to-Site(P2S)接続: VNetとPC等の接続

```
VNet
└GatewaySubnet
 └VPNゲートウェイ
    |VPN接続 (OpenVPN/SSTP等)
クライアントPC
```

■VPNゲートウェイのSKU

https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-about-vpngateways#gwsku

※「サイズ」とも。

VPNゲートウェイのSKUにより、使用できるスループットや接続数が決まる。

S2SトンネルはBasic: 10まで、その他: 30まで。

- 世代: Generation1
  - Basic - スループット: 100 Mbps, P2S IKEv2/OpenVPN接続: (非サポート)
  - VpnGw1 - 650 Mbps, P2S IKEv2/OpenVPN接続: 250
  - VpnGw2 - 1 Gbps, 500
  - VpnGw3 - 1.25 Gbps, 1000
  - VpnGw1AZ - 650 Mbps, 250
  - VpnGw2AZ - 1 Gbps, 500
  - VpnGw3AZ - 1.25Gbps, 1000
- 世代: Generation2
  - VpnGw2 - 1.25Gbps, 500
  - VpnGW3 - 2.5 Gbps, 1000
  - VpnGW4 - 5 Gbps, 5000
  - VpnGW5 - 10 Gbps, 10000
  - VpnGw2AZ - 1.25Gbps, 500
  - VpnGw3AZ - 2.5 Gbps, 1000
  - VpnGw4AZ - 5 Gbps, 5000
  - VpnGw5AZ - 10 Gbps, 10000

まとめ:
- Generation1よりもGeneration2のほうが、帯域幅が広く、P2S同時接続数が多い
- Basic,VpnGw1はGeneration1でのみサポート。
- VpnGw2,3はGeneration1,2両方でサポート。
- VpnGw4,5はGeneration2でのみサポート。
- 数字(1,2,3,4,5)が大きいほうが、帯域幅が広く、P2S同時接続数が多い
- 末尾に「AZ」が付くものは[可用性ゾーンに対応](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/about-zone-redundant-vnet-gateways)。（後述）

■Basic SKUの特徴/制約

https://azure.microsoft.com/ja-jp/pricing/details/vpn-gateway/

https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-about-skus-legacy#agg

https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-about-skus-legacy#resize

- 最も安価
- ExpressRoute との共存: 不可
- BGP はサポートされない
- サイズ変更ができない

■SKUの変更（「サイズの変更」とも）

https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-about-vpn-gateway-settings#resizechange

SKUはVPNゲートウェイ作成後に変更することもできる。

同じ世代（Generation）内で、SKUを変更できる。

ダウンタイムは「あまり」ない。(there is not much downtime) ※と、ドキュメントにある。

■VPNゲートウェイにおける可用性ゾーンの利用

https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-highlyavailable

※SKUに「AZ」と付くものを選択した場合に利用可能。

1つの「VPNゲートウェイ」インスタンスは内部的に2つのインスタンス（VM）で構成されている。

インスタンスを可用性ゾーンに配置する方法:

- ゾーン（Zonal）ゲートウェイ
  - 2つのインスタンスを、ユーザーが指定した1つの可用性ゾーンに配置。
- ゾーン冗長（Zone-redundant）ゲートウェイ
  - 2つのインスタンスを、異なる2つの可用性ゾーンに配置。
  - ゾーン障害の際もVPNゲートウェイの機能を利用することができる

■ルート ベース VPN ゲートウェイとポリシー ベース VPN ゲートウェイ

https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-connect-multiple-policybased-rm-ps#about

- ルート ベース（静的ルーティング）
  - BGPの構成を有効化できる
  - ほとんどの構成で、こちらが使用される
- ポリシー ベース（静的ルーティング）
  - SKU: BasicのVPNゲートウェイでのみ利用可能
  - [検証済みVPNデバイス](https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-about-vpn-devices#devicetable)に含まれていない場合が多い

https://qiita.com/hikaru_motomiya/items/377974a55e1042cff239#%E5%88%A9%E7%94%A8%E3%81%A7%E3%81%8D%E3%82%8B%E3%83%9D%E3%83%AA%E3%82%B7%E3%83%BC%E3%81%AE%E9%81%95%E3%81%84

> ルートベースのVPN:  ポリシーベースより柔軟性に優れており、例えば新しいサブネットを作成した場合などの変更による回複性に優れているため、オンプレミスとの接続にはこちらがお勧め


■BGP(Border Gateway Protocol)

https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-bgp-overview

ルートベースのVPNゲートウェイでのみ有効に設定できる。

■パブリックIPアドレス

https://docs.microsoft.com/ja-jp/azure/vpn-gateway/tutorial-create-gateway-portal

パブリック IP アドレスは、VPN ゲートウェイの作成時に、動的に割り当てらる。

パブリック IP アドレスが変わるのは、ゲートウェイが削除され、再度作成されたときのみ。 VPN ゲートウェイのサイズ変更、リセット、その他の内部メンテナンス/アップグレードでは、IP アドレスは変わらない。

SKUにAZが付くものの場合はStandard, そうでない場合はBasicのパブリックIPアドレスが付与される。

■VPNゲートウェイのインスタンス

1つの「VPNゲートウェイ」は、内部的には2つのインスタンス(VM)で構成される。

これらのインスタンスに直接接続して構成することはできない。

アクティブなインスタンスのリセットを行うことが可能。
https://docs.microsoft.com/ja-jp/azure/vpn-gateway/tutorial-create-gateway-portal#reset-a-gateway

アクティブ/スタンバイ モード、またはアクティブ/アクティブ モードで運用できる。

■アクティブ/スタンバイ モード: 1つのVPNトンネルを使用

```
VPNゲートウェイの内部VM1: アクティブ: IPアドレス＋トンネル
VPNゲートウェイの内部VM2: スタンバイ
```

- アクティブなインスタンスに対して計画的なメンテナンス（または計画外の中断）が発生すると、スタンバイ インスタンスが自動的に引き継ぎ (フェールオーバーし)、S2S VPN または VNet 間接続が再開される。
- 計画メンテナンスの場合は、**10 ～ 15 秒以内**に接続が復旧。
- 計画外の中断の場合は、**90秒以内**に復旧。


■アクティブ/アクティブ モード: 2つのVPNトンネルを使用

2016/11/26 Active-Active VPN gatewayの提供開始
https://azure.microsoft.com/en-us/blog/azure-networking-announcements-for-ignite-2016/

登場時の紹介記事:
https://japan.zdnet.com/article/35090208/6/

- より高い可用性を実現できる。
- プロダクション環境向け。
- VPN接続を2重に冗長化できる。

動作:
- 1 つのゲートウェイ インスタンスに対して計画的なメンテナンス（または計画外のイベント）が発生すると、そのインスタンスからオンプレミスの VPN デバイスへの IPsec トンネルが切断される。
- VPN デバイスの対応するルートは自動的に削除または無効にされ、トラフィックはもう一方のアクティブな IPsec トンネルに切り替えられる。
- トンネル切り替え時[切断は発生しない](https://www.cloudou.net/vpn-gateway/design001/)
- Azure 側では、影響を受けるインスタンスからアクティブ インスタンスに自動的に切り替わる。

```
VPNゲートウェイの内部VM1: アクティブ: IPアドレス＋トンネル
VPNゲートウェイの内部VM2: アクティブ: IPアドレス＋トンネル
```

※Basicでは利用不可

有効または無効に設定。

有効にした場合は2番目のパブリックIPアドレスを作成して割り当てる。

アクティブ/アクティブ セットアップのコストは、アクティブ/スタンバイの場合と同じ。[追加のコストはかからない](https://docs.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-vpn-faq#is-there-an-additional-cost-for-setting-up-a-vpn-gateway-as-active-active)。

■コスト

https://azure.microsoft.com/ja-jp/pricing/details/vpn-gateway/

- 仮想ネットワーク ゲートウェイに対する時間単位のコンピューティング コスト
- 仮想ネットワーク ゲートウェイからのエグレス (送信) データ転送のコスト
  - オンプレミスの VPN デバイスにトラフィックを送信する場合は、インターネット エグレス データ転送率を使用して課金
  - 異なるリージョンに属する仮想ネットワーク間でトラフィックを送信する場合は、リージョンごとの価格に基づいて課金
  - 同じリージョンに属する仮想ネットワーク間でトラフィックを送信する場合は、データ コストはかからない
- トンネル数に応じたコスト(無償枠あり)

■Azureで検証済みの対向VPNデバイス

https://learn.microsoft.com/ja-jp/azure/vpn-gateway/vpn-gateway-about-vpn-devices#devicetable

Microsoft では、デバイス ベンダーと協力して一連の標準的な VPN デバイスを検証している。

■参考: VPNゲートウェイのよくあるお問い合わせ by Azureサポートチーム

https://jpaztech.github.io/blog/network/vpngw-FAQ1/

# パブリックIPアドレス

https://docs.microsoft.com/ja-jp/azure/virtual-network/ip-services/public-ip-addresses

■料金

https://azure.microsoft.com/ja-jp/pricing/details/ip-addresses/

例: Standardの場合 $0.005/時間, [月あたり約400円](https://www.google.com/search?q=24*30*0.005%E3%83%89%E3%83%AB+%E5%86%86)

■SKU

- Basic
  - 割り当て方法: 動的または静的(IPv4の場合). 
  - デフォルトで開いている
  - 可用性ゾーンをサポートしない
- Standard
  - 割り当て方法: 静的のみ
  - フロントエンドとして使用されるとき、インバウンド トラフィックに対してデフォルトで閉じている
  - 可用性ゾーンをサポート（非ゾーン、ゾーン、ゾーン冗長）

Basic から Standardへアップグレードが可能。

Azure Load Balancerと組み合わせる場合、SKUを合わせる必要がある。

■関連付け

- 仮想マシン ネットワーク インターフェイス
- 仮想マシン スケール セット
  - [パブリックIPアドレス プレフィックス](https://docs.microsoft.com/ja-jp/azure/virtual-network/ip-services/public-ip-address-prefix)を使用
- パブリック ロード バランサー
- Virtual Network ゲートウェイ (VPN/ExpressRoute)
- NAT ゲートウェイ
- Application Gateway
- Azure Firewall
- bastion ホスト


# Azure Virtual WAN

ネットワーク、セキュリティ、ルーティングのさまざまな機能をまとめて、1 つの運用インターフェイスを提供するネットワーク サービス.

- [公式サイト](https://azure.microsoft.com/ja-jp/services/virtual-wan/#overview)
- [価格](https://azure.microsoft.com/ja-jp/pricing/details/virtual-wan/)
- [ドキュメント](https://docs.microsoft.com/ja-jp/azure/virtual-wan/virtual-wan-about)

■歴史

2018/9/24 一般提供開始
https://azure.microsoft.com/ja-jp/updates/azure-virtual-wan-generally-available/

2019/11/5 Virtual WANの機能強化（ハブ間接続のプレビュー、P2S VPN接続、ExpressRoute接続の一般提供開始）
https://azure.microsoft.com/ja-jp/updates/announcing-enhancements-to-azure-virtual-wan/

2020/7/6 複数の機能と新しいパートナーの一般提供開始（ハブ間接続の一般提供開始、仮想ネットワーク間の50Gbps転送速度の提供など）
https://azure.microsoft.com/ja-jp/updates/azure-virtual-wan-multiple-capabilities-and-new-partners-now-generally-available/

## Virtual WAN登場以前

```
東日本
├VNet1
└VNet2

西日本
├VNet3
└VNet4
```

上記の4つのVNetを、ピアリングを使用してメッシュ状に接続する場合、1-2,1-3,1-4,2-3,2-4,3-4 の 6つのピアリングを作らなければならない。

VNetが多くなればなるほど、必要なピアリングの数は増える。

- 4C2 (4つのVNetから2つを選ぶ[組み合わせの総数](https://mathwords.net/combination)) = 4*3 / 2*1 = 6
- 5C2 = 5*4 / 2*1 = 10
- 6C2 = 6*5 / 2*1 = 15
- 7C2 = 7*6 / 2*1 = 21
- ...

## Virtual WAN登場以降

「仮想WAN」と「仮想ハブ」により、多数のVNetの相互接続がシンプルになる。「ハブ&スポーク型」のトポロジーとなる。

```
仮想WAN
├仮想ハブ - 東日本
│├VNet1
│└VNet2
└仮想ハブ - 西日本
  ├VNet3
  └VNet4
```

※各リージョンごとに1つの仮想ハブを作成

※仮想WAN内の仮想ハブはフルメッシュで接続される. ※Standardの仮想WANの場合. [2019/11の機能強化](https://azure.microsoft.com/ja-jp/updates/announcing-enhancements-to-azure-virtual-wan/)でサポート

## 「ブランチ」の接続

VPN接続やExpressRoute（専用線）接続の先を「ブランチ」という。ブランチ間の通信が可能。

```
仮想WAN
└仮想ハブ
  ├VNet
  ├P2S VPNゲートウェイ - VPN接続 - ブランチ1(ノートPC等)
  ├S2S VPNゲートウェイ - VPN接続 - ブランチ2(オンプレミス拠点)
  └ExpressRouteゲートウェイ - 専用線接続 - ブランチ3(オンプレミス拠点)
```

※P2S = point to site, ポイント対サイト VPN接続

※S2S = site to site, サイト間 VPN接続

※ゲートウェイの利用はオプション

※ブランチ間の接続は On/Off 可能

## ルーティング

仮想ハブでは、ルートテーブル、BGPを使用してルーティングが行われる。[詳細](https://docs.microsoft.com/ja-jp/azure/virtual-wan/about-virtual-hub-routing)

## Virtual WANの作成・設定例

```
仮想WAN vwan1
└仮想ハブ hub1
  └仮想ネットワーク vnet1
```

■「仮想WAN」を作成

作成例

- リソースグループ: ...
- 名前: vwan1
- 種類: Standard

※種類

- Basic
  - 単一ハブ内でのサイト間 VPN 接続、ブランチ間およびブランチ対 VNet 接続をサポート
  - 無料
- Standard
  - 単一ハブ内, ハブ間 Any-to-Any 接続 (サイト間 VPN、VNET、ExpressRoute、ポイント対サイト エンドポイント)をサポート
  - $0.25/時間 のコストが発生

※データ処理量 1GBあたり $0.02 のコストが発生

■「仮想ハブ」を作成

作成例

- リソースグループ: ...
- 名前: hub1
- リージョン: japaneast
- プライベート アドレス空間: 10.0.0.0/16
- 仮想ハブ容量: 2 ルーティングインフラストラクチャユニット
- オプション（あとから追加が可能）
  - サイト対サイト（VPNゲートウェイ）
  - ポイント対サイト（ユーザーVPNゲートウェイ）
  - ExpressRouteゲートウェイ

※1つの「ルーティングインフラストラクチャユニット」あたり $0.10/時間

■VNetを作成

- 名前: vnet1
- アドレス空間: 10.1.0.0/16

■「仮想ハブ」にVNetを接続

vwan1 の 「接続＞仮想ネットワーク接続」で、hub1にvnet1を接続。

■接続状況の確認

vwan1 の「Monitor＞分析情報」で、全体の接続をグラフィカルに確認可能。


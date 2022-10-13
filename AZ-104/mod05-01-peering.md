# VNetピアリング

同じリージョン内の「ピアリング」
```
VNet1 ... 東日本
| ピアリング
VNet2 ... 東日本
```

異なるリージョン間の「グローバルVNetピアリング」
```
VNet1 ... 東日本
| グローバルVNetピアリング
VNet2 ... 西日本
```

[ピアリング接続](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-peering-overview)

2つ以上のVNetを接続。

VNet間の双方向通信が可能。

サブスクリプションやリージョンを越えてピアリングできる。

ピアリングされた仮想ネットワーク内の仮想マシン間のトラフィックには、Microsoft のバックボーンインフラストラクチャが使用される。

※Azureのバックボーンネットワーク: マイクロソフトが所有し運営する、データセンター間の接続回線。Microsoft サービス間のあらゆるトラフィックはこのグローバル トラフィック内でルーティングされ、決してパブリック インターネットを経由しない。

https://learn.microsoft.com/ja-jp/azure/networking/microsoft-global-network

■ グローバルVNetピアリング + Azure Load Balancerの注意点

https://azure.microsoft.com/ja-jp/updates/global-vnet-peering-now-supports-standard-load-balancer/

グローバル VNet ピアリング と、 Standard Load Balancer (内部) の組み合わせはサポートされる。以下の図で VM1は、フロントエンドIPアドレスを使用して、バックエンドVMに接続できる。

```
VNet1 (東日本)
│└VM1
| グローバルピアリング
VNet2 (西日本)
└Standard 内部ロードバランサー + フロントエンドIPアドレス(プライベートIP)
 └バックエンドVM
```

グローバル VNet ピアリング と、 Basic Load Balancer (内部) の組み合わせはサポートされない。以下の図で VM1は、フロントエンドIPアドレスを使用して、バックエンドVMに接続することはできない。

```
VNet1 (東日本)
│└VM1
| グローバルピアリング
VNet2 (西日本)
└Basic 内部ロードバランサー + フロントエンドIPアドレス(プライベートIP)
 └バックエンドVM
```

内部的に Basic ロード バランサーを使用する[一部のサービス](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-faq#what-are-the-constraints-related-to-global-vnet-peering-and-load-balancers)もこの影響を受ける。

```
VNet1 (東日本)
│└VM1
| グローバルピアリング
VNet2 (西日本)
└Azure Cache for Redis（内部的に「Basic 内部ロードバランサー」を使用している)
```

https://learn.microsoft.com/ja-jp/azure/azure-cache-for-redis/cache-how-to-premium-vnet#can-i-connect-to-my-cache-from-a-peered-virtual-network

> ピアリングされた仮想ネットワークからキャッシュに接続できますか?

> 仮想ネットワークが同じリージョンに存在する場合は、... 接続できます。

> ピアリングされた Azure 仮想ネットワークが "異なる" リージョンにある場合、リージョン 1 のクライアント VM は、負荷分散された IP アドレスを使用してリージョン 2 のキャッシュにアクセスできませんが、これは Basic ロード バランサーによる制約のためです。

回避策1:

仮想ネットワーク ピアリングではなく VPN Gateway VNet 間接続を使用する。

```
VNet1 (東日本)
│└VM1
| VPN接続
VNet2 (西日本)
└Azure Cache for Redis
```

回避策2:

Azure Private Link (プライベートエンドポイント)を使用する。

https://learn.microsoft.com/ja-jp/azure/azure-cache-for-redis/cache-private-link

プライベート エンドポイントは、Azure リージョンの枠を越えて Azure PaaS リソースに接続できる。

https://learn.microsoft.com/ja-jp/azure/private-link/private-link-faq#----------------azure-------------azure-paas--------------


```
VNet1 (東日本)
│├プライベートエンドポイント (Azure Cache for Redisに接続)
││  ↑
│└VM1
|
VNet2 (西日本)
└Azure Cache for Redis
```

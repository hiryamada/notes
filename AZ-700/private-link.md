# Azure Private Link

https://docs.microsoft.com/ja-jp/azure/private-link/private-link-service-overview

Azure Standard Load Balancer の背後で実行されている自分のサービスで Private Link アクセスを有効にすると、自分のサービスのコンシューマーがそのサービスに対して独自の VNet からプライベートにアクセスできるようになる。

https://docs.microsoft.com/ja-jp/azure/private-link/private-endpoint-dns

プライベート エンドポイントの IP アドレスを接続文字列の完全修飾ドメイン名 (FQDN) に解決するように、DNS 設定を正しく構成することが重要です。

方法

- ホスト ファイルを使用する (テストにのみ推奨) 。
- プライベート DNS ゾーンを使用する。
- DNS フォワーダーを使用する (オプション) 
  - 仮想ネットワークでホストされている DNS サーバーでプライベート DNS ゾーンを使用する DNS 転送規則を作成


# プライベートエンドポイント

https://docs.microsoft.com/ja-jp/azure/private-link/disable-private-endpoint-network-policy

以前は、プライベートエンドポイントに対し、「ネットワークポリシー」（NSG, UDR）はサポートされていなかった。

サブネットの下記の設定を使用して「ネットワークポリシー」のサポートを有効または無効に設定できるようになった。

PrivateEndpointNetworkPolicies: 無効/有効(Enabled)

ポータルを使用してプライベート エンドポイントを作成する場合、この設定は無効となる。

https://azure.microsoft.com/ja-jp/updates/public-preview-of-private-link-network-security-group-support/

- 2021/9/2
- Private Link (Private Endpoint) で NSG がサポートされる。
- PrivateEndpointNetworkPolicies を Enabledにする
- Microsoft.Network/AllowPrivateEndpointNSG を az feature / Register-AzProviderFeature で登録する

https://azure.microsoft.com/ja-jp/updates/public-preview-of-private-link-udr-support/

- 2021/9/2
- Private Link (Private Endpoint) で UDR がサポートされるようになった
- PrivateEndpointNetworkPolicies を Enabled にする
- Microsoft.Network/AllowPrivateEndpointNSG を az feature / Register-AzProviderFeature で登録する

※ [az feature : プレビュー機能の有効化](https://docs.microsoft.com/ja-jp/cli/azure/feature?view=azure-cli-latest)

参考

- https://www.simpletraveler.jp/2021/10/13/microsoftazure-privateendpoint-accesscontrol-by-nsg/

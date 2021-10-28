# ネットワーク アドレッシングと名前解決のソリューション

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-name-resolution-for-vms-and-role-instances?toc=/azure/dns/toc.json

※ここでは、仮想ネットワーク内における名前解決について説明する。グローバル（インターネット）の名前解決については[Azure DNS （パブリックDNS）](https://docs.microsoft.com/ja-jp/azure/dns/dns-overview)、[Azure Traffic Manager](https://docs.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-overview)などを利用できる。

- (1)Azureで提供される名前解決
- (2)Azure DNS プライベートDNSゾーン
- (3)独自のDNSサーバーを使用する名前解決

■(1)Azureで提供される名前解決

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-name-resolution-for-vms-and-role-instances#azure-provided-name-resolution

- 特に構成する必要がない。
- 基本的な権限を持つ DNS 機能のみが提供される。
- DNS ゾーン名とレコードが Azure によって自動的に管理され、DNS ゾーン名や DNS レコードのライフサイクルを制御することはできない。
- Azure DNS IP アドレス: 168.63.129.16
- 逆引きもサポート

■(2)Azure DNS プライベートDNSゾーン

https://docs.microsoft.com/ja-jp/azure/dns/private-dns-privatednszone

プライベートDNSゾーン:
- Azureのリソースとして作成する
- ラベルを指定する。例: contoso.org
  - 2個以上、34個以下のラベルがサポートされる。例「contoso.com」: 2ラベル
  - 単一ラベルはサポートされない。例「local」

リンク: 

- 「プライベートDNSゾーン」を仮想ネットワークに「リンク」することができる。
- リンクした仮想ネットワークで、「プライベートDNSゾーン」を使用して名前解決を行うことができる。
- リンクはリージョンをまたいで設定できる。

自動登録: 

- プライベートDNSゾーンのリンクの「自動登録」を有効にすると、仮想ネットワークに起動した仮想マシンの名前とプライベートIPアドレスが、プライベートDNSゾーンに登録されるようにすることができる。

1つのプライベートDNSゾーンは複数の仮想ネットワークからリンクできる。

```
vnet1
|リンク1(自動登録:有効)
プライベートDNSゾーン aaa.com
|リンク2(自動登録:有効)
vnet2
```

1つの仮想ネットワークは複数のプライベートDNSゾーンにリンクできる。ただし2つのリンクで自動登録を有効にすることはできない。

```
プライベートDNSゾーン1 aaa.com
|リンク1(自動登録:有効)
vnet
|リンク2(自動登録:無効) ← 有効にすることはできない
プライベートDNSゾーン2 bbb.com
```

■(3)独自のDNSサーバーを使用する名前解決

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-name-resolution-for-vms-and-role-instances#name-resolution-that-uses-your-own-dns-server

独自のDNSサーバー（Windows ServerのActive Directoryドメインなど）を使用することもできる。


■仮想ネットワークの設定

Azure portal＞仮想ネットワーク＞DNSサーバー

- 規定（Azure提供）
- カスタム

デフォルトは「規定（Azure提供）」となっている。この状態で、(1)「Azureで提供される名前解決」 と、(2)「Azure DNS プライベートDNSゾーン」 が利用できる。

「カスタム」を選択すると、DNSサーバーのIPアドレスを追加することができる（このIPアドレスはVNetのプライベートIPアドレスである必要はない。）。この状態で、(3)「独自のDNSサーバーを使用する名前解決」が使用できる。

■まとめ

(1)「Azureで提供される名前解決」 : デフォルト。

(2)「Azure DNS プライベートDNSゾーン」: 「プライベートDNSゾーン」を作り、仮想ネットワークに「リンク」することで、リンクした仮想ネットワークからそのゾーンを利用して名前解決ができるようになる。

(3)「独自のDNSサーバーを使用する名前解決」: Azure portal＞仮想ネットワーク＞DNSサーバー で「カスタム」を選択し、名前解決に使用したいDNSサーバーのIPアドレスを入力する。



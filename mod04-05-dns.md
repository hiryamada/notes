# [Azure DNS](https://azure.microsoft.com/ja-jp/services/dns/)

ドメイン ネーム システム (DNS) を Azure でホストすることができるサービスです。

DNS クエリは、Microsoftのネームサーバーのグローバルネットワークで、最も近くのネーム サーバーで応答されます。

新しい DNS レコードの追加時に Azure DNS ネーム サーバーは数秒で更新されます。


[Azure DNS を使用してドメイン名を購入することはできません](https://docs.microsoft.com/ja-jp/azure/dns/dns-overview) 。Azure App Serviceでは、[ドメインを購入](https://docs.microsoft.com/ja-jp/azure/app-service/manage-custom-dns-buy-domain#buy-the-domain)することができます。購入したドメインは、Azure DNSで管理されます。または、「お名前.com」などのドメイン レジストラーでドメインを取得します。

# パブリックDNSゾーン

Azure のリソースとして、[DNSゾーン](https://docs.microsoft.com/ja-jp/azure/dns/dns-getstarted-portal)を作成します。

# ゾーンのネームサーバー

ゾーンを作成すると、ゾーン内にネームサーバーが割り当てられます。

- ns1-03.azure-dns.com.
- ns1-03.azure-dns.net.
- ns1-03.azure-dns.org.
- ns1-03.azure-dns.info.

# DNS委任（ネームサーバーの変更）

「お名前.com」などのドメイン レジストラーでドメインを取得した場合、ドメイン レジストラーのネームサーバー設定画面にて、Azure DNSゾーンに割り当てられた4つのネームサーバーを設定します。以下に例を示します。

- [お名前.com](https://www.onamae.com/guide/p/67)
- [さくらのドメイン（さくらインターネット）](https://help.sakura.ad.jp/206205831/)
- [ニフクラ](https://hosting.nifcloud.com/manual_detail/889/)
- [バリュードメイン](https://www.value-domain.com/userguide/manual/modns/)

# DNSレコードセット

ゾーンに、[レコードセット](https://docs.microsoft.com/ja-jp/azure/dns/dns-zones-records#record-sets)を追加することができます。

レコードセットは、同じ名前を持つゾーン内のDNSレコードのコレクションです。レコードセットには、1つ以上のレコードが含まれます。

例えば、www.contoso.com が、1.2.3.4 と 5.6.7.8 の2つのIPアドレスでホストされている場合、以下のような2つのレコードで構成される、1つのレコードセットを作ります。

- www.contoso.com. 3600 IN A 1.2.3.4
- www.contoso.com. 3600 IN A 5.6.7.8

# [プライベートDNSゾーン](https://docs.microsoft.com/ja-jp/azure/dns/dns-overview#customizable-virtual-networks-with-private-domains)

仮想ネットワーク（VNet）で、独自のカスタム ドメイン名を使用することができる機能です。独自のDNSサーバーをホストする必要がなくなります。

プライベートDNSゾーンに「仮想ネットワーク リンク」を作成し、リンク先のVNetを指定します。このとき、「自動登録を有効にする」チェックで、この機能を有効化するかどうかを選択できます。

たとえば、example.com というプライベートDNSゾーンを作り、自動登録を有効にしたリンクを作成し、リンクしたVNet内に ubuntu1（IPアドレス: 10.0.0.4）というVMを起動すると、以下のように名前解決ができます。

```
azureuser@ubuntu1:~$ nslookup ubuntu1.example.com
Server:         127.0.0.53
Address:        127.0.0.53#53

Non-authoritative answer:
Name:   ubuntu1.example.com
Address: 10.0.0.4
```

また、逆引きを行うことができます。逆引きでは、[規定のFQDN](https://docs.microsoft.com/ja-jp/azure/dns/dns-faq-private#will-dns-resolution-by-using-the-default-fqdn-internalcloudappnet-still-work-even-when-a-private-zone-for-example-privatecontosocom-is-linked-to-a-virtual-network)である internal.cloudapp.net が、 example.com と[共に返されます](https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-networks-name-resolution-for-vms-and-role-instances#reverse-dns-considerations)。

```
azureuser@ubuntu1:~$ nslookup 10.0.0.4
4.0.0.10.in-addr.arpa   name = ubuntu1.internal.cloudapp.net.
4.0.0.10.in-addr.arpa   name = ubuntu1.example.com.

Authoritative answers can be found from:
```

dig コマンドによる名前解決の例（抜粋）。

```
azureuser@ubuntu1:~$ dig ubuntu1

;; ANSWER SECTION:
ubuntu1.                0       IN      A       10.0.0.4
```

dig コマンドによる逆引きの例（抜粋）。

```
azureuser@ubuntu1:~$ dig -x 10.0.0.4

;; ANSWER SECTION:
4.0.0.10.in-addr.arpa.  10      IN      PTR     ubuntu1.internal.cloudapp.net.
4.0.0.10.in-addr.arpa.  10      IN      PTR     ubuntu1.example.com.

```

また、プライベートDNSゾーンには、以下のような、編集することができないレコードセットが自動登録されます。

- ubuntu1.example.com. 10 IN A 10.0.0.4

# [自動登録の制限](https://docs.microsoft.com/ja-jp/azure/dns/private-dns-autoregistration#restrictions)

- 自動登録は、仮想マシンに対してのみ機能します。その他のリソースは、手動で設定します。
- 仮想マシンのプライマリNICのみ自動登録されます。
- 仮想マシンのプライマリNICでDHCPが有効化されている必要があります。
- IPv6の自動登録はサポートされていません。

# [仮想ネットワークリンク](https://docs.microsoft.com/ja-jp/azure/dns/private-dns-virtual-network-links)

- 登録仮想ネットワーク: 自動登録を有効にしたリンクで接続されたVNetです。VNet内のVMは自動的にプライベートDNSゾーンに登録されます。
- 解決仮想ネットワーク: 自動登録を有効にしないリンクで接続されたVNetです。VNet内のVMは、手動で、プライベートDNSゾーンに登録できます。

1つの仮想ネットワークに、自動登録を有効にしたリンクを作成した場合、さらに別の自動登録を有効にしたリンクを作成することはできません。つまり、1つのVMのレコードを2つのゾーンに自動登録させることはできません。

# プライベートDNSゾーンとVNetのリンクの注意事項

[Azure DNSの制限](https://docs.microsoft.com/en-us/azure/azure-resource-manager/management/azure-subscription-service-limits#azure-dns-limits)


- 1つのプライベートDNSゾーンに、最大1000個の仮想ネットワークをリンクすることができます。
- 1つのプライベートDNSゾーンに、最大100個の、自動登録を有効にした仮想ネットワークをリンクすることができます。
- 1つの仮想ネットワークに、最大1000個のプライベートDNSゾーンをリンクすることができます。

[よく寄せられる質問](https://docs.microsoft.com/ja-jp/azure/dns/dns-faq-private#will-azure-private-dns-zones-work-across-azure-regions)

- リージョンを超えて動作することができます。
- 仮想ネットワーク間のピアリングは必須ではありません。

# 逆引きの注意事項

逆引き DNS は、リンクされた仮想ネットワーク内のプライベート IP 空間に対してのみ[機能します](https://docs.microsoft.com/ja-jp/azure/dns/private-dns-overview#other-considerations)。

たとえば、VNet-Aと、VNet-Bが、1つのプライベートDNSゾーンにリンクされているとき、VNet-AのVMの逆引きはVNet-Aからのみ、VNet-BのVMの逆引きはVNet-Bからのみ動作します。それ以外は、[NXDOMAIN](https://jprs.jp/glossary/index.php?ID=0187)が返されます。

参考: [逆引きの必要性](https://www.atmarkit.co.jp/fnetwork/dnstips/006.html)の説明。


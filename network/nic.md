■ネットワークインターフェースカード（NIC）

https://learn.microsoft.com/ja-jp/azure/virtual-network/virtual-network-network-interface?tabs=network-interface-portal

※NICのイメージ（Google画像検索）https://www.google.com/search?q=%E3%83%8D%E3%83%83%E3%83%88%E3%83%AF%E3%83%BC%E3%82%AF%E3%82%A4%E3%83%B3%E3%82%BF%E3%83%BC%E3%83%95%E3%82%A7%E3%83%BC%E3%82%B9%E3%82%AB%E3%83%BC%E3%83%89&tbm=isch

仮想マシン（VM）は、NICを使用して、VNetに接続する。

```
VNet 10.0.0.0/16
└サブネット 10.0.0.0/24
 └NIC
   └VM プライベートIPアドレス 10.0.0.4
```

NICは「IP構成」（IP config）という設定を持つ。

```
VM
└NIC
 └IP構成
  ├パブリックIPアドレス（オプション）
  └プライベートIPアドレス
```

■参考: 2枚挿し(複数の NIC)

https://learn.microsoft.com/ja-jp/azure/virtual-machines/windows/multiple-nics

1つのVMで複数のNICを利用できる。

※Azure portalで普通にVMを作成した場合は1つのVMに1つのNICが作成される。

https://learn.microsoft.com/ja-jp/azure/virtual-network/virtual-machine-network-throughput

VMサイズにより、使用できるNIC枚数が決まる。

**AzureのVMは、NICを複数挿しても、トータルの帯域幅は変わらない。** したがって、ネットワークの性能を改善するといった目的では、2枚挿し構成は意味がないことに注意。

■帯域幅

https://learn.microsoft.com/ja-jp/azure/virtual-network/virtual-machine-network-throughput

VMサイズにより、仮想マシンとしてのネットワークスループット（帯域、Mbps）が決まる。大きな仮想マシンには、小さい仮想マシンよりも相対的に多くの帯域幅が割り当てられる。

帯域幅は仮想マシンごとに割り当てられており、仮想マシンに接続されているネットワーク インターフェイスの数は関係ない。

帯域幅の制限は送信のみ。受信は制限なし。

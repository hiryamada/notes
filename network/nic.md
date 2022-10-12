■ネットワークインターフェースカード（NIC）

https://learn.microsoft.com/ja-jp/azure/virtual-network/virtual-network-network-interface?tabs=network-interface-portal

仮想マシン（VM）は、NICを使用して、VNetに接続する。

```
VNet 10.0.0.0/16
└サブネット 10.0.0.0/24
 └NIC
   └VM 10.0.0.4
```

NICは「IP構成」（IP config）という設定を持つ。

```
VM
└NIC
 └IP構成
  ├パブリックIPアドレス（オプション）
  └プライベートIPアドレス
```

■2枚挿し(複数の NIC)

https://learn.microsoft.com/ja-jp/azure/virtual-machines/windows/multiple-nics

1つのVMで複数のNICを利用できる。

フロントエンドとバックエンドの接続に異なるサブネットを使用したい場合などに使用する。

```
VNet
├フロントエンドサブネット
│       └フロントエンドNIC - VM
└バックエンドサブネット       |
        └バックエンドNIC -----+
```


※Azure portalで普通にVMを作成した場合は1つのVMに1つのNICが作成される。


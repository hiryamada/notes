■ネットワークインターフェースカード（NIC）

https://learn.microsoft.com/ja-jp/azure/virtual-network/virtual-network-network-interface?tabs=network-interface-portal

仮想マシン（VM）は、NICを使用して、VNetに接続する。
```
VM
└NIC
 └IP構成
  ├パブリックIPアドレス（オプション）
  └プライベートIPアドレス
```

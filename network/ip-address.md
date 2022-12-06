# IPアドレス

■パブリックIPアドレス

https://learn.microsoft.com/ja-jp/azure/virtual-network/ip-services/public-ip-addresses

VM等にパブリックIPアドレスを割り当てることで、インターネットから、そのVMへ、直接接続することが可能となる。

- パブリックIPアドレス
  - Basic SKU
    - （Standard SKU導入以前から使われていたもの）
    - デフォルトで受信に対して開いている
    - 割り当て: 静的 または 動的
    - 可用性ゾーンをサポートしない
  - Standard SKU
    - デフォルトで受信に対して閉じている
    - ネットワークセキュリティグループで明示的に受信を許可
    - 割り当て: 静的のみ
    - 可用性ゾーンをサポート

※どちらがよいか？ → Standard （将来的にデフォルトになる）

コマンドを使用してVMを作成すると・・・

```
New-AzVm -ResourceGroupName "AZ500LAB131415" -Name "myVM" -Location 'EastUS' -VirtualNetworkName "myVnet" -SubnetName "mySubnet" -SecurityGroupName   "myNetworkSecurityGroup" -PublicIpAddressName "myPublicIpAddress" -OpenPorts 80,3389

It is recommended to use parameter "-PublicIpSku Standard" in order to create a new VM with a Standard public IP. Specifying zone(s) using the "-Zone" parameter will also result in a Standard public IP.If "-Zone" and "-PublicIpSku" are not specified, the VM will be created with a Basic public IP instead. Please note that the Standard SKU IPs will become the default behavior for VM creation in the future
```

標準のパブリック IP を持つ新しい VM を作成するには、パラメーター「-PublicIpSku Standard」を使用することをお勧めします。 "-Zone" パラメーターを使用してゾーンを指定すると、Standard パブリック IP も生成されます。 Standard SKU IP は、将来的に VM 作成のデフォルトの動作になることに注意してください。

■プライベートIPアドレス

https://learn.microsoft.com/ja-jp/azure/virtual-network/ip-services/private-ip-addresses

Azure 内のリソース間の通信などでは、プライベートIPアドレスが使用される。

```
VNet 10.0.0.0/16
└subnet1 10.0.0.0/24
  ├NIC (10.0.0.4, 動的)
  │ └VM1
  ├NIC (10.0.0.5, 動的)
  │ └VM2
  └NIC (10.0.0.100, 静的)
    └VM3
```

動的割り当て: サブネットのプライベートIPアドレスの範囲から、未使用のアドレスが採番される。

静的割り当て: サブネットのプライベートIPアドレスの範囲から、ユーザーが指定したアドレスを固定で割り当てる。


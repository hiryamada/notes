# ラボ (ハンズオン)

手順書: [M02-ユニット 3 仮想ネットワーク ゲートウェイを作成および構成する](https://github.com/MicrosoftLearning/AZ-700-Designing-and-Implementing-Microsoft-Azure-Networking-Solutions.ja-jp/blob/main/Instructions/Exercises/M02-Unit%203%20Create%20and%20configure%20a%20virtual%20network%20gateway.md)

概要: 2つのVNetをVPNで接続します。

```
CoreServicesVnet
└仮想ネットワークゲートウェイ
                            |
ManufacturingVnet           |VPN
└仮想ネットワークゲートウェイ
```

時間: 70 分 (最大 45 分のデプロイ待機時間を含む)

はじめにお読みください: [全般的なラボの注意](lab.md)

このラボの注意:
- リソースのデプロイに時間がかかります。
- タスク6: 仮想ネットワークゲートウェイの作成には45分ほどかかります。リソースの作成が始まったら、それが完了するのを待たず、タスク7に進んでください。
- タスク7: もう一つの仮想ネットワークゲートウェイを作成します。45分ほどかかります。
- タスク8: タスク6, 7のリソース作成が終わってから、タスク8を開始できます。
- 次のラボでクリーンナップ（リソース削除）を行います。


タスク6/7のスクリプト（Cloud Shellで実行）

```pwsh
$gwpip = New-AzPublicIpAddress -Name CoreServicesVnetGateway-ip -ResourceGroupName ContosoResourceGroup -Location 'East US' -AllocationMethod Dynamic
$vnet = Get-AzVirtualNetwork -Name CoreServicesVnet -ResourceGroupName ContosoResourceGroup
$subnet = Get-AzVirtualNetworkSubnetConfig -Name 'GatewaySubnet' -VirtualNetwork $vnet
$gwipconfig = New-AzVirtualNetworkGatewayIpConfig -Name gwipconfig1 -SubnetId $subnet.Id -PublicIpAddressId $gwpip.Id
New-AzVirtualNetworkGateway -Name CoreServicesVnetGateway -ResourceGroupName ContosoResourceGroup -Location 'East US' -IpConfigurations $gwipconfig -GatewayType Vpn -VpnType RouteBased -GatewaySku VpnGw1 -AsJob


$gwpip = New-AzPublicIpAddress -Name ManufacturingVnetGateway-ip -ResourceGroupName ContosoResourceGroup -Location 'West Europe' -AllocationMethod Dynamic
$vnet = Get-AzVirtualNetwork -Name ManufacturingVnet -ResourceGroupName ContosoResourceGroup
$subnet = Get-AzVirtualNetworkSubnetConfig -Name 'GatewaySubnet' -VirtualNetwork $vnet
$gwipconfig = New-AzVirtualNetworkGatewayIpConfig -Name gwipconfig2 -SubnetId $subnet.Id -PublicIpAddressId $gwpip.Id
New-AzVirtualNetworkGateway -Name ManufacturingVnetGateway -ResourceGroupName ContosoResourceGroup -Location 'West Europe' -IpConfigurations $gwipconfig -GatewayType Vpn -VpnType RouteBased -GatewaySku VpnGw1 -AsJob
```

`Get-Job` で状況を確認できます。

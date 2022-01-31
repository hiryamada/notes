https://docs.microsoft.com/ja-jp/azure/virtual-network/network-security-groups-overview

■既定セキュリティ規則

- AllowVNetInBound
  - ソース: VirtualNetwork, ポート 0-65535
  - 宛先: VirtualNetwork, ポート 0-65535
  - Protocol: Any
  - Access: Allow
  - ※このルールにより、VNet内・VNet間のあらゆる受信（RDPやSSHも含む）はデフォルトで許可となる。
- AllowAzureLoadBalancerInBound
  - ソース: AzureLoadBalancer, ポート 0-65535
  - 宛先: 0.0.0.0/0, ポート 0-65535
  - Protocol: Any
  - Access: Allow
  - ※宛先がVirtualNetworkではなく0.0.0.0となっており、VNet（内のNIC）に限らず、任意のIPアドレスへの受信が許可される。
  - ※Azure Load Balancerの[バックエンドプールはNICまたはIPアドレス](https://docs.microsoft.com/ja-jp/azure/load-balancer/components#backend-pool)
- DenyAllInbound

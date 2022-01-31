# Azure Key Vault

■サービスエンドポイント

https://docs.microsoft.com/ja-jp/azure/key-vault/general/overview-vnet-service-endpoints

■Azure Private Link (プライベート エンドポイント)

https://docs.microsoft.com/ja-jp/azure/key-vault/general/private-link-service

キー コンテナーは、別のリージョンに配置されていてもよい。

■VNet内にデプロイできるか？

できない。

https://docs.microsoft.com/ja-jp/azure/virtual-network/virtual-network-for-azure-services#services-that-can-be-deployed-into-a-virtual-network

[専用HSM (Azure Dedicated HSM)](https://docs.microsoft.com/ja-jp/azure/dedicated-hsm/)は可能。

> プロビジョニングした HSM デバイスは、お客様の仮想ネットワークに直接接続されます。 また、ポイント対サイトまたはサイト間の VPN 接続を構成することで、オンプレミスのアプリケーションや管理ツールからもアクセスできます。


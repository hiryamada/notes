
# Azure Dedicated HSM

[製品ページ](https://azure.microsoft.com/ja-jp/services/azure-dedicated-hsm/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/dedicated-hsm/overview)

シングルテナント、FIPS 140-2 level 3対応。[SafeNet (Thales タレス) Luna ネットワーク HSM 7 モデル A790](https://cpl.thalesgroup.com/encryption/hardware-security-modules/network-hsms)を使用。

Azure Dedicated HSM では、完全な管理制御と完全な管理責任が備わった、お客様専用の物理デバイスが提供されます。 物理デバイスを使用するので、確実に容量が効果的に管理されるよう、Microsoft がデバイスの割り当てを制御する必要があります。 そのため、Dedicated HSM サービスは通常、Azure サブスクリプション内でリソース プロビジョニング用には表示されません。 Dedicated HSM サービスへのアクセスを必要とする Azure のお客様は、まず、Microsoft アカウント担当者に連絡して、Dedicated HSM サービスへの登録を依頼しなければなりません。 このプロセスが正常に完了した場合にのみ、プロビジョニングが可能になります。

Azure Dedicated HSM は現在、Azure portal では使用できません。 サービスに対するすべての操作は、コマンドラインまたは PowerShell を使用して行います。


[HSMとは](https://docs.microsoft.com/ja-jp/azure/dedicated-hsm/faq#q-what-is-a-hardware-security-module-hsm)
- ハードウェア セキュリティ モジュール (HSM) は、暗号化キーの保護と管理に使用される物理コンピューティング デバイスです。
- キー マテリアルが HSM による保護の境界の外に出ることは決してありません。

# Azure Key Vault

アプリやサービスで使用される暗号化キーなどのシークレットを保護および管理することができます。

## サービスの種類
「Azure Key Vault」のほかに、「Azure Dedicated HSM」というサービスもあります。

「Azure Dedicated HSM」は試験の範囲外です。

## Azure Key Vaultで管理できるもの
- [キー](https://docs.microsoft.com/ja-jp/azure/key-vault/keys/about-keys)：暗号化に使用するキー
- [シークレット](https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/about-secrets)：パスワード、トークンなど
- [証明書](https://docs.microsoft.com/ja-jp/azure/key-vault/certificates/about-certificates)：パブリックおよびプライベートのTLS証明書

※これらはまとめて「シークレット」と呼ばれる場合がありますが、実際の操作では区別して扱います。

## Azure Key Vaultのリソース
「ボールト」（コンテナー）と「Managed HSM Pools」の2種類のリソースを作成できます。

※「ボールト」(vault)の日本語訳として「コンテナー」「キー コンテナー」「資格情報コンテナー」などの用語も使用されます。

「ボールト」を作成する際に、Standard または Premium のSKUを選択します。

「Managed HSM Pools」のSKUは現在「Standard B1」のみであり、リソース作成時のSKUの指定は不要です。
## Azure Key Vaultのキー
「ボールト」では「ソフトウェアで保護されたキー」を作成できます。また、Premium SKUを選択した場合は、「HSMで保護されたキー」を作成できます。

「Managed HSM Pools」では「HSMで保護されたキー」のみを作成できます。

## FIPS 140-2への対応

FIPS 140-2 は、暗号化ハードウェアに対する規格です。

[FIPS 140-2の各Level](https://cpl.thalesgroup.com/ja/faq/key-secrets-management/what-fips-140-2)
に対応する場合は、下記のように選択します。

- FIPS 140-2 Level 1: [ソフトウェアで保護されるキー](https://docs.microsoft.com/ja-jp/azure/key-vault/keys/about-keys#software-protected-keys)
- FIPS 140-2 Level 2:「ボールト」の「HSMで保護されたキー」
- FIPS-140-2 Level 3:「Managed HSM」または「Azure Dedicated HSM」

# 操作手順例

- Key Vaultを作成
- アクセスポリシーを「Azure ロールベースのアクセス制御」に設定
- アクセス制御（IAM）で、自分自身に、ロール「Key Vault Secret Officer」を追加
- シークレットを生成
- 作成したシークレットを確認

※ここで作成したシークレットをVMから読み込む手順については、[マネージドID](mod07-02-managed-id.md)を参照。

# Key Vaultのアクセス許可モデル

- Key Vault アクセス ポリシー
- Azure RBAC

これらのモデルは排他的であり、いったん「Azure RBAC」に設定すると、「Key Vault アクセス ポリシー」は非アクティブになります。

[データ プレーンとアクセス ポリシー](https://docs.microsoft.com/ja-jp/azure/key-vault/general/secure-your-key-vault#data-plane-and-access-policies)

[データ プレーンと Azure RBAC (プレビュー)](https://docs.microsoft.com/ja-jp/azure/key-vault/general/secure-your-key-vault#data-plane-and-azure-rbac-preview) - 2020/10/19の[アナウンス](https://azure.microsoft.com/en-us/updates/azure-rolebased-access-control-rbac-for-azure-key-vault-data-plane-authorization-is-now-in-preview/)


# 参考情報

[製品ページ](https://azure.microsoft.com/ja-jp/services/key-vault/)

Microsoft Learn

- [Azure Key Vault を使用してサーバー アプリのシークレットを管理する](https://docs.microsoft.com/ja-jp/learn/modules/manage-secrets-with-azure-key-vault/)
- [Azure Key Vault でのシークレットの構成と管理](https://docs.microsoft.com/ja-jp/learn/modules/configure-and-manage-azure-key-vault/)
- [Azure キー コンテナーを使用して ASP.NET アプリの構成を外部化する](https://docs.microsoft.com/ja-jp/learn/modules/aspnet-configurationbuilder/)


[Managed HSM](https://docs.microsoft.com/ja-jp/azure/key-vault/managed-hsm/): [public preview](https://azure.microsoft.com/en-us/updates/akv-managed-hsm-public-preview/#:~:text=Managed%20HSM%20is%20a%20new,pools%20should%20be%20very%20simple.). Managed HSM pool とも。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/key-vault/general/overview)

[解説スライド](https://www.slideshare.net/junichia/azure-key-vault-77692730)

クイックスタート
- [Vault](https://docs.microsoft.com/ja-jp/azure/key-vault/general/manage-with-cli2)
  - az provider register -n Microsoft.KeyVault
  - az keyvault create --name
  - az keyvault key create --vault-name --name
  - az keyvault secret set --vault-name --name --value 
- Vaultの[HSMを使用する手順](https://docs.microsoft.com/ja-jp/azure/key-vault/general/manage-with-cli2#working-with-hardware-security-modules-hsms)
  - az keyvault create --sku "Premium"
  - az keyvault key create --vault-name --name --protection "hsm" 
- [Managed HSM](https://docs.microsoft.com/ja-jp/azure/key-vault/managed-hsm/quick-create-cli)
  - az keyvault create --hsm-name
  - az keyvault key create --hsm-name --name

# HSM-Protected HSM

Premium SKUで使用可能。

[nCipher HSM](https://cn.teldevice.co.jp/product/nshield_connect/) を使用。

FIPS 140-2 Level 2 適合認定取得ずみ

# Managed HSM

[Marvell LiquidSecurity の HSM アダプターが使用される。](https://docs.microsoft.com/ja-jp/azure/key-vault/managed-hsm/overview#access-control-enhanced-data-protection--compliance)

[クラウドデータセンター向けに設計](https://jp.marvell.com/products/security-solutions.html)されたHSMアダプター。

# Azure Dedicated HSM

[製品ページ](https://azure.microsoft.com/ja-jp/services/azure-dedicated-hsm/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/dedicated-hsm/overview)

シングルテナント、FIPS 140-2 level 3対応。[SafeNet (Thales タレス) Luna ネットワーク HSM 7 モデル A790](https://cpl.thalesgroup.com/encryption/hardware-security-modules/network-hsms)を使用。

Azure Dedicated HSM では、完全な管理制御と完全な管理責任が備わった、お客様専用の物理デバイスが提供されます。 物理デバイスを使用するので、確実に容量が効果的に管理されるよう、Microsoft がデバイスの割り当てを制御する必要があります。 そのため、Dedicated HSM サービスは通常、Azure サブスクリプション内でリソース プロビジョニング用には表示されません。 Dedicated HSM サービスへのアクセスを必要とする Azure のお客様は、まず、Microsoft アカウント担当者に連絡して、Dedicated HSM サービスへの登録を依頼しなければなりません。 このプロセスが正常に完了した場合にのみ、プロビジョニングが可能になります。

Azure Dedicated HSM は現在、Azure portal では使用できません。 サービスに対するすべての操作は、コマンドラインまたは PowerShell を使用して行います。


[HSMとは](https://docs.microsoft.com/ja-jp/azure/dedicated-hsm/faq#q-what-is-a-hardware-security-module-hsm)
- ハードウェア セキュリティ モジュール (HSM) は、暗号化キーの保護と管理に使用される物理コンピューティング デバイスです。
- キー マテリアルが HSM による保護の境界の外に出ることは決してありません。

---

# 用語の注意

[英語のドキュメント](https://docs.microsoft.com/en-us/azure/key-vault/general/overview)では、「Key Vault」または「Vault」という用語を使用しています。（Key Vault service supports two types of containers: vaults and managed HSM pools.）

これに対し、[日本語のドキュメント](https://docs.microsoft.com/ja-jp/azure/key-vault/general/overview)では、翻訳として「ボールト」、「キー コンテナー」「コンテナー」「資格情報コンテナー」という用語を使用してます。ただし製品（サービス）名としては、「Azure Key Vault」を使用しています。



# アクセスおよび利用状況の監視
キー コンテナーをいくつか作成したら、キーとシークレットにアクセスする方法とタイミングを監視することをお勧めします。 アクティビティを監視するには、コンテナーのログ記録を有効にします。

- ストレージ アカウントへのアーカイブ。
- イベント ハブへのストリーム配信。
- Azure Monitor ログにログを送信します。

ユーザーは、ログを管理できます。ユーザーは、アクセスを制限することによってログを保護することができ、不要になったログを削除することもできます。

# キーのレプリケート

リージョン内およびセカンダリ リージョンに Key Vault の内容をレプリケートすることができます。

レプリケーションによって高可用性が確保され、フェールオーバーをトリガーするための管理者の操作が不要になります。

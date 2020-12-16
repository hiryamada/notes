# Azure Key Vault

アプリやサービスで使用される暗号化キーなどのシークレットを保護および管理することができます。


[製品ページ](https://azure.microsoft.com/ja-jp/services/key-vault/)

Microsoft Learn

- [Azure Key Vault を使用してサーバー アプリのシークレットを管理する](https://docs.microsoft.com/ja-jp/learn/modules/manage-secrets-with-azure-key-vault/)
- [Azure Key Vault でのシークレットの構成と管理](https://docs.microsoft.com/ja-jp/learn/modules/configure-and-manage-azure-key-vault/)
- [Azure キー コンテナーを使用して ASP.NET アプリの構成を外部化する](https://docs.microsoft.com/ja-jp/learn/modules/aspnet-configurationbuilder/)


[Managed HSM](https://docs.microsoft.com/ja-jp/azure/key-vault/managed-hsm/): [public preview](https://azure.microsoft.com/en-us/updates/akv-managed-hsm-public-preview/#:~:text=Managed%20HSM%20is%20a%20new,pools%20should%20be%20very%20simple.). Managed HSM pool とも。

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/key-vault/general/overview)

[解説スライド](https://www.slideshare.net/junichia/azure-key-vault-77692730)


# Azure Dedicated HSM
「Azure Key Vault」のほかに、「Azure Dedicated HSM」というサービスもあります。

「Azure Dedicated HSM」は試験の範囲外です。

[Azure Dedicated HSMのノート](mod07-01-mod07-01-dedicatedhsm.md)

# Azure Key Vaultで管理できるもの

- [キー](https://docs.microsoft.com/ja-jp/azure/key-vault/keys/about-keys)：暗号化に使用するキー
- [シークレット](https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/about-secrets)：接続文字列、パスワード、トークンなど。[Key Vaultでストレージアカウントキーを管理・ローテーションすることができる。](https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/about-secrets#azure-storage-account-key-management)この場合の管理下に置かれたストレージアカウントキーも「シークレット」の一種である。
- [証明書](https://docs.microsoft.com/ja-jp/azure/key-vault/certificates/about-certificates)：パブリックおよびプライベートのTLS証明書

※これらはまとめて「シークレット」と呼ばれる場合がありますが、実際の操作では区別して扱います。

# [Azure Key Vaultに格納すべきもの](https://docs.microsoft.com/ja-jp/learn/modules/manage-secrets-with-azure-key-vault/2-what-is-key-vault)

- サーバーアプリのシークレット（接続文字列など）: Azure Key Vault
- ユーザーに属する情報（ユーザーの個人情報やクレジットカード番号など）: データベースなど（Azure Key Vaultは適さない）
  

ユーザーの機密情報はデータベースなどに保存。そのデータベースに接続するための情報をAzure Key Vaultに保存。

シークレットの値はAzure Key Vaultに保存するが、そのシークレットの名前は機密情報ではなく、アプリケーション側に格納してよい。

参考：[Azure Key Vault のスロットル ガイダンス](https://docs.microsoft.com/ja-jp/azure/key-vault/general/overview-throttling) Key Vault は本来、デプロイ時にシークレットを格納および取得するために使用するように設計されました。 世界が進化し、実行時にシークレットを格納および取得するために Key Vault が使用されています。そして多くの場合、アプリやサービスは Key Vault をデータベースのように使用することを希望しています。現在の制限は、高いスループット率をサポートしていません。 

# Azure Key Vaultのリソース

- ボールト（コンテナー）- キー、シークレット、証明書
  - Standard - ソフトウェア (FIPS 140-2 Level 1)
  - Premium - HSM (FIPS 140-2 Level 2)
- Managed HSM Pools - キーのみ
  - Standard B1 - HSM (FIPS 140-2 Level 3)

「ボールト」（コンテナー）と「Managed HSM Pools」の2種類のリソースを作成できます。

※「ボールト」(vault)の日本語訳として「コンテナー」「キー コンテナー」「資格情報コンテナー」などの用語も使用されます。

「ボールト」を作成する際は、`Standard` または `Premium`のSKUを選択します。※指定を省略すると`Standard`になる。

「Managed HSM Pools」のSKUは現在「Standard B1」のみであり、リソース作成時のSKUの指定は不要です。

# VaultとManaged HSM Poolsの違い

ボールトでは、ソフトウェアと HSM でバックアップされる**キー、シークレット、証明書**を保存できます。

Managed HSM プールは、**HSM でバックアップされるキーにのみ対応**しています。 

# `Premium`のVault と Managed HSM Poolsの違い

- `Premium`のVault - FIPS 140-2 Level 2
- Managed HSM Pools - FIPS 140-2 Level 3, AZ対応

# Azure Key Vaultのキー

「ボールト」では「ソフトウェアで保護されたキー」を作成できます。また、Premium SKUを選択した場合は、「HSMで保護されたキー」を作成できます。

「Managed HSM Pools」では「HSMで保護されたキー」のみを作成できます。

# FIPS 140-2への対応

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

# [管理プレーンとデータプレーン](https://docs.microsoft.com/ja-jp/azure/key-vault/general/authentication-fundamentals#configure-key-vault-access-policies-for-your-security-principal)

Key Vault の操作には、主に、管理プレーン (コントロール プレーンとも呼ばれます) の操作とデータ プレーンの操作の 2 種類があります。

- 管理プレーン: Key Vaultの作成・削除など。Key Vaultリソース（あるいはその上位のスコープ）で、ユーザーにRBACロール（Key Vault閲覧者、所有者など）を割り当てることでコントロール。
- データプレーン: キー、シークレット、証明書の作成・削除。[「アクセスポリシー」](https://docs.microsoft.com/ja-jp/azure/key-vault/general/authentication-fundamentals#data-plane-access-option-1-classic-key-vault-access-policies)または[「Key Vault用のAzure RBAC」（プレビュー）](https://docs.microsoft.com/ja-jp/azure/key-vault/general/authentication-fundamentals#data-plane-access-option-2--azure-rbac-for-key-vault-preview)を割り当てることでコントロール。

[データプレーンのアクセス制御は、アクセスポリシーと、Key Vault用のAzure RBACのどちらか1つを選択する必要がある。組み合わせて使用することはできない。](https://docs.microsoft.com/ja-jp/azure/key-vault/general/authentication-fundamentals#data-plane-access-option-1-classic-key-vault-access-policies)

従来の Key Vault のアクセス ポリシーと Azure Active Directory のロールの割り当ては、互いに独立している

# Key Vaultのアクセス許可モデル

キー コンテナーにアクセスする場合、呼び出し元 (ユーザーまたはアプリケーション) がアクセスする前に適切な認証と認可が必要になります。 認証では呼び出し元の ID を確認し、認可では呼び出し元が実行できる操作を決定します。

認証は Azure Active Directory を介して行われます。 

認可は、Azure ロールベースのアクセス制御 (Azure RBAC) または Key Vault のアクセス ポリシーを使用して行うことができます。 

Azure RBAC は、**コンテナーを管理するとき**に使用されます。

キー コンテナーのアクセス ポリシーは、**コンテナーに格納されているデータにアクセスするとき**に使用されます。

- Key Vault アクセス ポリシー
- Azure RBAC

**これらのモデルは排他的**であり、いったん「Azure RBAC」に設定すると、「Key Vault アクセス ポリシー」は非アクティブになります。

[データ プレーンとアクセス ポリシー](https://docs.microsoft.com/ja-jp/azure/key-vault/general/secure-your-key-vault#data-plane-and-access-policies)

[データ プレーンと Azure RBAC (プレビュー)](https://docs.microsoft.com/ja-jp/azure/key-vault/general/secure-your-key-vault#data-plane-and-azure-rbac-preview) - 2020/10/19の[アナウンス](https://azure.microsoft.com/en-us/updates/azure-rolebased-access-control-rbac-for-azure-key-vault-data-plane-authorization-is-now-in-preview/)


# 操作例

クイックスタート
- [Vault(Standard)](https://docs.microsoft.com/ja-jp/azure/key-vault/general/manage-with-cli2)
  - az provider register -n Microsoft.KeyVault
  - az keyvault create --name
  - az keyvault key create --vault-name --name
  - az keyvault secret set --vault-name --name --value 
- [VaultのHSM(Premium)](https://docs.microsoft.com/ja-jp/azure/key-vault/general/manage-with-cli2#working-with-hardware-security-modules-hsms)
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

# Key Vault作成の流れ

「キー コンテナー」リソースを作成。

Key Vault名: 一意の名前。`https://<your-unique-keyvault-name>.vault.azure.net/` のような「Vault URI」に使用される。

価格レベル: Standard / Premium

[論理的な削除](https://docs.microsoft.com/ja-jp/azure/key-vault/general/soft-delete-overview): デフォルトで有効, 90日.

[消去保護](https://docs.microsoft.com/ja-jp/azure/key-vault/general/soft-delete-overview#purge-protection): デフォルトでは無効（保持期間中のキー コンテナーおよびオブジェクトの消去を許可）。

アクセスの有効化: 

- Azure Virtual Machines: 証明書へのアクセス
- Azure Resource Manager: シークレットへのアクセス
- Azure Disk Encryption: シークレットとラップされたキー

アクセス許可モデル: アクセスポリシー または RBAC（プレビュー）

アクセスポリシーを選択した場合は、AADユーザーに対する「キーのアクセス許可」「シークレットのアクセス許可」「証明書のアクセス許可」を選択。

ネットワーク接続: 

- パブリック エンドポイント(全てのネットワーク): デフォルト
- パブリック エンドポイント: VNetとサブネットを選択する。サブネット側で「サービスエンドポイント」が有効化される。
- プライベート エンドポイント: VNetとサブネットを選択。デフォルトで、プライベートDNSゾーンとの統合も構成される。

# [Key Vaultファイアウォール](https://docs.microsoft.com/ja-jp/azure/key-vault/general/network-security)

※キーコンテナー作成後に設定可能。

設定＞ネットワーク で、「すべてのネットワーク」から「プライベートエンドポイントと選択されたネットワーク」を選択。

IPv4アドレスまたはCIDRを複数件指定できる。

指定したアドレスからのみ接続できるようになる。

例:「すべてのネットワーク」から「プライベートエンドポイントと選択されたネットワーク」に切り替えて保存すると、すべてのネットワークアクセスを禁止した状態となる。ポータルからも読み書きができなくなる。

# シークレットの読み書き例

```
az login
az account set --subsription ...

# シークレットを設定し、表示
az keyvault secret set --vault-name ... --name ... --value ...
az keyvault secret show --vault-name ... --name ...

# 削除、削除されたシークレットの一覧表示、リカバー
az keyvault secret delete --vault-name ... --name ...
az keyvault secret list-deleted --vault-name ...
az keyvault secret recover --vault-name ... --name ...

# 完全に削除するには delete してさらに purge する
az keyvault secret delete --vault-name ... --name ...
az keyvault secret purge --vault-name ... --name ...

```



# Key Vault マネージド ストレージ アカウント キー機能

Key Vault マネージド ストレージ アカウント キー機能を使用して、Azure ストレージ アカウントのキーを一覧表示し (同期)、定期的にキーを再生成 (ローテーション) できます。

ストレージ アカウント キーの管理は Key Vault のみが行う必要があります。 キーを自分で管理したり、Key Vault のプロセスに干渉したりしないでください。

ストレージ アカウント キーの管理は、1 つの Key Vault オブジェクトのみが行う必要があります。 複数のオブジェクトからのキー管理を許可しないでください。

キーの再生成 (ローテーション) は、Key Vault のみを使用して行います。 ストレージ アカウント キーを手動で再生成 (ローテーション) しないでください。

[Azure CLIでの操作](https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/overview-storage-keys) / [PowerShellでの操作](https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/overview-storage-keys-powershell)

手順の概要

- Key VaultのアプリケーションID（「cfa8b339-82a2-471a-a3c9-0fc0be7a4093」、これは[すべてのAzure ADテナントに事前登録されている](https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/overview-storage-keys#service-principal-application-id)）に、「[ストレージ アカウント キー オペレーターのサービス ロール](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#storage-account-key-operator-service-role)」(Storage Account Key Operator Service Role)を割り当てる.
- 現在のユーザーに対するすべてのアクセス許可を付与するように、[ストレージアカウントのアクセスポリシーを更新する](https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/overview-storage-keys#give-your-user-account-permission-to-managed-storage-accounts)。
- [Key Vault のマネージド ストレージ アカウントを作成する](https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/overview-storage-keys#create-a-key-vault-managed-storage-account) - `az keyvault storage add --regeneration-period P90D` のように指定することで、キーの再生成期間を90日に設定できる。

設定が完了したら、[「SAS定義」をKey Vaultに格納し、その「SAS定義」から「SASトークン」を生成する](https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/storage-keys-sas-tokens-code)ことができる。

# キーコンテナーに対する認証

アプリケーションがKey Vaultのシークレットにアクセスするには、アプリケーションがAzure ADによって認証される必要がある。（かつ、アプリケーションに、シークレットにアクセスする権限も必要。）

アプリケーションの認証には「マネージドID」または「サービス プリンシパル」を使用する。

[マネージドID](https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/overview) - Azure リソースの ID は Azure AD から提供され、その ID を使用して Azure Active Directory (Azure AD) トークンが取得される。たとえばVM、VMSS、App Service、Azure Functions、ACIなどに対してマネージドIDを有効にすることができる。[内部的には、マネージドIDは特別な種類のサービス プリンシパルである。](https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/how-managed-identities-work-vm#how-it-works)

[サービスプリンシパル](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-authenticate-service-principal-powershell) - リソースへのアクセスを必要とするアプリやスクリプトがある場合は、アプリの ID を設定し、アプリを独自の資格情報で認証できます。 **この ID は、サービス プリンシパルと呼ばれます**。[無人スクリプトを実行するときに、証明書を使用して認証できます。](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-authenticate-service-principal-powershell)

サービスプリンシパルの場合は、証明書による認証、アプリケーション シークレットによる認証が利用できる。

※Key Vaultのそもそもの目的からして、そこにアクセスするために証明書やアプリケーションシークレットをアプリ側に持たせるというのはナンセンス。（「[ブートストラップ問題](https://docs.microsoft.com/ja-jp/learn/modules/manage-secrets-with-azure-key-vault/4-authentication-with-managed-identities-for-azure-resources)」と呼ばれる。「[Key Vault に対する認証で使用されるブートストラップ シークレットを自動的にローテーションするのは困難です。](https://docs.microsoft.com/ja-jp/azure/key-vault/general/basic-concepts)」）パスワードにアクセスするために別のパスワードが必要、のような状態。

- マネージドID - 推奨
- [「サービス プリンシパル」と証明書](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-create-service-principal-portal#option-1-upload-a-certificate)
- [「サービス プリンシパル」と「アプリケーション シークレット」](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/howto-create-service-principal-portal#option-2-create-a-new-application-secret)

※マネージドIDについての詳細は[次のLesson（mod07-02）](mod07-02-managed-id.md)で学習する。

# [「コンテナーの所有者」「コンテナー コンシューマー」](https://docs.microsoft.com/ja-jp/azure/key-vault/general/basic-concepts)とは？



このような名前のロールがあるわけではない。

コンテナーにこのようなプロパティがあるわけでもない。

単に「コンテナーを管理する側のユーザー」と「コンテナーの中のシークレットを利用する側のユーザー」がいる、と説明しているに過ぎない（と思われる）。

# [キー](https://docs.microsoft.com/ja-jp/azure/key-vault/keys/about-keys)とは？

キーは、特定の用途向けの暗号アセットです。

[Microsoft Azure RMS の非対称マスターキー、SQL Server TDE (Transparent Data Encryption)、CLE (列レベルの暗号化)、暗号化されたバックアップなどがあります。](https://docs.microsoft.com/ja-jp/learn/modules/configure-and-manage-azure-key-vault/2-key-vault-usage)


# キーの形式

Key Vault の暗号化キーは、[JSON Web Key (JWK) ](https://tools.ietf.org/html/draft-ietf-jose-json-web-key-41)オブジェクトとして表されます。これらのキーは、シングルテナントの HSM プールで保護されます。

A JSON Web Key (JWK) is a JSON data structure that represents a cryptographic key. 

[JWKの解説](https://techinfoofmicrosofttech.osscons.jp/index.php?JWK#d905d797)

HSM で保護されたキー (HSM キーとも呼ばれます) は、HSM (ハードウェア セキュリティ モジュール) で処理され、常に HSM の保護境界内に留まります。

# キーの[ラップ(WRAP)](https://docs.microsoft.com/ja-jp/rest/api/keyvault/wrapkey)と[アンラップ(UNWRAP)](https://docs.microsoft.com/ja-jp/rest/api/keyvault/unwrapkey)

[エンベロープ暗号化](https://docs.microsoft.com/ja-jp/azure/storage/common/storage-client-side-encryption?tabs=dotnet#encryption-and-decryption-via-the-envelope-technique)におけるデータキー（CEK）の暗号化の操作をラップ(wrap)、復号の操作をアンラップ(wrap)という。ラップ/アンラップに使用される鍵はKEKと呼ぶ。

- CEK - Contents Encryption Key, 対称キー(共通鍵)
- KEK - Key Encryption Key, 対称キーまたは非対称キー(公開鍵と秘密鍵), Key Vault内部に格納される. 


[Key-encription key (KEK)](https://www.ipa.go.jp/security/rfc/RFC2828-03KJA.html#key-encrypting%20key):
他の鍵（DEK や他の KEK）を暗号化するために使われるが、通常、アプリケーションデータを暗号化するためには使われない暗号技術的鍵。

Azure ストレージ クライアント ライブラリはCEKを生成し、データを暗号化する。次に、KEKを使用してCEKをラップまたは暗号化する（）。暗号化されたデータはストレージに保存され、ラップされたキーはメタデータとしてデータとともに保存される。

CEKはコンテンツごとに作られ、暗号化とラップが終わったら元のCEKは直ちに捨てられる（ラップされたCEKは暗号化されたデータと一緒に保存）。CEKをラップ・アンラップするにはKey Vaultに対する適切な権限が必要。Key Vault側にはラップ・アンラップの記録が残る。クライアントライブラリはKEKには直接アクセスしない（できない）。

CEKは毎回生成されるので、ある1つのCEKが[危殆化(compromised)](https://www.ipa.go.jp/files/000013736.pdf)した場合でも、その影響を受けるのは、そのCEKを使用して暗号化されたデータに限られる。

# WRAPの操作はどこで行なわれるのか？

https://docs.microsoft.com/en-us/rest/api/keyvault/wrapkey/wrapkey

WRAP操作は、以前にAzure KeyVaultに格納されていたキー暗号化キーを使用した対称キーの暗号化をサポートします。

非対称キーによる保護はキーの公開部分を使用して実行できるため、WRAP操作はAzure Key Vaultに格納されている対称キーにのみ厳密に必要です。

つまり、Key Vault格納されたKEKによって、どこでWRAPするかが決まる。
- 対称キーの場合: Key Vault側でWRAPすることが必要
- 非対称キーの場合: 非対称キーの「公開部分」（公開鍵）を使って、ローカルでWRAPが可能

[Key Encryption / Wrapping](https://docs.microsoft.com/en-us/azure/key-vault/keys/about-keys-details)
にはこのようなことが書いてある

KEKが対称キーならば「[キー暗号化](https://docs.microsoft.com/en-us/rest/api/keyvault/encrypt/encrypt)」が使われる。

KEKが非対称キーならば「[キーラッピング](https://docs.microsoft.com/en-us/rest/api/keyvault/wrapkey/wrapkey)」が使われる。

WRAPKEYは、パブリックキーへのアクセスがないアプリケーションの利便性のためにサポートされる。

最高のパフォーマンスのため、WRAPKEY操作はローカルで行なわれるべきである。

要するに・・「キーラッピング」は本来ローカルで実行できる（すべき）ものだが、ローカルにパブリックキーがないアプリが、Key Vaultを使ってラップが実行できるように、そのようなAPIがある。「キー暗号化」は、もちろんKey Vault側でないと実行できない。

実際の動きとしてはクライアントライブラリがよしなに実行してくれるものと思われる（未確認）。

# [証明書](https://docs.microsoft.com/ja-jp/azure/key-vault/certificates/about-certificates)はどのように使うのか？

Key Vault 証明書のサポートにより、x509 証明書が管理されるようになります。

証明機関 (CA) によって署名された、パブリックおよびプライベートの Secure Sockets Layer (SSL)/Transport Layer Security (TLS) 証明書、または自己署名証明書を使用できます。

[Azure Key Vault でサポートされている証明書の形式は PFX と PEM です。.pem ファイル形式には、1 つまたは複数の X509 証明書ファイルが含まれています。.pfx ファイル形式は、サーバー証明書 (ドメイン用に発行) や一致する秘密キーなどの複数の暗号化オブジェクトを 1 つのファイルに格納するためのアーカイブ ファイル形式で、必要に応じて中間 CA を含めることができます。](https://docs.microsoft.com/ja-jp/azure/key-vault/certificates/tutorial-import-certificate)

証明書の所有者が、Key Vault 作成プロセスを介して、または既存の証明書をインポートして、証明書を作成できます。 自己署名証明書と証明機関によって生成された証明書の両方が含まれます。

Key Vault 証明書が作成されるとき、秘密キーと共にアドレス指定可能なシークレットから PFX または PEM 形式で取得できます。 

# 証明書のローテーションは？

https://docs.microsoft.com/ja-jp/azure/key-vault/certificates/tutorial-rotate-certificates

Key Vault では、CA との確立されたパートナーシップを通じて証明書が自動的にローテーションされます。

Key Vault はパートナーシップを通じて証明書を自動的に要求および更新します。

次の CA は、現在 Key Vault と提携しているプロバイダーです。
- DigiCert:Key Vault は、OV TLS/SSL 証明書を提供します。
- GlobalSign:Key Vault は、OV TLS/SSL 証明書を提供します。

# 特定のバージョンのシークレットを取得するには？

# [診断設定](https://docs.microsoft.com/ja-jp/azure/key-vault/general/howto-logging)

他のAzureリソースと同様、ログとメトリクスに対する診断設定を行うことができる（ログとメトリクスをLog Analyticsワークスペースへ転送したりできる）。

# アクセス急増に対してスケール（アウト）するか？

# セカンダリリージョンはどのように使われる？

# RBACのロールにはどのようなものがあるか？


# OAuth2、Bearerトークンとは？

# ExamplePasswordとは？


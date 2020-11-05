# Azure Active Directory (Azure AD)

Azure ADは、Microsoft が提供する、[クラウドベースの ID およびアクセス管理サービス(IDaaS)](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-whatis)です。

さまざまなシステムへのサインインに利用することができます。
- Microsoft 365、Azure portalへのサインイン
- [SaaS アプリケーションへのサインイン](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/tutorial-list)
  - [Salesforce](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/salesforce-tutorial)
  - [Adobe Creative Cloud](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/adobe-creative-cloud-tutorial)
  - [AWS](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/amazon-web-service-tutorial)
  - [Zoom](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/zoom-tutorial)
  - [ヌーラボ](https://support.nulab.com/hc/ja/articles/360050198033-SAML%E8%AA%8D%E8%A8%BC-SSO-%E3%81%AE%E8%A8%AD%E5%AE%9A)
- 企業ネットワークとイントラネット上のアプリへのサインイン - [Azure AD アプリケーション プロキシ](https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/application-proxy)
- [自分の組織で開発したクラウド アプリへのサインイン](https://docs.microsoft.com/ja-jp/azure/app-service/configure-authentication-provider-aad)

パスワードなどの[資格情報の保護](https://docs.microsoft.com/ja-jp/azure/architecture/example-scenario/aadsec/azure-ad-security#credential-management)に役立つ機能を提供します。

Azure ADには、組織が所有するWindows PCだけではなく、ユーザー所有のiOSやAndroidなど、様々なデバイスで接続することができます。管理者は、「デバイスの参加」「デバイスの登録」を使用して、アクセスするデバイスを制御することができます（後述）。

ユーザーがパスワードを忘れてしまった場合、パスワードのリセット機能を利用できます（後述）。

オンプレミスのActive Directoryと、Azure ADを接続することができます（後述）。これにより、ユーザーは、1つのIDで、オンプレミスとクラウドの両方にアクセスすることができます。

# Azure ADの概念

[Azure AD テナント(ディレクトリ)とは](https://docs.microsoft.com/ja-jp/learn/modules/manage-users-and-groups-in-aad/2-create-aad)
- 企業または組織が、AzureやMicrosoft 365などのサービスにサインアップすると、既定の "ディレクトリ" が割り当てられ、Azure AD のインスタンスになります。 
- このディレクトリには、会社がサインアップした各サービスにアクセスできるユーザーとグループが保持されます。 
- この既定のディレクトリは、"テナント" と呼ばれることもあります。 
- テナントは、組織と、それに割り当てられた既定のディレクトリを表します。

[Azure ADのデータの保存場所は、Azure AD テナントを作成するときに選択した国/地域によって決まります。](https://docs.microsoft.com/ja-jp/azure/active-directory-b2c/data-residency#data-residency)

# [Active Directory Directory Service (AD DS)](https://docs.microsoft.com/ja-jp/windows-server/identity/ad-ds/ad-ds-getting-started) と Azure AD の違い

Azure ADは、[オンプレミスのActive Directoryとは異なります。](https://docs.microsoft.com/ja-jp/learn/modules/manage-users-and-groups-in-aad/2-create-aad)

- Azure AD は、Windows Server Active Directory のクラウド バージョンではありません。 
- オンプレミスの Active Directory を完全に置き換えることを目的としたものでもありません。

オンプレミスの Active Directory がすでに存在する場合、Azure AD Connectを使用して、オンプレミスのActive Directoryと、Azure ADを接続し、ハイブリッドIDを提供することができます（後述）。

# ハイブリッドID

オンプレミスとクラウドを基盤とする機能を利用する際に、場所に関係なく、1 つのユーザー ID ですべてのリソースの認証と権限付与を行うことができます。これを[ハイブリッド ID](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/) と呼んでいます。

ハイブリッドIDを実装するには、[Azure AD Connect](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect)を使用します。

Azure AD Connectの特徴

- オンプレミスのActive Directoryを、Azure ADに接続することができます。
- [無料で利用できます。](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect#license-requirements-for-using-azure-ad-connect)
- [ドメインに参加している Windows Server 2012 以降にインストールします](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-install-prerequisites)
- いくつかのハイブリッドIDの実装方式を選択できます。
  - [パスワード ハッシュ同期](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/tutorial-password-hash-sync) - ユーザーのオンプレミス AD パスワードのハッシュを Azure AD と同期させるサインイン方法。
  - [パススルー認証](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/tutorial-passthrough-authentication) - ユーザーがオンプレミスとクラウド内で同じパスワードを使用できるようにするサインイン方法。

# Azure ADのエディション

[Azure ADのエディションと価格](https://azure.microsoft.com/ja-jp/pricing/details/active-directory/)
- Free
- Office 365アプリ（Office 365、Microsoft 365サブスクリプションにて使用できる機能）
- Premium P1: ￥672 ユーザー/月
- Premium P2: ￥1,008 ユーザー/月

※[Basicは廃止に](https://www.google.com/search?q=azure+ad+basic+%E5%BB%83%E6%AD%A2)

[ユーザーまたはグループ (および関連するメンバー) ごとに、ライセンスを付与する必要があります。](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/license-users-groups)

# Azure ADの参加(Azure AD joined)

[Azure ADの参加とは](https://docs.microsoft.com/ja-jp/learn/modules/manage-device-identity-ad-join/3-what-is-ad-join)
- 組織が所有する、Windows 10 または Windows Server 2019 デバイスを Azure Active Directory インスタンスに参加させることができます。 
- 組織のリソースへのアクセスを、組織が管理しているデバイスのみに制限することができます。
- 組織は、[条件付きアクセス](https://docs.microsoft.com/ja-jp/learn/modules/manage-device-identity-ad-join/2-what-is-device-identity)を設定して、特定の条件を満たす場合に、デバイスのアクセスを許可または禁止することができます。
- ユーザーは、自分の職場アカウントを使用して、Azure AD インスタンスにアクセスします。
- ユーザーは、パスワードまたは [Windows Hello](https://support.microsoft.com/ja-jp/windows/windows-hello-%E3%81%AE%E6%A6%82%E8%A6%81%E3%81%A8%E3%82%BB%E3%83%83%E3%83%88%E3%82%A2%E3%83%83%E3%83%97-dae28983-8242-bb2a-d3d1-87c9d265a5f0) を使用して、ユーザー認証をすることができます。Windows Hello では、顔認証や指紋認証を使用することができます。


[Enterprise State Roaming](https://docs.microsoft.com/ja-jp/learn/modules/manage-device-identity-ad-join/4-what-is-enterprise-state-roaming)

- Windows 10 デバイスの設定とアプリケーション データを組織のクラウド サービスと同期させる機能です。
- すべてのデバイス ユーザーを有効にすることも、組織のニーズに基づいて特定のユーザーまたはグループを選択することもできます。
- [Enterprise State Roamingを使用するには、ライセンスの割り当てが必要です。](https://docs.microsoft.com/en-us/azure/active-directory/authentication/concept-sspr-licensing)
  - [Azure AD Premium P1 or P2](https://azure.microsoft.com/ja-jp/pricing/details/active-directory/)


# Azure ADの登録(Azure AD registered)

[Azure ADの登録済みデバイス](https://docs.microsoft.com/ja-jp/azure/active-directory/devices/concept-azure-ad-register)

- ユーザーは個人所有のデバイスを使用して、組織の Azure Active Directory の管理下にあるリソースにアクセスできます。
- Windows 10、iOS、Android、MacOSに対応します。
- 組織は、[条件付きアクセス](https://docs.microsoft.com/ja-jp/learn/modules/manage-device-identity-ad-join/2-what-is-device-identity)を設定して、特定の条件を満たす場合に、デバイスのアクセスを許可または禁止することができます。
- [Microsoft Intune](https://www.microsoft.com/ja-jp/microsoft-365/enterprise-mobility-security/microsoft-intune) などの Mobile Device Management (MDM) ツールを使用して、Azure AD 登録済みデバイスをセキュリティで保護し、制御することができます。 MDM では、ストレージの暗号化、パスワードの複雑さ、セキュリティ ソフトウェアを常に最新の状態に保つことを求めるなど、組織に必要な構成を適用する手段が提供されます。

# 管理者による、ユーザーのパスワードのリセット

ユーザーが自分のパスワードを忘れてしまった場合、[管理者は、ユーザーのパスワードをリセットできます。](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-users-reset-password-azure-portal)

# セルフサービス パスワードリセット(SSPR)

[Azure AD のセルフサービス パスワード リセット](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-howitworks)

- SSPRを使用すると、ユーザーが自分のパスワードを忘れてしまった場合、管理者やヘルプ デスクが関与することなく、自分のパスワードをリセットすることができます。
- ユーザーは、画面の指示に従って、自分自身のロックを解除して、作業に戻ることができます。
- 組織のヘルプ デスクの問い合わせが減り、生産性の喪失も軽減されます。
- [SSPRの有効範囲](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/tutorial-enable-sspr#enable-self-service-password-reset)は、「なし」「選択済み（指定したグループ）」「すべて」の3種類から選ぶことができます。現在、Azure portal を使用して SSPR に対して有効にできる Azure AD グループは 1 つだけです。

[SSPRを使用するには、ライセンスの割り当てが必要です。](https://docs.microsoft.com/en-us/azure/active-directory/authentication/concept-sspr-licensing)

- [Azure AD Premium P1 or P2](https://azure.microsoft.com/ja-jp/pricing/details/active-directory/)
- [Microsoft 365 Business Standard, Microsoft 365 Business Premium] (https://www.microsoft.com/ja-jp/microsoft-365/business/compare-all-microsoft-365-business-products)


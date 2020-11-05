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

[資格情報(パスワードなど)の保護](https://docs.microsoft.com/ja-jp/azure/architecture/example-scenario/aadsec/azure-ad-security#credential-management)に役立つ機能を提供します。

「デバイスの参加」「デバイスの登録」を使用して、アクセスするデバイスを制御することができます（後述）。

ユーザーがパスワードを忘れてしまった場合、パスワードのリセット機能を利用できます（後述）。

# Azure ADの概念

[Azure AD テナント(ディレクトリ)とは](https://docs.microsoft.com/ja-jp/learn/modules/manage-users-and-groups-in-aad/2-create-aad)
- 企業または組織が、AzureやMicrosoft 365などのサービスにサインアップすると、既定の "ディレクトリ" が割り当てられ、Azure AD のインスタンスになります。 
- このディレクトリには、会社がサインアップした各サービスにアクセスできるユーザーとグループが保持されます。 
- この既定のディレクトリは、"テナント" と呼ばれることもあります。 
- テナントは、組織と、それに割り当てられた既定のディレクトリを表します。

# AD DSとAzure AD

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
- ユーザーは、パスワードまたは Windows Hello を使用して、ユーザー認証をすることができます。

# Azure ADの登録(Azure AD registered)

[Azure ADの登録済みデバイス](https://docs.microsoft.com/ja-jp/azure/active-directory/devices/concept-azure-ad-register)
- ユーザーは個人所有のデバイスを使用して、組織の Azure Active Directory の管理下にあるリソースにアクセスできます。
- Windows 10、iOS、Android、MacOSに対応します。
- 組織は、[条件付きアクセス](https://docs.microsoft.com/ja-jp/learn/modules/manage-device-identity-ad-join/2-what-is-device-identity)を設定して、特定の条件を満たす場合に、デバイスのアクセスを許可または禁止することができます。
- [Microsoft Intune](https://www.microsoft.com/ja-jp/microsoft-365/enterprise-mobility-security/microsoft-intune) などの Mobile Device Management (MDM) ツールを使用して、Azure AD 登録済みデバイスをセキュリティで保護し、制御することができます。 MDM では、ストレージの暗号化、パスワードの複雑さ、セキュリティ ソフトウェアを常に最新の状態に保つことを求めるなど、組織に必要な構成を適用する手段が提供されます。

# 管理者による、ユーザーのパスワードのリセット

[管理者は、ユーザーのパスワードをリセットできます。](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-users-reset-password-azure-portal)

# セルフサービス パスワードリセット(SSPR)

[Azure AD のセルフサービス パスワード リセット](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-howitworks)

- ユーザーは、管理者やヘルプ デスクが関与することなく、自分のパスワードを変更またはリセットできるようになります。
- ユーザーはアカウントがロックされた場合やパスワードを忘れた場合でも、画面の指示に従って自分自身のロックを解除して、作業に戻ることができます。
- ヘルプ デスクの問い合わせが減り、生産性の喪失も軽減されます。
- [ライセンスの割り当てが必要な機能です。](https://docs.microsoft.com/en-us/azure/active-directory/authentication/concept-sspr-licensing)
  - [Azure AD Premium P1 or P2](https://azure.microsoft.com/ja-jp/pricing/details/active-directory/)
  - [Microsoft 365 Business Standard, Microsoft 365 Business Premium] (https://www.microsoft.com/ja-jp/microsoft-365/business/compare-all-microsoft-365-business-products)

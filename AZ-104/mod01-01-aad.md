# Azure Active Directory (Azure AD)

Azure ADは、Microsoft が提供する、[クラウドベースの ID およびアクセス管理サービス(IDaaS)](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-whatis)です。

さまざまなシステムへのサインインに利用することができます。
- Microsoft 365、Azure portalへのサインイン
- [SaaS アプリケーションへのサインイン](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/tutorial-list)
  - [Salesforce](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/salesforce-tutorial)
  - [Slack](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/slack-tutorial)
  - [Concur](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/concur-tutorial)
  - [Dropbox Business](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/dropboxforbusiness-tutorial)
  - [Adobe Creative Cloud](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/adobe-creative-cloud-tutorial)
  - [AWS](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/amazon-web-service-tutorial)
  - [Zoom](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/zoom-tutorial)
  - [ヌーラボ](https://support.nulab.com/hc/ja/articles/360050198033-SAML%E8%AA%8D%E8%A8%BC-SSO-%E3%81%AE%E8%A8%AD%E5%AE%9A)
  - [サイボウズ Kintone](https://docs.microsoft.com/ja-jp/azure/active-directory/saas-apps/kintone-tutorial)
  - [マネーフォワード クラウド](https://support.biz.moneyforward.com/valuepack/guide/sso/g022.html)
- オンプレミスのアプリへのサインイン - [Azure AD アプリケーション プロキシ](https://docs.microsoft.com/ja-jp/azure/active-directory/manage-apps/application-proxy)
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

[ユーザー数が100万未満の組織では、1つのテナントを作成することを強くお勧めします。100万を超えるユーザーがいる組織では、マルチテナントアーキテクチャを推奨します。](https://docs.microsoft.com/ja-jp/microsoft-365/education/deploy/design-multi-tenant-architecture)

[Azure ADのデータの保存場所は、Azure AD テナントを作成するときに選択した国/地域によって決まります。](https://docs.microsoft.com/ja-jp/azure/active-directory-b2c/data-residency#data-residency)

# テナントのドメイン名 

テキスト：モジュール4/Azure DNS/ドメインとカスタム ドメイン, カスタム ドメイン名を構成する

[初期ドメイン名とカスタムドメイン名](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/add-custom-domain)

- 初期ドメイン名: 新しい Azure AD テナントにはすべて、 ～～.onmicrosoft.com という初期ドメイン名が付きます。初期ドメイン名は変更したり削除したりできません。Azureのサインアップに使用したメールアドレスが user@example.com だった場合、初期ドメイン名は userexample.onmicrosoft.com のようになります。

- カスタム ドメイン名: ドメイン レジストラーでドメイン名を作成（購入）し、Azure AD テナントに追加することができます。

[プライマリ ドメイン](https://docs.microsoft.com/ja-jp/azure/active-directory/enterprise-users/domains-manage)

カスタム ドメインを追加後、それをテナントのプライマリ ドメインに設定することができます。プライマリ ドメインは、新しいユーザーを作成したときの既定のドメインになります。


# [Active Directory Directory Service (AD DS)](https://docs.microsoft.com/ja-jp/windows-server/identity/ad-ds/ad-ds-getting-started) と Azure AD の違い

Azure ADは、[オンプレミスのAD DSとは異なります。](https://docs.microsoft.com/ja-jp/learn/modules/manage-users-and-groups-in-aad/2-create-aad)

- Azure AD は、AD DS のクラウド バージョンではありません。 
- オンプレミスの AD DS を完全に置き換えることを目的としたものでもありません。
- AD DSの[OU(組織単位)](https://docs.microsoft.com/ja-jp/azure/active-directory-domain-services/create-ou)や[GPO(グループポリシーオブジェクト)](https://docs.microsoft.com/ja-jp/azure/active-directory-domain-services/manage-group-policy)は、Azure ADにはありません。(※)
- プロトコルや利用場所が異なります。

|-|AD DS|Azure AD|
|-|-|-|
|プロトコル|[Kerberos](https://ja.wikipedia.org/wiki/%E3%82%B1%E3%83%AB%E3%83%99%E3%83%AD%E3%82%B9%E8%AA%8D%E8%A8%BC), [NTLM](https://ja.wikipedia.org/wiki/NT_LAN_Manager)|[OAuth, OpenID Connect, SAML](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/authentication-vs-authorization#authentication-and-authorization-using-microsoft-identity-platform)|
|利用できる場所|オンプレミス(組織のファイアウォール内)|クラウド(インターネット)|

オンプレミスの AD DS がすでに存在する場合、Azure AD Connectを使用して、オンプレミスのAD DSと、Azure ADを接続することができます（後述）。

※ 従来の AD DS 機能(ドメイン参加、グループ ポリシー、LDAP、Kerberos 認証、NTLM 認証など)が必要な場合は、[Azure AD Domain Service](https://azure.microsoft.com/ja-jp/services/active-directory-ds/) というマネージド ドメイン サービスを利用することができます。ただし、こちらも、[オンプレミスのAD DSを完全に置き換えるものではありません。](https://jpazureid.github.io/blog/azure-active-directory/azure-ad-ds-scenario/)

# ハイブリッドID

Azure IDにおけるユーザーIDの種類として、クラウド専用ID(Cloud-only identity)と、ハイブリッドID(Hybrid identity)があります。

- [クラウド専用ID](https://docs.microsoft.com/ja-jp/microsoft-365/enterprise/about-microsoft-365-identity?view=o365-worldwide): Azure AD テナントにのみ存在するID
- [ハイブリッドID](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-hybrid-identity): オンプレミスとAzure ADの共通のID

オンプレミスおよびクラウドの両方のアプリケーションへのアクセス権を必要とする場合は、ハイブリッドIDを使用します。

# Azure AD Connect

ハイブリッドIDを実装するには、[Azure AD Connect](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect)を使用します。

- オンプレミスのActive Directoryを、Azure ADに接続することができます。
- オンプレミスで稼働する、[ドメインに参加している Windows Server 2012 以降にインストールします](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-install-prerequisites)
- [無料で利用できます。](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect#license-requirements-for-using-azure-ad-connect)

# Azure AD Connectによる、オンプレミスとAzure ADのID連携方法

Azure AD Connectのセットアップ時に選択します。

- [パスワード ハッシュ同期(PHS)](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/tutorial-password-hash-sync) - ユーザーのオンプレミス AD パスワードのハッシュを Azure AD と同期させるサインイン方法。
- [パススルー認証(PTA)](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/tutorial-passthrough-authentication) - ユーザーがオンプレミスとクラウド内で同じパスワードを使用できるようにするサインイン方法。パスワードのハッシュをクラウドに配置したくない場合に利用します。
- [フェデレーション認証(AD FS)](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/choose-ad-authn#federated-authentication) - 別の認証システムに認証プロセスを引き継ぐ方法。スマートカード ベースの認証やサードパーティの多要素認証が必要な場合に利用します。

これらの選択肢から適切な選択を行うための[ドキュメントを利用できます。](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/choose-ad-authn)

# Azure ADのエディション

[Azure ADのエディションと価格](https://azure.microsoft.com/ja-jp/pricing/details/active-directory/)には、以下のものがあります。

- Free
- Office 365アプリ（Office 365、Microsoft 365サブスクリプションにて使用できる機能）
- Premium P1: ￥672 ユーザー/月
- Premium P2: ￥1,008 ユーザー/月

※[Basicは廃止されます。](https://www.google.com/search?q=azure+ad+basic+%E5%BB%83%E6%AD%A2)

Azure ADの[ユーザーまたはグループごとに、ライセンスを付与する必要があります。](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/license-users-groups)

# 試用

https://azure.microsoft.com/ja-jp/trial/get-started-active-directory/

試用版のアクティブ化を行うと、100 個の Azure Active Directory Premium ライセンスを取得できます。30 日間有効です。

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
- Windows 10、iOS、Android、[macOS](https://ja.wikipedia.org/wiki/MacOS)に対応します。
- 組織は、[条件付きアクセス](https://docs.microsoft.com/ja-jp/learn/modules/manage-device-identity-ad-join/2-what-is-device-identity)を設定して、特定の条件を満たす場合に、デバイスのアクセスを許可または禁止することができます。
- [Microsoft Intune](https://www.microsoft.com/ja-jp/microsoft-365/enterprise-mobility-security/microsoft-intune) などの Mobile Device Management (MDM) ツールを使用して、Azure AD 登録済みデバイスをセキュリティで保護し、制御することができます。 MDM では、ストレージの暗号化、パスワードの複雑さ、セキュリティ ソフトウェアの最新化などを強制できます。
  - 参考: Apple製品用のMDMとしては[Jamf（ジャムフ）](https://www.jamf.com/ja/)があります。[Azure ADと統合](https://docs.jamf.com/ja/jamf-protect/administrator-guide/Microsoft_Azure_AD_%E3%81%A8%E3%81%AE%E7%B5%B1%E5%90%88.html)することができます。

# 管理者による、ユーザーのパスワードのリセット

ユーザーが自分のパスワードを忘れてしまった場合、[管理者は、ユーザーのパスワードをリセットできます。](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-users-reset-password-azure-portal)

[管理者アカウントは、デフォルトで、セルフサービスのパスワード リセットが有効になっています](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-policy#administrator-reset-policy-differences)。一般ユーザーとは異なるルールが適用されます。

# セルフサービス パスワードリセット(SSPR)

[Azure AD のセルフサービス パスワード リセット](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-howitworks)

- SSPRを使用すると、ユーザーが自分のパスワードを忘れてしまった場合、管理者やヘルプ デスクが関与することなく、自分のパスワードをリセットすることができます。
- ユーザーは、画面の指示に従って、自分自身のロックを解除して、作業に戻ることができます。
- 組織のヘルプ デスクの問い合わせが減り、生産性の喪失も軽減されます。
- [SSPRの有効範囲](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/tutorial-enable-sspr#enable-self-service-password-reset)は、「なし」「選択済み（指定したグループ）」「すべて」の3種類から選ぶことができます。現在、Azure portal を使用して SSPR に対して有効にできる Azure AD グループは 1 つだけです。

[SSPRを使用するには、ライセンスの割り当てが必要です。](https://docs.microsoft.com/en-us/azure/active-directory/authentication/concept-sspr-licensing)

- [Azure AD Premium P1 or P2](https://azure.microsoft.com/ja-jp/pricing/details/active-directory/)
- Microsoft 365 Business Standard または Microsoft 365 Business Premium でも、[SSPRを利用できます](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-licensing)

ご参考：SSPRだけが必要な場合、[LogonBox](https://www.logonbox.com/en/)のようなSSPRソリューションを使用するという方法もあります。1000ユーザーの場合、LogonBoxのほうが97%安くなります。

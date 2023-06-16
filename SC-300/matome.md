# SC-300 まとめ

## Azure ADの基本的な機能

- [Azure Active Directory (Azure AD)](https://learn.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-whatis)
- [シングルサインオン](https://learn.microsoft.com/ja-jp/azure/active-directory/manage-apps/what-is-single-sign-on)
- [MFA](https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/concept-mfa-howitworks)
- [Microsoft Entra](https://learn.microsoft.com/ja-jp/entra/)
- [カスタムドメインの割り当て](https://learn.microsoft.com/ja-jp/azure/active-directory/fundamentals/add-custom-domain)
- [Azure ADの管理者ロール](https://learn.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference)
- [外部ID](https://learn.microsoft.com/ja-jp/azure/active-directory/external-identities/external-identities-overview)
  - [Azure AD B2B](https://learn.microsoft.com/ja-jp/azure/active-directory/external-identities/what-is-b2b)
  - [Azure AD B2C](https://learn.microsoft.com/ja-jp/azure/active-directory-b2c/overview)
- [パスワードレス認証](https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/concept-authentication-passwordless)
- [スマートロックアウト](https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/howto-password-smart-lockout)
- [セキュリティの既定値](https://learn.microsoft.com/ja-jp/azure/active-directory/fundamentals/concept-fundamentals-security-defaults)

## ハイブリッドID

- [Active Directory Domain Service (AD DS)](https://learn.microsoft.com/ja-jp/windows-server/identity/ad-ds/get-started/virtual-dc/active-directory-domain-services-overview)
- [Active Directory Federation Service (AD FS)](https://learn.microsoft.com/ja-jp/windows-server/identity/active-directory-federation-services)
- [Azure AD Connect](https://learn.microsoft.com/ja-jp/azure/active-directory/hybrid/connect/whatis-azure-ad-connect)
  - [パスワードハッシュ同期](https://learn.microsoft.com/ja-jp/azure/active-directory/hybrid/connect/whatis-phs)
  - [パススルー認証](https://learn.microsoft.com/ja-jp/azure/active-directory/hybrid/connect/how-to-connect-pta)
  - [フェデレーション](https://learn.microsoft.com/ja-jp/azure/active-directory/hybrid/connect/whatis-fed)
- [パスワードライトバック (P1)](https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/tutorial-enable-sspr-writeback)
- [アプリケーションプロキシ (P1 or P2)](https://learn.microsoft.com/ja-jp/azure/active-directory/app-proxy/what-is-application-proxy)

## Azure ADの高度な機能 (Premium P1/P2ライセンス)

- [管理単位 (P1)](https://learn.microsoft.com/ja-jp/azure/active-directory/roles/administrative-units)
- [会社のブランドの構成 (P1)](https://learn.microsoft.com/ja-jp/azure/active-directory/fundamentals/customize-branding)
- [セルフサービスパスワードリセット (P1)](https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-howitworks)
- [動的グループ (P1)](https://learn.microsoft.com/ja-jp/azure/active-directory/enterprise-users/groups-dynamic-membership)
- [条件付きアクセス (P1)](https://learn.microsoft.com/ja-jp/azure/active-directory/conditional-access/overview)
- [Identity Protection (P2)](https://learn.microsoft.com/ja-jp/azure/active-directory/identity-protection/overview-identity-protection)
- [Privileged Identity Management (P2)](https://learn.microsoft.com/ja-jp/azure/active-directory/privileged-identity-management/pim-configure)
- [Azure ADアクセスレビュー (P2)](https://learn.microsoft.com/ja-jp/azure/active-directory/governance/access-reviews-overview)
- [エンタイトルメント管理 (P2)](https://learn.microsoft.com/ja-jp/azure/active-directory/governance/entitlement-management-overview)

## エンタープライズアプリの追加

- [エンタープライズアプリケーションの追加](https://learn.microsoft.com/ja-jp/azure/active-directory/manage-apps/what-is-application-management)
- [Azure ADプロビジョニングサービス](https://learn.microsoft.com/ja-jp/azure/active-directory/app-provisioning/how-provisioning-works)

## アプリの登録（独自のアプリの作成）

- [Microsoft ID プラットフォーム](https://learn.microsoft.com/ja-jp/azure/active-directory/develop/v2-overview)
- [アプリの登録](https://learn.microsoft.com/ja-jp/graph/auth-register-app-v2)
- [Microsoft Authentication Library (MSAL)](https://learn.microsoft.com/ja-jp/azure/active-directory/develop/msal-overview)
- [Microsoft Graph](https://learn.microsoft.com/ja-jp/graph/overview)
- [同意のフレームワーク](https://learn.microsoft.com/ja-jp/azure/active-directory/develop/application-consent-experience)

## Azure のセキュリティ

- [仮想マシン(Virtual Machine)でのAzure AD認証](https://learn.microsoft.com/ja-jp/azure/active-directory/devices/howto-vm-sign-in-azure-ad-windows)
- Azureの認証
  - [ユーザー](https://learn.microsoft.com/ja-jp/azure/active-directory/fundamentals/add-users-azure-active-directory)
  - [グループ](https://learn.microsoft.com/ja-jp/azure/active-directory/fundamentals/how-to-manage-groups)
  - [サービスプリンシパル](https://learn.microsoft.com/ja-jp/azure/active-directory/develop/howto-create-service-principal-portal)
  - [マネージドID](https://learn.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/overview)
- [Azure RBAC（ロール）](https://learn.microsoft.com/ja-jp/azure/role-based-access-control/overview)
- [Azure Key Vault](https://learn.microsoft.com/ja-jp/azure/key-vault/general/overview)
- [Azure Monitor](https://learn.microsoft.com/ja-jp/azure/azure-monitor/overview)
  - [メトリック](https://learn.microsoft.com/ja-jp/azure/azure-monitor/essentials/data-platform-metrics)
  - [ログ](https://learn.microsoft.com/ja-jp/azure/azure-monitor/logs/data-platform-logs)
- [Log Analytics](https://learn.microsoft.com/ja-jp/azure/azure-monitor/logs/log-analytics-workspace-overview)
- [Kusto Query Language (KQL)](https://learn.microsoft.com/ja-jp/azure/data-explorer/kusto/query/)

## Microsoft のセキュリティ製品

- [Microsoft Defender for Cloud Apps](https://learn.microsoft.com/ja-jp/defender-cloud-apps/)
  - 旧 Microsoft Cloud App Security（MCAS）
- [Microsoft Defender for Cloud](https://learn.microsoft.com/ja-jp/azure/defender-for-cloud/defender-for-cloud-introduction)
  - 旧 Azure Security Center
- [Microsoft Sentinel](https://learn.microsoft.com/ja-jp/azure/sentinel/overview)
  - 旧 Azure Sentinel
- [Microsoft Security Copilot](https://www.microsoft.com/ja-jp/security/business/ai-machine-learning/microsoft-security-copilot)
  - 現在プレビュー中

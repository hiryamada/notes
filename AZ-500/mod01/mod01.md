# Azure ADと関連サービス

解説:

[モジュール1-1(Azure Active Directory)](mod01-01-aad.md)で解説。

公式ドキュメントへのリンクとライセンス:

クラウド(Azure):
- [Azure Active Directory (Azure AD)](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-whatis)
- [Azure Active Directory Domain Services (AAD DS)](https://docs.microsoft.com/ja-jp/azure/active-directory-domain-services/overview)

オンプレミス:
- [Active Directory Domain Services (AD DS)](https://docs.microsoft.com/ja-jp/windows-server/identity/ad-ds/ad-ds-getting-started)
- [Active Directory Federation Services (AD FS)](https://docs.microsoft.com/ja-jp/windows-server/identity/ad-fs/ad-fs-overview)

# ハイブリッドID

解説:

[モジュール1-2(ハイブリッドID)](mod01-02-hybrid-id.md)で解説。

公式ドキュメントへのリンクとライセンス:

- [Azure AD Connect](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect): オンプレミスAD DSとAzure ADの同期。ライセンス: Free。500000個を超えるオブジェクト同期の場合はPremium (P1, P2)
- [Azure AD Connect Health](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/whatis-azure-ad-connect#why-use-azure-ad-connect-health) - Azure AD Connect, AD DS, AD FSなどを監視。ライセンス: P1(最初のエージェントに1ライセンス、追加のエージェントごとに25ライセンス)

# Azure ADに含まれる機能

解説:

[モジュール1-3(Azure AD Identity Protection)](mod01-03-idp.md)、[アクセスレビュー](../../AZ-303/mod10-02-access-review.md)、[モジュール1-4(Azure AD Privileged Identity Management)](mod01-04-pim.md)で解説。

公式ドキュメントへのリンクとライセンス:

[Azure AD Identity Protection](https://docs.microsoft.com/ja-jp/azure/active-directory/identity-protection/overview-identity-protection): 不審なサインインなどを検出。ライセンス: P2が必要だが、Free, Microsoft 365 Apps, P1でもセキュリティレポート（限定的な情報）が利用可能。

[Azure AD Multi-Factor Authentication](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-mfa-howitworks): 多要素認証。ライセンス: Free(セキュリティの既定値群), P1(条件付きアクセス), P2(リスクベースの条件付きアクセス)など。

[Azure AD 条件付きアクセス](https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/overview): ユーザー、アプリ、端末などの条件により、アクセスを許可、ブロック、追加の認証を要求。ライセンス: P1

[Azure AD アクセス レビュー](https://docs.microsoft.com/ja-jp/azure/active-directory/governance/access-reviews-overview): ユーザーへのロール割り当てを定期的にレビューし、不要な割り当てを削除。ライセンス: P2

[Azure AD Privileged Identity Management (PIM)](https://docs.microsoft.com/ja-jp/azure/active-directory/privileged-identity-management/pim-configure): 時間/承認ベースで、特権アクセスのロールをJIT(ジャストインタイム)で割り当て。ライセンス: P2

# エンタープライズ ガバナンス

※ここは、Azure ADではなくAzureサブスクリプション側の管理の話題。

[モジュール1-5(エンタープライズ ガバナンス)](mod01-05-enterprise-governance.md)で解説。

- 共同責任モデル
- スコープ
- Azure Policy
- Azure RBACロール
- リソースロック
- Azure Blueprints
- Azure サブスクリプション管理


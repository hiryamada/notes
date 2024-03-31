# Entra IDのライセンス（エディション/価格プラン）

[Azure ADのプランと価格（公式サイト）](https://www.microsoft.com/ja-jp/security/business/identity-access/azure-active-directory-pricing)

■4つのエディション

- Azure AD Free
  - 無料
  - Azure ADの基本的な機能が利用可能
    - シングルサインオン
    - MFA
- Office 365
  - Office 365 E1、E3、E5、F1、F3 サブスクリプションに含まれる
  - [Office 365アプリのIDとアクセスの管理](https://licensecounter.jp/microsoft365/blog/2019/11/aad-premium.html)
- Azure AD Premium P1
  - 有料(650 円 ユーザー/月)
  - [セルフサービス パスワード リセット (SSPR)](https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-howitworks)
  - [動的グループ](https://learn.microsoft.com/ja-jp/azure/active-directory/enterprise-users/groups-dynamic-membership)
  - [管理単位](https://learn.microsoft.com/ja-jp/azure/active-directory/roles/administrative-units)(の管理者)
  - [Azure AD Connect Health](https://learn.microsoft.com/ja-jp/azure/active-directory/hybrid/reference-connect-health-faq)
- Azure AD Premium P2
  - 有料(980 円 ユーザー/月)
  - [アクセスレビュー](https://learn.microsoft.com/ja-jp/azure/active-directory/governance/access-reviews-overview)
  - [Privileged Identity Management (PIM)](https://learn.microsoft.com/ja-jp/azure/active-directory/privileged-identity-management/pim-configure)
  - [Identity Protection](https://learn.microsoft.com/ja-jp/azure/active-directory/identity-protection/overview-identity-protection)

■ポイント:

- 各ライセンスに含まれる機能は Azure AD Free ⊂ Office 365 ⊂ Premium P1 ⊂ Premium P2 となっている。
  - P2を割り当てたユーザーはFree, Office 365, P1の機能も利用できる
- ライセンスは組織単位ではなくユーザー単位での割り当てとなる。
  - たとえば 100 人の組織の場合、Azure ADの高度な機能を必要とする 50人に P2 を割り当て、残りの50人には P1 や Free を割り当てる、といった運用が可能。
- Azure ADは、AzureのID管理だけではなく、Office 365（Microsoft 365）のID管理でも利用されるID基盤である


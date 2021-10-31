# ID およびアクセス管理のベスト プラクティス

https://docs.microsoft.com/ja-jp/security/compass/identity

■単一のエンタープライズ ディレクトリ（＝Azure AD）を使用する

https://docs.microsoft.com/ja-jp/security/compass/identity#a-single-enterprise-directory

組織で、単一の（1つの）Azure ADテナントを使用する。

組織でテナントを複数使用する（例：部署ごと）と、テナントレベルのセキュリティ対策を部署ごとに実施する必要がある。非常に手間がかかり、対策の漏れ・抜けが発生するリスクが高まる。

■オンプレミスとクラウド間のIDの同期を行う

https://docs.microsoft.com/ja-jp/security/compass/identity#synchronized-identity-systems

オンプレミスのAD DSと同期を行う。

```
Azure AD
↑同期
オンプレミスAD DS＋Azure AD Connect
```

組織のユーザーは、単一のIDとパスワードを使用して、オンプレミスとクラウド両方のアプリケーションを利用することができる。（ハイブリッドID）

■Azure ADのレガシ認証をブロックする

https://docs.microsoft.com/ja-jp/security/compass/identity#block-legacy-authentication

https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/block-legacy-authentication

https://jpazureid.github.io/blog/azure-active-directory/new-tools-to-block-legacy-auth/

認証の分類
- [レガシ(legacy)認証](https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/block-legacy-authentication#scenario-description)
  - 基本(basic)認証を使用するプロトコル。
  - 通常、第 2 要素の認証はどれも適用できない。
- [先進(modern)認証](https://docs.microsoft.com/ja-jp/microsoft-365/enterprise/hybrid-modern-auth-overview?view=o365-worldwide)（「最新の認証」とも）
  - より安全なユーザー認証と承認を提供する ID 管理の方法
  - 認証
    - MFA, スマートカード、クライアント証明書ベース認証など。
  - 承認
    - OAuthを使用
  - 条件付きアクセス
    - Azure ADの条件付きアクセス等を使用

レガシ認証を使用するアプリ:

- 従来の Microsoft Office アプリ
- POP、IMAP、SMTP などの電子メール プロトコルを使用するアプリ
- [詳細なリスト](https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/block-legacy-authentication#legacy-authentication-protocols)

レガシ認証がなぜ危険なのか:

https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/block-legacy-authentication

>99% を超えるパスワード スプレー攻撃がレガシ認証プロトコルを使用します

>97% を超える資格情報を含めた攻撃がレガシ認証を使用します

>レガシ認証を無効にしている組織の Azure AD アカウントは、レガシ認証が有効になっている場合よりも侵害が 67% 低下します

レガシ認証のブロック:

https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/block-legacy-authentication#block-legacy-authentication

https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/howto-conditional-access-policy-block-legacy

レガシ認証を使用するクライアントアクセスをブロックする「条件付きアクセスポリシー」を設定する。

レポートモード:

https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/howto-conditional-access-insights-reporting#configure-a-conditional-access-policy-in-report-only-mode

■オンプレミスの高い特権を持つ管理者アカウントを、クラウド ID プロバイダーに同期しない

https://docs.microsoft.com/ja-jp/security/compass/identity#no-on-premises-admin-accounts-in-cloud-identity-providers

Azure AD Connectのデフォルト設定をカスタマイズしていなければ問題ない。

Azure AD Connectのデフォルト設定で同期されないユーザーオブジェクト: 組み込みの管理者アカウントなど。

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/concept-azure-ad-connect-sync-default-configuration#out-of-box-rules-from-on-premises-to-azure-ad

■最新のパスワード保護を使用する

https://docs.microsoft.com/ja-jp/security/compass/identity#modern-password-protection


- 従来のパスワード対策(現代では不十分)
  - 複数の文字の種類を組み合わせる（大文字、小文字、数字、記号）
  - 所定の文字数以上にする
  - [パスワードに有効期限を設定する](https://docs.microsoft.com/ja-jp/microsoft-365/admin/manage/set-password-expiration-policy?view=o365-worldwide)
    - [※最近の研究では、強制的なパスワードの変更はメリットよりデメリットの方が大きいことが強く示唆されている](https://docs.microsoft.com/ja-jp/microsoft-365/admin/manage/set-password-expiration-policy?view=o365-worldwide#before-you-begin)
- 最新のパスワード保護
  - パスワードレスに移行できる場合
    - パスワードレス認証を使用する(Going Passwordless)
      - Microsoft Authenticatorアプリ、Windows Helloなどを利用
      - Azure AD
        - [概要](https://www.microsoft.com/ja-jp/security/business/identity-access-management/passwordless-authentication)
        - [ドキュメント](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-authentication-passwordless)
      - Microsoft Account
        - [概要](https://news.microsoft.com/ja-jp/2021/09/16/210916-the-passwordless-future-is-here-for-your-microsoft-account/)
        - [ドキュメント](https://support.microsoft.com/ja-jp/account-billing/microsoft-%E3%82%A2%E3%82%AB%E3%82%A6%E3%83%B3%E3%83%88%E3%81%A7%E3%83%91%E3%82%B9%E3%83%AF%E3%83%BC%E3%83%89%E3%82%92%E4%BD%BF%E7%94%A8%E3%81%97%E3%81%AA%E3%81%84%E6%96%B9%E6%B3%95-674ce301-3574-4387-a93d-916751764c43)
  - パスワードレスに移行できない場合
    - Azure AD Connectで、パスワードハッシュ同期を使用する。
    - Azure AD Identity Protectionで、リスク評価を使用する

■クロスプラットフォームの資格情報管理を使用する

https://docs.microsoft.com/ja-jp/security/compass/identity#cross-platform-credential-management

すべてのプラットフォームの認証に、単一のIDプロバイダー(=Azure AD)を使用する

複数のIDプロバイダーを組み合わせて利用すると、IDの管理とセキュティ対策が難しくなる。

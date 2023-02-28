# OATH

■OATHとは？

OATH（Initiative for Open AuTHentication）オース、認証にかかわる業界団体、または規格。

[OATH規格に準拠したさまざまな製品がある。](https://www.google.com/search?q=OATH%E6%BA%96%E6%8B%A0)

参考: https://en.wikipedia.org/wiki/Initiative_for_Open_Authentication

- オープン認証への取り組み
- 強力な認証の採用を促進するために、オープン スタンダードを使用してオープンリファレンス アーキテクチャを開発するための業界全体のコラボレーション
- 30 近くの調整メンバーと貢献メンバーがあり、コストの削減と機能の簡素化を目的として、さまざまな認証テクノロジの標準を提案している。

参考:
- https://atmarkit.itmedia.co.jp/fsecurity/rensai/oath01/oath01.html
- https://atmarkit.itmedia.co.jp/fsecurity/rensai/oath02/oath01.html

- 既存の認証技術であるユーザー名／パスワードには限界がある
- より強力な認証システムが必要である
- 「オープン」「標準化」および「相互運用性」を認証ソリューション業界内で確立することにより健全なエコシステムを創造することを目的としてOATHが2004年2月に発足した
- 認証に関連する業界をまたいだコラボレーションを推進する組織
- ワンタイムパスワード（OTP）、PKI、SIMカード（Subscriber Identity Module：加入者識別モジュール）を組み合わせた、オープンで低コストの多元的な認証デバイスの仕様を、ベンダからメーカーまであらゆる関係者に広めることを目的としている

※[oath ＝ 誓い、宣誓](https://ejje.weblio.jp/content/oath)

※[OAuth（オーオース）](https://ja.wikipedia.org/wiki/OAuth)とは別のもの。

■OATH ハードウェア トークン

Azureでの設定/使用例（くらう道）:
https://www.cloudou.net/azure-active-directory/mfa005/


https://www.idaten.ne.jp/portal/page/out/dsf2/C1569_maker.pdf


[キーホルダータイプ・カードタイプ(SafeNet OTP)](https://cpl.thalesgroup.com/ja/access-management/authenticators/one-time-password-otp)

[USBタイプ(Yubico)](https://www.yubico.com/yubikey/?lang=ja)

Azure AD OTPトークン（飛天ジャパン株式会社）
https://www.idaten.ne.jp/portal/page/out/dsf2/C1569_maker.pdf

■OATH ソフトウェア トークン


■ OATH 確認コード

Authenticator アプリを使用して生成することができる。




■OTP / TOTP / HOTP

参考: https://www.onelogin.com/jp-ja/learn/otp-totp-hotp

参考: https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/concept-authentication-oath-tokens

- OTP (One-Time Password)
  - 一度だけしか使用できないパスワード。
  - 認証のたびに異なるパスワードを使用する。
  - MFAの形式の1つ。
  - HOTPとTOTPという2つの種類がある。
- TOTP (Time-based One Time Password)
  - 時間ベースのOTP
  -  Azure AD ではサポートされている
- HOTP (HMAC-based One Time Password)
  - カウンターベースのOTP
  -  Azure AD ではサポートされていない


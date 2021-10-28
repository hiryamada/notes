# Azure AD MFA

■MFAとはなにか？

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-mfa-howitworks

```
ユーザー名・パスワードによる認証
＋
スマートフォンのアプリによる検証（通知＋指紋認証）など
```

■Azure AD MFAでは、どのような検証方法が利用できるのか？

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-mfa-howitworks#available-verification-methods

- Microsoft Authenticator アプリ
- OATH ハードウェア トークン (プレビュー, [2018/10/23～](https://techcommunity.microsoft.com/t5/azure-active-directory-identity/hardware-oath-tokens-in-azure-mfa-in-the-cloud-are-now-available/ba-p/276466))
- OATH ソフトウェア トークン
- SMS
- 音声通話

参考: Azure AD ハードウェアトークンによるMFAの設定例
https://www.cloudou.net/azure-active-directory/mfa005/


■MFAはどのようにして有効化できるのか？

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-mfa-licensing#compare-multi-factor-authentication-policies

3パターンの有効化方法がある。(1), (2), (3) **いずれか**を利用する。

- (1)セキュリティの規定値群（[デフォルトで有効](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/concept-fundamentals-security-defaults#availability)）
  - (2)が使えない場合に使用する
  - (3)は有効にしたり適用したりしてはいけない
  - 「Microsoft Authenticator」と「ソフトウェア トークン」を利用可能
- (2)条件付きアクセス（推奨）
  - ライセンスが必要
  - (1)よりも柔軟な運用が可能（ユーザーにとって便利）
  - (1)は無効化する
  - (3)は有効にしたり適用したりしてはいけない
  - すべての検証方法を利用可能
- (3)ユーザーごとのMFAの有効化（非推奨）
  - [(1)も(2)も使用しない場合に(3)を使用する](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/howto-mfa-userstates)
  - **ユーザーごとに有効化の設定が必要**
  - すべての検証方法を利用可能

■(1)セキュリティの既定値群

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/concept-fundamentals-security-defaults

概要:
- Microsoft によって推奨されている基本的な ID セキュリティ機構のセット。
- 有効にすると、これらの推奨事項が組織内で自動的に適用される。
- 管理者とユーザーは、一般的な ID 関連の攻撃からより良く保護されるようになる。
- ライセンス不要。

テナントでの設定方法:

- Azure AD＞プロパティ＞セキュリティの既定値群の管理＞有効化（「はい」「いいえ」）
- [2019 年 10 月 22 日以降に作成されたテナントの場合、セキュリティの既定値群はテナントで有効になっている](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/concept-fundamentals-security-defaults#availability)

エンドユーザー（Azure ADの各ユーザー）のセットアップ手順:

- [動画（日本語字幕あり, 2分26秒）および手順書](https://docs.microsoft.com/ja-jp/microsoft-365/business-video/set-up-mfa?view=o365-worldwide)
- 「スマートフォン」 と 「Microsoft Authenticator」を使用する

■(2)条件付きアクセス

https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/overview

条件に応じて、MFAを要求するように設定できる。

(1)(3)のように、常にMFAが要求されなくなるので、ユーザーにとって利便性が高い。

例: 
- あやしいサインインの場合にMFAを要求
- 重要なアプリケーションにサインインする場合のみMFAを要求
- Azure portalやコマンドを使用したAzureの操作を行う場合にMFAを要求
- 社内のIPアドレスからのサインインの際はMFAを省略

使用できる条件（シグナル）:

- ユーザー、グループ、Azure ADの管理者
- アクセスするアプリ
  - 「[Microsoft Azure Management](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/conditional-access-azure-management)」: Azure portal、Azure PowerShell、Azure CLIなど（Azureの管理エンドポイント）
- IPアドレス
- デバイス
- サインイン リスク(P2)

条件付きアクセスを使用する場合:
- [セキュリティの既定値群は「無効」に設定する。](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/concept-fundamentals-security-defaults#disabling-security-defaults)
- [「ユーザーごとのMFA」は有効にしたり、適用したりしない。](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/howto-mfa-userstates)

ライセンス: Azure AD Premium P1 または P2 が必要。

- Premium P1: 
  - [条件付きアクセス](https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/overview)
- Premium P2: 
  - [サインイン リスクベースの条件付きアクセス](https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/howto-conditional-access-policy-risk)
  - サインイン リスク: 各サインインにおける不正の可能性。匿名IPアドレスからのサインインなど。
  - 「MFAを要求する」または「サインインをブロックする」ことができる
  - このポリシーを構成できる場所は 2 つ
    - [条件付きアクセス ポリシーを有効にする](https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/howto-conditional-access-policy-risk#enable-with-conditional-access-policy)
    - [Identity Protection を有効にする](https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/howto-conditional-access-policy-risk#enable-through-identity-protection)

■(3)ユーザーごとのMFA（非推奨）

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/howto-mfa-userstates

「(1)セキュリティの既定値群」も「(2)条件付きアクセス」も使用しない場合に、これを使用する。

ユーザーごとの Azure AD MFA を、必要に応じて各アカウントで有効にすることができる。

基本的に、サインインするたびに多要素認証が実行される。

設定方法（MFA管理UIへの移動）:
Azure AD ＞ユーザー＞すべてのユーザー＞Multi-Factor Authentication

ユーザーの状態:

- 無効: MFA無効. デフォルト
- Enabled: MFAの登録を求める。
- 強制: Enabledで、MFAの登録が完了すると、自動的にこの状態となる。


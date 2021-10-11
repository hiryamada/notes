# パスワードの変更

https://support.microsoft.com/ja-jp/account-billing/%E4%BB%95%E4%BA%8B%E7%94%A8%E3%81%BE%E3%81%9F%E3%81%AF%E5%AD%A6%E6%A0%A1%E7%94%A8%E3%82%A2%E3%82%AB%E3%82%A6%E3%83%B3%E3%83%88%E3%81%AE%E3%83%91%E3%82%B9%E3%83%AF%E3%83%BC%E3%83%89%E3%82%92%E5%A4%89%E6%9B%B4%E3%81%99%E3%82%8B-97fced88-e0e7-4d7b-a9d3-936a3dcbd569

Azure ADの一般ユーザーは、「マイ アカウント」（ https://myaccount.microsoft.com/ ）の「パスワードの変更」を使用して、自分のパスワードを変更することができる。

このとき、「古いパスワード」（変更前のパスワード）の入力が必要となる。

※トレーニングで使用している「Microsoftアカウント」のユーザーは、「Microsoftアカウント」（ https://account.microsoft.com/ ）の「パスワードを変更する」を使用して、自分のパスワードを変更することができる。

[ライセンス](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-licensing#compare-editions-and-features): 不要(Free)

# 管理者による、一般ユーザーのパスワードのリセット

https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-users-reset-password-azure-portal

Azure ADの一般ユーザーがパスワードを忘れてしまった場合、Azure ADの管理者は、Azure AD＞ユーザー で、ユーザーのチェックボックスを選択し、「パスワードのリセット」をクリックすることで、そのユーザーのパスワードをリセットすることができる。

リセットを行うと、Azure ADポータル側で一時パスワードが発行される。管理者はその一時パスワードを一般ユーザーに伝達する。

一般ユーザーが、一時パスワードを使用してサインインすると、すぐに、別のパスワードの変更が求められる。

ライセンス: 不要(Free)

# セルフサービス パスワードリセット（SSPR）

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-howitworks

SSPRを有効化すると、Azure ADの一般ユーザーは、管理者やヘルプ デスクが関与することなく、自分のパスワードを変更またはリセットすることができる。

[ライセンス](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-licensing#compare-editions-and-features):

以下のいずれかが必要。Freeは不可。

- Microsoft 365 Business Standard
- Microsoft 365 Business Premium
- Azure AD Premium P1
- Azure AD Premium P2

# セルフサービス パスワードリセット（SSPR）の設定

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/tutorial-enable-sspr

[設定手順例PDF](pdf/mod02/SSPR.pdf)

■管理者作業: SSPRの有効化

Azure ADの管理者は、Azure AD＞ユーザー＞パスワード リセット＞プロパティ で、SSPRを有効化することができる。

- なし: このテナントではSSPRを使用しない。デフォルト。
- 選択済み: Azure ADのグループ（セキュリティグループ）を選択。そのグループのユーザーに対し、SSPRを使用可能とする。ここでは1つのグループしか選択できない（が、グループ自体は入れ子にすることができるので、ここで、複数のグループを束ねた親のグループを指定することは可能）
- すべて: このテナントのすべてのユーザーに対し、SSPRを使用可能とする。

■管理者作業: SSPRの認証方式の設定

Azure ADの管理者は、Azure AD＞ユーザー＞パスワード リセット＞認証方法 で、リセットするために必要な方法の数（1または2）、ユーザーが使用できる方法（モバイルアプリコード、電子メール、携帯電話（SMS）、会社電話、秘密の質問など）を選択する。

■一般ユーザー: 事前設定

SSPRの対象となった一般ユーザーは、サインイン時に、リセットに必要な情報（Microsoft Authenticator, 電話など）を設定する。

■一般ユーザーのSSPRの実行

SSPRの対象となった一般ユーザーが、自分のパスワードがわからなくなってしまった場合。

- サインイン画面で「パスワードを忘れてしまった場合」をクリックするか、「Microsoft Online パスワード リセット」（https://passwordreset.microsoftonline.com/ または https://aka.ms/sspr）にアクセスする。
- リセットに必要な情報（Microsoft Authenticatorに表示されるコードや、事前に登録した電話番号にSMSで送信されてくるコードなど）を入力する。
- 新しいパスワードをセットする。

以上の操作により、一般ユーザーは自分のパスワードをリセットすることができる。

# 管理者のSSPR

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-policy#administrator-reset-policy-differences

- 既定で、管理者アカウントはSSPRが有効になっている。
- [Set-MsolCompanySettings コマンド](https://docs.microsoft.com/ja-jp/powershell/module/msonline/set-msolcompanysettings?view=azureadps-1.0)を使用して、管理者アカウントに対する SSPR の使用を無効にすることができる。
  - `-SelfServePasswordResetEnabled $False`

# パスワード ライトバック

解説
https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-writeback

チュートリアル
https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/tutorial-enable-sspr-writeback

トラブルシュート
https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/troubleshoot-sspr-writeback

「パスワード ライトバック」を使用すると、Azure AD 側でSSPRでパスワードを変更した場合に、そのパスワードをオンプレミスの AD DS 環境に同期することができる。

- パスワードハッシュ同期（PHS）, パススルー認証（PTA）, フェデレーションのいずれでも利用できる。
- オンプレミスの AD DS パスワード ポリシーの強制
  - ユーザーが自分のパスワードをリセットすると、パスワードがオンプレミスの AD DS ポリシーに準拠していることが確認されてから、そのディレクトリにコミットされる。
- ゼロ遅延フィードバック
  - ライトバックは同期的に実行される（遅延はない）。
  - ユーザーのパスワードがポリシーに合わなかった場合や、何らかの理由でリセットまたは変更できなかった場合は、すぐにユーザーに通知される。
- この機能を利用するために、オンプレミス側で、ファイアウォールで受信ポートを開く必要はない。
  - 基盤の通信チャネルとして Azure Service Bus リレー（[現 Azure Relay](https://docs.microsoft.com/ja-jp/azure/azure-relay/relay-faq#service-bus-relay---------------)）を使用



[ライセンス](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-licensing#compare-editions-and-features):

以下のいずれかが必要。Free, Microsoft 365 Business Standardは不可。

- Microsoft 365 Business Premium
- Azure AD Premium P1
- Azure AD Premium P2


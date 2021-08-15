# パスワードの変更

Azure ADの一般ユーザーは、「マイ アカウント」ぺージ（https://myaccount.microsoft.com/）の「パスワードの変更」を使用して、自分のパスワードを変更することができる。

このとき、「古いパスワード」（変更前のパスワード）の入力が必要となる。

# パスワードのリセット

Azure ADの一般ユーザーがパスワードを忘れてしまった場合、Azure ADの管理者は、Azure AD＞ユーザー で、ユーザーのチェックボックスを選択し、「パスワードのリセット」をクリックすることで、そのユーザーのパスワードをリセットすることができる。

リセットを行うと、一時パスワードが発行される。管理者はその一時パスワードを一般ユーザーに伝達する。

一般ユーザーが、一時パスワードを使用してサインインすると、すぐに、別のパスワードの変更が求められる。

# 「セルフサービス パスワードリセット」（SSPR）

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-howitworks


# 一般ユーザーのSSPR

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

以上の操作により、自分のパスワードをリセットすることができる。

# 管理者のSSPR

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-policy#administrator-reset-policy-differences

- 既定で、管理者アカウントはSSPRが有効になっている。
- Set-MsolCompanySettings コマンドを使用して、管理者アカウントに対する SSPR の使用を無効にすることができる。

# パスワード ライトバック

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/tutorial-enable-sspr-writeback

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-writeback

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/troubleshoot-sspr-writeback

パスワード ライトバックを使用すると、Azure AD 側でパスワードを変更した場合に、そのパスワードをオンプレミスの AD DS 環境に同期することができる。

- ライセンス: Premium P1（以上）が必要。
- PHS, PTA, Fedどれでも利用できる。
- 遅延はない（同期操作）
- オンプレミス側で、受信のために、ファイアウォールに穴を開ける必要はない。

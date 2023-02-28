# Azure Active Directory スマート ロックアウト

https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/howto-password-smart-lockout

- 悪意のあるユーザーのロックアウトを支援
- 攻撃者はロックアウトされる一方、組織のユーザーは自分のアカウントへのアクセスを継続できる


■よくわかるアカウント ロックアウトとよくある質問

by Azureサポートチーム
https://jpazureid.github.io/blog/azure-active-directory/comprehend-account-lockout/

- Azure AD では総当たり攻撃などを防ぐために、パスワードを一定の回数連続して間違えると、しばらくの間アカウントをロックする。

■概要

参考: https://jpazureid.github.io/blog/azure-active-directory/password-sprey-attack/

- パスワード スプレー攻撃では、攻撃者が多くの人が設定するような一般的なパスワードで、複数の異なるアカウントに対してログインを試行することで、パスワードで保護されたリソースにアクセスを試みます
- スマート ロックアウトを使用して、正当と思われるユーザーからのサインイン試行と攻撃者と思われるユーザーからのサインイン試行を区別します。正当なユーザーがアカウントを使用できるようにしながら、攻撃者をロックアウトすることができます。これにより、ユーザーへのサービス拒否が防止され、繰り返しのパスワードスプレー攻撃が阻止されます。
- Azure AD に対してのすべてのサインイン、 Microsoft アカウントを利用したすべてのサインインについて、ライセンスのレベルによらず、対象とします。

■しくみ

- サインインが 10 回 失敗すると、サインイン試行ができないよう 1 分間アカウントがロックされる
- 後続のサインインの試行が失敗するたびに、アカウントは再度ロックされる
- 最初は 1 分間、後続の試行ではより長い時間ロックされる

■Azure ADでのスマートロックアウトの設定とテスト

https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/howto-password-smart-lockout#manage-azure-ad-smart-lockout-values


# シングル サインオン

■Azure AD ConnectのシームレスSSO（sSSO）

https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sso

- ユーザーが企業ネットワークに接続される会社のデバイスを使用するときに、自動的にサインインを行う仕組み。
- ユーザーは Azure AD にサインインするためにパスワードを入力する必要がなくなる
  - 通常はユーザー名も入力する必要がない
- ユーザーは、オンプレミスとクラウドベースの両方のアプリケーションに自動的にサインインすることができる。
- Windows 10 + Microsoft Edge, Mac OS X + Safari 等、[さまざまなOS・ブラウザーの組み合わせをサポート](https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sso#feature-highlights)
- 無料で利用できる

■「ハイブリッドID」と「sSSO」の関係

- ハイブリッドID(sSSOなし)
  - オンプレミスとクラウドの認証に同じIDを利用できる
  - パスワード入力は必要
- ハイブリッドID(sSSOあり)
  - オンプレミスとクラウドの認証に同じIDを利用できる
  - オンプレミスAD DSに参加しているデバイスを利用
  - パスワード入力が不要

■sSSOが使用できる同期方式

- パスワードハッシュ同期(PHS) または パススルー同期(PTA)と組み合わせて利用できる
- 「フェデレーション」には適用できない
  - 「フェデレーション」ではAD FSサーバーによるSSOを利用

SSO（sSSO）の利用パターン:

- PHS + sSSO
- PTA + sSSO
- フェデレーション + AD FSのSSO

■設定方法

- Azure AD Connectインストール中に、「Enable Single Sign On」（シングル サインオンを有効にする）にチェックを入れて有効化する。
- Active Directory のグループ ポリシーを利用して、対象ユーザーを選択する


具体的な設定方法:
https://docs.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sso-quick-start

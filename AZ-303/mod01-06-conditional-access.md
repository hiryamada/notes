
# Azure AD 条件付きアクセス

https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/overview

■条件付きアクセスとは？
    
ユーザーがリソースにアクセスする場合に、特定のアクションを完了する必要があるように設定することができる。

条件によって、必要な場合は適切なアクセス制御を適用して組織のセキュリティを維持し、必要でない場合はユーザーの邪魔にならないようにすることができる。

■Azure portalからのアクセス

※Azure AD Premiumライセンスの試用版をテナントでアクティブ化しておく

Azure AD＞セキュリティ＞条件付きアクセス

「条件付きアクセスポリシー」を作成して、テナントに適用することができる。

■ポリシー作成例

- （割り当て）「すべてのユーザー」 が
- （クラウド アプリまたは操作）「Office 365」 に
- （条件）「iOS」または「Androidデバイス」 を使用してアクセスする場合に
- （アクセス制御の「コントロール」）「多要素認証(MFA)を要求」 した上で
- （アクセス制御）アクセスを「許可」する

■ネームド ロケーション（Named location）

https://docs.microsoft.com/ja-jp/azure/active-directory/conditional-access/location-condition#named-locations

ユーザーのアクセス元の「国」や「IPアドレス範囲」に、わかりやすい名前をつける機能。

つけた名前は、ポリシーの「条件」の「場所」で利用することができる。

- 「国の場所」（Countries location）
  - 1つ～複数の国（「日本」「中国」など）を選択して、名前をつける機能。
  - アクセス元の国の特定には、「アクセス元のIPアドレス」や、「GPS」（モバイル デバイスにMicrosoft Authenticatorアプリをインストールする）が使用される
- 「IP範囲の場所」（IP ranges location）
  - パブリックのIPアドレス範囲を指定して、名前をつける

■信頼できるIP

https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/howto-mfa-mfasettings#trusted-ips

Azure AD MFA の 「信頼できる IP」機能を使用すると、定義された IP アドレス範囲からサインインするユーザーに対する多要素認証がバイパス（迂回）される。

会社のイントラネットなど、「安全と判断されるIPアドレス」から、Azure ADにサインインする場合に、MFAのチェックを省略することができる。


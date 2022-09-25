
■一時アクセスパス (Temporary Access Pass, TAP)

ドキュメント
https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/howto-authentication-temporary-access-pass

2022/6/22 一般提供開始
https://techcommunity.microsoft.com/t5/microsoft-entra-azure-ad-blog/secure-authentication-method-provisioning-with-temporary-access/ba-p/3290631

（日本語訳）
https://jpazureid.github.io/blog/azure-active-directory/secure-authentication-method-provisioning-with-temporary-access/

一時アクセスパス は時間制限付きパスコードで、ユーザーがパスワードレスの認証方法を登録し、パスワードを使用せずともアカウントへのアクセスを回復するために使用できるもの。
一時アクセスパス を使用することで、（一時的な）パスワードを完全になくすことができる。

https://azuread.net/archives/10745

> パスワードレスでAzure ADの認証を行う場合、Microsoft Authenticatorを利用する場合でも、FIDO2.0を利用する場合でも、最初に登録をしなければなりません。じゃあ、最初の登録を行うときのサインインには何を使うのか？という問題があります。
ここでパスワードを使ったら、結局パスワードレスじゃないのかい！と突っ込みたくなるでしょう。

> そこでAzure ADでは一定期間のみ利用可能なパスワードとして一時アクセスパスというものを提供しています。


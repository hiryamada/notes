# Windows Hello 

https://docs.microsoft.com/ja-jp/learn/modules/explore-authentication-capabilities/4-describe-windows-hello-for-business

https://jpazureid.github.io/blog/azure-active-directory/how-to-disable-whfb/

- 生体認証または PIN (personal identification number) が使用される。
- Windows では、PIN および生体認証のデータがローカル デバイスに安全に格納される。
- 外部のデバイスまたはサーバーには送信されない。


■Windows hello

- パスワード情報そのものを端末の TPM と呼ばれるセキュアな領域に格納
- PIN や生体認証を行うことで TPM からパスワードそのものを提示する

■Windows hello for Business

- パスワード自体をログオン処理で使用しない
- 秘密鍵/公開鍵のペアによって認証する
- TPM にはパスワードではなく秘密鍵が格納される



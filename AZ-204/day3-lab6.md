# ラボ6補足

ラボ6
https://microsoftlearning.github.io/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/Instructions/Labs/AZ-204_lab_06.html

■必要なもの

- .NET 6 SDK （最新）
- Visual Studio Code
- Azure ADのユーザー - 事前に作ります。

■ポイント

動作確認（サインイン・サインアウト）時、シークレットウィンドウを使用しましょう

■開発用の証明書のインストール

この作業は、.NET SDKインストール後に1回だけ実行すればよい。

※開発用の環境でのみ実施。本番環境では実施してはいけない。

```
dotnet dev-certs https --trust
```

証明書が反映されるように、Webブラウザが立ち上がっている場合は、いったんすべて閉じる。

■Webアプリの作成

```
dotnet new mvc --auth SingleOrg -o webapp

cd webapp
```


■「アプリの登録」を行う

「msidentity-app-sync」ツールを使用する。

```
dotnet tool install -g msidentity-app-sync
```

※これで「msidentity-app-sync」が使えるようになっているはずだが、コマンドが認識されない場合はいったんコマンドプロンプト（や、PowerShell、Terminal、Visual Studio Code等）を閉じて、開き直す。

```
msidentity-app-sync --tenant-id aaaa --username bbbb
```

※テナントIDは、自分のAzure ADのテナントIDを調べておき、それを指定する。

※usernameは、今回のトレーニング用に作成したMicrosoftアカウントのメールアドレスを指定する。

このコマンドにより、Azure ADに「webapp1」アプリの登録が行われる。

※画面上の「最新の情報に更新」をクリックする。コマンド実行から1分以内には出てくるはず。

また、Webアプリの appsetting.json に、アプリの登録によって生成されたクライアントIDなどが書き込まれる。

■Webアプリを実行する

```
dotnet run
```

以下のようなログが出力される。

```
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:7054
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5289
```

■動作確認

Webブラウザを「InPrivate」ウィンドウ（シークレット）で開く。

`https`で始まるほうのアドレスにアクセスする。

アクセスすると、Azure ADの認証がまだ済んでいない場合はまず認証が要求される。準備しておいたAzure ADユーザー（または、Microsoftアカウント）でサインインを行う

続いて、アクセス許可の受け入れの画面が出てくるので、「承諾（Accept）」をクリックする。

すると、Webアプリの「Welcome」画面が表示される。

画面右上には「Hello （ユーザー名）!」というあいさつと「Sign out」リンクがある。

「Sign out」をクリックすると、Microsoftのサインアウト画面が表示される。サインアウトしたいユーザーをクリックして、サインアウトを行う。「アカウントからサインアウトしました」という画面が表示される。

そしてすぐに、Webアプリのサイトに戻り、「Signed out」「You have successfully signed out.」と表示される。


■参考

https://docs.microsoft.com/en-us/shows/Hello-World/Hello-World-Microsoft-Identity

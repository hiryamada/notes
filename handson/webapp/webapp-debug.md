# Webアプリのデバッグ

画面左側のファイル一覧で、「Program.cs」を開く。

![](images/ss-2022-04-04-02-19-27.png)

以下のようなダイアログ「Are you using a screen reader ... ?」が出た場合は「No」をクリック。

![](images/ss-2022-04-03-23-56-57.png)

「F5」を押すか、「Run」メニューの「Start Debugging」を選択して、「デバッグ」を開始する。

![](images/ss-2022-04-04-00-00-16.png)

Visual Studio Codeの画面は以下のようになる。

※デバッグ中はステータスバーがオレンジ色になる。

![](images/ss-2022-04-03-23-59-13.png)

同時にWebブラウザ（Edge）が開くが、以下のような「Your connection isn't private」という表示となる。

![](images/ss-2022-04-04-00-02-59.png)

いったんWebブラウザを閉じ、Visual Studio Code側では「□」をクリックして、「デバッグ」を終了する。

![](images/ss-2022-04-04-00-03-51.png)

![](images/ss-2022-04-03-23-37-26.png)

Terminalメニューから「New Terminal」を選択

`dotnet dev-certs https`と打ってエンター。

続いて`dotnet dev-certs https -t`と打ってエンター。

![](images/ss-2022-04-04-00-06-33.png)

すると以下のような画面が出るので、Yesをクリック。

![](images/ss-2022-04-04-00-07-33.png)

再度、F5を押して「デバッグ」を開始すると、以下のようなサンプルのWebアプリが表示される。

![](images/ss-2022-04-04-00-08-27.png)

以上で、Webアプリの作成と実行ができた。

Webブラウザを閉じ、「デバッグ」を終了する。

画面左側の「Explorer」アイコン（一番上）をクリックすると、ファイル一覧の表示になる。

![](images/ss-2022-04-04-00-10-27.png)
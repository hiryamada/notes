# Linux VM上で Webアプリを作成する

```
dotnet new web -n containerwebapp1
code -r containerwebapp1
```

Visual Studio Codeウィンドウがリロードされる。

下記のようなダイアログが出た場合は「Yes」をクリック。

![](images/ss-2022-04-05-23-32-16.png)


下記のようなダイアログが出た場合は「Yes」をクリック。

![](images/ss-2022-04-05-23-33-09.png)

拡張機能のアイコンをクリックし、「C#」と検索。C#拡張機能がインストールされていない場合はインストール。

![](images/ss-2022-04-05-23-34-24.png)

画面左のエクスプローラ（ファイル一覧）のアイコンをクリック。

Properties フォルダ内の launchSettings.json を開く。

ファイル中央付近、`applicationUrl` の 右側の文字列を `http://localhost:8080` に修正する。

※もともとここには2つのアドレスが書かれている。いったん全部消して、上記を記入する。

※「https」ではなく「http」とする。

![](images/ss-2022-04-05-23-36-49.png)

`Ctrl + s`で、ファイルを保存する。

Run 、Start Debugging で、プロジェクトのデバッグを開始する。

![](images/ss-2022-04-05-23-41-42.png)

Webブラウザが起動し、「Hello World!」と表示される。

※このとき、さきほど `launchSettings.json` で設定したポート番号以外の番号が使用されることがあるが、それは問題ない。

![](images/ss-2022-04-05-23-42-26.png)

Webブラウザを閉じ、デバッグを終了する。

![](images/ss-2022-04-05-23-44-14.png)


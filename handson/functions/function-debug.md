# ハンズオン: Azure Function 「関数アプリ」のデバッグ

F5を押してデバッグを開始する。

以下のようなダイアログが表示される。Learn moreをクリック。

![](images/ss-2022-04-04-01-39-50.png)

Webブラウザが起動し、以下のような、「Azure Functions Core Tools」インストーラのダウンロード用リンクが表示される。「Windows 64-bit」をクリック。

![](images/ss-2022-04-04-01-40-59.png)

ダウンロードされたインストーラを起動する。

![](images/ss-2022-04-04-01-42-17.png)

![](images/ss-2022-04-04-01-42-44.png)

![](images/ss-2022-04-04-01-43-09.png)

以降、「Next」をクリックして進めていき、「Install」、「Finish」をクリック。

インストールが完了したら、いったんVisual Studio Codeを再起動する。（すべてのVisual Studio Code のウィンドウを閉じてから、Visual Studio Codeを開く）

Azure Function 関数アプリのプロジェクトのフォルダが開かれた状態であることを確認する。

![](images/ss-2022-04-04-01-47-49.png)

※もし、フォルダが開かれていない場合は、FileメニューのOpen Folder...から、関数アプリのプロジェクトのフォルダを開く。

![](images/ss-2022-04-04-01-48-40.png)

F5を押して、関数アプリのデバッグを開始する。

![](images/ss-2022-04-04-01-46-30.png)

`http://localhost:7071/api/HttpTrigger1` といったような、HTTPトリガーの「関数」のURLが表示される。

コントロールキーを押しながらURLをクリックすると、WebブラウザーでURLを開くことができる。

![](images/ss-2022-04-04-01-51-40.png)

以下のような画面が出ればOK。

![](images/ss-2022-04-04-01-52-16.png)

Webブラウザーのアドレス欄をクリックし、そこに表示されている `http://localhost:7071/api/HttpTrigger1` の後ろに「?name=taro」といったようなクエリパラメータを加える。

![](images/ss-2022-04-04-01-53-09.png)

「name」パラメータに指定した値がメッセージ内に組み込まれて、挨拶文が表示される。

![](images/ss-2022-04-04-01-54-27.png)

Visual Studio Codeで、「Disconnect」をクリックして、デバッグを終了する。

![](images/ss-2022-04-04-01-55-36.png)


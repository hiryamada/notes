# Linux VMでの Docker拡張機能 のインストール

Dockerの操作をすばやく実行するための拡張機能をインストールする。

![](images/ss-2022-04-05-23-21-35.png)

インストールが完了したら、画面左側のDockerアイコン（クジラ）をクリック。

実行されたコンテナーや、Docker HubからプルされたDockerイメージが確認できる。

![](images/ss-2022-04-05-21-57-58.png)

※コンテナーやイメージの一覧が表示されず、エラーが表示される場合は、いったん、Visual Studio Codeウィンドウ（画面左下が SSH: dockervm1と表示されている）を閉じ、

![](images/ss-2022-04-06-15-04-33.png)

dockervm1の再起動を行う。

![](images/ss-2022-04-06-15-05-06.png)

再起動が完了したら再度 Connect to Host via Remote SSH で接続。

![](images/ss-2022-04-06-15-06-04.png)

すると、Docker拡張機能が動作する。

![](images/ss-2022-04-06-15-06-27.png)
Docker拡張機能をインストールする

![](images/ss-2022-07-13-15-01-52.png)

画面左のDocker拡張機能のアイコンをクリックすると、「Docker Desktop is not installed. Would you like to install it?」と聞いてくる。「Install」をクリック。

![](images/ss-2022-07-13-15-05-20.png)

Dockerのインストールがスタートする

![](images/ss-2022-07-13-15-07-25.png)

Dockerインストーラーが起動する。「OK」をクリック

![](images/ss-2022-07-13-15-08-02.png)

![](images/ss-2022-07-13-15-13-08.png)

いったんリモートデスクトップが切断される。

![](images/ss-2022-07-13-15-13-41.png)


1分ほど待って、リモートデスクトップで再度接続する。

Service Agreementが表示される。

I accept the termsにチェックしてAcceptをクリック

![](images/ss-2022-07-13-15-15-13.png)

![](images/ss-2022-07-13-15-23-50.png)

![](images/ss-2022-07-13-15-24-33.png)

![](images/ss-2022-07-13-15-25-11.png)

![](images/ss-2022-07-13-15-25-42.png)

![](images/ss-2022-07-13-15-26-05.png)

PowerShellを起動する

![](images/ss-2022-07-13-15-29-16.png)

以下のコマンドを実行する

```ps
wsl --set-default-version 2
```

The operation completed successfully. と表示される

![](images/ss-2022-07-13-15-30-25.png)


![](images/ss-2022-07-13-15-26-30.png)

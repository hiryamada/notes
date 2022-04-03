# WSL (Ubuntu)

画面左下のWindowsアイコンをクリックし、「powershell」と検索し、「Windows PowerShell」を起動する

![](images/ss-2022-04-02-02-18-14.png)

`wsl --install` を入力する。

![](images/ss-2022-04-02-02-29-12.png)

Windowsを再起動する

![](images/ss-2022-04-02-02-27-32.png)

Continue

![](images/ss-2022-04-02-02-29-41.png)

いったんリモートデスクトップ接続が切れるので、再度接続する

![](images/ss-2022-04-02-02-30-00.png)

再起動・再接続後、自動的にUbuntuのインストールが開始される。

![](images/ss-2022-04-02-02-31-22.png)

しばらく待つ。※10分ほどがかかる。

![](images/ss-2022-04-02-02-32-09.png)

「Enter new UNIX username:」と出る。適当なユーザー名を入力する。

ユーザー名の例: `azureuser`

![](images/ss-2022-04-02-02-34-56.png)

続いて「New password:」と出る。適当なパスワードを決めて入力する。

「Retype new password」と聞いてくるので、再度同じパスワードを入力。

以上で、WSL上でUbuntuが使えるようになった。

![](images/ss-2022-04-02-02-37-22.png)

スタートメニューからは「ubuntu」で開ける。

![](images/ss-2022-04-02-02-38-32.png)
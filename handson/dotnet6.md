# ハンズオン: .NET SDK 6.0のインストール

Webブラウザで以下のサイトを開く。

https://dotnet.microsoft.com/en-us/download

「.NET 6.0」の「Download .NET SDK」をクリックする。

![](images/ss-2022-04-02-02-14-07.png)

ダウンロードされたインストーラを開く。※ダウンロードされたインストーラをクリックしてから、インストーラの画面が出るまで、15秒ほどかかるので、クリックしたらしばらく待つこと。

![](images/ss-2022-04-02-02-15-41.png)

「Install」をクリック。

![](images/ss-2022-04-02-02-16-07.png)

しばらく待つ。※途中で「Cancel」をクリックしないこと。

「Close」が表示されたら、クリック。

![](images/ss-2022-04-02-02-17-01.png)

画面左下のWindowsアイコンをクリックし、「powershell」と検索し、「Windows PowerShell」を起動する

![](images/ss-2022-04-02-02-18-14.png)

`dotnet --version` を入力する。`6.0.201` といった、インストールした.NETのバージョン情報が出ればOK。PowerShellを閉じる。

![](images/ss-2022-04-02-02-19-02.png)

※バージョン情報が出ない場合は、いったん **すべての** PowerShellウィンドウを閉じてから、再度PowerShellウィンドウを開き、`dotnet --version` を入力する。

※それでもだめな場合は、インストールがうまく完了していないので、ダウンロードとインストーラ実行をやり直す。

# ハンズオン: Windows VMへのリモートデスクトップ接続

VMの「概要」で「接続」をクリックし、「RDP」をクリック

![](../images/ss-2022-04-03-09-32-27.png)

「RDPファイルのダウンロード」

![](../images/ss-2022-04-03-09-35-16.png)

ダウンロードされたRDPファイルを右クリック。

Windows 11の場合、以下のようなメニューが出るので「その他のオプションを表示」をクリック

![](../images/ss-2022-04-03-09-37-15.png)

「編集」をクリック

![](../images/ss-2022-04-03-09-37-31.png)

ユーザー名に、VMを作成した際に指定したユーザー名（`azureuser`）を入力。

![](../images/ss-2022-04-03-09-37-58.png)

「画面」タブをクリックし、画面サイズを「1920 x 1080」に指定

![](../images/ss-2022-04-03-09-38-09.png)

「全般」タブに戻り、「保存」をクリックし、「接続」

![](../images/ss-2022-04-03-09-37-58.png)

「接続」をクリック

![](../images/ss-2022-04-03-09-38-29.png)

「接続しています」画面が出る。少し待つ。

![](../images/ss-2022-04-03-09-38-54.png)

「資格情報を入力してください」が表示される。VMを作成した際に指定したパスワードを入力。

![](../images/ss-2022-04-03-09-39-30.png)

「はい」

![](../images/ss-2022-04-03-09-39-44.png)

リモートデスクトップが起動する。少し待つ。

![](../images/ss-2022-04-03-09-40-00.png)

画面右側に「Network」「Do you want to allow your PC to be discoverable by other PCs and devices on this network?」と表示される。「Yes」をクリック。

![](../images/ss-2022-04-03-09-41-24.png)

しばらくして「Server Manager」が起動する。ダイアログの「Don't show this message again」にチェックして、ダイアログ右上の「✕」をクリック

![](../images/ss-2022-04-03-09-58-18.png)

「Server Manager」のウィンドウの右上の「✕」をクリックして、「Server Manager」を閉じる。

![](../images/ss-2022-04-03-10-06-20.png)

以上で、Windows VMにRDP接続ができた。

![](../images/ss-2022-04-03-10-07-04.png)
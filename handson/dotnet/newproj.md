# ハンズオン: 新しいプロジェクトの作成

Visual Studio Codeで、Terminal を開く。

![](images/ss-2022-04-05-12-43-48.png)

または、Windows PowerShellを開く。

![](images/ss-2022-04-05-12-42-47.png)

以下のコマンドを投入する。`プロジェクト名`の部分は、適当な名前を指定する。

プロジェクト名の例:

- blobapp1
- cosmosapp1
- webapp1

```
cd ~/Documents
dotnet new console -n プロジェクト名
code -r プロジェクト名
```

![](images/ss-2022-04-05-12-49-10.png)

Visual Studio Codeが開く。「Do you trust the authors of the files in this folder?」というダイアログが表示される。「Yes」をクリック。

![](images/ss-2022-04-05-12-50-38.png)

`Required assets to build and debug are missing ... Add them?` と聞いてくる。「Yes」をクリックする。プロジェクトに「.vscode」フォルダが追加される。

![](images/ss-2022-04-05-12-51-48.png)

上記ダイアログは1分ほどで勝手に閉じられてしまう。その場合は F1 を押してコマンドパレットを出し、`build` で検索し、「.NET: Generate Assets for Build and Debug」を選択すると、ダイアログで「Yes」をクリックした場合と同様、プロジェクトに「.vscode」フォルダが追加される。

![](images/ss-2022-04-05-12-53-05.png)

※.vscode が追加された状態

![](images/ss-2022-04-05-12-54-31.png)
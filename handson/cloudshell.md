# ハンズオン: Cloud Shell

WebブラウザでAzure portalを開く
https://portal.azure.com/

画面上に並ぶアイコンの一番左「Cloud Shell」ボタンをクリック
![](images/ss-2022-04-01-10-13-54.png)

以下のような画面が表示された場合は「ストレージの作成」をクリック
![](images/ss-2022-04-01-10-17-11.png)

「Bash」（黒い背景）または「PowerShell」（青い背景）が起動する。

※「Bash」が起動した場合:
![](images/ss-2022-04-01-10-18-18.png)

「Bash」・「PowerShell」の切り替えが必要な場合は、画面左上のプルダウンで行う。
![](images/ss-2022-04-01-10-18-31.png)

※「PowerShell」に切り替えた場合:
![](images/ss-2022-04-01-10-30-24.png)

さらに詳しい使い方については、Cloud Shell上部の「？」アイコンをクリックすると表示される。
![](images/ss-2022-04-01-10-31-46.png)


## Cloud Shell用のリソースグループとストレージアカウント

Cloud Shellを使用すると、リソースグループ「cloud-shell-～～」とストレージアカウント「cs～～」が自動的に作成される。ストレージアカウント内にはファイル共有が作成される。

![](images/ss-2022-04-01-10-38-58.png)

```
リソース グループ: cloud-shell-storage-<region>
└ Storage アカウント: cs<uniqueGuid>
    └ファイル共有: cs-<user>-<domain>-com-<uniqueGuid>
```

ファイル共有に対してごく少量のコスト（月0.36$ 程度）が発生する。

※少額であるため放置しても大きな問題はないが、気になる場合は、Cloud Shellを使用したあとで、リソースグループごと削除してもよい。

## 参考

[Azure Cloud Shellでフォント表示がおかしい場合の対処法](https://qiita.com/aical/items/f7a4c6cc0499936e7180)
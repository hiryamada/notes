# Windows VM (Windows Server 2022) 文字化けの解消

以下のような入出力を行うコードを実行する。
```c#
Console.WriteLine("Hello, World!あいうえお");
var s = Console.ReadLine();
Console.WriteLine(s);
```

普通にVisual Studio Code上のターミナル（PowerShell）で実行すると、文字化けしてしまう。

![](images/ss-2022-04-05-20-12-09.png)

# chcp 65001（失敗）

[ネットで検索](https://www.google.com/search?q=visual+studio+code+chcp+65001) すると、「`chcp 65001` コマンドを投入すると解消する」という情報が多く見つかるが・・・

![](images/ss-2022-04-05-20-16-13.png)

# Git for Windows の Git Bash

[Git for Windows](https://gitforwindows.org/)をインストール。

スタートメニューから Git Bash を起動。

![](images/ss-2022-04-05-19-35-13.png)

# コマンドプロンプト

スタートメニューから コマンドプロンプト を起動。

![](images/ss-2022-04-05-19-43-03.png)

`chcp 932`を実行後、`dotnet run`

![](images/ss-2022-04-05-19-44-06.png)

# Visual Studio Code

F1, `Terminal: Create New Terminal (With Profile)`

![](images/ss-2022-04-05-19-38-30.png)

Command Promptを選択

![](images/ss-2022-04-05-19-39-27.png)

`chcp 932`を実行後、`dotnet run`

![](images/ss-2022-04-05-19-41-01.png)

# システムロケールの変更

![](images/ss-2022-04-05-20-23-01.png)

![](images/ss-2022-04-05-20-23-44.png)

![](images/ss-2022-04-05-20-24-47.png)

![](images/ss-2022-04-05-20-25-04.png)

![](images/ss-2022-04-05-20-25-32.png)

再起動後

![](images/ss-2022-04-05-20-29-57.png)
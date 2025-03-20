■基本的なこと

チャット（Github Copilot Chat）を使用すると、
チャット形式で、プロンプト（指示文）を使用して、
GitHub Copilotにより詳細な指示を出すことができる。

■チャットを使用した後のファイルの保存

変更されたファイルは自動では保存されないことに注意。
必要に応じて明示的にコードをCtrl + S で保存すること。
※補完の場合と同様。

■インラインチャット（inline chat） Ctrl + I

```cs
class Employee
{
    public string Name { get; set; }
}
```

`Ctrl + I`を押し、インラインチャットを表示。
`/doc` と入力してエンター。
`Ctrl + Enter` または `Accept` で受け入れる。

■スマートアクション（コンテキストメニュー内）右クリック＞Copilot＞Generate Docsなど

※これでインラインチャットで /doc と入力するのと同じ

```cs
class Employee
{
    public string Name { get; set; }
}
```

ソースコードを右クリック
Copilotをポイント
Generate Docsをクリック

Click 'Accept' button
to accept

■チャットビュー（chat view） Ctrl + Alt + I ※注意: Ctrl + Shift + I は Copilot Edits

```cs
class Employee
{
    public string Name { get; set; }
}
```

`Ctrl + Alt + I`を押し、チャットを表示。
`write docs` と入力してエンター。
`Ctrl + Enter` で受け入れる。

チャットビュー（chat view）の中にコード候補が表示される。
表示されたコード候補の右上のアイコンから操作を選ぶ。
・Apply in Editor
・Insert At Cursor
・Copy
・Insert into Terminal
・Insert into New File

※インラインチャットとの使い分け: チャットビューでは /doc は使えない。そのかわり
add doc for Name property only
add doc in Japanese
add one-liner comments
といったようにより詳細な指示を出せる。
なお単に「doc」だとコードの説明が表示される場合がある。

■詳細手順

Type Ctrl + Alt + I
to show Chat view

Type @workspace write document comments
to generate document comments

Click 'Apply' button
to apply it to the code

Click 'Accept' button
to accept


■クイックチャット（quick chat） Ctrl + Alt + Shift + L ※ I ではなく L

インラインチャットやチャットビューを使わずに、チャットを利用できる。

チャットビューとの違いとして、が使えない。

チャットビューに履歴が残らない（履歴を共有しない）、#fileが使えない、といった例外を除けば、チャットビューと機能的には同じである。

レイアウトにもよるが、チャットビュー（縦長）に比べて少しだけ横幅があるので、質問の回答を眺めるのに少し便利かもしれない。

※使い道(1)チャットビューの履歴を変化させずに一時的にチャットを使いたい場合

※使い道(2)チャットビューとは異なるモデルを選択して利用できる。

※使い道(3): 昔は、プライマリサイドバー（画面左側）にGitHub Copilot Chatのビューが
表示されていたので、Explorer（ファイル一覧表示）などの表示を変えずに、
一時的にチャットを使いたい・・といった場合に便利だったのかもしれない。

```cs
class Employee
{
    public string Name { get; set; }
}
```

`Ctrl + Alt + Shift + L`を押し、クイックチャットを表示。
`write doc` と入力してエンター。

Click 'Apply' button
to apply it to the code

Click 'Accept' button
to accept

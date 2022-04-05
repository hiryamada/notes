# Azure Functions 「関数アプリ」の作成

F1, Azure Functions: Create New Project...

![](images/ss-2022-04-04-01-36-09.png)

- Select the folder...
  - Browse...

![](images/ss-2022-04-04-01-36-44.png)

「Documents」以下に「func1」フォルダを新規作成し、それをクリックして選択した状態で「Select」

![](images/ss-2022-04-04-01-32-48.png)

- Select a language
  - C#
- Select a .NET runtime
  - .NET 6
- Select a template for your project's first function
  - HTTP trigger
- Privide a function name
  - HttpTrigger1
- Provide a namespace
  - Company.Function
- AccessRights
  - Function
- Select how you would like to open your project
  - Open in current window

プロジェクトが作成される。

![](images/ss-2022-04-04-01-35-06.png)

There are unresolved dependencies ... と表示された場合は「Restore」をクリック。

![](images/ss-2022-04-04-16-17-22.png)
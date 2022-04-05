# ハンズオン: Azure Functions 「関数アプリ」のデプロイ

F1を押して「deploy func」と検索し、「Azure Functions: Deploy to Function App...」を選択。

![](images/ss-2022-04-04-01-56-59.png)

「＋Create new Funciton App in Azure... Advanced」を選択

![](images/ss-2022-04-04-16-25-38.png)

- Enter a globally unique name...
  - func（乱数）
- Select a runtime stack
  - .NET 6
- Select an OS
  - Linux
- Select a resource group ...
  - ＋ Create new resource group
- Enter the name of the new resource group...
  - （エンターキーを押してデフォルト値を受け入れる）
- Select a location for new resources
  - East US
- Select a hosting plan
  - Consumption
- Select a storage account
  - ＋ Create new storage account
- Enter the name of the new storage account...
  - （エンターキーを押してデフォルト値を受け入れる）
- Select an Application Insights resource for your app.
  - Skip for now

関数のデプロイが進行する。しばらく待つ。

![](images/ss-2022-04-04-02-07-43.png)

画面右下に、以下のようなダイアログが出ればデプロイが成功。ダイアログはしばらくすると消える。

![](images/ss-2022-04-04-02-08-49.png)

Azure拡張機能のFUNCTIONSで、サブスクリプション、関数アプリ、と展開していく。Functionsの下に「HttpTrigger1」がある。右クリックして「Execute Function Now...」

![](images/ss-2022-04-04-02-10-14.png)

2つの文字列のうち、右側の部分を、適当な名前に書き換えて、エンター。

![](images/ss-2022-04-04-02-11-49.png)

画面右下に、実行結果が表示される。入力した名前が表示されればOK。

![](images/ss-2022-04-04-02-12-52.png)

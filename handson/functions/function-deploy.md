# ハンズオン: Azure Functions 「関数アプリ」のデプロイ

F1 を押し、コマンドパレットで「Create Funciton App in Azure... (Advanced)」を選択する。

（または画面左「Azure」拡張機能アイコンでAzureリソース一覧を表示し、「Function App」を右クリックして「Create Funciton App in Azure... (Advanced)」を選択する。）

![](images/ss-2022-06-20-16-53-20.png)

- Enter a globally unique name...
  - func（8桁程度の乱数を入力して「func12349876」のような名前にする）
- Select a runtime stack
  - .NET 6 ※「.NET 6 Isolated」ではなく「.NET 6」
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

関数アプリの作成が進行する。しばらく待つ。

![](images/ss-2022-04-04-02-07-43.png)


RESOURCES以下でAzure Passサブスクリプション、Function App、作成した関数アプリ、Functionsと展開していく。`Deploy to Function App...`をクリック。

![](images/ss-2022-06-20-17-01-08.png)

`Deploy`をクリック。

画面右下に、以下のようなダイアログが出ればデプロイが成功。ダイアログはしばらくすると消える。

![](images/ss-2022-04-04-02-08-49.png)

RESOURCES以下でAzure Passサブスクリプション、Function App、作成した関数アプリ、Functionsと展開していく。「HttpTrigger1」がある。右クリックして「Execute Function Now...」

![](images/ss-2022-04-04-02-10-14.png)

2つの文字列のうち、右側の部分を、適当な名前に書き換えて、エンター。

![](images/ss-2022-04-04-02-11-49.png)

画面右下に、実行結果が表示される。入力した名前が表示されればOK。

![](images/ss-2022-04-04-02-12-52.png)


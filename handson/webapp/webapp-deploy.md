# ハンズオン: WebアプリをApp Serviceにデプロイする

Azure拡張機能のアイコンをクリック。

APP SERVICE内に表示されているAzureサブスクリプション（鍵のマークのアイコン）を右クリックし、「Create New Web App...(Advanced)」をクリック。

![](images/ss-2022-04-04-00-39-37.png)

「Enter a globally unique name...」→「app（8桁程度の乱数）」といった適当な名前を入力。乱数部分はキーボードをランダムに叩いて決める。

![](images/ss-2022-04-04-00-41-00.png)

「Select a resource group...」→「＋ Create new resource group」

![](images/ss-2022-04-04-00-42-41.png)

そのままエンターキーを押してデフォルト値を受け入れる。

![](images/ss-2022-04-04-00-43-24.png)

ランタイムの選択。「.NET 6 (LTS)」をクリック。

![](images/ss-2022-04-04-00-44-10.png)

OSの選択。「Linux」

![](images/ss-2022-04-04-00-44-52.png)

ロケーション（リージョン）の選択。「East US」をクリック

![](images/ss-2022-04-04-00-45-24.png)

「App Serviceプラン」の選択。「＋Create new App Service plan」をクリック。

![](images/ss-2022-04-04-00-45-59.png)

そのままエンターキーを押してデフォルト値を受け入れる。

![](images/ss-2022-04-04-00-46-47.png)

「App Serviceプラン」の価格レベルの選択。Basic (B1)を選ぶ。

※「Free (F1)」も選べるが、各リージョンに作れるFreeプランは1個だけであることに注意。

![](images/ss-2022-04-04-00-50-31.png)

Application Insightsの選択。「Skip for now」を選択。

![](images/ss-2022-04-04-00-48-17.png)

以上で、アプリの作成が開始される。

![](images/ss-2022-04-04-00-49-06.png)

※画面右下に以下のようなエラー「This subscription has reached the limit of 1 Free ... service plan(s) ...」と表示されてしまう場合は、すでにFreeプランが作られており、これ以上Freeのプランを作ることができない状態である。

この場合はこのページの手順を最初からやり直し、「App Serviceプラン」の価格レベルの選択で、Free (F1) 以外を選択する。

![](images/ss-2022-04-04-00-57-16.png)

Webアプリが作成されたら、「Deploy」をクリック。

![](images/ss-2022-04-04-14-18-09.png)

または、APP SERVICEの中で、作成したアプリを右クリックし、「Deploy to Web App...」をクリック。

![](images/ss-2022-04-04-14-20-20.png)

![](images/ss-2022-04-04-14-21-29.png)

![](images/ss-2022-04-04-14-21-48.png)

![](images/ss-2022-04-04-14-22-07.png)

![](images/ss-2022-04-04-14-22-28.png)

無事デプロイが完了したら、以下のようなダイアログが表示される。「Browse Website」をクリックする。

![](images/ss-2022-04-04-01-07-19.png)

または、Azure拡張機能の「APP SERVICE」のサブスクリプションを展開し、作成したWebアプリの「Browse Website」をクリックする。

![](images/ss-2022-04-04-01-02-19.png)

Webブラウザが開き、デプロイしたWebアプリが表示される。

![](images/ss-2022-04-04-01-08-07.png)

※デプロイしてすぐにWebアプリにアクセスすると、以下のようなエラー画面が出てしまう場合がある。1分ほど待ってから再度アクセス（リロード）すると、正常にアクセスできるようになる。

![](images/ss-2022-04-04-01-14-12.png)
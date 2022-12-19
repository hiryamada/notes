# ハンズオン: WebアプリをApp Serviceにデプロイする

Visual Studio Codeの、Azure拡張機能のアイコン（画面左側の「A」マーク）をクリック。

RESOURCES内に表示されているAzureサブスクリプション（鍵のマークのアイコン）を展開し、App Servicesを右クリックし、「Create New Web App...(Advanced)」をクリック。

![](images/ss-2022-06-20-14-36-10.png)

「Enter a globally unique name...」→「app（8桁程度の乱数）」といった適当な名前を入力。乱数部分はキーボードをランダムに叩いて決める。

![](images/ss-2022-04-04-00-41-00.png)

「Select a resource group...」→「＋ Create new resource group」

![](images/ss-2022-04-04-00-42-41.png)

そのままエンターキーを押してデフォルト値を受け入れる。

![](images/ss-2022-04-04-00-43-24.png)

ランタイムの選択。「.NET 6 (LTS)」をクリック。

![](images/ss-2022-06-20-14-53-17.png)

OSの選択。「Windows」

![](images/ss-2022-04-04-00-44-52.png)

ロケーション（リージョン）の選択。「East US」をクリック

![](images/ss-2022-04-04-00-45-24.png)

「App Serviceプラン」の選択。「＋Create new App Service plan」をクリック。

![](images/ss-2022-04-04-00-45-59.png)

そのままエンターキーを押してデフォルト値を受け入れる。

![](images/ss-2022-04-04-00-46-47.png)

「App Serviceプラン」の価格レベルの選択。Basic (B1)を選ぶ。

![](images/ss-2022-04-04-00-50-31.png)

Application Insightsの選択。「Skip for now」を選択。

![](images/ss-2022-04-04-00-48-17.png)

以上で、アプリの作成が開始される。

![](images/ss-2022-04-04-00-49-06.png)


Webアプリが作成されたら、「Deploy」をクリック。

![](images/ss-2022-04-04-14-18-09.png)

または、APP SERVICEの中で、作成したアプリを右クリックし、「Deploy to Web App...」をクリック。

![](images/ss-2022-04-04-14-20-20.png)

デプロイする（ローカルの）Webアプリを選択。

![](images/ss-2022-04-04-14-21-29.png)

デプロイ用のコンフィグ（設定）を追加するかどうかの確認。「Add Config」をクリック。

![](images/ss-2022-04-04-14-21-48.png)

デプロイをするかどうかの確認。「Deploy」をクリック。

![](images/ss-2022-04-04-14-22-07.png)

この（ローカルの）Webアプリを、常に同じApp Service Webアプリへとデプロイするかどうかの質問。「Yes」

![](images/ss-2022-04-04-14-22-28.png)

「Azure Developer CLI is not installed...」→ 「Later」

※[Azure Developer CLI](https://learn.microsoft.com/ja-jp/azure/developer/azure-developer-cli/overview) は、Azureアプリ開発を支援するコマンドラインツール。今回は利用しない。

![](images/ss-2022-12-19-10-14-10.png)

無事デプロイが完了したら、以下のようなダイアログが表示される。「Browse Website」をクリックする。

![](images/ss-2022-04-04-01-07-19.png)

または、Azure拡張機能の「APP SERVICE」のサブスクリプションを展開し、作成したWebアプリの「Browse Website」をクリックする。

![](images/ss-2022-04-04-01-02-19.png)

Webブラウザが開き、デプロイしたWebアプリが表示される。

![](images/ss-2022-04-04-01-08-07.png)

※デプロイしてすぐにWebアプリにアクセスすると、以下のようなエラー画面が出てしまう場合がある。1分ほど待ってから再度アクセス（リロード）すると、正常にアクセスできるようになる。

![](images/ss-2022-04-04-01-14-12.png)
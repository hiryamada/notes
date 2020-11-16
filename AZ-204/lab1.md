# 演習1

ストレージアカウントのimagesコンテナーのURLリストを返すWebアプリをデプロイする。

大まかな流れ

- リソースグループを作成
- ストレージ アカウントを作成
- ストレージ アカウントのBlobコンテナーに画像をアップロード
- Web App作成
- Web Appの「アプリケーション設定」に、ストレージアカウントの接続文字列を設定
- Web Appに、ZIPでアプリをデプロイ
- Web Appにアクセスし、画像のURLがJSONで返されることを確認

ポイント

- アップロードする画像はなんでもよい
- ストレージアカウントの接続文字列は、「アプリケーション設定」で設定される。Options.csの対応するフィールドにセットされる。
- Blobコンテナーの名前「images」は、appsettings.json に記述されている。Options.csの対応するフィールドにセットされる。
- Options.csの ThumbnailImageContainerName は、特に使われていないようだ。
- シフトキーを押しながらフォルダを右クリックすると「Windows Terminalで開く」メニューが使用できる。APIフォルダを一発で開けて便利。

# 演習2

- Web Appを作成
- Web Appの「アプリケーション設定」に、演習1で作ったWeb AppのURLを設定する
- Web Appに、ZIPでアプリをデプロイ
- Web Appにアクセスし、画像の一覧の表示、画像のアップロードができることを確認

# Zipデプロイについて

[コマンドの説明](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-zip#deploy-zip-file-with-azure-cli)。


このコマンドは、ファイルとディレクトリを ZIP ファイルから既定の App Service アプリケーション フォルダー (\\home\\site\\wwwroot) にデプロイし、アプリを再起動します。

既定で、展開エンジンでは ZIP ファイルがそのまま実行できる状態で、ビルド自動化は実行されないことが想定されています。 

Git デプロイの場合と同じビルド自動化を有効にするには、Cloud Shell で次のコマンドを実行することで、SCM_DO_BUILD_DURING_DEPLOYMENT アプリ設定を設定します。

`az webapp config appsettings set --resource-group <group-name> --name <app-name> --settings SCM_DO_BUILD_DURING_DEPLOYMENT=true`

# コマンドのヘルプより

`az webapp deployment source config-zip --help` より。

```
az webapp deployment source config-zip : Perform deployment using the kudu zip push deployment
for a web app.
    By default Kudu assumes that zip deployments do not require any build-related actions like
    npm install or dotnet publish. This can be overridden by including a .deployment file in
    your zip file with the following content '[config] SCM_DO_BUILD_DURING_DEPLOYMENT = true',
    to enable Kudu detection logic and build script generation process. See
    https://github.com/projectkudu/kudu/wiki/Configurable-settings#enabledisable-build-actions-preview
    . Alternately the setting can be enabled using the az webapp config appsettings set
    command.
```

az webapp deployment source config-zip：Webアプリのkudu zipプッシュデプロイメントを使用してデプロイメントを実行します。

デフォルトでは、Kuduは、zipデプロイメントが `npm install` や `dotnet publish` などのビルド関連のアクションを必要としないことを前提としています。

これは、zipファイルに `[config] SCM_DO_BUILD_DURING_DEPLOYMENT = true` を含む `.deployment` ファイルを含めることでオーバーライドでき、Kudu 検出ロジックとビルドスクリプト生成プロセスを有効にします。

https://github.com/projectkudu/kudu/wiki/Configurable-settings#enabledisable-build-actions-preview を参照してください。

または、`az webapp config appsettings set`コマンドを使用して設定を有効にすることもできます。

# Kuduについて

[KuduのWiki](https://github.com/projectkudu/kudu)。[Kuduの解説（@IT）](https://www.atmarkit.co.jp/ait/articles/1707/27/news024_3.html)。[ZIPデプロイ](https://github.com/projectkudu/kudu/wiki/Deploying-from-a-zip-file-or-url)にも対応しています。

[ZIPデプロイ](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-zip#create-a-project-zip-file)


# タスク1


# タスク2

> アクセス階層: ホット

Blobのアクセス改装は、デフォルトでホットになるため、特に指定する必要はありません。

# タスク3

> 3. パブリック アクセス レベル: BLOB (BLOB の場合のみ匿名読み取りアクセス)

「BLOB (BLOB専用の匿名読み取りアクセス)」を選択します。

> 4. ラボ マシン上の・・・grilledcheese.jpg ファイルをアップロードします。

ラボで使用するファイル一式はこちらから入手できます。ZIPを展開すると、`Allfiles/Labs/01/Starter/Images` フォルダがあり、そこに `grilledcheese.jpg` があります。

https://github.com/MicrosoftLearning/AZ-204JA-DevelopingSolutionsforMicrosoftAzure/archive/master.zip

画像ファイルは、適当な画像をアップすれば、どんなものでもかまいません。

# タスク4

> 1. 次の詳細で新規 Web アプリを作成します:

Azure portal上部の検索ボックスで 「App Service」を検索し、「App Service」を選択し、「＋追加」をクリックします。

# タスク5

> 2. 値: ストレージの接続文字列

ストレージアカウントのアクセス キーのブレードで取得しておいた接続文字列をここに設定します。

> 3. 変更内容をアプリケーション設定に保存します。

画面上部の「保存」をクリックし、さらに「続行」をクリックします。

> 注: この時点で、この URL の Web サーバーは 404 エラーを返します。

実際には、「Hey, App Service developers!」という画面が表示されます（200 OK が返ります）。


# タスク 6

> 1. Visual Studio Code で、... Starter\\API フォルダーにある Web アプリケーションを開きます。

Visual Studio Code を開き、`File > Open Folder ...`  で、`Labs/01/Starter` フォルダを開きます。Codeの画面左側のExplorerから、`API/Controllers/ImagesController.cs`を開きます。

> 5. ManagedPlatform リソース グループ内のすべてのアプリを一覧表示します。
> 6. プレフィックス imgapi* を持つアプリを見つけます。
> 7. プレフィックス imgapi* を持つ単一のアプリの名前のみを印刷します。

出力を見やすくするためには、`--output table` を追加します。

この時点ではWebアプリが1つだけ存在するはずです。6/7は省略できます。（これらはAZ CLIの使い方の例です）

> 8. 現在のディレクトリを、...Starter\\API ディレクトリに変更します。

WindowsエクスプローラでAPIフォルダを開き、 Shift＋クリック し、「パスのコピー」を選びます。Windows Terminalに戻り、「cd 」（cdスペース）に続き、コピーしたパスを貼り付けてエンターキーを押します。

> 9. この課題で前に作成した Web アプリに api.zip ファイルをデプロイします。

ここでは[Azure CLI を使って ZIP ファイルを展開する](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-zip#deploy-zip-file-with-azure-cli)方法を使用しています。ZIPファイルは[あらかじめ作成しておきます](https://docs.microsoft.com/ja-jp/azure/app-service/deploy-zip#create-a-project-zip-file)。

> 11. Web サイトのルートに GET 要求を実行し、...

これは、前の手順で、Webアプリにアクセスしたことに相当します。（特になにもしなくてよいです）


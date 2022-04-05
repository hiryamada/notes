# Azure Container Registry レジストリの作成

Webブラウザーで https://portal.azure.com/ (Azure portal) にアクセスし、サブスクリプションを表示。

![](images/ss-2022-04-06-00-15-29.png)

使用中のサブスクリプションをクリック。

![](images/ss-2022-04-06-00-15-57.png)

registry で検索

![](images/ss-2022-04-06-00-16-44.png)

検索結果の Microsoft.ContainerRegistry をクリックし、「登録」

![](images/ss-2022-04-06-00-17-26.png)

何度か「更新」をクリックし、「Registering」が「Registered」となればOK。

![](images/ss-2022-04-06-00-20-07.png)

Visual Studio Code（画面左下が緑色のSSH: dockervmとなっているウィンドウ）に戻る。

![](images/ss-2022-04-06-00-07-43.png)

![](images/ss-2022-04-06-00-08-00.png)

![](images/ss-2022-04-06-00-07-19.png)

「Install Azure Account Extension...」の表示が消え、代わりに Azureサブスクリプション名が表示される。

※もし「Sign in to Azure...」と表示された場合は、クリックして、サインインする。

![](images/ss-2022-04-06-00-08-45.png)

- Provide a registry name
  - acr(乱数)
- Select a SKU
  - Basic
- Select a resource group
  - + Create new resource group
- Enter the name of the new resource group
  - エンターキーを押してデフォルト値を受け入れる
- Select a location for new resources
  - East US

ACRレジストリが作成される。

![](images/ss-2022-04-06-00-22-52.png)
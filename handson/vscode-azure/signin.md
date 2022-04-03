# ハンズオン: Azureへのサインイン

Visual Studio Codeの拡張機能を使用して、Azureにサインインする。

その前に、Webブラウザ（Edge）でサインインを済ませておくとスムーズである。

Webブラウザ（Edge）を開き、以下のサイトを開く。

https://portal.azure.com/

![](../webapp/images/ss-2022-04-04-00-18-11.png)

Azure portalのサインイン画面が表示される。

※Edgeの「Save your passwords...」といったダイアログが表示された場合は「Not now」をクリック。

![](../webapp/images/ss-2022-04-04-00-20-27.png)

トレーニング開始時に作成したMicrosoftアカウントでサインインを行う。

![](../webapp/images/ss-2022-04-04-00-23-13.png)

「Save passwords」が表示されたら「Save」をクリック。

![](../webapp/images/ss-2022-04-04-00-23-57.png)

「Stay signed in?」が表示されたら「Yes」をクリック。

![](../webapp/images/ss-2022-04-04-00-24-44.png)

Azure portalにサインインできた。「Translate ...?」が表示された場合は「Not now」をクリック。

![](../webapp/images/ss-2022-04-04-00-25-23.png)

続いて、Visual Studio Code 側で操作を行う。

F1を押し（または「Ctrl + Shift + P」を押し）て、コマンドパレットを開き、`sign in`と入力し、「Azure: Sign In」をクリックする。

![](../webapp/images/ss-2022-04-04-00-26-53.png)

Webブラウザで先程サインインしたアカウントが表示されるはずである。そのアカウントをクリックする。

![](../webapp/images/ss-2022-04-04-00-30-00.png)

「You are signed in now...」と表示される。このブラウザ（タブ）は閉じてよい。

![](../webapp/images/ss-2022-04-04-00-30-38.png)

Visual Studio Code画面左側「Azure」拡張機能のボタンをクリックし、「APP SERVICE」等の区画内に、「Azure pass」といったサブスクリプション名が表示されていれば、サインインが正しく完了している。

![](../webapp/images/ss-2022-04-04-00-32-01.png)
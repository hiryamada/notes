# ラボ6 Azure AD Connect

目標: 120min

- 演習1 
  - VMに割り当てる、未使用のドメイン名（xxx.yyy.cloudapp.azure.com）を探します。xxxには任意の名前、yyyはeastusなどのリージョン名が入ります。
  - VMをデプロイします。このVMには、Windows Serverが稼働し、その中でActive Directory Domain Serviceが稼働します。
- 演習2 新しいAzure ADテナントを作成します。
- 演習3 
  - VMにAzure AD Connectをインストールします。
  - 新しいOU（組織単位）を作り、ユーザーを追加します。
  - Azure AD Connectにより、そのユーザーの情報が、Azure ADテナントへと同期されていくことを確認します。

途中、Windows VMへのリモートデスクトップ接続が必要となります。リモートデスクトップ接続が使用できない環境では、代わりに[Azure Bastion](https://docs.microsoft.com/ja-jp/azure/bastion/tutorial-create-host-portal)を使用できます。

リージョンは米国東部(eastus)を使用します。

このラボの開始時は、前のラボで作った新しいテナントではなく、最初のテナントを使用します。演習2では、また別の新しいテナントを作ります。

## 演習1

タスク1-2 画面上部の検索ボックスの右のアイコンをクリックしてCloud Shellを起動します。「ストレージがマウントされていません」というメッセージが出た場合は「ストレージの作成」をクリックします。

タスク1-4～1/5 たとえば以下のように、DomainLabelNameの引数を変えながら何度か実行し、Trueが返されるドメイン名を探します。[コマンドのドキュメント](https://docs.microsoft.com/en-us/powershell/module/az.network/test-azdnsavailability?view=azps-5.6.0)

```
PS /home/test2021-0322-2> Test-AzDnsAvailability -DomainNameLabel test1234 -Location eastus
False
PS /home/test2021-0322-2> Test-AzDnsAvailability -DomainNameLabel test987654 -Location eastus
True
```

タスク2-2 開いたGitHubリポジトリのページの下部にある、青い「Deploy to Azure」ボタンをクリックします。

タスク2-4 「ロード ファイル」→「ファイルの読み込み」

タスク2-5 
- リージョン：米国東部
- 管理者ユーザー名（Admin Username）：Student
- 管理者のパスワード（Admin Password）: Pa55w.rd1234

## 演習2

タスク2-1～2-2 テナント作成直後、「テナントが正常に作成されました。新しいテナント AdatumSync に移動するには、ここをクリックします。」と画面に表示されます。それをクリックすることでも、新しいテナントに移動できます。

タスク3-3 ロール: 「役割」の「ユーザー」をクリックします。「グローバル**閲覧者**」を選ばないように気をつけてください。

タスク3-3 利用場所 「米国」→United States

タスク3-4 InPrivateブラウザーの画面を開きます→Ctrl + Shift + N を押して、InPrivateウィンドウを開きます。

タスク3-5 portal.azure.com にアクセスします。ここで、すでに他のユーザーでサインイン状態になってしまう場合は、いったんサインアウトします。

## 演習3

タスク1-6 Local Serverをクリックし、IE Enhanced Security Configuration をクリックします。

タスク1-8 画面右上Toolsをクリックし、Active Directory Administrative Centerをクリックします。

タスク1-9 画面右側TaskでNewをクリックし、Organizational Unitをクリックします。

タスク1-13 Confirm passwordにもパスワードを設定します。

タスク1-13 「その他のパスワードオプション」→画面右側のPassword options: の「Other password options」をクリックし、「Password never expires」をクリックします。

タスク2-1 IEでportal.azure.com に接続すると、Welcome to Azureという画面が出ます。画面右下「Continue to Azure Portal website」をクリックします。

タスク2-5 画面を下にダウンロードします。Downloadというボタンをクリックします。

タスク2-6 「実行」→Run

タスク2-9 Install required components画面で、すべてのチェックボックスのチェックを**入れずに**、Installをクリックします。

タスク2-10 Password Hash Synchronization が選択されていることを確認して「Next」をクリックします。

タスク2-11 ここでは syncadminのUPN（ syncadmin@～～.onmicrosoft.com ）を入力します。

タスク2-15 「Continue without matching all UPN suffixes to verified domains」にチェックを付けて「Next」をクリックします。

タスク2-16 Sync selected domains and OUsを選択します。adatum.comのチェックを外します。adatum.comのチェックボックスの左に表示されている三角形をクリックしてツリーを展開し、ToSyncにチェックを付けます。

タスク2-20 「Start the synchronization process when configuration completes」にチェックが付いていることを確認して「Install」をクリックします。

タスク3-1 IE内でAzure Active Directory を表示し、ManageセクションのUsersをクリックします。

タスク3-2 aduserが出るまで数分かかる場合があります。何度か、一覧の上部の「Refresh」ボタンをクリックして、リストにaduser1が出現するまで待ちます。

タスク3-3 Identityセクション内で、「Source」が「Windows Server AD」と表示されていることを確認します。

タスク3-6 Azure Directory Administrative Centerのウィンドウに切り替えます。ToSync OU のオブジェクトのリストで aduser1 エントリをダブルクリックします。Organization の Department に Sales と入力してOKをクリックします。

タスク3-9 コマンドを手順書からコピーし、PowerShellに貼り付けて実行します。貼付け後、エンターキーを押して、全てのコマンドが実行されるようにしてください。コマンドの出力で「Result ------ Success」と出ればOKです。

タスク3-10 IEで、 aduser1 を表示しているページで、Ctrl + R を押して、ページをリロードします。Job info の Department が「Sales」となっていることが確認できます。

リソースのクリーンナップの2

```
[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
Install-PackageProvider -Name NuGet -MinimumVersion 2.8.5.201 -Force
Install-Module MsOnline -Force
```

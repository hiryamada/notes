# ラボの手順書

こちらのGitHubリポジトリに格納されています。

https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator

手順書は、[Instructions/Labs](https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/tree/master/Instructions/Labs) 以下の各Markdownファイル（～.md）です。

# Cloud Shell のホームディレクトリに、ラボのファイルをコピーする

ラボで使用されるファイル（[Allfiles/Labs](https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/tree/master/Allfiles/Labs)以下のファイル）は、下記の方法で準備すると、毎回アップロードする必要がなくなり、便利です。

Azure portalでCloud Shell （Bash）を起動し、下記のコマンドを貼り付けます。

```
git clone https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator.git
cp `find AZ-104JA-MicrosoftAzureAdministrator/Allfiles/Labs -type f` .
```

コピーされたファイルを確認するには `ls` を使用します。
```
ls
```

あとは、PowerShell に切り替えて、ラボで指示されるように、コマンドを貼り付けていけばOKです。

# ラボのファイルをローカルにダウンロードするには

※上記の「Cloud Shell のホームディレクトリに、ラボのファイルをコピーする」を実施した場合は、ラボのファイルをローカルにダウンロードする必要はありません。この説明はスキップしてください。

**ローカルにファイルをダウンロードせず、上記の「Cloud Shell のホームディレクトリに、ラボのファイルをコピーする」方法を強くおすすめします。そのほうがトラブルがなく、手間も少ないです。**

ラボで使用されるファイルは、 [Allfiles/Labs](https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/tree/master/Allfiles/Labs) 以下に格納されています。

ファイルを一括でダウンロードするには、[GitHubリポジトリ](https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator) の「Code」ボタン（画面右上の緑色のボタン）をクリックし、「Download ZIP」を選択してください。または、[ZIPファイルへのリンク](https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/archive/master.zip)を使ってください。

GitHubから、ファイルを個別にダウンロードする場合のご注意：
たとえば、[ラボ2のJSONファイル](https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/blob/master/Allfiles/Labs/02/az104-02a-customRoleDefinition.json)をダウンロードする場合、このページの「Raw」ボタンをクリックし、[JSONファイルそのもの](https://raw.githubusercontent.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/master/Allfiles/Labs/02/az104-02a-customRoleDefinition.json)をブラウザに表示させてから、`Ctrl + S` または、「ページ右クリック ＞ 名前を付けて保存」で、ファイルとして保存してください。

# ラボ1

タスク2の7でメンバーシップの種類の選択のところがグレーアウトして選択できない場合は、Webブラウザでページをリロードしてください。

最後の「リソースのクリーンアップ」の「8.Azure portal からサインアウトし、サインインし直します。」はなくてもできる場合があります。最初に削除を試してみて、ダメならサインアウト、サインインしてみてください。

# ラボ2a

クリーンアップのコマンドでは、
'[id]' ではなく 'id' と書いてください。

# ラボ2b

# ラボ3a

演習 1
タスク 1: リソース グループを作成し、リソース グループにリソースをデプロイする

3 リージョン このラボで使用するサブスクリプションで使用できる Azure リージョンの名前
westus2（米国西部2）を使ってください。

# ラボ3b

演習 1
タスク 2: ARM テンプレートを使用して Azure マネージド ディスクを作成する

3「テンプレートの編集」 ブレードで、「ファイルの読み込み」 をクリックし、前の手順でダウンロードしたテンプレート ファイルをアップロードします。

は、自分でダウンロードしたものではなく、\Allfiles\Labs\03\az104-03b-md-template.json および \Allfiles\Labs\03\az104-03b-md-parameters.jsonを使ってください。

タスク 2: ARM テンプレートを使用して Azure マネージド ディスクを作成する

８．「カスタムデプロイ」 ブレードに戻って、次の設定を指定します。
のLocationはeastusになりますが、そのまま進めて大丈夫です。

# ラボ3c

ラボ3cとラボ3dは同じ内容で、PowerShellでやるかAz CLIでやるかの違いだけです。どちらか片方を実施いただければ十分です。

# ラボ3d

3dの最後のコマンドがラボ3で使ったリソースの削除コマンドになっています。よって、3cで終わるとリソースがすべて残ります。終わった方は3dの最後のコマンドでリソースグループすべて削除してください。

# ラボ4

【タスク02】（手順3）・jsonファイルを１個ずつアップロードしました。ドラッグして複数ファイルを同時にアップロードはできません。

・２つのファイルがアップロードできているかどうか、確認しましょう。lsコマンドで確認します。

（全体）「ipconfig1」の設定など［保存］することを忘れずに。

【タスク04】（手順4）「ネットワークセキュリティグループ」と「ネットワークセキュリティグループ（クラシック）」があり、見間違えないようにしましょう。「ネットワークセキュリティグループ」で実施できました。

（手順7）「受信セキュリティルール」とありますが、画面では「受信セキュリティ規則」です。

【タスク05】（手順7）反映まで時間がかかりました。数分待ってからページ更新。

# ラボ5

【タスク01】(手順5)「可用性ゾーンに対応したAzureリージョンの名前」は west usにしました。

（手順09）こちらの「可用性ゾーンに対応したAzureリージョンの名前」は　east usにしました。

【タスク02】（手順5）この表だけではなく、これ以降の表についても、設定名と画面表示が異なります。表の上４行が画面では下方に、表の下４行が画面では上方にというイメージです。

例えば、「az104-05-vnet0からリモート仮想ネットワークへのピアリングの名前」は
「リモート仮想ネットワーク」項目の「ピアリング名」で読み替えてください。

# ラボ6
【タスク01】（手順1）east usにしました。

【タスク02】（手順5)ラボ05と同じように、表と画面表示の上下が逆です、ご注意ください。

【タスク03】（手順5)かなり時間がかかりました。１回目はダメで、しばらく経った２回目でＯＫ。

（手順9）「到達不能」ではなく、「到達不可能」と表示されます。

【タスク04】（手順11）ルートテーブルの作成において、「仮想ネットワークを作成したときと同じAzureリージョン」ですが、注意してください。既定値が米国西部2になっています。私はタスク01で米国東部を選んでので、選ぶ直すことになりました。

（手順13・15）「ルート」「サブネット」は”設定”にあります。
【タスク05】（手順9）「暗黙的なアウトバウンド規則の設定」は、「はい」では無く、「推奨」でうまくいきました。

# ラボ7

タスク 5: Azure Files 共有を作成して構成する

Azure portal で 「仮想マシン」 を検索して選択し、仮想マシンの一覧で 「az104-07-vm0」 をクリックします。

→この手順だと仮想マシン（クラシック）がでるので、Virtual Machinesで検索してください。

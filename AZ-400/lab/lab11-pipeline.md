事前準備
- Azure DevOps組織をまだ準備していない場合は準備してください。
- 組織の課金（Billing）の設定で、課金の設定（サブスクリプションとの接続）を行い、Microsoft ホステッドエージェントに1以上を割り当ててください。

手順書: 
https://microsoftlearning.github.io/AZ-400JA-Designing-and-Implementing-Microsoft-DevOps-solutions/Instructions/Labs/AZ400_M11_Configuring_Pipelines_as_Code_with_YAML.html
に従って、ラボを実施します。

このラボでは以下のことを行います。
・Azure DevOps Demo Generatorを使用して、Azure DevOpsに「Parts Unlimited」プロジェクトを作ります。
・Azure portal側で「＋リソースの作成」を使用し、「Web App + SQL」をデプロイします。Azure App ServiceのWebアプリと、SQLデータベースが作成されます。
・DevOpsのAzure Reposに格納されたコードから、プロジェクトのYAMLパイプラインを使用して、ビルド・テストを行い、上記のWebアプリにデプロイします。
・パイプラインの最初の起動は手動で行いますが、一度パイプラインが動くと、以降はAzure Reposのソースを修正してコミットするだけで、パイプラインが起動します。

リージョンを指定するところはすべて 「米国東部」（East US）を選択してください。

タスク3は、手順2～18で、段階的にYAMLを書き加えていくようになっていますが、長くて間違えやすいです。初めに手順19のYAMLの「最後のタスク」(最終7行)を除いて、全部コピーしてAzure Pipelinesに貼り付けし、手順7を実施すると、楽に完成させることができます。

初回のデプロイ時、デプロイの進行画面に「This pipeline needs pernmission to access a resource before this run can countinue to Deploy」と表示される場合があります。「View」、「Permit」をクリックして進めてください。

The agent request is not running because all potential agents are running other requests. Current position in queue: 1

というメッセージが出る場合がありますが、これは待つしかないようです。数分経つと勝手に始まると思います。

デプロイが完了したら、App Serviceのアプリの「参照」ボタンを押して、Webアプリにアクセスします。Parts UnlimitedのWebサイトにアクセスができればデプロイは成功しています。

実施後は、手順の最初で作成したリソースグループを削除します。Azure DevOps側のプロジェクトも不要でしたら削除してください。

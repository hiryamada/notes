# ラボ4

想定時間: 60min


## ラボの重要ポイント

ACR(Azure Container Registry)と、AKS(Azure Kubernetes Service)を使用します。

Kubernetesクラスターに、Nginx（Webサーバー）をデプロイします。

デプロイに使用するファイルは以下の2つです。

- nginxexternal.yaml
  - Nginxと、[パブリックロードバランサー](https://docs.microsoft.com/ja-jp/azure/aks/load-balancer-standard#use-the-public-standard-load-balancer)をデプロイします。
- nginxinternal.yaml
  - Nginxと、[内部ロードバランサー](https://docs.microsoft.com/ja-jp/azure/aks/internal-lb)をデプロイします。

このラボについてはコマンドの実行が主体となります。各コマンドの意味については、説明を読みながら進めていただければご理解いただけると思います。

Cloud Shellは、Bashを使用します。切り替えるのを忘れないようにしてください。

コマンドをCloud Shellに貼り付けるには Ctrl + Shift + V を押します。複数行のコマンドを貼り付ける場合は、最後にエンターキーを押すのを忘れないでください。

演習で使用するファイル（ZIPでダウンロードして展開）内の、2つのyamlファイルを、Cloud Shellのなかで操作します。エクスプローラ等から、Cloud Shellに、ファイルをドラッグ・ドロップすると、アップロードすることができます。

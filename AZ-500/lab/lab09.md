# ラボ9

ACR(Azure Container Registry)と、AKS(Azure Kubernetes Service)を使用します。

Kubernetesクラスターに、Nginx（Webサーバー）をデプロイします。

このラボについてはコマンドの実行が主体となります。各コマンドの意味については、説明を読みながら進めていただければご理解いただけると思います。

コマンドをCloud Shellに貼り付けるには Ctrl + Shift + V を押します。複数行のコマンドを貼り付ける場合は、最後にエンターキーを押すのを忘れないでください。

演習で使用するファイル（ZIPでダウンロードして展開）内の、2つのyamlファイルを、Cloud Shellのなかで操作します。エクスプローラ等から、Cloud Shellに、ファイルをドラッグ・ドロップすると、アップロードすることができます。

## 演習1

タスク1-6 $RANDOMの部分には自動的に乱数が入ります。[参考](https://qiita.com/7of9/items/60b59fd872fe378726fd)

タスク1-7 ACRの名前: "name" の右側の文字列を記録しておきます。az5003174026365 など。

タスク3-1 「AKS」で検索すると「Kubernetes サービス」が検索できます。

タスク3-3 (US) East US → 米国東部

タスク3-3 可用性ゾーン：なし → 可用性ゾーンのプルダウンをクリックし、ゾーン1/2/3のチェックを外すと、表示が「なし」となります。

タスク3-5 認可→ 認証

タスク3-6 DNS 名のプレフィックス：有効な、グローバルに一意の DNS ホスト名 → テキストボックスに「MyKubernetesCluster-dns」という文字列が入っていますので、その末尾に乱数を追加（キーボードから適当な数字を打ち込む）し、一意な名前にします。

タスク3-14 「状態」 が 「準備完了」 と表示されていることを確認します。→ 以下のように「STATUS」が「Ready」となることを確認します。

```
NAME                       STATUS   ROLES   AGE   VERSION
aks-agentpool-18419162-0   Ready    agent   72m   v1.18.14
```

タスク5-4 `<`と `>`は削除します。例としては、以下のようになります。
```
        image: az5003174026365.azurecr.io/sample/nginx:v1
```

タスク5-4 「省略記号」は、Cloud Shellの上に表示されたエディタ右側の「...」のことです。

タスク5-7 これはコマンドではなく、実行結果例です。

タスク6-2 「外部IP」列に・・・→ EXTERNAL-IP の下に表示されているIPアドレスをコピーします。

タスク7-7 「Cloud Shell」 ウィンドウ内の Bash セッションで、出力を確認します。外部 IP は、この場合はプライベート IP アドレスです。→ 7-6のコマンド実行で以下のような出力が得られます。CLUSTER-IPを記録します。

```
NAME            TYPE           CLUSTER-IP   EXTERNAL-IP   PORT(S)        AGE
nginxinternal   LoadBalancer   10.0.19.17   <pending>     80:31151/TCP   4m10s
```

タスク8-1 

タスク8-2 ポッドの一覧表示で、NAME 列の最初の項目をコピーします。 → 8-1のコマンドで以下のような出力が得られます。
`nginxinternal-` で始まるNAMEを記録します。
```
NAME                             READY   STATUS    RESTARTS   AGE
nginxexternal-77ddc89569-rjm49   1/1     Running   0          8m4s
nginxinternal-765d58855-f5zcm    1/1     Running   0          6m11s
```

タスク8-3 `<`と `>`は削除します。例としては、以下のようになります。

```
kubectl exec -it nginxinternal-765d58855-f5zcm -- /bin/bash
```

タスク8-4 タスク7-7で記録した、`nginxinternal-`で始まるPodのINTERNAL-IPを使用します。`<`と `>`は削除します。例としては、以下のようになります。

```
curl http://10.0.19.17
```


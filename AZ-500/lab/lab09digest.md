# ラボ9 ダイジェスト

■リソースグループを作成

```sh
az group create --name AZ500LAB09 --location eastus
```

■ACRを作成

```sh
az acr create --resource-group AZ500LAB09 --name az500$RANDOM$RANDOM --sku Basic
```

■Dockerfileを作成

```sh
echo FROM nginx > Dockerfile
```

■ACRビルド

```sh
ACRNAME=$(az acr list --resource-group AZ500LAB09 --query '[].{Name:name}' --output tsv)
az acr build --image sample/nginx:v1 --registry $ACRNAME --file Dockerfile .
```

■AKSクラスターを作成

Azure portalで作業。

MyKubernetesCluster という名前のクラスターを作成

■AKSクラスター接続のための認証情報を取得

```sh
az aks get-credentials --resource-group AZ500LAB09 --name MyKubernetesCluster
```

（ `~/.kube/config` にマージされる）

■AKSクラスターのノードを取得

```sh
kubectl get nodes
```

```
NAME                                STATUS   ROLES   AGE   VERSION
aks-agentpool-33281716-vmss000000   Ready    agent   25m   v1.23.8
```

■AKS クラスターのマネージドIDに、ACRにアクセスする権限を与える。

```sh
ACRNAME=$(az acr list --resource-group AZ500LAB09 --query '[].{Name:name}' --output tsv)
az aks update -n MyKubernetesCluster -g AZ500LAB09 --attach-acr $ACRNAME
```

※これにより AKS クラスターに関連付けられているマネージド ID に AcrPull ロールが割り当てられる。
https://learn.microsoft.com/ja-jp/azure/aks/cluster-container-registry-integration?tabs=azure-cli

■AKS クラスターに、仮想ネットワークへの Contributor ロールを付与

```sh
RG_AKS=AZ500LAB09
AKS_VNET_NAME=AZ500LAB09-vnet
AKS_CLUSTER_NAME=MyKubernetesCluster
AKS_VNET_ID=$(az network vnet show --name $AKS_VNET_NAME --resource-group $RG_AKS --query id -o tsv)
AKS_MANAGED_ID=$(az aks show --name $AKS_CLUSTER_NAME --resource-group $RG_AKS --query identity.principalId -o tsv)
az role assignment create --assignee $AKS_MANAGED_ID --role "Contributor" --scope $AKS_VNET_ID
```

- スコープ: AKSクラスターがデプロイされている仮想ネットワーク
- ロール: Contributor（共同作成者）
- 割当先: AKSクラスターのマネージドID

■nginxexternal.yamlとnginxinternal.yamlのアップロード

Cloud Shellのストレージにアップロードする。

■nginxexternal.yamlの書き換え

このファイルではKubernetesの「Deployment」と「Service」を定義している。

「Deployment」では、デプロイするイメージを指定している。

```
<ACRUniquename>.azurecr.io/sample/nginx:v1
↑ここを冒頭で作成したACRの名前に書き換える。
```

「Service」では、LoadBalancerを指定している。

これにより、Azure Load Balancer（パブリック）が作成される。

■nginxexternal.yamlの適用

```sh
kubectl apply -f nginxexternal.yaml
```

■デプロイ結果の確認

```sh
kubectl get service nginxexternal
```

```
NAME            TYPE           CLUSTER-IP     EXTERNAL-IP      PORT(S)        AGE
nginxexternal   LoadBalancer   10.0.207.109   20.237.107.245   80:31926/TCP   22m
```

EXTERNAL-IPにアクセスして動作確認。

■nginxinternal.yamlの書き換え

```
<ACRUniquename>.azurecr.io/sample/nginx:v1
↑ここを冒頭で作成したACRの名前に書き換える。
```

nginxexternal.yaml とほぼ同じ内容。

「Service」には、以下の記述が含まれている。

```
service.beta.kubernetes.io/azure-load-balancer-internal: "true"
```

これにより、Azure Load Balancer（内部）が作成される。

参考: https://learn.microsoft.com/ja-jp/azure/aks/internal-lb#create-an-internal-load-balancer

■nginxinternal.yamlの適用

```sh
kubectl apply -f nginxinternal.yaml
```

```
NAME            TYPE           CLUSTER-IP     EXTERNAL-IP    PORT(S)        AGE
nginxinternal   LoadBalancer   10.0.193.237   10.240.0.113   80:30552/TCP   23m
```

EXTERNAL-IPは、ロードバランサーのフロントエンドIP（プライベートIPアドレス）。

■デプロイ結果の確認

Pod情報を取得

```sh
kubectl get pods
```

```
NAME                             READY   STATUS    RESTARTS   AGE
nginxexternal-8675d7cdf6-b94vk   1/1     Running   0          26m
nginxinternal-7bf65b8954-rnw2q   1/1     Running   0          25m
```

「最初の」Podに接続（して、/bin/bashを起動）

```sh
kubectl exec -it nginxexternal-8675d7cdf6-b94vk -- /bin/bash
```

Pod内部で、curlコマンドを使用して、Podから、Azure Load Balancer（内部）にアクセス。

```sh
curl http://10.240.0.113
```

```
<!DOCTYPE html>
<html>
<head>
<title>Welcome to nginx!</title>
...
```



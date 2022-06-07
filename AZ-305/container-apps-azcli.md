https://docs.microsoft.com/ja-jp/azure/container-apps/get-started?tabs=bash


# 初回のみ実施

```sh
az extension add --name containerapp --upgrade
az provider register --namespace Microsoft.App
az provider register --namespace Microsoft.OperationalInsights
```

# 「Container Apps環境」「コンテナーアプリ」を作成

```sh
name=app$(date|md5sum|head -c6)
location=japaneast

# リソースグループを作成
az group create -n $name -l $location

# 「Container Apps環境」を作成。Log Analyticsワークスペースは自動で作られる
az containerapp env create -n $name -g $name -l $location

# provisioningState が Waiting から Succeeded になるまで待つ
az containerapp env show -n $name -g $name --query 'properties.provisioningState' -o tsv

# 「コンテナーアプリ」を作成
az containerapp create -n $name -g $name --environment $name \
--image nginx --target-port 80 --ingress 'external'

# 「コンテナーアプリ」のURLを確認
url=$(az containerapp show -n $name -g $name --query properties.configuration.ingress.fqdn -o tsv)
echo https://$url
```

# 削除

```sh
# リソースグループを削除
az group delete -n $name --no-wait --yes
```

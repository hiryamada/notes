# Azure PowerShell

[ドキュメント](https://docs.microsoft.com/ja-jp/powershell/azure/)

Learn: [PowerShell の概要](https://docs.microsoft.com/ja-jp/learn/modules/introduction-to-powershell/)


[Azure Administrator対策「Azure PowerShellの命名規約」](https://ohina.work/post/az-103_powershell/)

実行注意: すべてのロックを削除し、すべてのリソースグループを削除（Cloud Shell用のストレージアカウントを除外）
```
Get-AzResourceLock | Remove-AzResourceLock -Force
Get-AzResourceGroup |Where-Object {$_.ResourceGroupName -notlike 'cloud-shell*'} |Remove-AzResourceGroup -Force -AsJob
```


# Azure CLI

[ドキュメント](https://docs.microsoft.com/ja-jp/cli/azure/)

コマンドの実行結果（JSON）から必要な部分を抽出したい場合は `--query` オプションを使用する。[JMESPath](https://jmespath.org/)の文法を使用する。[ドキュメント](https://docs.microsoft.com/ja-jp/cli/azure/query-azure-cli)

出力形式は`--output`, `--out`, `-o` で指定できる。json, jsonc, yaml, table, tsv, noneを指定できる。[ドキュメント](https://docs.microsoft.com/ja-jp/cli/azure/format-output-azure-cli)

```
az login
```

```
az account list
```

```
az account set \
--subscription "Visual Studio Enterprise サブスクリプション"
```

```
az group create \
--name testrg \
--location japaneast
```

```
az group delete \
--name testrg
```

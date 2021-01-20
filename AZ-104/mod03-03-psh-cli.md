# Azure PowerShell

[ドキュメント](https://docs.microsoft.com/ja-jp/powershell/azure/)



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

# ハンズオン: リソースのクリーンナップ

不要なリソースグループを一括削除する。

[Azure portalで、Cloud Shellを開く。](cloudshell.md)

以下のコマンドをCloud Shellに投入する。

このコマンドは、「winvm1_group」と「Cloud Shellで使用するストレージアカウントが含まれるリソースグループ」以外のリソースグループをすべて削除する。

```
az group list --query '[].name' --output tsv |grep -v winvm1_group |grep -v cloud-shell-storage |xargs -tl az group delete --no-wait --yes -g
```

解説:

```
az group list
   --query '[].name' # 各リソースグループの名前を抽出
   --output tsv # 出力する各行をタブ区切り(tab separated value)形式とする
```

```
grep -v cloud-shell-storage # 「cloud-shell-storage」が含まれていない行を選択
```

```
xargs -tl COMMAND # 入力された各行を引数として(-l)、COMMANDを実行。確認のため、各実行を出力(-t)
```

```
az group delete --no-wait --yes # リソースグループを確認なしで(--yes)削除。
```
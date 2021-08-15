
# リソース グループ

※注意: Azure ADではなくAzureサブスクリプションの話

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/manage-resource-groups-portal#what-is-a-resource-group

- リソース グループは、Azure ソリューションの関連するリソースを保持するコンテナー
- リソースをリソースグループにまとめることができる
- リソースグループを削除すると、中のリソースは同時に削除される
- 複数のリソースに対するロールやポリシーの設定をまとめることができる

# 管理グループ

※注意: Azure ADではなくAzureサブスクリプションの話

https://docs.microsoft.com/ja-jp/azure/governance/management-groups/overview

- 「管理グループ」と呼ばれるコンテナーにサブスクリプションを整理することができる。
- 最上位には「ルート管理グループ」が存在する
- 6段まで階層構造にできる
- 複数のサブスクリプションに対するロールやポリシーの設定をまとめることができる

```
管理グループ
└ サブスクリプション
  └ リソースグループ
    └ リソース
```

# サブスクリプション

※注意: Azure ADではなくAzureサブスクリプションの話

■クォータ

https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/azure-subscription-service-limits

サブスクリプション等には、作成できるリソース数などの上限値（クォータ）がある。

例: サブスクリプションには最大980個まで、リソースグループを作成できる など。

Azureサポートに問い合わせて、クォータの「引き上げ」を要求することができる。

例: Azure VMのvCPUクォータ制限の引き上げを要求する
https://docs.microsoft.com/ja-jp/azure/azure-portal/supportability/per-vm-quota-requests#request-a-standard-quota-increase-from-help--support

※「引き上げ」ができない「ハードリミット」も存在する。サブスクリプションのハードリミットに近づいた場合は、サブスクリプションそのものを追加して対応する。


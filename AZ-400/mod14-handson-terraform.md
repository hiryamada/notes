# Terraform ハンズオン

■構成ファイルの例（リソースグループの作成）
```
provider azurerm {
  features {}
}

resource "azurerm_resource_group" "test" {
 name     = "terraformTestResourceGroup"
 location = "East US"
}
```

■手順（Azure Cloud Shellを使用）

- 上記の構成ファイル(sample.tf)を作成
- `terraform init`
- `terraform plan`
- `terraform apply -auto-approve`
- コマンドの実行が完了してから、Azure portal側の一覧に反映されるまで、1分ほどかかる。
- Azure portalの「リソースグループ」画面で、リソースグループが作成されたことを確認

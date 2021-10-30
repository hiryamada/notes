

# Terraform


[公式サイト](https://www.terraform.io/)

[HashiCorp社](https://www.hashicorp.com/)が開発する構成管理ツール。

[テラフォーミング](https://ja.wikipedia.org/wiki/%E3%83%86%E3%83%A9%E3%83%95%E3%82%A9%E3%83%BC%E3%83%9F%E3%83%B3%E3%82%B0)

■特徴

- [Goで実装](https://github.com/hashicorp/terraform)。
- 「プロバイダー」を使用して機能を拡張できる。
  - [Azureプロバイダー](https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs)
- 冪等性をツール側で保証。
- HCL(HashiCorp Configuration Language)を使用して構成を定義。
  - ～.tf という名前で保存
- コマンド（terraform）がCloud Shellにインストール済みで、すぐに利用できる

■製品群

- [Terraform CLI](https://www.terraform.io/docs/cli/index.html)
- [Terraform Cloud](https://www.terraform.io/cloud)
  - Cloud infrastructure automation as a Service（サービスとしてのクラウド自動化）
  - 複数のクラウドプロバイダー（Azure, AWS, GCP等）を一箇所からコントロール
  - チームや組織でTerraformを利用する場合におすすめ
- [Terraform Enterprise](https://www.terraform.io/docs/enterprise/index.html)
  - セルフホストのTerraform Cloud

■構成ファイルの例
```
provider azurerm {
  features {}
}

resource "azurerm_resource_group" "test" {
 name     = "terraformTestResourceGroup"
 location = "East US"
}
```

■使用手順（Azure Cloud Shell）

- 構成ファイル(～.tf)を作成
- `terraform init`
- `terraform plan`
- `terraform apply -auto-approve`
- コマンドの実行が完了してから、Azure portal側の一覧に反映されるまで、1分ほどかかる。

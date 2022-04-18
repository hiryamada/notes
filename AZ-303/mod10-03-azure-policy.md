# Azure Policy

リソースに対してポリシー（ルール）を設定し、評価。

https://docs.microsoft.com/ja-jp/azure/governance/policy/overview

2016/4/15、一般提供開始。https://azure.microsoft.com/en-us/blog/azure-resource-policy-ga/

2017/11/20、いくつかの機能が追加された。https://azure.microsoft.com/en-us/blog/recap-on-new-azure-policy-features-in-ignite/

- 継続的なモニタリングのためのUI
- イニシアチブ
- 追加の「効果」
  - AuditIfNotExists
  - DeployIfNotExists

[まとめPDF](../AZ-104/pdf/mod02/ロール・ポリシー全体像.pdf)


■ポリシーでできることの例

サブスクリプションで作成できるVMのサイズを制限する(Deny)

VMに「[マルウェア対策拡張機能](https://docs.microsoft.com/ja-jp/azure/virtual-machines/extensions/iaas-antimalware-windows)」が追加されていなければ追加する([DeployIfNotExists](https://docs.microsoft.com/ja-jp/azure/governance/policy/concepts/effects#deployifnotexists))

■ポリシーの定義の例


「許可されている仮想マシンSKU」ポリシーの例

```
{
  "if": {
    "allOf": [
      {
        "field": "type",
        "equals": "Microsoft.Compute/virtualMachines"
      },
      {
        "not": {
          "field": "Microsoft.Compute/virtualMachines/sku.name",
          "in": [ "Standard_A0", "Standard_A1" ]
        }
      }
    ]
  },
  "then": {
    "effect": "Deny"
  }
}
```

- if: リソースのプロパティに対する条件を指定。
- then: 条件が成立した場合の「効果」を指定。


■ポリシーの「パラメータ」

https://docs.microsoft.com/ja-jp/azure/governance/policy/samples/pattern-parameters

パラメータ「listOfAllowedSKUs」の定義例
```
"parameters": {
    "listOfAllowedSKUs": {
    "type": "Array",
    "allowedValues": [
      "Standard_DS1_v2",
      "Standard_DS3_v2",
      "Standard_DS5_v2"
    ],
    "metadata": {
      "displayName": "Allowed SKUs",
      "description": "The list of SKUs that can be specified for virtual machines."
    }
  }
}
```

パラメータ「listOfAllowedSKUs」の利用例
```
{
  "if": {
    "allOf": [
      {
        "field": "type",
        "equals": "Microsoft.Compute/virtualMachines"
      },
      {
        "not": {
          "field": "Microsoft.Compute/virtualMachines/sku.name",
          "in": "[parameters('listOfAllowedSKUs')]"
        }
      }
    ]
  },
  "then": {
    "effect": "Deny"
  }
}
```

ポリシーの利用時（たとえばリソースグループなどのスコープに割り当てる際）に、管理者は、パラメータ「listOfAllowedSKUs」の値を「allowedValues」で指定された値から選んで指定することができる。

■ポリシーの「効果」

https://docs.microsoft.com/ja-jp/azure/governance/policy/concepts/effects

■ポリシーの割り当て


管理グループ、サブスクリプション、リソースグループ、リソースにポリシーを割り当てできる。

※リソースへのポリシー割り当て：リソースによる。VM等では可能。ストレージアカウント、VNet等では不可能。


■カスタムポリシー

https://docs.microsoft.com/ja-jp/azure/governance/policy/tutorials/create-custom-policy-definition

Azureが提供する「組み込みポリシー」を利用するだけではなく、「カスタムポリシー」を定義して利用することもできる。

■GitHubの、Azureポリシーのサンプルのコレクション

https://github.com/Azure/azure-policy

このリポジトリには多数のAzureポリシーの定義が登録されている。

Azure portal上からGitHubへポリシー定義をエクスポートしたり、GitHub上で更新されたポリシー定義をAzureにプッシュ（取り込み）したりすることができる。

https://docs.microsoft.com/ja-jp/azure/governance/policy/tutorials/policy-as-code-github

■イニシアチブ

ポリシーのグループ。

多数のポリシーを「イニシアチブ」として定義したり、「イニシアチブ」を（ポリシーと同じように）スコープに割り当てて利用することができる。


Azureが提供する、組み込みの「イニシアチブ」も利用することができる。（規制コンプライアンス）

https://docs.microsoft.com/ja-jp/azure/governance/policy/samples/#regulatory-compliance

例: クレジットカード会員データを安全に取り扱う事を目的として策定されたセキュリティ標準である[PCI-DSS(Payment Card Industry Data Security Standard)](https://www.jcdsc.org/pci_dss.php) コンプライアンスを実現するのに役立つイニシアチブがAzureによって提供されている。「Azureブループリント」にイニシアチブが組み込まれている。

https://docs.microsoft.com/ja-jp/azure/governance/blueprints/samples/pci-dss-3.2.1/

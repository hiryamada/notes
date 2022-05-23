# ラーニングパス 1: [AZ-104:Azure 管理者向けの前提条件](https://docs.microsoft.com/ja-jp/learn/paths/az-104-administrator-prerequisites/)
## モジュール 1: [ツールを使用して Azure リソースを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-resources-tools/)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-resources-tools/6-knowledge-check)
  - 第1問 リソースを繰り返しデプロイしない場合: Azure portal(正解)を使用する. リソースを繰り返しデプロイする場合: Azure CLI, Azure PowerShellを使用して、コマンドをスクリプト化する。
  - 第2問 Azure CLI / Azure PowerShell は、Windows, Linux, Macにインストールできる。[Azure CLI](https://docs.microsoft.com/ja-jp/cli/azure/install-azure-cli), [Azure PowerShell](https://docs.microsoft.com/ja-jp/powershell/azure/install-az-ps?view=azps-7.5.0)
  - 第3問 ローカルPC等にAzure PowerShellをインストールし、起動した場合、[はじめに Connect-AzAccount を使用してサインインする必要がある。](https://docs.microsoft.com/ja-jp/powershell/azure/authenticate-azureps?view=azps-0.10.0)
## モジュール 2: [Azure Resource Manager を使用する](https://docs.microsoft.com/ja-jp/learn/modules/use-azure-resource-manager/)
- ユニット 9: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/use-azure-resource-manager/9-knowledge-check)
  - 第1問 まとめて管理するリソースは、1つのリソースグループに入れて管理するとよい。リソースグループを削除すると、リソースグループに含まれるリソースがまとめて削除される。リソースグループに対し、ロールを適用したり、ポリシーを適用したりできる。
  - 第2問 リソースロックを使用すると、リソースを誤った削除などから保護できる。ExpressRoute回路（オンプレとAzureをつなぐ専用線を表すリソース）などは、一度作成したら基本的に削除することがないため、リソースロックをかけて保護する。
  - 第3問 リソースグループは、入れ子にすることができない。（リソースグループの中にリソースグループを作ることはできない）
## モジュール 3: [Azure Resource Manager テンプレートを使用してリソースを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-resources-arm-templates/)
- ユニット 7: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-resources-arm-templates/7-knowledge-check)
  - 第1問 ARMテンプレートはJSONファイルであり、Azureの複数のリソースをまとめて定義し、デプロイ（リソースを作成）できる。
  - 第2問 ARMテンプレートの最上位の要素には「parameters」「resources」「outputs」などが含まれる。
  - 第3問 あるARMテンプレートを2回デプロイしてもエラーは起きず、リソースに変更は生じない。
## モジュール 4: [PowerShell でスクリプトを使用して Azure タスクを自動化する](https://docs.microsoft.com/ja-jp/learn/modules/automate-azure-tasks-with-powershell/)
- ユニット 9: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/automate-azure-tasks-with-powershell/9-summary)
  - ※ページの下の方に知識チェックがあります
  - 第1問 Azure portal, Azure CLI, Azure PowerShell は、いずれも、Azureのほとんど全てのサービスを操作する機能を提供する。
  - 第2問 リソースを繰り返しデプロイしない場合: Azure portal(正解)を使用する. リソースを繰り返しデプロイする場合: Azure CLI, Azure PowerShellを使用して、コマンドをスクリプト化する。
  - 第3問 あるコンピュータでAzure PowerShellモジュールを利用するには、まずそのコンピュータに.NETとPowerShellがインストールされている必要がある。
## モジュール 5: [CLI を使用した Azure サービスの制御](https://docs.microsoft.com/ja-jp/learn/modules/control-azure-services-with-cli/)
- ユニット 6: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/control-azure-services-with-cli/6-summary)
  - ※ページの下の方に知識チェックがあります
  - 第1問 あるコンピュータでAzure CLIを利用するには、Azure CLIをインストールすればよい。（.NETやPowerShellは不要）
  - 第2問 Azure CLI は、Linux、macOS、および Windows にインストールできる。使用するコマンドはすべてのプラットフォームで同じである。
  - 第3問 Azure CLIで情報を表示する際に「--output table」を使用すると、テーブル形式でわかりやすく情報を表示することができる。
## モジュール 6: [JSON ARM テンプレートを使用して Azure インフラストラクチャをデプロイする](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resource-manager-template-vs-code/)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resource-manager-template-vs-code/6-knowledge-check)
  - 第1問 ARMテンプレートはJSONファイルであり、Azureの複数のリソースをまとめて定義し、デプロイ（リソースを作成）できる。
  - 第2問 ARMテンプレートの最上位の要素には「parameters」「resources」「outputs」などが含まれる。
  - 第3問 あるARMテンプレートを2回デプロイしてもエラーは起きず、リソースに変更は生じない。

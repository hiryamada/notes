
[→ ラーニングパス2](lp2.md)

- ラーニングパス1 Azure 管理者向けの前提条件
  - [Azure portal](mod03-02-portal.md)
  - [Azure Resource Manager](mod03-01-arm.md)
    - リソースグループ
    - ロック
    - ARMテンプレート
  - Azure PowerShell
  - Azure CLI
- [知識チェック](lp1-check.md)
- ラボ
  - 事前に「[ラボで使用するファイル](https://github.com/MicrosoftLearning/AZ-104-MicrosoftAzureAdministrator.ja-jp/archive/refs/heads/main.zip)」(ZIP)をダウンロードして、適当な場所に展開してください。展開すると「AllFiles」というフォルダがあり、その中に、ラボに必要なファイルが含まれています。
  - 手順書で「ラボ コンピューター」と書かれている場合は「現在ご受講に使用しているコンピュータ」と読み替えてください。
  - [3a: Azure portal](https://github.com/MicrosoftLearning/AZ-104-MicrosoftAzureAdministrator.ja-jp/blob/main/Instructions/Labs/LAB_03a-Manage_Azure_Resources_by_Using_the_Azure_Portal.md)
    - 概要: Azure portalを使用して、VMで使用する「ディスク」を作成します。
  - [3b: ARMテンプレート](https://github.com/MicrosoftLearning/AZ-104-MicrosoftAzureAdministrator.ja-jp/blob/main/Instructions/Labs/LAB_03b-Manage_Azure_Resources_by_Using_ARM_Templates.md)
    - 概要: 作成済みのディスクからARMテンプレートをエクスポートし（「ディスク＞テンプレートのエクスポート」からコピー）、「カスタム テンプレートのデプロイ」画面で、ARMテンプレートを使用して、同じリソースをデプロイします。
  - [3c: Azure PowerShell](https://github.com/MicrosoftLearning/AZ-104-MicrosoftAzureAdministrator.ja-jp/blob/main/Instructions/Labs/LAB_03c-Manage_Azure_Resources_by_Using_Azure_PowerShell.md)
    - 概要: Cloud Shell内でAzure PowerShellを使用して、ディスクを作成します。リソースグループ「az104-03b-rg1」（リージョン: eastus）は予め作成しておきます。
  - [3d: Azure CLI](https://github.com/MicrosoftLearning/AZ-104-MicrosoftAzureAdministrator.ja-jp/blob/main/Instructions/Labs/LAB_03d-Manage_Azure_Resources_by_Using_Azure_CLI.md)
    - 概要: Cloud Shell内でAzure CLIを使用してディスクを作成します。

# ラーニングパス 1: [AZ-104:Azure 管理者向けの前提条件](https://docs.microsoft.com/ja-jp/learn/paths/az-104-administrator-prerequisites/)
## モジュール 1: [ツールを使用して Azure リソースを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-resources-tools/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-resources-tools/1-introduction)
- ユニット 2: [Azure ポータルの使用](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-resources-tools/2-use-azure-portal)
- ユニット 3: [Azure Cloud Shell の使用](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-resources-tools/3-use-azure-cloud-shell)
- ユニット 4: [Azure PowerShell の使用](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-resources-tools/4-use-azure-powershell)
- ユニット 5: [Azure CLI の使用](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-resources-tools/5-use-azure-cli)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-resources-tools/6-knowledge-check)
- ユニット 7: [まとめとリソース](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-resources-tools/7-summary-resources)
## モジュール 2: [Azure Resource Manager を使用する](https://docs.microsoft.com/ja-jp/learn/modules/use-azure-resource-manager/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/use-azure-resource-manager/1-introduction)
- ユニット 2: [Azure Resource Manager の利点を確認する](https://docs.microsoft.com/ja-jp/learn/modules/use-azure-resource-manager/2-review-benefits)
- ユニット 3: [Azure リソースの用語を確認する](https://docs.microsoft.com/ja-jp/learn/modules/use-azure-resource-manager/3-review-terminology)
- ユニット 4: [リソース グループを作成する](https://docs.microsoft.com/ja-jp/learn/modules/use-azure-resource-manager/4-create-resource-groups)
- ユニット 5: [Azure Resource Manager ロックを作成する](https://docs.microsoft.com/ja-jp/learn/modules/use-azure-resource-manager/5-create-locks)
- ユニット 6: [Azure リソースを再構成する](https://docs.microsoft.com/ja-jp/learn/modules/use-azure-resource-manager/6-reorganize-azure-resources)
- ユニット 7: [リソースとリソース グループを削除する](https://docs.microsoft.com/ja-jp/learn/modules/use-azure-resource-manager/7-remove-resources-groups)
- ユニット 8: [リソース制限を決定する](https://docs.microsoft.com/ja-jp/learn/modules/use-azure-resource-manager/8-determine-resource-limits)
- ユニット 9: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/use-azure-resource-manager/9-knowledge-check)
- ユニット 10: [まとめとリソース](https://docs.microsoft.com/ja-jp/learn/modules/use-azure-resource-manager/10-summary-resources)
## モジュール 3: [Azure Resource Manager テンプレートを使用してリソースを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-resources-arm-templates/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/configure-resources-arm-templates/1-introduction)
- ユニット 2: [Azure Resource Manager テンプレートの利点についての確認](https://docs.microsoft.com/ja-jp/learn/modules/configure-resources-arm-templates/2-review-template-advantages)
- ユニット 3: [Azure Resource Manager テンプレート スキーマについて詳しく知る](https://docs.microsoft.com/ja-jp/learn/modules/configure-resources-arm-templates/3-explore-template-schema)
- ユニット 4: [Azure Resource Manager テンプレートのパラメーターについて詳しく知る](https://docs.microsoft.com/ja-jp/learn/modules/configure-resources-arm-templates/4-explore-template-parameters)
- ユニット 5: [Bicep テンプレートを検討する](https://docs.microsoft.com/ja-jp/learn/modules/configure-resources-arm-templates/5-consider-bicep-templates)
- ユニット 6: [クイックスタート テンプレートの確認](https://docs.microsoft.com/ja-jp/learn/modules/configure-resources-arm-templates/6-review-quickstart-templates)
- ユニット 7: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-resources-arm-templates/7-knowledge-check)
- ユニット 8: [まとめとリソース](https://docs.microsoft.com/ja-jp/learn/modules/configure-resources-arm-templates/8-summary-resources)
## モジュール 4: [PowerShell でスクリプトを使用して Azure タスクを自動化する](https://docs.microsoft.com/ja-jp/learn/modules/automate-azure-tasks-with-powershell/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/automate-azure-tasks-with-powershell/1-introduction)
- ユニット 2: [Azure PowerShell がタスクに合っているかどうかを判断する](https://docs.microsoft.com/ja-jp/learn/modules/automate-azure-tasks-with-powershell/2-decide-if-azure-powershell-is-right-for-your-tasks)
- ユニット 3: [PowerShell をインストールする](https://docs.microsoft.com/ja-jp/learn/modules/automate-azure-tasks-with-powershell/3-install-azure-powershell)
- ユニット 4: [演習 - Azure PowerShell をインストールする](https://docs.microsoft.com/ja-jp/learn/modules/automate-azure-tasks-with-powershell/4-exercise-install-azure-powershell)
- ユニット 5: [Azure PowerShell でスクリプトを使用して Azure リソースを作成する](https://docs.microsoft.com/ja-jp/learn/modules/automate-azure-tasks-with-powershell/5-create-resource-interactively)
- ユニット 6: [演習 - Azure PowerShell でスクリプトを使用して Azure リソースを作成する](https://docs.microsoft.com/ja-jp/learn/modules/automate-azure-tasks-with-powershell/6-exercise-create-resource-interactively)
- ユニット 7: [Azure PowerShell でスクリプトを作成して保存する](https://docs.microsoft.com/ja-jp/learn/modules/automate-azure-tasks-with-powershell/7-create-resource-using-script)
- ユニット 8: [演習 - Azure PowerShell でスクリプトを作成して保存する](https://docs.microsoft.com/ja-jp/learn/modules/automate-azure-tasks-with-powershell/8-exercise-create-resource-using-script)
- ユニット 9: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/automate-azure-tasks-with-powershell/9-summary)
## モジュール 5: [CLI を使用した Azure サービスの制御](https://docs.microsoft.com/ja-jp/learn/modules/control-azure-services-with-cli/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/control-azure-services-with-cli/1-introduction)
- ユニット 2: [Azure CLI とは](https://docs.microsoft.com/ja-jp/learn/modules/control-azure-services-with-cli/2-what-is-the-azure-cli)
- ユニット 3: [演習 - Azure CLI をインストールして実行する](https://docs.microsoft.com/ja-jp/learn/modules/control-azure-services-with-cli/3-exercise-install-and-run-the-azure-cli)
- ユニット 4: [Azure CLI を使用する](https://docs.microsoft.com/ja-jp/learn/modules/control-azure-services-with-cli/4-work-with-the-cli)
- ユニット 5: [演習 - CLI を使用して Azure Web サイトを作成する](https://docs.microsoft.com/ja-jp/learn/modules/control-azure-services-with-cli/5-exercise-create-website-using-the-cli)
- ユニット 6: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/control-azure-services-with-cli/6-summary)
## モジュール 6: [JSON ARM テンプレートを使用して Azure インフラストラクチャをデプロイする](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resource-manager-template-vs-code/)
- ユニット 1: [はじめに](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resource-manager-template-vs-code/1-introduction)
- ユニット 2: [Azure Resource Manager テンプレート構造を探索する](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resource-manager-template-vs-code/2-explore-template-structure)
- ユニット 3: [演習 - Azure Resource Manager テンプレートを作成してデプロイする](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resource-manager-template-vs-code/3-exercise-create-and-deploy-template)
- ユニット 4: [パラメーターと出力を使用して Azure Resource Manager テンプレートの柔軟性を高める](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resource-manager-template-vs-code/4-add-flexibility-arm-template)
- ユニット 5: [演習 - Azure Resource Manager テンプレートにパラメーターと出力を追加する](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resource-manager-template-vs-code/5-exercise-parameters-output)
- ユニット 6: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resource-manager-template-vs-code/6-knowledge-check)
- ユニット 7: [まとめ](https://docs.microsoft.com/ja-jp/learn/modules/create-azure-resource-manager-template-vs-code/7-summary)

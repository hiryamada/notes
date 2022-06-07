- サブスクリプションの整理、設定の共通化
  - [管理グループ](https://docs.microsoft.com/ja-jp/azure/governance/management-groups/overview)を使用
  - ```
     ルート管理グループ 監査担当者: Reader
     └事業部（複数）
        └部門（複数）
          └サブスクリプション（複数）
    ```
- 監査用のロール
  - Azure（管理グループ以下）: [Azureロール](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/rbac-and-directory-admin-roles#azure-roles)の「Reader」（閲覧者）
  - Azure AD（テナント）: [「グローバル閲覧者」](https://docs.microsoft.com/ja-jp/azure/active-directory/roles/permissions-reference#global-reader)
- VMサイズ
  - [VM用のAzure Policy](https://docs.microsoft.com/ja-jp/azure/virtual-machines/policy-reference#microsoftcompute)
  - 「許可されている仮想マシン サイズ SKU」を割り当てる
- 名前付け
  - [名前付け規則を定義する](https://docs.microsoft.com/ja-jp/azure/cloud-adoption-framework/ready/azure-best-practices/resource-naming)
    - 例
      - VM: vmsqlnode001 (vm sql node 001)
      - ストレージアカウント: stnavigatordata001 (st navigator data 001)
      - SQL Database: sql-navigator-prod
  - [名前付けルールのためのAzureポリシー](https://github.com/matthiasguentert/azure-naming-convention-initiative)
    - 例: `rg-*` というパターンの名前ではないリソースグループの作成を禁止

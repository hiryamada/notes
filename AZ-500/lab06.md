# ラボ6

## ラボの重要ポイント

「SQL Server」の中に、「SQLデータベース」があります。

- タスク1
  - ARMテンプレートを使用してSQL ServerとSQLデータベースをデプロイします。
- タスク2
  - [Azure Defender for SQL](https://docs.microsoft.com/ja-jp/azure/azure-sql/database/azure-defender-for-sql)を、サブスクリプションレベルで有効化します。
    - この操作は「セキュリティセンター」から行います。
    - サブスクリプションに含まれるSQL Serverが、Azure Defender for SQLで保護されます
    - Azure Defender for SQLの機能
      - 脆弱性評価: 潜在的な脆弱性（ベストプラクティスに則っていない設定）を検出
      - Advanced Threat Protection(ATP): SQLインジェクション攻撃などを検出
- タスク3 
  - データベースのテーブルの、個人情報などが入力されている列を自動的に検出します。
  - 検出した列に「機密ラベル」を付けます。
- タスク4 
  - サーバーで、監査を有効化します。
  - 監査ログの保存先としてストレージアカウントを設定します。
  - サーバーの監査レコードとデータベースの監査レコードの表示方法を確認します。
    - 実際の監査レコードは、このラボでは確認できません。


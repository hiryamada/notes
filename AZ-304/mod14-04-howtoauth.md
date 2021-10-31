
# ベストプラクティスの「[キーよりも Azure AD認証を選ぶ](https://docs.microsoft.com/ja-jp/security/compass/applications-services#prefer-identity-authentication-over-keys)」について（重要）

再掲: アプリケーション（のコード、設定ファイル、環境変数など）に「パスワード」「アクセスキー」「認証キー」「APIキー」「接続文字列」を持たせない。

- 暗号化キーではなく Azure ADで認証する
- 例: ストレージアカウントのアクセス
  - アクセスキー
    - キーの漏洩のリスクがある
      - 定期的なローテーションが必要
    - 細かい権限割り当てができない（フルアクセス）
  - Azure AD認証 + Azure RBACロール
    - マネージドIDを使用
      - IDやパスワード、キーを使用する必要がない
      - 漏洩の心配がない
      - キーのローテーションが不要
    - RBACロールを使用して、詳細な権限割り当てが可能
    - RBACロールを特定のスコープで割り当てることができる


(1)サービスへのアクセスに、Azure AD認証が使えない場合は、Key Vaultを使用する。

例: Azure Table Storageのアクセス

- ストレージアカウント（Table）へのアクセス方法: 共有キー承認（アクセスキー）
- アプリケーションのIDに割り当てるロール: [Key Vault Secrets User](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#key-vault-secrets-user)

```
Azure Key Vault ＋ ストレージアカウントのアクセスキー
↑
アプリケーション＋マネージドID＋「Key Vault Secrets User」ロール
↓
ストレージアカウント（Table）
```

※現在、Azure Table Storageのアクセスでも「Azure AD認証」が利用できるようになっている。2021/10/31現時点ではプレビュー。
https://docs.microsoft.com/ja-jp/azure/storage/tables/authorize-managed-identity

(2)サービスへのアクセスに、Azure AD認証が使用できる場合は、Azure AD認証を使用する。

例: Azure Blob Storageへのアクセス

- ストレージアカウント（Table）へのアクセス方法: Azure AD認証＋ロール
- 使用するロール: [ストレージ BLOB データ共同作成者](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#storage-blob-data-contributor)

```
アプリケーション＋マネージドID＋「ストレージ BLOB データ共同作成者」ロール
↓
ストレージアカウント（Blob）
```

[Azure AD認証をサポートしているサービスの一覧](https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/services-support-managed-identities#azure-services-that-support-azure-ad-authentication)

(3)可能な場合、Azure Storage アカウントの共有キーによる承認を禁止する
https://docs.microsoft.com/ja-jp/azure/storage/common/shared-key-authorization-prevent
組み込みロールの一覧
https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles

Azure リソース プロバイダーの操作（アクションの一覧）
https://docs.microsoft.com/ja-jp/azure/role-based-access-control/resource-provider-operations

Azure リソースのマネージド ID をサポートする Azure サービス
https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/services-support-managed-identities#azure-services-that-support-managed-identities-for-azure-resources

Azure AD 認証をサポートしている Azure サービス
https://docs.microsoft.com/ja-jp/azure/active-directory/managed-identities-azure-resources/services-support-managed-identities


■リソースプロバイダーとオペレーション

```
Group
    az provider : Manage resource providers.

Subgroups:
    operation  : Get provider operations metadatas.
    permission : Manage permissions for a provider.

Commands:
    list       : Gets all resource providers for a subscription.
    register   : Register a provider.
    show       : Gets the specified resource provider.
    unregister : Unregister a provider.
```

■ロール/カスタムロール

```
Group
    az role : Manage user roles for access control with Azure Active Directory and service
    principals.

Subgroups:
    assignment : Manage role assignments.
    definition : Manage role definitions.
```

■マネージドID

```
Group
    az identity : Managed Service Identities.

Commands:
    create          : Create or update an identity in the specified subscription and resource group.
    delete          : Deletes the identity.
    list            : List Managed Service Identities.
    list-operations : Lists available operations for the Managed Identity provider.
    show            : Gets the identity.
```

ユーザー割り当てマネージドIDの作成: az identity create

システム割り当てマネージドIDの作成:

```
# VM
az vm create --assign-identity
az vm identity assign

# App Service
az webapp create --assign-identity
az webapp identity assign

# Azure Functions
az functionapp create --assign-identity
az functionapp identity assign

# Logic App
az logic ???

```


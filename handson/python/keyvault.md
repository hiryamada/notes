# Key Vaultアクセス例

使用するライブラリ
```
pip install azure-identity
pip install azure-keyvault-secrets
```

コード例
```
from azure.identity import DefaultAzureCredential
from azure.keyvault.secrets import SecretClient

cred = DefaultAzureCredential()
endpoint = "https://handsonkv9837423.vault.azure.net/"

client = SecretClient(endpoint, cred)

connection_string = client.get_secret("StorageAccountConnectionString")

print(connection_string.value)

```

参考
https://docs.microsoft.com/ja-jp/azure/key-vault/secrets/quick-create-python
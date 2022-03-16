# Ansible ハンズオン

■プレイブック（sample.yml）

```
- name: example
  hosts: localhost
  connection: local
  tasks:
  - name: Create resource group
    azure_rm_resourcegroup:
      name: ansibleTestResouceGroup
      location: eastus
```

■手順（Azure Cloud Shellを使用）

- 上記のプレイブック（sample.yml）を作成
- `ansible-playbook sample.yml`
- コマンドの実行が完了してから、Azure portal側の一覧に反映されるまで、1分ほどかかる。
- Azure portalの「リソースグループ」画面で、リソースグループが作成されたことを確認

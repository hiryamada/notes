■概要

```
VM ←管理 / 接続
↓
Azure AD認証をサポートするサービス
```


■VMにマネージドIDを割り当てる

https://docs.microsoft.com/ja-jp/cli/azure/vm?view=azure-cli-latest#az_vm_create

```
az vm create --assign-identity
az vm identity assign 

az vmss create --assign-identity
az vmss identity assign
```

■VMの管理・接続のためのロール

- [Virtual Machine Administrator Login](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#virtual-machine-administrator-login)
  - ポータルで仮想マシンを表示し、管理者としてログインします。
- [Virtual Machine User Login](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#virtual-machine-user-login)
  - ポータルで仮想マシンを表示し、通常のユーザーとしてログインします。
- [Virtual Machine Contributor](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/built-in-roles#virtual-machine-contributor)
  - 仮想マシンの作成と管理、ディスクとディスクのスナップショットの管理、ソフトウェアのインストールと実行、VM 拡張機能を使用した仮想マシンのルート ユーザーのパスワードのリセット、VM 拡張機能を使用したローカル ユーザー アカウントの管理を行います


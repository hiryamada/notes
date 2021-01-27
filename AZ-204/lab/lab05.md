# 演習（エクササイズ）1

タスク4-1:以下のように、`--admin-username` を省略すると、ユーザー名は現在のユーザーとなります。また、`--admin-password` の代わりに `--generate-ssh-keys` を指定すると、パスワードではなく公開鍵認証で接続することができます。秘密鍵は `~/.ssh` 以下に保存されます。`ssh {VMのIPアドレス}` で接続できます。

```
az vm create -g ContainerCompute -n quickvm --image Debian --generate-ssh-keys
```

# 演習（エクササイズ）2

タスク2-8

`Dockerfile` の `FROM` 行は以下のように変更してください。

```
FROM mcr.microsoft.com/dotnet/sdk:3.1-alpine AS build
```

# 演習（エクササイズ）3

タスク1-5

設定＞アクセスキー＞管理者ユーザー

と辿ると、「管理者」があります。

保存ボタンはありません。



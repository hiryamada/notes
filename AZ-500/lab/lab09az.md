# Azure CLI 2.26.0で発生する問題のワークアラウンド

2021/7/28

ラボ9 タスク2-2 で、`az acr build` ... を実行すると、以下のようなエラーとなります.

```
$ az acr build --image sample/nginx:v1 --registry $ACRNAME --file Dockerfile .
Packing source code into tar to upload...
Uploading archived source code from '/tmp/build_archive_029059cc8d82455a89350f319ca0c5d1.tar.gz'...
Sending context (55.394 KiB) to registry: az5001494516883...
The command failed with an unexpected error. Here is the traceback:
'NoneType' object is not callable
Traceback (most recent call last):
  File "/opt/az/lib/python3.6/site-packages/knack/cli.py", line 231, in invoke
    cmd_result = self.invocation.execute(args)
  File "/opt/az/lib/python3.6/site-packages/azure/cli/core/commands/__init__.py", line 657, in execute
    raise ex
  File "/opt/az/lib/python3.6/site-packages/azure/cli/core/commands/__init__.py", line 720, in _run_jobs_serially
    results.append(self._run_job(expanded_arg, cmd_copy))
  File "/opt/az/lib/python3.6/site-packages/azure/cli/core/commands/__init__.py", line 691, in _run_job
    result = cmd_copy(params)
  File "/opt/az/lib/python3.6/site-packages/azure/cli/core/commands/__init__.py", line 328, in __call__
    return self.handler(*args, **kwargs)
  File "/opt/az/lib/python3.6/site-packages/azure/cli/core/commands/command_operation.py", line 121, in handler
    return op(**command_args)
  File "/opt/az/lib/python3.6/site-packages/azure/cli/command_modules/acr/build.py", line 109, in acr_build
    variant=platform_variant
TypeError: 'NoneType' object is not callable
To open an issue, please run: 'az feedback'
```

以下の問題に該当するようです。
https://github.com/Azure/azure-cli/issues/18963

このIssueによれば、

- 現在 Azure Cloud Shell に組み込まれている Azure CLI の 2.26.0 で問題が発生します。
- 最新版 Azure CLI の 2.26.1(最新版) では、問題が解消されるようです。
- 8月3日に、Azure Cloud Shell のアップデートで、この問題の解決が行われるようです。

Azure Cloud Shell で、`az --version` を実行して、現在のAzure CLIのバージョンを確認できます。

（以降、表示しているコマンド例の`$` 以降の1行を入力します。2行目以降はコマンドの出力例です。）

```
$ az --version
azure-cli                         2.26.0 *
...
```

以下のコマンドで、Azure Cloud Shellに、Azure CLIの 2.26.1(最新版)をインストールできます。途中、何度か質問が出ますが、すべてエンターキーを押して進めます。

```
$ curl -L https://aka.ms/InstallAzureCli | bash
```

インストール後、2.26.0 と 2.26.1(最新版) が両方ともインストールされた状態となります。以下のようにエイリアスを設定して、インストールした最新版のAzure CLIを使用するように設定します。（Cloud Shellを閉じたりした場合は、再度このコマンドの実行が必要です）

```
$ alias az=~/bin/az
```

エイリアスの設定が終わったら、再度 `az --version` を実行して、今度は 2.26.1(最新版) が実行されることを確認します。

```
$ az --version
azure-cli                         2.26.1
...
```

この状態ですと、`az acr build`が問題なく進行します。

```
$ az acr build --image sample/nginx:v1 --registry $ACRNAME --file Dockerfile.
Packing source code into tar to upload...
Uploading archived source code from '/tmp/build_archive_ee11eb8857db4d5fa21f9635f8af2453.tar.gz'...
Sending context (95.528 MiB) to registry: az5001155612922...
Queued a build with ID: ca1
Waiting for an agent...
2021/07/28 13:18:58 Downloading source code...

...(略)...

Run ID: ca1 was successful after 1m12s
```

皆様、大変お手数をおかけいたしました。情報を共有いただきまして、ありがとうございます。

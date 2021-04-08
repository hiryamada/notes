# ラボ8

想定時間: 90分

VM, VMSSの各種設定を学習します。

（まだ準備していない場合）事前に[ラボのファイル](https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/archive/master.zip)をダウンロードして展開しておきましょう。

## ラボの重要ポイント

- タスク1
  - 可用性ゾーン1にvm0をデプロイします。
  - vm0の「デプロイ」画面の「テンプレート」で「デプロイ」をクリックし、パラメータの値を一部書き換えてデプロイします。これによりvm1がデプロイされます。
- タスク2
  - タスク1で[ブート診断](https://docs.microsoft.com/ja-jp/troubleshoot/azure/virtual-machines/boot-diagnostics)のために作成したストレージアカウントを流用して、PowerShellスクリプトを配置するためのコンテナーを作成します
  - カスタムスクリプト拡張機能を使い、vm0にスクリプトを適用します。スクリプトによりWebサーバー（IIS）がセットアップされます。
  - vm1のテンプレートにカスタムスクリプト拡張機能のリソースを追記して、デプロイすることで、vm1にスクリプトを適用します。
  - vm1の「実行コマンド」を使用して、PowerShellの「Invoke-WebRequest」を実行し、vm0, vm1のWebサーバーにアクセスして動作を確認します。
  - なお、vm0/vm1ともパブリックIPアドレスを持っていますが、NICに関連付けられたネットワークセキュリティグループでHTTPの受信を許可していないので、パブリックIPアドレスではアクセスできません。
- タスク3
  - vm0のサイズを変更します。
  - vm0に2つのデータディスク（各1TB）を接続します。
  - コマンドを使用して、2つのディスクを束ねて、2TBの[「シンプル」記憶域スペース](https://docs.microsoft.com/ja-jp/windows-server/storage/storage-spaces/deploy-standalone-storage-spaces)を作成します。
  - vm1のテンプレートにて、VMのサイズの指定を変更し、さらに2台のデータディスクのリソースを追記して、デプロイすることで、vm1のサイズ変更とディスクの追加を行います。その後、vm0と同様にコマンドを使用してシンプル記憶域スペースを作成します。
- タスク4
  - タスク7の自動スケール機能を使用する際に必要となる「リソースプロバイダー」を[明示的に登録](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/templates/error-register-resource-provider)しています。
- タスク5
  - 2個のインスタンス（VM）を含む仮想マシンスケールセット（VMSS）を作成しています。
  - 同時に、このVMSSをバックエンドとするAzure Load Balancerも作成しています。
- タスク6
  - VMSSにカスタムスクリプト拡張機能を設定し、「アップグレード」を実行することで、2個のインスタンスにカスタムスクリプト拡張機能を反映させます。
- タスク7
  - VMSSのサイズの指定を変更し、「アップグレード」を実行することで、2個のインスタンスにサイズ変更を反映させます。
  - VMSSの「カスタム自動スケール」を設定し、「ネットワーク受信」が増加したらインスタンス数が増えるようにします。
  - Cloud Shellを利用して、VMSSのインスタンスの1つに繰り返しHTTPリクエストを送信し、自動スケールによってインスタンスが増加することを確認します。
  - VMSSの各インスタンスにディスクを追加します。
  - VMSSのカスタムスクリプト拡張機能をいったんアンインストールます。
  - コマンドを使って、新しくカスタムスクリプト拡張機能をインストールします。このカスタムスクリプト拡張機能では、[prepare_vm_disks.ps1](https://github.com/Azure-Samples/compute-automation-configurations/blob/master/prepare_vm_disks.ps1)を実行します。このスクリプトは、マシンに接続された未フォーマットのディスクをNTFSでフォーマットします。

## 補足事項

タスク1の2
仮想マシン→Virtual Machines

タスク1の3
リージョン：地域で「東日本」を選択します

タスク1の4
標準→Standard

タスク1の6
アドレス範囲は既存のものを上書きしましょう。

タスク1の8
診断ストレージアカウントが追加されない場合、新規作成で「名前」に一意のものを入れ作成してください。
それ以外はデフォルトでOKです。

タスク1の13
画面は英語なので注意

enable hotpatching → false を選択

タスク2の3
Script→大文字使えないのでscript
非公開→プライベート

タスク2の9
カスタムスクリプト拡張機能→Custom Script Extension

タスク2の17

`resources: [` の次の行に貼り付けます。

```
"resources": [
    (ここに貼り付けます)
    {
        "type": "Microsoft.Compute/virtualMachines",
```

リソースグループの下に「リソース グループは、テンプレート内の1つ以上のリソースがサポートしていない場所にあります。別のリソース グループを選択してください」というエラーは、無視しても進められます。

1度別のリソースグループを選択して、
もう1度az104-08-rg01を選択すれば、エラーが解消されます。

注意
タスク2の17の次の番号が、18ではなく、1に戻っています。

タスク2-2 「コマンドの実行」→「実行コマンド」

タスク2-3 「実行コマンド スクリプト」の「PowerShellスクリプト」で以下のコマンドを実行します。10.80.0.4はvm0のプライベートIPアドレスです。

`Invoke-WebRequest -URI http://10.80.0.4 -UseBasicParsing`

以下のようなテキストで始まる出力が得られればOKです。
```
StatusCode        : 200
StatusDescription : OK
Content           : az104-08-vm0
```

続いて、「PowerShellスクリプト」のコマンドを一旦削除し、以下のコマンドを実行します。10.80.0.5はvm0のプライベートIPアドレスです。
`Invoke-WebRequest -URI http://10.80.0.5 -UseBasicParsing`

以下のようなテキストで始まる出力が得られればOKです。
```
StatusCode        : 200
StatusDescription : OK
Content           : Hello World from az104-08-vm1
```


タスク3-9

以下のようなテキストで始まる出力が得られればOKです。
```
FriendlyName OperationalStatus HealthStatus IsPrimordial IsReadOnly Size AllocatedSize
------------ ----------------- ------------ ------------ ---------- ---- -------------
storagepool1 OK                Healthy      False        False      2 TB        512 MB
```

タスク4の1
Cloud Shellがうまく起動しない場合は、一度ブラウザをリロードしてください。

タスク5の1
仮想マシンスケールセット → Virtual Machine Scale Sets

タスク5の2
リージョンは東日本

タスク5の12
スケーリングポリシー　「マニュアル」→「手動」

タスク5の13
「仮想マシン スケール セットの作成」 ブレードの 「管理」 タブで、「ブート診断」 オプションが有効になっていることを確認し・・・
→マネージド ストレージ アカウントで有効にする (推奨)にデフォルトでなっていますが、「カスタム ストレージ アカウントで有効にする」を選択してください。

タスク6の3
Script→大文字使えないのでscript

タスク6の9
カスタムスクリプト拡張機能→Custom Script Extension

タスク6の12
負荷分散装置→ロードバランサー

タスク7の3

「標準 DS1_v2」→ Standard DS1_v2

タスク7の9
演算子　「より大きい」→「次の値より大きい」

タスク7の19
標準HDD→Standard HDD

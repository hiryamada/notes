# ラボ5

（まだ準備していない場合）事前に[ラボのファイル](https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/archive/master.zip)をダウンロードして展開しておきましょう。

想定時間: 60分

## ラボの重要ポイント

3つのVNetをデプロイし、以下のようなピアリングを構成します。また、それぞれのVNetにVMがデプロイされます。
```
vnet1(東日本): vm1(10.51.0.4)
↓↑ローカル ピアリング 
vnet0(東日本): vm0(10.50.0.4)
↓↑グローバル ピアリング 
vnet2(米国西部): vm2(10.52.0.4)
```

- タスク1
  - VNetとVMをデプロイします
- タスク2
  - vnet0とvnet1のローカルピアリングを構成します
  - vnet0とvnet2のグローバルピアリングを構成します
- タスク3
  - vm0からvm1への接続（ローカルピアリング経由）が成功することを確認します。
  - vm0からvm2への接続（グローバルピアリング経由）が成功することを確認します。
- 備考
  - vm1とvm2の通信（推移的な接続）は不可能です。

### ヒント1

リソースグループを作成して、その中にVNET、VMを作成していくのですが、
1回ずつ作成を確認してから、次のコマンドを投入するのが良いです。

-AsJobを抜いて実行するとバックグラウンド処理ではなくなるので、確認しながら進めてください。

```
New-AzResourceGroupDeployment `
   -ResourceGroupName $rgName `
   -TemplateFile $HOME/az104-05-vnetvm-template.json `
   -TemplateParameterFile $HOME/az104-05-vnetvm-parameters.json `
   -nameSuffix 0 `
   -AsJob
```
↓ AsJobオプションを取り除く（注意：前の行のバッククォートも削除します）
```
New-AzResourceGroupDeployment `
   -ResourceGroupName $rgName `
   -TemplateFile $HOME/az104-05-vnetvm-template.json `
   -TemplateParameterFile $HOME/az104-05-vnetvm-parameters.json `
   -nameSuffix 0
```

### ヒント2

タスク3の手順では、RDPを使用してVMに接続してコマンドを実行していますが、RDPを使わずにコマンドを実行することができます。

VMの「実行コマンド」,「RunPowerShellScript」をクリックし、実行するコマンドをテキストボックスに貼り付けて「実行」することができます。

## 補足事項

タスク1の5
リージョン：japaneast

以下のように、`[`と`]`は取り除いてください。
```
$location = 'japaneast'
```

タスク1の9
リージョン：westus
注意　japanwestはNGです！JSONファイルで指定されているVMのサイズがJapanwestに対応していません。

以下のように、`[`と`]`は取り除いてください。
```
$location = 'westus'
```

タスク2の1
バーチャルネットワーク→仮想ネットワーク

タスク2の4
ピアリング→Peerings

タスク2の5などのピアリングの設定は注意して行ってください。

タスク3の1
仮想マシン→VirtualMachines

タスク3の6
ローカルのPCからリモートデスクトップ接続先のPCへコピペ可能です。

タスク3の7
接続が正常に行われたことを確認します。→以下のように表示されれば、接続は正常です。
```
TcpTestSucceeded        : True
```
■ラボ12

リージョンを2つ使います。
- 1つ目: eastus
- 2つ目: westus

az30312a-hv-vm (仮想マシン) 起動後、NSGでRDP接続を許可していることを確認し、RDP接続を行ってくだい。つながらない場合、少し時間をあけて何度か接続を繰り返すとつながるはずです。

Hyper-V上での仮想マシンへの接続では、メニューの「Action」→「Ctrl + Alt + Delete」からこのキーを送信できます。「Clipboard」→「Type Clipboard Text」で、コピーしたコマンドをPowerShellに貼り付けできます。

リソース名称でハイフンやスペースが許可されない場所があります。以下のように命名します。

- Hyper-Vサイト名: az30312bHyperVsite 
- Retension Policy Name: az30312breplicationpolicy

```
■演習0タスク1

テンプレートを使って、リソースグループを作成
クイックスタートテンプレートを使って、VMを作成 - eastus
https://github.com/Azure/azure-quickstart-templates/tree/master/demos/nested-vms-in-virtual-network

VNet
└サブネット
 └VM - Hyper-V ホスト
   └Windows Server 2019

オンプレミス
└Hyper-V ホスト
  └Windows Server 2019

■演習0タスク2

作成したVMにRDP接続
Microsoft Edgeを追加
Windows Server 2019 VHDファイルをダウンロード
Hyper-Vマネージャーを起動
Hyper-V上でVMを作成

■演習1タスク1
Recovery Servicesコンテナーを作成 - westus

■演習1タスク2
Recovery ServicesコンテナーのレプリケーションをLRSに、ソフト削除を無効に設定

■演習2タスク1

仮想ネットワーク az30312c-dr-vnet   を作成 - westus, 10.7.0.0/16
※レプリケーションのターゲット環境として、演習2タスク1で利用

仮想ネットワーク az30312c-test-vnet を作成 - westus, 10.7.0.0/16
※フェイルオーバー先の環境として、演習2タスク4で利用

ストレージアカウントを作成: LRS, westus
※レプリケートされたマシンのイメージの保存に利用される

■演習2タスク2

Recovery Servicesコンテナーで、Site Recoveryを設定
Hyper-V machine to Azure
1. インフラの準備
  ソースとしてHyper-Vサイトを追加 az30312bHyperVsite
  Hyper-Vサーバーを追加
    「Microsoft Azure Site Recovery プロバイダー」をダウンロード
    Valut登録キーをダウンロード
    Hyper-Vホスト(VM)上で、「Microsoft Azure Site Recovery プロバイダー」を実行
      Valut登録キーを読み込ませる
  レプリケーションポリシーを設定 az30312breplicationpolicy （30秒間隔でレプリケーション)

■演習2タスク3
レプリケーション状態を確認
「最新の復旧ポイント」 → クラッシュ整合性の復旧ポイントの時間が確認できる

■演習3タスク4
フェールオーバーのテストを実行
フェールオーバーのテストを完了（作成された仮想マシンを削除）

計画的なフェイルオーバーを実行
```
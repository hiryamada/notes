
■質問
下記について、VM HostへのOSアップデート や Security Patchの自動適用はユーザー側で設定・実施する認識で宜しかったでしょうか。
>仮想マシンとOSを詳細にコントロールすることができる


■質問
再確認で申し訳ないですが、PaaSのAzure App Serviceだと裏側のHyper-VホストのOSアップデートやSeucurity PatchはMicrosoft側の任意のタイミングで自動適用され、一方、Azure VMのHyper-Vホストだとユーザー側の自動設定が必要という理解で宜しかったでしょうか。
>仮想マシンとOSを詳細にコントロールすることができる
>PaaS:Azure App Service
> Webアプリのホスティング

■「プラットフォームの更新」: お客様が実施 または Azureが実施（後述）

https://docs.microsoft.com/ja-jp/azure/virtual-machines/maintenance-and-updates

Azure では、定期的にそのプラットフォームを更新して、仮想マシンのホスト インフラストラクチャの信頼性、パフォーマンス、セキュリティの向上に努めています。 これらの更新の目的は、ホスティング環境のソフトウェア コンポーネントの修正から、ネットワーク コンポーネントのアップグレード、ハードウェアの使用停止まで、広い範囲に及びます。

■VM/VMSSのOSレベルのセキュリティパッチ適用: お客様が実施

基本的にはお客様が実施。ただし、適用を自動化する仕組みがいくつかある。

VM/VMSS:
https://docs.microsoft.com/ja-jp/azure/virtual-machines/updates-maintenance-overview
https://docs.microsoft.com/ja-jp/azure/virtual-machines/automatic-vm-guest-patching

Azure AutomationのUpdate Management:
https://docs.microsoft.com/ja-jp/azure/automation/update-management/manage-updates-for-vm

■Azure VM/VMSSのプラットフォームの更新（VM再起動が不要なケース）: Azureが実施

https://docs.microsoft.com/ja-jp/azure/virtual-machines/maintenance-and-updates#maintenance-that-doesnt-require-a-reboot

- 影響がゼロではないメンテナンスでは、ほとんどの場合、VM の一時停止は 10 秒未満です。 
- 場合によっては、Azure はメモリ保持メンテナンスのメカニズムを使用します。これらのメカニズムでは通常、30 秒間 VM が一時停止され、RAM 内のメモリが保持されます。 その後、VM が再開され、クロックが自動的に同期されます。
- Azure側が実施します。
- この、メンテナンスのための数十秒の停止が許容できない場合は、「専用ホスト」の「メンテナンスコントロール」を使用します。

■Azure VM/VMSSのプラットフォームの更新（再起動が必要なケース）: お客様が実施 または Azureが実施

https://docs.microsoft.com/ja-jp/azure/virtual-machines/maintenance-and-updates#maintenance-that-requires-a-reboot

- Azure側が実施します。（そのタイミングはお客様が指定することができます（後述））

```
VM1 VM2 VM3 ...   ←OSのセキュリティパッチ適用等（お客様で実施）
----------------
物理ホスト（Hyper-V） ←プラットフォーム更新（Azureが実施）
```

- プラットフォームの更新は月1回程度実施されます。（計画メンテナンス）
- まれに、計画メンテナンスによって、お客様のVMの再起動が必要となる場合があります。その場合はお客様に通知されます。
- 計画メンテナンスには、"セルフサービス フェーズ"（通常4週間） と "予定メンテナンス フェーズ" の 2 つのフェーズがあります。
- セルフサービスフェーズでは、お客様がご都合のよいタイミング（＝VMに再起動がかかってもよいタイミング）で、メンテナンスを開始できます。セルフサービス メンテナンスを開始すると、VM は、既に更新済みのノードに再デプロイされます。
- 予定メンテナンスフェーズでは、Azureがメンテナンスを開始します。

■「専用ホスト」の「メンテナンスコントロール」: お客様が実施

https://docs.microsoft.com/ja-jp/azure/virtual-machines/dedicated-hosts#maintenance-control
https://docs.microsoft.com/ja-jp/azure/virtual-machines/maintenance-control

ゲーム、メディア ストリーミング、金融取引などの一部のセンシティブなワークロードでは、数秒間であっても、メンテナンスのために VM がフリーズしたり切断したりすることが許されません。

「メンテナンスコントロール」が提供するオプションを使用すると、プラットフォームの更新を待機し、35 日間のローリング期間内にそれらの更新を適用できます。

■App Service: Azureが実施

https://docs.microsoft.com/ja-jp/azure/app-service/overview-patch-os-runtime
https://azure.github.io/AppService/2018/01/18/Demystifying-the-magic-behind-App-Service-OS-updates.html
https://ruslany.net/2015/09/how-to-warm-up-azure-web-app-during-deployment-slots-swap/

・App Serviceのメンテナンス・更新は毎月行わます。
  - 物理サーバーレベル
  - App Service リソースを実行するゲスト仮想マシン (VM)レベル

・更新は、「Azure サービスの高可用性 SLA を保証する方法」で、自動的に適用されます。
  - お客様のアプリを、更新が完了したインスタンスに移動する。
  - このときコールドスタート（アプリの初回リクエスト処理時に余分な時間がかかる）が発生する。
  - コールドスタートの影響を少なくするようにアプリケーションを構成することができる（アプリケーションにウォームアップの仕組みを作り込み、それが呼び出されるようにする）。

・言語ランタイムの更新は定期的に行われます。
  - 方式:「サイドバイサイド」または「上書き」



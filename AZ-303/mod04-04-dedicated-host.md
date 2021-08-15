# Azure 専用ホスト (dedicated host)

https://docs.microsoft.com/ja-jp/azure/virtual-machines/dedicated-hosts

- 1 つの Azure サブスクリプションに対して専用の物理サーバーを提供するサービス
- 企業のコンプライアンス要件と規制要件に対応するための可視性と制御が得られる
- 物理サーバーのレベルのハードウェア分離を提供
- 1台の専用ホストで、複数のVMを稼働させることができる
- Linux と Windows 仮想マシンを実行できる
- Azure ハイブリッド特典を利用できる

2019/8にプレビュー開始。
https://azure.microsoft.com/ja-jp/blog/introducing-azure-dedicated-host/

2019/12に一般提供開始（Generally available）
https://azure.microsoft.com/en-gb/updates/azure-dedicated-hosts-now-generally-available/

■普通のVM（仮想マシン）との違い

普通のVMを運用する場合:
- VMを稼働させるホストはユーザーが指定できない（Azureにおまかせ）。
- ホストのメンテナンスによる再起動をコントロールできない
- ホストで、他のサブスクリプションのVMも実行される可能性がある
- ホストについて考慮する必要はない
- すべてのサイズのVMを利用できる
- VM単位で課金される

専用ホストでVMを運用する場合:
- VMを稼働させるホストをユーザーが指定できる。
- ホストのメンテナンスによる再起動をコントロールできる
- ホストで、他のサブスクリプションのVMが実行される可能性はない
- 専用ホストを明示的にデプロイする必要がある
- 専用ホストでサポートされているサイズのVMのみ利用できる
- ホスト単位で課金される（ホストの上でいくつVMを起動するかは関係ない）

■価格

https://azure.microsoft.com/ja-jp/pricing/details/virtual-machines/dedicated-host/

最安: DCsv2-Type1, 89,608円/月 (EastUS)

■専用ホスト

- 1 つ以上の仮想マシンをホストできる
- データ センターで使用されるものと同じ物理サーバー
- Azure データ センター内のいずれかの物理サーバーにマップ（対応付け）される
- 専用ホストのSKUによって、そのホスト上で稼働できるVMのシリーズ、トータルのvCPU数が決まる。
  - 専用ホスト上で複数のVMを稼働させることができる

■ホストグループ

- 専用ホストのコレクションを表すリソース



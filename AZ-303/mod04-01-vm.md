# Azure 仮想マシン（VM）

■VM作成前の検討事項

Linux:
https://docs.microsoft.com/ja-jp/azure/virtual-machines/linux/overview#what-do-i-need-to-think-about-before-creating-a-vm

Windows:
https://docs.microsoft.com/ja-jp/azure/virtual-machines/windows/overview#what-do-i-need-to-think-about-before-creating-a-vm

- ネットワーク(VNet)を事前に計画・設計しておく
- 名前
  - Windows: 15文字まで
  - Linux: 64文字まで
- ロケーション（リージョン）
- サイズ（後述）
- 価格モデル
  - 従量課金制（通常の料金）
  - リザーブドVMインスタンス（後述）
  - スポット仮想マシン（後述）
  - ハイブリッド特典（後述）
- OSイメージ
  - 仮想マシン作成画面のイメージ選択欄では、Windows 10やUbuntuなどを選択できる
  - 仮想マシン作成画面のイメージ選択欄の下の「すべてのイメージを表示」をクリックすると、より多くのイメージが表示される

■VMのサイズ

https://docs.microsoft.com/ja-jp/azure/virtual-machines/sizes

主なタイプとシリーズ。

- 汎用 タイプ
  - [Aシリーズ(Av2)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/av2-series)
  - [Bシリーズ(B)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/sizes-b-series-burstable)
  - [Dシリーズ(Dv4)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/dv4-dsv4-series)
- コンピューティング最適化 タイプ
  - [Fシリーズ(Fsv2)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/fsv2-series)
- メモリの最適化 タイプ
  - [Eシリーズ(Ev4)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/ev4-esv4-series)
  - [Mシリーズ(M)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/m-series)
- ストレージの最適化 タイプ
  - [Lシリーズ(Lsv2)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/lsv2-series)
- GPU タイプ
  - [NCシリーズ(NCv3)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/ncv3-series)
  - [NVシリーズ(NVv4)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/nvv4-series)
- FPGA最適化済み タイプ
  - [NPシリーズ(NP)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/np-series)
- ハイ パフォーマンス コンピューティング タイプ
  - [Hシリーズ(H)](https://docs.microsoft.com/ja-jp/azure/virtual-machines/h-series)

■ハンズオン: VMのサイズ変更

※vm1, vm2はここまでのハンズオンで作成済み

- 画面上部の検索で「vm」→「Virtual Machines」
- vm1をクリック
- サイズ
- D2s_v5が選択されている。
- D4s_v5を選択して、「サイズの変更」をクリック
- VMが再起動され、サイズが変更される

■VMのサイズの名前付け規則

https://docs.microsoft.com/ja-jp/azure/virtual-machines/vm-naming-conventions

例:頭に「Basic」や「Standard」を付けないパターン（公式サイトのシリーズ表記）

- Dv4 ... D ファミリ, version 4
- NCv3 ... N ファミリ、C サブファミリ、version 3
- Lsv2 ... L ファミリ、Premium Storage対応(s)、version 2

例:頭に「Basic」や「Standard」を付けるパターン（コマンド等ではこれを指定）

- Basic_A0 ... Basicレベル、A0 (1 vCPU)
- Standard_A1_v2 ... Standardレベル、Aシリーズ、1 vCPU, version 2
- Standard_D4_v4 ... Standardレベル、Dシリーズ、4 vCPU, version 4

※Basic_A0の0はvCPU数ではない。A0～A4がある。

※古いサイズでは、シリーズの後ろの数字＝vCPUとはなっていない。

※Aシリーズは「旧世代」. 現行世代は Av2 シリーズ
https://docs.microsoft.com/ja-jp/azure/virtual-machines/sizes-previous-gen

■レベル(tier)

https://docs.microsoft.com/ja-jp/azure/virtual-machines/sizes-previous-gen#basic-a

- Basic ... かつて使われていたレベル。2014年に導入. 当時は Basic tier と呼ばれていた。
- Standard ... 現在はすべてのVMがこのレベル。

参考: 
- https://azure.microsoft.com/ja-jp/blog/basic-tier-virtual-machines-2/
- https://www.acrovision.jp/service/azure/?p=1097

■世代(generation)

https://docs.microsoft.com/ja-jp/azure/virtual-machines/generation-2

- 第1世代 ... BIOSベース
- 第2世代 ... UEFIベース

※世代は、サイズの文字列には含まれない。

■旧世代のサイズ(previous generations of VM sizes)

https://docs.microsoft.com/ja-jp/azure/virtual-machines/sizes-previous-gen

- 「旧世代のサイズ」は、「世代」（「第1世代」「第2世代」）とは別のもの。
- より新しいサイズが登場したことによって、「旧世代のサイズ」扱いとなったもの。

Dシリーズ の Standard_D1 など。

■version

- サイズ末尾についている「v2」「v3」「v4」「v5」など。
- 数字が大きいほうがより新しい
- 数字が大きいほうが、VMを稼働させるホストコンピュータのハードウェアもより新しいものとなる。

例: Dシリーズ

- D シリーズ ... 「旧世代のサイズ」。2014/9～
- Dv2 シリーズ ... D シリーズの後継。2016/3～
- Dv3 シリーズ ... 2017/7～
- Dv4 シリーズ ... 2020/6～
- Dv5 シリーズ ... 2021/4～

参考
- D https://azure.microsoft.com/ja-jp/blog/new-d-series-virtual-machine-sizes/
- Dv2 https://azure.microsoft.com/ja-jp/updates/announcing-new-dv2-series-virtual-machine-size/
- Dv3 https://azure.microsoft.com/en-us/blog/introducing-the-new-dv3-and-ev3-vm-sizes/
- Dv4 https://azure.microsoft.com/ja-jp/blog/new-general-purpose-and-memoryoptimized-azure-virtual-machines-with-intel-now-available/
- Dv5 https://azure.microsoft.com/ja-jp/updates/new-azure-vms-for-general-purpose-and-memory-intensive-workloads-now-in-public-preview/
 
# Azureの予約

リソースを長期間（1年以上）利用する場合におすすめ。

https://docs.microsoft.com/ja-jp/azure/cost-management-billing/reservations/save-compute-costs-reservations?toc=/azure/cost-management-billing/reservations/toc.json

- 1 年または 3 年期間を指定して「予約」を「購入」する。
- 例: 仮想マシン「Standard_DS3_v2」の「予約」を1年分「購入」する。
- 従量課金制の料金に比べ最大 72% 削減できる
- Azure portalから「購入」できる。画面上部の検索で「予約」を検索。
- 支払いは前払いでも月払いでもOK
- 「予約」の「購入」後、該当するリソースに、割引が自動的に適用される。
- 「購入」完了後すぐに割引が始まる
- VM以外のサービスでも予約が使用できるものがある
- キャンセル・交換（別の予約への変更）・払い戻しも可能。※中途解約料が差し引かれる
  - https://docs.microsoft.com/ja-jp/azure/cost-management-billing/reservations/exchange-and-refund-azure-reservations?toc=/azure/cost-management-billing/reservations/toc.json#cancel-exchange-and-refund-policies

■リザーブドVMインスタンス （RI）

https://azure.microsoft.com/ja-jp/pricing/reserved-vm-instances/

- サイズの変更が可能。同じリージョン内および同じ「柔軟性グループ」内の VM に対して、予約インスタンス割引が自動的に適用される（「インスタンス サイズの柔軟性」）
  - 例: 仮想マシン「Standard_DS3_v2」の予約を購入すると、以下のサイズでその予約を利用できる。
    - Standard_DS1_v2
    - Standard_DS2_v2
    - Standard_DS3_v2
    - Standard_DS4_v2

■RIの購入の流れ

https://docs.microsoft.com/ja-jp/azure/cost-management-billing/reservations/exchange-and-refund-azure-reservations

- Azure portalで「予約」を検索
- 「仮想マシン」をクリック
- VMのサイズと数量を選択

# スポット仮想マシン（Azure Spot Virtual Machines）

https://docs.microsoft.com/ja-jp/azure/virtual-machines/spot-vms

途中で中断されてもかまわないようなワークロードで活用できる。コストを大幅に削減。

- テスト・検証など
- 大規模なレンダリングやシミュレーションの計算ノード

※Azure portal上では「Azure スポット インスタンス」と表示される


■概要

- Azure で容量の回復が必要になると、スポットVM は削除される。
  - 「削除ポリシー」で「停止/割当解除」を指定しておくと、VMは停止するが、後でまた起動できる。（自動で再開はしない）
- 削除30秒前に通知をイベントで受信することができる
  - データを一時的に保存するタスクなどを実行できる
  - https://docs.microsoft.com/ja-jp/azure/virtual-machines/linux/scheduled-events
  - https://docs.microsoft.com/ja-jp/azure/virtual-machines/windows/scheduled-events

■料金の例

「カナダ中央」リージョンで、「D4s」のWindows VMを利用する場合。

- 従量課金: 1時間 0.965 ドル。
- スポットVM: 1時間 0.11ドル～（時価）。

この例の場合は、最安の場合、約1/9のコストでVMを使用できる。

実際に支払うスポットVMのコストは刻々と変動するが、従量課金料金を超えることはない。


■スポットVMの起動

- VMの作成画面の最初の画面で「Azure スポット インスタンス」のチェックを入れる。
- 「削除の種類」で「容量のみ」（最大従量課金）または「価格または容量」を選ぶ
  - 「容量のみ」: 上限価格を指定しない（上限価格＝従量課金の価格となる）
  - 「価格または容量」: 上限価格を指定する（上限価格を
- 「削除ポリシー」で「停止/割当解除」または「削除」を選ぶ
  - 「停止/割当解除」: スポットVMが削除される際に、VMリソースを残す
  - 「削除」: スポットVMが削除される際に、VMリソースを削除

# Azure ハイブリッド特典

https://azure.microsoft.com/ja-jp/pricing/hybrid-benefit/

- [ソフトウェア アシュアランス](https://www.microsoft.com/ja-jp/licensing/licensing-programs/software-assurance-default)プログラムご契約のお客様用
- Windows Server と SQL Server の両方のワークロードに適用できる。


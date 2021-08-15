# 仮想マシン スケール セット(Virtual Machine Scale Set, VMSS)

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/overview

- 多数の VM の一元的な管理、構成、更新を可能にする
- VM インスタンスの数を自動的に増減させることができる
- スケール セット内のすべての VM が、同一の OS イメージと構成から作成される
- 前面にロードバランサーを立てて負荷分散を行うことができる
  - Azure Load Balancer
  - Azure Application Gateway
- 可用性ゾーンと組み合わせることで、VMをリージョン内のゾーンに分散させることができる
  - ゾーン1,2,3を明示的に選択。
- 1つのスケール セットに、最大1000個（カスタムVMイメージを使用する場合は600個）のVMを含めることができる

■インスタンス

- VMSSに含まれる個々のVMを「インスタンス」と呼ぶ

■初期インスタンス数

VMSS作成時に指定する、スケールセットに含まれるインスタンスの数。

■手動スケーリング

VMSS作成後、「スケーリング」の「インスタンス数」でインスタンス数を手動で調節できる。

■自動スケーリング

https://docs.microsoft.com/ja-jp/azure/virtual-machine-scale-sets/virtual-machine-scale-sets-autoscale-overview

インスタンスの数を自動的に増減させることができる。

■スケーリングに使用するメトリック

- ホスト メトリック
  - 追加のエージェント等を構成する必要がない
- パフォーマンス メトリック
  - VM インスタンスで Azure Diagnostics 拡張機能をインストールして構成する
  - または、App Insights を使用してアプリケーションを構成する

■スケジュールに基づく自動スケール

- 決まった時間に VM インスタンスの数を自動的にスケールできる。


■スケーリングポリシー

- 手動
- カスタム


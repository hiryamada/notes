# ラボ (ハンズオン)

手順書: M01-ユニット 8 グローバル仮想ネットワーク ピアリングを使用して 2 つの Azure 仮想ネットワークを接続する
- [英語の手順書(最新, 推奨)](https://github.com/MicrosoftLearning/AZ-700-Designing-and-Implementing-Microsoft-Azure-Networking-Solutions/blob/master/Instructions/Exercises/M01-Unit%208%20Connect%20two%20Azure%20Virtual%20Networks%20using%20global%20virtual%20network%20peering.md)
- [日本語の手順書(内容が古くなっている場合があります, 非推奨)](https://github.com/MicrosoftLearning/AZ-700-Designing-and-Implementing-Microsoft-Azure-Networking-Solutions.ja-jp/blob/main/Instructions/Exercises/M01-Unit%208%20Connect%20two%20Azure%20Virtual%20Networks%20using%20global%20virtual%20network%20peering.md)


概要:
- 2つのVNetを接続するピアリングを作成します。
- VNetに配置されたVMがピアリングを使って別VNetのVMと通信できることを確認します。

時間: 20分

はじめにお読みください: [全般的なラボの注意](lab.md)

このラボの注意:
- タスク 6: 「リソースをクリーンアップする」では、`ContosoResourceGroup` リソースグループを削除します。
  - その他に`cloud-shell-storage-southeastasia` と `NetworkWatcherRG` リソースグループもありますが、これらは削除する必要はありません。（削除してもまたすぐ自動的に作成されます）

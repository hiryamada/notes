# ラボ (ハンズオン)

手順書: M01 - ユニット 6 Azure で DNS 設定を構成する
- [英語の手順書(最新, 推奨)](https://github.com/MicrosoftLearning/AZ-700-Designing-and-Implementing-Microsoft-Azure-Networking-Solutions/blob/master/Instructions/Exercises/M01-Unit%206%20Configure%20DNS%20settings%20in%20Azure.md)
- [日本語の手順書(内容が古くなっている場合があります, 非推奨)](https://github.com/MicrosoftLearning/AZ-700-Designing-and-Implementing-Microsoft-Azure-Networking-Solutions.ja-jp/blob/main/Instructions/Exercises/M01-Unit%206%20Configure%20DNS%20settings%20in%20Azure.md)

概要:
- Azure DNS プライベートDNSゾーンを作成し、VNetにリンクします。
- VNetに起動したVMの名前とIPアドレスがプライベートDNSゾーンに自動登録されることを確認します。
- VNetに起動したVMで、プライベートDNSゾーンを使用した名前解決ができることを確認します。
- ※注意: VM同士は通信はできません。

時間: 25分

はじめにお読みください: [全般的なラボの注意](lab.md)

このラボの注意:
- 以下の様に読み替えます。
  - 「オン」＝（チェックボックスにチェックする）
  - Create storage ＝ ストレージの作成
  - 仮想マシン＝Virtual Machines
- タスク 2: 仮想ネットワーク リンク作成後、「リンクの状態」が「完了」となるまで、少し時間がかかります。
- タスク 3:
  - ARMテンプレートのデプロイが終わると、testvm1 と testvm2 という2つの仮想マシンが作成されます。

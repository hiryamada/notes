<!--
日本語版
https://github.com/MicrosoftLearning/AZ-700-Designing-and-Implementing-Microsoft-Azure-Networking-Solutions.ja-jp/tree/main/Instructions/Exercises

英語版
https://github.com/MicrosoftLearning/AZ-700-Designing-and-Implementing-Microsoft-Azure-Networking-Solutions/tree/master/Instructions/Exercises

- Instructions/Exercises 以下の Markdownファイル（～.md）が手順書です。
- 全 8モジュール, 17ラボ
- 1ラボは20分～60分(ラボによる)

-->

■ラボの全般的な注意

- Azure の操作は、Azure portalから実行します。
  - お手元のWebブラウザーで、 https://portal.azure.com/ にアクセスしてください。
  - トレーニング初日に作成したMicrosoftアカウントでサインインしてください。
- Azureでは、全体的に、リソースの作成が完了したり、リソースの設定を変更してから、一覧画面などに反映（表示）されるまで、1分～2分ほどかかる場合があります（VPN Gatewayなど一部のリソースはさらに時間がかかる場合があります）。
  - 作成したリソースなどが画面に反映されない場合は、しばらく待ってから、以下の操作を行ってください。
    - 画面内の「更新」「最新の情報に更新」ボタンがある場合はそれをクリックしてください。
    - または、Webブラウザーでページをリロードしてください。
- あるラボで作成したリソースは、次のラボで続けて使いますので、指示がない限り、消さないでください。
- ラボの指示と、実際の画面は、若干異なる場合があります。適宜、読み替えてください。
- 事前に [ZIPファイル(AZ-700-Designing-and-Implementing-Microsoft-Azure-Networking-Solutions-master.zip)](https://github.com/MicrosoftLearning/AZ-700-Designing-and-Implementing-Microsoft-Azure-Networking-Solutions/archive/refs/heads/master.zip) をダウンロードします。
  - ダウンロードしたファイルのファイル名を「AZ-700.zip」といった短い名前に変更します。
  - 「AZ-700.zip」を展開します。
  - 展開されたフォルダ内に `Allfiles/Exercises` というフォルダがあることを確認してください。
  - 各ラボの手順書で、ファイルを使用するように指示があった場合、このフォルダ内の対応するファイルを使用してください。
    - 例えば `F:/Allfiles/Exercises/M01` といったフォルダー内のファイルを使用するように指示があった場合は、展開されたフォルダ内の `Allfiles/Exercises/M01` 内のファイルを使用してください。
- ご所属の企業のネットワークによっては、Azureの仮想マシンへの RDP（リモートデスクトップ）接続が許可されていない場合があります。
  - その場合は、RDP の代わりに Bastion（Azure Bastion）を使用して仮想マシンに接続してください。

# Microsoft Copilot for Microsoft 365 用のコネクタとプラグインを構築する

<!--
ラーニングパス1が「Microsoft 365 Copilot用のプラグインとコネクタを構築する」となっています。コース名はおそらくここから取られたものと思われます。含まれるモジュールは「Microsoft 365 Copilot の機能拡張の基礎」と「Copilot の拡張開発パスを選択する」の2つであり、基本的に「Copilotの拡張方法にはどのようなものがあり、どの場合にどれを選択すべきか」という概論を説明します。VSCodeのTeams ToolKit拡張機能やKiota拡張機能でプラグインが作れますよ、というご紹介がある。
 
ラーニングパス2が「Visual Studio Code を使用して宣言型エージェントを使用してMicrosoft 365 Copilotを拡張する」となっています。このラーニングパスは昨年11月のコース改定で追加されたものだそうです。 https://techcommunity.microsoft.com/blog/iltcommunicationblog/introducing-the-newly-revamped-ms-4010-build-plugins-and-connectors-for-microsof/4330329
んでこのラーニングパス2では、VSCodeを使用してMicrosoft 365 Copilotを拡張する、という内容になります。「宣言的エージェント」という仕組みを使用して、基本的に設定ファイルをごにょごにょしてMicrosoft 365 Copilotをカスタマイズする感じです。あとはTeams上で動作確認をします。宣言型エージェントで、プラグイン（ここではレストランのメニューを表示したり注文したりする例が使用される）やGraphコネクタ（コントソ社のITポリシーのテキストをGraphコネクタ経由で読み込む例が使用される）を使う方法の解説が含まれます。
 
ラーニングパス2にはラボがあるようです。https://github.com/MicrosoftLearning/MS-4010-Build-Plugins-Connectors-Microsoft-Copilot-M365/tree/main/Instructions/Labs ラボ1番で宣言型エージェントの基本、ラボ2番でプラグインの作成（といってもマニュフェストをコピペするだけ）、ラボ3でアダプティブカードという、Copilotの応答のアイコンをクリックすると詳細（ここではレストランの注文内容）をポップアップで表示する仕掛けを追加、といった感じですね。
-->

Microsoft Learn: 

https://learn.microsoft.com/en-us/training/courses/ms-4010

https://learn.microsoft.com/ja-jp/training/courses/ms-4010

## 講義

- Microsoft 365 Copilot用のプラグインとコネクタを構築する
    - Microsoft Copilot の機能拡張の基礎
    - Copilot の拡張開発パスを選択する
- Visual Studio Code を使用して宣言型エージェントを使用してMicrosoft 365 Copilotを拡張する
    - Microsoft 365 Copilotの宣言型エージェントの概要
    - Visual Studio Code を使用してMicrosoft 365 Copilot用の最初の宣言型エージェントを構築する
    - Visual Studio Code を使用して API プラグインを使用して宣言型エージェントの最初のアクションを構築する
    - アダプティブ カードを使用して、宣言型エージェントの API プラグインにデータを表示する
    - Microsoft Graph コネクタと Visual Studio Code を使用して宣言型エージェントにカスタムナレッジを追加する

<!--
2024/11にコースが更新された
https://techcommunity.microsoft.com/blog/iltcommunicationblog/introducing-the-newly-revamped-ms-4010-build-plugins-and-connectors-for-microsof/4330329

- ガイド付きプロジェクト - Microsoft Copilot 用の TypeScript (TS) を使用してメッセージ拡張機能プラグインを構築する

-->

## 講師デモ


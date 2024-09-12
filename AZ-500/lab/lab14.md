# ラボ9 前半（Microsoft Defender for Cloud）

想定時間: 30min

想定時間: 30min

Microsoft Defender for Cloud （統合的なセキュリティ監視、セキュリティアラート）について学びます。

## ラボの重要ポイント

- タスク1
  - Microsoft Defender for Cloudの「アップグレード」を実行します。
    - Microsoft Defender for Cloudは無償の製品です。[クラウドとオンプレミスのセキュリティを評価・強化します。](https://docs.microsoft.com/ja-jp/azure/security-center/security-center-introduction)
    - Azure Defender は、[高度でインテリジェントな保護を実現します](https://docs.microsoft.com/ja-jp/azure/security-center/azure-defender)。
      - Azure Defender には、「for servers」「for App Service」などの「プラン」があります。
    - Microsoft Defender for CloudにてAzure Defenderを有効化（アップグレード）することができます。30 日間の無料試用版が利用できます。
    - Microsoft Defender for CloudやAzure Defenderの機能をターゲットに対して有効化し、監視対象とすることを「オンボードする」(Onboarding your X into Microsoft Defender for Cloud / on-board Microsoft Defender for Cloud)といいます。例：「[AWS アカウントを Microsoft Defender for Cloud にオンボードする](https://docs.microsoft.com/ja-jp/azure/security-center/quickstart-onboard-aws)」
  - Azure VMに、Log Analyticsエージェントがインストールされます。[Microsoft Defender for Cloud では、Log Analyticsエージェントを使用して、必要なデータを収集します](https://docs.microsoft.com/ja-jp/azure/security-center/security-center-enable-data-collection#how-does-security-center-collect-data)。
- タスク2
  - Microsoft Defender for Cloud の[推奨事項](https://docs.microsoft.com/ja-jp/azure/security-center/recommendations-reference)を実装します。
    - [Endpoint Protection](https://www.microsoft.com/ja-jp/microsoft-365/security/endpoint-defender)を有効にします
      - [Microsoft Antimalware](https://docs.microsoft.com/ja-jp/azure/security/fundamentals/antimalware)をインストールします
- タスク3
  - [Just In Time VMアクセス](https://docs.microsoft.com/ja-jp/azure/security-center/security-center-just-in-time?tabs=jit-config-asc%2Cjit-request-asc)の構成にて、Just-In-Time VM アクセスが適用されるポートの一覧から、ポート22（SSH接続）を削除します。

<!--
## 

タスク1-2
画面上部の検索ボックスで「セキュリティ センター」を検索します。

タスク1-3
「セキュリティ センター | はじめに」画面を下までスクロールし、画面下の「アップグレード」ボタンをクリックします。続いて「エージェントのインストール」をクリックします。


タスク1-4

「セキュリティ センター | 概要」画面で、管理セクションの「価格と設定」をクリックします。

タスク1-5
サブスクリプションを表すエントリをクリック→ 「Azure Pass - スポンサー プラン」をクリックします。次の画面で「Azure Defender オン」が選択（背景色が青）されていることを確認します。

タスク1-6
自動プロビジョニングがオンに設定されていることを確認します。 → 「Azure VM の Log Analytics エージェント」の「状態」が「オン」になっていればOKです。

タスク1-11 
「拡張機能のデプロイ構成」で「適用」をクリックして閉じた後、さらに「設定 | 自動プロビジョニング」画面で「保存」をクリックしてください。

タスク1-13 ～ 1-15 ここは「ワークフロー自動化」設定画面の確認だけとなりますが、Security Centerのワークフロー自動化（セキュリティアラート発生時などの対応の自動化）については[ドキュメント](https://docs.microsoft.com/ja-jp/azure/security-center/workflow-automation)をご確認ください。

タスク2-1 「セキュリティ センター」の「概要」ブレードに移動します。

タスク2-4 「インサイト」タイル→「分析情報」タイル

「仮想マシンにエンドポイント保護ソリューションをインストールする」 → 「仮想マシンに Endpoint Protection ... (ソリューションをインストールする）」

タスク2-5 「myVM」が表示されず、「推奨事項はありません」と表示される場合は、「セキュリティ センター」の「概要」ブレードにもどり、「推奨事項」画面の画面下部の「Endpoint Protectionを有効にする」を展開し、「仮想マシンに Endpoint Protection ... (ソリューションをインストールする）」をクリックします。こちらの画面では、「myVM」が選択された状態となります。

タスク2-6 「1つの VMにインストール」 → 画面上部「1 VMへインストール」をクリックします

タスク3-1 「セキュリティ センター」の「概要」ブレードに移動します。

タスク3-2 「クラウド セキュリティ」セクションの「Azure Defender」をクリックします。画面下部「高度な保護」の「Just-in-Time VMアクセス」をクリックします。「構成されていません」を選択して、myVM の行のチェックボックスをオンにします。

タスク3-3 「1台のVMでJITを有効にする」をクリックします。

タスク3-4 「省略記号ボタン」→ 画面右側の「...」です

-->

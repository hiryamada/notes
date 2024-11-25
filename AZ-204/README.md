# AZ-204 Developing Solutions for Microsoft Azure

Azure開発者向けのコースです。

開発でよく使われるサービスや、C#などのプログラムからのAzureサービスの利用に重点が置かれています。

- 初級 ★
  - AZ-900 Azure Fundamentals
- 中級 ★★
  - **AZ-204 Developing Solutions for Microsoft Azure**
- 上級 ★★★
  - AZ-400: Designing and Implementing Microsoft DevOps Solutions


# 日程

- [開始時のご案内](../opening.md)
- [1日目](day1.md)
  - App Service, [ラボ1](lab01cs.md)
  - Azure Functions, [ラボ2](lab02cs.md)
- [2日目](day2.md)
  - Azure Blob Storage, [ラボ3](lab03cs.md)
  - Azure Cosmos DB, [ラボ4](lab04cs.md)
- [3日目](day3.md)
  - コンテナー化されたソリューションの実装(ACR, ACI, ACA), [ラボ5](lab05cs.md)
  - ユーザー認証(Microsoft ID Platform, MSAL, Microsoft Graph), [ラボ6](lab06cs.md)
- [4日目](day4.md)
  - セキュリティ(Key Vault, マネージドID), [ラボ7](lab07cs.md)
  - App Configuration
  - API Management, [ラボ8(API Management)](lab08cs.md)
  - イベントベースソリューション(Event Grid, Event Hubs), [ラボ9(Event Grid)](lab09cs.md)
- [5日目](day5.md)
  - メッセージベースソリューション(Queue Storage, Service Bus), [ラボ10(Service Bus)](lab10cs.md)
  - Application Insights, [ラボ11](lab11cs.md)
  - キャッシュ(Azure Cache for Redis, Azure CDN), [ラボ12(CDN)](lab12cs.md)
- クロージング
  - [全体のまとめ](summary.md)
  - [認定試験のご案内](exam.md)
  - [終了時のご案内](../closing-cloudslice.md)
  - 満足度調査アンケート


# 教材 (Microsoft Learn)

https://docs.microsoft.com/ja-jp/learn/certifications/courses/az-204t00

ページ下部に、Microsoft Learnへのリンクがあります。
<!--
# ラーニングパスの構成

全12ラーニングパスで構成されます。

1. [Azure App Service Web Apps の作成](mod01.md)
   - 参考: [Azure Static Web Apps](pdf/Azure%20Static%20Web%20Apps.pdf)
2. [Azure Functions の実装](mod02.md)
     - 参考: [Durable Functions](pdf/mod02/durable-function.pdf)
3. [Blob Storage を使用するソリューションの開発](mod03-01-blob.md)
   - [ラボ3のコード例](lab03.md)
4. [Cosmos DB ストレージを使用するソリューションを開発する](mod04.md)
5. IaaS ソリューションの実装
   - [VM](mod05-01-vm.md)
   - [ARMテンプレート](mod05-02-arm.md)
   - [Docker](mod05-03-docker.md)
   - [Azure Container Registry](mod05-04-acr.md)
   - [Azure Container Instance](mod05-05-aci.md)
6. [安全なクラウド ソリューションの実装](mod06.md)
7. [ユーザー認証と認可を実装する](mod07.md)
8. [API Management を理解します](mod08-01-apim.md)
9.  イベントベースのソリューションの開発
   - [Event Grid](mod09-01-eventgrid.md)
   - [Event Hubs](mod09-02-eventhubs.md)
10. メッセージ ベース ソリューションの開発
    - [Service Bus](mod10-01-servicebus.md)
    - [Queue Storage](mod10-02-queue.md)
11. [監視とロギングをサポートするインストルメント ソリューション](mod11.md)
    - [Azure Monitor](mod11-01-monitor.md)
    - [Application Insights](mod11-02-appinsights.md)
    - [Log Analytics](mod11-03-loganalytics.md)
12. [キャッシュとコンテンツ配信をソリューション内で統合](mod12.md)
    - [Azure Cache for Redis](pdf/mod13/Azure%20Cacheまとめ.pdf)
    - [Azure CDN](pdf/mod13/Azure%20CDNまとめ.pdf)

1日2～3モジュールを目安に進めていきます。
各モジュールにはハンズオンラボ（演習時間）があります。
-->

## ラボ(演習) / 講師デモ

■ご案内

- ラボ(演習)の実施はオプションです。 
- ラボ環境にアクセスするにはMicrosoftアカウントが必要です。
  - [ラボ環境 ( https://esi.learnondemand.net/ )](https://esi.learnondemand.net/)
  - [Microsoftアカウントの作成](https://account.microsoft.com/account?lang=ja-jp)
- ラボ環境にアクセスしたらトレーニングキーを入力します。
  - トレーニングキーは講師よりお知らせします。
  - トレーニングキーには有効期限があり、最終日までに入力する必要があります。
  - 新しいトレーニングキーの再発行はいたしかねます。あらかじめご了承ください。
- トレーニングキー入力後、ラボはご受講後半年後まで利用できます。
  - ラボの利用可能期間の延長はいたしかねます。あらかじめご了承ください。
- ラボの利用方法について詳細は以下をご覧ください。
  - [ラボ環境の利用方法 解説PDF](../ラボ環境の利用方法.pdf)

■ラボのファイル

ラボを起動し、「ラボのファイルをC:/ドライブにダウンロード」をクリックすると、C:ドライブにAllFilesフォルダーが作成されます。その中にラボで使用するサンプルコード類が配置されます。

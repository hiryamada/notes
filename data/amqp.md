# Advanced Message Queuing Protocol (AMQP)


https://www.amqp.org/

Advanced Message Queuing Protocol (AMQP) は、アプリケーション間または組織間でビジネス メッセージをやり取りするためのオープン スタンダードです。システムを接続し、ビジネス プロセスに必要な情報を提供し、目標を達成するための指示を確実に送信します。

https://buildersbox.corp-sansan.com/entry/2020/11/06/110000

AMQP は金融サービス大手の JP Morgan Chase で生み出され、2006年に version 0.8～0.9、2008年に version 0.9.1 が発表されたのち、構造化情報標準促進協会 (OASIS) によって、2012年10月に現状の最新版である version 1.0 が発表されています。

# Azure Service Bus での AMQP 対応


https://codezine.jp/article/detail/7171

2012年10月、OASIS標準化団体は、OASIS標準として、AMQP 1.0の承認したことを発表し、その同日に、私たちはWindows Azure Service Busにより、そのプレビュー実装をリリース

Windows Azure Service BusでのAMQP 1.0サポートを一般公開（GA）機能としてリリース


https://learn.microsoft.com/ja-jp/azure/service-bus-messaging/service-bus-amqp-overview

Azure Service Bus クラウド サービスは、主要な通信手段として AMQP 1.0 を使用します。 Microsoft は、AMQP を開発および進化させるために、過去 10 年間にわたって、お客様および競合するメッセージング ブローカーのベンダーの両方を含む、業界全体のパートナーと協力して、OASIS AMQP 技術委員会において新しい拡張機能を開発してきました。 AMQP 1.0 は、ISO/IEC 標準です (ISO 19464:20149)。

AMQP を使用すると、ベンダーおよび実装に中立で、オープンな標準プロトコルを使用したクロス プラットフォームのハイブリッド アプリケーションを構築できます。 異なる言語とフレームワークを使用して作成され、異なるオペレーティング システムで実行可能であるコンポーネントを使用して、アプリケーションを構築できます。 これらのコンポーネントはすべて Service Bus に接続でき、構造化されたビジネス メッセージを効率よく完全な忠実度でシームレスに交換できます。

Azure SDK 経由でサポートされているすべての Service Bus クライアント ライブラリが AMQP 1.0 を使用します。

# AMQP.Net Lite


https://github.com/Azure/amqpnetlite

AMQP.Net Lite is a lightweight AMQP 1.0 library for the .Net Framework, .Net Core, Windows Runtime platforms, .Net Micro Framework, .NET nanoFramework and Mono. The library includes both a client and listener to enable peer to peer and broker based messaging.

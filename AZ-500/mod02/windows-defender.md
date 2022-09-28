# Windows ホストのセキュリティ強化 (Windows Defender)

https://learn.microsoft.com/ja-jp/training/modules/host-security/9-windows-defender

WindowsのVBS (Virtualization-Based Security)を使用したセキュリティ機能。

■ Windows Defender Credential Guard

https://ja.wikipedia.org/wiki/Windows%E3%81%AE%E3%82%BB%E3%82%AD%E3%83%A5%E3%83%AA%E3%83%86%E3%82%A3%E6%A9%9F%E8%83%BD#VBS


> Active Directoryの資格情報を管理するセキュリティ認証サブシステム(Local Security Authority Subsystem Service : LSASS)をVSM側で実行し、さらに暗号化鍵をTPM(ない場合はUEFI)で保護する事で、Windowsの特権が攻撃者に取られても、Pass-the-Hash攻撃などで資格情報が窃取されないようにする。


■ Windows Defender Device Guard

https://yamanxworld.blogspot.com/2015/11/upgrade-to-windows-10-device-guard.html

> Hyper-V の仮想化を利用してOS と分離して、カーネルモードドライバーやアプリのコードの整合性を検証して許可されていないコードをブロックする機能などを提供します。

https://ja.wikipedia.org/wiki/Windows%E3%81%AE%E3%82%BB%E3%82%AD%E3%83%A5%E3%83%AA%E3%83%86%E3%82%A3%E6%A9%9F%E8%83%BD#VBS

> アプリケーションやデバイスドライバのホワイトリスト機能。アプリケーションやデバイスドライバに正当な署名が付いている事を確認した上でこれらを実行する。「グループポリシーの「コードの整合性ポリシーを展開する」を使って、あらかじめ指定したアプリケーションだけしか動作しないように設定」する事も可能。カーネルモードで動くバイナリをチェックする「カーネルモードのコードの整合性(Kernel Mode Code Integrity:KMCI)」とユーザーモードで動くバイナリをチェックする「ユーザーモードのコードの整合性(User Mode Code Integrity:UMCI)」からなっている。

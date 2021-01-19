# Azure Security Center

統合インフラストラクチャ セキュリティ管理システム

クラウド内とオンプレミス上のハイブリッド ワークロード全体を保護する高度な脅威防止機能があります。

[製品ページ](https://azure.microsoft.com/ja-jp/services/security-center/)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/security-center/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/security-center/security-center-introduction)

[Azure Security Center Labs](https://github.com/Azure/Azure-Security-Center/tree/master/Labs)

Microsoft Learn: [Azure Security Center を使用してセキュリティ上の脅威を解決する](https://docs.microsoft.com/ja-jp/learn/modules/resolve-threats-with-azure-security-center/)

# [Azure Defender](https://docs.microsoft.com/ja-jp/azure/security-center/azure-defender)

**これは Azure Security Center の Standard 価格レベル オプションに代わるものです**。


[2020/9にリリースされた](https://docs.microsoft.com/ja-jp/azure/security-center/release-notes#azure-defender-released)。

Azure Defender は、Azure とハイブリッド ワークロードを高度かつインテリジェントに保護するために Security Center 内に統合された、クラウド ワークロード保護プラットフォーム (CWPP) です。 

Azure Defenderは、[複数の「Defender プラン」から構成されます](https://docs.microsoft.com/ja-jp/azure/security-center/azure-defender#what-resource-types-can-azure-defender-secure)。

Azure Security Center の 価格と設定 の領域から Azure Defender を有効にすると、次の Defender プランが同時にすべて有効になります。

- [Azure Defender for servers](https://docs.microsoft.com/ja-jp/azure/security-center/defender-for-servers-introduction) - [JIT VMアクセス](https://docs.microsoft.com/ja-jp/azure/security-center/just-in-time-explained)などを含む。
- [Azure Defender for App Service](https://docs.microsoft.com/ja-jp/azure/security-center/defender-for-app-service-introduction)
- [Azure Defender for Storage](https://docs.microsoft.com/ja-jp/azure/security-center/defender-for-storage-introduction)
- [Azure Defender for SQL](https://docs.microsoft.com/ja-jp/azure/security-center/defender-for-sql-introduction)
- [Azure Defender for Kubernetes](https://docs.microsoft.com/ja-jp/azure/security-center/defender-for-kubernetes-introduction)
- [Azure Defender for container registries](https://docs.microsoft.com/ja-jp/azure/security-center/defender-for-container-registries-introduction)
- [Azure Defender for Key Vault](https://docs.microsoft.com/ja-jp/azure/security-center/defender-for-key-vault-introduction)
- [Azure Defender for Resource Manager](https://docs.microsoft.com/ja-jp/azure/security-center/defender-for-resource-manager-introduction)
- [Azure Defender for DNS](https://docs.microsoft.com/ja-jp/azure/security-center/defender-for-dns-introduction)


その他のDefender
- [Microsoft 365 Defender](https://www.microsoft.com/ja-jp/microsoft-365/security/microsoft-365-defender)
- [Windows Defender](https://support.microsoft.com/ja-jp/windows/windows-%E3%82%BB%E3%82%AD%E3%83%A5%E3%83%AA%E3%83%86%E3%82%A3%E3%81%AB%E3%82%88%E3%82%8B%E4%BF%9D%E8%AD%B7%E3%82%92%E5%88%A9%E7%94%A8%E3%81%97%E3%81%BE%E3%81%99-2ae0363d-0ada-c064-8b56-6a39afb6a963) - Windows 10に組み込まれたウィルス対策プログラム
- [Azure Defender for Identity](https://docs.microsoft.com/ja-jp/defender-for-identity/what-is) - 以前Azure ATP(Advanced Thread Protection)とよばれていたもの
- [Azure Defender for IoT](https://azure.microsoft.com/ja-jp/services/azure-defender-for-iot/)


# クラウドセキュリティの2つの柱

- クラウド セキュリティ態勢管理 (CSPM: Cloud Security Posture Management) - Security Center
- クラウド ワークロード保護 (CWP: Cloud Workload Protection) - Azure Defender

※ Azure Defenderは、Security Center の統合クラウド ワークロード保護プラットフォーム (CWPP: Cloud Workload Protection Platform) である。


# [キルチェーン](https://www.google.com/search?q=%E3%82%AD%E3%83%AB%E3%83%81%E3%82%A7%E3%83%BC%E3%83%B3)

キルチェーン（英語：Kill Chain）とは、もともとは軍事で使用される言葉であり、攻撃の構造について、「目標の識別」「目標への武力の指向」「目標を攻撃するかどうかの決心と命令」「目標の破壊」 これとは逆に、敵のキルチェーンを「破壊」するという考え方は、防御法や先制措置に該当する。

https://ja.wikipedia.org/wiki/%E3%82%AD%E3%83%AB%E3%83%81%E3%82%A7%E3%83%BC%E3%83%B3



# [サイバーキルチェーン](https://www.google.com/search?q=%E3%82%B5%E3%82%A4%E3%83%90%E3%83%BC%E3%82%AD%E3%83%AB%E3%83%81%E3%82%A7%E3%83%BC%E3%83%B3)

キルチェーンの考え方をベースに、2009年にロッキード・マーチン社がサイバー攻撃に適用したものが「サイバーキルチェーン(Cyber Kill Chain)」である。

攻撃の構造を理解し、各フェーズの攻撃に対して有効な対策をとることが必要とされている。

https://www.nec-solutioninnovators.co.jp/ss/insider/security-words/35.html

いずれかの階層で脅威を断ち切るという多層防御の考え方を理解、設計するのに役立ちます。

https://www.macnica.net/solution/security_apt.html/

# [MITRE（マイター）](https://www.google.com/search?q=MITRE)

MITREは、米国の連邦政府が資金を提供する非営利組織であり、R＆Dセンターと官民のパートナーシップを通じて、国の安全性、安定性、福祉に関する事項に取り組んでいる。

http://www.intellilink.co.jp/article/column/attack-mitre-sec01.html

脆弱性に関するニュースでも参照される世界共通の脆弱性識別子「CVE」を採番している機関としても広く知られています。

https://www.cybernet.co.jp/carbonblack/tips/24.html

# [MITRE ATT&CK™ （マイター アタック）](https://www.google.com/search?q=%E3%83%9E%E3%82%A4%E3%82%BF%E3%83%BC+%E3%82%A2%E3%82%BF%E3%83%83%E3%82%AF) フレームワーク

MITREが制定した、攻撃者が利用する可能性のある200種類以上の手法を集めた包括的なナレッジベースおよび複合的なフレームワーク。

ATT&CKはCyber Kill ChainにおけるExploit以降のステージをより具体的に細分化したものだと捉えることが出来ます。

https://ox0xo.github.io/security/mitre_attck

# [セキュリティ アラート](https://docs.microsoft.com/ja-jp/azure/security-center/security-center-alerts-overview)


Security Center がリソースに対する脅威を検出したときに生成する通知です。 

Security Center では、アラートに優先順位を付け、問題の迅速な調査に必要な情報と共に一覧表示します。

[アラートのリスト](https://docs.microsoft.com/ja-jp/azure/security-center/alerts-reference)

アラートには「名前」「説明」「意図」（Intent）「重大度」が含まれています。

# [意図](https://docs.microsoft.com/ja-jp/azure/security-center/alerts-reference#intentions)

Security Center でサポートされている意図は、MITRE ATT&CK™ フレームワークに基づいています。

攻撃の意図を理解することは、イベントをより簡単に調査して報告するのに役立ちます。

# [Just-In-Time VM アクセス](https://docs.microsoft.com/ja-jp/azure/security-center/just-in-time-explained#how-jit-operates-with-network-security-groups-and-azure-firewall)

Just-In-Time VM アクセスを有効にすると、受信トラフィックをブロックする VM のポートを選択できます。 Security Center により、ネットワーク セキュリティ グループ (NSG) と Azure Firewall 規則で選択したポートに対して "すべての受信トラフィックを拒否" 規則が存在することが保証されます。 これらの規則により、Azure VM の管理ポートへのアクセスが制限され、攻撃から保護されます。

選択したポートに対して他の規則がすでに存在している場合は、既存の規則が新しい "すべての受信トラフィックを拒否" 規則よりも優先されます。 選択したポートに既存の規則がない場合は、NSG と Azure Firewall で新しい規則が優先されます。

ユーザーが VM へのアクセス権を要求すると、Security Center によってそのユーザーが VM に対する Azure ロール ベースのアクセス制御 (Azure RBAC) アクセス許可を持っているかどうかがチェックされます。 要求が承認されると、Security Center では、関連する IP アドレス (または範囲) から選択したポートへの受信トラフィックを指定された時間だけ許可するように、NSG および Azure Firewall が構成されます。 指定された時間が経過すると、Security Center により NSG が以前の状態に復元されます。 既に確立されている接続は中断されません。

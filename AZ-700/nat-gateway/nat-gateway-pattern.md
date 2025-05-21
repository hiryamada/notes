# Azure VM

VMで、デフォルトのSNATを使用する場合、SNATポート数は 1024 まで

![](VM内の1つのアプリからのNAT.drawio.svg)

---

特に、VM内で複数のコンテナーを使用して多数のアプリを稼働させると、SNATポートが枯渇しがち

![](VM内の複数のコンテナー.drawio.svg)

---

NAT Gatewayを使用することで、SNATポート枯渇を防止できる。1つのNAT Gatewayでは、1パブリックIPアドレスあたり64,512のSNATポートを使用可能

![](<仮想マシン＋NAT Gateway.drawio.svg>)

---

NAT GatewayはAzure Firewallと組み合わせて運用することも可能

![](<App Service＋NAT Gateway.drawio.svg>)

---

# Azure App Service

App Serviceの場合、1インスタンスあたりで使用可能なSNATポート数は 128 ～ 160 程度であり、1台のVMで運用する場合よりもポート枯渇が発生しやすい。

![](<App Service.drawio.svg>)

---

App Serviceでは「仮想ネットワーク統合」によりNAT Gatewayを利用できる

![](<Azure Firewall＋NAT Gateway.drawio.svg>)


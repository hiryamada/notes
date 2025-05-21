# Azure VM


VMでデフォルトのSNATを使用する場合、1024接続まで。

![](VM内の1つのアプリからのNAT.drawio.svg)

---

特にVM内で複数のコンテナーを稼働させるとSNATポートが枯渇しがち。

![](VM内の複数のコンテナー.drawio.svg)

---

仮想マシンとNAT Gatewayを組み合わせることでSNATポート枯渇を防止できる。

![](<仮想マシン＋NAT Gateway.drawio.svg>)

---

NAT GatewayはAzure Firewallと組み合わせて運用することも可能

![](<App Service＋NAT Gateway.drawio.svg>)

---

# Azure App Service

App ServiceのSNATの場合、1インスタンスあたり128～160接続程度。


![](<App Service.drawio.svg>)

---

App ServiceとNAT Gatewayを組み合わせる場合、「仮想ネットワーク統合」を使用

![](<Azure Firewall＋NAT Gateway.drawio.svg>)


# ラボ 03c - Azure PowerShell を使用して Azure リソースを管理する



## 動画

ラボの実施手順を記録した動画です。音声はありません。

AZ-104 ラボ03c Azure PowerShell を使用して Azure リソースを管理する(CloudSlice)
https://youtu.be/JkiFBDbnYo8

## 起動するラボの番号

ラボ6番を起動します。**3番ではありませんのでお気をつけください。**

## 手順書

日本語版:
https://microsoftlearning.github.io/AZ-104-MicrosoftAzureAdministrator.ja-jp/Instructions/Labs/LAB_03c-Manage_Azure_Resources_by_Using_Azure_PowerShell.html

英語版:
https://microsoftlearning.github.io/AZ-104-MicrosoftAzureAdministrator/Instructions/Labs/LAB_03c-Manage_Azure_Resources_by_Using_Azure_PowerShell.html

## ヒント

ラボの開始時、「リソースを作成する」ボタンをクリックしてください。

![](images/ss-2023-07-01-15-19-30.png)

## 参考

`New-AzDisk` を実行した際に以下のような警告が表示されます。このラボでは、無視してかまいません。

```
WARNING: Upcoming breaking changes in the cmdlet 'New-AzDisk':
Starting in November 2023 the "New-AzDisk" cmdlet will deploy with the Trusted Launch configuration by default. This includes the "HyperVGeneration" parameter to "v2".
```

AzureのVMやディスクの種類として「第1世代」と「第2世代」があります。より高度なセキュリティ機能をサポートするには、第1世代ではなく第2世代を使用します。基本的には第2世代を使用することが推奨されています。

https://learn.microsoft.com/ja-jp/windows-server/virtualization/hyper-v/plan/should-i-create-a-generation-1-or-2-virtual-machine-in-hyper-v

第1世代のVMでは、ほぼすべてのOSがサポートされますが、第2世代のVMでは、古いOSがサポートされません（たとえば Windows Server 2008やWindows 7はサポートされません）。

2023年11月より、New-AzVMコマンドレットやNew-AzDiskコマンドレットでは、既定で「トラステッド起動(Trusted Launch)」構成でデプロイされます。「トラステッド起動(Trusted Launch)」は、第2世代のVMでセキュリティを向上させる方法です。

https://learn.microsoft.com/ja-jp/azure/virtual-machines/trusted-launch-portal

2023年11月より、New-AzVMやNew-AzDiskでは、デフォルトで、第2世代のVMや、それに対応したディスクを作成します。

そのため、第2世代に対応していない古いOSを起動しようとすると、それが失敗するようになります。

したがってコマンドの実行時に警告を出して、利用者に注意喚起をしています。

以下のページで紹介されている方法で、警告の表示をオフにすることもできます。

https://zenn.dev/microsoft/articles/powershell-suppress-warning

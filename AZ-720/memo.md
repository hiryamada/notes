■4 SSPR

https://learn.microsoft.com/ja-jp/azure/active-directory/authentication/troubleshoot-sspr-writeback#confirm-network-connectivity

URL とポートへのアクセスが制限されているかどうかを判断する

Invoke-WebRequest -Uri https://ssprdedicatedsbprodscu.servicebus.windows.net -Verbose

sspr dedicated sb prod scu

■7(Q5)

Azure Traffic Manager でリソースログを有効にする

https://learn.microsoft.com/ja-jp/azure/traffic-manager/traffic-manager-diagnostic-logs

■q12

attack surface 攻撃面（を小さくする）: 攻撃を阻止する考え方

blast radius 爆風半径（を小さくする）: 攻撃が起きることを前提とした考え方

■q14

https://learn.microsoft.com/en-us/azure/defender-for-cloud/just-in-time-access-usage?tabs=jit-config-asc%2Cjit-request-asc#enable-jit-on-your-vms-from-microsoft-defender-for-cloud

JIT
22,3389,5985(WinRM HTTP),5986(WinRM HTTPS)

WinRM
https://learn.microsoft.com/ja-jp/powershell/scripting/learn/remoting/winrmsecurity?view=powershell-7.3

PowerShell リモート処理は、Windows リモート管理 (WinRM) を使用しています。これは、ユーザーがリモート コンピューター上で PowerShell コマンドを実行できるように、Microsoft によって Web Services for Management (WS-Management) プロトコルが実装されたものです。

WinRM
https://learn.microsoft.com/ja-jp/troubleshoot/windows-client/system-management-components/configure-winrm-for-https

■120 Restore point collection 復元ポイント コレクション

https://learn.microsoft.com/ja-jp/azure/backup/backup-azure-troubleshoot-vm-backup-fails-snapshot-timeout

UserErrorRpCollectionLimitReached


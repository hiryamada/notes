# リソースグループを全て削除

Cloud Shell (PowerShell)で実行
```pwsh
# ロックをすべて外す
Get-AzResourceLock | Remove-AzResourceLock -Force

# Cloud Shellで利用しているストレージアカウントを除く、すべてのリソースグループを削除
Get-AzResourceGroup |Where-Object {$_.ResourceGroupName -notlike 'cloud-shell*'} |Remove-AzResourceGroup -Force -AsJob

```

# Azureからのメール送信

[仮想マシン (VM) からのアウトバウンド メール メッセージは、Microsoft Azure の特定のサブスクリプションの種類でのみ使用できます。 TCP ポート 25 を使用するアウトバウンド SMTP 接続はブロックされました。](https://docs.microsoft.com/ja-jp/azure/virtual-network/troubleshoot-outbound-smtp-connectivity)

↓Twillo SendGridを使う

https://docs.microsoft.com/ja-jp/azure/sendgrid-dotnet-how-to-send-email

https://www.twilio.com/ja/sendgrid/email-api

https://sendgrid.kke.co.jp/docs/Integrate/Partners/Microsoft_Azure.html


# パケットキャプチャ

https://techinfoofmicrosofttech.osscons.jp/index.php?%E9%9B%BB%E6%96%87%E3%82%92%E7%A2%BA%E8%AA%8D%E3%81%99%E3%82%8B%E6%96%B9%E6%B3%95%EF%BC%88%E3%83%91%E3%82%B1%E3%83%83%E3%83%88%E3%83%BB%E3%82%AD%E3%83%A3%E3%83%97%E3%83%81%E3%83%A3%EF%BC%89

# プロセスの監視

[Procmon](https://docs.microsoft.com/en-us/sysinternals/downloads/procmon)

[ProcMon for linux](https://github.com/microsoft/ProcMon-for-Linux)
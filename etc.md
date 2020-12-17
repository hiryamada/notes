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



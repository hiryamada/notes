# Linux VMへの.NET SDKのインストール

ターミナルで、以下のコマンドを投入する。

```
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
rm packages-microsoft-prod.deb
sudo apt-get update; \
sudo apt-get install -y apt-transport-https && \
sudo apt-get update && \
sudo apt-get install -y dotnet-sdk-6.0
```

上記が完了したら、`dotnet --version` で動作を確認。

```
dotnet --version
```

`6.0.201` といったバージョン番号が出ればOK。

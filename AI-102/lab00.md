# 環境セットアップ

## Azure VMを起動

- リソースグループ名 labvm_group
- 名前 labvm
- 場所（リージョン） japaneast
- サイズ Standard D4s v5
- イメージ Windows (Windows Server 2022 Datacenter Azure Edition)

起動後リモートデスクトップで接続します。

リモートデスクトップで接続ができない場合はAzure Bastionを使用します。

## タイムゾーンを日本標準時に設定

Windows PowerShellを開き、以下を実行。

```
tzutil /s "Tokyo Standard Time"
```

## Chocolateyのインストール

Windows PowerShellを開き、以下を実行。

```
Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))
```

## .NET 7.0 SDKのインストール

```
choco install -y dotnet-7.0-sdk
```

## Visual Studio Codeのインストール

```
choco install -y vscode
```

## Azure CLIのインストール

```
choco install -y azure-cli
```

## 環境変数PATHのリフレッシュ

```
Import-Module "$env:ChocolateyInstall\helpers\chocolateyProfile.psm1"
refreshenv
```

## Visual Studio CodeにC#拡張機能をインストール

```
code --install-extension ms-dotnettools.csharp
```

## Azure CLIを使用してAzureにサインイン（ログイン）

```
az login
```

コマンドを実行するとWebブラウザーが起動し、サインインが求められます。トレーニング用に作成したMicrosoftアカウントでサインインします。


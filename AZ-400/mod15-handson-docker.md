# ハンズオン（前編） Docker

■ハンズオンの概要

- 前編
  - 作業用環境として labvm (Windows VM) を準備します
  - Docker実行のため、dockervm（Linux VM）を準備します
  - .NET で、Webアプリを作成します
  - WebアプリをDockerコンテナー化します
- 後編
  - Azure Reposに、開発したコード一式を格納します
  - Azure Container RegistryとAzure Kubernetes Serviceを準備します
  - Azure Pipelinesで、次のパイプラインを作成します
    - Dockerイメージをビルド
    - Azure Container Registryにイメージをプッシュ
    - イメージをAzure Kubernetes Serviceにデプロイ
  - Azure Kubernetes ServicesでWebアプリの動作を確認します

■ハンズオン用のWindows VM (labvm) の作成

- Cloud Shellを起動
  - https://shell.azure.com にアクセスすると起動できる
  - Bash / PowerShellどちらでもよい
- 以下のコマンドを投入
    ```
    git clone https://github.com/hiryamada/labvm2
    cd labvm2
    bash deploy.sh
    ```
- 少し待つと `Please provide securestring value for 'adminPassword' (? for help):` と表示される。Windows VM用のパスワードを入力する。
  - 12文字以上
  - 大文字・小文字・数字・記号が含まれること
- `Running...`と表示される
- `labvmrg_(乱数)` リソースグループが作成され、その中に `labvm` という Windows VMが作成される
- VMには自動的に .NET SDK や Visual Studio Codeの組み込みなどが行われる。そのため、作成完了まで15分ほどかかる。
- 作成が完了したら`Running...`という表示が消え、次のコマンドを入れられる状態となる。
- Cloud Shellを閉じる。

■labvm への接続

- リモートデスクトップ または Azure Bastion を使用して、labvm に接続する
  - ユーザー名: azureuser
  - パスワード: 先ほど入れたもの
  - [パスワードのリセット方法](https://docs.microsoft.com/ja-jp/troubleshoot/azure/virtual-machines/reset-rdp)
- ※以降の操作はvm内で実施
- 画面右側「Networks」「Do you want to allow ... 」が出た場合 Noをクリック
- 「Server Manager」
  - 「Try managing servers with Windows Admin Center」というダイアログが出る場合は「Don't show this message again」にチェックして閉じる
  - 「Server Manager」ウィンドウを閉じる
- [日本語キーボードを使用する場合](https://github.com/hiryamada/labvm2/issues/4)
- デフォルトブラウザをChromeにする
  - （Edgeは初回起動時の初期設定が大変なので、Chromeがおすすめ）
  - 左下スタートボタンをクリックし、PowerShellを開く
  - `setdefaultbrowser chrome` というコマンドを投入する

■Visual Studio Codeの初期設定

- Visual Studio Codeを起動する
- 画面左の「Extensions」アイコンをクリック
- `remote` と検索し、`Remote - SSH`をインストール
  - ※名前がよく似た `Remote - SSH: Editing Configuration Files` というものがある。`Remote - SSH`をインストールするとこれも自動的にインストールされる
  - 画面左に「Remote Explorer」アイコンが追加される
- `azure` と検索し、`Azure Tools`をインストール
  - 画面左に「Azure」アイコンと「Docker」アイコンが追加される
- 画面左に「Azure」アイコンをクリック
- 「VIRTUAL MACHINES」の「Sign in to Azure...」をクリック
- Webブラウザが起動し、Azureへのサインインが求められるので、トレーニング用に作成したMicrosoftアカウントでサインイン
- 「VIRTUAL MACHINES」の「Sign in to Azure...」が消え「Azure Pass - スポンサー プラン」と表示されればOK

■Docker利用のためのLinux VMを起動

Windows Server上ではDockerが動かないため、Docker実行用のLinux VMを別途起動する必要がある。

- 「VIRTUAL MACHINES」の「＋」をクリック
- Enter a name for the new virtual machine: dockervm
- Enter a passphrase ... : エンター（何も入れない）
- Select a location ... : Japan East
- 2分ほどで `Created new virtual machine.`と表示され、Linux VMが作成される

■Linux VMに接続

- 「VIRTUAL MACHINES」の「Azure Pass - スポンサー プラン」を展開
- dockervm を右クリックし、「Connect to Host via Remote SSH」
- 新しいVisual Studio Codeウィンドウが開く
  - 新しいVisual Studio Codeウィンドウの左下には「SSH: dockervm」と表示されているので、ここでウィンドウを判別できる
- Select the platform ... : Linux
- Are you sure ... : Continue
- 画面右下「You selected linux as the remote platform...」が出た場合→✕を押して閉じる

■Linux VMに.NET SDKをインストール

- 新しいVisual Studio Codeウィンドウ（左下には「SSH: dockervm」と表示）でTerminalメニュー＞New Terminal
- 以下のコマンドを投入
    ```
    wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb
    rm packages-microsoft-prod.deb
    sudo apt-get update; \
    sudo apt-get install -y apt-transport-https && \
    sudo apt-get update && \
    sudo apt-get install -y dotnet-sdk-6.0
    dotnet --version
    ```
- 最後の「dotnet --version」の結果として「6.0.201」といったバージョン番号が出ればOK

■.NET の Webアプリを作成

- 以下のコマンドを投入
    ```
    dotnet new web -n hello
    cd hello
    dotnet run
    ```
- 画面左下に確認が出てくるので「Open in browser」をクリック
- Webブラウザが開き「Hello World!」と表示されればOK
- Webブラウザを閉じる
- Terminal内をクリックしてアクティブにし、`Ctrl + C` を押して`dotnet run`を止める（「Application is shutting down...」と表示され、次のコマンドをが投入できる状態になればOK）

■Linux VMにDockerをインストール

- 以下のコマンドを投入
    ```
    sudo apt-get update
    sudo apt-get install -y \
        ca-certificates \
        curl \
        gnupg \
        lsb-release
    curl -fsSL https://download.docker.com/linux/ubuntu/gpg | sudo gpg --dearmor -o /usr/share/keyrings/docker-archive-keyring.gpg
    echo \
    "deb [arch=$(dpkg --print-architecture) signed-by=/usr/share/keyrings/docker-archive-keyring.gpg] https://download.docker.com/linux/ubuntu \
    $(lsb_release -cs) stable" | sudo tee /etc/apt/sources.list.d/docker.list > /dev/null
    sudo apt-get update
    sudo apt-get install -y docker-ce docker-ce-cli containerd.io
    sudo docker version
    ```
- 最後の「sudo docker version」の結果として以下のような表示が出ていればOK
    ```
    Client: Docker Engine - Community
    Version:           20.10.13
    API version:       1.41
    Go version:        go1.16.15
    Git commit:        a224086
    Built:             Thu Mar 10 14:07:52 2022
    OS/Arch:           linux/amd64
    Context:           default
    Experimental:      true

    Server: Docker Engine - Community
    Engine:
    Version:          20.10.13
    API version:      1.41 (minimum version 1.12)
    Go version:       go1.16.15
    Git commit:       906f57f
    Built:            Thu Mar 10 14:05:41 2022
    OS/Arch:          linux/amd64
    Experimental:     false
    containerd:
    Version:          1.5.10
    GitCommit:        2a1d4dbdb2a1030dc5b01e96fb110a9d9f150ecc
    runc:
    Version:          1.0.3
    GitCommit:        v1.0.3-0-gf46b6ba
    docker-init:
    Version:          0.19.0
    GitCommit:        de40ad0
    ```

■Linuxの一般ユーザーがsudoなしでDockerを実行できるようにする

※次の工程でDocker拡張機能を使うために必要

- 以下のコマンドを投入
    ```
    sudo groupadd docker
    sudo usermod -aG docker $USER
    newgrp docker
    sudo reboot
    ```
- 「Cannot reconnect. Please reload the window.」→ 30秒ほど待ってから「Reload Window」
- 以下のコマンドを投入
    ```
    docker version
    ```
- 「docker version」の結果として以下のような表示が出ていればOK
    ```
    Client: Docker Engine - Community
    Version:           20.10.13
    API version:       1.41
    Go version:        go1.16.15
    Git commit:        a224086
    Built:             Thu Mar 10 14:07:52 2022
    OS/Arch:           linux/amd64
    Context:           default
    Experimental:      true

    Server: Docker Engine - Community
    Engine:
    Version:          20.10.13
    API version:      1.41 (minimum version 1.12)
    Go version:       go1.16.15
    Git commit:       906f57f
    Built:            Thu Mar 10 14:05:41 2022
    OS/Arch:          linux/amd64
    Experimental:     false
    containerd:
    Version:          1.5.10
    GitCommit:        2a1d4dbdb2a1030dc5b01e96fb110a9d9f150ecc
    runc:
    Version:          1.0.3
    GitCommit:        v1.0.3-0-gf46b6ba
    docker-init:
    Version:          0.19.0
    GitCommit:        de40ad0
    ```

■WebアプリをDockerコンテナー化

- 以下のコマンドを投入
    ```
    cd hello
    code -r .
    ```
- Visual Studio Codeがリロードされる
- 「Do you trust...」→「Yes」
- 画面左の「Extensions」アイコンをクリック
- C#と検索→C#の「Install」をクリック
- dockerと検索
- 「Docker」（薄く表示されている）の「Install in SSH: dockervm」をクリック
  - 画面左に「Docker」アイコンが追加される
  - F1を押し「add docker」と検索→「Docker: Add Docker Files to Workspace...」
  - Select Application Platform: .NET: ASP.NET Core
  - Select Operating System: Linux
  - What port(s) does your app listen on? : そのままエンター
  - Include optional Docker Compose files? :  No
- 画面左「Explorer」アイコンをクリック（ファイル一覧）
- Dockerfileを右クリックし「Build image...」
- イメージのビルドが終わるまで少し待つ
- 以下のようなメッセージが最後に出力されればOK
    ```
    Successfully tagged hello:latest
    ```
- 画面左「Docker」アイコンをクリック
- IMAGESの「hello」を展開し、「latest」を右クリックして「Run」
- CONTAINERSの「Individual Containers」→「hello:latest」を右クリックし、「Open in Browser」
- Select the container port to browse to.: 8080 と入力してエンター。
- Webブラウザが開き「Hello World!」と表示されればOK
- Webブラウザを閉じる
- CONTAINERSの「Individual Containers」→「hello:latest」を右クリックし、「Stop」

■（後編に続く）
# ラボ6b

想定時間: 60分

Azureの2種類のロードバランサーのデプロイを学習します。

- Azure Load Balancer
- Azure Application Gateway

[ラボ6手順書](https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/blob/master/Instructions/Labs/LAB_06-Implement_Network_Traffic_Management.md)の、タスク5のロードバランサー、タスク6のApplication Gatewayを実施します。

このラボは、このページの手順に従って進めてください。

## ラボの重要ポイント

- 2つのVM（web1とweb2）を準備します。
- Webブラウザでweb1にアクセスすると「web1」が、web2にアクセスすると「web2」が表示されます。
- Azure Load Balancer を構成します。
  - バックエンドにweb1,web2を指定します。
  - Azure Load Balancer経由でweb1,web2にアクセスできることを確認します。
- Azure Application Gateway を構成します。バックエンドにweb1,web2を指定します。
  - バックエンドにweb1,web2を指定します。
  - Azure Application Gateway経由でweb1,web2にアクセスできることを確認します。

## ラボで使用するVMの準備

1. Cloud Shell を開き、**Bashを選択します**。

2. 下記のスクリプトをすべてコピーし、Cloud Shell に貼り付けて実行します。「web1」と「web2」という2つのVMが作成されます。

    ```
    rg=az104-06-rg1
    region=japaneast
    vnet=az104-06-vnet01
    subnet=subnet1

    az group create \
        --location $region \
        --name $rg

    az network vnet create \
    --name $vnet \
    --resource-group $rg \
    --address-prefixes 10.60.0.0/16 \
    --subnet-name $subnet \
    --subnet-prefixes 10.60.0.0/24

    cat <<EOF >cloud-init1.txt
    #cloud-config
    package_upgrade: true
    packages:
    - apache2
    runcmd:
    - [ sh, -c, "echo web1 > /var/www/html/index.html" ]
    EOF

    cat <<EOF >cloud-init2.txt
    #cloud-config
    package_upgrade: true
    packages:
    - apache2
    runcmd:
    - [ sh, -c, "echo web2 > /var/www/html/index.html" ]
    EOF

    az vm create \
        --location $region \
        --resource-group $rg \
        --name web1 \
        --image UbuntuLTS \
        --size Standard_B1s \
        --vnet-name $vnet \
        --subnet $subnet \
        --public-ip-sku Standard \
        --admin-username azureuser \
        --generate-ssh-keys \
        --custom-data cloud-init1.txt

    az vm open-port \
        --resource-group $rg \
        --name web1 \
        --port 80

    az vm create \
        --location $region \
        --resource-group $rg \
        --name web2 \
        --image UbuntuLTS \
        --size Standard_B1s \
        --vnet-name $vnet \
        --subnet $subnet \
        --public-ip-sku Standard \
        --admin-username azureuser \
        --generate-ssh-keys \
        --custom-data cloud-init2.txt

    az vm open-port \
        --resource-group $rg \
        --name web2 \
        --port 80

    ```

3. VM「web1」のパブリックIPアドレスをコピーします。この値をメモ帳などに記録しておきます（タスク6で使用します）

4. Webブラウザの新しいタブで「web1」のIPアドレスにアクセスします。ページ内に「web1」が表示されることを確認します。

5. 同様にVM「web2」のIPアドレスをコピーし、メモ帳などに記録しておきます（タスク6で使用します）。

6. Webブラウザの新しいタブで「web2」のIPアドレスにアクセスします。ページ内に「web2」が表示されることを確認します。

## Azure Load Balancer


7. [ラボ6手順書](https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/blob/master/Instructions/Labs/LAB_06-Implement_Network_Traffic_Management.md) のタスク5を実施してください。下記に注意してください。
   - リージョン（地域）は「東日本」（japaneast）を指定してください。
   - バックエンドプールに追加する仮想マシンは、web1とweb2を選択してください。
   - 「正常性プローブ」と「負荷分散規則」はタスク5の指示通りに作成します。
   - 「負荷分散規則」の作成後、ロードバランサーのパブリックIPにアクセスします。
   - アクセスするブラウザを変えることで、送信元のポート番号などが変化し、それによって、誘導先のVMが決定されます。ただし、ブラウザを変えることで、必ず別のVMに誘導されるかどうかはわかりません。何度か試してみてください。
     - ロードバランサーのパブリックIPにアクセスすると、「web1」または「web2」が表示されます。
     - 「InPrivateウィンドウ」、「シークレットウィンドウ」、別のブラウザ、別のPC、別の端末（携帯、タブレットなど）を使うなどして、ロードバランサーのパブリックIPにアクセスします。「web1」または「web2」が表示されます。

## Application Gateway

8. [ラボ6手順書](https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/blob/master/Instructions/Labs/LAB_06-Implement_Network_Traffic_Management.md) のタスク6を実施してください。下記に注意してください。
   - アプリケーション ゲートウェイの作成（手順が多いのでがんばってください）
     - リージョン（地域）は「東日本」（japaneast）を指定してください。
     - スケールユニット：「インスタンス数」に読み替えます。1を指定してください。
     - バックエンドプールの追加：前の手順でメモ帳などに記録しておいた「web1」「web2」のパブリックIPアドレスを指定します。
   - アプリケーション ゲートウェイの作成後、フロントエンド パブリック IP アドレスにアクセスすると、「web1」または「web2」が表示されます。
   - ブラウザを何度もリロードすると、「web1」「web2」「web1」「web2」・・・と表示されます。ラウンドロビンで負荷分散が行われている様子が確認できます。

## クリーンナップ

9. [ラボ6手順書](https://github.com/MicrosoftLearning/AZ-104JA-MicrosoftAzureAdministrator/blob/master/Instructions/Labs/LAB_06-Implement_Network_Traffic_Management.md) のページ末尾の「リソースのクリーンアップ」を実行してください。

以上です。お疲れさまでした！

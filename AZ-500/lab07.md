
# ラボ7

```
myVirtualNetwork
├Publicサブネット - myNsgPublic
│└myVmPublic（インターネットアクセス可、ストレージへのアクセス不可）
└Privateサブネット - myNsgPrivate
  │myVmPrivate（インターネットアクセス不可、ストレージへのアクセス可）
  │ ↓
  └サービスエンドポイント
     ↓
     ↓z:ドライブとしてマウント
     ↓
  ファイル共有 my-file-share

myNsgPublic
└受信セキュリティ規則(1200) *->VirtualNetwork:3389 Allow

myNsgPrivate
├受信セキュリティ規則(1200) *->VirtualNetwork:3389 Allow
├送信セキュリティ規則(1000) VirtualNetwork->Storage Allow
└送信セキュリティ規則(1100) VirtualNetwork->Internet Deny

ストレージアカウント
│（myVirtualNetworkのPrivateサブネットからのアクセスを許可）
└ファイル共有 my-file-share
```


※ラボ7で、NSGの送信セキュリティ規則の作成時に`Storage`や`Internet`などのサービスタグが選択できない場合、Azure Cloud Shell (bash) を開き、以下のコマンドを入力してください。
```
az network nsg rule create \
	--resource-group リソースグループ名 \
	--nsg-name myNsgPrivate \
	--name Allow-Storage-All \
	--direction Outbound \
	--priority 1000 \
	--source-address-prefixes VirtualNetwork \
	--destination-address-prefixes Storage \
	--access Allow

az network nsg rule create \
	--resource-group リソースグループ名 \
	--nsg-name myNsgPrivate \
	--name Deny-Internet-All \
	--direction Outbound \
	--priority 1100 \
	--source-address-prefixes VirtualNetwork \
	--destination-address-prefixes Internet \
	--access Deny
```

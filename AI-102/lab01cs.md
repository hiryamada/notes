# ラボ01

<iframe width="560" height="315" src="https://www.youtube.com/embed/cSGjkjkNi_Q?start=146" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe>

- ラボ1番を起動
- 仮想デスクトップにサインイン
- Azure portalにサインイン、UIを日本語化
- Cognitive Servicesマルチサービスアカウントを作成
  - リージョン: East US
  - リソースグループ: 作成済みの ResourceGroup1 を選択
  - 名前: cog902387423 など適当に
- キーとエンドポイントをコピー
- VSCodeを起動
- リポジトリをクローン
  - https://github.com/MicrosoftLearning/AI-102-AIEngineer
- ファイル内の文字列を置換
  - YOUR_COGNITIVE_SERVICES_ENDPOINT
  - →コピーしたエンドポイント
  - YOUR_COGNITIVE_SERVICES_KEY
  - →コピーしたキー
- 統合ターミナルで `01-getting-started/C-Sharp/rest-client` を開く
- `dotnet run`
- 「Hello」、「Bonjour」、「Gracias」などを入力し、対応する言語「English」「French」「Spanish」が表示されることを確認
- 統合ターミナルで `01-getting-started/C-Sharp/sdk-client` を開く
- `dotnet add package Azure.AI.TextAnalytics`
- `dotnet run`
- 「Hello」、「Bonjour」、「Gracias」などを入力し、対応する言語「English」「French」「Spanish」が表示されることを確認

<!--

```
az login

location='eastus'

group=ResourceGroup1

name=cog`date|md5sum|head -c6`

az cognitiveservices account create --kind CognitiveServices -l $location -n $name -g $group --sku s0 --custom-domain $name --yes

endpoint=$(az cognitiveservices account show -n $name -g $group --query properties.endpoint -otsv)

key=$(az cognitiveservices account keys list -n $name -g $group --query 'key1' -otsv)

cd ~/Documents

git clone --depth 1 https://github.com/MicrosoftLearning/AI-102-AIEngineer

cd AI-102-AIEngineer

grep -rl YOUR_COGNITIVE_SERVICES_ENDPOINT . | xargs sed -i "s|YOUR_COGNITIVE_SERVICES_ENDPOINT|$endpoint|g"

grep -rl YOUR_COGNITIVE_SERVICES_KEY . | xargs sed -i "s/YOUR_COGNITIVE_SERVICES_KEY/$key/g"

code -r 01-getting-started/C-Sharp

cd sdk-client

dotnet add package Azure.AI.TextAnalytics

dotnet run
```

-->

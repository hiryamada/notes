# ハブ&スポーク トポロジー

https://docs.microsoft.com/ja-jp/azure/architecture/reference-architectures/hybrid-networking/hub-spoke

```
オンプレミス
↓↑ VPN等
ハブVNet
├スポークVNet
└スポークVNet
```

- ハブ（中央）VNetに、Azure Firewall、VPN Gateway、Azure Bastionなどの共通サービスを配置する
- 複数のスポークVNetで、ハブの共通サービスを利用できる（コストを削減）
- 各アプリケーションやシステムはそれぞれ専用のスポークVNetで運用（ワークロードを分離）
- ハブとスポークはVNetピアリングで相互接続


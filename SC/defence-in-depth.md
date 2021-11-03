# 多層防御 (defense in-depth strategy)

https://docs.microsoft.com/ja-jp/learn/modules/describe-security-concepts-methodologies/4-describe-defense-depth

https://ja.wikipedia.org/wiki/%E5%A4%9A%E5%B1%A4%E9%98%B2%E5%BE%A1_(%E3%82%BB%E3%82%AD%E3%83%A5%E3%83%AA%E3%83%86%E3%82%A3)

- 多層防御
  - （セキュリティ侵害はあるものと想定して対策(Assume breach)）
  - 単一の境界に依存しない
  - 複数層のセキュリティアプローチを使用
  - 攻撃の進行を遅らせる
  - 階層が侵害された場合でも、別の層で攻撃を防止

- 物理的 セキュリティ(Physical security)
  - limiting access to a datacenter
- ID とアクセス セキュリティ(Identity and access security)
  - multi-factor authentication 
  - condition-based access
- 境界 セキュリティ(Perimeter security)
  - DDoS protection
- ネットワーク セキュリティ(Network security)
  - network segmentation
  - network access controls
- コンピューティング 層のセキュリティ(Compute layer security)
  - securing access to virtual machines by closing certain ports.
- アプリケーション 層のセキュリティ(Application layer security)
  - free of security vulnerabilities.
- データ 層のセキュリティ(Data layer security)
  - including controls to manage access to data
  - encryption to protect data
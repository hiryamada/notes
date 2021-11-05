# アプリケーションとサービスの開発におけるセキュリティのベストプラクティス

https://docs.microsoft.com/ja-jp/security/compass/applications-services

※ここでは、他社から提供されるアプリケーションやサービスではなく、自組織（自社）で開発するアプリケーションやサービスに焦点を当てている。

■組織の、ビジネス クリティカルなアプリケーションを特定して分類する

- ビジネスに与える影響が大きいアプリケーションを特定
  - ビジネスクリティカルなデータを扱うアプリケーション
  - ビジネスクリティカルな可用性を必要とするアプリケーション
  - 他の重要なシステムにアクセスするアプリケーション
- 外部からの攻撃リスクがあるアプリケーションを特定（※）
  - インターネットに公開されるWebアプリケーション
- 優先順位をつけてセキュリティ対策を行う

※参考: [ゼロトラスト セキュリティモデル](../SC/zero-trust.md)

■DevOpsアプローチを採用する

「ウォーターフォール型」から「DevOps（アジャイルプロセス）」に移行する

- 「ウォーターフォール型」
  - 設計～実装～テスト～リリースの期間が長い
  - アプリケーションのセキュリティ対策にも時間がかかる
- 「DevOps（アジャイルプロセス）」
  - DevOps: 継続的に価値を届けるための人・プロセス・ツールの集まり
  - セキュリティの懸念に対しても迅速に対処することができるようになる

■DevOps の標準的なセキュリティ ガイダンスに従う

すでに開発済みのガイダンスに従って、効率よく、漏れ抜けなく、対策を行う。

例: AzureでのDevSecOps

- https://azure.microsoft.com/ja-jp/solutions/devsecops/#overview
- https://docs.microsoft.com/ja-jp/azure/architecture/solution-ideas/articles/devsecops-in-azure

■カスタム実装の代わりにクラウド サービスを使用する

- 例: アプリの認証（ログイン）機能
  - カスタムのログイン機能を実装
    - 例: ログイン画面、ユーザー登録画面、パスワードの複雑さのチェック、パスワードリセット機能、ユーザーテーブル（パスワードをハッシュ化して記録する）
    - 開発に労力を要する
    - 「車輪の再発明」が行われる
    - セキュリティが低下する場合がある
      - SQLインジェクション攻撃に対する脆弱性など
  - Azure AD認証を利用
    - [Microsoft ID プラットフォーム](https://docs.microsoft.com/ja-jp/azure/active-directory/develop/v2-overview)を使用して、アプリケーションのユーザーをAzure ADで認証することができる。
    - 認証機能を独自に開発する必要がない
    - Azure ADに備わる認証機能をアプリですぐに活用できる
      - 多要素認証（MFA）
      - 条件付きアクセス
      - Identity Protection（サインインリスク、ユーザーリスクの低減）
    - セキュリティはクラウドプロバイダー側が維持

■サービスのネイティブのセキュリティ機能を使用する

暗号化、トラフィックのフィルタリング、脅威検出などにおいて、外部のセキュリティサービスではなく、クラウドが提供するセキュリティを活用する。

- 外部のセキュリティツールの導入のデメリット:
  - 導入・維持に労力を要する
  - ツールがAzureのサービスのバージョンアップに追従できない場合がある
- クラウドネイティブの（Azureに組み込まれた）セキュリティ機能のメリット:
  - 導入・維持に労力がかからない
  - Azureに組み込まれたセキュリティ機能はAzureのサービスのバージョンアップに追従する

■キーよりも Azure AD認証を選ぶ

アプリケーション（のコード、設定ファイル、環境変数など）に「パスワード」「アクセスキー」「認証キー」「APIキー」「接続文字列」を持たせない。

- 暗号化キーではなく Azure ADサービスで認証する
- 例: ストレージアカウントのアクセス
  - アクセスキー
    - キーの漏洩のリスクがある
      - 定期的なローテーションが必要
    - 細かい権限割り当てができない（フルアクセス）
  - Azure AD認証 + Azure RBACロール
    - マネージドIDを使用
      - IDやパスワード、キーを使用する必要がない
      - 漏洩の心配がない
      - キーのローテーションが不要
    - RBACロールを使用して、詳細な権限割り当てが可能
    - RBACロールを特定のスコープで割り当てることができる

■セキュリティ バグの量と影響を軽減するためのボトムアップ アプローチ

開発ライフサイクル中にセキュリティ プラクティスとツールを実装することによって、アプリケーション内のセキュリティ バグの数と潜在的な重要度を低減させる。

例: Checkmarkx CxSAST: コードを静的解析し、脆弱性を特定。たとえば、SQLインジェクション攻撃に対する脆弱性があるコードを特定することができる。
https://www.toyo.co.jp/ss/products/detail/checkmarx

■脅威モデリングを通したトップダウン アプローチ

わかりやすい解説:
https://qiita.com/takutoy/items/688b6b0517003f35e79a

- 「脅威モデル」を使用して、アプリケーションの脅威分析を行うことで、分析の際の漏れ抜けを防ぐことが可能となる。
- モデルを使用してセキュリティ対策を行うことで、アプリケーションに必要なセキュリティ対策を**事前に**洗い出すことができる。セキュリティ対策を**あとから**実施することは困難であり、コストもかかる。

■参考: Microsoft SDL

Microsoftが提供する「セキュリティ開発ライフサイクル」（Microsoft Security Development Lifecycle, SDL）を活用できる。

- 2004年頃からMicrosoftで利用されている、開発におけるセキュリティ対策。
  - 開発プロセスのすべてのフェーズでセキュリティとプライバシーに関する考慮事項を導入
  - 開発者が安全性の高いソフトウェアを構築できるようにする
  - セキュリティコンプライアンス要件に対応できるようにする
  - 開発コストを削減できるようにする
- プロセスは、トレーニング、要件、設計、実装、検証、リリース、対応の7つのフェーズに分かれている。
- Microsoftが自社開発する製品のセキュリティ対策
- [すべての Microsoft ソフトウェア開発チームは、SDL の要件に従う必要がある](https://docs.microsoft.com/ja-jp/compliance/assurance/assurance-security-development-and-operation)
- 2009年、アジャイル開発にも対応した

- [Microsoft SDL](https://www.microsoft.com/en-us/securityengineering/sdl)
- [Azure での安全な開発のベスト プラクティス(SDLの解説を含む)](https://docs.microsoft.com/ja-jp/azure/security/develop/secure-dev-overview)
- [セキュリティの開発と運用の概要](https://docs.microsoft.com/ja-jp/compliance/assurance/assurance-security-development-and-operation)
- [解説記事（publickey）](https://www.publickey1.jp/blog/09/security_development_lifecycle.html)
- [マイクロソフトセキュリティ開発ライフサイクル（Microsoft SDL）](https://ja.continuousdev.com/23582-microsoft-security-development-lifecycle-microsoft-sdl-6205)
- [Microsoft SDL の簡単な実装](https://www.microsoft.com/ja-jp/download/details.aspx?id=12379)

Microsoft SDLは、一般公開されており、一般の組織や開発者が自由に利用することができる。自社の開発プロセスにおけるセキュリティ対策の際に、SDLを参考にすることができる。

- 現在は[一般公開されている](https://www.microsoft.com/en-us/securityengineering/sdl)
- [Microsoft SDL の簡単な実装](https://www.microsoft.com/ja-jp/download/details.aspx?id=12379)より:
  - Microsoft SDLは、自由に使用することができる。
  - 「Microsoft SDL の簡単な実装」では、Microsoftの**外部のグループ**が一般的に使用している**開発プラクティスにMicrosoft SDLを適用する**場合を中心に解説している。
  - 「Microsoft SDL最適化モデル」で、4段階の「成熟度」（基本、標準、高度、動的）を定義している。


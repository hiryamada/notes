# ゼロトラスト セキュリティ モデル

ゼロ トラスト ガイダンス センター
https://docs.microsoft.com/ja-jp/security/zero-trust/



■ゼロトラスト セキュリティ モデル (Zero Trust security model)とは？ 

以下のような「原則」を組織に適用し、セキュリティを強化するという概念。

- 常に明示的な認証・承認を実施(Veryfy explicitly)
- 特権アクセスを最小化(Least privileged access)
  - ユーザーアクセスをJIT/JEAで制限
- セキュリティ侵害はあるものと想定して対策(Assume breach)
  - セグメント化により被害拡大を防ぐ

■Just Enough Administration (JEA)

https://docs.microsoft.com/ja-jp/powershell/scripting/learn/remoting/jea/overview?view=powershell-7.1

- 管理者が作業を行うのに必要な PowerShell コマンドだけにアクセスできるようにする
- 管理者に、特権を与える必要がなくなる
- PowerShell 5.0 以降で利用できる

https://www.slideshare.net/kazukitakai/powershell-50-jea-just-enough-administration-first-step

■Just-In-Time (JIT)

→ Microsoft Defender for Cloud の JIT VMアクセス

■Microsoft Defender for Cloud の JIT VMアクセス

2017/9/14 JIT VM アクセス プレビュー
https://azure.microsoft.com/ja-jp/updates/just-in-time-virtual-machine-access/

2018/3/7 JIT VM アクセス 一般提供開始
https://azure.microsoft.com/en-us/blog/just-in-time-vm-access-is-generally-available/

https://docs.microsoft.com/ja-jp/azure/security-center/just-in-time-explained

■参考: 境界セキュリティ（perimeter security）

https://www.ntt.com/bizon/glossary/j-h/perimeter-security.html

> 社内ネットワークとインターネットの境界で講じるセキュリティ対策

> 昨今ではクラウドが広く使われるようになったことで、社内ネットワークの外にも守るべき対象が存在するようになりました。また攻撃も外部から行われるとは限りません。内部不正が考えられるほか、マルウェアに感染したPCを踏み台に使い、内部からサーバーなどへ攻撃を仕掛けるといったことも考えられるためです。このように現状にそぐわなくなりつつあることから、昨今ではペリメータセキュリティに変わる新たなセキュリティモデルとして、ゼロトラストセキュリティなどに注目が集まっています。

■参考資料

- Wikipedia(en): [zero trust security model](https://en.wikipedia.org/wiki/Zero_trust_security_model)
- [NIST SP800-207 ゼロトラスト・アーキテクチャの解説（日本語訳PDFダウンロード可能）](https://www.pwc.com/jp/ja/knowledge/column/awareness-cyber-security/zero-trust-architecture-jp.html)
- [Implementing a Zero Trust security model at Microsoft](https://www.microsoft.com/en-us/insidetrack/implementing-a-zero-trust-security-model-at-microsoft)


■参考: Microsoft Learn

- [ゼロ トラスト方法について説明する](https://docs.microsoft.com/ja-jp/learn/modules/describe-security-concepts-methodologies/2-describe-zero-trust-methodology)
- [Microsoft のゼロ トラスト モデルと IAM](https://docs.microsoft.com/ja-jp/learn/modules/describe-identity-access-management-capabilities-of-microsoft-365/2-learn-identity-access-management-microsoft-zero-trust-model)
- [Microsoft Learn 組織にゼロトラストを構築する](https://docs.microsoft.com/ja-jp/learn/modules/m365-identity-zero-trust/)

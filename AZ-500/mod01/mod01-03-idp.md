# Azure AD Identity Protection

https://docs.microsoft.com/ja-jp/azure/active-directory/identity-protection/overview-identity-protection

https://jpazureid.github.io/blog/azure-active-directory/identity-protection-riskpolicy-introduction/

> Identity Protection は Microsoft が持つ脅威の検出ソリューションの一つ

> Identity Protection は Microsoft のデータセンターに蓄積された膨大なログや脅威に関するデータを基に、機械学習を用いて自動的にリスクの判定を行います

■Identity Protection （ID保護）とは？

Azure portal＞Azure AD＞セキュリティ＞Identity Protection

![](images/ss-2022-09-26-00-17-39.png)

ID ベースのリスクの検出。以下のようなサインインを検出することができる。

- 匿名 IP アドレスからのサインイン
  - [Torブラウザー](https://www.torproject.org/)等によるIPアドレス匿名化を行った状態でのサインイン
- ユーザーの最近のサインインに基づき特殊と判断された場所からのサインイン
  - 過去にアクセスされたことがない国からのサインインなど
- 指定されたユーザーで最近観察されていないプロパティを使用したサインイン
  - ユーザーが使用するIPアドレスなどを自動で学習し、そこから逸脱したプロパティを検出
- パスワードスプレー
  - よく使われるパスワードを多数のユーザーIDに対して試行する攻撃

検出された場合に以下の「修復作業」をトリガーすることができる。

- 多要素認証(MFA)を要求する
- セルフサービス パスワード リセット(SSPR)を使用したパスワードのリセットを要求する
- 管理者がアクションを実行するまで、サインインをブロックする

管理者は、ポータルの「レポート」を使用してリスクを調査することができる。

- 検出内容を確認
- 必要に応じて手動で操作(ブロック等)

詳細な分析のために、サードパーティ製ユーティリティにリスク検出データをエクスポートすることができる。

- セキュリティ情報とイベント管理 (SIEM) ツールに送り戻して、組織の適用するポリシーに基づく詳細な調査を行う
- 例: Identity Protection からMicrosoft Sentinelへのデータ接続
https://docs.microsoft.com/ja-jp/azure/sentinel/connect-azure-ad-identity-protection
  - Azure AD Identity Protection から Azure Sentinel にログをストリーミングし、Azure Sentinel にストリーミングしたアラームのダッシュボードに表示し、カスタム アラームを作成し、調査を改善できます。
  - PDF資料: [Microsoft Sentinelまとめ](../pdf/mod4/Microsoft%20Sentinel%20まとめ.pdf)

■ポリシー

3種類のポリシーを設定できる。

- 多要素認証（MFA）登録ポリシー
  - 新しいユーザーにMFAを登録させるかどうかの設定
  - ![](images/ss-2022-09-26-00-26-12.png)
- サインインリスクポリシー
  - 例
    - 匿名IPからのアクセス
    - ありえない移動
  - 正規のユーザーによるサインインが行われなかった確率をスコア化
    - スコアに基づいて、アクセスのブロック、追加のMFA要求などを発動
  - ![](images/ss-2022-09-26-00-25-54.png)
- ユーザーリスクポリシー
  - 例
    - ユーザーのID・パスワードがダークウェブに流出している場合、アクセスをブロックする
  - IDが侵害されている確率をスコア化
    - スコアに基づいて、アクセスのブロック、パスワードの変更などを発動
    - ![](images/ss-2022-09-26-00-25-23.png)

■「ユーザー リスク ポリシー」と「サインイン リスク ポリシー」の導入メリット

https://jpazureid.github.io/blog/azure-active-directory/identity-protection-riskpolicy-introduction/

サインイン リスク ポリシー

> 「リアルタイム」のリスクを検知し、「サインイン リスク ポリシー」の定義に従った制御を行います。例えば、ユーザーが Tor ブラウザーなどを利用してアクセス元の IP アドレスを隠してアクセスを試行したサインインに対して Identity Protection による制御を行えます。ここで行える制御は、対象のユーザーのサインインを「ブロック」するか「多要素認証」 (MFA) を要求させることです。例えば攻撃者がサインインを試行した際に MFA を強制することで、攻撃者が MFA を突破することは難しいためサインインを自動的に防ぐことができます。

ユーザー リスク ポリシー

> リアルタイムの情報に加えて、「オフライン」のリスクと呼ばれるリスク情報を利用して、ユーザー アカウント単位でリスクを判定したうえで「ユーザー リスク ポリシー」の定義の制御を行います。例えば Azure AD テナントに登録されているアプリケーションにサインインした後に、何らかの理由で該当ユーザーの ID とパスワードがダークウェブ上に流出したとします。Identity Protection は、ダークウェブ上の資格情報を監視しており、当該ユーザーのパスワードがダークウェブ上でやり取りされていることを確認すると、オフライン リスクである「漏洩した資格情報」を検出します。Identity Protection はこの一連のオペレーションを自動的に行います。ユーザー リスク ポリシーの制御方法としてはユーザー リスクを検知した際に対象のユーザーのアクセスを「ブロック」するか「パスワードの変更」を要求させることが可能です。


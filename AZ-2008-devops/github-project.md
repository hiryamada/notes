# GitHub Projects

## 歴史

GitHub のカンファレンス「Universe 2016」にて、カンバン機能「Projects」が追加。

https://github.blog/news-insights/product-news/a-whole-new-github-universe-announcing-new-tools-forums-and-features/

https://qiita.com/Yamotty/items/95bcd4743ab10da89db5

https://dev.classmethod.jp/articles/github-projects/

https://qiita.com/kashira2339/items/c12ff5294ef5ea290bfd

https://blog.teratail.com/entry/github-projects

1プロジェクトに以前は 1.2k までしかItemを作れなかった. 現在は プロジェクトには、最大で 50,000 個のアイテムと 10,000 個のアーカイブ済みアイテムを含めることができる。

## 公式ドキュメント

https://docs.github.com/ja/issues/planning-and-tracking-with-projects/learning-about-projects/about-projects

クイックスタート
https://docs.github.com/ja/issues/planning-and-tracking-with-projects/learning-about-projects/quickstart-for-projects

## プロジェクトの基本

- プロジェクトでは複数のリポジトリを横断してIssueを管理できる
  - プロジェクト側でIssueを作り、リポジトリに関連付ける
  - リポジトリ側でIssueを作り、プロジェクトに関連付ける
  - 必ずしもリポジトリのすべてのIssueがプロジェクトに関連付けられるわけではない。プロジェクトで管理するかどうかは好きに決めて良い
- 特定のリポジトリに結びつかない「Draft」を作成できる。
  - Convert to Issue で、Issueに変換できる

## Item

- プロジェクト側では、IssueとDraftを合わせて「Item」と呼ぶ
  - 「＋Add item」など
- 「Archive」操作
  - いわゆるItemをプロジェクトから非表示にする操作
    - Issueのアーカイブ操作は、リポジトリ側の見た目には特に影響を与えない。プロジェクトから一時的に「見えなくなる」だけ。
  - （ショートカット: `E`）
  - Itemを「アーカイブ」できる
  - 「アーカイブ」されたItemは、画面右上「...」の「Archived items」で表示できる。
  - 「Restore」操作で元に戻す（再度プロジェクト内に表示する）ことができる
- 「Delete from project」操作
  - Itemをプロジェクトから削除する
  - 画面右上「...」の「Archived items」で、複数のItemを選択して一気に削除できる
  - プロジェクト側でIssueを削除しても、プロジェクトの中にそのIssueが表示されなくなるだけであって、リポジトリ側にはそのIssueは残っている

## プロジェクト

- 画面右上「Project details」ボタン
  - クリックするとプロジェクトの情報が表示される
  - 画面上部の「Pin the side」をクリックして、プロジェクトの情報を常に右側に表示しておくことができる（オプション）
- Short description
  - プロジェクトに対する短い説明文を設定できる
- README
  - プロジェクトに対するREADMEを設定できる
- ステータス
  - 「Add status update」ボタン、または画面右上「Project details」ボタンをクリックして表示される「Add update」ボタンをクリックして、プロジェクトの「Status update」を追加できる。
    - プロジェクトの状況に関するお知らせのようなもの

## ビュー

- プロジェクトの中に表示されるタブのような部分
  - タブをクリックしてビューを切り替えできる
- 多数のIssueをある「見た目」「観点」で表示するしくみ
  - ボード、テーブル、ロードマップなど
- 画面上の「＋New View」をクリックしてビューを追加できる
- ビューには好きな名前を付けられる。デフォルトでは「View 1」といった名前になる
- ビューは削除できる
- プロジェクトには少なくとも1つビューが必要。最後のビューは削除できない。
- ビュー上部の「Filter by keyword or by field」で、条件を設定して、ビューの中から該当Itemのみ表示できる。

## 「Board」ビュー

- 「Todo」「In Progress」「Done」の3つの「Column」がある
  - ColumnはIssueやDraftの状態（Status）を表す。
  - 必要に応じて「Ready」「QA」といったColumnを増やせる
    - Boardビューの「Add a new column to the board」から
    - Project settingsの中の「Status」画面から
- ワークフロー
  - プロジェクト側で「Todo」「In Progress」のIssueを「Done」にすると、プロジェクト内でそのIssueは「Closed」となる。（Auto-close issue）

※ 「Board」ビュー以外からItemを作成すると、「Todo」「In Progress」「Done」といった状態（Status）がセットされていないItemができる。その場合「Board」ビューで「No Status」というColumnが出現し、そのItemがそこに表示される。

## 「Table」ビュー
  - すべてのItemをリスト形式で見るのに便利
  - 新しい「フィールド」を追加できる。
    - たとえば「Severity」（重大度）を追加することができる

## 「Roadmap」ビュー

https://developer.mamezou-tech.com/blogs/2023/03/28/github-projects-new-roadmaps-layout/

https://www.seeds-std.co.jp/blog/creators/2023-06-26-175547/

https://zenn.dev/kyrice2525/articles/article_tech_010

ざっくり言えば、各Itemをいつ開始しいつ終了するか（など）の情報をセットし、横長のカレンダーで表示して確認できる、というもの。

簡単な使い方:

- Roadmap ビューを追加
- ＋Add ItemをクリックしてItemを追加できる。
- Itemの番号部分を上下にドラッグすると順番を変えることができる
- Date fields をクリック、+ New field
- start date（開始日）, target date（終了日）を追加
- Item脇の「＋」をクリックすると、そのItemのstart dateとtarget dateが本日にセットされる。つまり、今日やる、という意味。
- Itemの行の上の日付をクリックすると、そのItemのstart dateとtarget dateがその日にセットされる。
  - 行に出現した横長の線をクリックして、target_date を変更できる。（複数日で実施する作業、という意味）
- 制限事項
  - 行に出現した横長の線をドラッグして日付や長さを変えたりはできない。
  - start date（開始日）, target date（終了日）の前後関係などは特にチェックされないので、終了日が開始日よりも早い、といった設定も出来てしまうことに注意

応用的な使い方:

Date fields やビューはいくつも追加できるので、応用的な使い方としては、レビュー日・テスト日・リリース日・廃止日といったフィールドを設定してプロジェクトで利用する、ということが想定される。

## マイルストーン

- プロジェクトにおいて重要な段階や中間目標を指す。
  - 設定例
    - スケジュール上動かせない日。リリース予定日 とか
    - フォーターフォール型開発での「要件定義完了」「設計完了」「実装完了」「テスト完了」など
    - または単純に「4月末」「5月末」「6月末」といったようなある決まった区切り
- マイルストーンはプロジェクト側ではなくリポジトリ側で作成する
  - リポジトリの「Issues」の画面右上「Milestones」
  - Create a milestone
  - Title、Due date (optional)、Descriptionを入力
- マイルストーンは作成されると「Open」状態となる
  - 「Close」をクリックしてクローズできる
- 各Issueは、一つのマイルストーンに関連付けできる
  - マイルストーンの状態はOpenでもCloseでも構わない
- プロジェクト側でのマイルストーン操作
  - Issueの作成・編集の画面で、Issueのマイルストーンを選択できる。
  - テーブルビューで、Milestone列を追加し、Issueのマイルストーンを表示できる
  - ビュー上部の「Filter by keyword or by field」で、「milestone:milestone1」といったようにマイルストーンを条件として設定して、ビューの中から該当Itemのみ表示できる。

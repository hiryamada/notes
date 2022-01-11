# Git

https://git-scm.com/

https://gitforwindows.org/


## なぜGitなのか

Gitに移行するアドバンテージとは。

- すでに利用者が多い（トレーニング不要な場合が多い）
- 分散開発がしやすい（ローカルリポジトリを持てる）
- [トランクベース開発がしやすい](https://cloud.google.com/architecture/devops/devops-tech-trunk-based-development?hl=ja)
- プルリクエスト（マージの依頼）
- （以上の結果として）より早いリリースサイクルが実現できる

Gitは、CI/CDと組み合わせて非常にうまく機能する。

フックを使用して、特定のアクションが発生したときにカスタムスクリプトを実行することができる。

フックについては[モジュール4](mod04.md) 「Gitフックの重要性」で解説する。

## Gitの使用に対する反対意見

Gitの弱点とは。

- 履歴が上書きできる
  - 対策
    - 設定で、上書きを禁止できる（Force pushをDeny）
    - [参考](https://qiita.com/KoKeCross/items/243f7b40ef0461f0de1e)
      - Repos / Branches / All / ... / Branch security / Contributors
      - Force push を Deny に設定
- 大きなファイル（音声、動画、Photoshop/Illustratorなど）の保存が苦手
  - 対策
    - [Git LFS](https://git-lfs.github.com/) を使う
      - コンテンツをリモートサーバーに配置するしくみ
    - プロジェクトの成果物（ビルドされるもの）はリポジトリには含めない。
      - 成果物は通常 Azure Artifacts に格納する
- 学ぶのに時間がかかる （[学習曲線がある](https://tsuhon.jp/column/7582)）
  - 初心者にとって特にブランチと同期（プッシュ・プル）が難しい
  - 対策
    - [入門サイト](https://qiita.com/yuyakato/items/41751848add5dfd5289c)などで学習
    - [GitHub Desktop](https://desktop.github.com/)のようなGUIツールを使う

## Gitをローカルで操作（Gitを使い始める）

[→基本的なgitコマンド](mod02-02-01-git-commands.md)

- git init
- git config
- git branch
- git checkout
- git status
- git add
- git commit
- git merge
- git branch --delete
- git log

## 参考: 入門サイト等

■Gitの入門資料

- [サル先生のGit入門 入門編](https://backlog.com/ja/git-tutorial/intro/01/) 
- [GitHubのGit入門](https://docs.github.com/ja/get-started)
41751848add5dfd5289c)
- [Git入門（Slideshare）](https://www.slideshare.net/y-uti/git-41040074)
- [ドットインストール Git入門 （動画）](https://dotinstall.com/lessons/basic_git)
- [Microsoft Learn: Git入門](https://docs.microsoft.com/ja-jp/learn/modules/intro-to-git/)
- マンガでわかるGit(第1話～第12話)
  - [目次](https://next.rikunabi.com/journal/tag/webdesign-manga/)
  - [第1話](https://next.rikunabi.com/journal/20160526_t12_iq/)
  - [書籍「改訂2版 わかばちゃんと学ぶ Git使い方入門」](https://www.amazon.co.jp/%E6%94%B9%E8%A8%822%E7%89%88-%E3%82%8F%E3%81%8B%E3%81%B0%E3%81%A1%E3%82%83%E3%82%93%E3%81%A8%E5%AD%A6%E3%81%B6-Git%E4%BD%BF%E3%81%84%E6%96%B9%E5%85%A5%E9%96%80%E3%80%88GitHub%E3%80%81SourceTree%E3%80%81%E3%82%B3%E3%83%9E%E3%83%B3%E3%83%89%E6%93%8D%E4%BD%9C%E5%AF%BE%E5%BF%9C%E3%80%89-%E6%B9%8A%E5%B7%9D-%E3%81%82%E3%81%84/dp/4863543433)
- [Git をはじめからていねいに](https://github.com/Shinpeim/introduction-to-git)
- [Gitスタイルガイド](https://github.com/objectx/git-style-guide)

■Gitの入門資料へのリンク集
- [Gitを学び直したい人に見て欲しい。遊んで学べる、無料のGit学習サービス5選！](https://omuriceman.hatenablog.com/entry/enjoy-git)
- [Git、GitHubを教える時に使いたい資料まとめ](https://qiita.com/yuyakato/items/41751848add5dfd5289c)
  - Try Gitは現在利用できないもよう。

■Gitの学習（中級～上級）

- [サル先生のGit入門 発展編](https://backlog.com/ja/git-tutorial/stepup/01/) 
- [Pro Git 日本語版 電子書籍](http://git-scm.com/book/ja/v2) - [紹介](https://progit-ja.github.io/)
- [Learn Git Branching](https://k.swd.cc/learnGitBranching-ja/)

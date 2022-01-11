# 変更ログ(Changelog)の実装

## 変更ログ（Changelog）とは。

- プロジェクトの各バージョン（各リリース）で行われた変更点を記載したMarkdownファイル
  - リリースのバージョンと日付
    - 新機能
    - バグフィックス
    - 互換性を壊すような変更
    - プルリクエストのマージ記録
    - その他の（プロジェクト内部の重要な変更点など）
- 多くの場合 CHANGELOG.md というファイル名で、リポジトリのトップに置かれる
- サンプル
  - [1](https://github.com/rails/rails/blob/main/activerecord/CHANGELOG.md)
  - [2](https://github.com/git-chglog/git-chglog/blob/master/CHANGELOG.md)
    - [※Chore（チョーア）：雑用](https://ejje.weblio.jp/content/chore)
- [良いChangeLog、良くないChangeLog](https://efcl.info/2015/06/18/good-changelog/)

## ジェネレータ

変更ログのジェネレータがいくつか存在する。

- [gitchangelog](https://pypi.org/project/gitchangelog/) ... 2018/12以降、メンテされていない？
- [github-changelog-generator](https://github.com/github-changelog-generator/github-changelog-generator)
- [git-chglog](https://github.com/git-chglog/git-chglog)

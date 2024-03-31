# アクセスレビュー

https://docs.microsoft.com/ja-jp/azure/active-directory/governance/access-reviews-overview

グループへのメンバーシップ（所属）、アプリケーションへのアクセス、ロールの割り当て（Entra IDロールとAzure RBACロール）を定期的にレビューし、不要なメンバーシップ・アクセス・ロール割り当てを削除する仕組み。

[Premium P2ライセンスが必要](https://docs.microsoft.com/ja-jp/azure/active-directory/governance/access-reviews-overview#license-requirements)。[必要なライセンス数](https://docs.microsoft.com/ja-jp/azure/active-directory/governance/access-reviews-overview#how-many-licenses-must-you-have)

■アクセスレビューの例: グループ

(1)レビューの作成 - レビュー作成者の操作

https://docs.microsoft.com/ja-jp/azure/active-directory/governance/create-access-review

- Entra ID＞グループ＞アクセスレビュー
- ＋新しいアクセスレビュー
  - グループを選択
  - レビュー範囲を選択（「すべてのユーザー」または「ゲストユーザーのみ）
  - レビュー担当者を選択
    - 「ユーザーまたはグループが選択済み」を選び、担当者を選択
  - 開始日、期間（日数）、繰り返しを設定
  - リソースの結果への自動適用
    - 有効: 拒否されたユーザーを自動でグループから削除
    - 無効: レポートに記録するだけ

実施日になると、レビュー担当者にメールが送信される

(2)レビューの実施 - 各レビュー担当者の操作

https://docs.microsoft.com/ja-jp/azure/active-directory/governance/perform-access-review

- レビュー依頼のメール内のリンクをクリック
  - または myaccess.microsoft.com の「アクセスレビュー」に移動し、対象のレビューをクリックして、レビューを開始する
- 各ユーザーをクリック
- 「承認する」「拒否」「不明」をクリック
  - 「承認する」: グループへの所属を維持
  - 「拒否」: グループから削除
  - 「不明」: グループへの所属を維持する。
- 「理由」を入力。
  - 他のレビュー担当者に表示される。
  - レポートに記録される。

レビュー期間が終了するまでは、承認や拒否の再設定ができる。

(3)レビューの完了

https://docs.microsoft.com/ja-jp/azure/active-directory/governance/complete-access-review

自動適用が有効な場合は、レビュー結果が自動的に適用される。

自動適用が有効ではない場合は、手動で「適用」を実行する。

■アクセスレビューの例: ロールの割り当て

https://docs.microsoft.com/ja-jp/azure/active-directory/privileged-identity-management/pim-how-to-start-security-review

https://docs.microsoft.com/ja-jp/azure/active-directory/privileged-identity-management/pim-how-to-perform-security-review


■複数のレビュー担当者がいる場合は？

https://docs.microsoft.com/ja-jp/azure/active-directory/governance/perform-access-review#approve-or-deny-access-for-one-or-more-users

レビュー担当者が複数いる場合、最後に送信された応答が記録される。

例:
- あるグループにユーザー1が所属している。
- そのグループのレビューを作成する。
- 管理者1がレビューを実施し、ユーザー1の所属を承認した。
- 続いて、別の管理者2がレビューを実施し、ユーザー1の所属を拒否した。
- この場合、最終的に、ユーザー1の応答として「拒否」が記録される。

■期間内にレビューがされなかった場合は？

レビュー作成時の「レビュー担当者が応答しない場合」で設定したものが、レビュー期間終了時に反映される。

- 変更なし
- アクセスの削除
- アクセスを承認する
- 推奨事項の実行
  - システムの推奨設定を適用


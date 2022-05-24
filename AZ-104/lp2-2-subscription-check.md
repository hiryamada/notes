# 知識チェック - Azure サブスクリプション/ポリシー/ロール

# ラーニングパス 2: [AZ-104:Azure での ID とガバナンスの管理](https://docs.microsoft.com/ja-jp/learn/paths/az-104-manage-identities-governance/)
## モジュール 3: [サブスクリプションを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-subscriptions/)
- ユニット 9: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-subscriptions/9-knowledge-check)
  - 第1問 サブスクリプションで「予算」を設定できる。また、予算（コスト）に対して、一定額を上回った場合の「アラート」を設定し、管理者に通知することができる。
  - 第2問 リソースに対してタグを設定できる。タグを使って、リソースのコストを集計できる。
  - 第3問 リージョンを選択することで、データの所在地が「東日本リージョン」といったようにある場所に定まる。あるリージョンから別のリージョンへデータをレプリケーションするなどして、回復性を高めることができる（リージョン障害の際に別のリージョンでシステムやデータを利用できる）。
## モジュール 4: [Azure Policy を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-policy/)
- ユニット 9: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-policy/9-knowledge-check)
  - 第1問 複数のポリシーをまとめて適用したい→ポリシーの集まりである「イニシアティブ」を定義し、それを割り当てる。
  - 第2問 [「リソースグループでタグを必須とする」](https://docs.microsoft.com/ja-jp/azure/azure-resource-manager/management/tag-policies)などのポリシーを割り当てて、タグの割り当てを必須にする。
  - 第3問 [「許可されている仮想マシン サイズSKU」](https://docs.microsoft.com/ja-jp/azure/governance/policy/samples/built-in-policies#compute)ポリシーを使用して、指定されている以外のSKU以外の仮想マシン作成を禁止することができる。
  - 第4問 複数のサブスクリプションをまとめて管理する（複数のサブスクリプションに共通のポリシーを割り当てる等）場合は、管理グループを作り、サブスクリプションを管理グループ以下に移動する。
## モジュール 5: [ロールベースのアクセス制御の構成](https://docs.microsoft.com/ja-jp/learn/modules/configure-role-based-access-control/)
- ユニット 8: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-role-based-access-control/8-knowledge-check)
  - 第1問 新しい従業員はVM3だけ管理できればよい。VM3のスコープで、新しい従業員に、「共同作成者」ロールを割り当てる。VMを新しいリソースグループに移動するのはより手間がかかる（管理の「オーバーヘッド」（余分な作業）が大きい）。
  - 第2問 Azureロールは、Azureリソースのスコープで割り当てる（他に、管理グループ、サブスクリプション、リソースグループのスコープで割り当てすることもできる）。Azure ADロールは、ユーザーやグループに対して割り当てる。
  - 第3問 [カスタムロール定義](https://docs.microsoft.com/ja-jp/azure/role-based-access-control/custom-roles#custom-role-example)には、名前、ID、カスタムロールかどうかのフラグ、説明文、アクション（リソースに対して可能な操作）、Notアクション（除外するアクション）、データアクション（リソース内のデータに対して可能な操作）、Notデータアクション（データアクションから除外する操作）、割り当て可能なスコープ、の記述が含まれる。
## モジュール 7: [Azure ロールベースのアクセス制御 (Azure RBAC) を使用した Azure リソースのセキュリティ保護](https://docs.microsoft.com/ja-jp/learn/modules/secure-azure-resources-with-rbac/)
- ユニット 3: [知識チェック - Azure RBAC とは](https://docs.microsoft.com/ja-jp/learn/modules/secure-azure-resources-with-rbac/3-knowledge-check-rbac-overview)
  - 第1問 簡単に言えば、ロール定義にはアクセス許可（アクション）が含まれる。
  - 第2問 共同作成者は、リソースの管理（作成・削除・変更・一覧など）が可能。他のユーザーへのロールの割り当てはできない。
  - 第3問 スコープの種類は、上位から、管理グループ、サブスクリプション、リソースグループ、リソース。上位のスコープで割り当てられたロールは下位のスコープへと継承される。
- ユニット 7: [知識チェック - Azure RBAC を使用する](https://docs.microsoft.com/ja-jp/learn/modules/secure-azure-resources-with-rbac/7-knowledge-check-rbac)
  - 第1問
  - 第2問
  - 第3問

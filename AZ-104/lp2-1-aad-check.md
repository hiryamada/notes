# 知識チェック - Azure AD

# ラーニングパス 2: [AZ-104:Azure での ID とガバナンスの管理](https://docs.microsoft.com/ja-jp/learn/paths/az-104-manage-identities-governance/)
## モジュール 1: [Azure Active Directory を構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-active-directory/)
- ユニット 8: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-azure-active-directory/8-knowledge-check)
  - 第1問 Azure ADは、「ユーザーID」などのID管理を行うソリューションである。OAuth/OpenIDなどの新しい認証・認可プロトコルに対応する。オンプレミスAD DSのような「組織単位（OU）」・「グループポリシーオブジェクト（GPO）」といった仕組みは持たず、LDAPには非対応。OU・GPO・LDAP等が必要な場合はオンプレミスAD DSとAzure ADを組み合わせて使用する（ハイブリッドID）。
  - 第2問 Azure ADには「テナント」が作成される。各テナントは組織を表す（テナントは組織ごとに用意される）。テナントは、Azure ADの[インスタンス](https://ja.wikipedia.org/wiki/%E3%82%A4%E3%83%B3%E3%82%B9%E3%82%BF%E3%83%B3%E3%82%B9)である。つまり、Azure ADの世界には、「テナント」がたくさん存在している。
  - 第3問 デバイスをAzure ADに「参加」させると、デバイスに、「学校または職場アカウント」（＝Azure ADのユーザーID）を使用してサインインできるようになる。また、デバイスのサインイン情報を使用して、クラウドアプリケーション等にシングルサインオンできるようになる。[「参加」の設定例](https://jpazureid.github.io/blog/azure-active-directory/aadj-link-is-not-displayed/#%E8%A3%9C%E8%B6%B3-%E6%89%8B%E5%8B%95%E3%81%A7-Azure-AD-%E5%8F%82%E5%8A%A0%E3%82%92%E6%A7%8B%E6%88%90%E3%81%99%E3%82%8B%E6%89%8B%E9%A0%86)
## モジュール 2: [ユーザー アカウントとグループ アカウントを構成する](https://docs.microsoft.com/ja-jp/learn/modules/configure-user-group-accounts/)
- ユニット 7: [知識チェック](https://docs.microsoft.com/ja-jp/learn/modules/configure-user-group-accounts/7-knowledge-check)
  - 第1問 「共同作成者」: リソースの管理（作成など）が可能（正解）。「所有者」: リソースの管理（作成など）が可能＋ロール割り当てが可能。「Reader（閲覧者）」: リソースの情報の読み取り（一覧、詳細表示など）が可能。
  - 第2問 外部の組織のユーザーをゲストとして招待する（「ゲストユーザー」アカウントを作成する）ことができる。ゲストユーザーは、招待されたテナントで作業を行うことができる。
  - 第3問 Azure ADの「全体管理者」（「グローバル管理者」とも）は、テナントの全操作が可能。
## モジュール 6: [Azure Active Directory に Azure のユーザーとグループを作成する](https://docs.microsoft.com/ja-jp/learn/modules/create-users-and-groups-in-azure-active-directory/)
- ユニット 2: [Azure Active Directory のユーザー アカウントとは](https://docs.microsoft.com/ja-jp/learn/modules/create-users-and-groups-in-azure-active-directory/2-user-accounts-azure-ad)
  - ※ページ下部に知識チェックあり
  - 第1問 ユーザーは削除から30日以内であれば復元することができる
  - 第2問 外部の組織のユーザーをゲストとして招待する（「ゲストユーザー」アカウントを作成する）ことができる。ゲストユーザーは、招待されたテナントで作業を行うことができる。
## モジュール 7: [Azure ロールベースのアクセス制御 (Azure RBAC) を使用した Azure リソースのセキュリティ保護](https://docs.microsoft.com/ja-jp/learn/modules/secure-azure-resources-with-rbac/)
- ユニット 7: [知識チェック - Azure RBAC を使用する](https://docs.microsoft.com/ja-jp/learn/modules/secure-azure-resources-with-rbac/7-knowledge-check-rbac)
  - 第1問 「アクセスの確認」では、ユーザーIDを指定して、そのユーザーのアクセス（ロール割り当て）を確認できる（正解）。「ロールの割り当て」でも確認できるが、指定したユーザーではなく、リソースに対するアクセス（ロール割り当て）を持つ全ユーザーのリストが表示される。
  - 第2問 （部門のVMがあるリソースグループに含まれている場合）そのリソースグループのスコープで、VM管理用のロールを割り当てると、部門のVMをすべて管理できる。
  - 第3問 あるユーザーが「リソース グループへのフル アクセスを必要としている」ので、そのリソースグループで「所有者」ロールを割り当てる。[最小権限の原則](https://ja.wikipedia.org/wiki/%E6%9C%80%E5%B0%8F%E6%A8%A9%E9%99%90%E3%81%AE%E5%8E%9F%E5%89%87)に基づく場合、ユーザーに余分な権限を与える（より上位のスコープでユーザーにロールを割り当てる）べきではない。
  - 第4問 アクティビティログを使用して、指定した期間の操作（ロール割り当て等の操作を含む）の一覧を取得できる。
## モジュール 8: [Azure Active Directory のセルフサービス パスワード リセット を使用して、ユーザーがパスワードをリセットできるようにする](https://docs.microsoft.com/ja-jp/learn/modules/allow-users-reset-their-password/)
- ユニット 2: [Azure Active Directory のセルフサービス パスワード リセット とは](https://docs.microsoft.com/ja-jp/learn/modules/allow-users-reset-their-password/2-self-service-password-reset)
  - ※ページ下部に知識チェックあり
  - 第1問 ユーザーは、「モバイルアプリ通知」「電子メール」「携帯電話」「セキュリティの質問」などいくつかの認証（確認）方法を登録する。管理者が指定した数の認証（確認）方法を登録すると、SSPR登録状態（SSPRが有効）となる。
  - 第2問 SSPRにより、ユーザーは、（パスワードを忘れてしまったなどの）サインインできない場合に、自力でパスワードをリセットできる。

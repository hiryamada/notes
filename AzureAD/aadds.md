# Azure Active Directory Domain Service (AAD DS)

Azure上で、Active Directory ドメインコントローラを運用するためのマネージド・サービス。

ドメイン サービス (ドメイン参加、グループ ポリシー、ライトウェイト ディレクトリ アクセス プロトコル (LDAP)、Kerberos/NTLM 認証など)がマネージド型で提供される。

ドメインコントローラを必要とするオンプレミスのアプリをAzureに移行する際に使用される。

[製品ページ](https://azure.microsoft.com/ja-jp/services/active-directory-ds/)

[ドキュメント](https://docs.microsoft.com/ja-jp/azure/active-directory-domain-services/overview)

[価格](https://azure.microsoft.com/ja-jp/pricing/details/active-directory-ds/)

■構成

内部的に 2 つの仮想マシン (ドメイン コントローラー) が生成され、指定した Azure 仮想ネットワーク上に接続される。これらのドメイン コントローラーは従来 Windows Server で運用されていたドメイン コントローラーと完全な互換性がある。

複製やバックアップは自動的に管理される。

■導入シナリオ

Azure ADサポートチームのブログ記事を参照
https://jpazureid.github.io/blog/azure-active-directory/azure-ad-ds-scenario/

（「利用パターン1」より抜粋）

- オンプレミスで Active Directory と共に動作していたサーバーを Azure 上に仮想マシンとして移行 (リフト アンド シフト) したい
- Azure 上に仮想マシンとして移行 (リフト アンド シフト) したサーバーに、Azure AD に同期されているものと同じ ID およびパスワードでサインインしたい

移行前:
```
オンプレミスAD DS
| (Kerberos/NTLM認証)
オンプレミスのサーバー
└業務システム等
```

移行後:

```
オンプレミスAD DS
|
| (Azure AD Connect)
|
Azure AD
|
Azure AD DS
| (Kerberos/NTLM認証)
Azure仮想マシン(VM)
└業務システム等
```

■料金

1時間あたり $ 0.15（Standardの場合）

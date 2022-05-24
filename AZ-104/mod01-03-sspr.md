# 管理者による、ユーザーのパスワードのリセット

ユーザーが自分のパスワードを忘れてしまった場合、[管理者は、ユーザーのパスワードをリセットできます。](https://docs.microsoft.com/ja-jp/azure/active-directory/fundamentals/active-directory-users-reset-password-azure-portal)

[管理者アカウントは、デフォルトで、セルフサービスのパスワード リセットが有効になっています](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-policy#administrator-reset-policy-differences)。一般ユーザーとは異なるルールが適用されます。

# セルフサービス パスワードリセット(SSPR)

[Azure AD のセルフサービス パスワード リセット](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-howitworks)

- SSPRを使用すると、ユーザーが自分のパスワードを忘れてしまった場合、管理者やヘルプ デスクが関与することなく、自分のパスワードをリセットすることができます。
- ユーザーは、画面の指示に従って、自分自身のロックを解除して、作業に戻ることができます。
- 組織のヘルプ デスクの問い合わせが減り、生産性の喪失も軽減されます。
- [SSPRの有効範囲](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/tutorial-enable-sspr#enable-self-service-password-reset)は、「なし」「選択済み（指定したグループ）」「すべて」の3種類から選ぶことができます。現在、Azure portal を使用して SSPR に対して有効にできる Azure AD グループは 1 つだけです。

[SSPRを使用するには、ライセンスの割り当てが必要です。](https://docs.microsoft.com/en-us/azure/active-directory/authentication/concept-sspr-licensing)

- [Azure AD Premium P1 or P2](https://azure.microsoft.com/ja-jp/pricing/details/active-directory/)
- Microsoft 365 Business Standard または Microsoft 365 Business Premium でも、[SSPRを利用できます](https://docs.microsoft.com/ja-jp/azure/active-directory/authentication/concept-sspr-licensing)

ご参考：SSPRだけが必要な場合、[LogonBox](https://www.logonbox.com/en/)のようなSSPRソリューションを使用するという方法もあります。1000ユーザーの場合、LogonBoxのほうが97%安くなります。

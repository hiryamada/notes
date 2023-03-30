# プライマリ更新トークン (Primary Refresh Token、PRT)

■「シームレスSSO(sSSO)」から「プライマリ更新トークン(PRT)」へ

https://learn.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sso

Windows 7 と Windows 8.1 の場合、シームレス SSO を使用することをお勧めします。

Windows 10、Windows Server 2016、およびそれ以降のバージョンの場合は、プライマリ更新トークン (PRT) を介した SSO を使用することをお勧めします。

■プライマリ更新トークンとは？

PRT（Primary Refresh Token、プライマリ更新トークン）は、Azure ADが、認証の完了時に発行する認証トークンの一種。

Azure ADに登録されているデバイス（個人所有のモバイルデバイス等）、または参加している（会社所有のWindows PC等）デバイスの場合に発行される。

ユーザーがデバイスをアクティブに使用している限り継続的に更新される。

発行されたPRTの有効期限は14日で、その間、認証なしで、アクセストークン・リフレッシュトークン・セッショントークンを取得できる。

Azure AD ConnectなどでPRT使用を有効化するといった操作は特に必要ない。条件が整えば自動的に使用される。

■「シームレスSSO(sSSO)」と「プライマリ更新トークン(PRT)」は組み合わせて使用できる

https://learn.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sso-faq#azure-ad-join--------sso------------------------------

テナントで PRT（Azure AD Join） とシームレス SSO を両方とも使用できる。

PRT（Azure AD Join） がシームレス SSO に優先して使用される。

■「シームレスSSO(sSSO)」の無効化

不要な場合は、シームレスSSOを無効化することもできる。

https://learn.microsoft.com/ja-jp/azure/active-directory/hybrid/how-to-connect-sso-faq#------sso----------------

■参考

PRTについては、以下のページの説明がわかりやすい。

https://sharedtechv.wordpress.com/2021/09/26/azuread%E3%81%8C%E7%99%BA%E8%A1%8C%E3%81%99%E3%82%8B%E8%AA%8D%E8%A8%BC%E3%83%88%E3%83%BC%E3%82%AF%E3%83%B3%E3%81%AB%E3%81%A4%E3%81%84%E3%81%A6/

以下の動画で、PRTについて解説されている。

https://youtu.be/BU-nVn9CDmw?t=977

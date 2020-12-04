# Azure Files

サーバー メッセージ ブロック (SMB) プロトコルまたはネットワーク ファイル システム (NFS) プロトコルを介してアクセスできる、フル マネージドのファイル共有です。

Azure Files SMB ファイル共有には、Windows、Linux、および macOS クライアントからアクセスできます。

Azure Files NFS ファイル共有には、Linux または macOS クライアントからアクセスできます。 

クラウドまたはオンプレミスから同時にマウントできます。

Azure Filesの中に「ファイル共有」を作り、「ファイル」をアップロードします。


# Azure ファイル共有へのAD DS認証

Azure Files では、**オンプレミス Active Directory Domain Services (AD DS) と Azure Active Directory Domain Services (Azure AD DS)** という 2 種類の Domain Services を使用した、**サーバー メッセージ ブロック (SMB) 経由の ID ベースの認証**がサポートされます。

https://docs.microsoft.com/ja-jp/azure/storage/files/storage-files-identity-auth-active-directory-enable


# Azure File Sync

データが使用されている場所の近くから高速アクセスするため、Azure File Sync を使用して、Windows サーバーに Azure Files SMB ファイル共有をキャッシュできます。


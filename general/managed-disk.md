# マネージドディスク

2017/2/11 一般提供開始
https://azure.microsoft.com/ja-jp/updates/azure-managed-disks-ga/

ユーザーに代わってストレージ アカウントの管理を行うことで Azure IaaS VM のディスク管理を簡略化する機能
https://docs.microsoft.com/ja-jp/azure/virtual-machines/faq-for-disks#azure-managed-disks--------

2017/2/8に投稿されたブログ
https://azure.microsoft.com/ja-jp/blog/announcing-general-availability-of-managed-disks-and-larger-scale-sets/

マネージド ディスクは、ストレージ アカウントの規模管理から解放されます。
ストレージ アカウントを気にせず、ディスクの詳細を指定しなくても、数千の Managed Disks を作成できます。
空のディスクを作成したり、ストレージ アカウントの VHD から作成したり、VM 作成の一環としてイメージから作成したりできます。

スナップショット
スナップショットを使用すると、任意の時点で管理ディスクをバックアップできます
これらのスナップショットはソースディスクとは無関係に存在し、新しい管理ディスクの作成に使用できます。

イメージ
管理ディスクでは、管理されたカスタムイメージの作成もサポートしています。
ストレージ アカウントのカスタム VHD からイメージを作成することも、実行中の VM から直接イメージを作成することもできます。
これは、OS とデータ ディスクの両方を含む、実行中の仮想マシンに関連付けられているすべての管理ディスクを 1 つのイメージにキャプチャします。


以前は、VM起動時に、OSディスク・データディスクを格納するストレージアカウントを指定していた。

マネージド ディスク、スナップショット、およびイメージは Azure リソース マネージャー リソースであるため、
それぞれにAzure RBACを使用して詳細なアクセス制御を適用できるようになりました。

Azure ディスク暗号化を使用して、マネージドディスクを顧客管理キーまたはマイクロソフト管理キーで暗号化することもできます。

管理ディスクを標準から Premium に簡単に移行できるようになりました

■増分スナップショット

https://docs.microsoft.com/ja-jp/azure/virtual-machines/disks-incremental-snapshots?tabs=azure-cli

# エンタープライズ アプリケーション

■組織が使用するすべてのアプリケーションをAzure ADテナントに追加する（推奨）

https://learn.microsoft.com/ja-jp/azure/active-directory/fundamentals/five-steps-to-full-application-integration-with-azure-ad

組織が新しいアプリケーションの使用を開始したら、すぐにそれを Azure AD テナントに追加することが推奨されている。

https://learn.microsoft.com/ja-jp/azure/active-directory/manage-apps/overview-application-gallery

アプリケーションをAzure AD テナントに追加することで、アプリケーションへのサインインにAzure ADを使用できる。

■Azure AD アプリケーション ギャラリー

「Azure AD アプリケーション ギャラリー」を使用すると、何千ものアプリケーションをすぐにAzure ADテナントに追加できる。

Azure portal＞Azure AD＞エンタープライズ アプリケーション＞＋新しいアプリケーション
![](images/ss-2023-03-01-22-10-27.png)

![](images/ss-2023-03-01-22-10-46.png)

■チュートリアル

https://learn.microsoft.com/ja-jp/azure/active-directory/saas-apps/tutorial-list

主要なアプリケーションをAzure ADに追加するためのチュートリアルが提供されている。

Salesforce、ServiceNow、Adobe Creative Cloud、Slack、Zoom、AWS、Google Cloudなど・・・。

![](images/ss-2023-03-01-22-11-39.png)

■「エンタープライズ アプリケーション」の「所有者」※ロールではない

https://learn.microsoft.com/ja-jp/azure/active-directory/manage-apps/assign-app-owners?pivots=portal

Azure ADユーザーが、エンタープライズ アプリケーションを登録すると、そのユーザーは、そのエンタープライズ アプリケーションの「所有者」となる。

「エンタープライズ アプリケーション」の「所有者」は、他の「所有者」を追加または削除できる。

「アプリケーション管理者」ロールや「クラウド アプリケーション管理者」ロールを持つユーザーは、組織内のエンタープライズ アプリケーションに「所有者」を割り当てることができる。

「所有者」は、シングル サインオン、プロビジョニング、ユーザー割り当てなど、アプリケーションの組織固有の構成を管理できる。

「所有者」は、自分が所有するアプリケーションのみを管理できる。

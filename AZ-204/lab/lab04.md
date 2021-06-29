ラボ4は、
[Visual Studio Code で Azure Cosmos DB 向けの .NET Core アプリを構築する](https://docs.microsoft.com/ja-jp/learn/modules/build-cosmos-db-app-with-vscode/)
を実施してください。

演習の3つ目（ユニット4）まで実施すればOKです。

以下、演習の3つ目（ユニット4）まで実施した状態のコードです。


```cs
using System;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Newtonsoft.Json;
namespace learning_module
{
    class Program
    {
        private DocumentClient client;
        static void Main(string[] args)
        {
            try
            {
                Program p = new Program();
                p.BasicOperations().Wait();
            }
            catch (DocumentClientException de)
            {
                Exception baseException = de.GetBaseException();
                Console.WriteLine("{0} error occurred: {1}, Message: {2}", de.StatusCode, de.Message, baseException.Message);
            }
            catch (Exception e)
            {
                Exception baseException = e.GetBaseException();
                Console.WriteLine("Error: {0}, Message: {1}", e.Message, baseException.Message);
            }
            finally
            {
                Console.WriteLine("End of demo, press any key to exit.");
                Console.ReadKey();
            }            
        }
        private async Task BasicOperations()
        {
            this.client = new DocumentClient(new Uri(ConfigurationManager.AppSettings["accountEndpoint"]), ConfigurationManager.AppSettings["accountKey"]);

            await this.client.CreateDatabaseIfNotExistsAsync(new Database { Id = "Users" });

            await this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri("Users"), new DocumentCollection { Id = "WebCustomers" });

            Console.WriteLine("Database and collection validation complete");

            User yanhe = new User
            {
                Id = "1",
                UserId = "yanhe",
                LastName = "He",
                FirstName = "Yan",
                Email = "yanhe@contoso.com",
                OrderHistory = new OrderHistory[]
                    {
                        new OrderHistory {
                            OrderId = "1000",
                            DateShipped = "08/17/2018",
                            Total = "52.49"
                        }
                    },
                    ShippingPreference = new ShippingPreference[]
                    {
                            new ShippingPreference {
                                    Priority = 1,
                                    AddressLine1 = "90 W 8th St",
                                    City = "New York",
                                    State = "NY",
                                    ZipCode = "10001",
                                    Country = "USA"
                            }
                    },
            };

            await this.CreateUserDocumentIfNotExists("Users", "WebCustomers", yanhe);

            User nelapin = new User
            {
                Id = "2",
                UserId = "nelapin",
                LastName = "Pindakova",
                FirstName = "Nela",
                Email = "nelapin@contoso.com",
                Dividend = "8.50",
                OrderHistory = new OrderHistory[]
                {
                    new OrderHistory {
                        OrderId = "1001",
                        DateShipped = "08/17/2018",
                        Total = "105.89"
                    }
                },
                ShippingPreference = new ShippingPreference[]
                {
                    new ShippingPreference {
                            Priority = 1,
                            AddressLine1 = "505 NW 5th St",
                            City = "New York",
                            State = "NY",
                            ZipCode = "10001",
                            Country = "USA"
                    },
                    new ShippingPreference {
                            Priority = 2,
                            AddressLine1 = "505 NW 5th St",
                            City = "New York",
                            State = "NY",
                            ZipCode = "10001",
                            Country = "USA"
                    }
                },
                Coupons = new CouponsUsed[]
                {
                    new CouponsUsed{
                        CouponCode = "Fall2018"
                    }
                }
            };

            await this.CreateUserDocumentIfNotExists("Users", "WebCustomers", nelapin);

            await this.ReadUserDocument("Users", "WebCustomers", yanhe);

            yanhe.LastName = "Suh";
            await this.ReplaceUserDocument("Users", "WebCustomers", yanhe);

            await this.DeleteUserDocument("Users", "WebCustomers", yanhe);

        }


        public class User
        {
            [JsonProperty("id")]
            public string Id { get; set; }
            [JsonProperty("userId")]
            public string UserId { get; set; }
            [JsonProperty("lastName")]
            public string LastName { get; set; }
            [JsonProperty("firstName")]
            public string FirstName { get; set; }
            [JsonProperty("email")]
            public string Email { get; set; }
            [JsonProperty("dividend")]
            public string Dividend { get; set; }
            [JsonProperty("OrderHistory")]
            public OrderHistory[] OrderHistory { get; set; }
            [JsonProperty("ShippingPreference")]
            public ShippingPreference[] ShippingPreference { get; set; }
            [JsonProperty("CouponsUsed")]
            public CouponsUsed[] Coupons { get; set; }
            public override string ToString()
            {
                return JsonConvert.SerializeObject(this);
            }
        }

        public class OrderHistory
        {
            public string OrderId { get; set; }
            public string DateShipped { get; set; }
            public string Total { get; set; }
        }

        public class ShippingPreference
        {
            public int Priority { get; set; }
            public string AddressLine1 { get; set; }
            public string AddressLine2 { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string ZipCode { get; set; }
            public string Country { get; set; }
        }

        public class CouponsUsed
        {
            public string CouponCode { get; set; }

        }

        private void WriteToConsoleAndPromptToContinue(string format, params object[] args)
        {
            Console.WriteLine(format, args);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadKey();
        }

        private async Task CreateUserDocumentIfNotExists(string databaseName, string collectionName, User user)
        {
            try
            {
                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, user.Id), new RequestOptions { PartitionKey = new PartitionKey(user.UserId) });
                this.WriteToConsoleAndPromptToContinue("User {0} already exists in the database", user.Id);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    await this.client.CreateDocumentAsync(UriFactory.CreateDocumentCollectionUri(databaseName, collectionName), user);
                    this.WriteToConsoleAndPromptToContinue("Created User {0}", user.Id);
                }
                else
                {
                    throw;
                }
            }
        }
        private async Task ReadUserDocument(string databaseName, string collectionName, User user)
        {
            try
            {
                await this.client.ReadDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, user.Id), new RequestOptions { PartitionKey = new PartitionKey(user.UserId) });
                this.WriteToConsoleAndPromptToContinue("Read user {0}", user.Id);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    this.WriteToConsoleAndPromptToContinue("User {0} not read", user.Id);
                }
                else
                {
                    throw;
                }
            }
        }


        private async Task ReplaceUserDocument(string databaseName, string collectionName, User updatedUser)
        {
            try
            {
                await this.client.ReplaceDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, updatedUser.Id), updatedUser, new RequestOptions { PartitionKey = new PartitionKey(updatedUser.UserId) });
                this.WriteToConsoleAndPromptToContinue("Replaced last name for {0}", updatedUser.LastName);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    this.WriteToConsoleAndPromptToContinue("User {0} not found for replacement", updatedUser.Id);
                }
                else
                {
                    throw;
                }
            }
        }

        private async Task DeleteUserDocument(string databaseName, string collectionName, User deletedUser)
        {
            try
            {
                await this.client.DeleteDocumentAsync(UriFactory.CreateDocumentUri(databaseName, collectionName, deletedUser.Id), new RequestOptions { PartitionKey = new PartitionKey(deletedUser.UserId) });
                Console.WriteLine("Deleted user {0}", deletedUser.Id);
            }
            catch (DocumentClientException de)
            {
                if (de.StatusCode == HttpStatusCode.NotFound)
                {
                    this.WriteToConsoleAndPromptToContinue("User {0} not found for deletion", deletedUser.Id);
                }
                else
                {
                    throw;
                }
            }
        }
    }

    
}


```


以下、本家のラボ4のかんたんな説明

```
フォルダ Starter
  AdventureWorks.bacpac --- SQL DBのバックアップデータ

プロジェクト AdventureWorks.Models
  Model.cs --- 「モデル」のクラス。名称、カテゴリ、説明文など
  Product.cs --- 「製品」のクラス。名称、番号、色、サイズ、重量、価格など

プロジェクト AdventureWorks.Context
  Interfaces
    IAdventureWorksProductContext.cs --- ModelとProductを取得するためのインターフェース
  AdventureWorksCosmosContext.cs --- 上記インターフェースのCosmos実装
  AdventureWorksSqlContext.cs --- 上記インターフェースのSQL DB実装

プロジェクト AdventureWorks.Web
  Pages
    Index.cshtml.cs --- モデル一覧画面
    Details.cshtml.cs --- 製品一覧画面
  Startup.cs --- 使用するContext(SQL DB実装 / Cosmos DB実装)を指定

プロジェクト AdventureWorks.Migrate
  Programs.cs --- 移行(SQL DBの全データを読み取り、Cosmos DBへUpsert)

```
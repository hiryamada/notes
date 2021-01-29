/*

document: https://azuresdkdocs.blob.core.windows.net/$web/dotnet/Azure.Messaging.EventGrid/4.0.0-beta.4/index.html

dotnet add package Azure.Messaging.EventGrid
→error: 利用可能な安定バージョンがありません。利用可能な中では 4.0.0-beta.4 が最善です。--prerelease オプションを追加することをご検討ください

dotnet add package Azure.Messaging.EventGrid --prerelease

*/

using System;
using System.Collections.Generic;
using Azure.Messaging.EventGrid;
using Azure;

var topicEndpoint = "YOUR_ENDPOINT_HERE";
var topicKey = "YOUR_TOPICKEY_HERE"; // THIS IS JUST A SAMPLE CODE. Please use KeyVault in your code !!!

var cred = new AzureKeyCredential(topicKey);

var client = new EventGridPublisherClient(new Uri(topicEndpoint), cred);

var events = new List<EventGridEvent>();

var firstPerson = new
{
    FullName = "Alba Sutton",
    Address = "4567 Pine Avenue, Edison, WA 97202"
};

var firstEvent = new EventGridEvent(
    // ID
    firstPerson.ToString(),
    // Subject
    $"New Employee: {firstPerson.FullName}",
    // EventType
    "Employees.Registration.New",
    // DataVersion
    "1.0"
);

events.Add(firstEvent);

var secondPerson = new
{
    FullName = "Alexandre Doyon",
    Address = "456 College Street, Bow, WA 98107"
};

var secondEvent = new EventGridEvent(
    // ID
    Guid.NewGuid().ToString(),
    // Subject
    $"New Employee: {secondPerson.FullName}",
    // EventType
    "Employees.Registration.New",
    // DataVersion
    "1.0.0"
);

events.Add(secondEvent);

client.SendEvents(events);

Console.WriteLine("Events published");

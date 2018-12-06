using System;
using Microsoft.Azure.CognitiveServices.Search;
using Microsoft.Azure.CognitiveServices.Search.WebSearch;
using Microsoft.Azure.CognitiveServices.Search.WebSearch.Models;
using Newtonsoft.Json;

namespace Bing
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Acesso Prof
            var subscriptionKey = "5783dbc5562e4297a79a3e9f2f0aca2c";
            Console.WriteLine("Digite o nome de uma personalidade:");
            var nome = Console.ReadLine();

            var client = new WebSearchClient(new ApiKeyServiceClientCredentials(subscriptionKey));
            var result = client.Web.SearchAsync(nome).Result;
            Console.WriteLine(JsonConvert.SerializeObject(result));
            Console.Read();
            #endregion

            #region Acesso Mine
            subscriptionKey = "68f2823182e9473d865b1e595d1e6f7a";
            Console.WriteLine("Digite o nome de uma personalidade:");
            nome = Console.ReadLine();

            client = new WebSearchClient(new ApiKeyServiceClientCredentials(subscriptionKey));
            result = client.Web.SearchAsync(nome).Result;
            Console.WriteLine(JsonConvert.SerializeObject(result));
            Console.Read();
            #endregion
        }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.Azure.CognitiveServices;
using Microsoft.Azure.CognitiveServices.Vision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision;
using Microsoft.Azure.CognitiveServices.Vision.ComputerVision.Models;
using Newtonsoft.Json;

namespace CognitiveServices
{
    class Program
    {
        static void Main(string[] args)
        {
            var features = new List<VisualFeatureTypes>
            {
                VisualFeatureTypes.Faces,
                VisualFeatureTypes.Tags,
                VisualFeatureTypes.Description,
                VisualFeatureTypes.Categories
            };

            #region do Prof.
            var subscriptionKey = "002d9cf2be714679abeedb67f0bf137a";
            var imageUrl = "https://media.metrolatam.com/2018/08/03/11969651high-ac4a6a6fc08c572da85948d147c6baf5-1200x600.jpg";

            var client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey));
            client.Endpoint = "https://brazilsouth.api.cognitive.microsoft.com/";            

            var result = client.AnalyzeImageAsync(imageUrl, features).Result;

            Console.WriteLine(JsonConvert.SerializeObject(result));

            Console.Read();
            #endregion

            #region Mine            
            subscriptionKey = "6dba8e71f28e469bb04bbb8ac0f0a3c7";
            imageUrl = "https://media.metrolatam.com/2018/08/03/11969651high-ac4a6a6fc08c572da85948d147c6baf5-1200x600.jpg";

            client = new ComputerVisionClient(new ApiKeyServiceClientCredentials(subscriptionKey));
            client.Endpoint = "https://brazilsouth.api.cognitive.microsoft.com/";

            result = client.AnalyzeImageAsync(imageUrl, features).Result;

            Console.WriteLine(JsonConvert.SerializeObject(result));

            Console.Read();
            #endregion            
        }
    }
}

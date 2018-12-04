using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=trezenet;AccountKey=AXwUsljgM169Q3c9IvcunCdagOXypuVtbaSs/mMmPCrPuMADu9rW7BYeEAE/B5Qm5v9sM956wpbBjpJYoj/8UQ==;EndpointSuffix=core.windows.net");
            var queueClient = account.CreateCloudQueueClient();

            var queue = queueClient.GetQueueReference("rm330381");
            queue.CreateIfNotExistsAsync().Wait();

            again:
            Console.WriteLine("Digite uma mensagem:");
            var msg = Console.ReadLine();

            queue.AddMessageAsync(new CloudQueueMessage(msg));
            var messages = queue.GetMessagesAsync(10).Result;
            foreach(var m in messages)
            {
                Console.WriteLine($"Mensagem: {m.AsString}");                
            }

            Console.WriteLine("Deseja apagar as mensagens?");
            if (Console.ReadLine().ToLower() == "s")
                foreach(var m in messages)
                    queue.DeleteMessageAsync(m);

            Console.ReadKey();
            goto again;
        }
    }
}

using System;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Table;

namespace ExemploStorage
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=storage13netigor;AccountKey=gDhuZlVAUkXSs/iNmMWZEnG9T0cC/2pJ6zX3+x3hOsRZ4N4ev0G7FKDhumMhXlEH/nl2xXbqtRlzUbmQWxr5YQ==;EndpointSuffix=core.windows.net");

            #region blob
            //var blobClient = account.CreateCloudBlobClient();
            //var container = blobClient.GetContainerReference("rm330381");

            //container.CreateIfNotExistsAsync().Wait();

            //var blob = container.GetBlockBlobReference("igor3.txt");
            //blob.UploadTextAsync("Olá Mundo !");

            //var sas = blob.GetSharedAccessSignature(new SharedAccessBlobPolicy()
            //{
            //    Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write, //Necessário para poder ter acesso a leitura
            //    SharedAccessExpiryTime = DateTime.Now.AddYears(5) //Necessário passar uma SE (Shared Expiry) para funcionar
            //});

            //Console.WriteLine(blob.Uri + sas);
            #endregion

            #region table (na verdade é chave, valor kkk)
            var client = account.CreateCloudTableClient();
            var table = client.GetTableReference("rm330381");
            table.CreateIfNotExistsAsync().Wait();

            var entity = new Aluno("rm330381", "sao paulo");
            entity.Nome = "Igor";
            entity.Email = "igorcabralfacul@gmail.com";

            table.ExecuteAsync(TableOperation.Insert(entity));
            #endregion

            Console.Read();
        }
    }
}

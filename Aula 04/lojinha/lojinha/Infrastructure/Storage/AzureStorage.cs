﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using lojinha.Core.Models;
using lojinha.Core.Entities;

namespace lojinha.Infrastructure.Storage
{
    public class AzureStorage : IAzureStorage
    {
        private readonly CloudStorageAccount _account;
        private readonly CloudTableClient _tableClient;
        public AzureStorage(IConfiguration config)
        {
            _account = CloudStorageAccount.Parse(
                config.GetSection("Azure:Storage").Value);

            _tableClient = _account.CreateCloudTableClient();
        }

        public void AddProduto(Produto produto)
        {
            var json = JsonConvert.SerializeObject(produto);

            var table = _tableClient.GetTableReference("produtos");
            table.CreateIfNotExistsAsync();

            var entity = new ProdutoEntity("13net", produto.Id.ToString());
            entity.Produto = json;

            TableOperation operation = TableOperation.Insert(entity);
            table.ExecuteAsync(operation).Wait();
        }

        public async Task<Produto> ObterProduto(string id)
        {
            var table = _tableClient.GetTableReference("produtos");
            table.CreateIfNotExistsAsync().Wait();

            var query = new TableQuery<ProdutoEntity>()
                .Where(
                TableQuery.GenerateFilterCondition
                ("PartitionKey", QueryComparisons.Equal, "13net"))
                .Where(
                TableQuery.GenerateFilterCondition
                ("RowKey", QueryComparisons.Equal, id));

            TableContinuationToken token = null;

            var segment = await table
                .ExecuteQuerySegmentedAsync(query, token);
            var produtoEntity = segment.FirstOrDefault();

            return JsonConvert.DeserializeObject<Produto>(produtoEntity.Produto);
        }

        public async Task<List<Produto>> ObterProdutos()
        {
            var table = _tableClient.GetTableReference("produtos");
            table.CreateIfNotExistsAsync().Wait();

            var query = new TableQuery<ProdutoEntity>()
                .Where(
                TableQuery.GenerateFilterCondition
                ("PartitionKey", QueryComparisons.Equal, "13net"));

            TableContinuationToken token = null;

            var segment = await table
                .ExecuteQuerySegmentedAsync(query, token);
            var produtosEntity = segment.ToList();

            return produtosEntity.Where(x => x.Produto != null && x != null).Select(x =>
                JsonConvert.DeserializeObject<Produto>(x.Produto)
            ).ToList();
        }
    }
}

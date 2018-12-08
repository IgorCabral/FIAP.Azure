using lojinha.Core.Models;
using lojinha.Infrastructure.Redis;
using lojinha.Infrastructure.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lojinha.Core.Services
{
    public class ProdutoServices : IProdutoServices
    {
        private readonly IRedisCache _cache;
        private readonly IAzureStorage _storage;

        public ProdutoServices(IRedisCache cache, IAzureStorage storage)
        {
            _cache = cache;
            _storage = storage;
        }

        public Task<Produto> ObterProduto(string id)
        {
            return _storage.ObterProduto(id);
        }        

        public async Task<List<Produto>> ObterProdutos() //PATTERN: cache aside
        {
            var key = "produtos";
            var value = _cache.Get(key);

            if (string.IsNullOrWhiteSpace(value))
            {
                var produtos = await _storage.ObterProdutos();

                _cache.Set(key, JsonConvert.SerializeObject(produtos));

                return produtos;
            }

            return JsonConvert.DeserializeObject<List<Produto>>(value);
        }
    }
}

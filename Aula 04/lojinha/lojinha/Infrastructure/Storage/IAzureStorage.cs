using lojinha.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lojinha.Infrastructure.Storage
{
    public interface IAzureStorage
    {
        void AddProduto(Produto produto);

        Task<List<Produto>> ObterProdutos();

        Task<Produto> ObterProduto(string id);
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;
using lojinha.Core.Models;

namespace lojinha.Core.Services
{
    public interface IProdutoServices
    {
        Task<List<Produto>> ObterProdutos();
        Task<Produto> ObterProduto(string id);
    }
}
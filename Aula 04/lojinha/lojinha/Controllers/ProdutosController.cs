using AutoMapper;
using lojinha.Core.Models;
using lojinha.Core.Services;
using lojinha.Core.ViewModels;
using lojinha.Infrastructure.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lojinha.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private IProdutoServices _produtoServices;
        private IMapper _mapper;
        public ProdutosController(IProdutoServices produtoService, IMapper mapper)
        {
            _produtoServices = produtoService;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            var produto = new Produto
            {
                Id = 330381,
                Nome = "Smart HUWAEII",
                Categoria = new Categoria
                {
                    Id = 1,
                    Nome = "Celulares"
                },
                Descricao = "HUWAEII ChingLing",
                Fabricante = new Fabricante
                {
                    Id = 10,
                    Nome = "HUWAEII"
                },
                Preco = 1000m,
                Tags = new[] { "xingling", "celular", "hwaeii", "tlesecinquenta" },
                ImagemPrincipalUrl = "https://www.worten.pt/i/c48999b700e802c2ba6f62ab609a7bec08e2a9ee.jpg"
            };
            //_produtoServices.AddProduto(produto);
            //TODO: ProdutoServico.Add(produto);

            return Content("OK");
        }

        public async Task<IActionResult> List()
        {
            var produtos = await _produtoServices.ObterProdutos();
            var vm = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return View(vm);
        }

        public async Task<IActionResult> Details(string id)
        {
            var produto = await _produtoServices.ObterProduto(id);
            return Json(produto);
        }
    }
}

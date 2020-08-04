using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DesenvolvimentoWeb.Projeto01.Models;

namespace DesenvolvimentoWeb.Projeto01.Controllers
{
    public class InicioController : Controller
    {
        //primeiro action: string
        public string MostrarTexto()
        {
            return $"<h1>Conceitos do MVC</h1>";
        }

        public FileResult MostrarPDF()
        {
            return File("arquivos/apostila.pdf", "application/pdf");
        }

        public FileResult MostrarImagem()
        {
            return File("arquivos/leao.jpg", "image/jpeg");
        }

        public ActionResult MostrarConteudo()
        {
            return View("Index");
        }

        public IActionResult Index()
        {
            return View();
        }

        //trabalhando com a classe produto
        //1 - Criando um objeto e aprensentado para o usuario
        public IActionResult MostrarProduto()
        {
            var produto = new Produto { Codigo = 1, Descricao = "Produto 01", Preco = 25.36 };

            return View(produto);
        }

        //2 - Lista de Produtos - List
        public IActionResult ListarProdutos1()
        {
            List<Produto> lista = new List<Produto> {
                new Produto{ Codigo = 1, Descricao = "Produto 01", Preco = 63.16},
                new Produto{ Codigo = 2, Descricao = "Produto 02", Preco = 40.99},
                new Produto{ Codigo = 3, Descricao = "Produto 03", Preco = 17.97},
                new Produto{ Codigo = 4, Descricao = "Produto 04", Preco = 52.14},
                new Produto{ Codigo = 5, Descricao = "Produto 05", Preco = 98.99}
            };

            return View(lista);
        }

        //3 - Lista de Produtos - HashSet
        public IActionResult ListarProdutos2()
        {
            HashSet<Produto> lista = new HashSet<Produto> {
                new Produto{ Codigo = 1, Descricao = "Produto 06", Preco = 13.16},
                new Produto{ Codigo = 2, Descricao = "Produto 07", Preco = 32.99},
                new Produto{ Codigo = 3, Descricao = "Produto 08", Preco = 25.97}
            };

            return View("ListarProdutos1", lista);
        }

        //4 - Formulario de cadastro de produtos
        [HttpGet]
        public IActionResult CadastroProduto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastroProduto(Produto prod)
        {
            if(prod.Codigo <= 100)
            {
                ModelState.AddModelError("Codigo", "O código deve ser maior que 100");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }
            return View("MostrarProduto", prod);
        }
    }
}
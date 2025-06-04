using Microsoft.AspNetCore.Mvc;
using ProjetoProduto.Models;
using ProjetoProduto.Repositorio;

namespace ProjetoProduto.Controllers
{
    public class ProdutoController : Controller
    {
        // Declarando uma váriavel privada somente para leitura do tipo ProdutoRepositorio chamada  "_ProdutoRepositorio"
        private readonly ProdutoRepositorio _ProdutoRepositorio;

        // Definindo o construtor da classe ProdutoController e vai receber uma instância de ProdutoRepositorio
        public ProdutoController(ProdutoRepositorio ProdutoRepositorio)
        {
            _ProdutoRepositorio = ProdutoRepositorio;
        }

        public IActionResult Cadastro()
        {
            // Retorna a View  Cadastro.
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Produto produto)
        {
            // Verifica se o ModelState é válido. O ModelState é considerado válido se não houver erros de validação.
            if (ModelState.IsValid)
            {
                _ProdutoRepositorio.AdicionarProduto(produto);
            }

            /* Se o ModelState não for válido (houver erros de validação):
             Retorna a View de Cadastro novamente, passando o objeto Produto com os erros de validação.
             Isso permite que a View exiba os erros para o usuário corrigir o formulário.*/
            return View();

        }
    }

}

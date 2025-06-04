using Microsoft.AspNetCore.Mvc;
using ProjetoProduto.Models;
using ProjetoProduto.Repositorio;

namespace ProjetoProduto.Controllers
{
    public class UsuarioController : Controller
    {
        // Declarando uma váriavel privada somente para leitura do tipo UsuarioRepositorio chamada  "_usuarioRepositorio"
        private readonly UsuarioRepositorio _usuarioRepositorio;

        // Definindo o construtor da classe UsuarioController e vai receber uma instância de UsuarioRepositorio
        public UsuarioController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Cadastro()
        {
            // Retorna a View  Cadastro.
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            // Verifica se o ModelState é válido. O ModelState é considerado válido se não houver erros de validação.
            if (ModelState.IsValid)
            {
                /* Se o modelo for válido:
                 Chama o método AdicionarUsuario do _usuarioRepositorio, passando o objeto Usuario recebido.
                 Isso  salvará as informações do novo usuário no banco de dados.*/

                _usuarioRepositorio.AdicionarUsuario(usuario);

                /* Redireciona o usuário para a action "Login" deste mesmo Controller (LoginController).
                  após um cadastro bem-sucedido, redirecionará à página de login.*/
                return RedirectToAction("Login");
            }

            /* Se o ModelState não for válido (houver erros de validação):
             Retorna a View de Cadastro novamente, passando o objeto Usuario com os erros de validação.
             Isso permite que a View exiba os erros para o usuário corrigir o formulário.*/
            return View(usuario);

        }

        public IActionResult Contato()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string senha)
        {
            /* Chama o método ObterUsuario do _usuarioRepositorio, passando o email fornecido pelo usuário.
            Isso buscará um usuário no banco de dados com o email correspondente.*/
            var usuario = _usuarioRepositorio.ObterUsuario(email);
            // Verifica se um usuário foi encontrado for diferente de vazio e se a senha fornecida corresponde à senha do usuário encontrado.
            if (usuario != null && usuario.Senha == senha)
            {
                // Autenticação bem-sucedida
                // Redireciona o usuário para a action "Index" do Controller "Cliente".
                return RedirectToAction("Cliente", "Cliente");
            }
            /* Se a autenticação falhar (usuário não encontrado ou senha incorreta):
             Adiciona um erro ao ModelState. ModelState armazena o estado do modelo e erros de validação.
             O primeiro argumento ("") indica um erro
             O segundo argumento é a mensagem de erro que será exibida ao usuário.*/

            ModelState.AddModelError("", "Email ou senha inválidos.");
            //retorna view Login 
            return View();
        }
    }

}

using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Projeto_MVC___ProvaDjalma.Models;

namespace Projeto_MVC___ProvaDjalma.Controllers
{
    public class CadastrosController : Controller
    {
     public IActionResult Index()
        {
            return View();
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public IActionResult DeletarConfirmacao()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Controllers
{
    public class EquipamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

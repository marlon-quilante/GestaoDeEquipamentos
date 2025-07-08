using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Controllers
{
    public class FabricanteController : Controller
    {
        private RepositorioFabricanteEmArquivo repositoryManufactor;

        public FabricanteController()
        {
            ContextoDados context = new ContextoDados(true);
            repositoryManufactor = new RepositorioFabricanteEmArquivo(context);
        }

        public IActionResult Index()
        {
            List<Fabricante> manufactors = repositoryManufactor.GetRegisters();

            return View(manufactors);
        }

        [HttpGet] //Opcional, pois o framework entende que é GET se deixar sem o atributo
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(string name, string email, string phone)
        {
            Fabricante newManufactor = new Fabricante(name, email, phone);

            repositoryManufactor.Create(newManufactor);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            Fabricante manufactor = repositoryManufactor.GetRegisterByID(id);

            if (manufactor == null)
                return RedirectToAction(nameof(Index));

            return View(manufactor);
        }

        [HttpPost]
        public IActionResult Editar(int id, string name, string email, string phone)
        {
            Fabricante updatedManufactor = new Fabricante(name, email, phone);

            bool successEdit = repositoryManufactor.Update(updatedManufactor, id);

            if (!successEdit)
                return RedirectToAction(nameof(Index));

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            Fabricante manufactor = repositoryManufactor.GetRegisterByID(id);

            if (manufactor == null)
                return RedirectToAction(nameof(Index));

            return View(manufactor);
        }

        [HttpPost]
        public IActionResult ExcluirConfirmado(int id)
        {
            repositoryManufactor.Delete(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

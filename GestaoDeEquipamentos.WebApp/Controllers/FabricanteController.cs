using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Controllers
{
    public class FabricanteController : Controller
    {
        private RepositorioFabricanteEmArquivo repositorioFabricante;

        public FabricanteController()
        {
            ContextoDados contexto = new ContextoDados(true);
            repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);
        }

        public IActionResult Index()
        {
            List<Fabricante> fabricantes = repositorioFabricante.BuscarRegistros();

            return View(fabricantes);
        }

        [HttpGet] //Opcional, pois o framework entende que é GET se deixar sem o atributo
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(string nome, string email, string telefone)
        {
            Fabricante novoFabricante = new Fabricante(nome, email, telefone);

            repositorioFabricante.Cadastrar(novoFabricante);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            Fabricante fabricante = repositorioFabricante.BuscarRegistroPeloID(id);

            if (fabricante == null)
                return RedirectToAction(nameof(Index));

            return View(fabricante);
        }

        [HttpPost]
        public IActionResult Editar(int id, string nome, string email, string telefone)
        {
            Fabricante fabricanteAtualizado = new Fabricante(nome, email, telefone);

            bool sucessoEdicao = repositorioFabricante.Editar(fabricanteAtualizado, id);

            if (!sucessoEdicao)
                return RedirectToAction(nameof(Index));

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            Fabricante fabricante = repositorioFabricante.BuscarRegistroPeloID(id);

            if (fabricante == null)
                return RedirectToAction(nameof(Index));

            return View(fabricante);
        }

        [HttpPost]
        public IActionResult ExcluirConfirmado(int id)
        {
            repositorioFabricante.Excluir(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

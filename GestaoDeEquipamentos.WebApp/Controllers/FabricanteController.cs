using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using GestaoDeEquipamentos.WebApp.Models;
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

            VisualizarFabricantesViewModel visualizarVM = new VisualizarFabricantesViewModel(fabricantes);

            return View(visualizarVM);
        }

        [HttpGet] //Opcional, pois o framework entende que é GET se deixar sem o atributo
        public IActionResult Cadastrar()
        {
            CadastrarFabricanteViewModel cadastrarVM = new CadastrarFabricanteViewModel();

            return View(cadastrarVM);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarFabricanteViewModel cadastrarVM)
        {
            Fabricante novoFabricante = new Fabricante(cadastrarVM.Nome, cadastrarVM.Email, cadastrarVM.Telefone);

            repositorioFabricante.Cadastrar(novoFabricante);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            Fabricante fabricante = repositorioFabricante.BuscarRegistroPeloID(id);

            if (fabricante == null)
                return RedirectToAction(nameof(Index));

            EditarFabricanteViewModel editarVM = new EditarFabricanteViewModel(
                fabricante.Id,
                fabricante.Nome,
                fabricante.Email,
                fabricante.Telefone);

            return View(editarVM);
        }

        [HttpPost]
        public IActionResult Editar(int id, EditarFabricanteViewModel editarVM)
        {
            Fabricante fabricanteAtualizado = new Fabricante(editarVM.Nome, editarVM.Email, editarVM.Telefone);

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

            ExcluirFabricanteViewModel excluirVM = new ExcluirFabricanteViewModel(id, fabricante.Nome);

            return View(excluirVM);
        }

        [HttpPost]
        public IActionResult ExcluirConfirmado(int id)
        {
            repositorioFabricante.Excluir(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

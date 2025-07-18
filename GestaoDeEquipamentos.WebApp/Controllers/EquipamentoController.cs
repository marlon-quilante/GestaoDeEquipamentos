using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using GestaoDeEquipamentos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Controllers
{
    public class EquipamentoController : Controller
    {
        private RepositorioEquipamentoEmArquivo repositorioEquipamento;
        private RepositorioFabricanteEmArquivo repositorioFabricante;

        public EquipamentoController()
        {
            ContextoDados contexto = new ContextoDados(true);
            repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);
            repositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);
        }

        public IActionResult Index()
        {
            List<Equipamento> equipamentos = repositorioEquipamento.BuscarRegistros();

            VisualizarEquipamentosViewModels visualizarVM = new VisualizarEquipamentosViewModels(equipamentos);

            return View(visualizarVM);
        }

        public IActionResult Cadastrar()
        {
            List<Fabricante> fabricantes = repositorioFabricante.BuscarRegistros();

            CadastrarEquipamentoViewModel cadastrarVM = new CadastrarEquipamentoViewModel(fabricantes);

            return View(cadastrarVM);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarEquipamentoViewModel cadastrarVM)
        {
            Fabricante fabricanteSelecionado = repositorioFabricante.BuscarRegistroPeloID(cadastrarVM.FabricanteID);

            if (fabricanteSelecionado == null)
                return RedirectToAction(nameof(Index));

            Equipamento novoEquipamento = new Equipamento(cadastrarVM.Nome, cadastrarVM.Preco, cadastrarVM.NumeroSerie, fabricanteSelecionado, cadastrarVM.DataFabricacao);

            repositorioEquipamento.Cadastrar(novoEquipamento);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            Equipamento equipamentoSelecionado = repositorioEquipamento.BuscarRegistroPeloID(id);

            List<Fabricante> fabricantes = repositorioFabricante.BuscarRegistros();

            EditarEquipamentoViewModel editarVM = new EditarEquipamentoViewModel(equipamentoSelecionado.Id, equipamentoSelecionado.Nome, equipamentoSelecionado.Preco, 
                equipamentoSelecionado.NumeroSerie, equipamentoSelecionado.Fabricante.Id, equipamentoSelecionado.DataFabricacao, fabricantes);

            return View(editarVM);
        }

        [HttpPost]
        public IActionResult Editar(int id, EditarEquipamentoViewModel editarVM)
        {
            Fabricante fabricanteSelecionado = repositorioFabricante.BuscarRegistroPeloID(editarVM.FabricanteID);

            if (fabricanteSelecionado == null)
                return RedirectToAction(nameof(Index));

            Equipamento equipamentoAtualizado = new Equipamento(editarVM.Nome, editarVM.Preco, editarVM.NumeroSerie, fabricanteSelecionado, editarVM.DataFabricacao);

            repositorioEquipamento.Editar(equipamentoAtualizado, id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            Equipamento equipamentoSelecionado = repositorioEquipamento.BuscarRegistroPeloID(id);

            ExcluirEquipamentoViewModel excluirVM = new ExcluirEquipamentoViewModel(equipamentoSelecionado.Id, equipamentoSelecionado.Nome);

            return View(excluirVM);
        }

        [HttpPost]
        public IActionResult ExcluirConfirmado(int id)
        {
            repositorioEquipamento.Excluir(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

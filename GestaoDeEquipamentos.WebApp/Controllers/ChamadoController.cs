using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;
using GestaoDeEquipamentos.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDeEquipamentos.WebApp.Controllers
{
    public class ChamadoController : Controller
    {
        private RepositorioChamadoEmArquivo repositorioChamado;
        private RepositorioEquipamentoEmArquivo repositorioEquipamento;

        public ChamadoController()
        {
            ContextoDados contexto = new ContextoDados(true);
            this.repositorioChamado = new RepositorioChamadoEmArquivo(contexto);
            this.repositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);
        }

        public IActionResult Index()
        {
            List<Chamado> chamados = repositorioChamado.BuscarRegistros();

            VisualizarChamadosViewModels visualizarVM = new VisualizarChamadosViewModels(chamados);

            return View(visualizarVM);
        }

        public IActionResult Cadastrar()
        {
            List<Equipamento> equipamentos = repositorioEquipamento.BuscarRegistros();

            CadastrarChamadoViewModel cadastrarVM = new CadastrarChamadoViewModel(equipamentos);

            return View(cadastrarVM);
        }

        [HttpPost]
        public IActionResult Cadastrar(CadastrarChamadoViewModel cadastrarVM)
        {
            Equipamento equipamentoSelecionado = repositorioEquipamento.BuscarRegistroPeloID(cadastrarVM.EquipamentoID);

            if (equipamentoSelecionado == null)
                return RedirectToAction(nameof(Index));

            Chamado novoChamado = new Chamado(cadastrarVM.Titulo, cadastrarVM.Descricao, equipamentoSelecionado, cadastrarVM.DataAbertura);

            repositorioChamado.Cadastrar(novoChamado);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Editar(int id)
        {
            Chamado chamadoSelecionado = repositorioChamado.BuscarRegistroPeloID(id);

            List<Equipamento> equipamentos = repositorioEquipamento.BuscarRegistros();

            EditarChamadoViewModel editarVM = new EditarChamadoViewModel(chamadoSelecionado.Id, chamadoSelecionado.Titulo, chamadoSelecionado.Descricao,
                chamadoSelecionado.DataAbertura, chamadoSelecionado.Equipamento.Id, equipamentos);

            return View(editarVM);
        }

        [HttpPost]
        public IActionResult Editar(int id, EditarChamadoViewModel editarVM)
        {
            Equipamento equipamentoSelecionado = repositorioEquipamento.BuscarRegistroPeloID(editarVM.EquipamentoID);

            if (equipamentoSelecionado == null)
                return RedirectToAction(nameof(Index));

            Chamado chamadoAtualizado = new Chamado(editarVM.Titulo, editarVM.Descricao,
                equipamentoSelecionado, editarVM.DataAbertura);

            repositorioChamado.Editar(chamadoAtualizado, id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Excluir(int id)
        {
            Chamado chamadoSelecionado = repositorioChamado.BuscarRegistroPeloID(id);

            ExcluirChamadoViewModel excluirVM = new ExcluirChamadoViewModel(chamadoSelecionado.Id, chamadoSelecionado.Titulo);

            return View(excluirVM);
        }

        [HttpPost]
        public IActionResult ExcluirConfirmado(int id)
        {
            repositorioChamado.Excluir(id);

            return RedirectToAction(nameof(Index));
        }
    }
}

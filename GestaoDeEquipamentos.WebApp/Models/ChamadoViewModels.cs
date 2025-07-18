using GestaoDeEquipamentos.Dominio;

namespace GestaoDeEquipamentos.WebApp.Models
{
    public class VisualizarChamadosViewModels
    {
        public List<DetalhesChamadoViewModel> Registros { get; set; }

        public VisualizarChamadosViewModels(List<Chamado> chamados)
        {
            Registros = new List<DetalhesChamadoViewModel>();

            foreach (Chamado c in chamados)
            {
                DetalhesChamadoViewModel detalhesVM = new DetalhesChamadoViewModel(
                    c.Id,
                    c.Titulo,
                    c.Descricao,
                    c.DataAbertura,
                    c.Equipamento.Nome);

                Registros.Add(detalhesVM);
            }
        }
    }

    public class DetalhesChamadoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public string NomeEquipamento { get; set; }

        public DetalhesChamadoViewModel(int id, string titulo, string descricao, DateTime dataAbertura, string nomeEquipamento)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataAbertura = dataAbertura;
            NomeEquipamento = nomeEquipamento;
        }

        public override string ToString()
        {
            return $"ID: {Id} - Nome: {Titulo} - Fabricante: {NomeEquipamento} - Preço: {Descricao:C2} - Data de Fabricação: {DataAbertura:d}";
        }
    }

    public class SelecionarEquipamentoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public SelecionarEquipamentoViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }

    public class CadastrarChamadoViewModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public int EquipamentoID { get; set; }
        public List<SelecionarEquipamentoViewModel> Equipamentos { get; set; }

        public CadastrarChamadoViewModel()
        {
            Equipamentos = new List<SelecionarEquipamentoViewModel>();
        }

        public CadastrarChamadoViewModel(List<Equipamento> equipamentos) : this()
        {
            foreach (Equipamento e in equipamentos)
            {
                SelecionarEquipamentoViewModel selecionarEquipamentoVM = new SelecionarEquipamentoViewModel(e.Id, e.Nome);

                Equipamentos.Add(selecionarEquipamentoVM);
            }
        }
    }

    public class EditarChamadoViewModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public int EquipamentoID { get; set; }
        public List<SelecionarEquipamentoViewModel> Equipamentos { get; set; }

        public EditarChamadoViewModel()
        {
            Equipamentos = new List<SelecionarEquipamentoViewModel>();
        }

        public EditarChamadoViewModel(int id, string titulo, string descricao, DateTime dataAbertura, int equipamentoID, List<Equipamento> listaEquipamentos) : this()
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            DataAbertura = dataAbertura;
            EquipamentoID = equipamentoID;

            foreach (Equipamento f in listaEquipamentos)
            {
                SelecionarEquipamentoViewModel selecionarEquipamentoVM = new SelecionarEquipamentoViewModel(f.Id, f.Nome);

                Equipamentos.Add(selecionarEquipamentoVM);
            }
        }
    }

    public class ExcluirChamadoViewModel()
    {
        public int Id { get; set; }
        public string Titulo { get; set; }

        public ExcluirChamadoViewModel(int id, string titulo) : this()
        {
            Id = id;
            Titulo = titulo;
        }
    }
}

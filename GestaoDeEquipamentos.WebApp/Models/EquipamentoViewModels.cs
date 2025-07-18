using GestaoDeEquipamentos.Dominio;

namespace GestaoDeEquipamentos.WebApp.Models
{
    public class VisualizarEquipamentosViewModels
    {
        public List<DetalhesEquipamentoViewModel> Registros { get; set; }

        public VisualizarEquipamentosViewModels(List<Equipamento> equipamentos)
        {
            Registros = new List<DetalhesEquipamentoViewModel>();

            foreach (Equipamento e in equipamentos)
            {
                DetalhesEquipamentoViewModel detalhesVM = new DetalhesEquipamentoViewModel(
                    e.Id,
                    e.Nome,
                    e.Preco,
                    e.NumeroSerie,
                    e.Fabricante.Nome,
                    e.DataFabricacao);

                Registros.Add(detalhesVM);
            }
        }
    }

    public class DetalhesEquipamentoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int NumeroSerie { get; set; }
        public string NomeFabricante { get; set; }
        public DateTime DataFabricacao { get; set; }

        public DetalhesEquipamentoViewModel(int id, string nome, decimal preco, int numeroSerie, string nomeFabricante, DateTime dataFabricacao)
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            NumeroSerie = numeroSerie;
            NomeFabricante = nomeFabricante;
            DataFabricacao = dataFabricacao;
        }

        public override string ToString()
        {
            return $"ID: {Id} - Nome: {Nome} - Fabricante: {NomeFabricante} - Preço: {Preco:C2} - Data de Fabricação: {DataFabricacao:d}";
        }
    }

    public class SelecionarFabricanteViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public SelecionarFabricanteViewModel(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }
    }

    public class CadastrarEquipamentoViewModel
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int NumeroSerie { get; set; }
        public int FabricanteID { get; set; }
        public DateTime DataFabricacao { get; set; }
        public List<SelecionarFabricanteViewModel> Fabricantes { get; set; }

        public CadastrarEquipamentoViewModel()
        {
            Fabricantes = new List<SelecionarFabricanteViewModel>();
        }

        public CadastrarEquipamentoViewModel(List<Fabricante> fabricantes) : this()
        {
            foreach (Fabricante f in fabricantes)
            {
                SelecionarFabricanteViewModel selecionarFabricanteVM = new SelecionarFabricanteViewModel(f.Id, f.Nome);

                Fabricantes.Add(selecionarFabricanteVM);
            }
        }
    }

    public class EditarEquipamentoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int NumeroSerie { get; set; }
        public int FabricanteID { get; set; }
        public DateTime DataFabricacao { get; set; }
        public List<SelecionarFabricanteViewModel> Fabricantes { get; set; }

        public EditarEquipamentoViewModel()
        {
            Fabricantes = new List<SelecionarFabricanteViewModel>();
        }

        public EditarEquipamentoViewModel(int id, string nome, decimal preco, int numeroSerie, int fabricanteID, DateTime dataFabricacao, List<Fabricante> listaFabricantes) : this()
        {
            Id = id;
            Nome = nome;
            Preco = preco;
            NumeroSerie = numeroSerie;
            FabricanteID = fabricanteID;
            DataFabricacao = dataFabricacao;

            foreach (Fabricante f in listaFabricantes)
            {
                SelecionarFabricanteViewModel selecionarFabricanteVM = new SelecionarFabricanteViewModel(f.Id, f.Nome);

                Fabricantes.Add(selecionarFabricanteVM);
            }
        }
    }
    
    public class ExcluirEquipamentoViewModel()
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ExcluirEquipamentoViewModel(int id, string nome) : this()
        {
            Id = id;
            Nome = nome;
        }
    }
}

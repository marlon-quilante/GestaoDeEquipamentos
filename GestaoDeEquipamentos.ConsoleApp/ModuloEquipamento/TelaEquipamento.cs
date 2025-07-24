using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento
{
    public class TelaEquipamento : TelaBase<Equipamento>, ITela
    {
        private RepositorioEquipamentoEmArquivo RepositorioEquipamento;
        public TelaFabricante viewFabricante;
        public RepositorioFabricanteEmArquivo RepositorioFabricante;
        public TelaEquipamento(RepositorioEquipamentoEmArquivo RepositorioEquipamento) : base("Equipamento", RepositorioEquipamento)
        {
            this.RepositorioEquipamento = RepositorioEquipamento;
        }

        protected override Equipamento Dados()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Preço: ");
            decimal preco = decimal.Parse(Console.ReadLine());
            Console.Write("Número de série: ");
            int numeroSerie = int.Parse(Console.ReadLine());

            int idFabricante = viewFabricante.BuscarID();
            Fabricante fabricante = RepositorioFabricante.BuscarRegistroPeloID(idFabricante);

            Console.Write("Data de fabricação: ");
            DateTime dataFabricacao = Convert.ToDateTime(Console.ReadLine());

            Equipamento equipamento = new Equipamento(nome, preco, numeroSerie, fabricante, dataFabricacao);

            return equipamento;
        }

        protected override void MostrarLista()
        {
            Console.WriteLine("{0, -5} | {1, -20} | {2, -10} | {3, -20} | {4, -20} | {5, -20}",
                "ID", "Nome", "Preço", "Número de Série", "Fabricante", "Data de Fabricação");

            List<Equipamento> equipamentos = RepositorioEquipamento.BuscarRegistros();

            foreach (Equipamento e in equipamentos)
            {
                Console.WriteLine("{0, -5} | {1, -20} | {2, -10} |" +
                    " {3, -20} | {4, -20} | {5, -20}",
                    e.Id, e.Nome, e.Preco.ToString("F2"), e.NumeroSerie,
                    e.Fabricante.Nome, e.DataFabricacao.ToShortDateString());
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

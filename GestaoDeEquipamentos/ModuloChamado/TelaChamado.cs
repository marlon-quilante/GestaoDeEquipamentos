using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloChamado
{
    public class TelaChamado : TelaBase<Chamado>, ITela
    {
        private RepositorioChamadoEmArquivo RepositorioChamado;
        public RepositorioEquipamentoEmArquivo RepositorioEquipamento;
        public TelaEquipamento productView;

        public TelaChamado(RepositorioChamadoEmArquivo RepositorioChamado) : base("Chamado", RepositorioChamado)
        {
            this.RepositorioChamado = RepositorioChamado;
        }

        protected override Chamado Inputs()
        {
            Console.Write("Título: ");
            string title = Console.ReadLine();
            Console.Write("Descrição: ");
            string description = Console.ReadLine();

            int idProduct = productView.GetID();
            Equipamento product = (Equipamento)RepositorioEquipamento.GetRegisterByID(idProduct);

            DateTime openingDate = DateTime.Now;

            Chamado ticket = new Chamado(title, description, product, openingDate);

            return ticket;
        }

        protected override void ShowList()
        {
            Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                "ID", "Título", "Descrição", "Equipamento", "Data de Abertura");

            List<Chamado> tickets = RepositorioChamado.GetRegisters();

            foreach (Chamado ticket in tickets)
            {
                Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                    ticket.Id, ticket.Title, ticket.Description, ticket.Product.Name, ticket.OpeningDate.ToShortDateString());
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

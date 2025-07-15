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
        public TelaEquipamento viewEquipamento;

        public TelaChamado(RepositorioChamadoEmArquivo RepositorioChamado) : base("Chamado", RepositorioChamado)
        {
            this.RepositorioChamado = RepositorioChamado;
        }

        protected override Chamado Dados()
        {
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            int id = viewEquipamento.BuscarID();
            Equipamento equipamento = RepositorioEquipamento.BuscarRegistroPeloID(id);

            DateTime dataAbertura = DateTime.Now;

            Chamado chamado = new Chamado(titulo, descricao, equipamento, dataAbertura);

            return chamado;
        }

        protected override void MostrarLista()
        {
            Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                "ID", "Título", "Descrição", "Equipamento", "Data de Abertura");

            List<Chamado> chamados = RepositorioChamado.BuscarRegistros();

            foreach (Chamado c in chamados)
            {
                Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                    c.Id, c.Titulo, c.Descricao, c.Equipamento.Nome, c.DataAbertura.ToShortDateString());
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class TelaFabricante : TelaBase<Fabricante>, ITela
    {
        private RepositorioFabricanteEmArquivo RepositorioFabricante;

        public TelaFabricante(RepositorioFabricanteEmArquivo RepositorioFabricante) 
            : base("Fabricante", RepositorioFabricante)
        {
            this.RepositorioFabricante = RepositorioFabricante;
        }

        protected override Fabricante Dados()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();

            Fabricante fabricante = new Fabricante(nome, email, telefone);

            return fabricante;
        }

        protected override void MostrarLista()
        {
            Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -15} | {4, -5}",
                "ID", "Nome", "Email", "Telefone", "Qtd de Produtos");

            List<Fabricante> fabricantes = RepositorioFabricante.BuscarRegistros();

            foreach (Fabricante f in fabricantes)
            {
                Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -15} | {4, -5}",
                    f.Id, f.Nome, f.Email, f.Telefone, RepositorioFabricante.ObterQtdProdutos(f));
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

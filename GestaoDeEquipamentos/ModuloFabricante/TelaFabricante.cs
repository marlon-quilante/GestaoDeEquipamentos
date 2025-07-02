using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloFabricante
{
    public class TelaFabricante : TelaBase<Fabricante>, ITela
    {
        private RepositorioFabricante RepositorioFabricante;

        public TelaFabricante(RepositorioFabricante RepositorioFabricante) : base("Fabricante", RepositorioFabricante)
        {
            this.RepositorioFabricante = RepositorioFabricante;
        }

        protected override Fabricante Inputs()
        {
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Telefone: ");
            string phone = Console.ReadLine();

            Fabricante manufactor = new Fabricante(name, email, phone);

            return manufactor;
        }

        protected override void ShowList()
        {
            Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -15} | {4, -5}",
                "ID", "Nome", "Email", "Telefone", "Qtd de Produtos");

            List<Fabricante> manufactors = RepositorioFabricante.GetRegisters();

            foreach (Fabricante manufactor in manufactors)
            {
                Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -15} | {4, -5}",
                    manufactor.id, manufactor.name, manufactor.email, manufactor.phone, RepositorioFabricante.GetProductsQty(manufactor));
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

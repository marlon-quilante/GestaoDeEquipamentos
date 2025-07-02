using GestaoDeEquipamentos.ConsoleApp.Compartilhado;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos;

namespace GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento
{
    public class TelaEquipamento : TelaBase<Equipamento>, ITela
    {
        private RepositorioEquipamento RepositorioEquipamento;
        public TelaFabricante manufactorView;
        public RepositorioFabricante RepositorioFabricante;
        public TelaEquipamento(RepositorioEquipamento RepositorioEquipamento) : base("Equipamento", RepositorioEquipamento)
        {
            this.RepositorioEquipamento = RepositorioEquipamento;
        }

        protected override Equipamento Inputs()
        {
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Preço: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Número de série: ");
            int serialNumber = int.Parse(Console.ReadLine());

            int idManufactor = manufactorView.GetID();
            Fabricante manufactor = (Fabricante)RepositorioFabricante.GetRegisterByID(idManufactor);

            Console.Write("Data de fabricação: ");
            DateTime manufacturingDate = Convert.ToDateTime(Console.ReadLine());

            Equipamento product = new Equipamento(name, price, serialNumber, manufactor, manufacturingDate);

            return product;
        }

        protected override void ShowList()
        {
            Console.WriteLine("{0, -5} | {1, -20} | {2, -10} | {3, -20} | {4, -20} | {5, -20}",
                "ID", "Nome", "Preço", "Número de Série", "Fabricante", "Data de Fabricação");

            List<Equipamento> products = RepositorioEquipamento.GetRegisters();

            foreach (Equipamento product in products)
            {
                Console.WriteLine("{0, -5} | {1, -20} | {2, -10} |" +
                    " {3, -20} | {4, -20} | {5, -20}",
                    product.id, product.name, product.price.ToString("F2"), product.serialNumber,
                    product.manufactor.name, product.manufactoringDate.ToShortDateString());
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

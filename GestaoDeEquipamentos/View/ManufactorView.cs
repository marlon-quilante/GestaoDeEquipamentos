using GestaoDeEquipamentos.Controller;
using GestaoDeEquipamentos.Model;

namespace GestaoDeEquipamentos.View
{
    public class ManufactorView : BaseView
    {
        private ManufactorController manufactorController;

        public ManufactorView(ManufactorController manufactorController) : base("Fabricante", manufactorController)
        {
            this.manufactorController = manufactorController;
        }

        protected override Manufactor Inputs()
        {
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Telefone: ");
            string phone = Console.ReadLine();

            Manufactor manufactor = new Manufactor(name, email, phone);

            return manufactor;
        }

        protected override void ShowList()
        {
            Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -15} | {4, -5}",
                "ID", "Nome", "Email", "Telefone", "Qtd de Produtos");

            List<BaseRegister> registers = manufactorController.GetRegisters();

            foreach (BaseRegister register in registers)
            {
                Manufactor m = (Manufactor)register;

                Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -15} | {4, -5}",
                    m.id, m.name, m.email, m.phone, manufactorController.GetProductsQty(m));
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

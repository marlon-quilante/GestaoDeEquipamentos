using GestaoDeEquipamentos.Model;
using GestaoDeEquipamentos.Controller;

namespace GestaoDeEquipamentos.View
{
    public class ProductView : BaseView
    {
        private ProductController productController;
        public ManufactorView manufactorView;
        public ManufactorController manufactorController;
        public ProductView(ProductController productController) : base("Equipamento", productController)
        {
            this.productController = productController;
        }

        protected override Product Inputs()
        {
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Preço: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Número de série: ");
            int serialNumber = int.Parse(Console.ReadLine());

            int idManufactor = manufactorView.GetID();
            Manufactor manufactor = (Manufactor)manufactorController.GetRegisterByID(idManufactor);

            Console.Write("Data de fabricação: ");
            DateTime manufacturingDate = Convert.ToDateTime(Console.ReadLine());

            Product product = new Product(name, price, serialNumber, manufactor, manufacturingDate);

            return product;
        }

        protected override void ShowList()
        {
            Console.WriteLine("{0, -5} | {1, -20} | {2, -10} | {3, -20} | {4, -20} | {5, -20}",
                "ID", "Nome", "Preço", "Número de Série", "Fabricante", "Data de Fabricação");

            List<BaseRegister> registers = productController.GetRegisters();

            foreach (BaseRegister register in registers)
            {
                Product p = (Product)register;

                Console.WriteLine("{0, -5} | {1, -20} | {2, -10} | {3, -20} | {4, -20} | {5, -20}",
                    p.id, p.name, p.price.ToString("F2"), p.serialNumber, p.manufactor.name, p.manufactoringDate.ToShortDateString());
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

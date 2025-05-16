using GestaoDeEquipamentos.Model;
using GestaoDeEquipamentos.Controller;

namespace GestaoDeEquipamentos.View
{
    public class ProductView
    {
        private ProductController productController;
        public ManufactorView manufactorView;
        public ManufactorController manufactorController;

        public ProductView(ProductController productController)
        {
            this.productController = productController;
        }

        public void MainHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Controle de Equipamentos");
            Console.WriteLine("---------------------------");
        }

        public void Create()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Cadastro de Equipamento");
            Console.WriteLine("---------------------------\n");

            Product newProduct = Inputs();
            string errors = newProduct.Validate();

            if (errors != "")
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errors);
                Console.ResetColor();
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();

                Create();
                return;
            }

            productController.CreateController(newProduct);
        }

        public void Read()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Equipamentos Cadastrados");
            Console.WriteLine("---------------------------\n");

            ShowList();
        }

        public void Update()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Edição de Equipamento");
            Console.WriteLine("---------------------------\n");

            int idToUpdate = GetID();
            Console.WriteLine();
            Product product = Inputs();
            productController.UpdateController(product, idToUpdate);
        }

        public void Delete()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Exclusão de Equipamento");
            Console.WriteLine("---------------------------\n");

            int idToDelete = GetID();
            productController.DeleteController(idToDelete);
        }

        public string Menu()
        {
            Console.WriteLine("Selecione uma opção...\n");
            Console.WriteLine("1- Cadastrar");
            Console.WriteLine("2- Visualizar");
            Console.WriteLine("3- Editar");
            Console.WriteLine("4- Excluir");
            Console.WriteLine("5- Voltar\n");

            return Console.ReadLine();
        }

        private Product Inputs()
        {
            Console.Write("Nome: ");
            string name = Console.ReadLine();
            Console.Write("Preço: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Número de série: ");
            int serialNumber = int.Parse(Console.ReadLine());

            int idManufactor = manufactorView.GetID();
            Manufactor manufactor = manufactorController.GetManufactorByID(idManufactor);

            Console.Write("Data de fabricação: ");
            DateTime manufacturingDate = Convert.ToDateTime(Console.ReadLine());

            Product product = new Product(name, price, serialNumber, manufactor, manufacturingDate);

            return product;
        }

        private void ShowList()
        {
            Console.WriteLine("{0, -5} | {1, -20} | {2, -10} | {3, -20} | {4, -20} | {5, -20}",
                "ID", "Nome", "Preço", "Número de Série", "Fabricante", "Data de Fabricação");

            foreach (Product p in productController.productsList)
            {

                Console.WriteLine("{0, -5} | {1, -20} | {2, -10} | {3, -20} | {4, -20} | {5, -20}",
                    p.id, p.name, p.price, p.serialNumber, p.manufactor.name, p.manufactoringDate.ToShortDateString());
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }

        public int GetID()
        {
            int inputID = 0;
            bool IDExists = false;

            do
            {
                Console.Write("ID do produto: ");
                inputID = int.Parse(Console.ReadLine());
                IDExists = productController.IDExists(inputID);

                if (IDExists == false)
                {
                    Console.WriteLine("\nNão foi encontrado um produto com este ID! Pressione ENTER e tente novamente...");
                    Console.ReadLine();
                }
            }
            while (IDExists == false);

            return inputID;
        }
    }
}

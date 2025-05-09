using GestaoDeEquipamentos.Model;
using GestaoDeEquipamentos.Controller;

namespace GestaoDeEquipamentos.View
{
    public class ProductView
    {
        public List<Product> productsList;
        public ProductController productController;
        public ManufactorView manufactorView;
        public ManufactorController manufactorController;

        public void MainHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Controle de Equipamentos");
            Console.WriteLine("---------------------------");
        }

        public void CreateHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Cadastro de Equipamento");
            Console.WriteLine("---------------------------\n");
        }

        public void ReadHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Equipamentos Cadastrados");
            Console.WriteLine("---------------------------\n");
        }

        public void UpdateHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Edição de Equipamento");
            Console.WriteLine("---------------------------\n");
        }

        public void DeleteHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Exclusão de Equipamento");
            Console.WriteLine("---------------------------\n");
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

        public Product Inputs(Product product)
        {
            Console.Write("Nome: ");
            product.name = Console.ReadLine();
            Console.Write("Preço: ");
            product.price = decimal.Parse(Console.ReadLine());
            Console.Write("Número de série: ");
            product.serialNumber = int.Parse(Console.ReadLine());

            int idManufactor = manufactorView.GetID();
            Manufactor manufactor = manufactorController.GetManufactorByID(idManufactor);
            product.manufactor = manufactor;

            Console.Write("Data de fabricação: ");
            product.manufactoringDate = Convert.ToDateTime(Console.ReadLine());

            return product;
        }

        public void ShowList()
        {
            ReadHeader();

            Console.WriteLine("{0, -5} | {1, -20} | {2, -10} | {3, -20} | {4, -20} | {5, -20}",
                "ID", "Nome", "Preço", "Número de Série", "Fabricante", "Data de Fabricação");

            foreach (Product p in productsList)
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

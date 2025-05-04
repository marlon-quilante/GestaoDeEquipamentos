using GestaoDeEquipamentos.Entities;

namespace GestaoDeEquipamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            List<Product> products = new List<Product>();

            while (true)
            {
                ProductHeader();
                string option = ProductMenu();

                switch (int.Parse(option))
                {
                    case 1:
                        product = ProductCreateInput();
                        product.Create(product, products);
                        break;
                    case 2:
                        ProductReadOutput(products);
                        break;
                    default:
                        break;
                }
            }
        }

        static void ProductHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Controle de Equipamentos");
            Console.WriteLine("---------------------------");
        }

        static string ProductMenu()
        {
            Console.WriteLine("PRODUTOS\n");
            Console.WriteLine("Selecione uma opção...");
            Console.WriteLine("1- Cadastrar");
            Console.WriteLine("2- Visualizar");
            Console.WriteLine("3- Editar");
            Console.WriteLine("4- Excluir\n");

            return Console.ReadLine();
        }

        static Product ProductCreateInput()
        {
            Console.Clear();

            Product product = new Product();

            Console.Write("ID: ");
            product.id = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            product.name = Console.ReadLine();
            Console.Write("Preço: ");
            product.price = decimal.Parse(Console.ReadLine());
            Console.Write("Número de série: ");
            product.serialNumber = int.Parse(Console.ReadLine());
            Console.Write("Nome do fabricante: ");
            product.manufactorName = Console.ReadLine();
            Console.Write("Data de fabricação: ");
            product.manufactoringDate = Convert.ToDateTime(Console.ReadLine());

            return product;
        }

        static void ProductReadOutput(List<Product> products)
        {
            Console.Clear();

            foreach (Product product in products)
            {
                string[] productData = product.Read(product);

                for (int i = 0; i < productData.Length; i++)
                {
                    Console.WriteLine(productData[i]);
                }
                Console.WriteLine();
            }

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

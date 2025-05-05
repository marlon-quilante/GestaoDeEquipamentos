using GestaoDeEquipamentos.Entities;

namespace GestaoDeEquipamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            List<Product> productsList = new List<Product>();
            int id = 0;
            bool online = true;

            while (online == true)
            {
                ProductHeader();
                string option = ProductMenu();

                switch (int.Parse(option))
                {
                    case 1:
                        product = new Product();
                        CreateProductHeader();
                        product = ProductDataInput(product);
                        product.Create(product, productsList);
                        break;
                    case 2:
                        ReadProductHeader();
                        ProductReadOutput(productsList);
                        break;
                    case 3:
                        UpdateProductHeader();
                        id = GetProductID(productsList);
                        product = product.Update(productsList, id);
                        Product updatedProduct = ProductDataInput(product);
                        break;
                    case 4:
                        DeleteProductHeader();
                        id = GetProductID(productsList);
                        product.Delete(productsList, id);
                        break;
                    case 5:
                        online = false;
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

        static void CreateProductHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Cadastro de Produto");
            Console.WriteLine("---------------------------\n");
        }

        static void ReadProductHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Produtos Cadastrados");
            Console.WriteLine("---------------------------\n");
        }

        static void UpdateProductHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Atualização de Produto");
            Console.WriteLine("---------------------------\n");
        }

        static void DeleteProductHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Exclusão de Produto");
            Console.WriteLine("---------------------------\n");
        }

        static string ProductMenu()
        {
            Console.WriteLine("PRODUTOS\n");
            Console.WriteLine("Selecione uma opção...\n");
            Console.WriteLine("1- Cadastrar");
            Console.WriteLine("2- Visualizar");
            Console.WriteLine("3- Editar");
            Console.WriteLine("4- Excluir");
            Console.WriteLine("5- Sair\n");

            return Console.ReadLine();
        }

        static Product ProductDataInput(Product product)
        {
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

        static void ProductReadOutput(List<Product> productsList)
        {
            foreach (Product product in productsList)
            {
                string[] productData = product.Read(product);

                Console.WriteLine("-------------------------------------");
                for (int i = 0; i < productData.Length; i++)
                {
                    Console.WriteLine(productData[i]);
                }
                Console.WriteLine("-------------------------------------");
                Console.WriteLine();
            }

            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
        }

        static int GetProductID(List<Product> productsList)
        {
            int id = 0;
            bool validID = false;

            while (validID == false)
            {
                Console.Write("Digite o ID do produto: ");
                id = int.Parse(Console.ReadLine());

                foreach (Product product in productsList)
                {
                    if (id == product.id)
                    {
                        validID = true;
                        break;
                    } 
                }

                if (validID == false)
                {
                    Console.WriteLine("\nNão foi encontrado um produto com este ID! Pressione ENTER e tente novamente...");
                    Console.ReadLine();
                }
            }
            Console.WriteLine();
            return id;
        }
    }
}

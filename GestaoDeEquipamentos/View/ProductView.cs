using GestaoDeEquipamentos.Model;
using GestaoDeEquipamentos.Controller;

namespace GestaoDeEquipamentos.View
{
    public class ProductView
    {
        public Product product;
        public List<Product> productsList;
        public ProductController productController;

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
            Console.WriteLine("PRODUTOS\n");
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
            Console.Write("Nome do fabricante: ");
            product.manufactorName = Console.ReadLine();
            Console.Write("Data de fabricação: ");
            product.manufactoringDate = Convert.ToDateTime(Console.ReadLine());

            return product;
        }

        public void ShowList()
        {
            ReadHeader();
            foreach (Product p in productsList)
            {
                string[] productData = productController.Read(p);

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

            Console.WriteLine();
            return inputID;
        }
    }
}

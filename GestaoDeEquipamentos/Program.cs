using GestaoDeEquipamentos.Entities;

namespace GestaoDeEquipamentos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            while (true)
            {
                ProductHeader();
                Product product = ProductCreateInput();
                product.Create(product, products);
            }
        }

        static void ProductHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Controle de Equipamentos");
            Console.WriteLine("---------------------------");
        }

        static Product ProductCreateInput()
        {
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
    }
}

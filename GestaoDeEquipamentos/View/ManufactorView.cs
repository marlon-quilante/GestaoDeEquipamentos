using GestaoDeEquipamentos.Controller;
using GestaoDeEquipamentos.Model;

namespace GestaoDeEquipamentos.View
{
    public class ManufactorView
    {
        public Manufactor manufactor;
        public List<Manufactor> manufactorsList;
        public ManufactorController manufactorController;
        public ProductController productController;
        public ProductView productView;

        public void MainHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Controle de Fabricantes");
            Console.WriteLine("---------------------------");
        }

        public void CreateHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Cadastro de Fabricante");
            Console.WriteLine("---------------------------\n");
        }

        public void ReadHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Fabricantes Cadastrados");
            Console.WriteLine("---------------------------\n");
        }

        public void UpdateHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Edição de Fabricante");
            Console.WriteLine("---------------------------\n");
        }

        public void DeleteHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Exclusão de Fabricante");
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

        public Manufactor Inputs(Manufactor manufactor)
        {
            Console.Write("Nome: ");
            manufactor.name = Console.ReadLine();
            Console.Write("Email: ");
            manufactor.email = Console.ReadLine();
            Console.Write("Telefone: ");
            manufactor.phone = Console.ReadLine();

            return manufactor;
        }

        public void ShowList()
        {
            ReadHeader();

            Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -10} | {4, -5}",
                "ID", "Nome", "Email", "Telefone", "Qtd de Produtos");

            foreach (Manufactor m in manufactorsList)
            {

                Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -10} | {4, -5}",
                    m.id, m.name, m.email, m.phone, manufactorController.GetProductsQty(m));
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
                Console.Write("ID do fabricante: ");
                inputID = int.Parse(Console.ReadLine());
                IDExists = manufactorController.IDExists(inputID);

                if (IDExists == false)
                {
                    Console.WriteLine("\nNão foi encontrado um fabricante com este ID! Pressione ENTER e tente novamente...");
                    Console.ReadLine();
                }
            }
            while (IDExists == false);

            return inputID;
        }
    }
}

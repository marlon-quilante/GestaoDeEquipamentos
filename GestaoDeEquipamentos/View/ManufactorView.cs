using GestaoDeEquipamentos.Controller;
using GestaoDeEquipamentos.Model;

namespace GestaoDeEquipamentos.View
{
    public class ManufactorView
    {
        private ManufactorController manufactorController;

        public ManufactorView(ManufactorController manufactorController)
        {
            this.manufactorController = manufactorController;
        }

        public void MainHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Controle de Fabricantes");
            Console.WriteLine("---------------------------");
        }

        public void Create()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Cadastro de Fabricante");
            Console.WriteLine("---------------------------\n");

            Manufactor newManufactor = Inputs();
            manufactorController.CreateController(newManufactor);
        }

        public void Read()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Fabricantes Cadastrados");
            Console.WriteLine("---------------------------\n");

            ShowList();
        }

        public void Update()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Edição de Fabricante");
            Console.WriteLine("---------------------------\n");

            int idToUpdate = GetID();
            Console.WriteLine();
            Manufactor newManufactor = Inputs();
            manufactorController.UpdateController(newManufactor, idToUpdate);
        }

        public void Delete()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Exclusão de Fabricante");
            Console.WriteLine("---------------------------\n");

            int idToDelete = GetID();

            manufactorController.DeleteController(idToDelete);
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

        public Manufactor Inputs()
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

        private void ShowList()
        {
            Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -10} | {4, -5}",
                "ID", "Nome", "Email", "Telefone", "Qtd de Produtos");

            foreach (Manufactor m in manufactorController.manufactorsList)
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

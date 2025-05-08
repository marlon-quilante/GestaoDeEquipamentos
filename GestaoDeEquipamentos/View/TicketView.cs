using GestaoDeEquipamentos.Controller;
using GestaoDeEquipamentos.Model;

namespace GestaoDeEquipamentos.View
{
    public class TicketView
    {
        public List<Ticket> ticketsList;
        public TicketController ticketController;
        public ProductController productController;
        public ProductView productView;

        public void MainHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Controle de Chamados");
            Console.WriteLine("---------------------------");
        }

        public void CreateHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Registro de Chamado");
            Console.WriteLine("---------------------------\n");
        }

        public void ReadHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Chamados Registrados");
            Console.WriteLine("---------------------------\n");
        }

        public void UpdateHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Edição de Chamado");
            Console.WriteLine("---------------------------\n");
        }

        public void DeleteHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Exclusão de Chamado");
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

        public Ticket Inputs(Ticket ticket)
        {
            Console.Write("Título: ");
            ticket.title = Console.ReadLine();
            Console.Write("Descrição: ");
            ticket.description = Console.ReadLine();
            int idProduct = productView.GetID();
            Product product = productController.GetProductByID(idProduct);
            ticket.product = product;

            return ticket;
        }

        public void ShowList()
        {
            ReadHeader();
            foreach (Ticket t in ticketsList)
            {
                string[] ticketData = ticketController.Read(t);

                Console.WriteLine("-------------------------------------");
                for (int i = 0; i < ticketData.Length; i++)
                {
                    Console.WriteLine(ticketData[i]);
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
                Console.Write("ID do chamado: ");
                inputID = int.Parse(Console.ReadLine());
                IDExists = ticketController.IDExists(inputID);

                if (IDExists == false)
                {
                    Console.WriteLine("\nNão foi encontrado um chamado com este ID! Pressione ENTER e tente novamente...");
                    Console.ReadLine();
                }
            }
            while (IDExists == false);

            Console.WriteLine();
            return inputID;
        }
    }
}

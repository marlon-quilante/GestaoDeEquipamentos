using GestaoDeEquipamentos.Controller;
using GestaoDeEquipamentos.Model;

namespace GestaoDeEquipamentos.View
{
    public class TicketView
    {
        private TicketController ticketController;
        public ProductController productController;
        public ProductView productView;

        public TicketView(TicketController ticketController)
        {
            this.ticketController = ticketController;
        }

        public void MainHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Controle de Chamados");
            Console.WriteLine("---------------------------");
        }

        public void Create()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Registro de Chamado");
            Console.WriteLine("---------------------------\n");

            Ticket newTicket = Inputs();
            ticketController.CreateController(newTicket);
        }

        public void Read()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Chamados Registrados");
            Console.WriteLine("---------------------------\n");

            ShowList();
        }

        public void Update()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Edição de Chamado");
            Console.WriteLine("---------------------------\n");

            int idToUpdate = GetID();
            Console.WriteLine();
            Ticket updatedTicket = Inputs();
            ticketController.UpdateController(updatedTicket, idToUpdate);
        }

        public void Delete()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine("Exclusão de Chamado");
            Console.WriteLine("---------------------------\n");

            int idToDelete = GetID();
            ticketController.DeleteController(idToDelete);
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

        public Ticket Inputs()
        {
            Console.Write("Título: ");
            string title = Console.ReadLine();
            Console.Write("Descrição: ");
            string description = Console.ReadLine();

            int idProduct = productView.GetID();
            Product product = productController.GetProductByID(idProduct);

            Ticket ticket = new Ticket(title, description, product);

            return ticket;
        }

        public void ShowList()
        {
            Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                "ID", "Título", "Descrição", "Equipamento", "Data de Abertura");

            foreach (Ticket t in ticketController.ticketsList)
            {

                Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                    t.id, t.title, t.description, t.product.name, t.openingDate.ToShortDateString());
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

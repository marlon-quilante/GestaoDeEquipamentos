using GestaoDeEquipamentos.Controller;
using GestaoDeEquipamentos.Model;

namespace GestaoDeEquipamentos.View
{
    public class TicketView : BaseView
    {
        private TicketController ticketController;
        public ProductController productController;
        public ProductView productView;

        public TicketView(TicketController ticketController) : base ("Chamado", ticketController)
        {
            this.ticketController = ticketController;
        }

        protected override Ticket Inputs()
        {
            Console.Write("Título: ");
            string title = Console.ReadLine();
            Console.Write("Descrição: ");
            string description = Console.ReadLine();

            int idProduct = productView.GetID();
            Product product = (Product)productController.GetRegisterByID(idProduct);

            DateTime openingDate = DateTime.Now;

            Ticket ticket = new Ticket(title, description, product, openingDate);

            return ticket;
        }

        protected override void ShowList()
        {
            Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                "ID", "Título", "Descrição", "Equipamento", "Data de Abertura");

            List<BaseRegister> registers = ticketController.GetRegisters();

            foreach (BaseRegister register in registers)
            {
                Ticket t = (Ticket)register;

                Console.WriteLine("{0, -5} | {1, -20} | {2, -20} | {3, -20} | {4, -20}",
                    t.id, t.title, t.description, t.product.name, t.openingDate.ToShortDateString());
            }
            Console.WriteLine("\nPressione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

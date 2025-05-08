using GestaoDeEquipamentos.Model;
using GestaoDeEquipamentos.View;

namespace GestaoDeEquipamentos.Controller
{
    public class TicketController
    {
        public Ticket ticket;
        public List<Ticket> ticketsList;
        public TicketView ticketView;
        public Product product;
        public ProductView productView;
        public int idCount = 0;

        public void Create()
        {
            ticketView.CreateHeader();
            ticket = new Ticket();
            idCount++;
            ticket.id = idCount;
            ticket.openingDate = DateTime.Now;
            ticket = ticketView.Inputs(ticket);
            ticketsList.Add(ticket);
        }

        public string[] Read(Ticket ticket)
        {
            string[] ticketData =
            [
                $"ID: {ticket.id}",
                $"Título: {ticket.title}",
                $"Descrição: {ticket.description}",
                $"Produto: {ticket.product.name}",
                $"Data de Abertura: {ticket.openingDate.ToString("dd/MM/yyyy")}"
            ];

            return ticketData;
        }

        public void Update()
        {
            ticketView.UpdateHeader();
            int idToUpdate = ticketView.GetID();

            foreach (Ticket t in ticketsList)
            {
                if (idToUpdate == t.id)
                {
                    ticketView.Inputs(t);
                    break;
                }       
            }
        }

        public void Delete()
        {
            ticketView.DeleteHeader();
            int idToDelete = ticketView.GetID();

            foreach (Ticket t in ticketsList)
            {
                if (idToDelete == t.id)
                {
                    ticketsList.Remove(t);
                    break;
                }
            }
        }

        public bool IDExists(int idToValidate)
        {
            bool idExists = false;

            foreach (Ticket t in ticketsList)
            {
                if (idToValidate == t.id)
                {
                    idExists = true;
                    break;
                }
                else
                    idExists = false;
            }
            return idExists;
        }
    }
}

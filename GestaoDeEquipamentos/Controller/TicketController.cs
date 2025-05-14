using GestaoDeEquipamentos.Model;

namespace GestaoDeEquipamentos.Controller
{
    public class TicketController
    {
        public List<Ticket> ticketsList = new List<Ticket>();
        private int idCount = 0;

        public void CreateController(Ticket newTicket)
        {
            idCount++;
            newTicket.id = idCount;
            newTicket.openingDate = DateTime.Now;
            ticketsList.Add(newTicket);
        }

        public void UpdateController(Ticket updatedTicket, int idToUpdate)
        {
            foreach (Ticket t in ticketsList)
            {
                if (idToUpdate == t.id)
                {
                    t.title = updatedTicket.title;
                    t.description = updatedTicket.description;
                    t.product = updatedTicket.product;
                    break;
                }       
            }
        }

        public void DeleteController(int idToDelete)
        {
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

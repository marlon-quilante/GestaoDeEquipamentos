namespace GestaoDeEquipamentos.Model
{
    public class Ticket
    {
        public int id = 0;
        public string title;
        public string description;
        public Product product;
        public DateTime openingDate;

        public Ticket(string title, string description, Product product)
        {
            this.title = title;
            this.description = description;
            this.product = product;
        }

        public string Validate()
        {
            string error = "";

            if (string.IsNullOrWhiteSpace(title))
                error += "O título é obrigatório!\n";
            else if (title.Length < 2)
                error += "O título precisa conter mais do que 1 caractere!\n";

            if (string.IsNullOrWhiteSpace(description))
                error += "A descrição é obrigatória!\n";
            else if (description.Length < 2)
                error += "A descrição precisa conter mais do que 1 caractere!\n";

            return error;
        }

        public void Update(Ticket updatedTicket)
        {
            this.title = updatedTicket.title;
            this.description = updatedTicket.description;
            this.product = updatedTicket.product;
        }
    }
}

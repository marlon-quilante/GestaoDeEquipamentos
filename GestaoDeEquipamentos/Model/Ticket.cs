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
    }
}

namespace GestaoDeEquipamentos.Dominio
{
    public class Chamado : Equipamento<Chamado>
    {
        public string title;
        public string description;
        public Equipamento product;
        public DateTime openingDate;

        public Chamado(string title, string description, Equipamento product, DateTime openingDate)
        {
            this.title = title;
            this.description = description;
            this.product = product;
            this.openingDate = openingDate;
        }

        public override string Validate()
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

        public override void Update(Chamado updatedTicket)
        {
            this.title = updatedTicket.title;
            this.description = updatedTicket.description;
            this.product = updatedTicket.product;
        }
    }
}

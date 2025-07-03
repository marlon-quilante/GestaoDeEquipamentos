namespace GestaoDeEquipamentos.Dominio
{
    public class Chamado : EntidadeBase<Chamado>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Equipamento Product { get; set; }
        public DateTime OpeningDate { get; set; }

        public Chamado() { }

        public Chamado(string title, string description, 
            Equipamento product, DateTime openingDate) : this()
        {
            this.Title = title;
            this.Description = description;
            this.Product = product;
            this.OpeningDate = openingDate;
        }

        public override string Validate()
        {
            string error = "";

            if (string.IsNullOrWhiteSpace(Title))
                error += "O título é obrigatório!\n";
            else if (Title.Length < 2)
                error += "O título precisa conter mais do que 1 caractere!\n";

            if (string.IsNullOrWhiteSpace(Description))
                error += "A descrição é obrigatória!\n";
            else if (Description.Length < 2)
                error += "A descrição precisa conter mais do que 1 caractere!\n";

            return error;
        }

        public override void Update(Chamado updatedTicket)
        {
            this.Title = updatedTicket.Title;
            this.Description = updatedTicket.Description;
            this.Product = updatedTicket.Product;
        }
    }
}

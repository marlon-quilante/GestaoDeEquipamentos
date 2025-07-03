namespace GestaoDeEquipamentos.Dominio
{
    public class Equipamento : EntidadeBase<Equipamento>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SerialNumber { get; set; }
        public Fabricante Manufactor { get; set; }
        public DateTime ManufactoringDate { get; set; }

        public Equipamento() { }

        public Equipamento(string name, decimal price, int serialNumber, 
            Fabricante manufactor, DateTime manufactoringDate) : this()
        {
            this.Name = name;
            this.Price = price;
            this.SerialNumber = serialNumber;
            this.Manufactor = manufactor;
            this.ManufactoringDate = manufactoringDate;
        }

        public override string Validate()
        {
            string error = "";

            if (string.IsNullOrWhiteSpace(Name))
                error += "O nome é obrigatório!\n";
            else if (Name.Length < 2)
                error += "O nome precisa conter mais do que 1 caractere!\n";

            if (!decimal.IsCanonical(Price))
                error += "O preço digitado não é válido!\n";

            if (!int.IsPositive(SerialNumber))
                error += "O número de série digitado não é válido!\n";

            return error;
        }

        public override void Update(Equipamento updatedProduct)
        {
            this.Name = updatedProduct.Name;
            this.Price = updatedProduct.Price;
            this.SerialNumber = updatedProduct.SerialNumber;
            this.Manufactor = updatedProduct.Manufactor;
            this.ManufactoringDate = updatedProduct.ManufactoringDate;
        }
    }
}

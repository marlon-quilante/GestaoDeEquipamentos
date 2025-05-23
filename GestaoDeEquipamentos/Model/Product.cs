namespace GestaoDeEquipamentos.Model
{
    public class Product : BaseRegister
    {
        public string name;
        public decimal price;
        public int serialNumber;
        public Manufactor manufactor;
        public DateTime manufactoringDate;

        public Product(string name, decimal price, int serialNumber, Manufactor manufactor, DateTime manufactoringDate)
        {
            this.name = name;
            this.price = price;
            this.serialNumber = serialNumber;
            this.manufactor = manufactor;
            this.manufactoringDate = manufactoringDate;
        }

        public override string Validate()
        {
            string error = "";

            if (string.IsNullOrWhiteSpace(name))
                error += "O nome é obrigatório!\n";
            else if (name.Length < 2)
                error += "O nome precisa conter mais do que 1 caractere!\n";

            if (!decimal.IsCanonical(price))
                error += "O preço digitado não é válido!\n";

            if (!int.IsPositive(serialNumber))
                error += "O número de série digitado não é válido!\n";

            return error;
        }

        public override void Update(BaseRegister updatedRegister)
        {
            Product updatedProduct = (Product)updatedRegister;

            this.name = updatedProduct.name;
            this.price = updatedProduct.price;
            this.serialNumber = updatedProduct.serialNumber;
            this.manufactor = updatedProduct.manufactor;
            this.manufactoringDate = updatedProduct.manufactoringDate;
        }
    }
}

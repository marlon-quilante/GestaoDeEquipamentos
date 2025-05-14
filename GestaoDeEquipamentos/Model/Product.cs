namespace GestaoDeEquipamentos.Model
{
    public class Product
    {
        public int id;
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
    }
}

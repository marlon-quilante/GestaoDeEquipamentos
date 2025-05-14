namespace GestaoDeEquipamentos.Model
{
    public class Manufactor
    {
        public int id;
        public string name;
        public string email;
        public string phone;

        public Manufactor(string name, string email, string phone)
        {
            this.name = name;
            this.email = email;
            this.phone = phone;
        }
    }
}

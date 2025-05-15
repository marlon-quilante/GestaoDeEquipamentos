using System.Net.Mail;

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

        public string Validate()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(name))
                erros += "O nome é obrigatório!\n";
            else if (name.Length < 2)
                erros += "O nome precisa conter mais do que 1 caractere!\n";

            if (!MailAddress.TryCreate(email, out _))
                erros += "O email deve conter um formato válido: email@email.com\n";

            if (string.IsNullOrWhiteSpace(phone))
                erros += "O telefone é obrigatório!\n";

            else if (phone.Length < 9)
                erros += "O telefone deve conter no mínimo 9 caracteres!\n";

            return erros;
        }

        public void Update(Manufactor updatedManufactor)
        {
            this.name = updatedManufactor.name;
            this.email = updatedManufactor.email;
            this.phone = updatedManufactor.phone;
        }
    }
}

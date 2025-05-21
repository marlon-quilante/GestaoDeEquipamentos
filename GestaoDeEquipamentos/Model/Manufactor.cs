using System.Net.Mail;

namespace GestaoDeEquipamentos.Model
{
    public class Manufactor : BaseRegister
    {
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
            string errors = "";

            if (string.IsNullOrWhiteSpace(name))
                errors += "O nome é obrigatório!\n";
            else if (name.Length < 2)
                errors += "O nome precisa conter mais do que 1 caractere!\n";

            if (!MailAddress.TryCreate(email, out _))
                errors += "O email deve conter um formato válido: email@email.com\n";

            if (string.IsNullOrWhiteSpace(phone))
                errors += "O telefone é obrigatório!\n";
            else if (phone.Length < 9)
                errors += "O telefone deve conter no mínimo 9 caracteres!\n";

            return errors;
        }

        public override void Update(BaseRegister updatedRegister)
        {
            Manufactor updatedManufactor = (Manufactor)updatedRegister;

            this.name = updatedManufactor.name;
            this.email = updatedManufactor.email;
            this.phone = updatedManufactor.phone;
        }
    }
}

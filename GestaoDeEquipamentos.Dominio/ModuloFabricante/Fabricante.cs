using System.Net.Mail;

namespace GestaoDeEquipamentos.Dominio
{
    public class Fabricante : EntidadeBase<Fabricante>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Fabricante() { }

        public Fabricante(string name, string email, string phone) : this()
        {
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
        }

        public override string Validate()
        {
            string errors = "";

            if (string.IsNullOrWhiteSpace(Name))
                errors += "O nome é obrigatório!\n";
            else if (Name.Length < 2)
                errors += "O nome precisa conter mais do que 1 caractere!\n";

            if (!MailAddress.TryCreate(Email, out _))
                errors += "O email deve conter um formato válido: email@email.com\n";

            if (string.IsNullOrWhiteSpace(Phone))
                errors += "O telefone é obrigatório!\n";
            else if (Phone.Length < 9)
                errors += "O telefone deve conter no mínimo 9 caracteres!\n";

            return errors;
        }

        public override void Update(Fabricante updatedManufactor)
        {
            this.Name = updatedManufactor.Name;
            this.Email = updatedManufactor.Email;
            this.Phone = updatedManufactor.Phone;
        }
    }
}

using System.Net.Mail;

namespace GestaoDeEquipamentos.Dominio
{
    public class Fabricante : EntidadeBase<Fabricante>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        public Fabricante() { }

        public Fabricante(string nome, string email, string telefone) : this()
        {
            this.Nome = nome;
            this.Email = email;
            this.Telefone = telefone;
        }

        public override string Validacao()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Nome))
                erros += "O nome é obrigatório!\n";
            else if (Nome.Length < 2)
                erros += "O nome precisa conter mais do que 1 caractere!\n";

            if (!MailAddress.TryCreate(Email, out _))
                erros += "O email deve conter um formato válido: email@email.com\n";

            if (string.IsNullOrWhiteSpace(Telefone))
                erros += "O telefone é obrigatório!\n";
            else if (Telefone.Length < 9)
                erros += "O telefone deve conter no mínimo 9 caracteres!\n";

            return erros;
        }

        public override void Editar(Fabricante fabricanteAtualizado)
        {
            this.Nome = fabricanteAtualizado.Nome;
            this.Email = fabricanteAtualizado.Email;
            this.Telefone = fabricanteAtualizado.Telefone;
        }
    }
}

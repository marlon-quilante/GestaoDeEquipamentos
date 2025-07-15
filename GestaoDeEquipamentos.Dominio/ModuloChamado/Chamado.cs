namespace GestaoDeEquipamentos.Dominio
{
    public class Chamado : EntidadeBase<Chamado>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public Equipamento Equipamento { get; set; }
        public DateTime DataAbertura { get; set; }

        public Chamado() { }

        public Chamado(string titulo, string descricao, 
            Equipamento equipamento, DateTime dataAbertura) : this()
        {
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Equipamento = equipamento;
            this.DataAbertura = dataAbertura;
        }

        public override string Validacao()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Titulo))
                erros += "O título é obrigatório!\n";
            else if (Titulo.Length < 2)
                erros += "O título precisa conter mais do que 1 caractere!\n";

            if (string.IsNullOrWhiteSpace(Descricao))
                erros += "A descrição é obrigatória!\n";
            else if (Descricao.Length < 2)
                erros += "A descrição precisa conter mais do que 1 caractere!\n";

            return erros;
        }

        public override void Editar(Chamado chamadoAtualizado)
        {
            this.Titulo = chamadoAtualizado.Titulo;
            this.Descricao = chamadoAtualizado.Descricao;
            this.Equipamento = chamadoAtualizado.Equipamento;
        }
    }
}

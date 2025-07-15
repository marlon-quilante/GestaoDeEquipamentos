namespace GestaoDeEquipamentos.Dominio
{
    public class Equipamento : EntidadeBase<Equipamento>
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int NumeroSerie { get; set; }
        public Fabricante Fabricante { get; set; }
        public DateTime DataFabricacao { get; set; }

        public Equipamento() { }

        public Equipamento(string nome, decimal preco, int numeroSerie, 
            Fabricante fabricante, DateTime dataFabricacao) : this()
        {
            this.Nome = nome;
            this.Preco = preco;
            this.NumeroSerie = numeroSerie;
            this.Fabricante = fabricante;
            this.DataFabricacao = dataFabricacao;
        }

        public override string Validacao()
        {
            string erros = "";

            if (string.IsNullOrWhiteSpace(Nome))
                erros += "O nome é obrigatório!\n";
            else if (Nome.Length < 2)
                erros += "O nome precisa conter mais do que 1 caractere!\n";

            if (!decimal.IsCanonical(Preco))
                erros += "O preço digitado não é válido!\n";

            if (!int.IsPositive(NumeroSerie))
                erros += "O número de série digitado não é válido!\n";

            return erros;
        }

        public override void Editar(Equipamento equipamentoEditado)
        {
            this.Nome = equipamentoEditado.Nome;
            this.Preco = equipamentoEditado.Preco;
            this.NumeroSerie = equipamentoEditado.NumeroSerie;
            this.Fabricante = equipamentoEditado.Fabricante;
            this.DataFabricacao = equipamentoEditado.DataFabricacao;
        }
    }
}

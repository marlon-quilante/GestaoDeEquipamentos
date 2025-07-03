using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos
{
    public class RepositorioEquipamentoEmArquivo : RepositorioBaseEmArquivo<Equipamento>
    {
        public RepositorioEquipamentoEmArquivo(ContextoDados context) : base(context) { }

        public override List<Equipamento> GetRegisters()
        {
            return context.Products;
        }

        public override int GetLastID()
        {
            registersList = GetRegisters();
            int lastId = 0;

            foreach (Equipamento product in registersList)
            {
                lastId = product.Id;
            }

            return lastId;
        }
    }
}

using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos
{
    public class RepositorioChamadoEmArquivo : RepositorioBaseEmArquivo<Chamado>
    {
        public RepositorioChamadoEmArquivo(ContextoDados context) : base(context) { }

        public override List<Chamado> GetRegisters()
        {
            return context.Tickets;
        }

        public override int GetLastID()
        {
            registersList = GetRegisters();
            int lastId = 0;

            foreach (Chamado ticket in registersList)
            {
                lastId = ticket.Id;
            }

            return lastId;
        }
    }
}
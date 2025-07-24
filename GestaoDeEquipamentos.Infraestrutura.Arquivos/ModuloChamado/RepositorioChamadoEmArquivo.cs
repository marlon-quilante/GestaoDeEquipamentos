using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos
{
    public class RepositorioChamadoEmArquivo : RepositorioBaseEmArquivo<Chamado>
    {
        public RepositorioChamadoEmArquivo(ContextoDados contexto) : base(contexto) { }

        public override List<Chamado> BuscarRegistros()
        {
            return contexto.Chamados;
        }

        public override int BuscarUltimoID()
        {
            listaRegistros = BuscarRegistros();
            int ultimoID = 0;

            foreach (Chamado c in listaRegistros)
            {
                ultimoID = c.Id;
            }

            return ultimoID;
        }
    }
}
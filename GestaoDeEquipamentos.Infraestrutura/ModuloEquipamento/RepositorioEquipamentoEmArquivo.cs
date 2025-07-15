using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos
{
    public class RepositorioEquipamentoEmArquivo : RepositorioBaseEmArquivo<Equipamento>
    {
        public RepositorioEquipamentoEmArquivo(ContextoDados contexto) : base(contexto) { }

        public override List<Equipamento> BuscarRegistros()
        {
            return contexto.Equipamentos;
        }

        public override int BuscarUltimoID()
        {
            listaRegistros = BuscarRegistros();
            int ultimoID = 0;

            foreach (Equipamento e in listaRegistros)
            {
                ultimoID = e.Id;
            }

            return ultimoID;
        }
    }
}

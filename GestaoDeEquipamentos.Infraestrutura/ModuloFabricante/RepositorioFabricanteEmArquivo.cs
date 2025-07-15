using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos
{
    public class RepositorioFabricanteEmArquivo : RepositorioBaseEmArquivo<Fabricante>
    {
        public RepositorioEquipamentoEmArquivo RepositorioEquipamento;

        public RepositorioFabricanteEmArquivo(ContextoDados contexto) : base(contexto) { }

        public override List<Fabricante> BuscarRegistros()
        {
            return contexto.Fabricantes;
        }

        public override int BuscarUltimoID()
        {
            listaRegistros = BuscarRegistros();
            int ultimoID = 0;

            foreach (Fabricante f in listaRegistros)
            {
                ultimoID = f.Id;
            }

            return ultimoID;
        }

        public int ObterQtdProdutos(Fabricante fabricante)
        {
            int quantidade = 0;

            List<Equipamento> equipamentos = RepositorioEquipamento.BuscarRegistros();

            foreach (Equipamento e in equipamentos)
            {
                if (fabricante.Id == e.Fabricante.Id)
                    quantidade++;
            }
            return quantidade;
        }
    }
}

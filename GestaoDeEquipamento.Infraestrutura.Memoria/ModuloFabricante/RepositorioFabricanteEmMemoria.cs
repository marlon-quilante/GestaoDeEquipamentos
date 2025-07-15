using GestaoDeEquipamentos.Dominio;

namespace GestaoDeEquipamentos.Infraestrutura.Memoria
{
    public class RepositorioFabricanteEmMemoria : RepositorioBaseEmMemoria<Fabricante>
    {
        public RepositorioEquipamentoEmMemoria RepositorioEquipamento;

        public int ObterQtdProdutos(Fabricante fabricante)
        {
            int quantidade = 0;

            List<Equipamento> equipamentos = RepositorioEquipamento.ObterRegistros();

            foreach (Equipamento e in equipamentos)
            {
                if (fabricante.Id == e.Fabricante.Id)
                    quantidade++;
            }
            return quantidade;
        }
    }
}

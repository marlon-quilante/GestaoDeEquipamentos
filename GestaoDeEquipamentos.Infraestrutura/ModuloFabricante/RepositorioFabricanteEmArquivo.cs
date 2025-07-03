using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos
{
    public class RepositorioFabricanteEmArquivo : RepositorioBaseEmArquivo<Fabricante>
    {
        public RepositorioEquipamentoEmArquivo RepositorioEquipamento;

        public RepositorioFabricanteEmArquivo(ContextoDados context) : base(context) { }

        public override List<Fabricante> GetRegisters()
        {
            return context.Manufactors;
        }

        public override int GetLastID()
        {
            registersList = GetRegisters();
            int lastId = 0;

            foreach (Fabricante manufactor in registersList)
            {
                lastId = manufactor.Id;
            }

            return lastId;
        }

        public int GetProductsQty(Fabricante manufactor)
        {
            int number = 0;

            List<Equipamento> products = RepositorioEquipamento.GetRegisters();

            foreach (Equipamento product in products)
            {
                if (manufactor.Id == product.Manufactor.Id)
                    number++;
            }
            return number;
        }
    }
}

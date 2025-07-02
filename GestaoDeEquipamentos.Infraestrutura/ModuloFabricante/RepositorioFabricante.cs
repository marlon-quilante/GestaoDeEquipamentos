using GestaoDeEquipamentos.Dominio;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos
{
    public class RepositorioFabricante : RepositorioBase<Fabricante>
    {
        public RepositorioEquipamento RepositorioEquipamento;

        public int GetProductsQty(Fabricante manufactor)
        {
            int number = 0;

            List<Equipamento> products = RepositorioEquipamento.GetRegisters();

            foreach (Equipamento product in products)
            {
                if (manufactor.id == product.manufactor.id)
                    number++;
            }
            return number;
        }
    }
}

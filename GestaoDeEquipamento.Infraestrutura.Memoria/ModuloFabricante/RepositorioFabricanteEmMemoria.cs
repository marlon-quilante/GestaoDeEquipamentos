using GestaoDeEquipamentos.Dominio;

namespace GestaoDeEquipamentos.Infraestrutura.Memoria
{
    public class RepositorioFabricanteEmMemoria : RepositorioBaseEmMemoria<Fabricante>
    {
        public RepositorioEquipamentoEmMemoria RepositorioEquipamento;

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

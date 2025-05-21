using GestaoDeEquipamentos.Model;

namespace GestaoDeEquipamentos.Controller
{
    public class ManufactorController : BaseController
    {
        public ProductController productController;

        public int GetProductsQty(Manufactor manufactor)
        {
            int number = 0;

            List<BaseRegister> registers = productController.GetRegisters();

            foreach (BaseRegister register in registers)
            {
                Product p = (Product)register;

                if (manufactor.id == p.manufactor.id)
                    number++;
            }
            return number;
        }
    }
}

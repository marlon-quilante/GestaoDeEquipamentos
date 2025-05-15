using GestaoDeEquipamentos.Model;

namespace GestaoDeEquipamentos.Controller
{
    public class ManufactorController
    {
        public List<Manufactor> manufactorsList = new List<Manufactor>();
        public ProductController productController;
        private int idCount = 0;

        public void CreateController(Manufactor newManufactor)
        {
            idCount++;
            newManufactor.id = idCount;
            manufactorsList.Add(newManufactor);
        }

        public void UpdateController(Manufactor updatedManufactor, int idToUpdate)
        {
            foreach (Manufactor m in manufactorsList)
            {
                if (idToUpdate == m.id)
                {
                    m.Update(updatedManufactor);
                    break;
                }
            }
        }

        public void DeleteController(int idToDelete)
        {
            foreach (Manufactor m in manufactorsList)
            {
                if (idToDelete == m.id)
                {
                    manufactorsList.Remove(m);
                    break;
                }
            }
        }

        public bool IDExists(int idToValidate)
        {
            bool idExists = false;

            foreach (Manufactor m in manufactorsList)
            {
                if (idToValidate == m.id)
                {
                    idExists = true;
                    break;
                }
                else
                    idExists = false;
            }
            return idExists;
        }

        public Manufactor GetManufactorByID(int id)
        {
            foreach (Manufactor m in manufactorsList)
            {
                if (id == m.id)
                {
                    return m;
                }
            }
            return null;
        }

        public int GetProductsQty(Manufactor manufactor)
        {
            int number = 0;

            foreach (Product p in productController.productsList)
            {
                if (manufactor.id == p.manufactor.id)
                    number++;
            }

            return number;
        }
    }
}

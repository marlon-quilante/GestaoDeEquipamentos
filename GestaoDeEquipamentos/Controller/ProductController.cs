using GestaoDeEquipamentos.Model;

namespace GestaoDeEquipamentos.Controller
{
    public class ProductController
    {
        public List<Product> productsList = new List<Product>();
        private int idCount = 0;

        public void CreateController(Product newProduct)
        {
            idCount++;
            newProduct.id = idCount;
            productsList.Add(newProduct);
        }

        public void UpdateController(Product updatedProduct, int idToUpdate)
        {
            foreach (Product p in productsList)
            {
                if (idToUpdate == p.id)
                {
                    p.Update(updatedProduct);
                    break;
                }
            }
        }

        public void DeleteController(int idToDelete)
        {
            foreach (Product p in productsList)
            {
                if (idToDelete == p.id)
                {
                    productsList.Remove(p);
                    break;
                }
            }
        }

        public bool IDExists(int idToValidate)
        {
            bool idExists = false;

            foreach (Product p in productsList)
            {
                if (idToValidate == p.id)
                {
                    idExists = true;
                    break;
                }
                else
                    idExists = false;
            }
            return idExists;
        }

        public Product GetProductByID(int id)
        {
            foreach (Product p in productsList)
            {
                if (id == p.id)
                {
                    return p;
                }
            }
            return null;
        }
    }
}

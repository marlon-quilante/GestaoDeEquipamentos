using GestaoDeEquipamentos.Model;
using GestaoDeEquipamentos.View;

namespace GestaoDeEquipamentos.Controller
{
    public class ProductController
    {
        public Product product;
        public List<Product> productsList;
        public ProductView productView;
        public int idCount = 0;

        public void Create()
        {
            productView.CreateHeader();
            product = new Product();
            idCount++;
            product.id = idCount;
            product = productView.Inputs(product);
            productsList.Add(product);
        }

        public string[] Read(Product product)
        {
            string[] productData =
            [
                $"ID: {product.id}",
                $"Nome: {product.name}",
                $"Preço: {product.price}",
                $"Número de série: {product.serialNumber}",
                $"Fabricante: {product.manufactorName}",
                $"Data de fabricação: {product.manufactoringDate.ToString("dd/MM/yyyy")}",
            ];

            return productData;
        }

        public void Update()
        {
            productView.UpdateHeader();
            int idToUpdate = productView.GetID();

            foreach (Product p in productsList)
            {
                if (idToUpdate == p.id)
                {
                    productView.Inputs(p);
                    break;
                }
            }
        }

        public void Delete()
        {
            productView.DeleteHeader();
            int idToDelete = productView.GetID();

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

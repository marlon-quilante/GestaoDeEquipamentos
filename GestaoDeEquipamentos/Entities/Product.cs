namespace GestaoDeEquipamentos.Entities
{
    internal class Product
    {
        public int id = 0;
        public string name = "";
        public decimal price = 0;
        public int serialNumber = 0;
        public string manufactorName = "";
        public DateTime manufactoringDate = new DateTime();

        public void Create(Product product, List<Product> productsList)
        {
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

        public Product Update(List<Product> productsList, int id)
        {
            foreach (Product product in productsList)
            {
                if (id == product.id)
                    return product;
            }
            return null;
        }

        public void Delete(List<Product> productsList, int id)
        {
            foreach (Product product in productsList)
            {
                if (id == product.id)
                {
                    productsList.Remove(product);
                    break;
                }
            }
        }

        public bool IDExists(int id, List<Product> productsList)
        {
            bool idExists = false;

            foreach (Product p in productsList)
            {
                if (id == p.id)
                {
                    idExists = true;
                    break;
                }
                else
                    idExists = false;
            }

            return idExists;
        }
    }
}

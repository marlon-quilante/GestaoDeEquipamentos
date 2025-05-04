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

        public void Create(Product product, List<Product> products)
        {
            products.Add(product);
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
    }
}

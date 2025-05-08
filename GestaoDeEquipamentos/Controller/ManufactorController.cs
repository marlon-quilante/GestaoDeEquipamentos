using GestaoDeEquipamentos.Model;
using GestaoDeEquipamentos.View;

namespace GestaoDeEquipamentos.Controller
{
    public class ManufactorController
    {
        public Manufactor manufactor;
        public List<Manufactor> manufactorsList;
        public ManufactorView manufactorView;
        public Product product;
        public List<Product> productsList;
        public ProductView productView;
        public int idCount = 0;

        public void Create()
        {
            manufactorView.CreateHeader();
            manufactor = new Manufactor();
            idCount++;
            manufactor.id = idCount;
            manufactor = manufactorView.Inputs(manufactor);
            manufactorsList.Add(manufactor);
        }

        public string[] Read(Manufactor manufactor)
        {
            string[] manufactorData =
            [
                $"ID: {manufactor.id}",
                $"Nome: {manufactor.name}",
                $"Email: {manufactor.email}",
                $"Telefone: {manufactor.phone}",
                $"Qtd de equipamentos: {GetProductsQty(manufactor)}"
            ];

            return manufactorData;
        }

        public void Update()
        {
            manufactorView.UpdateHeader();
            int idToUpdate = manufactorView.GetID();

            foreach (Manufactor m in manufactorsList)
            {
                if (idToUpdate == m.id)
                {
                    manufactorView.Inputs(m);
                    break;
                }
            }
        }

        public void Delete()
        {
            manufactorView.DeleteHeader();
            int idToDelete = manufactorView.GetID();

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

            foreach (Product p in productsList)
            {
                if (manufactor.id == p.manufactor.id)
                    number++;
            }

            return number;
        }
    }
}

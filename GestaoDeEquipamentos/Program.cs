using GestaoDeEquipamentos.Model;
using GestaoDeEquipamentos.Controller;
using GestaoDeEquipamentos.View;

namespace GestaoDeEquipamentos
{
    public class Program
    {
        static void Main(string[] args)
        {
            Manufactor manufactor = new Manufactor();
            ManufactorController manufactorController = new ManufactorController();
            ManufactorView manufactorView = new ManufactorView();
            List<Manufactor> manufactorsList = new List<Manufactor>();

            Product product = new Product();
            ProductController productController = new ProductController();
            ProductView productView = new ProductView();
            List<Product> productsList = new List<Product>();

            Ticket ticket = new Ticket();
            TicketController ticketController = new TicketController();
            TicketView ticketView = new TicketView();
            List<Ticket> ticketsList = new List<Ticket>();

            manufactorView.manufactorController = manufactorController;
            manufactorView.manufactorsList = manufactorsList;
            manufactorController.manufactorView = manufactorView;
            manufactorController.manufactorsList = manufactorsList;
            manufactorController.productsList = productsList;

            productView.productController = productController;
            productView.productsList = productsList;
            productView.manufactorView = manufactorView;
            productView.manufactorController = manufactorController;
            productController.productView = productView;
            productController.productsList = productsList;

            ticketView.ticketController = ticketController;
            ticketView.ticketsList = ticketsList;
            ticketView.productView = productView;
            ticketView.productController = productController;
            ticketController.ticketView = ticketView;
            ticketController.ticketsList = ticketsList;

            bool systemON = true;

            while (systemON == true)
            {
                MainHeader();
                string option = MainMenu();

                switch (int.Parse(option)) 
                {
                    case 1:
                        ProductOptions(productView, productController);
                        break;
                    case 2:
                        TicketOptions(ticketView, ticketController);
                        break;
                    case 3:
                        ManufactorOptions(manufactorView, manufactorController);
                        break;
                    case 4:
                        systemON = false;
                        break;
                    default:
                        break;
                } 
            }
        }

        static void MainHeader()
        {
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("SISTEMA DE GESTÃO");
            Console.WriteLine("-----------------");
        }

        static string MainMenu()
        {
            Console.WriteLine("\nSelecione uma opção...\n");
            Console.WriteLine("1- Equipamentos");
            Console.WriteLine("2- Chamados");
            Console.WriteLine("3- Fabricantes");
            Console.WriteLine("4- Sair\n");

            return Console.ReadLine();
        }

        static void ProductOptions(ProductView productView, ProductController productController)
        {
            productView.MainHeader();
            string productOption = productView.Menu();

            switch (int.Parse(productOption))
            {
                case 1:
                    productController.Create();
                    break;
                case 2:
                    productController.Read();
                    break;
                case 3:
                    productController.Update();
                    break;
                case 4:
                    productController.Delete();
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }

        static void TicketOptions(TicketView ticketView, TicketController ticketController)
        {
            ticketView.MainHeader();
            string ticketOption = ticketView.Menu();

            switch (int.Parse(ticketOption))
            {
                case 1:
                    ticketController.Create();
                    break;
                case 2:
                    ticketController.Read();
                    break;
                case 3:
                    ticketController.Update();
                    break;
                case 4:
                    ticketController.Delete();
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }

        static void ManufactorOptions(ManufactorView manufactorView, ManufactorController manufactorController)
        {
            manufactorView.MainHeader();
            string manufactorOption = manufactorView.Menu();

            switch (int.Parse(manufactorOption))
            {
                case 1:
                    manufactorController.Create();
                    break;
                case 2:
                    manufactorController.Read();
                    break;
                case 3:
                    manufactorController.Update();
                    break;
                case 4:
                    manufactorController.Delete();
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }
    }
}

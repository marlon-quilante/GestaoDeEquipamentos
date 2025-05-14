using GestaoDeEquipamentos.Model;
using GestaoDeEquipamentos.Controller;
using GestaoDeEquipamentos.View;

namespace GestaoDeEquipamentos
{
    public class Program
    {
        static void Main(string[] args)
        {
            ProductController productController = new ProductController();
            ProductView productView = new ProductView(productController);

            ManufactorController manufactorController = new ManufactorController();
            ManufactorView manufactorView = new ManufactorView(manufactorController);

            TicketController ticketController = new TicketController();
            TicketView ticketView = new TicketView(ticketController);

            manufactorController.productController = productController;

            productView.manufactorController = manufactorController;
            productView.manufactorView = manufactorView;

            ticketView.productController = productController;
            ticketView.productView = productView;

            bool systemON = true;

            while (systemON == true)
            {
                MainHeader();
                string option = MainMenu();

                switch (int.Parse(option)) 
                {
                    case 1:
                        ProductOptions(productView);
                        break;
                    case 2:
                        TicketOptions(ticketView);
                        break;
                    case 3:
                        ManufactorOptions(manufactorView);
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

        static void ProductOptions(ProductView productView)
        {
            productView.MainHeader();
            string productOption = productView.Menu();

            switch (int.Parse(productOption))
            {
                case 1:
                    productView.Create();
                    break;
                case 2:
                    productView.Read();
                    break;
                case 3:
                    productView.Update();
                    break;
                case 4:
                    productView.Delete();
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }

        static void TicketOptions(TicketView ticketView)
        {
            ticketView.MainHeader();
            string ticketOption = ticketView.Menu();

            switch (int.Parse(ticketOption))
            {
                case 1:
                    ticketView.Create();
                    break;
                case 2:
                    ticketView.Read();
                    break;
                case 3:
                    ticketView.Update();
                    break;
                case 4:
                    ticketView.Delete();
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }

        static void ManufactorOptions(ManufactorView manufactorView)
        {
            manufactorView.MainHeader();
            string manufactorOption = manufactorView.Menu();

            switch (int.Parse(manufactorOption))
            {
                case 1:
                    manufactorView.Create();
                    break;
                case 2:
                    manufactorView.Read();
                    break;
                case 3:
                    manufactorView.Update();
                    break;
                case 4:
                    manufactorView.Delete();
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }
    }
}

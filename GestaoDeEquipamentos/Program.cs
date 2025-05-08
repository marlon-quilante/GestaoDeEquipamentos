using GestaoDeEquipamentos.Model;
using GestaoDeEquipamentos.Controller;
using GestaoDeEquipamentos.View;

namespace GestaoDeEquipamentos
{
    public class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product();
            ProductController productController = new ProductController();
            ProductView productView = new ProductView();
            List<Product> productsList = new List<Product>();

            productView.productController = productController;
            productView.productsList = productsList;
            productController.productsList = productsList;
            productController.productView = productView;

            Ticket ticket = new Ticket();
            TicketController ticketController = new TicketController();
            TicketView ticketView = new TicketView();
            List<Ticket> ticketsList = new List<Ticket>();

            ticketView.ticketController = ticketController;
            ticketView.ticketsList = ticketsList;
            ticketView.productView = productView;
            ticketView.productController = productController;
            ticketController.ticketsList = ticketsList;
            ticketController.ticketView = ticketView;
            ticketController.product = product;

            bool systemON = true;

            while (systemON == true)
            {
                MainHeader();
                string option = MainMenu();

                switch (int.Parse(option)) 
                {
                    case 1:
                        productView.MainHeader();
                        string productOption = productView.Menu();

                        switch (int.Parse(productOption))
                        {
                            case 1:
                                productController.Create();
                                break;
                            case 2:
                                productView.ShowList();
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
                        break;
                    case 2:
                        ticketView.MainHeader();
                        string ticketOption = ticketView.Menu();

                        switch (int.Parse(ticketOption))
                        {
                            case 1:
                                ticketController.Create();
                                break;
                            case 2:
                                ticketView.ShowList();
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
                        break;
                    case 3:
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
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Controle de Produtos e Chamados");
            Console.WriteLine("-------------------------------");
        }

        static string MainMenu()
        {
            Console.WriteLine("Selecione uma opção...\n");
            Console.WriteLine("1- Produtos");
            Console.WriteLine("2- Chamados");
            Console.WriteLine("3- Sair\n");

            return Console.ReadLine();
        }
    }
}

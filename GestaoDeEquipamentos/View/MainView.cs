using GestaoDeEquipamentos.Controller;

namespace GestaoDeEquipamentos.View
{
    public class MainView
    {
        private char option;

        private ManufactorController manufactorController;
        private ProductController productController;
        private TicketController ticketController;

        private ManufactorView manufactorView;
        private ProductView productView;
        private TicketView ticketView;

        public MainView()
        {
            manufactorController = new ManufactorController();
            productController = new ProductController();
            ticketController = new TicketController();

            manufactorView = new ManufactorView(manufactorController);
            productView = new ProductView(productController);
            ticketView = new TicketView(ticketController);

            manufactorController.productController = productController;
            
            productView.manufactorController = manufactorController;
            productView.manufactorView = manufactorView;

            ticketView.productView = productView;
            ticketView.productController = productController;
        }

        public void MainHeader()
        {
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("SISTEMA DE GESTÃO");
            Console.WriteLine("-----------------");
        }

        public void MainMenu()
        {
            Console.WriteLine("\nSelecione uma opção...\n");
            Console.WriteLine("1- Equipamentos");
            Console.WriteLine("2- Chamados");
            Console.WriteLine("3- Fabricantes");
            Console.WriteLine("4- Sair\n");

            option = Console.ReadLine()[0];
        }

        public BaseView GetView()
        {
            if (option == '1')
                return productView;
            else if (option == '2')
                return ticketView;
            else if (option == '3')
                return manufactorView;

            return null;
        }
    }
}

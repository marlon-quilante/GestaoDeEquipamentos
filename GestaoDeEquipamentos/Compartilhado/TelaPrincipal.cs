using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.Infraestrutura.Arquivos;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public class TelaPrincipal
    {
        private char option;

        private RepositorioFabricante RepositorioFabricante;
        private RepositorioEquipamento RepositorioEquipamento;
        private RepositorioChamado RepositorioChamado;

        private TelaFabricante manufactorView;
        private TelaEquipamento productView;
        private TelaChamado ticketView;

        public TelaPrincipal()
        {
            RepositorioFabricante = new RepositorioFabricante();
            RepositorioEquipamento = new RepositorioEquipamento();
            RepositorioChamado = new RepositorioChamado();

            manufactorView = new TelaFabricante(RepositorioFabricante);
            productView = new TelaEquipamento(RepositorioEquipamento);
            ticketView = new TelaChamado(RepositorioChamado);

            RepositorioFabricante.RepositorioEquipamento = RepositorioEquipamento;

            productView.RepositorioFabricante = RepositorioFabricante;
            productView.manufactorView = manufactorView;

            ticketView.productView = productView;
            ticketView.RepositorioEquipamento = RepositorioEquipamento;
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

        public ITela GetView()
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

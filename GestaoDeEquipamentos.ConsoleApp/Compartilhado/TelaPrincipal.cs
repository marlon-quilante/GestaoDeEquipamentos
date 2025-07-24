using GestaoDeEquipamentos.ConsoleApp.ModuloChamado;
using GestaoDeEquipamentos.ConsoleApp.ModuloEquipamento;
using GestaoDeEquipamentos.ConsoleApp.ModuloFabricante;
using GestaoDeEquipamentos.Infraestrutura.Arquivos;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public class TelaPrincipal
    {
        private char opcao;

        private ContextoDados contexto;

        private RepositorioFabricanteEmArquivo RepositorioFabricante;
        private RepositorioEquipamentoEmArquivo RepositorioEquipamento;
        private RepositorioChamadoEmArquivo RepositorioChamado;

        private TelaFabricante viewFabricante;
        private TelaEquipamento viewEquipamento;
        private TelaChamado viewChamado;

        public TelaPrincipal()
        {
            contexto = new ContextoDados(true);

            RepositorioFabricante = new RepositorioFabricanteEmArquivo(contexto);
            RepositorioEquipamento = new RepositorioEquipamentoEmArquivo(contexto);
            RepositorioChamado = new RepositorioChamadoEmArquivo(contexto);

            viewFabricante = new TelaFabricante(RepositorioFabricante);
            viewEquipamento = new TelaEquipamento(RepositorioEquipamento);
            viewChamado = new TelaChamado(RepositorioChamado);

            RepositorioFabricante.RepositorioEquipamento = RepositorioEquipamento;

            viewEquipamento.RepositorioFabricante = RepositorioFabricante;
            viewEquipamento.viewFabricante = viewFabricante;

            viewChamado.viewEquipamento = viewEquipamento;
            viewChamado.RepositorioEquipamento = RepositorioEquipamento;
        }

        public void CabecalhoPrincipal()
        {
            Console.Clear();
            Console.WriteLine("-----------------");
            Console.WriteLine("SISTEMA DE GESTÃO");
            Console.WriteLine("-----------------");
        }

        public void MenuPrincipal()
        {
            Console.WriteLine("\nSelecione uma opção...\n");
            Console.WriteLine("1- Equipamentos");
            Console.WriteLine("2- Chamados");
            Console.WriteLine("3- Fabricantes");
            Console.WriteLine("4- Sair\n");

            opcao = Console.ReadLine()[0];
        }

        public ITela ObterTela()
        {
            if (opcao == '1')
                return viewEquipamento;
            else if (opcao == '2')
                return viewChamado;
            else if (opcao == '3')
                return viewFabricante;

            return null;
        }
    }
}

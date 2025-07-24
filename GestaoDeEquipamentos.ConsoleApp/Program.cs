using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool sistemaON = true;

            TelaPrincipal telaPrincipal = new TelaPrincipal();

            while (sistemaON == true)
            {
                telaPrincipal.CabecalhoPrincipal();
                telaPrincipal.MenuPrincipal();
                ITela telaEscolhida = telaPrincipal.ObterTela();

                if (telaEscolhida == null)
                {
                    sistemaON = false;
                    break;
                }
                else
                {
                    telaEscolhida.CabecalhoPrincipal();
                    string opcao = telaEscolhida.Menu();

                    switch (int.Parse(opcao))
                    {
                        case 1:
                            telaEscolhida.Cadastrar();
                            break;
                        case 2:
                            telaEscolhida.Visualizar();
                            break;
                        case 3:
                            telaEscolhida.Editar();
                            break;
                        case 4:
                            telaEscolhida.Deletar();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}

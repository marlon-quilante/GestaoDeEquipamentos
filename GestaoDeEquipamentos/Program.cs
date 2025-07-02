using GestaoDeEquipamentos.ConsoleApp.Compartilhado;

namespace GestaoDeEquipamentos
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool systemON = true;

            TelaPrincipal mainView = new TelaPrincipal();

            while (systemON == true)
            {
                mainView.MainHeader();
                mainView.MainMenu();
                ITela chosenView = mainView.GetView();

                if (chosenView == null)
                {
                    systemON = false;
                    break;
                }
                else
                {
                    chosenView.MainHeader();
                    string option = chosenView.Menu();

                    switch (int.Parse(option))
                    {
                        case 1:
                            chosenView.Create();
                            break;
                        case 2:
                            chosenView.Read();
                            break;
                        case 3:
                            chosenView.Update();
                            break;
                        case 4:
                            chosenView.Delete();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}

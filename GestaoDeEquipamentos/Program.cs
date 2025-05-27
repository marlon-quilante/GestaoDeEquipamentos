using GestaoDeEquipamentos.View;

namespace GestaoDeEquipamentos
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool systemON = true;

            MainView mainView = new MainView();

            while (systemON == true)
            {
                mainView.MainHeader();
                mainView.MainMenu();
                BaseView chosenView = mainView.GetView();

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

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public interface ITela
    {
        string Menu();
        void MainHeader();
        void Create();
        void Read();
        void Update();
        void Delete();
    }
}

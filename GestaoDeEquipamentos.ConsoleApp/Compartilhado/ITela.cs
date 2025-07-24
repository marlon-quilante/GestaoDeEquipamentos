namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public interface ITela
    {
        string Menu();
        void CabecalhoPrincipal();
        void Cadastrar();
        void Visualizar();
        void Editar();
        void Deletar();
    }
}

namespace GestaoDeEquipamentos.Dominio;

public abstract class EntidadeBase<T>
{
    public int Id { get; set; }

    public abstract string Validacao();

    public abstract void Editar(T registroAtualizado);
}

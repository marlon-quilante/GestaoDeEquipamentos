namespace GestaoDeEquipamentos.Dominio;

public abstract class EntidadeBase<T>
{
    public int Id { get; set; }

    public abstract string Validate();

    public abstract void Update(T updatedRegister);
}

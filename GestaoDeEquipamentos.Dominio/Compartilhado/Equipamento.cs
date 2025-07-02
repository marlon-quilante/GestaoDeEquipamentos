namespace GestaoDeEquipamentos.Dominio;

public abstract class Equipamento<T>
{
    public int id;

    public abstract string Validate();

    public abstract void Update(T updatedRegister);
}

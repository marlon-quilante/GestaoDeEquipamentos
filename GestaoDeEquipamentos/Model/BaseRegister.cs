namespace GestaoDeEquipamentos.Model
{
    public abstract class BaseRegister
    {
        public int id;

        public abstract void Update(BaseRegister updatedRegister);
    }
}

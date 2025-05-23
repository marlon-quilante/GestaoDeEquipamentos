namespace GestaoDeEquipamentos.Model
{
    public abstract class BaseRegister
    {
        public int id;
        public abstract string Validate();

        public abstract void Update(BaseRegister updatedRegister);
    }
}

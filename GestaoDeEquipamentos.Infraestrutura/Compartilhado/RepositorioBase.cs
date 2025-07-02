using GestaoDeEquipamentos.Dominio;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos
{
    public abstract class RepositorioBase<T> where T : Equipamento<T>
    {
        public List<T> registersList = new List<T>();
        private int idCount = 0;

        public void CreateController(T newRegister)
        {
            idCount++;
            newRegister.id = idCount;
            registersList.Add(newRegister);
        }

        public void UpdateController(T updatedRegister, int idToUpdate)
        {
            foreach (T register in registersList)
            {
                if (idToUpdate == register.id)
                {
                    register.Update(updatedRegister);
                    break;
                }
            }
        }

        public void DeleteController(int idToDelete)
        {
            foreach (T register in registersList)
            {
                if (idToDelete == register.id)
                {
                    registersList.Remove(register);
                    break;
                }
            }
        }

        public bool IDExists(int idToValidate)
        {
            bool idExists = false;

            foreach (T register in registersList)
            {
                if (idToValidate == register.id)
                {
                    idExists = true;
                    break;
                }
                else
                    idExists = false;
            }
            return idExists;
        }

        public List<T> GetRegisters()
        {
            return registersList;
        }

        public T GetRegisterByID(int id)
        {
            foreach (T register in registersList)
            {
                if (id == register.id)
                {
                    return register;
                }
            }
            return null;
        }
    }
}

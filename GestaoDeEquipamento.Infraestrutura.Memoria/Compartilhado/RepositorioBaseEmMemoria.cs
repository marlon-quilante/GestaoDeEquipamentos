using GestaoDeEquipamentos.Dominio;

namespace GestaoDeEquipamentos.Infraestrutura.Memoria
{
    public abstract class RepositorioBaseEmMemoria<T> where T : EntidadeBase<T>
    {
        public List<T> registersList = new List<T>();
        private int idCount = 0;

        public void CreateController(T newRegister)
        {
            idCount++;
            newRegister.Id = idCount;
            registersList.Add(newRegister);
        }

        public void UpdateController(T updatedRegister, int idToUpdate)
        {
            foreach (T register in registersList)
            {
                if (idToUpdate == register.Id)
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
                if (idToDelete == register.Id)
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
                if (idToValidate == register.Id)
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
                if (id == register.Id)
                {
                    return register;
                }
            }
            return null;
        }
    }
}

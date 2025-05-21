using GestaoDeEquipamentos.Model;

namespace GestaoDeEquipamentos.Controller
{
    public class BaseController
    {
        public List<BaseRegister> registersList = new List<BaseRegister>();
        private int idCount = 0;

        public void CreateController(BaseRegister newRegister)
        {
            idCount++;
            newRegister.id = idCount;
            registersList.Add(newRegister);
        }

        public void UpdateController(BaseRegister updatedRegister, int idToUpdate)
        {
            foreach (BaseRegister register in registersList)
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
            foreach (BaseRegister register in registersList)
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

            foreach (BaseRegister register in registersList)
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

        public List<BaseRegister> GetRegisters()
        {
            return registersList;
        }

        public BaseRegister GetRegisterByID(int id)
        {
            foreach (BaseRegister register in registersList)
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

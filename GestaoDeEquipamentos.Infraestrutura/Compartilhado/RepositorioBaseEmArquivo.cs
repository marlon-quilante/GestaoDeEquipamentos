using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos
{
    public abstract class RepositorioBaseEmArquivo<T> where T : EntidadeBase<T>
    {
        public List<T> registersList = new List<T>();
        protected ContextoDados context;

        protected RepositorioBaseEmArquivo(ContextoDados context)
        {
            this.context = context;
            this.registersList = GetRegisters();
        }

        public void Create(T newRegister)
        {
            newRegister.Id = GetLastID() + 1;
            registersList.Add(newRegister);

            context.Save();
        }

        public abstract int GetLastID();

        public bool Update(T updatedRegister, int idToUpdate)
        {
            foreach (T register in registersList)
            {
                if (idToUpdate == register.Id)
                {
                    register.Update(updatedRegister);
                    break;
                }
            }
            context.Save();
            return true;
        }

        public void Delete(int idToDelete)
        {
            foreach (T register in registersList)
            {
                if (idToDelete == register.Id)
                {
                    registersList.Remove(register);
                    break;
                }
            }

            context.Save();
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

        public abstract List<T> GetRegisters();
    }
}

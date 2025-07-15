using GestaoDeEquipamentos.Dominio;

namespace GestaoDeEquipamentos.Infraestrutura.Memoria
{
    public abstract class RepositorioBaseEmMemoria<T> where T : EntidadeBase<T>
    {
        public List<T> listaRegistros = new List<T>();
        private int contadorID = 0;

        public void Cadastrar(T novoRegistro)
        {
            contadorID++;
            novoRegistro.Id = contadorID;
            listaRegistros.Add(novoRegistro);
        }

        public void Editar(T registroAtualizado, int idParaAtualizar)
        {
            foreach (T registro in listaRegistros)
            {
                if (idParaAtualizar == registro.Id)
                {
                    registro.Editar(registroAtualizado);
                    break;
                }
            }
        }

        public void Excluir(int idParaDeletar)
        {
            foreach (T registro in listaRegistros)
            {
                if (idParaDeletar == registro.Id)
                {
                    listaRegistros.Remove(registro);
                    break;
                }
            }
        }

        public bool IDExiste(int idParaValidar)
        {
            bool idExiste = false;

            foreach (T registro in listaRegistros)
            {
                if (idParaValidar == registro.Id)
                {
                    idExiste = true;
                    break;
                }
                else
                    idExiste = false;
            }
            return idExiste;
        }

        public List<T> ObterRegistros()
        {
            return listaRegistros;
        }

        public T ObterRegistroPeloID(int id)
        {
            foreach (T registro in listaRegistros)
            {
                if (id == registro.Id)
                {
                    return registro;
                }
            }
            return null;
        }
    }
}

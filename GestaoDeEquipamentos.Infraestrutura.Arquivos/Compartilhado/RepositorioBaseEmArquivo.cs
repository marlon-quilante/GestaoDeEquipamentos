using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos
{
    public abstract class RepositorioBaseEmArquivo<T> where T : EntidadeBase<T>
    {
        public List<T> listaRegistros = new List<T>();
        protected ContextoDados contexto;

        protected RepositorioBaseEmArquivo(ContextoDados contexto)
        {
            this.contexto = contexto;
            this.listaRegistros = BuscarRegistros();
        }

        public void Cadastrar(T novoRegistro)
        {
            novoRegistro.Id = BuscarUltimoID() + 1;
            listaRegistros.Add(novoRegistro);

            contexto.Salvar();
        }

        public abstract int BuscarUltimoID();

        public bool Editar(T registroAtualizado, int idParaAtualizar)
        {
            foreach (T registro in listaRegistros)
            {
                if (idParaAtualizar == registro.Id)
                {
                    registro.Editar(registroAtualizado);
                    break;
                }
            }
            contexto.Salvar();
            return true;
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

            contexto.Salvar();
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

        public T BuscarRegistroPeloID(int id)
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

        public abstract List<T> BuscarRegistros();
    }
}

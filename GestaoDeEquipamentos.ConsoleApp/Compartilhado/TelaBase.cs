using GestaoDeEquipamentos.Dominio;
using GestaoDeEquipamentos.Infraestrutura.Arquivos;

namespace GestaoDeEquipamentos.ConsoleApp.Compartilhado
{
    public abstract class TelaBase<T> where T : EntidadeBase<T>
    {
        private string nomeEntidade;
        private RepositorioBaseEmArquivo<T> RepositorioBase;

        protected TelaBase(string nomeEntidade, RepositorioBaseEmArquivo<T> RepositorioBase)
        {
            this.nomeEntidade = nomeEntidade;
            this.RepositorioBase = RepositorioBase;
        }

        public void CabecalhoPrincipal()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Controle de {nomeEntidade}s");
            Console.WriteLine("---------------------------");
        }

        public string Menu()
        {
            Console.WriteLine("Selecione uma opção...\n");
            Console.WriteLine("1- Cadastrar");
            Console.WriteLine("2- Visualizar");
            Console.WriteLine("3- Editar");
            Console.WriteLine("4- Excluir");
            Console.WriteLine("5- Voltar\n");

            return Console.ReadLine();
        }

        protected abstract T Dados();

        public void Cadastrar()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Cadastro de {nomeEntidade}");
            Console.WriteLine("---------------------------\n");

            T novoRegistro = Dados();
            string erros = novoRegistro.Validacao();

            if (erros != "")
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(erros);
                Console.ResetColor();
                Console.Write("Pressione ENTER para continuar...");
                Console.ReadLine();

                Cadastrar();
                return;
            }

            Console.WriteLine("\nCadastro realizado com sucesso!");
            Console.ReadLine();
            RepositorioBase.Cadastrar(novoRegistro);
        }

        public void Visualizar()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"{nomeEntidade}s Cadastrados");
            Console.WriteLine("---------------------------\n");

            MostrarLista();
        }

        public void Editar()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Edição de {nomeEntidade}");
            Console.WriteLine("---------------------------\n");

            int idParaAtualizar = BuscarID();
            Console.WriteLine();
            T registroAtualizado = Dados();
            RepositorioBase.Editar(registroAtualizado, idParaAtualizar);
        }

        public void Deletar()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Exclusão de {nomeEntidade}");
            Console.WriteLine("---------------------------\n");

            int idParaDeletar = BuscarID();

            RepositorioBase.Excluir(idParaDeletar);
        }

        protected abstract void MostrarLista();

        public int BuscarID()
        {
            int id = 0;
            bool idExiste = false;

            do
            {
                Console.Write($"ID do {nomeEntidade.ToLower()}: ");
                id = int.Parse(Console.ReadLine());
                idExiste = RepositorioBase.IDExiste(id);

                if (idExiste == false)
                {
                    Console.WriteLine($"\nNão foi encontrado um {nomeEntidade.ToLower()} com este ID! Pressione ENTER e tente novamente...");
                    Console.ReadLine();
                }
            }
            while (idExiste == false);

            return id;
        }
    }
}

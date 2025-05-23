using GestaoDeEquipamentos.Controller;
using GestaoDeEquipamentos.Model;

namespace GestaoDeEquipamentos.View
{
    public abstract class BaseView
    {
        private string entityName;
        private BaseController baseController;

        protected BaseView(string entityName, BaseController baseController)
        {
            this.entityName = entityName;
            this.baseController = baseController;
        }

        public void MainHeader()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Controle de {entityName}s");
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

        protected abstract BaseRegister Inputs();

        public void Create()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Cadastro de {entityName}");
            Console.WriteLine("---------------------------\n");

            BaseRegister newRegister = Inputs();
            string errors = newRegister.Validate();

            if (errors != "")
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(errors);
                Console.ResetColor();
                Console.Write("Pressione ENTER para continuar...");
                Console.ReadLine();

                Create();
                return;
            }

            Console.WriteLine("\nCadastro realizado com sucesso!");
            Console.ReadLine();
            baseController.CreateController(newRegister);
        }

        public void Read()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"{entityName}s Cadastrados");
            Console.WriteLine("---------------------------\n");

            ShowList();
        }

        public void Update()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Edição de {entityName}");
            Console.WriteLine("---------------------------\n");

            int idToUpdate = GetID();
            Console.WriteLine();
            BaseRegister updatedRegister = Inputs();
            baseController.UpdateController(updatedRegister, idToUpdate);
        }

        public void Delete()
        {
            Console.Clear();
            Console.WriteLine("---------------------------");
            Console.WriteLine($"Exclusão de {entityName}");
            Console.WriteLine("---------------------------\n");

            int idToDelete = GetID();

            baseController.DeleteController(idToDelete);
        }

        protected abstract void ShowList();

        public int GetID()
        {
            int inputID = 0;
            bool IDExists = false;

            do
            {
                Console.Write($"ID do {entityName.ToLower()}: ");
                inputID = int.Parse(Console.ReadLine());
                IDExists = baseController.IDExists(inputID);

                if (IDExists == false)
                {
                    Console.WriteLine($"\nNão foi encontrado um {entityName.ToLower()} com este ID! Pressione ENTER e tente novamente...");
                    Console.ReadLine();
                }
            }
            while (IDExists == false);

            return inputID;
        }
    }
}

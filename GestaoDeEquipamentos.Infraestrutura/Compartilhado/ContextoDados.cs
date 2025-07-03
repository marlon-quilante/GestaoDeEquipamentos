using GestaoDeEquipamentos.Dominio;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado
{
    public class ContextoDados
    {
        public List<Fabricante> Manufactors { get; set; }
        public List<Equipamento> Products { get; set; }
        public List<Chamado> Tickets { get; set; }

        private string storageFolder = "C:\\temp";
        private string storageFile = "dados.json";

        public ContextoDados()
        {
            Manufactors = new List<Fabricante>();
            Products = new List<Equipamento>();
            Tickets = new List<Chamado>();
        }

        public ContextoDados(bool loadData) : this()
        {
            if (loadData) Load();
        }

        public void Save()
        {
            string path = Path.Combine(storageFolder, storageFile);

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.WriteIndented = true;
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            Directory.CreateDirectory(storageFolder);

            string jsonContent = JsonSerializer.Serialize(this);

            File.WriteAllText(path, jsonContent);
        }

        public void Load()
        {
            string path = Path.Combine(storageFolder, storageFile);

            if (!Directory.Exists(storageFolder)) return;

            string jsonContent = File.ReadAllText(path);

            if (string.IsNullOrWhiteSpace(jsonContent)) return;

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            ContextoDados storedContext = JsonSerializer.Deserialize<ContextoDados>(jsonContent, jsonOptions)!;

            if (storedContext == null) return;

            this.Manufactors = storedContext.Manufactors;
            this.Products = storedContext.Products;
            this.Tickets = storedContext.Tickets;
        }
    }
}

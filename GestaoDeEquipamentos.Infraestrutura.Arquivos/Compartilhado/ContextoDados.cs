using GestaoDeEquipamentos.Dominio;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GestaoDeEquipamentos.Infraestrutura.Arquivos.Compartilhado
{
    public class ContextoDados
    {
        public List<Fabricante> Fabricantes { get; set; }
        public List<Equipamento> Equipamentos { get; set; }
        public List<Chamado> Chamados { get; set; }

        private string pastaArmazenamento = "C:\\temp";
        private string arquivoArmazenamento = "dados.json";

        public ContextoDados()
        {
            Fabricantes = new List<Fabricante>();
            Equipamentos = new List<Equipamento>();
            Chamados = new List<Chamado>();
        }

        public ContextoDados(bool carregarDados) : this()
        {
            if (carregarDados) Carregar();
        }

        public void Salvar()
        {
            string caminho = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            JsonSerializerOptions opcoesJson = new JsonSerializerOptions();
            opcoesJson.WriteIndented = true;
            opcoesJson.ReferenceHandler = ReferenceHandler.Preserve;

            string conteudoJson = JsonSerializer.Serialize(this);

            Directory.CreateDirectory(pastaArmazenamento);

            File.WriteAllText(caminho, conteudoJson);
        }

        public void Carregar()
        {
            string caminhoCompleto = Path.Combine(pastaArmazenamento, arquivoArmazenamento);

            if (!File.Exists(caminhoCompleto))
                return;

            string conteudoJson = File.ReadAllText(caminhoCompleto);

            if (string.IsNullOrWhiteSpace(conteudoJson))
                return;

            JsonSerializerOptions jsonOptions = new JsonSerializerOptions();
            jsonOptions.ReferenceHandler = ReferenceHandler.Preserve;

            ContextoDados contextoArmazenado = JsonSerializer.Deserialize<ContextoDados>(conteudoJson, jsonOptions)!;

            if (contextoArmazenado == null)
                return;

            this.Fabricantes = contextoArmazenado.Fabricantes;
            this.Equipamentos = contextoArmazenado.Equipamentos;
            this.Chamados = contextoArmazenado.Chamados;
        }
    }
}

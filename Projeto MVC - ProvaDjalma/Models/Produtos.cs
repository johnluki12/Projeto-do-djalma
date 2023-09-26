namespace Projeto_MVC___ProvaDjalma.Models
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal PrecoVenda { get; set; }
        public string Marca { get; set; }
        public string Fabricante { get; set; }
        public int EstoqueAtual { get; set; }
    }
}

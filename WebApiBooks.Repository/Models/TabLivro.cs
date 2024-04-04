namespace WebApiBooks.Repository.Models
{
    public class TabLivro
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string autor { get; set; }
        public decimal preco { get; set; }
        public DateTime dataLancamento { get; set; }
    }
}

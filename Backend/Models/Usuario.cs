namespace GerfinAPI.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public ICollection<Renda> ? Rendas { get; set; }
        public ICollection<Despesa> ? Despesas { get; set; }
    }
}
namespace GerfinAPI.Models
{
    public class Renda
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataRecebimento { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
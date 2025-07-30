using Microsoft.EntityFrameworkCore;
using GerfinAPI.Models;

namespace GerfinAPI.Data // ou o nome do seu projeto + ".Data"
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class GerfinDbContext : DbContext
    {
        public GerfinDbContext(DbContextOptions<GerfinDbContext> options)
        : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Renda> Rendas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
    }
}

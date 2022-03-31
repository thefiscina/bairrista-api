using Microsoft.EntityFrameworkCore;

namespace Bairrista.Dominio
{
    public sealed class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");        
            modelBuilder.Entity<Usuario>().ToTable("usuario");
            modelBuilder.Entity<Endereco>().ToTable("endereco");
            modelBuilder.Entity<Avaliacao>().ToTable("avaliacao");
            modelBuilder.Entity<Orcamento>().ToTable("orcamento");
            modelBuilder.Entity<OrcamentoResposta>().ToTable("orcamento_resposta");
            modelBuilder.Entity<PagamentoUsuario>().ToTable("pagamento_usuario");
            modelBuilder.Entity<Estado>().ToTable("estado");
            modelBuilder.Entity<Municipio>().ToTable("municipio");
            modelBuilder.Entity<Profissao>().ToTable("profissao");
        }
    }
}
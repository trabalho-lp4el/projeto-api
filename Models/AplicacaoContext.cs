using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projeto_api.Models;

namespace projeto_api.Models
{
    public class AplicacaoContext :DbContext
    {
        public AplicacaoContext(DbContextOptions<AplicacaoContext> options) : base(options) {        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasMany<Ponto>(u => u.Pontos)
                .WithOne(p => p.Usuario)
                .HasForeignKey(p => p.UsuarioId);

            modelBuilder.Entity<Ponto>()
                .HasMany<Solicitacao>(p => p.Solicitacoes)
                .WithOne(s => s.Ponto)
                .HasForeignKey(s => s.PontoId);
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Ponto> Ponto { get; set; }
        public DbSet<Solicitacao> Solicitacao { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using SideTechProd2.Mapeamento;

namespace SideTechProd2.Models
{
    public class Contexto : DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new EmpresaMap());
            builder.ApplyConfiguration(new FuncionarioMap());
        }

    }
}


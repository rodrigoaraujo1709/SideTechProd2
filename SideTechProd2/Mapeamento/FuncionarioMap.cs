using Microsoft.EntityFrameworkCore;
using SideTechProd2.Models;

namespace SideTechProd2.Mapeamento
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(f => f.IdFuncionario);
            builder.Property(f => f.Nome).HasMaxLength(100).IsRequired();
            builder.Property(f => f.Cpf).HasMaxLength(14).IsRequired();
            builder.Property(f => f.Matricula).HasMaxLength(12).IsRequired();
            builder.Property(f => f.DataDeAdmissao).IsRequired();

            builder.HasOne(f => f.Empresa).WithMany(f => f.Funcionarios).HasForeignKey(f => f.IdEmpresa).IsRequired();

            builder.ToTable("Funcionarios");
        }
    }
}


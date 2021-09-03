using Microsoft.EntityFrameworkCore;
using SideTechProd2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SideTechProd2.Mapeamento
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Empresa> builder)
        {
            builder.HasKey(e => e.IdEmpresa);
            builder.Property(f => f.RazaoSocial).HasMaxLength(100).IsRequired();
            builder.Property(f => f.NomeFantasia).HasMaxLength(100).IsRequired();
            builder.Property(f => f.Cnpj).HasMaxLength(18).IsRequired();


            builder.HasMany(e => e.Funcionarios).WithOne(c => c.Empresa);

            builder.ToTable("Empresas");
        }
    }
}


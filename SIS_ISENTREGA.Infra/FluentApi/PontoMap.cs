using SIS_ISENTREGA.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace SIS_ISENTREGA.DataAccess
{
   public class PontoMap :EntityTypeConfiguration<Ponto>
    {
        public PontoMap()
        {
            this.ToTable("Ponto");
            this.HasKey(r => r.OidPonto);
            this.Property(r => r.OidPonto).HasColumnType("int").HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(r => r.OidMatriz).HasColumnType("int");
            this.Property(r => r.NomeMatriz).HasColumnType("nvarchar").HasMaxLength(100);
            this.Property(r => r.DataCadastro).HasColumnType("DateTime").HasPrecision(8);
            this.Property(r => r.NomeMatriz).HasColumnType("nvarchar").HasMaxLength(18);

            //Relacionamento

            this.HasRequired(r => r.Matriz).WithMany().HasForeignKey(r => r.OidMatriz);
        }
    }
}

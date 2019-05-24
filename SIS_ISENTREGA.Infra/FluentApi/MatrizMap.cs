using SIS_ISENTREGA.Domain;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
namespace SIS_ISENTREGA.DataAccess
{
    public class MatrizMap : EntityTypeConfiguration<Matriz>
    {
        public MatrizMap()
        {
            this.ToTable("Matriz");
            this.HasKey(r => r.OidMatriz);
            this.Property(r => r.OidMatriz).HasColumnType("int")
                                           .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(r => r.NomeMatriz).HasColumnType("nvarchar")
                                            .HasMaxLength(100);
            this.Property(r => r.DataCadastro).HasColumnType("DateTime")
                                              .HasPrecision(8);
            this.Property(r => r.NomeMatriz).HasColumnType("nvarchar")
                                            .HasMaxLength(18);

        }
    }
}

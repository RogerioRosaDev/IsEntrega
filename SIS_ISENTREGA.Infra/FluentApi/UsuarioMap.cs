using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS_ISENTREGA.Domain;

namespace SIS_ISENTREGA.DataAccess
{
   public class UsuarioMap: EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            this.ToTable("Usuario");
            this.HasKey(r => r.OidUsuario);
            this.Property(r => r.OidUsuario).HasColumnType("int")
                                            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(r => r.NomeUsuario).HasColumnType("nvarchar")
                                             .HasMaxLength(100);
            this.Property(r => r.Email).HasColumnType("nvarchar")
                                       .HasMaxLength(50);
            this.Property(r => r.Senha).HasColumnType("nvarchar")
                                .HasMaxLength(50);
            this.Property(r => r.Token).HasColumnType("nvarchar")
                                       .HasMaxLength(50);
            this.Property(r => r.FlAtivo).HasColumnType("bit");
            this.Property(r => r.DataCadastro).HasColumnType("DateTime")
                                              .HasPrecision(8);
        }
    }
}

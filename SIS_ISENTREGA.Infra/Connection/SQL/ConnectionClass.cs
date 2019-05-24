
using SIS_ISENTREGA.Domain;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SIS_ISENTREGA.DataAccess
{
    public class ConnectionClass : DbContext
    {
        public ConnectionClass() : base(StringConnection())
        {

        }

        public DbSet<Matriz> Matriz { get; set; }
        public DbSet<Ponto> Ponto { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new MatrizMap());
            modelBuilder.Configurations.Add(new PontoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }

        public static String StringConnection()
        {
            // Mudar String de Conexao
            return "Server=DESKTOP-ABT071V; Database = SIS_ISENTREGA; Trusted_Connection = True; User ID = sa; Password = Pa$$w0rd; MultipleActiveResultSets=true";
        }
    }
}

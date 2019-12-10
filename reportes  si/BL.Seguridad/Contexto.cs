using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Seguridad
{
    public class Contexto : DbContext
    {
        public Contexto() : base("Data Source=yourfunnypics.db.4232052.hostedresource.com; Initial Catalog=yourfunnypics; User ID=yourfunnypics; Password='Temp%123';")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("OrdenesDeTrabajo");
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosdeInicio());
        }



        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Equipo>Equipos { get; set; }
        public DbSet<DetallesEquipo> Detalles { get; set; }








    }
}
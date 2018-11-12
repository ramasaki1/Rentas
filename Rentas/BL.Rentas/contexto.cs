using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Rentas
{
   public class contexto:DbContext
    {
        public contexto():base("VideoJuegos")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosdeInicio());
            //Agrega Datos de Inicio despues de ELIMINARLA
        }

        public DbSet<Producto> Productos{ get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        internal void _Savechanges()
        {
          throw new NotImplementedException();
        }
    }
}

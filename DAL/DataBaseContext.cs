using CashFlow_API.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
namespace CashFlow_API.DAL
{
    public class DataBaseContext :DbContext
    {
        //Conexión a la BD
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Persona>().HasIndex(c => c.Nombre).IsUnique();//Aquí creo un indice
            modelBuilder.Entity<Persona>().HasIndex(c => c.Cedula).IsUnique();
            modelBuilder.Entity<Gasto>().HasIndex(g => g.Referencia).IsUnique();
        }

        #region DbSets
            public DbSet<Persona> Personas { get; set; }
            public DbSet<Gasto> Gastos { get; set; }
        #endregion
    }
}

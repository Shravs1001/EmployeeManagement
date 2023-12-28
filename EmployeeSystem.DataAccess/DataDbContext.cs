using EmployeeManagement.DataAccess.Common.Entities;
using EmployeeManagement.DataAccess.Entity_Configurations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccess
{
    public class DataDbContext : DbContext
    {

        private static readonly string DB_NAME = "postgres";
        private string schemaName = "public";


        public DbSet<EmployeeEntity> Employees{ get; set; }

        public DbSet<LoginEntity> Login { get; set; }

        public DbSet<ProfileEntity> Profile { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string connectionstring = "Server=localhost;Port=5432;Username=postgres;Password=Qwertyuiop@19;Database=attendance;";
            schemaName = "public";
            optionsBuilder.UseNpgsql(connectionstring);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new ProfileConfiguration());
            modelBuilder.ApplyConfiguration(new LoginConfiguration());
          
        }


    }
}

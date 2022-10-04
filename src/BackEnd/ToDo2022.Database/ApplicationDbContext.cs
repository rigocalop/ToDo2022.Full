using System.Security.Cryptography.X509Certificates;

namespace ToDo2022.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        //Request
        public DbSet<Meta> Meta { get; set; }
        public DbSet<Tarea> Tarea { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ModelConfig(modelBuilder);
            modelBuilder.HasDefaultSchema("TODO");
        }
        private void ModelConfig(ModelBuilder modelBuilder)
        {

            new Meta__Configuration(modelBuilder.Entity<Meta>());
            new Tarea__Configuration(modelBuilder.Entity<Tarea>());
        }
    }
}

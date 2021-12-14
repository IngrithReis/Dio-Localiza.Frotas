using Localiza.Frotas.Domain;
using Microsoft.EntityFrameworkCore;

namespace Localiza.Frotas.Infra
{
    public class LocalizaDbContext : DbContext
    {
        public LocalizaDbContext(DbContextOptions<LocalizaDbContext> options) : base(options)
        { }
        public DbSet<Veiculo> Veiculos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Veiculo>(builder =>
            {

                builder.Property(x => x.Id);
                builder.Property(x => x.Placa).HasMaxLength(100).IsRequired();
                builder.Property(x => x.Marca).HasMaxLength(100).IsRequired();
                builder.Property(x => x.AnoFabricacao).HasMaxLength(10).IsRequired();


            });

        }
    }

}


        

        
    


using CardValidator.Domain.Entities;
using CV.Infrastructure.Database.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CV.Infrastructure.Database
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options) { }

        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardEntityTypeConfiguration());
        }
    }
}

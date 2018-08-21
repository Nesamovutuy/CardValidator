using CardValidator.Domain.Entities;
using CardValidator.Domain.Interfaces;
using CV.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CV.Infrastructure.Data
{
    public class ContextBase : DbContext, IUnitOfWork
    {
        public DbSet<Card> Cards { get; set; }

        private ContextBase(DbContextOptions<ContextBase> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardEntityTypeConfiguration());
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // After executing this line all the changes performed through the DbContext will be committed
            var result = await base.SaveChangesAsync();

            return true;
        }
    }
}

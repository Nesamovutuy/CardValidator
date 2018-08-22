using CardValidator.Domain.Interfaces;
using System.Threading.Tasks;

namespace CV.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextBase _context;

        public UnitOfWork(ContextBase context)
        {
            _context = context;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

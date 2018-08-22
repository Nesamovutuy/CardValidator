using System;
using System.Threading.Tasks;

namespace CardValidator.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
    }
}

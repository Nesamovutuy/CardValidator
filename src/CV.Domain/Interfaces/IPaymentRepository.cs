using CardValidator.Domain.Entities;

namespace CardValidator.Domain.Interfaces
{
    public interface IPaymentRepository : IRepository<Card>
    {
        bool IsCardNumberExists(string cardNumber);
    }
}

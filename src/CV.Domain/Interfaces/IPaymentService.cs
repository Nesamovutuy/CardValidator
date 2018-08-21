using CardValidator.Domain.Entities;

namespace CardValidator.Domain.Interfaces
{
    public interface IPaymentService : IRepository<Card>
    {
        bool IsCardNumberExist(string cardNumber);
    }
}

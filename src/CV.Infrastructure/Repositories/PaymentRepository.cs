using CardValidator.Domain.Entities;
using CardValidator.Domain.Interfaces;
using CV.Infrastructure.Database;

namespace CV.Infrastructure.Repositories
{
    public class PaymentRepository : EfRepository<Card>, IPaymentRepository
    {
        public PaymentRepository(ContextBase context) : base(context)
        {
        }

        public bool IsCardNumberExists(string cardNumber)
        {
            // TODO: Added stored proc call
            throw new System.NotImplementedException();
        }
    }
}

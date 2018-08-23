using CardValidator.Domain.Entities;
using CardValidator.Domain.Interfaces;
using CV.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace CV.Infrastructure.Repositories
{
    public class PaymentRepository : EfRepository<Card>, IPaymentRepository
    {
        public PaymentRepository(ContextBase context) : base(context)
        {
        }

        public bool IsCardNumberExists(string cardNumber)
        {
            SqlParameter param = new SqlParameter("@number", SqlDbType.NVarChar)
            {
                Value = cardNumber
            };

            return _context.Database.ExecuteSqlCommand("exec IsCardNumberExists @number", param) == 1; // if 1 is exists
        }
    }
}

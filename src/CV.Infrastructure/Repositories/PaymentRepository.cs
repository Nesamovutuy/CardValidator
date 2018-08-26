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
            SqlParameter number = new SqlParameter("@number", SqlDbType.NVarChar)
            {
                Value = cardNumber
            };

            SqlParameter isExists = new SqlParameter
            {
                ParameterName = "@isExist",
                SqlDbType = SqlDbType.Bit,
                Direction = ParameterDirection.Output
            };

            _context.Database.ExecuteSqlCommand("IsCardNumberExists @number, @isExist OUT", number, isExists);

            return (bool)isExists.Value;
        }
    }
}

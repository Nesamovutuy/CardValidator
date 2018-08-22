using CardValidator.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CV.Infrastructure.Database
{
    public class ContextBaseSeed
    {
        public static async Task SeedAsync(ContextBase context,
            ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                // TODO: Only run this if using a real database
                // context.Database.Migrate();

                if (!context.Cards.Any())
                {
                    context.Cards.AddRange(
                        GetPreconfiguredCards());

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<ContextBaseSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(context, loggerFactory, retryForAvailability);
                }
            }
        }

        static IEnumerable<Card> GetPreconfiguredCards()
        {
            return new List<Card>()
            {
                // Visa
                new Card() { CardNumber = "4725364751442738" },
                new Card() { CardNumber = "4622385684083269" },
                new Card() { CardNumber = "4357514073698442" },
                new Card() { CardNumber = "4940821107767620" },
                // MasterCard
                new Card() { CardNumber = "5295117316010979" },
                new Card() { CardNumber = "5300315472681822" },
                new Card() { CardNumber = "5387188082387494" },
                new Card() { CardNumber = "5512976419382578" },
                // Amex
                new Card() { CardNumber = "343261400231563" },
                new Card() { CardNumber = "375030148596145" },
                new Card() { CardNumber = "346668824911512" },
                new Card() { CardNumber = "375572842886595" },
                // JCB
                new Card() { CardNumber = "3542516435332089" },
                new Card() { CardNumber = "3543150747856947" },
                new Card() { CardNumber = "3535429155217721" },
                new Card() { CardNumber = "3561160334739049" },
                // Unknown
                new Card() { CardNumber = "6011110063380241" },
                new Card() { CardNumber = "2014269757902178" },
                new Card() { CardNumber = "8699549921769074" },
                new Card() { CardNumber = "7569309731262530" }
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CV.Api.ViewModels
{
    public class CardViewModel : IValidatableObject
    {
        public string Number { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            Regex spacesDashes = new Regex(@"[ -]+");
            Number = spacesDashes.Replace(Number, "");

            Regex notDigits = new Regex(@"[^0-9]+");
            if (notDigits.Match(Number).Success)
                yield return new ValidationResult("Invalid");

            if (Number.Length < 15 || Number.Length > 16)
                yield return new ValidationResult("Invalid");

            if (Number.Length == 15 && !Number.StartsWith("3"))
                yield return new ValidationResult("Invalid");

            DateTime CurrentDate = DateTime.Now;
            if ((Month < 1 || Month > 12)
                || (Year < CurrentDate.Year || Year > DateTime.MaxValue.Year)
                || (Year == CurrentDate.Year && Month < CurrentDate.Month)
                || (Number.StartsWith("4") && !DateTime.IsLeapYear(Year))
                || (Number.StartsWith("5") && !IsPrimeNumber(Year)))
                yield return new ValidationResult("Invalid");
        }

        // TODO: Move to HelperService
        private bool IsPrimeNumber(int number)
        {
            if (number < 2)
                return false;
            if (number % 2 == 0)
                return number == 2;

            int n = (int)(Math.Sqrt(number) + 0.5);

            for (int i = 3; i <= n; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}



using CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate.Extensions;

namespace CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate
{
    public class MoneyValueMustHaveCurrencyRule : IBusinessRule
    {
        private readonly string _currency;

        public MoneyValueMustHaveCurrencyRule(string currency)
        {
            _currency = currency;
        }

        public bool IsBroken() => string.IsNullOrEmpty(_currency);

        public string Message => "";
    }
}
using CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate
{
    //Value Object
    public class MoneyValue : ValueObject
    {
        public Decimal Value { get; }

        public string Currency { get; }

        //private MoneyValue(Decimal value, string currency)
        //{
        //    this.Value = value;
        //    this.Currency = currency;
        //}

        public MoneyValue(Decimal value, string currency)
        {
            this.Value = value;
            this.Currency = currency;
        }

        public static MoneyValue Of(Decimal value, string currency)
        {
            CheckRule(new MoneyValueMustHaveCurrencyRule(currency));

            return new MoneyValue(value, currency);
        }

        public static MoneyValue Of(MoneyValue value)
        {
            return new MoneyValue(value.Value, value.Currency);
        }

        public static MoneyValue operator +(MoneyValue moneyValueLeft, MoneyValue moneyValueRight)
        {
            CheckRule(new MoneyValueOperationMustBePerformedOnTheSameCurrencyRule(moneyValueLeft, moneyValueRight));

            if (moneyValueLeft.Currency != moneyValueRight.Currency)
            {
                throw new ArgumentException();
            }

            return new MoneyValue(moneyValueLeft.Value + moneyValueRight.Value, moneyValueLeft.Currency);
        }

        public static MoneyValue operator *(int number, MoneyValue moneyValueRight)
        {
            return new MoneyValue(number * moneyValueRight.Value, moneyValueRight.Currency);
        }

        public static MoneyValue operator *(Decimal number, MoneyValue moneyValueRight)
        {
            return new MoneyValue(number * moneyValueRight.Value, moneyValueRight.Currency);
        }
    }

    public static class SumExtensions
    {
        public static MoneyValue Sum<T>(this IEnumerable<T> source, Func<T, MoneyValue> selector)
        {
            return MoneyValue.Of(source.Select(selector).Aggregate((x, y) => x + y));
        }

        public static MoneyValue Sum(this IEnumerable<MoneyValue> source)
        {
            return source.Aggregate((x, y) => x + y);
        }
    }
}
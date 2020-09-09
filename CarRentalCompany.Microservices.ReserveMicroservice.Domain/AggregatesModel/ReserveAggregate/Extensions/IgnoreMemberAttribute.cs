using System;

namespace CarRentalCompany.Microservices.ReserveMicroservice.Domain.AggregatesModel.ReserveAggregate.Extensions
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class IgnoreMemberAttribute : Attribute
    {
    }
}
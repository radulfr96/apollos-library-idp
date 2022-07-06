using ApollosLibrary.IDP.Infrastructure.Interfaces;
using NodaTime;
using System;

namespace ApollosLibrary.IDP.Interfaces
{
    public class DateTimeService : IDateTimeService
    {
        public LocalDateTime Now => LocalDateTime.FromDateTime(DateTime.Now);
    }
}

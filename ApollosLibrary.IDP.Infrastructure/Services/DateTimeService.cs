using ApollosLibrary.IDP.Infrastructure.Interfaces;
using System;

namespace ApollosLibrary.IDP.Interfaces
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.Now;
    }
}

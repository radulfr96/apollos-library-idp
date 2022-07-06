﻿using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.Infrastructure.Interfaces
{
    public interface IDateTimeService
    {
        LocalDateTime Now { get; }
    }
}

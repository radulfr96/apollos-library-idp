﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.Application.Exceptions
{
    public class UserCannotSelfBanException : BadRequestException
    {
        public UserCannotSelfBanException(string message) : base(message) { }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace ApollosLibrary.IDP.IntegrationTests
{
    public class TestPrincipal : ClaimsPrincipal
    {
        public TestPrincipal(params Claim[] claims) : base(new TestIdentity(claims))
        {
        }
    }

    public class TestIdentity : ClaimsIdentity
    {
        public TestIdentity(params Claim[] claims) : base(claims)
        {
        }
    }
}

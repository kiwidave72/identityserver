// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Security.Claims;
using IdentityModel;
using identityserver.Data;
using identityserver.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace identityserver
{
    public class SeedData
    {
        public static void AddIdentityTestData(ApplicationDbContext context)
        {
            
            var bob = context.Users.FirstOrDefault(x => x.Email == "BobSmith@test.com");
            if (bob == null)
            {
                bob = new ApplicationUser
                {
                    Id = "c03451a5-8cb7-41be-ba03-55d1da93f0fa",
                    ConcurrencyStamp = "cc949dfd-a905-4657-a075-97a89711a3aa",
                    UserName = "bob",
                    NormalizedUserName = "BOB",
                    Email = "BobSmith@test.com",
                    NormalizedEmail = "BobSmith@test.com".ToUpper(),
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAENay4oPIjFNEJ7/8sjhVw49gvoW//IfBdLK2io3ZvzQgj4YOul4jOfaQVOW3xVFR3g==", // "My long 123$ password"
                    SecurityStamp = "099d224c-8714-416f-bfa9-73034da90045",

                    Claims = new List<IdentityUserClaim<string>>
                    {
                        new IdentityUserClaim<string>
                        {
                            Id=1,  
                            ClaimType = "name",
                            ClaimValue = "Bob Smith"
                        },
                        new IdentityUserClaim<string>
                        {
                            Id=2,
                            ClaimType = "given_name",
                            ClaimValue = "Bob"
                        },
                        new IdentityUserClaim<string>
                        {
                            Id=3,
                            ClaimType = "family_name",
                            ClaimValue = "Smith"
                        },
                        new IdentityUserClaim<string>
                        {
                            Id=4,
                            ClaimType = "email",
                            ClaimValue = "BobSmith@test.com"
                        },
                        new IdentityUserClaim<string>
                        {
                            Id=5,
                            ClaimType = "website",
                            ClaimValue = "http://bob.test.com"
                        },

                        new IdentityUserClaim<string>
                        {
                            Id=6,
                            ClaimType = "email_verified",
                            ClaimValue = true.ToString()
                        },

                        new IdentityUserClaim<string>
                        {
                            Id=7,
                            ClaimType = "address",
                            ClaimValue = @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }"
                        }
                    }
                };
                bob.UserRoles = new List<IdentityUserRole<string>>
                {
                };

                context.Users.Add(bob);
            }


            context.SaveChanges();
        }
    }
}


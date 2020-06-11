using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebApplication2.Models;

namespace WebApplication2.Identity
{
    public class AppUserClaimsIdentityFactory : ClaimsIdentityFactory<AppUser>
    {
            public async Task<ClaimsIdentity> CreateAsync(
                UserManager<AppUser> manager,
                AppUser user,
                string authenticationType)
            {
                var identity = await base.CreateAsync(manager, user, authenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Country, user.Country));

                return identity;
            }

        }
    }
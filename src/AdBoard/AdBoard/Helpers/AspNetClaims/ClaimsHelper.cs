using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AdBoard.Helpers.AspNetClaims
{
    public static class ClaimsHelper
    {
        public static Guid GetUserId(this ClaimsPrincipal user) 
            => Guid.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}

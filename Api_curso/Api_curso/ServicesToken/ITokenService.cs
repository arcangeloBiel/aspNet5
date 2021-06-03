using System.Collections.Generic;
using System.Security.Claims;

namespace Api_curso.ServicesToken {
    public  interface ITokenService {

        string GenerateAccessToken(IEnumerable<Claim> claims);

        string GenerateRefreshToken();

        ClaimsPrincipal GetPrincipalExpiredToken(string token);
    }
}

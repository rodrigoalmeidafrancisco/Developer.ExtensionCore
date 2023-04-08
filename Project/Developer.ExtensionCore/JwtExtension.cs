using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Developer.ExtensionCore
{
    public static class JwtExtension
    {
        public static string GetValue(string token, string claimType)
        {
            string value = string.Empty;

            if (token.IsNullOrEmptyOrWhiteSpace() == false)
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = handler.ReadJwtToken(token);
                Claim claim = jwtToken?.Claims.Where(x => x.Type == claimType || x.Type.Contains(claimType)).FirstOrDefault();
                value = claim?.Value;
            }

            return value;
        }

        public static IEnumerable<string> GetValueList(string token, string claimType)
        {
            List<string> listValues = new List<string>();

            if (token.IsNullOrEmptyOrWhiteSpace() == false)
            {
                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                JwtSecurityToken jwtToken = handler.ReadJwtToken(token);
                List<Claim> listClaim = jwtToken?.Claims.Where(x => x.Type == claimType || x.Type.Contains(claimType)).ToList();

                if (listClaim != null)
                {
                    listClaim.ForEach(item => { listValues.Add(item.Value); });
                }
            }

            return listValues;
        }

    }
}

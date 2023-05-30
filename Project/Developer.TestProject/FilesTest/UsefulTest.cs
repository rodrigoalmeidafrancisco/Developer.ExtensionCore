using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Developer.TestProject.FilesTest
{
    public static class UsefulTest
    {
        public static string GenerateTokenJwtTestUnit()
        {
            JwtSecurityTokenHandler tokenHandler = new();
            byte[] key = Encoding.ASCII.GetBytes("486e2b77-7b50-438f-b11a-9385df06e555");

            ClaimsIdentity claimsIdentity = new();
            claimsIdentity.AddClaim(new Claim("claims/DeveloperExtensionCore/Registration", "123456"));
            claimsIdentity.AddClaim(new Claim("claims/DeveloperExtensionCore/Name", "Nome Teste"));
            claimsIdentity.AddClaim(new Claim("claims/DeveloperExtensionCore/Role", "AAAAA"));
            claimsIdentity.AddClaim(new Claim("claims/DeveloperExtensionCore/Role", "BBBBB"));
            claimsIdentity.AddClaim(new Claim("claims/DeveloperExtensionCore/Role", "CCCCC"));
            claimsIdentity.AddClaim(new Claim("claims/DeveloperExtensionCore/Role", "DDDDD"));
            claimsIdentity.AddClaim(new Claim("claims/DeveloperExtensionCore/Role", "EEEEE"));

            string requireScope = "openid/profile/offline_access/DeveloperExtensionCore";
            string[] requireScopeList = requireScope.Split('/');

            Dictionary<string, object> listaScope = new() { { "scope", requireScopeList } };

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Issuer = "https://www.nuget.org/packages/Developer.ExtensionCore/",
                Audience = "https://www.nuget.org/packages/Developer.ExtensionCore/",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = claimsIdentity,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(60),
                IssuedAt = DateTime.UtcNow,
                Claims = listaScope,
                TokenType = "at+jwt"
            };

            SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(securityToken);
            return token;
        }

    }
}

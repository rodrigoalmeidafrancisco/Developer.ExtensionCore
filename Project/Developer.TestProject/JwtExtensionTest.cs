using Developer.ExtensionCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

namespace Developer.TestProject
{
  [TestClass]
    public class JwtExtensionTest
    {
 private readonly string _issuer = "https://www.nuget.org/packages/Developer.ExtensionCore/";
        private readonly string _audience = "https://www.nuget.org/packages/Developer.ExtensionCore/";
     private readonly Dictionary<string, object> _claims;
 private readonly string _tokenType = "at+jwt";
        private readonly string _requireScope = "openid/profile/offline_access/DeveloperExtensionCore";
 private readonly SigningCredentials _signingCredentials;
private readonly ClaimsIdentity _claimsIdentity;

     public JwtExtensionTest()
{
_claims = new Dictionary<string, object>() { { "scope", _requireScope.Split('/') } };

 byte[] key = Encoding.ASCII.GetBytes("486e2b77-7b50-438f-b11a-9385df06e555");
  _signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            _claimsIdentity = new();
       _claimsIdentity.AddClaim(new Claim("claims/DeveloperExtensionCore/Registration", "123456"));
 _claimsIdentity.AddClaim(new Claim("claims/DeveloperExtensionCore/Name", "Nome Teste"));
   _claimsIdentity.AddClaim(new Claim("claims/DeveloperExtensionCore/Role", "AAAAA"));
 _claimsIdentity.AddClaim(new Claim("claims/DeveloperExtensionCore/Role", "BBBBB"));
  _claimsIdentity.AddClaim(new Claim("claims/DeveloperExtensionCore/Role", "CCCCC"));
       _claimsIdentity.AddClaim(new Claim("claims/DeveloperExtensionCore/Role", "DDDDD"));
       _claimsIdentity.AddClaim(new Claim("claims/DeveloperExtensionCore/Role", "EEEEE"));
 }

 [TestMethod]
   public void Test_CreateTokenJWT()
 {
     var token = JwtExtension.CreateTokenJWT(null, null, _audience, _claims, null, null, 60, _issuer, _signingCredentials, _claimsIdentity, _tokenType);
  token.Should().NotBeNullOrWhiteSpace();
     }

        [TestMethod]
public void Test_GetValueToken()
        {
 string token = JwtExtension.CreateTokenJWT(null, null, _audience, _claims, null, null, 60, _issuer, _signingCredentials, _claimsIdentity, _tokenType);
      token.Should().NotBeNullOrWhiteSpace();

   token.GetValueToken("claims/DeveloperExtensionCore/Registration").Should().Be("123456");
      token.GetValueToken("Registration").Should().Be("123456");
   }

     [TestMethod]
   public void Test_GetListValueToken()
        {
   string token = JwtExtension.CreateTokenJWT(null, null, _audience, _claims, null, null, 60, _issuer, _signingCredentials, _claimsIdentity, _tokenType);
       token.Should().NotBeNullOrWhiteSpace();

  var listValToken = token.GetListValueToken("claims/DeveloperExtensionCore/Role");
  listValToken.Should().NotBeEmpty();
      listValToken.Should().HaveCount(5);

     listValToken = token.GetListValueToken("Role");
   listValToken.Should().NotBeEmpty();
  listValToken.Should().HaveCount(5);
  }
    }
}

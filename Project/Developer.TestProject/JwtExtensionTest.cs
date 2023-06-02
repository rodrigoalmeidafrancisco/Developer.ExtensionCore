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
            Assert.IsTrue(token.IsNullOrEmptyOrWhiteSpace() == false);
        }

        [TestMethod]
        public void Test_GetValueToken()
        {
            string token = JwtExtension.CreateTokenJWT(null, null, _audience, _claims, null, null, 60, _issuer, _signingCredentials, _claimsIdentity, _tokenType);
            Assert.IsTrue(token.IsNullOrEmptyOrWhiteSpace() == false);

            var valToken = token.GetValueToken("claims/DeveloperExtensionCore/Registration");
            Assert.AreEqual("123456", valToken);

            var teste2 = token.GetValueToken("Registration");
            Assert.AreEqual("123456", valToken);
        }

        [TestMethod]
        public void Test_GetListValueToken()
        {
            string token = JwtExtension.CreateTokenJWT(null, null, _audience, _claims, null, null, 60, _issuer, _signingCredentials, _claimsIdentity, _tokenType);
            Assert.IsTrue(token.IsNullOrEmptyOrWhiteSpace() == false);

            var listValToken = token.GetListValueToken("claims/DeveloperExtensionCore/Role");
            Assert.IsTrue(listValToken.Any());

            listValToken = token.GetListValueToken("Role");
            Assert.IsTrue(listValToken.Any());
        }


    }
}

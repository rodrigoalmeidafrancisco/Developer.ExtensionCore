using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Developer.ExtensionCore
{
    public static class JwtExtension
    {
        /// <summary>
        /// Cria um token de acesso, baseado nas informações fornecidas.
        /// Caso ocorra erro na geração do token, retorna null.
        /// </summary>
        /// <param name="additionalHeaderClaims"></param>
        /// <param name="additionalInnerHeaderClaims"></param>
        /// <param name="audience"></param>
        /// <param name="claims"></param>
        /// <param name="compressionAlgorithm"></param>
        /// <param name="encryptingCredentials"></param>
        /// <param name="minutesExpires"></param>
        /// <param name="issuer"></param>
        /// <param name="signingCredentials"></param>
        /// <param name="claimsIdentity"></param>
        /// <param name="tokenType"></param>
        /// <returns></returns>
        public static string CreateTokenJWT(Dictionary<string, object> additionalHeaderClaims, Dictionary<string, object> additionalInnerHeaderClaims,
            string audience, Dictionary<string, object> claims, string compressionAlgorithm, EncryptingCredentials encryptingCredentials, int minutesExpires,
            string issuer, SigningCredentials signingCredentials, ClaimsIdentity claimsIdentity, string tokenType)
        {
            try
            {
                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
                {
                    AdditionalHeaderClaims = additionalHeaderClaims,
                    AdditionalInnerHeaderClaims = additionalInnerHeaderClaims,
                    Audience = audience,
                    Claims = claims,
                    CompressionAlgorithm = compressionAlgorithm,
                    EncryptingCredentials = encryptingCredentials,
                    Expires = DateTime.UtcNow.AddMinutes(minutesExpires),
                    IssuedAt = DateTime.UtcNow,
                    Issuer = issuer,
                    NotBefore = DateTime.UtcNow,
                    SigningCredentials = signingCredentials,
                    Subject = claimsIdentity,
                    TokenType = tokenType
                };

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken securityToken = tokenHandler.CreateToken(tokenDescriptor);
                string token = tokenHandler.WriteToken(securityToken);
                return token;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Obtém apenas 1 (um) valor correspondente a claimType solicitada.
        /// Caso ocorra erro ao obter, retorna uma null.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public static string GetValueToken(this string token, string claimType)
        {
            try
            {
                string value = string.Empty;

                if (token.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    JwtSecurityToken jwtToken = handler.ReadJwtToken(token);

                    if (jwtToken != null)
                    {
                        Claim claim = jwtToken.Claims.Where(x => x.Type.ToUpper() == claimType.ToUpper() ||
                                                                 x.Type.ToUpper().Contains(claimType.ToUpper())).FirstOrDefault();
                        value = claim?.Value;
                    }
                }

                return value;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Obtém uma lista de claims correspondente a claimType solicitada.
        /// Caso ocorra erro ao obter, retorna uma null.
        /// </summary>
        /// <param name="token"></param>
        /// <param name="claimType"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetListValueToken(this string token, string claimType)
        {
            try
            {
                List<string> listValues = new List<string>();

                if (token.IsNullOrEmptyOrWhiteSpace() == false)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    JwtSecurityToken jwtToken = handler.ReadJwtToken(token);

                    if (jwtToken != null)
                    {
                        List<Claim> listClaim = jwtToken.Claims.Where(x => x.Type.ToUpper() == claimType.ToUpper() ||
                                                                           x.Type.ToUpper().Contains(claimType.ToUpper())).ToList();
                        
                        listClaim?.ForEach(item => { listValues.Add(item.Value); });
                    }
                }

                return listValues;
            }
            catch
            {
                return null;
            }
        }

    }
}

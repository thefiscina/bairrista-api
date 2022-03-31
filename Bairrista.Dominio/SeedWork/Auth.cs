using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bairrista.Dominio.SeedWork
{
    public class Auth
    {
        public static string GerarToken(string uuidUsuario, string tokenUsuario, string secret, int secondsToExpire, string issuer)
        {
            try
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(uuidUsuario, "token"),
                    new[] {
                        new Claim("token", tokenUsuario)
                    });

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Issuer = issuer,
                    Subject = identity,
                    Expires = DateTime.UtcNow.AddSeconds(secondsToExpire),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                    IssuedAt = DateTime.Now,
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return tokenString;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void CriarSenhaHash(string password)
        {
            if (password == null)
                throw new Exception("");
            if (string.IsNullOrWhiteSpace(password))
                throw new Exception("");           
        }

        public static bool VerificarSenhaHash(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("Informe uma Senha");               
            return true;
        }

        public static string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }
    }
}
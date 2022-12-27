using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Colpatria.SOAT.Api.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Muestra una pantalla de inicio
        /// </summary>
        /// <returns></returns>
        public string Index()
        {
            return "Bienvenido";
        }
        /// <summary>
        /// Test de ingreso con token basico
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public string Secret()
        {
            return "Ingreso Autorizado";
        }

        /// <summary>
        /// Genera el token que permite el ingreso
        /// </summary>
        /// <returns></returns>
        public IActionResult Authenticate()
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "some_id"),
                new Claim("granny", "cookie")
            };

            var secretBytes = Encoding.UTF8.GetBytes(Constants.Secret);
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                Constants.Issuer,
                Constants.Audiance,
                claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddHours(1),
                signingCredentials);

            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new { access_token = tokenJson });
        }
        /// <summary>
        /// Decodifica base64 en bytes
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public IActionResult Decode(string part)
        {
            var bytes = Convert.FromBase64String(part);
            return Ok(Encoding.UTF8.GetString(bytes));
        }
    }
}
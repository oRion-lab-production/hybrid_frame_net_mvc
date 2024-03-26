using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Abstraction.GenericModels.Components;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace WebApp.Controllers
{
    public abstract class ControllerBase : Controller
    {
        protected ILogger<object> _logger;

        public ControllerBase(ILogger<object> logger)
        {
            this._logger = logger;
        }

        public string GetTokenFromCookies() => Request.Cookies["Token"];

        public bool IsTokenExpired()
        {
            var token = GetTokenFromCookies();

            if(token == null) { return true; }

            var handler = new JwtSecurityTokenHandler();
            var decodedValueExp = handler.ReadJwtToken(token).Claims.FirstOrDefault(claim => claim.Type.Equals("exp"))?.Value;

            if (decodedValueExp == null) { return true; }

            if (DateTime.Now.ToUniversalTime() > DateTimeOffset.FromUnixTimeSeconds(long.Parse(decodedValueExp)).UtcDateTime) { return true; }

            return false;
        }
    }
}

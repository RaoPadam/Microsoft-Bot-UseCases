using Microsoft.Extensions.Configuration;
using AzureGraphAuthApp.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AzureGraphAuthApp.Controllers
{
    public class AuthController : Controller
    {
        public AuthCodeFlowController Oauth { get; }

        public AuthController(AuthCodeFlowController oauth)
        {
            Oauth = oauth;
        }

        [HttpGet("userconsentredirect")]
        public async Task<ContentResult> GetUserConsent(string code, string state)
        {
            await Oauth.UserConsented(code, state);
            return Content("Thanks for providing user consent, you may now close this window.");
        }
    }
}

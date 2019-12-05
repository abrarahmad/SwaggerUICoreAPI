using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SwaggerUI.API.Authentication
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private const string _userName = "abrar";
        private const string _userPwd = "abrar@123";
        public BasicAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder url, ISystemClock clock)
            : base(options, logger, url, clock)
        {

        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return await Task.FromResult(AuthenticateResult.Fail("Missing Authorization Header"));
            }
            try
            {
                var authenticationHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialByte = Convert.FromBase64String(authenticationHeader.Parameter);
                var credential = Encoding.UTF8.GetString(credentialByte).Split(":");
                var userName = credential[0];
                var password = credential[1];
                if (userName == _userName && password == _userPwd)
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier,userName)
                    };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return await Task.FromResult(AuthenticateResult.Success(ticket));
                }
                return await Task.FromResult(AuthenticateResult.Fail("Invalid username and password"));
            }
            catch (System.Exception ex)
            {

                return await Task.FromResult(AuthenticateResult.Fail("Invalide Authorization header more infor refer exception:" + ex.Message));
            }
        }

    }
}
#pragma warning restore CS1591

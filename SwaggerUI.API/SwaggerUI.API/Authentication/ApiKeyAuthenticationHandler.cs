using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SwaggerUI.API.Authentication
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {

        private const string _apiKeyHeaderName = "X-Api-Key";
        private const string _secretKey = "abrar";
        public ApiKeyAuthenticationHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
         ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock
        ) : base(options, logger, encoder, clock)
        {

        }


        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(_apiKeyHeaderName, out var apiKeyHeaderValues))
            {
                return AuthenticateResult.NoResult();
            }
            try
            {
                var providedApiKey = apiKeyHeaderValues.FirstOrDefault();

                if (apiKeyHeaderValues.Count == 0 || string.IsNullOrWhiteSpace(providedApiKey))
                {
                    return AuthenticateResult.NoResult();
                }

                if (providedApiKey == _secretKey)
                {
                    var claims = new[]
                         {
                            new Claim(ClaimTypes.NameIdentifier,providedApiKey)
                         };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);
                    return await Task.FromResult(AuthenticateResult.Success(ticket));

                }
                return await Task.FromResult(AuthenticateResult.Fail("Invalid Key"));
            }
            catch (System.Exception ex)
            {

                return await Task.FromResult(AuthenticateResult.Fail("Invalid Key refer exception:" + ex.Message));
            }
        }
    }
}
#pragma warning restore CS1591
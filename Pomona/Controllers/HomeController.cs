using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Pomona.Controllers.Repurchase;

namespace Pomona.Controllers
{
    public class HomeController : Controller
    {
        string Username { get; set; }
        string Password { get; set; }
        string LiscenceID { get; set; }
        private Dictionary<string, int> loggedSessions
        {
            get
            {
                return (Session.AppContext.MemoryCache.Get("loggedSessions_") == null)
                    ? null : (Dictionary<string, int>)(Session.AppContext.MemoryCache.Get("loggedSessions_"));
            }
            set
            {
                Session.AppContext.MemoryCache.Set("loggedSessions_", value);
            }
        }

        public HomeController(IConfiguration config)
        {
            Username = config.GetValue<string>("ExchangeRateUserName");
            Password = config.GetValue<string>("ExchangeRatePassword");
            LiscenceID = config.GetValue<string>("ExchangeRateLiscenseID");
            GetExchange();
        }
        public async Task GetExchange()
        {
            CurrentExchangeRate.CurrentExchangeRateServiceSoapClient client =
             new CurrentExchangeRate.CurrentExchangeRateServiceSoapClient(CurrentExchangeRate.CurrentExchangeRateServiceSoapClient.EndpointConfiguration.CurrentExchangeRateServiceSoap);
            CurrentExchangeRate.AuthenticationHeader authenticationHeader = new CurrentExchangeRate.AuthenticationHeader();

            authenticationHeader.UserName = Username;
            authenticationHeader.Password = Password;
            authenticationHeader.LicenceID = Guid.Parse(LiscenceID);

            CurrentExchangeRate.GetCurrentExchangeRateByRateTypeResponse response =
                await client.GetCurrentExchangeRateByRateTypeAsync(authenticationHeader, 978, 2, 2).ConfigureAwait(false);

            CurrentExchangeRate.GetCurrentExchangeRateByRateTypeResponse responseProd =
               await client.GetCurrentExchangeRateByRateTypeAsync(authenticationHeader, 978, 1, 3).ConfigureAwait(false);

            RepurchaseController.SrednjiKurs = response.GetCurrentExchangeRateByRateTypeResult;
            RepurchaseController.ProdajniKurs = responseProd.GetCurrentExchangeRateByRateTypeResult;
        }

        public IActionResult EmptyView()
        {
            return View();
        }

        public IActionResult Index(string autentification, int token)
        {
            if (loggedSessions == null)
            {
                loggedSessions = new Dictionary<string, int>();
            }
            try
            {
                //ako uradi refresh ili copy paste
                if (loggedSessions.Keys.Contains(autentification))
                {
                    HttpContext.Response.Redirect($"/Pomona/Login/Login");
                }
                //ako je ne daj boze menjao url
                else if (!IsGuid(autentification))
                {
                    HttpContext.Response.Redirect($"/Pomona/Login/Login");
                }
                else
                {
                    Session.AppContext.UserID = token;
                    loggedSessions.Add(autentification, token);
                }

                return View();
            }
            catch (Exception)
            {
                throw;
            }

        }

        public bool IsGuid(string value)
        {
            Guid x;
            return Guid.TryParse(value, out x);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}

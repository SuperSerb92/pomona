using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pomona.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Controllers.Repurchase
{
    public class RepurchaseController:Controller
    {
        private readonly IRepurchaseService service;
        private readonly IBarCodeGeneratorService barCodeGeneratorService;
        IConfiguration config;
        string Username { get; }
        string Password { get; }
        string LiscenceID { get; }
       public static decimal SrednjiKurs { get; set; }
       public static decimal ProdajniKurs { get; set; }
       
       
        private static List<Models.Repurchase> repurchases
        {
            get; set;
        }
        private static List<Pomona.Models.BarCodeGenerator> barcodes
        {
            get; set;
        }
        public RepurchaseController(IRepurchaseService service, IBarCodeGeneratorService barCodeGeneratorService, IConfiguration config)
        {
            this.barCodeGeneratorService = barCodeGeneratorService;
            this.service = service;
            this.config = config;
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

            SrednjiKurs = response.GetCurrentExchangeRateByRateTypeResult;
            ProdajniKurs = responseProd.GetCurrentExchangeRateByRateTypeResult;
        }
        public IActionResult Repurchase()
        {
            repurchases = service.GetRepurchases();

            return View();
        }

        [HttpGet]
        public object GetRepurchases(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(repurchases, loadOptions);
        }

        [HttpGet]
        public object GetRepurchasesStaticList(DataSourceLoadOptions loadOptions)
        {
            repurchases = service.GetRepurchases();

            return DataSourceLoader.Load(repurchases, loadOptions);
        }

        [HttpPost]
        public IActionResult InsertRepurchase(string values)
        {
            var rep = new Models.Repurchase();
            JsonConvert.PopulateObject(values, rep);
            if (rep.Price==0 || rep.NetoShipped==0)
            {
                rep.Income = 0;
            }
            else
            {
                rep.Income = rep.Price * rep.NetoShipped;
            }        
     
            rep.IncomeEur = rep.PriceEur * rep.NetoShipped;
            rep.Difference = rep.NetoShipped - rep.Neto;
            rep.Date = rep.Date.Date;

            int brKutija = 0;
        
            var repu = repurchases.Sum(x=> x.NoOfBoxes);

            barcodes = barCodeGeneratorService.GetBarCodeActive().Where(x => x.DateGenerated.Date == rep.Date).ToList();

            brKutija = barcodes.Count();

            if (repu > brKutija)
            {
               // return 
            }

            service.AddRepurchase(rep);
            service.SaveChanges();
            RefreshSources();

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateRepurchase(int key, string values)
        {
            var rep = repurchases.FirstOrDefault(a => a.Id == key);
            if (rep != null)
            {
                JsonConvert.PopulateObject(values, rep);
                if (rep.Price == 0 || rep.NetoShipped == 0)
                {
                    rep.Income = 0;
                }
                else
                {
                    rep.Income = rep.Price * rep.NetoShipped;
                }
                rep.Difference = rep.NetoShipped - rep.Neto;

                service.UpdateRepurchase(rep);
                service.SaveChanges();
            }

            RefreshSources();

            return Ok();
        }

        [HttpDelete]
        public void DeleteRepurchase(int key)
        {
            var rep = repurchases.FirstOrDefault(a => a.Id == key);
            if (rep != null)
            {
                service.DeleteRepurchase(rep);
                repurchases.Remove(rep);
                service.SaveChanges();
            }
        }



        private void RefreshSources()
        {
            repurchases = service.GetRepurchases();
        }

        [HttpGet]
        public object GetNeto(int key,DateTime date)
        {
            decimal neto = 0;
            decimal netoRep = 0;
            var rep = repurchases.Where(x => x.CultureId == key && x.Date.Date == date.Date).ToList();
          
            barcodes = barCodeGeneratorService.GetBarCodeActive().Where(x=> x.CultureId==key && x.DateGenerated.Date==date.Date).ToList();
            if (barcodes.Count >0)
            {
                 neto = barcodes.Sum(x=>x.Neto);
                if (rep.Count() > 0)
                {
                    netoRep = rep.Sum(a => a.NetoShipped);
                }
                neto -= netoRep;
            }
            else
            {
                return Json(new { success = false, result = "Ne postoji težina za odabrani datum i vrstu voća" });
            }

            return Json(new { success = true, result = Math.Round(neto,2) });
            // return Ok();

        }

        [HttpGet]
        public object GetNoOfBoxes(int key, DateTime date)
        {
            int brKutija = 0;
            int brojKutijaRep = 0;
            var rep = repurchases.Where(x => x.CultureId == key && x.Date.Date == date.Date).ToList();

            barcodes = barCodeGeneratorService.GetBarCodeActive().Where(x => x.CultureId == key && x.DateGenerated.Date == date.Date).ToList();
            if (barcodes.Count > 0)
            {
                brKutija = barcodes.Count();
                if (rep.Count() > 0)
                {
                    brojKutijaRep = rep.Sum(x=>x.NoOfBoxes);
                }
                brKutija -= brojKutijaRep;
            }
            else
            {
                return Json(new { success = false, result = "Nema kutija za odabrani datum i vrstu voća" });
            }

            return Json(new { success = true, result = brKutija });
            // return Ok();

        }

        [HttpGet]
        public object GetPriceEur(string key, decimal price)
        {
           
            if (key == "Srednji kurs")
                {
                  
                return Json(new { success = true, result = Math.Round(SrednjiKurs, 2) });
                }
                else
                {
                
                return Json(new { success = true, result = Math.Round(ProdajniKurs, 2) });
                 }
               
              
         
         
        }
           
    }
}

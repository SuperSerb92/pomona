using DevExpress.XtraPrinting;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Pomona.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Controllers.BarCodeMenu
{
   // [Route("api/[controller]/[action]")]
    public class BarCodeMenuController : Controller
    {
        private readonly IBarCodeGeneratorService service;
        private readonly IPackagingService packagingService;
        private readonly ICultureTypeService cultureTypeService;
        private readonly IPlotService plotService;
        private readonly IEmployeesService employeesService;
        private readonly ILoginService loginService;
        private readonly IConfiguration _config;
        private readonly IControlorEmployeesService controlorEmployeesService;
        string printerName;
        bool hasPrinter;
        private static List<Pomona.Models.BarCodeGenerator> barcodes
        {
            get; set;
        }
        private static List<Pomona.Models.BarCodeGenerator> barcodesTotal
        {
            get; set;
        }
        private static List<Pomona.Models.Packaging> packagings
        {
            get; set;
        }
        private static List<Pomona.Models.CultureType> CultureTypes
        {
            get; set;
        }
        private static List<Pomona.Models.Plot> plots
        {
            get; set;
        }
        private static List<Pomona.Models.Employee> employees
        {
            get; set;
        }
        private static List<Pomona.Models.User> users
        {
            get; set;
        }
        private static List<Pomona.Models.ControlorEmployeesRelation> controlorEmployees
        {
            get; set;
        }
        public BarCodeMenuController(IBarCodeGeneratorService service, IPackagingService packagingService, ICultureTypeService cultureTypeService,IPlotService plotService,IEmployeesService employeesService, IConfiguration config,ILoginService loginService,IControlorEmployeesService controlorEmployeesService)
        {
            this.service = service;
            this.packagingService = packagingService;
            this.cultureTypeService = cultureTypeService;
            this.plotService = plotService;
            this.employeesService = employeesService;
            this.loginService = loginService;
            this.controlorEmployeesService = controlorEmployeesService;
            _config = config;
            printerName = _config.GetValue<string>("Logging:PrinterName");
            hasPrinter = _config.GetValue<bool>("Logging:HasPrinter");
        }
        public IActionResult BarCodeGenerator()
        {
            //ba = db.Employees.ToList();
            return View();
        }
        public IActionResult BarCodeMenu()
        {
            barcodesTotal = service.GetBarCode();
            barcodes = service.GetBarCode().Where(x=> x.DateGenerated>=DateTime.Now.AddDays(-4)).OrderByDescending(a => a.MaxRbr).ToList();
            packagings = packagingService.GetPackagings();
            CultureTypes = cultureTypeService.GetCultureTypes();
            plots = plotService.GetPlots();
            employees = employeesService.GetEmployees();
            users = loginService.GetUsers();
            controlorEmployees = controlorEmployeesService.GetControlorEmployeeRelations();
            //ba = db.Employees.ToList();
            return View();
        }
        [HttpGet]
        public object GetBarCodes(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(barcodes, loadOptions);
        }


        [HttpPost]
        public IActionResult InsertBarcode(string values)
        {

            var barCode = new Models.BarCodeGenerator();
            //var plot = new Models.Plot();
                        
            JsonConvert.PopulateObject(values, barCode);
          
            var RbrBarcode = barcodes.Where(x => x.EmployeeID == barCode.EmployeeID && x.DateGenerated.Date == barCode.DateGenerated.Date)
                .OrderByDescending(a=>a.Rbr)
                .FirstOrDefault();
            for (int i = 0; i < barCode.NoOfPrint; i++)
            {
               // barCode
                if (RbrBarcode == null)
                {
                    barCode.Rbr++;  //rbr dobija svaki radnik zasebno na taj dan  
                }
                else
                {
                    barCode.Rbr = RbrBarcode.Rbr + 1;
                }
                if (barCode.PlotId == null)
                {
                    barCode.PlotId = 0;
                }
                barCode.BarCode = barCode.EmployeeID.ToString() + barCode.DateGenerated.Day.ToString() + barCode.DateGenerated.Month.ToString()
                    + barCode.DateGenerated.Year.ToString().Substring(2, 2) + barCode.Rbr + barCode.PlotListId.ToString() + barCode.PlotId.ToString()
                    + barCode.CultureId.ToString() + barCode.CultureTypeId.ToString();
                var pack = packagings.Where(a => a.PackagingId == barCode.PackagingId).ToList();
                var employee = employees.Where(a => a.EmployeeID == barCode.EmployeeID).ToList();
                barCode.Tara = pack[0].Tara;
                var cultureType = CultureTypes.Where(a => a.CultureTypeId == barCode.CultureTypeId).ToList();
                var user = users.Where(a => a.UserID == barCode.UserID).ToList();
                if (barCode.MaxRbr==0)
                {
                    barCode.MaxRbr = barcodesTotal.Max(x => x.MaxRbr) + 1;
                }
                else
                {
                    barCode.MaxRbr++;
                }
                barCode.RbrRead = 0;
                //Stampa barkoda
                Views.BarCodeMenu.BarcodeReport report = new Views.BarCodeMenu.BarcodeReport();
                report.barCode1.Text = barCode.BarCode;
                report.Radnik.Value = employee[0].Name + " " + employee[0].MiddleName + " " + employee[0].Surname;
                report.Lotcode.Value = barCode.DateGenerated.Day.ToString() + barCode.DateGenerated.Month.ToString() + barCode.DateGenerated.Year.ToString();
                report.Variety.Value = cultureType[0].CultureTypeName;
                report.Supervisor.Value = user[0].NameSurname;
                report.CreateDocument();
                if (hasPrinter == true)
                {
                    // PrintToolBase tool = new PrintToolBase(report.PrintingSystem);
                    //tool.Print();
                    report.Print(printerName);
                }
                barCode.IndPrint = 1;
                service.AddBarCode(barCode);
                service.SaveChanges();
                // service.SaveChanges();
            }

            RefreshSources();

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateBarcode(string key, string values)
        {
            var barc = barcodes.FirstOrDefault(a => a.BarCode == key);
            if (barc != null)
            {
                JsonConvert.PopulateObject(values, barc);              
                service.UpdateBarCode(barc);
                service.SaveChanges();
            }

            RefreshSources();

            return Ok();
        }

        [HttpDelete]
        public void DeleteBarcode(string key)
        {
            var barc = barcodes.FirstOrDefault(a => a.BarCode == key);
            if (barc != null)
            {
                barc.Status = 1;
                service.UpdateBarCode(barc);              
                service.SaveChanges();
            }

            RefreshSources();

            
        }
        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            
            return DataSourceLoader.Load(CultureTypes, loadOptions);
        }
        [HttpGet]
        public object GetPl(DataSourceLoadOptions loadOptions)
        {

            return DataSourceLoader.Load(plots, loadOptions);
        }
        private void RefreshSources()
        {
            barcodes = service.GetBarCode().Where(x => x.DateGenerated >= DateTime.Now.AddDays(-4)).OrderByDescending(a => a.MaxRbr).ToList();
        }

        [HttpPost]
        public JsonResult Print(string Barcode)
        {
            try
            {
                var Bar = barcodes.FirstOrDefault(a => a.BarCode == Barcode);
                if (Bar != null)
                {
                    if (Bar.IndPrint == 1)
                    {
                        return Json(new { success = false, result = "Barkod je već odštampan." });
                    }
                    if (Bar.Status == 1)
                    {
                        return Json(new { success = false, result = "Barkod je neaktivan." });
                    }
                    else
                    {
                        Views.BarCodeMenu.BarcodeReport report = new Views.BarCodeMenu.BarcodeReport();
                        report.barCode1.Text = Barcode;
                        report.CreateDocument();
                        PrintToolBase tool = new PrintToolBase(report.PrintingSystem);
                        tool.Print();
                        Bar.IndPrint = 1;
                        service.UpdateBarCode(Bar);
                        service.SaveChanges();
                        RefreshSources();
                        return Json(new { success = true });
                    }
                }
                else
                {
                    return Json(new { success = false, result = "Barkod nije pronađen." });
                }
               
               
            }
            catch (Exception ex)
            {

                return Json(new { success = false, result = ex.Message });
            }
            
        }

        [HttpPost]
        public JsonResult ProveraAktivnosti(string Barcode)
        {
            var Bar = barcodes.Where(x => x.BarCode == Barcode).ToList();
            if (Bar != null)
            {

                if (Bar[0].Status == 1)
                {
                    return Json(new { success = false, result = "Barkod je neaktivan." });
                }
                else
                {
                    return Json(new { success = true });
                }

            }
            else
            {
                return Json(new { success = false, result = "Barkod nije pronađen." });
            }
        }

        [HttpGet]
        public JsonResult GetSuperVisor(int key)
        {
            try
            {
                var userid = controlorEmployees.Where(x => x.EmployeeID == key).ToList();
                if (userid.Count()>0)
                {
                    return Json(new { success = true, result = userid[0].UserID });
                }
                else
                {
                    return Json(new { success = true, result = 0 });
                }
                      
                 


            }
            catch (Exception ex)
            {

                return Json(new { success = false, result = ex.Message });
            }

        }


    }
}

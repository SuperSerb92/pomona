using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pomona.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Controllers.WorkEvaluation
{
    public class WorkEvaluationController : Controller
    {
        private readonly IWorkEvaluationService service;
        private static List<Models.WorkEvaluation> workEvaluations
        {
            get; set;
        }

  
        public WorkEvaluationController(IWorkEvaluationService service)
        {
          
            this.service = service;
        }
        public IActionResult WorkEvaluation()
        {
            
            workEvaluations = service.GetWorkEvaluations();
            return View();
        }
        [HttpGet]
        public object GetWorkEvaluations(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(workEvaluations, loadOptions);
        }
        [HttpPut]
        public IActionResult UpdateEvaluation(int key, string values)
        {
            var eval = workEvaluations.FirstOrDefault(a => a.Id == key);
            if (eval != null)
            {
                JsonConvert.PopulateObject(values, eval);
                if (eval.PayPerDay>0 && eval.ExpenseKg==0)
                {
                    eval.Total = eval.PayPerDay;
                }
                if (eval.ExpenseKg>0 && eval.PayPerDay==0)
                {
                    eval.Total = Math.Round((eval.Neto * eval.ExpenseKg),0) ;
                }
                if (eval.ExpenseKg == 0 && eval.PayPerDay == 0)
                {
                    eval.Total = 0;
                }
                //if (eval.ExpenseKg < 0 || eval.PayPerDay < 0)
                //{
                //    return Ok();
                //}
                service.UpdateWorkEval(eval);
                service.SaveChanges();
            }

            RefreshSources();

            return Ok();
        }

        private void RefreshSources()
        {
            workEvaluations = service.GetWorkEvaluations();
        }
        [HttpGet]
        public object Get(string date)
        {
            var ev = workEvaluations.Where(x => x.Date.Date ==Convert.ToDateTime(date).Date).ToList();
            return ev;
        }
    }
}

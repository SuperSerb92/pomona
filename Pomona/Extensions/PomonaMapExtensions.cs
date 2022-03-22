using AutoMapper;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Extensions
{
    public class PomonaMapProfile : Profile
    {
       
        public PomonaMapProfile( )
        {

            ConfigureMappings();
        }

        /// <summary>
        /// Creates a mapping between source (Domain) and destination (ViewModel)
        /// </summary>
        private void ConfigureMappings()
        {
            CreateMap<Employee, Pomona.Models.Employee>();
            CreateMap<User, Pomona.Models.User>();
            CreateMap<Buyer, Pomona.Models.Buyer>();
            CreateMap<Group, Pomona.Models.Group>();
            CreateMap<ControlorEmployeesRelation, Pomona.Models.ControlorEmployeesRelation>();
            CreateMap<BarCodeGenerator, Pomona.Models.BarCodeGenerator>();
            CreateMap<Plot, Pomona.Models.Plot>();
            CreateMap<PlotList, Pomona.Models.PlotList>();
            CreateMap<Packaging, Pomona.Models.Packaging>();
            CreateMap<Culture, Pomona.Models.Culture>();
            CreateMap<CultureType, Pomona.Models.CultureType>();
            CreateMap<WorkEvaluation, Pomona.Models.WorkEvaluation>();
            CreateMap<SummaryReport, Pomona.Models.SummaryReport>();
            CreateMap<Repurchase, Pomona.Models.Repurchase>();
            CreateMap<ProfitLossReport, Pomona.Models.ProfitLossReport>();
            CreateMap<SummaryReportRepurchase, Pomona.Models.SummaryReportRepurchase>();

            CreateMap<Pomona.Models.Employee,Employee> ();
            CreateMap<Pomona.Models.Group, Group>();
            CreateMap<Pomona.Models.User,User> ();
            CreateMap<Pomona.Models.Plot, Plot>();
            CreateMap<Pomona.Models.Buyer,Buyer>();
            CreateMap<Pomona.Models.Packaging, Packaging>();
            CreateMap<Pomona.Models.ControlorEmployeesRelation, ControlorEmployeesRelation>();
            CreateMap<Pomona.Models.Culture, Culture>();
            CreateMap<Pomona.Models.CultureType, CultureType>();
            CreateMap<Pomona.Models.BarCodeGenerator, BarCodeGenerator>();
            CreateMap<Pomona.Models.WorkEvaluation, WorkEvaluation>();
            CreateMap<Pomona.Models.SummaryReport, SummaryReport>();
            CreateMap<Pomona.Models.Repurchase, Repurchase>();
            CreateMap<Pomona.Models.ProfitLossReport, ProfitLossReport>();
            CreateMap<Pomona.Models.SummaryReportRepurchase, SummaryReportRepurchase>();
        }
    }
   
}

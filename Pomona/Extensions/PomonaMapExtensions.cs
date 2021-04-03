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
            CreateMap<Packaging, Pomona.Models.Packaging>();
            CreateMap<Culture, Pomona.Models.Culture>();
            CreateMap<CultureType, Pomona.Models.CultureType>();

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
        }
    }
   
}

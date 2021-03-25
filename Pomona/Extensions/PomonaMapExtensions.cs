using AutoMapper;
using DBModel.DataAccess;
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

            CreateMap<Employee, Pomona.Models.Employee>()
             .ForMember(d => d.EmployeeID, o => o.Ignore());

            CreateMap<User, Pomona.Models.User>()
             .ForMember(d => d.UserID, o => o.Ignore());
        }
        //metoda daj mi employee model za view model 
        //public  List<Pomona.Models.Employee> ToEmployeeDto(this List<DBModel.Models.Employee> employees)
        //{
        //    var records = new List<Pomona.Models.Employee>();

        //    foreach (var employee in employees)
        //    {
        //        var record = _mapper.Map<Models.Employee>(employee);

        //        records.Add(record);
        //    }

        //    return records;
        //}
        // za konkretnog  db employee daj mi pomona model konverzija
    }
    public  class ObjectCustomMappings
    {
         private  readonly IMapper _mapper;
        public ObjectCustomMappings(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<Pomona.Models.Employee> ToEmployeeDto( List<DBModel.Models.Employee> employees)
        {
            var records = new List<Pomona.Models.Employee>();

            foreach (var employee in employees)
            {
                var record = _mapper.Map<Models.Employee>(employee);

                records.Add(record);
            }

            return records;
        }


    }
}

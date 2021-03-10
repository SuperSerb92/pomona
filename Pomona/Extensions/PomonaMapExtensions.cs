using AutoMapper;
using DBModel.DataAccess;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Extensions
{
    public class PomonaMapProfile : Profile, IProfile
    {
        public PomonaMapProfile()
        {
            CreateMap<Employee, Pomona.Models.Employee>()
             .ForMember(d => d.EmployeeID, o => o.Ignore());

            CreateMap<User, Pomona.Models.User>()
             .ForMember(d => d.UserID, o => o.Ignore());
        }
    }
}

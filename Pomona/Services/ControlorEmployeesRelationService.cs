using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DBModel.Interfaces;
using Pomona.Interfaces;
using Pomona.Models;

namespace Pomona.Services
{
    public class ControlorEmployeesRelationService : IControlorEmployeesService
    {
        private readonly IControlorEmployeesRelationRepository conEmpRelRepository;
        private readonly IMapper mapper;
        public ControlorEmployeesRelationService(IControlorEmployeesRelationRepository conEmpRelRepository, IMapper mapper)
        {
            this.conEmpRelRepository = conEmpRelRepository;
            this.mapper = mapper;
        }

        public void AddControlorEmployeeRelation(ControlorEmployeesRelation controlorEmployees)
        {
            var controlorEmployeeDB = mapper.Map<DBModel.Models.ControlorEmployeesRelation>(controlorEmployees);
            conEmpRelRepository.Add(controlorEmployeeDB);
        }

        public void DeleteControlorEmployeeRelation(ControlorEmployeesRelation controlorEmployees)
        {
            var controlorEmployeeDB = mapper.Map<DBModel.Models.ControlorEmployeesRelation>(controlorEmployees);
            conEmpRelRepository.Delete(controlorEmployeeDB);
        }

        public List<ControlorEmployeesRelation> GetControlorEmployeeRelations()
        {
            var controlorEmployeeDB = conEmpRelRepository.GetConEmployeesRelations();
            var controlorEmployee = mapper.Map<IEnumerable<Models.ControlorEmployeesRelation>>(controlorEmployeeDB);
            return controlorEmployee.ToList();
        }

        public void SaveChanges()
        {
            conEmpRelRepository.SaveChanges();
        }
        public void RemoveRangeForUser(int userID)
        {
            conEmpRelRepository.RemoveRangeForUser(userID);
        }
        public void UpdateControlorEmployeeRelation(ControlorEmployeesRelation controlorEmployees)
        {
            var controlorEmployeeDB = mapper.Map<DBModel.Models.ControlorEmployeesRelation>(controlorEmployees);
            conEmpRelRepository.Update(controlorEmployeeDB);
        }
    }
}

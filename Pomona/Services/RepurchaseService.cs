using AutoMapper;
using DBModel.Interfaces;
using Pomona.Interfaces;
using Pomona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Services
{
    public class RepurchaseService : IRepurchaseService
    {
        private readonly IRepurchaseRepository repurchaseRepository;
        private readonly IMapper mapper;
        public RepurchaseService(IRepurchaseRepository repurchaseRepository, IMapper mapper)
        {
            this.repurchaseRepository = repurchaseRepository;
            this.mapper = mapper;
        }
        public void AddRepurchase(Repurchase repurchase)
        {
            var repurchaseDB = mapper.Map<DBModel.Models.Repurchase>(repurchase);
            repurchaseRepository.Add(repurchaseDB);
        }

        public void DeleteRepurchase(Repurchase repurchase)
        {
            var repurchaseDB = mapper.Map<DBModel.Models.Repurchase>(repurchase);
            repurchaseRepository.Delete(repurchaseDB);
        }

        public List<Repurchase> GetRepurchases()
        {
            var repurchases = repurchaseRepository.GetRepurchases();
            var repurchasesDto = mapper.Map<IEnumerable<Models.Repurchase>>(repurchases);
            return repurchasesDto.ToList();
        }

        public void SaveChanges()
        {
            repurchaseRepository.SaveChanges();
        }

        public void UpdateRepurchase(Repurchase repurchase)
        {
            var repurchaseDB = mapper.Map<DBModel.Models.Repurchase>(repurchase);
            repurchaseRepository.Update(repurchaseDB);
        }
    }
}

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
    public class CultureTypeService : ICultureTypeService
    {
        private readonly ICultureTypeRepository cultureTypeRepository;
        private readonly IMapper mapper;
        public CultureTypeService(ICultureTypeRepository cultureTypeRepository, IMapper mapper)
        {
            this.cultureTypeRepository = cultureTypeRepository;
            this.mapper = mapper;
        }

        public void AddCultureType(CultureType cultureType)
        {
            var cultureTypeDB = mapper.Map<DBModel.Models.CultureType>(cultureType);
            cultureTypeRepository.Add(cultureTypeDB);
        }

        public void DeleteCultureType(CultureType cultureType)
        {
            var cultureTypeDB = mapper.Map<DBModel.Models.CultureType>(cultureType);
            cultureTypeRepository.Delete(cultureTypeDB);
        }

        public List<CultureType> GetCultureTypes()
        {
            var cultureTypes = cultureTypeRepository.GetCultureTypes();
            var cultureTypesDto = mapper.Map<IEnumerable<Models.CultureType>>(cultureTypes);
            return cultureTypesDto.ToList();
        }

        public void SaveChanges()
        {
           cultureTypeRepository.SaveChanges();
        }

        public void UpdateCultureType(CultureType cultureType)
        {
            var cultureTypeDB = mapper.Map<DBModel.Models.CultureType>(cultureType);
            cultureTypeRepository.Update(cultureTypeDB);
        }
    }
}

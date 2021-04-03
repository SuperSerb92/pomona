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
    public class CultureService: ICultureService
    {
        private readonly ICultureRepository cultureRepository;
        private readonly IMapper mapper;
        public CultureService(ICultureRepository cultureRepository, IMapper mapper)
        {
            this.cultureRepository = cultureRepository;
            this.mapper = mapper;
        }
        public void AddCulture(Culture culture)
        {
            var cultureDB = mapper.Map<DBModel.Models.Culture>(culture);
            cultureRepository.Add(cultureDB);
        }
        public void DeleteCulture(Culture culture)
        {
            var cultureDB = mapper.Map<DBModel.Models.Culture>(culture);
            cultureRepository.Delete(cultureDB);
        }
        public List<Culture> GetCultures()
        {
            var cultures = cultureRepository.GetCultures();
            var culturesDto = mapper.Map<IEnumerable<Models.Culture>>(cultures);
            return culturesDto.ToList();
        }
        public void SaveChanges()
        {
            cultureRepository.SaveChanges();
        }
        public void UpdateCulture(Culture culture)
        {
            var cultureDB = mapper.Map<DBModel.Models.Culture>(culture);
            cultureRepository.Update(cultureDB);
        }
    }
}

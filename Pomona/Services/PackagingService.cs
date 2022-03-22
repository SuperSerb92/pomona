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
    public class PackagingService : IPackagingService
    {
        private readonly IPackagingRepository packagingRepository;
        private readonly IMapper mapper;
        public PackagingService(IPackagingRepository packagingRepository, IMapper mapper)
        {
            this.packagingRepository = packagingRepository;
            this.mapper = mapper;
        }

        public void AddPackaging(Packaging packaging)
        {
            var packageDB = mapper.Map<DBModel.Models.Packaging>(packaging);
            packagingRepository.Add(packageDB);
        }

        public void DeletePackaging(Packaging packaging)
        {
            var packageDB = mapper.Map<DBModel.Models.Packaging>(packaging);
            packagingRepository.Delete(packageDB);
        }

        public List<Packaging> GetPackagings()
        {
            var packages = packagingRepository.GetPackaging();
            var packageDB = mapper.Map<IEnumerable<Models.Packaging>>(packages);
            return packageDB.OrderBy(x=>x.PackagingType).ToList();
        }

        public void SaveChanges()
        {
            packagingRepository.SaveChanges();
        }

        public void UpdatePackaging(Packaging packaging)
        {
            var packageDB = mapper.Map<DBModel.Models.Packaging>(packaging);
            packagingRepository.Update(packageDB);
        }
    }
}

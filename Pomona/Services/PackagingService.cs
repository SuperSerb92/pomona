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
            throw new NotImplementedException();
        }

        public void DeletePackaging(Packaging packaging)
        {
            throw new NotImplementedException();
        }

        public List<Packaging> GetPackagings()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdatePackaging(Packaging packaging)
        {
            throw new NotImplementedException();
        }
    }
}

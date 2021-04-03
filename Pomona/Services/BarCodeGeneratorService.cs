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
    public class BarCodeGeneratorService : IBarCodeGeneratorService
    {
        private readonly IBarCodeGeneratorRepository barCodeRepository;
        private readonly IMapper mapper;
        public BarCodeGeneratorService(IBarCodeGeneratorRepository barCodeRepository, IMapper mapper)
        {
            this.barCodeRepository = barCodeRepository;
            this.mapper = mapper;
        }

        public void AddBarCode(BarCodeGenerator barCode)
        {
            throw new NotImplementedException();
        }

        public void DeleteBarCode(BarCodeGenerator barCode)
        {
            throw new NotImplementedException();
        }

        public List<BarCodeGenerator> GetBarCode()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateBarCode(BarCodeGenerator barCode)
        {
            throw new NotImplementedException();
        }
    }
}

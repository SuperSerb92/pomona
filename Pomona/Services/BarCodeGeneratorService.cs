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
            var barcodeDB = mapper.Map<DBModel.Models.BarCodeGenerator>(barCode);
            barCodeRepository.Add(barcodeDB);
        }

        public void DeleteBarCode(BarCodeGenerator barCode)
        {
            var barcodeDB = mapper.Map<DBModel.Models.BarCodeGenerator>(barCode);
            barCodeRepository.Delete(barcodeDB);
        }

        public List<BarCodeGenerator> GetBarCode()
        {
            var barcode = barCodeRepository.GetBarCodeGenerators();
            var barcodeDto = mapper.Map<IEnumerable<Models.BarCodeGenerator>>(barcode);
            foreach (var item in barcodeDto)
            {
                if (item.Status==0)
                {
                    item.StatusDisplay = "Aktivan";
                }
                if (item.Status==1)
                {
                    item.StatusDisplay = "Neaktivan";
                }
            }
            return barcodeDto.ToList();
        }

        public void SaveChanges()
        {
           barCodeRepository.SaveChanges();
        }

        public void UpdateBarCode(BarCodeGenerator barCode)
        {
            var barcodeDB = mapper.Map<DBModel.Models.BarCodeGenerator>(barCode);
            barCodeRepository.Update(barcodeDB);
        }
    }
}

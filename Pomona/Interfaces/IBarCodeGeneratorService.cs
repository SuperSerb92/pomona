using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
   public interface IBarCodeGeneratorService
    {
        List<Models.BarCodeGenerator> GetBarCode();
        List<Models.BarCodeGenerator> GetBarCodeActive();
        void AddBarCode(Models.BarCodeGenerator barCode);
        void DeleteBarCode(Models.BarCodeGenerator barCode);
        void UpdateBarCode(Models.BarCodeGenerator barCode);
        void SaveChanges();
        void Measure(ref decimal vrednostSaVage,string port);
    }
}

using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
  public  interface IBarCodeGeneratorRepository
    {
        IEnumerable<BarCodeGenerator> GetBarCodeGenerators();
        void Add(DBModel.Models.BarCodeGenerator barCode);
        void Delete(DBModel.Models.BarCodeGenerator barCode);
        void Update(DBModel.Models.BarCodeGenerator barCode);
        void SaveChanges();
        void Measure(ref decimal vrednostSaVage,string port);
    }
}

using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DBModel.Interfaces
{
   public interface IWorkEvaluationRepository
    {
        IEnumerable<WorkEvaluation> GetWorkEvaluations();          
        void Update(DBModel.Models.WorkEvaluation workEvaluation);
        void SaveChanges();
    }
}

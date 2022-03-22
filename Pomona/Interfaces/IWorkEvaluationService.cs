using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Interfaces
{
   public interface IWorkEvaluationService
    {
        List<Models.WorkEvaluation> GetWorkEvaluations();
        void UpdateWorkEval(Models.WorkEvaluation workEvaluation);
        void SaveChanges();
    }
}

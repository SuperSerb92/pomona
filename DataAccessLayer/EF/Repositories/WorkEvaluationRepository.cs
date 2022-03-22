using DBModel;
using DBModel.Interfaces;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EF.Repositories
{
    public class WorkEvaluationRepository : IWorkEvaluationRepository
    {
        private readonly DbModelContext _context;
        public WorkEvaluationRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<WorkEvaluation> GetWorkEvaluations()
        {
            return _context.WorkEvaluations.ToList();
        }

        public void SaveChanges()
        {
           _context.SaveChanges();
        }

        public void Update(WorkEvaluation workEvaluation)
        {
            _context.Update(workEvaluation);
        }
    }
}

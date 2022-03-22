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
    public class WorkEvaluationService : IWorkEvaluationService
    {
        private readonly IWorkEvaluationRepository workEvaluationRepository;
        private readonly IMapper mapper;
        public WorkEvaluationService(IWorkEvaluationRepository workEvaluationRepository, IMapper mapper)
        {
            this.workEvaluationRepository = workEvaluationRepository;
            this.mapper = mapper;
        }
        public List<WorkEvaluation> GetWorkEvaluations()
        {
            var workEvals = workEvaluationRepository.GetWorkEvaluations();
            var workEvalsDto = mapper.Map<IEnumerable<Models.WorkEvaluation>>(workEvals);
            return workEvalsDto.ToList();
        }

        public void SaveChanges()
        {
            workEvaluationRepository.SaveChanges();
        }

        public void UpdateWorkEval(WorkEvaluation workEvaluation)
        {
            var workEvaluationDB = mapper.Map<DBModel.Models.WorkEvaluation>(workEvaluation);
            workEvaluationRepository.Update(workEvaluationDB);
        }
    }
}

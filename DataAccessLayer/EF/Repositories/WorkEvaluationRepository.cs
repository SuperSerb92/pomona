using DBModel;
using DBModel.Interfaces;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

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
        //public IEnumerable<ProfitLossReport> SetWorkEvaluation(DateTime datum, int EmployeeID)
        //{
        //    try
        //    {
        //        var param = new SqlParameter[] {
        //                new SqlParameter() {
        //                    ParameterName = "@datumOd",
        //                    SqlDbType =  System.Data.SqlDbType.DateTime,
        //                    Direction = System.Data.ParameterDirection.Input,
        //                    Value = datumOd
        //                },
        //                new SqlParameter() {
        //                    ParameterName = "@datumDo",
        //                    SqlDbType =  System.Data.SqlDbType.DateTime,
        //                    Direction = System.Data.ParameterDirection.Input,
        //                    Value = datumDo
        //                }};

        //        return _context.ProfitLossReports.FromSqlRaw("EXECUTE dbo.InsertWorkEvaluation @datumOd,@datumDo", param).ToList();

        //    }
        //    catch (Exception)
        //    {

        //        return null;
        //    }

        //}
    }
}

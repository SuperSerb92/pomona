using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using DBModel;
using DBModel.Interfaces;
using DBModel.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EF.Repositories
{
    public class SummaryReportRepository : ISummaryReportRepository
    {
        private readonly DbModelContext _context;
        public SummaryReportRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<SummaryReport> GetSummaryReport()
        {
            return _context.SummaryReports.ToList();
        }
        public IEnumerable<SummaryReport> GetSummaryReport(DateTime datumOd, DateTime datumDo)
        {
            var param = new SqlParameter[] {
                        new SqlParameter() {
                            ParameterName = "@datumOd",
                            SqlDbType =  System.Data.SqlDbType.DateTime,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = datumOd
                        },
                        new SqlParameter() {
                            ParameterName = "@datumDo",
                            SqlDbType =  System.Data.SqlDbType.DateTime,
                            Direction = System.Data.ParameterDirection.Input,
                            Value = datumDo
                        }};

            return _context.SummaryReports.FromSqlRaw("EXECUTE dbo.GetSummaryReport @datumOd,@datumDo",param).ToList();
        }
    }
}

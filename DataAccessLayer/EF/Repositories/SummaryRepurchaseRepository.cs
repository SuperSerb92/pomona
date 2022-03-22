using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using DBModel.Interfaces;
using DBModel.Models;
using Microsoft.EntityFrameworkCore;
using DBModel;

namespace DataAccessLayer.EF.Repositories
{
    public class SummaryRepurchaseRepository : ISummaryRepurchaseRepository
    {
        private readonly DbModelContext _context;
        public SummaryRepurchaseRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public IEnumerable<SummaryReportRepurchase> GetSummaryReportRepurchase(DateTime datumOd, DateTime datumDo)
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

            return _context.SummaryReportsRepurchases.FromSqlRaw("EXECUTE dbo.GetSummaryReportRepurchase @datumOd,@datumDo", param).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(SummaryReportRepurchase summaries)
        {
            _context.Update(summaries);
        }
    }
}

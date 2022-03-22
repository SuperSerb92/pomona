using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBModel;
using DBModel.Interfaces;
using DBModel.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EF.Repositories
{
    public class ProfitLossReportRepository : IProfitLossReportRepository
    {
        private readonly DbModelContext _context;
        public ProfitLossReportRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public decimal GetAvgPrice(string datumOd, string datumDo)
        {
            try
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

                List<ProfitLossReport> result = _context.ProfitLossReports.FromSqlRaw("EXECUTE dbo.GetAVGPrice @datumOd,@datumDo", param).ToList();
                if (result == null)
                {
                    return 0;
                }
                else
                {
                    return result[0].TrosakProc;
                }
            }
            catch (Exception)
            {

                return 0;
            }
        }

        public IEnumerable<ProfitLossReport> GetProfitLossReport(DateTime datumOd, DateTime datumDo)
        {
            try
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

                return _context.ProfitLossReports.FromSqlRaw("EXECUTE dbo.GetProfitLossReport @datumOd,@datumDo", param).ToList();

            }
            catch (Exception)
            {

                return null;
            }
           
        }
    }
}

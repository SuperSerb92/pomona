using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DBModel;
using DBModel.Interfaces;
using DBModel.Models;

namespace DataAccessLayer.EF.Repositories
{
    public class ControlorEmployeesRelationRepository : IControlorEmployeesRelationRepository
    {
        private readonly DbModelContext _context;
        public ControlorEmployeesRelationRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); 
        }
        public void Add(ControlorEmployeesRelation relation)
        {
          _context.Add(relation);
        }

        public void Delete(ControlorEmployeesRelation relation)
        {
            _context.Remove(relation);
        }

        public void RemoveRangeForUser(int  userID)
        {
           var rel =  _context.ControlorEmployeesRelations.Where(x => x.UserID == userID);
            _context.RemoveRange(rel);
        }

        public IEnumerable<ControlorEmployeesRelation> GetConEmployeesRelations()
        {
           return _context.ControlorEmployeesRelations.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(ControlorEmployeesRelation relation)
        {
            _context.Update(relation);
        }
    }
}

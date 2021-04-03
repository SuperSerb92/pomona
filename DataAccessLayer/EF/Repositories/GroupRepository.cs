using DBModel;
using DBModel.Interfaces;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EF.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly DbModelContext _context;

        public GroupRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); 
        }
        public void Add(Group group)
        {
          _context.Add(group);
        }

        public void Delete(Group group)
        {
            _context.Remove(group);
        }

        public IEnumerable<Group> GetGroups()
        {
            return _context.Groups.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void Update(Group group)
        {
            _context.Update(group);
        }
    }
}

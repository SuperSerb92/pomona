using DBModel;
using DBModel.Interfaces;
using DBModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.EF.Repositories
{
    public class LoginRepository : ILoginRepository
    {
       
        private readonly DbModelContext _context;
        public LoginRepository(DbModelContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Add(User user)
        {
            _context.Add(user);
        }

        public void Delete(User user)
        {
            _context.Remove(user);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void SaveChanges()
        {
           _context.SaveChanges();
        }

        public void Update(User user)
        {
            _context.Update(user);
        }
    }
}

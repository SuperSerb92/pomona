using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Extensions
{
    public class MapperHelper
    {
        DBModel.DataAccess.DbModelContext db;
        private  Mapper _mapper ;
        public MapperHelper(DBModel.DataAccess.DbModelContext db)
        {
            this.db = db;
            
        }

        public  List<Pomona.Models.Employee> GetEmployees()
        {
            return _mapper.Map< List<Pomona.Models.Employee>>(db.Employees.ToList());
        }

        //insert
        public void Insert(object o)
        {
            db.Add(o);
           
        }
        //update
        public void Update(object o)
        {
            db.Update(o);         
        }
        //delete
        public void Delete(object o)
        {
            db.Remove(0);          
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}

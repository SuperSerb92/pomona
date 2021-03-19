using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Extensions
{
    public class MapperHelper
    {
        DBModel.DataAccess.DbModelContext db;

        public MapperHelper(DBModel.DataAccess.DbModelContext db)
        {
            this.db = db;
        }
        //insert
        public void Insert(object o)
        {
            db.Add(o);
            db.SaveChanges();
        }
        //update
        public void Update(object o)
        {
            db.Update(o);
            db.SaveChanges();
        }
        //delete
        public void Delete(object o)
        {
            db.Remove(0);
            db.SaveChanges();
        }
    }
}

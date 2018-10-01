using DataCollectionPRJ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
namespace DataCollectionPRJ.DAL.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private OilDataCollectionEntities context;
        private DbSet<T> table;


        public GenericRepository()
        {

            context = new OilDataCollectionEntities();
            table = context.Set<T>();

        }
        public GenericRepository(OilDataCollectionEntities _context)
        {
            this.context = _context;
            table = context.Set<T>();

        }
        public void Delete(object id)
        {
            var Data = table.Find(id);
            context.Entry(Data).State = EntityState.Deleted;
        }

        public T Insert(T obj)
        {
            if (obj != null)
            {
                table.Add(obj);
            }
            return obj;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public IEnumerable<T> SelectAll()
        {
            return table.ToList();
        }

        public T SelectAllById(object id)
        {
            return table.Find(id);
        }

        public T Update(T obj)
        {
            table.Attach(obj);
            var entry = context.Entry(obj);
            entry.State = EntityState.Modified;
            return obj;
        }
    }
}

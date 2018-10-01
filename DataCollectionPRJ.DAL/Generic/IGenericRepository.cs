using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionPRJ.DAL.Generic
{
    public interface IGenericRepository<T> where T : class
    {
        T Insert(T obj);
        T Update(T obj);
        void Delete(object id);
        void Save();
        IEnumerable<T> SelectAll();
        T SelectAllById(object id);
    }
}

using DataCollectionPRJ.DAL.Generic;
using DataCollectionPRJ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionPRJ.DAL.Interface
{
    public interface IWebUserRepository : IGenericRepository<WebUser>, IDisposable
    {

    }
}

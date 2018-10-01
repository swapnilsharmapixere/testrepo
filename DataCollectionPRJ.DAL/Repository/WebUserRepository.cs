using DataCollectionPRJ.DAL.Generic;
using DataCollectionPRJ.DAL.Interface;
using DataCollectionPRJ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionPRJ.DAL.Repository
{
    public class WebUserRepository : GenericRepository<WebUser>, IWebUserRepository
    {
        private OilDataCollectionEntities context;
        public WebUserRepository()
        {
            context = new OilDataCollectionEntities(); ;
        }

        public WebUserRepository(OilDataCollectionEntities _context)
        {
            context = _context;
        }
        public void Dispose()
        {
            if (context != null)
            {
                GC.SuppressFinalize(context);
                context.Dispose();
            }
        }
    }
}

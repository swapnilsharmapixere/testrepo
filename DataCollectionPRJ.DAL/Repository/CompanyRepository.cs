using DataCollectionPRJ.DAL.Generic;
using DataCollectionPRJ.DAL.Interface;
using DataCollectionPRJ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataCollectionPRJ.DAL.Repository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private OilDataCollectionEntities context;
        public CompanyRepository()
        {
            context = new OilDataCollectionEntities(); ;
        }

        public CompanyRepository(OilDataCollectionEntities _context)
        {
            context = _context;
        }

        public List<SelectListItem> GetCompanyName()
        {
            List<SelectListItem> NameList = new List<SelectListItem>();
            NameList = context.Companies.Where(x => x.IsActive == true).ToList().Select(x => new SelectListItem { Text = x.CompanyName, Value = x.CompanyId.ToString() }).ToList();
            return NameList;
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

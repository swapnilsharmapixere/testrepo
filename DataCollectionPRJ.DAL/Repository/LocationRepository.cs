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
    public class LocationRepository : GenericRepository<Location>, ILocationRepository
    {

        private OilDataCollectionEntities context;
        public LocationRepository()
        {
            context = new OilDataCollectionEntities(); ;
        }

        public LocationRepository(OilDataCollectionEntities _context)
        {
            context = _context;
        }
        public List<SelectListItem> GetLocationName()
        {
            List<SelectListItem> NameList = new List<SelectListItem>();
            NameList = context.Locations.Where(x => x.IsActive == true).ToList().Select(x => new SelectListItem { Text = x.LocationName, Value = x.LocationId.ToString() }).ToList();
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

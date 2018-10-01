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
    public class DashboardRepository : GenericRepository<SpSelect_WellData_Result>, IDashboardRepository
    {
        private OilDataCollectionEntities context;
        public DashboardRepository()
        {
            context = new OilDataCollectionEntities(); ;
        }

        public DashboardRepository(OilDataCollectionEntities _context)
        {
            context = _context;
        }

        public List<SpSelect_WellData_Result> WellDataList()
        {
            List<SpSelect_WellData_Result> NameList = new List<SpSelect_WellData_Result>();
            NameList = context.SpSelect_WellData().ToList();
            return NameList;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<SpSelect_dashboardWellmarkers_Result> DashboardMarkerData()
        {
            List<SpSelect_dashboardWellmarkers_Result> NameList = new List<SpSelect_dashboardWellmarkers_Result>();
            NameList = context.SpSelect_dashboardWellmarkers().ToList();
            return NameList;
        }
    }
}

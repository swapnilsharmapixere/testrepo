using DataCollectionPRJ.DAL.Generic;
using DataCollectionPRJ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionPRJ.DAL.Interface
{
   public interface IDashboardRepository :  IGenericRepository<SpSelect_WellData_Result>, IDisposable
    {
        List<SpSelect_WellData_Result> WellDataList();
        List<SpSelect_dashboardWellmarkers_Result> DashboardMarkerData();
    }
}

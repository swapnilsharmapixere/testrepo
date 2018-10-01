using DataCollectionPRJ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionPRJ.Entity.ViewModels.Dashboard
{
    public class DashboardViewmodel
    {
        public List<SpSelect_WellData_Result> WellData { get; set; }
        public List<SpSelect_dashboardWellmarkers_Result> DashboardWellMarkers { get; set; }
    }
}

using DataCollectionPRJ.DAL.UnitOfWork;
using DataCollectionPRJ.Data;
using DataCollectionPRJ.Entity.ViewModels.Dashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataCollectionPRJ.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        UnitOfWork unitofwork = new UnitOfWork();
        public DashboardController()
        {
          
        }
        public ActionResult Index()
        {
            DashboardViewmodel model = new DashboardViewmodel();
            model.WellData = unitofwork.DashboarsRepository.WellDataList();
            model.DashboardWellMarkers = unitofwork.DashboarsRepository.DashboardMarkerData();
          
            return View(model);
        }
    }
}
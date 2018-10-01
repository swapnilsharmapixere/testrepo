using DataCollectionPRJ.DAL.Repository;
using DataCollectionPRJ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCollectionPRJ.DAL.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly OilDataCollectionEntities context;

        #region Main Member       
        public UnitOfWork()
        {
            context = new OilDataCollectionEntities();
        }
        public UnitOfWork(OilDataCollectionEntities _context)
        {
            context = _context;
        }
        #endregion

        #region Private Member
        private LocationRepository _locationtrpository;
        private UserRoleRepository _userrolerepository;
        private CompanyRepository _companyrepository;
        private WebUserRepository _webuserrepository;
        private DashboardRepository _dashboardrepository;
        #endregion

        #region Public Member

        public LocationRepository LocationRepository
        {
            get
            {
                if (_locationtrpository == null)
                {
                    _locationtrpository = new LocationRepository(context);
                }
                return _locationtrpository;
            }
        }

        public UserRoleRepository UserRoleRepository
        {
            get
            {
                if (_userrolerepository == null)
                {
                    _userrolerepository = new UserRoleRepository(context);
                }
                return _userrolerepository;
            }
        }

        public CompanyRepository CompanyRepository
        {
            get
            {
                if (_companyrepository == null)
                {
                    _companyrepository = new CompanyRepository(context);
                }
                return _companyrepository;
            }
        }

        public WebUserRepository WebUserRepository
        {
            get
            {
                if (_webuserrepository == null)
                {
                    _webuserrepository = new WebUserRepository(context);
                }
                return _webuserrepository;
            }
        }
        public DashboardRepository DashboarsRepository
        {
            get
            {
                if (_dashboardrepository == null)
                {
                    _dashboardrepository = new DashboardRepository(context);
                }
                return _dashboardrepository;
            }
        }
        #endregion
    }
}

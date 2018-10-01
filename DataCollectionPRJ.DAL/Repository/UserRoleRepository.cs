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
    public class UserRoleRepository : GenericRepository<UserRole>, IUserRoleRepository
    {

        private OilDataCollectionEntities context;
        public UserRoleRepository()
        {
            context = new OilDataCollectionEntities(); ;
        }

        public UserRoleRepository(OilDataCollectionEntities _context)
        {
            context = _context;
        }
        public List<SelectListItem> GetRoleName()
        {
            List<SelectListItem> NameList = new List<SelectListItem>();
            NameList = context.UserRoles.Where(x => x.IsActive == true).ToList().Select(x => new SelectListItem { Text = x.RoleName, Value = x.UserRoleId.ToString() }).ToList();
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

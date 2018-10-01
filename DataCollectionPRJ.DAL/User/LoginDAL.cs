using DataCollectionPRJ.Data;
using DataCollectionPRJ.Entity.ViewModels.User;
using System.Linq;


namespace DataCollectionPRJ.DAL.User
{
    public class LoginDAL
    {
        OilDataCollectionEntities context;
        public LoginViewModel ValidateUser(string username, string password)
        {
            LoginViewModel model = null;
            using (context = new OilDataCollectionEntities())
            {
                var user = context.WebUsers.Where(u => u.WebUserName == username && u.UserPassword == password && u.IsActive == true).FirstOrDefault();
                if (user != null)
                {
                    model = new LoginViewModel();
                    model.WebUserName = user.WebUserName;
                    model.UserPassword = user.UserPassword;
                    model.RoleName = user.UserRole.RoleName;
                    model.WebUserId = user.WebUserId;
                    model.CreatedDate = user.CreatedDate.Value;
                    model.WebEmailId = user.WebEmailId;
                    model.CompanyId = user.CompanyId.Value;
                    model.RoleId = user.RoleId.Value;
                    model.LocationId = user.LocationId.Value;
                    model.IsActive = user.IsActive.Value;

                }
                return model;
            }
        }
    }
}

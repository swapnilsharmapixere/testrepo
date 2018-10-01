using DataCollectionPRJ.DAL.UnitOfWork;
using DataCollectionPRJ.DAL.User;
using DataCollectionPRJ.Data;
using DataCollectionPRJ.Entity.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DataCollectionPRJ.Controllers
{
    public class UserController : Controller
    {
        UnitOfWork unitofwork = new UnitOfWork();
        LoginViewModel model = new LoginViewModel();
        LoginDAL obj;
        // GET: User
        public UserController()
        {
            //  usersessiondetails = new UserSessionDetails();
            obj = new LoginDAL();
        }
        public ActionResult AddUser()
        {
            return View();
        }

        public ActionResult AllUser()
        {
            return View();
        }

        public ActionResult Login()
        {
            model.LocationList = unitofwork.LocationRepository.GetLocationName();
            model.RoleList = unitofwork.UserRoleRepository.GetRoleName();
            model.CompanyList = unitofwork.CompanyRepository.GetCompanyName();
            return View(model);
        }
        [HttpPost]
        public ActionResult CreateAccount(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entity = new WebUser();
                entity.WebUserName = model.WebUserName;
                entity.WebEmailId = model.WebEmailId;
                entity.UserPassword = model.UserPassword;
                entity.CompanyId = model.CompanyId;
                entity.RoleId = model.RoleId;
                entity.LocationId = model.LocationId;
                entity.CreatedDate = DateTime.Now;
                entity.IsActive = true;
                unitofwork.WebUserRepository.Insert(entity);
                unitofwork.WebUserRepository.Save();
            }
            model.LocationList = unitofwork.LocationRepository.GetLocationName();
            model.RoleList = unitofwork.UserRoleRepository.GetRoleName();
            model.CompanyList = unitofwork.CompanyRepository.GetCompanyName();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {

            var ValidateUser = obj.ValidateUser(model.WebUserName, model.UserPassword);
            if (ValidateUser != null)
            {
                Session["Rolename"] = ValidateUser.RoleName;
                Session["UserName"] = ValidateUser.WebUserName;
                FormsAuthentication.SetAuthCookie(ValidateUser.WebUserName, false);
                WebUser entity = new WebUser();
                entity.WebUserId = ValidateUser.WebUserId;
                entity.WebUserName = ValidateUser.WebUserName;
                entity.WebEmailId = ValidateUser.WebEmailId;
                entity.CompanyId = ValidateUser.CompanyId;
                entity.RoleId = ValidateUser.RoleId;
                entity.LocationId = ValidateUser.LocationId;
                entity.LastLogin = DateTime.Now;
                entity.CreatedDate = ValidateUser.CreatedDate;
                entity.IsActive = ValidateUser.IsActive;
                entity.UserPassword = ValidateUser.UserPassword;
                unitofwork.WebUserRepository.Update(entity);
                unitofwork.WebUserRepository.Save();
                return RedirectToAction("Index", "Dashboard");

            }
            ModelState.AddModelError("Error", "Invalid User Name or Password.");
            model.LocationList = unitofwork.LocationRepository.GetLocationName();
            model.RoleList = unitofwork.UserRoleRepository.GetRoleName();
            model.CompanyList = unitofwork.CompanyRepository.GetCompanyName();

            return View(model);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
    }
}
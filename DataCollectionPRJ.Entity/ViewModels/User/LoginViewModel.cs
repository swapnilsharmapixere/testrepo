using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataCollectionPRJ.Entity.ViewModels.User
{
    public class LoginViewModel
    {
        public int WebUserId { get; set; }
        [Required(ErrorMessage = "Please Enter {0}")]
        [Display(Name = "User Name")]
        [StringLength(50, MinimumLength = 1)]
        public string WebUserName { get; set; }

        [Required(ErrorMessage = "Please Enter {0}")]
        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 1)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
        [Required(ErrorMessage = "Email is Requirde")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" + @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" + @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Email is not valid")]
        public string WebEmailId { get; set; }
        public int CompanyId { get; set; }
        public int RoleId { get; set; }
        public int LocationId { get; set; }
        public DateTime LastLogin { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

        public string RoleName { get; set; }
        public List<SelectListItem> CompanyList { get; set; }

        public List<SelectListItem> LocationList { get; set; }
        public List<SelectListItem> RoleList { get; set; }

    }
}

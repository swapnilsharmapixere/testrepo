﻿using DataCollectionPRJ.DAL.Generic;
using DataCollectionPRJ.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DataCollectionPRJ.DAL.Interface
{
    public interface ICompanyRepository : IGenericRepository<Company>, IDisposable
    {
        List<SelectListItem> GetCompanyName();
    }
}

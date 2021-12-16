using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PasaLife.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize]

    public class DashboardController : Controller
    {

        #region Index
        public IActionResult Index()
        {
            return View();
        }
        #endregion

    }
}

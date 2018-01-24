using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniSocialNetwork.Web.Controllers
{
    public class SettingsController : Controller
    {
        // GET: UserSettings
        public ActionResult Index()
        {
            return View();
        }
    }
}
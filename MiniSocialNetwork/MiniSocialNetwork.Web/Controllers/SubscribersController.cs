using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniSocialNetwork.Web.Controllers
{
    public class SubscribersController : Controller
    {
        // GET: Subscribers
        public ActionResult Index()
        {
            return View("Subscribers");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniSocialNetwork.Web.Controllers
{
    [RoutePrefix("Messages")]
    public class MessagesController : Controller
    {
        [Route("{id:Guid}")]
        public ActionResult Index(Guid id)
        {
            return View("Messages");
        }
    }
}
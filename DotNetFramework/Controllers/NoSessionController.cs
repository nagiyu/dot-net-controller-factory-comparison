using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace DotNetFramework.Controllers
{
    [SessionBehavior(SessionStateBehavior.Disabled)]
    public class NoSessionController : Controller
    {
        // GET: NoSession
        public ActionResult Index()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Vidly18.Controllers
{
    public class RentedController : Controller
    {
        // GET: Rented
        [Authorize(Roles ="Admin")]
        public ActionResult New()
        {
            return View();
        }
    }
}
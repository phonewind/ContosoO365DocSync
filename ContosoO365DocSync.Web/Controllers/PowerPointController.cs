﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ContosoO365DocSync.Web.Controllers
{
    [Authorize]
    public class PowerPointController : Controller
    {
        // GET: PowerPoint
        public ActionResult Point()
        {
            return View();
        }
    }
}
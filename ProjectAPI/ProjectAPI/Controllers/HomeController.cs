using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;
using ProjectAPI.Models;

namespace ProjectAPI.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();

        }



    }
}
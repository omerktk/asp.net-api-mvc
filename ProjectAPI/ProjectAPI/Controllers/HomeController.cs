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
            List<Class1> customers = new List<Class1>();
            string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                string query = "SELECT id, name, pro , phone , photo FROM emp";
                using (MySqlCommand cmd = new MySqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (MySqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new Class1
                            {
                                id = Convert.ToInt32(sdr["id"]),
                                name = sdr["name"].ToString(),
                                pro = sdr["pro"].ToString(),
                                phone = sdr["phone"].ToString(),
                                photo = sdr["photo"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            

            return Json(customers, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
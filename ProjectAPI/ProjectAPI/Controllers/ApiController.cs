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
    public class ApiController : Controller
    {
        List<Class1> customers = new List<Class1>();
        // GET: Api
        public ActionResult Index()
        {
            var data = new
            {
                query = "error"
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }



        //delete
        public ActionResult delete(int id)
        {
            try
            {
                int a = 0;
                if (id == null)
                {
                    a = a + 1;
                }
                if (a != 1)
                {
                    string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {

                        string query = "DELETE FROM `emp` WHERE `emp`.`id` = " + id;

                        using (MySqlCommand cmd = new MySqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            using (MySqlDataReader sdr = cmd.ExecuteReader())
                            {

                            }
                            con.Close();
                        }
                    }


                    var data = new
                    {
                        query = "success"
                    };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var data = new
                    {
                        query = "error"
                    };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                var data = new
                {
                    query = "error"
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }

        }




        //Put data

        public ActionResult put()
        {
            var data = new
            {
                query = "error"
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult put(string idl,string name, string pro, string phone, string photo)
        {
            try
            {
                int a = 0;
                if (idl == null)
                {
                    if (photo == "")
                    {
                        if (name == "")
                        {
                            if (pro == "")
                            {
                                if (phone == "")
                                {
                                    a = a + 1;
                                }
                            }
                        }
                    }
                }
                if (a != 1)
                {
                    string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {

                        string query = "UPDATE `emp` SET `name` = '"+ name + "', `pro` = '" + pro  + "', `phone` = '" + phone + "', `photo` = '" + photo + "' WHERE `emp`.`id` = " + idl + ";";

                        using (MySqlCommand cmd = new MySqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            using (MySqlDataReader sdr = cmd.ExecuteReader())
                            {

                            }
                            con.Close();
                        }
                    }


                    var data = new
                    {
                        query = "success"
                    };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var data = new
                    {
                        query = "error"
                    };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }

            }
            catch (Exception ex)
            {
                var data = new
                {
                    query = "error"
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }













        //Post data 

        public ActionResult post()
        {
            var data = new
            {
                query = "error"
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult post(string name, string pro, string phone,string photo)
        {
            try
            {
                int a = 0;
                if(name == "")
                {
                    if(pro=="")
                    {
                        if(phone=="")
                        {
                            a = a + 1;
                        }
                    }
                }
                if (a != 1)
                {
                    string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {

                        string query = "INSERT INTO `emp` (`id`, `name`, `pro`, `phone`, `photo`) VALUES (NULL, '" + name + "', '" + pro + "', '" + phone + "', '" + photo + "');";

                        using (MySqlCommand cmd = new MySqlCommand(query))
                        {
                            cmd.Connection = con;
                            con.Open();
                            using (MySqlDataReader sdr = cmd.ExecuteReader())
                            {

                            }
                            con.Close();
                        }
                    }


                    var data = new
                    {
                        query = "success"
                    };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var data = new
                    {
                        query = "error"
                    };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
                
            }
            catch (Exception ex)
            {
                var data = new
                {
                    query = "error"
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult emp()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {

                    string query = "SELECT id, name, pro , phone , photo FROM emp;";

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

                if (customers.Count != 0)
                {
                    return Json(customers, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var data = new
                    {
                        query = "Empty"
                    };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                var data = new
                {
                    query = "Error"
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult emp(int id)
        {
             int a = 0;
                if (id == null)
                {
                    a = a + 1;
                }
            if (a != 1)
            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {

                        string query = "SELECT id, name, pro , phone , photo FROM emp where id = " + id;

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

                    if (customers.Count != 0)
                    {

                        return Json(customers, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var data = new
                        {
                            query = "empty"
                        };
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                }
                catch (Exception ex)
                {
                    var data = new
                    {
                        query = "error"
                    };
                    return Json(data, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                var data = new
                {
                    query = "error"
                };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTPBD.Models;

namespace PTPBD.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string userName, string password)
        {
            try
            {
                using (PRATNEEntities db = new PRATNEEntities())
                {
                    var list = db.User
                        .SqlQuery("SELECT * FROM [User] where [User].UserName = @userName AND [User].Password = @password",
                                     new SqlParameter("@userName", userName), new SqlParameter("@password", password)).ToList();

                    if(list.Count() > 0)
                    {
                        User oUser = list.First();
                        Session["User"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario invalido :(");
                    }
                }
                
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error:( " + ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTPBD.Controllers
{
    public class CloseController : Controller
    {
        //Metodo para el cierre de sesion
        public ActionResult Logoff()
        {
            Session["User"] = null;
            return RedirectToAction("Index", "Access");
        }
    }
}
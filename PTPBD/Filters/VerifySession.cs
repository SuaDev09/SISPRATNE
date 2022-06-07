using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTPBD.Models;
using PTPBD.Controllers;

namespace PTPBD.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Se evalua la sesion
            var oUser = (User)HttpContext.Current.Session["User"];
            
            //Si es null no se pasara el filtro debido a que no hay un inicio de sesion
            if (oUser == null)
            {
                //Si se va a una ruta diferente a AccessController se le mandara al inicio de sesion
                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else
            {
                //Una vez el usuario inicia sesion no podra regresar a esa pantalla hasta que se cierre sesion
                if(filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
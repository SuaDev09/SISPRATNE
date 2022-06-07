using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTPBD.Models;
using PTPBD.Models.TableViewModels;
using PTPBD.Models.ViewModels;

namespace PTPBD.Controllers
{
    public class SolicitudAtencionController : Controller
    {
        private PRATNEEntities db = new PRATNEEntities();
        // GET: SolicitudAtencion
        public ActionResult Index()
        {
            return View(db.SolicitudAtencion.ToList());
        }

         //GET: SolicitudAtencion/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            SolicitudAtencion oSolicitudA = db.SolicitudAtencion.Find(id);
            if(oSolicitudA == null)
            {
                return HttpNotFound();
            }

            return View(oSolicitudA);
        }

        // GET: SolicitudAtencion/Create
        public ActionResult Add()
        {
            
            return View();
        }

        // POST: SolicitudAtencion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(int idExpediente,[Bind(Include = "PerVive, MotivoConsulta, HistoriaCaso, PruebasAplicadas, Nombre_EstudianteApoyo")]SolicitudAtencion solicitudAtencion, [Bind(Include = "Id_Se_Conforma_Por, FK_Id_Expediente, FK_Id_SolicitudAtencion") ] Expediente_Compuesto_por expedienteCompuesto)
        {
            if (ModelState.IsValid)
            {
                db.SolicitudAtencion.Add(solicitudAtencion);
                expedienteCompuesto.FK_Id_SolicitudAtencion = idExpediente;
                expedienteCompuesto.FK_Id_SolicitudAtencion = solicitudAtencion.Id_SolicitudAtencion;
                db.Expediente_Compuesto_por.Add(expedienteCompuesto);
                db.SaveChanges();
                return Redirect(Url.Content("~/Expediente"));
            }

          
            return View();
        }

        // GET: SolicitudAtencion/Edit/5
        public ActionResult Edit(int id)
        {

            var oSolicitudAtencion = db.SolicitudAtencion.Find(id);
          
            if(oSolicitudAtencion == null)
            {
                return HttpNotFound();
            }
          

            return View(oSolicitudAtencion);
        }

        // POST: SolicitudAtencion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        // POST: SolicitudAtencion/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id)
        {

            int oSolicitud = db.Database.ExecuteSqlCommand("DELETE FROM [SolicitudAtencion] WHERE Id_SolicitudAtencion = @Id", new SqlParameter("@Id", id));  
            if(oSolicitud == 0)
            {
                return Content("0");
            }
            else
            {
                db.SaveChanges();
                return Content("1");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PTPBD.Models;
using PTPBD.Models.TableViewModels;
using PTPBD.Models.ViewModels;

namespace PTPBD.Controllers
{
    public class PacienteController : Controller
    {
        private PRATNEEntities db = new PRATNEEntities();
        // GET: Paciente
        public ActionResult Index()
        { 
            return View(db.Paciente.ToList());
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.FK_Id_Terapeuta = new SelectList(db.Terapeuta, "Id_Terapeuta", "Id_Terapeuta");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Id_Paciente,Nombre,Apellido_Paterno,Apellido_Materno,Edad,Genero,FechaNa,Escolaridad,DireccionPost,Telefono,Padecimiento")] Paciente paciente, [Bind(Include = "Id_Atiende,FK_Id_Terapeuta,FK_Id_Paciente")] Terapeuta_Atiende terapeuta_Atiende)
        {
            if (ModelState.IsValid)
            {
                db.Paciente.Add(paciente);
                terapeuta_Atiende.FK_Id_Paciente = paciente.Id_Paciente;
                db.Terapeuta_Atiende.Add(terapeuta_Atiende);
                db.SaveChanges();
                return Redirect(Url.Content("~/Paciente/"));
            }
            ViewBag.FK_Id_Terapeuta = new SelectList(db.Terapeuta, "Id_Terapeuta", "Id_Terapeuta", terapeuta_Atiende.FK_Id_Terapeuta);

            return View();
        }

        public ActionResult Edit(int? Id) {
            
            if(Id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Paciente paciente = db.Paciente.Find(Id);

            //Codigo para retornar el terapeuta que se tiene asignado
            int idTerapeutaAtiende = 0;
            var listaAux = db.Terapeuta_Atiende.ToList();
            for (int i = 0; i < listaAux.Count(); i++)
            {
                if(listaAux[i].FK_Id_Paciente == Id)
                {
                    idTerapeutaAtiende = listaAux[i].Id_Atiende;
                }
            }
            var listaAux2 = db.Terapeuta_Atiende.Find(idTerapeutaAtiende);
            
            
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.FK_Id_Terapeuta = new SelectList(db.Terapeuta, "Id_Terapeuta", "Id_Terapeuta", listaAux2.FK_Id_Terapeuta);
            return View(paciente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Paciente,Nombre,Apellido_Paterno,Apellido_Materno,Edad,Genero,FechaNa,Escolaridad,DireccionPost,Telefono,Padecimiento")] Paciente paciente, [Bind(Include = "FK_Id_Terapeuta")] Terapeuta_Atiende terapeuta_Atiende)
        {

            
            if (ModelState.IsValid)
                {
                try
                {
                    db.Paciente.Attach(paciente);
                    db.Entry(paciente).State = EntityState.Modified;

                    var listaAux = db.Terapeuta_Atiende.ToList();
                    for (int i = 0; i < listaAux.Count(); i++)
                    {
                        if (listaAux[i].FK_Id_Paciente == paciente.Id_Paciente)
                        {
                            db.Terapeuta_Atiende.Remove(listaAux[i]);
                        }
                    }
                    terapeuta_Atiende.FK_Id_Paciente = paciente.Id_Paciente;
                    db.Terapeuta_Atiende.Add(terapeuta_Atiende);
                    db.SaveChanges();
                }
                catch (OptimisticConcurrencyException)
                {
                    db.SaveChanges();
                }
                              
                return Redirect(Url.Content("~/Paciente/"));
            }

            ViewBag.FK_Id_Terapeuta = new SelectList(db.Terapeuta, "Id_Terapeuta", "Id_Terapeuta", terapeuta_Atiende.FK_Id_Terapeuta);
            return View(paciente);

        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            
            var oPaciente = db.Database.ExecuteSqlCommand("DELETE FROM [Paciente] WHERE [Paciente].Id_Paciente = @Id", new SqlParameter("@Id", id));
            db.SaveChanges();
            

            return Content(oPaciente.ToString());
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Paciente.Find(id);
            if(paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }


    }
}

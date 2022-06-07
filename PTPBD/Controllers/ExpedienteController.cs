using PTPBD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PTPBD.Controllers
{
    public class ExpedienteController : Controller
    {
        private PRATNEEntities db = new PRATNEEntities();

        //public ActionResult Index()
        //{
        //    //var list = db.Database.SqlQuery("SELECT p.Id_Paciente, p.Nombre, p.Apellido_Paterno, p.Apellido_Materno, p.Padecimiento, t.Id_Terapeuta, t.Nombre, t.Apellido_Paterno, t.Apellido_Materno FROM [Paciente_Tiene] as pt" +
        //    //" INNER JOIN Paciente p ON p.Id_Paciente = pt.FK_Id_Paciente" +
        //    //" INNER JOIN Expediente as e ON e.Id_Expediente = pt.FK_Id_Expediente" +
        //    //" INNER JOIN Terapeuta_Realiza as tr ON tr.FK_Id_Expediente = e.Id_Expediente" +
        //    //" INNER JOIN Terapeuta as t ON t.Id_Terapeuta = tr.FK_Id_Terapeuta"); 
                        
        //    //return View(list);
        //}

        public ActionResult Add()
        {
            return View();
        }
        // GET: Expediente/Details/5
        [HttpPost]
        public ActionResult Details([Bind(Include = "Id_Paciente,Nombre,Apellido_Paterno,Apellido_Materno,Edad,Genero,FechaNa,Escolaridad,DireccionPost,Telefono,Padecimiento")] Paciente paciente, [Bind(Include = "Id_Expediente, Estado_Expediente")]Expediente expediente, [Bind(Include = "Id_PacienteTiene,FK_Id_Paciente,FK_Id_Expediente")] Paciente_Tiene paciente_Tiene)
        {
            var existe = db.Paciente_Tiene.ToList();
            bool bandera = false;
            Paciente paciente1 = null;
            Expediente expediente2 = null;
            Paciente_Tiene paciente_Tiene1 = null;

            for(int i = 0; i < existe.Count; i++)
            {
                if(existe[i].FK_Id_Paciente == paciente.Id_Paciente)
                {
                    bandera = true;
                    paciente1 = existe[i].Paciente;
                    expediente2 = existe[i].Expediente;
                    paciente_Tiene1 = existe[i];
                    break;
                }
            }
            
            if (bandera)
            {
                ViewBag.PacienteTiene = paciente_Tiene1;
                ViewBag.Paciente = paciente1;
                return View(expediente2);
            }
            else
            {
               db.Expediente.Add(expediente);
                paciente_Tiene.FK_Id_Expediente = expediente.Id_Expediente;
                paciente_Tiene.FK_Id_Paciente = paciente.Id_Paciente;
                db.Paciente_Tiene.Add(paciente_Tiene);
                db.SaveChanges();
                ViewBag.PacienteTiene = paciente_Tiene;
                ViewBag.Paciente = paciente;
                
                
                return View(expediente2); 
            }

        }

        //[HttpGet]
        //public ActionResult AsignarTerapeuta(int? idExpediente)
        //{
            


        //    //Terapeuta terapeuta = null;
        //    //Expediente expediente = db.Expediente.Find(idExpediente);
        //    //var idTerapeutaRealiza = 0;
        //    //var registros = db.Terapeuta_Realiza.ToList();

        //    //for(int i = 0; i < registros.Count; i++)
        //    //{
        //    //    if(registros[i].FK_Id_Expediente == idExpediente)
        //    //    {
        //    //        idTerapeutaRealiza = registros[i].Id_TerapeutaRealiza;
        //    //        terapeuta = registros[i].Terapeuta;
        //    //    }
        //    //}
        //    //    ViewBag.Terapeuta = terapeuta;
        //    //    ViewBag.FK_Id_Terapeuta = new SelectList(db.Terapeuta, "Id_Terapeuta", "Id_Terapeuta", idTerapeutaRealiza);
        //    //    return View(expediente);

        //    //if (idExpediente == null)
        //    //{
        //    //    return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
        //    //}

        //    //var registros = db.Terapeuta_Realiza.ToList();
        //    //var terapeuta = null;
        //    //int idTerapeutaRealiza = 0;
        //    //for(int i = 0; i < registros.Count(); i++)
        //    //{
        //    //    if (registros[i].FK_Id_Expediente == idExpediente)
        //    //    {
        //    //        idTerapeutaRealiza = registros[i].Id_TerapeutaRealiza;
        //    //        terapeuta = registros[i].Terapeuta;

        //    //    }

        //    //}
        //    //ViewBag.Terapeuta = terapeuta;
        //    //var registros2 = db.Terapeuta_Realiza.Find(idTerapeutaRealiza);
        //    //ViewBag.FK_Id_Terapeuta = new SelectList(db.Terapeuta, "Id_Terapeuta", "Id_Terapeuta", registros2.FK_Id_Terapeuta);
        //    //return View(registros2.Expediente);

        //    //bool bandera = false;
        //    //Terapeuta terapeuta = null;
        //    //Expediente expediente2 = db.Expediente.Find(idExpediente);

        //    //for (int i = 0; i < existe.Count; i++)
        //    //{
        //    //    if (existe[i].FK_Id_Expediente == idExpediente)
        //    //    {

        //    //        bandera = true;
        //    //        terapeuta = existe[i].Terapeuta;
        //    //        break;
        //    //    }
        //    //}

        //    //if (bandera)
        //    //{
        //    //    ViewBag.Terapeuta = terapeuta;
        //    //    ViewBag.FK_Id_Terapeuta = new SelectList(db.Terapeuta, "Id_Terapeuta", "Id_Terapeuta");
        //    //    return View(expediente2);
        //    //}

        //}

        [HttpPost]
        public ActionResult AsignarTerapeuta(int? idExpediente, [Bind(Include = "Id_terapeutaRealiza,FK_Id_Terapeuta,FK_Id_Expediente")] Terapeuta_Realiza terapeuta_Realiza)
        {
            var existe = db.Terapeuta_Realiza.ToList();
            bool bandera = false;
            Terapeuta terapeuta = null;
            Expediente expediente2 = db.Expediente.Find(idExpediente);

            for (int i = 0; i < existe.Count; i++)
            {
                if (existe[i].FK_Id_Expediente == idExpediente)
                {

                    bandera = true;
                    terapeuta = existe[i].Terapeuta;
                    break;
                }
            }

            if (bandera)
            {
                ViewBag.Terapeuta = terapeuta;
                ViewBag.FK_Id_Terapeuta = new SelectList(db.Terapeuta, "Id_Terapeuta", "Id_Terapeuta", terapeuta_Realiza.FK_Id_Terapeuta);
                return View(expediente2);
            }
            else
            {
                terapeuta_Realiza.FK_Id_Terapeuta = terapeuta.Id_Terapeuta;
                terapeuta_Realiza.FK_Id_Expediente = (Int32)idExpediente;
                db.Terapeuta_Realiza.Add(terapeuta_Realiza);
                db.SaveChanges();
                ViewBag.TerapeutaRealiza = terapeuta_Realiza;
                ViewBag.Terapeuta = terapeuta;
                ViewBag.FK_Id_Terapeuta = new SelectList(db.Terapeuta, "Id_Terapeuta", "Id_Terapeuta", terapeuta_Realiza.FK_Id_Terapeuta);
                return View();
            }
        }


        //for (int i = 0; i < listaAux.Count(); i++)
        //{
        //    if (listaAux[i].FK_Id_Paciente == paciente.Id_Paciente)
        //    {
        //        db.Terapeuta_Atiende.Remove(listaAux[i]);
        //    }
        //}
        //terapeuta_Atiende.FK_Id_Paciente = paciente.Id_Paciente;
        //db.Terapeuta_Atiende.Add(terapeuta_Atiende);
        //db.SaveChanges();

        

        // GET: Expediente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Expediente/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Expediente/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Expediente/Edit/5
        [HttpPost]
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

        // GET: Expediente/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Expediente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

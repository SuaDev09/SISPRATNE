using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PTPBD.Models;
using PTPBD.Models.TableViewModels;
using PTPBD.Models.ViewModels;

namespace PTPBD.Controllers
{
    public class TerapeutaController : Controller
    {
        // GET: Terapeuta
        public ActionResult Index()
        {
            List<TerapeutaTableViewModel> list = null;
            using(var db = new PRATNEEntities())
            {
                list = db.Database.SqlQuery<TerapeutaTableViewModel>("SELECT * FROM [Terapeuta] ORDER BY [Terapeuta].Id_Terapeuta").ToList();
            }

            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TerapeutaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new PRATNEEntities())
            {
                int insert = db
                    .Database
                    .ExecuteSqlCommand("INSERT INTO [Terapeuta](Organizacion, Matricula, Universidad, Grado, Nombre, Apellido_Paterno, Apellido_Materno, Escolaridad)" +
                                        "VALUES (@Organizacion, @Matricula, @Universidad, @Grado, @Nombre, @Apellido_Paterno, @Apellido_Materno, @Escolaridad)"
                                        , new SqlParameter("@Organizacion", model.Organizacion)
                                        , new SqlParameter("@Matricula", model.Matricula)
                                        , new SqlParameter("@Universidad", model.Universidad)
                                        , new SqlParameter("@Grado", model.Grado)
                                        , new SqlParameter("@Nombre", model.Nombre)
                                        , new SqlParameter("@Apellido_Paterno", model.Apellido_Paterno)
                                        , new SqlParameter("@Apellido_Materno", model.Apellido_Materno)
                                        , new SqlParameter("@Escolaridad", model.Escolaridad));
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Terapeuta/"));
        }

        public ActionResult Edit(int Id)
        {
            EditTerapeutaViewModel model = new EditTerapeutaViewModel();


            using (var db = new PRATNEEntities())
            {
                //    // Retorna un objeto que contenga ese id
                //var list = db.Database.SqlQuery("SELECT * FROM [Terapeuta] WHERE [Terapeuta].Id_Terapeuta=@Id", new SqlParameter("@Id", Id)).();
                List<EditTerapeutaViewModel> list = null;
                list = db.Database.SqlQuery<EditTerapeutaViewModel>("SELECT * FROM [Terapeuta] WHERE Id_Terapeuta=@Id", new SqlParameter("@Id", Id)).ToList();

                model.Nombre = list.First().Nombre;
                model.Apellido_Paterno = list.First().Apellido_Paterno;
                model.Apellido_Materno = list.First().Apellido_Materno;
                model.Organizacion = list.First().Organizacion;
                model.Grado = list.First().Grado;
                model.Escolaridad = list.First().Escolaridad;
                model.Universidad = list.First().Universidad;
                model.Matricula = list.First().Matricula;
                model.Id_Terapeuta = list.First().Id_Terapeuta;

            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditTerapeutaViewModel model)
        {
            //Validar el modelo
            if (!ModelState.IsValid)
            {
                return View(model);
            }


            using (var db = new PRATNEEntities())
            {
                int insert = db
                    .Database
                    .ExecuteSqlCommand("UPDATE [Terapeuta] SET " +
                                        "Organizacion = @Organizacion, Matricula = @Matricula, Universidad = @Universidad, Grado = @Grado, Nombre = @Nombre, Apellido_Paterno = @Apellido_Paterno, Apellido_Materno = @Apellido_Materno, Escolaridad = @Escolaridad" +
                                        " WHERE Id_Terapeuta = @Id;"
                                        , new SqlParameter("@Organizacion", model.Organizacion)
                                        , new SqlParameter("@Matricula", model.Matricula)
                                        , new SqlParameter("@Universidad", model.Universidad)
                                        , new SqlParameter("@Grado", model.Grado)
                                        , new SqlParameter("@Nombre", model.Nombre)
                                        , new SqlParameter("@Apellido_Paterno", model.Apellido_Paterno)
                                        , new SqlParameter("@Apellido_Materno", model.Apellido_Materno)
                                        , new SqlParameter("@Escolaridad", model.Escolaridad)
                                        , new SqlParameter("@Id", model.Id_Terapeuta));
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Terapeuta/"));
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new PRATNEEntities())
            {
                // Retorna un objeto que contenga ese id
                //var oUser = db.user.Find(Id);
                var oUser = db.Database.ExecuteSqlCommand("DELETE FROM [Terapeuta] where [Terapeuta].Id_Terapeuta=@Id", new SqlParameter("@Id", Id));

                db.SaveChanges();
            }

            return Content("1");
        }

        public ActionResult Details(int id)
        {
            List<TerapeutaTableViewModel> list = null;
            using (var db = new PRATNEEntities())
            {
                list = db.Database.SqlQuery<TerapeutaTableViewModel>("SELECT * FROM [Terapeuta] WHERE Id_Terapeuta=@Id", new SqlParameter("@Id", id)).ToList();
            }

            return View(list);
        }

        public ActionResult VerPacientes(int id)
        {
            List<Paciente> list = null;
            using (var db = new PRATNEEntities())
            {
                list = db.Database.SqlQuery<Paciente>("SELECT * FROM [Paciente] as p INNER JOIN [Terapeuta_ATiende] as tA ON tA.FK_Id_Paciente = p.Id_Paciente AND tA.FK_Id_Terapeuta = @Id", new SqlParameter("@Id", id)).ToList();
                ViewBag.Terapeuta = db.Terapeuta.Find(id);
            }
            return View(list);
        }

    }
}
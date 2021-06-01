using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaMVC.Models;
using PruebaMVC.Models.ViewModels;

namespace PruebaMVC.Controllers
{
    public class PFController : Controller
    {
        // GET: PF
        public ActionResult Index()
        {
            List<ListTablaPF> lst;
            using (PRUEBAEntities db = new PRUEBAEntities())
            {
                lst = (from d in db.Tb_PersonasFisicas
                           select new ListTablaPF
                           {
                               _Id = d.IdPersonaFisica,
                               _FechaRegistro = d.FechaRegistro.ToString(),
                               _FechaActualizacion = d.FechaActualizacion.ToString(),
                               _Nombre = d.Nombre,
                               _ApellidoPaterno = d.ApellidoPaterno,
                               _ApellidoMaterno = d.ApellidoMaterno,
                               _RFC = d.RFC,
                               _FechaNacimiento = d.FechaNacimiento.ToString(),
                               _UsuarioAgrega = d.UsuarioAgrega.Value,
                               _Activo = d.Activo.Value
                           }).ToList();
            }
            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(TablaPF model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using(PRUEBAEntities db = new PRUEBAEntities())
                    {
                        var parsedDate = DateTime.Parse(model._FechaNacimiento);
                        db.sp_AgregarPersonaFisica(model._Nombre, model._ApellidoPaterno, model._ApellidoMaterno, 
                            model._RFC, parsedDate, model._UsuarioAgrega);
                        db.SaveChanges();
                    }
                    return Redirect("~/PF/");
                }
                return View(model);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            TablaPF model = new TablaPF();
            using (PRUEBAEntities db = new PRUEBAEntities())
            {
                var oTabla = db.Tb_PersonasFisicas.Find(id);
                model._FechaRegistro = oTabla.FechaRegistro.ToString();
                model._FechaActualizacion = oTabla.FechaActualizacion.ToString();
                model._Nombre = oTabla.Nombre;
                model._ApellidoPaterno = oTabla.ApellidoPaterno;
                model._ApellidoMaterno = oTabla.ApellidoMaterno;
                model._RFC = oTabla.RFC;
                model._FechaNacimiento = oTabla.FechaNacimiento.ToString();
                model._UsuarioAgrega = oTabla.UsuarioAgrega.Value;
                model._Activo = oTabla.Activo.Value;
                model._Id = oTabla.IdPersonaFisica;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Editar(TablaPF model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (PRUEBAEntities db = new PRUEBAEntities())
                    {
                        var parsedDate = DateTime.Parse(model._FechaNacimiento);
                        db.sp_ActualizarPersonaFisica(model._Id,model._Nombre, model._ApellidoPaterno, model._ApellidoMaterno,
                            model._RFC, parsedDate, model._UsuarioAgrega);
                        db.SaveChanges();
                    }
                    return Redirect("~/PF/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            TablaPF model = new TablaPF();
            using (PRUEBAEntities db = new PRUEBAEntities())
            {
                var oTabla = db.Tb_PersonasFisicas.Find(id);
                db.sp_EliminarPersonaFisica(oTabla.IdPersonaFisica);
            }
            return Redirect("~/PF/");
        }
    }
}
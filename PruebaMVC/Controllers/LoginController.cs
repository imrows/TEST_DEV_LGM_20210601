using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PruebaMVC.Models;
using PruebaMVC.App_Start;

namespace PruebaMVC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Verify(PruebaMVC.Models.ViewModels.Login login)
        {
            List<PruebaMVC.Models.ViewModels.Login> lst = null;
            using (PRUEBAEntities db = new PRUEBAEntities())
            {
                lst = (from d in db.Login 
                       where d.Correo == login._Correo.ToUpper()                        
                       select new PruebaMVC.Models.ViewModels.Login
                       {
                           _Id = d.Id,
                           _Correo = d.Correo,
                           _Contrasena = d.Contrasena,
                           _CveContras = d.CveContrs
                       }).ToList();
            }

            foreach(PruebaMVC.Models.ViewModels.Login l in lst)
            {
                String pwd = Util.GetInstance().generarMD5(l._CveContras + login._Contrasena);
                if (l._Contrasena.Equals(pwd))
                {
                    return Redirect("~/PF/");
                }
            }
            Response.Write("<script>alert('Contraseña Incorrecta')</script>");
            return Redirect("~/Login/Login");
        }
    }
}
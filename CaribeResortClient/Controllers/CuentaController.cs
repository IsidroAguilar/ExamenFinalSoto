using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CaribeResortLib.Models;
using System.Web.Security;
using CaribeResortLib.Auxiliar;
using System.Threading.Tasks;

namespace CaribeResortClient.Controllers
{
    public class CuentaController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Ingresar(Usuarios usuario)
        {
            try
            {
                string expresion = string.Format("Usuario = \"{0}\" And Contrasena = \"{1}\"", usuario.Nombre, usuario.Contrasena);
                Parametro[] parametros = new Parametro[] { new Parametro("expresion", expresion) };
                var resultado = await ServiceController.ConsumirServicio<List<Usuarios>>("Usuario", "ObtenerUsuarios", "GET", parametros);
                usuario = resultado.Where(u => u.Nombre == usuario.Nombre).Count() > 0 ? resultado.First() : null;
                if (usuario != null)
                {
                    // Los datos de acceso son correctos, ingresa una entrada en el log.
                    Login login = new Login();
                    login.IdUsuario = usuario.IdUsuario;
                    login.FechaHora = DateTime.Now;
                    ServiceController.ConsumirServicio<bool, Login>("Login", "CrearLogUsuario", "POST", login);
                    // Autentica al usuario y lo almacena en sesión.
                    FormsAuthentication.SetAuthCookie(usuario.Nombre, false);
                    Session["Usuario"] = usuario;
                    return Json(new { result = true, url = Url.Action("Index", "Home") });
                }
                else
                {
                    return Json(new { result = false });
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        
        public ActionResult CerrarSesion()
        {
            // Proceso de logout.
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}

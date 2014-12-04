using CaribeResortLib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace CaribeResortWebService.Controllers
{
    public class LoginController : ApiController
    {
        HotelEntities db = new HotelEntities();

        [HttpPost]
        public bool CrearLogUsuario(Login logUsuario)
        {
            try
            {
                db.Login.Add(logUsuario);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Método que cierra los procesos del Controlador
        /// </summary>
        /// <param name="disposing">Parametro bool de los procesos</param>
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
	}
}
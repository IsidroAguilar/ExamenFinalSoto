using CaribeResortClient.Models;
using CaribeResortLib.Auxiliar;
using CaribeResortLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CaribeResortClient.Controllers
{
    [AutorizarAttribute]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "ISSC 511 - Universidad de la Salle Bajío";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "ISSC 511 - Universidad de la Salle Bajío";
            return View();
        }

        public async Task<ActionResult> ObtenerPlatillos([DataSourceRequest]DataSourceRequest request)
        {
            try
            {
                var platillos = await ServiceController.ConsumirServicio<List<Platillos>>("Platillos", "ObtenerPlatillos", "GET");
                DataSourceResult result = platillos.ToDataSourceResult(request, p => new
                {
                    IdPlatillo = p.IdPlatillo,
                    NombrePlatillo = p.NombrePlatillo,
                    Descripcion = p.Descripcion
                });
                return Json(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
using CaribeResortLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CaribeResortClient.Models
{
    public class AutorizarAttribute : AuthorizeAttribute
    {
        public int IndexModulo { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            // Verificar Autorización.
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (isAuthorized)
            {
                // Verificar sesión.
                if (httpContext.Session["Usuario"] != null)
                {
                    Usuarios usuario = (Usuarios)httpContext.Session["Usuario"];

                    // TEMPORAL PRIVILEGIOS
                    // Verificcar si el usuario esta autenticado para el módulo.
                    //if (priv[indexModulo - 1] == 1)
                    //{
                    return true;
                    //}
                    //else
                    //{
                    //    return false;
                    //}                    
                }
                else
                {
                    // Si no existe la sesión enviar nuevamente al login.
                    return false;
                }
            }
            else
            {
                // Si no esta autorizado enviar al login.
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Cuenta", action = "Index" }));
        }

    }
}
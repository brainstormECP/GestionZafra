using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionZafra.Filters
{
    [HandleError]
    public class InicioZafraRequerido : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var db = new GestionZafra.Models.Entities();
            var param = db.ParametrosGenerales.First();
            if (param.Zafras.fechaFin != null)
            {
                throw new Exception("Debe iniciar una Zafra para que la aplicación funcione");
            }
        }
    }
}
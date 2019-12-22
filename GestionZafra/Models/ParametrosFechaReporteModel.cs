using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionZafra.Filters;

namespace GestionZafra.Models
{
    public class ParametrosFechaReporteModel
    {
        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.Date, ErrorMessage = "Este campo debe ser una fecha")]
        [Remote("CheckFechaInicio", "Reportes", ErrorMessage = "Esta fecha esta fuera del rango de la zafra actual")]
        public DateTime? FechaInicio { get; set; }

        [Display(Name = "Fecha de Fin")]
        [FechaMayorQue("FechaInicio")]
        [DataType(DataType.Date,ErrorMessage = "Este campo debe ser una fecha")]
        [Remote("CheckFechaFin", "Reportes", ErrorMessage = "Esta fecha esta fuera del rango de la zafra actual")]
        public DateTime? FechaFin { get; set; }
    }
}
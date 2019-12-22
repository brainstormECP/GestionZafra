using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionZafra.Filters;

namespace GestionZafra.Models
{
    public class HistoricoModel
    {
        [Display(Name = "Zafras")]
        public int Zafraid { get; set; }

        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.Date)]
        [Remote("CheckFechaInicioHistorico", "Reportes", AdditionalFields = "Zafraid", ErrorMessage = "Esta fecha no se encuentra dentro del periodo de esta zafra")]
        public DateTime? FechaInicio { get; set; }

        [Display(Name = "Fecha de Fin")]
        [FechaMayorQue("FechaInicio")]
        [DataType(DataType.Date)]
        [Remote("CheckFechaFinHistorico", "Reportes", AdditionalFields = "Zafraid", ErrorMessage = "Esta fecha no se encuentra dentro del periodo de esta zafra")]
        public DateTime? FechaFin { get; set; }

        [Display(Name = "Reportes")]
        [Required(ErrorMessage = "Este Campo es Obligatorio")]
        public string Reporte { get; set; }

    }
}
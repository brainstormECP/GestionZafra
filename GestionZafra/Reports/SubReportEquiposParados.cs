using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace GestionZafra.Reports
{
    public partial class SubReportEquiposParados : DevExpress.XtraReports.UI.XtraReport
    {
        public SubReportEquiposParados()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            //Datos
            var db = new Models.Entities();
            var idSuministrador = SumID.Value.ToString();
            var fecha = (DateTime)FechaActual.Value;
            var idZafra = int.Parse(Zafra.Value.ToString());

            var diariosHoy = db.DiarioEquiposZafra.Where(i => i.Zafrasid == idZafra  
                && i.PlanEquiposAgricZafra.ParqueEquipos.Suministradores.nombreSuministrador == idSuministrador && i.fecha == fecha).ToList();
           
            var equiposParados = from dia in diariosHoy
                               group dia by dia.PlanEquiposAgricZafra.ParqueEquipos.TipoEquipos.descripcionEquipo
                                   into diarioGroup
                                   select new
                                   {
                                       tipoEquipo = diarioGroup.Key,
                                       parados = diarioGroup.Sum(i => i.parqueParado)
                                   };
            //Fin Datos

            //Enlazando datos
            DataSource = equiposParados.ToList();

            this.Equipo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tipoEquipo")});

            this.paradosCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "parados")});

            totalParadosCell.Text = equiposParados.Sum(u => u.parados).ToString();

            //fin de enlace
        }

    }
}

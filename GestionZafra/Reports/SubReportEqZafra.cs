using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace GestionZafra.Reports
{
    public partial class SubReportEqZafra : DevExpress.XtraReports.UI.XtraReport
    {
        public SubReportEqZafra()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            //Datos
            var db = new Models.Entities();
            var suministrador = SumID.Value.ToString();
            var paramGen = db.ParametrosGenerales.ToArray();
            var param = paramGen.First();
            var idZafra = int.Parse(Zafra.Value.ToString());
            var zafra = db.DiarioEquiposZafra.Where(i => i.Zafrasid == idZafra  
                && i.PlanEquiposAgricZafra.ParqueEquipos.Suministradores.nombreSuministrador == suministrador).ToList();
           
            var diarioGroups = from dia in zafra
                               group dia by dia.PlanEquiposAgricZafra.ParqueEquipos.TipoEquipos.descripcionEquipo
                                   into diarioGroup
                                   select new
                                   {
                                       tipoEquipo = diarioGroup.Key,
                                       acumulado = diarioGroup.Sum(i => i.arrobasTiradas),
                                       plan = diarioGroup.Sum(i => i.PlanEquiposAgricZafra.tareaDiaria),
                                       periodo = diarioGroup.Where(i => i.fecha >= (DateTime)fechaInicio.Value && i.fecha <= (DateTime)fechaFin.Value)
                                       .Sum(i => i.arrobasTiradas)
                                   };
            //Fin Datos

            //Enlazando datos
            DataSource = diarioGroups;

            this.Equipo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tipoEquipo")});

            this.planCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "plan")});

            this.periodoCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "periodo")});

            this.acumCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "acumulado")});

            totalPlanCell.Text = diarioGroups.Sum(u => u.plan).ToString();
            totalPeriodoCell.Text = diarioGroups.Sum(u => u.periodo).ToString();
            totalAcumCell.Text = diarioGroups.Sum(u => u.acumulado).ToString();

            //fin de enlace
        }

    }
}

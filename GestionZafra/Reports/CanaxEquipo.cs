using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;


namespace GestionZafra.Reports
{
    public partial class CanaxEquipo : DevExpress.XtraReports.UI.XtraReport
    {
        public CanaxEquipo()
        {
            InitializeComponent();
            // Info de los parametros
            var db = new Models.Entities();
            var paramGen = db.ParametrosGenerales.ToArray();
            
            this.emprezaLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", paramGen, "nombreEmpresa")});

            this.fechaLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", paramGen, "fechaActual", "{0:dd/MM/yyyy}")});
            //fin Info de los parametros
            xrSubreport1.ReportSource = new SubReportEqZafra();
        }

        public void CargarDatos()
        {
            var db = new Models.Entities();
            var paramGen = db.ParametrosGenerales.ToArray();
            //Datos
            var idZafra = int.Parse(Zafra.Value.ToString());
            var zafra = db.Zafras.Find(idZafra);

            this.zafraLabel.DataBindings.AddRange(new[] {new XRBinding("Text", zafra, "descripcionZafra")});

            var zafras = db.DiarioEquiposZafra.Where(i => i.Zafrasid == idZafra).ToList();

            var diarioGroups = from dia in zafras
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
            //Fi Datos

            //Enlazando datos
            DataSource = db.Suministradores.ToList();

            this.suministradorCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nombreSuministrador")});

            totalPlan.Text = diarioGroups.Sum(u => u.plan).ToString();
            totalPeriodo.Text = diarioGroups.Sum(u => u.periodo).ToString();
            totalAcum.Text = diarioGroups.Sum(u => u.acumulado).ToString();
            //fin de enlace
        }

        private void xrSubreport1_BeforePrint(object sender, PrintEventArgs e)
        {
            var report = ((SubReportEqZafra)((XRSubreport)sender).ReportSource);
            report.SumID.Value = GetCurrentColumnValue("nombreSuministrador").ToString();
            report.fechaInicio = fechaInicio;
            report.fechaFin = fechaFin;
            report.Zafra = Zafra;
            report.CargarDatos();
        }

    }
}

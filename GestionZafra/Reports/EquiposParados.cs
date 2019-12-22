using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;


namespace GestionZafra.Reports
{
    public partial class EquiposParados : DevExpress.XtraReports.UI.XtraReport
    {
        public EquiposParados()
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
            xrSubreport1.ReportSource = new SubReportEquiposParados();
        }

        public void CargarDatos()
        {
            var db = new Models.Entities();
            var paramGen = db.ParametrosGenerales.ToArray();
            //Datos

            var fecha = (DateTime)FechaActual.Value;
            var idZafra = int.Parse(Zafra.Value.ToString());

           
            var zafra = db.Zafras.Find(idZafra);

            this.zafraLabel.DataBindings.AddRange(new[] {new XRBinding("Text", zafra, "descripcionZafra")});

            var diariosHoy = db.DiarioEquiposZafra.Where(i => i.Zafrasid == idZafra && i.fecha == fecha).ToList();

            var equiposParados = from dia in diariosHoy
                                 group dia by dia.PlanEquiposAgricZafra.ParqueEquipos.TipoEquipos.descripcionEquipo
                                     into diarioGroup
                                     select new
                                     {
                                         tipoEquipo = diarioGroup.Key,
                                         parados = diarioGroup.Sum(i => i.parqueParado)
                                     };


            //Fi Datos

            //Enlazando datos
            DataSource = db.Suministradores.ToList();

            this.suministradorCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nombreSuministrador")});

            totalPlan.Text = equiposParados.Sum(u => u.parados).ToString();
            //fin de enlace
        }

        private void xrSubreport1_BeforePrint(object sender, PrintEventArgs e)
        {
            var report = ((SubReportEquiposParados)((XRSubreport)sender).ReportSource);
            report.SumID.Value = GetCurrentColumnValue("nombreSuministrador").ToString();
            report.FechaActual = FechaActual;
            report.Zafra = Zafra;
            report.CargarDatos();
        }

    }
}

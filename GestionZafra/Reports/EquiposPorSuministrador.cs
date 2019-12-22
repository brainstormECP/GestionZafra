using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace GestionZafra.Reports
{
    public partial class EquiposPorSuministrador : DevExpress.XtraReports.UI.XtraReport
    {
        public EquiposPorSuministrador()
        {
            InitializeComponent();
            // Info de los parametros
            var db = new Models.Entities();
            var paramGen = db.ParametrosGenerales.ToArray();

            this.zafraLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", paramGen, "Zafras.descripcionZafra")});

            this.emprezaLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", paramGen, "nombreEmpresa")});

            this.fechaLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", paramGen, "fechaActual", "{0:dd/MM/yyyy}")});
            //fin Info de los parametros

            xrSubreport1.ReportSource = new SubReportTipoEqExitente();

            DataSource = db.Suministradores.ToList();

            this.suministradorCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nombreSuministrador")});
        }

        private void xrSubreport1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            var report = ((SubReportTipoEqExitente)((XRSubreport)sender).ReportSource);
            report.SumID.Value = GetCurrentColumnValue("nombreSuministrador").ToString();
            report.CargarDatos();
        }

    }
}

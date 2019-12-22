using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;


namespace GestionZafra.Reports
{
    public partial class CanaxOperador : DevExpress.XtraReports.UI.XtraReport
    {
        public CanaxOperador()
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
            xrSubreport1.ReportSource = new SubReportOperadores();
        }

        public void CargarDatos()
        {
            var db = new Models.Entities();
            var paramGen = db.ParametrosGenerales.ToArray();
            //Datos
            var idZafra = int.Parse(Zafra.Value.ToString());
            var z = db.Zafras.Find(idZafra);

            this.zafraLabel.DataBindings.AddRange(new[] {new XRBinding("Text", z, "descripcionZafra")});

            var zafra = db.DiarioOperadorCombinadas.Where(i => i.Zafrasid == idZafra).ToList();

            var diarioGroups = from dia in zafra
                               group dia by dia.PlanOperadoresCombinadas.OperadorCombinada.nombreOperador
                                   into diarioGroup
                                   select new
                                   {
                                       operador = diarioGroup.Key,
                                       acumulado = diarioGroup.Sum(i => i.cantVerde) + diarioGroup.Sum(i => i.cantQuemada) + diarioGroup.Sum(i => i.cantQuemadaProgram),
                                       plan = diarioGroup.Sum(i => i.PlanOperadoresCombinadas.tareaDiaria),
                                       periodo = diarioGroup.Where(i => i.fecha >= (DateTime)fechaInicio.Value && i.fecha <= (DateTime)fechaFin.Value)
                                       .Sum(i => i.cantVerde)
                                       + diarioGroup.Where(i => i.fecha >= (DateTime)fechaInicio.Value && i.fecha <= (DateTime)fechaFin.Value)
                                       .Sum(i => i.cantQuemada)
                                       + diarioGroup.Where(i => i.fecha >= (DateTime)fechaInicio.Value && i.fecha <= (DateTime)fechaFin.Value)
                                       .Sum(i => i.cantQuemadaProgram)
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
            var report = ((SubReportOperadores)((XRSubreport)sender).ReportSource);
            report.SumID.Value = GetCurrentColumnValue("nombreSuministrador").ToString();
            report.fechaInicio = fechaInicio;
            report.fechaFin = fechaFin;
            report.Zafra = Zafra;
            report.CargarDatos();
        }

    }
}

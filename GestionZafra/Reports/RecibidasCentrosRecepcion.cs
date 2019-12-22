using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;


namespace GestionZafra.Reports
{
    public partial class RecibidasCentrosRecepcion : DevExpress.XtraReports.UI.XtraReport
    {
        public RecibidasCentrosRecepcion()
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
        }

        public void CargarDatos()
        {
            var db = new Models.Entities();
            var paramGen = db.ParametrosGenerales.ToArray();
            int zafraid = int.Parse(Parameters["Zafra"].Value.ToString());
            var Zafra = db.Zafras.Find(zafraid);

            this.zafraLabel.Text = Zafra.descripcionZafra; 
            //Datos
            var param = paramGen.First();
            var zafra = db.DiarioEquiposZafra.Where(i => i.Zafrasid == zafraid).ToList();

            var result = from dia in zafra
                               group dia by dia.PlanEquiposAgricZafra.CentrosRecepcion.nombreCentroRecepcion
                                   into diarioGroup
                                   select new
                                   {
                                       suministrador = diarioGroup.Key,
                                       acumulado = diarioGroup.Sum(i => i.arrobasTiradas),
                                       plan = diarioGroup.Sum(i => i.PlanEquiposAgricZafra.tareaDiaria),
                                       periodo = diarioGroup.Where(i => i.fecha >= (DateTime)fechaInicio.Value && i.fecha <= (DateTime)fechaFin.Value).Sum(i => i.arrobasTiradas)
                                   };
            //Fi Datos

            //Enlazando datos
            DataSource = result.ToList();

            this.centroCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "suministrador")});

            this.planCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "plan")});

            this.periodoCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "periodo")});

            this.acumuladaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "acumulado")});

            totalPlan.Text = result.Sum(u => u.plan).ToString();
            totalPeriodo.Text = result.Sum(u => u.periodo).ToString();
            totalAcum.Text = result.Sum(u => u.acumulado).ToString();
            //fin de enlace
        }
    }
}

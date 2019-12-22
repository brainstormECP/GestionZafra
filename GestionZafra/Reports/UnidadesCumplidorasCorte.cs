using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;


namespace GestionZafra.Reports
{
    public partial class UnidadesCumplidorasCorte : DevExpress.XtraReports.UI.XtraReport
    {
        public UnidadesCumplidorasCorte()
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
            var paramGen = db.ParametrosGenerales.First();
            //Datos
            var idZafra = int.Parse(Zafra.Value.ToString());
            var z = db.Zafras.Find(idZafra);

            fechaInicio.Value = z.fechaInicio;
            fechaFin.Value = z.fechaFin;
            if (idZafra == paramGen.zafraAct)
            {
                fechaFin.Value = paramGen.fechaActual;
            }

            

            this.zafraLabel.DataBindings.AddRange(new[] {new XRBinding("Text", z, "descripcionZafra")});

            var zafra = db.DiarioOperadorCombinadas.Where(i => i.Zafrasid == idZafra).ToList();

            var diarioGroups = from dia in zafra
                               group dia by dia.PlanOperadoresCombinadas.OperadorCombinada.PelotonCombinadas.Suministradores.nombreSuministrador
                                   into diarioGroup
                                   select new
                                   {
                                       unidad = diarioGroup.Key,
                                       cortada = diarioGroup.Sum(i => i.cantVerde) + diarioGroup.Sum(i => i.cantQuemada) + diarioGroup.Sum(i => i.cantQuemadaProgram),
                                       plan = diarioGroup.Sum(i => i.PlanOperadoresCombinadas.tareaDiaria)
                                   };

            var result = from unidad in diarioGroups where unidad.cortada >= unidad.plan select unidad;
            
            //Fi Datos

            //Enlazando datos
            DataSource = result.ToList();

            this.suministradorCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "unidad")});

            this.planCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "plan")});

            this.cortadaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cortada")});

            totalPlan.Text = result.Sum(u => u.plan).ToString();
            totalCortada.Text = result.Sum(u => u.cortada).ToString();
            //fin de enlace
        }
    }
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;


namespace GestionZafra.Reports
{
    public partial class CortadaPorOperador : DevExpress.XtraReports.UI.XtraReport
    {
        public CortadaPorOperador()
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
        }

        public void CargarDatos()
        {
            var db = new Models.Entities();
            var paramGen = db.ParametrosGenerales.ToArray();
            //Datos
            var param = paramGen.First();
            var zafra = db.DiarioOperadorCombinadas.Where(i => i.Zafrasid == param.zafraAct).ToList();
            var peloton = db.PelotonCombinadas.ToList();

            var diaOp = from z in zafra
                        select new
                        {
                            suministrador = z.PlanOperadoresCombinadas.OperadorCombinada.PelotonCombinadas.Suministradores.nombreSuministrador,
                            cortada = z.cantQuemada + z.cantQuemadaProgram + z.cantVerde,
                            plan = z.PlanOperadoresCombinadas.tareaDiaria,
                            z.fecha
                        };

            var diarioGroups = from dia in diaOp
                               group dia by dia.suministrador
                                   into diarioGroup
                                   select new
                                   {
                                       suministrador = diarioGroup.Key,
                                       acumulado = diarioGroup.Sum(i => i.cortada),
                                       plan = diarioGroup.Sum(i => i.plan),
                                       periodo = diarioGroup.Where(i => i.fecha >= (DateTime)fechaInicio.Value && i.fecha <= (DateTime)fechaFin.Value).Sum(i => i.cortada)
                                   };
            var result = from d in diarioGroups
                         join p in peloton on d.suministrador equals p.Suministradores.nombreSuministrador
                             select new {d.suministrador, cantComb = p.parque, d.plan,d.periodo ,d.acumulado}; 
            
            //Fi Datos

            //Enlazando datos
            DataSource = result.ToList();

            this.suministradorCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "suministrador")});

            this.cantCombCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cantComb")});

            this.planCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "plan")});

            this.periodoCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "periodo")});

            this.acumuladaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "acumulado")});

            totalPlan.Text = result.Sum(u => u.plan).ToString();
            totalPeriodo.Text = result.Sum(u => u.periodo).ToString();
            totalAcum.Text = result.Sum(u => u.acumulado).ToString();
            totalComb.Text = result.Sum(u => u.cantComb).ToString();
            //fin de enlace
        }
    }
}

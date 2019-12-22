using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace GestionZafra.Reports
{
    public partial class SubReportOperadores : DevExpress.XtraReports.UI.XtraReport
    {
        public SubReportOperadores()
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

            var zafra = db.DiarioOperadorCombinadas.Where(i => i.Zafrasid == idZafra  
                && i.PlanOperadoresCombinadas.OperadorCombinada.PelotonCombinadas.Suministradores.nombreSuministrador == suministrador).ToList();
           
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
            //Fin Datos

            //Enlazando datos
            DataSource = diarioGroups;

            this.operadorCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "operador")});

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

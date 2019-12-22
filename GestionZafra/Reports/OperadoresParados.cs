using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;
using System.Drawing.Printing;


namespace GestionZafra.Reports
{
    public partial class OperadoresParados : DevExpress.XtraReports.UI.XtraReport
    {
        public OperadoresParados()
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
            //Datos

            var fecha = (DateTime)FechaActual.Value;
            var idZafra = int.Parse(Zafra.Value.ToString());

           
            var zafra = db.Zafras.Find(idZafra);

            this.zafraLabel.DataBindings.AddRange(new[] {new XRBinding("Text", zafra, "descripcionZafra")});

            var diariosHoy = db.DiarioOperadorCombinadas.Where(i => i.Zafrasid == idZafra && i.fecha == fecha).ToList();

            var equiposParados = from dia in diariosHoy 
                                 where dia.EstadoEquipo.nombreEstado == "Roto"
                                     select new
                                     {
                                         operador = dia.PlanOperadoresCombinadas.OperadorCombinada.nombreOperador,
                                         peloton = dia.PlanOperadoresCombinadas.OperadorCombinada.PelotonCombinadas.Suministradores.nombreSuministrador
                                     };

            //Fi Datos

            //Enlazando datos
            DataSource = equiposParados.ToList();

            this.operadorCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "operador")});

            this.pelotonCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "peloton")});

            totalParados.Text = equiposParados.Count().ToString();
            //fin de enlace
        }
    }
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace GestionZafra.Reports
{
    public partial class DiarioCentrosRecepcion : DevExpress.XtraReports.UI.XtraReport
    {
        public DiarioCentrosRecepcion()
        {
            InitializeComponent();
            // Mi codigo personalizado
            var db = new Models.Entities();
            var paramGen = db.ParametrosGenerales.ToArray();
            this.DataSource = paramGen;

            this.zafraLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "Zafras.descripcionZafra")});

            this.emprezaLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nombreEmpresa")});

            this.fechaLabel.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "fechaActual", "{0:dd/MM/yyyy}")});
            //fin de mi codigo
            //datos del reporte
            var d = db.DiarioEquiposZafra.ToArray();
            


            this.suministradorCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text",d , "PlanEquiposAgricZafra.ParqueEquipos.Suministradores")});
        }

    }
}

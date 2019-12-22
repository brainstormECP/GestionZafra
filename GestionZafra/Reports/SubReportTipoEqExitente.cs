using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace GestionZafra.Reports
{
    public partial class SubReportTipoEqExitente : DevExpress.XtraReports.UI.XtraReport
    {
        public SubReportTipoEqExitente()
        {
            InitializeComponent();
        }

        public void CargarDatos()
        {
            //Datos
            var db = new Models.Entities();
            var suministrador = SumID.Value.ToString();
            var zafra = db.ParqueEquipos.Where(i => i.Suministradores.nombreSuministrador == suministrador).ToList();

            var diarioGroups = from dia in zafra
                                   select new
                                   {
                                       tipoEquipo = dia.TipoEquipos.descripcionEquipo,
                                       cantidad = dia.cantidadEquipos
                                   };
            //Fin Datos

            //Enlazando datos
            DataSource = diarioGroups;

            this.Equipo.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tipoEquipo")});

            this.cantEquiposCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cantidad")});

            totalEquiposCell.Text = diarioGroups.Sum(u => u.cantidad).ToString();
            

            //fin de enlace
        }

    }
}

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using DevExpress.XtraReports.UI;

namespace GestionZafra.Reports
{
    public partial class Campos : DevExpress.XtraReports.UI.XtraReport
    {
        public Campos()
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


            //Datos
            var campos = from c in db.Campo select new {campo = c.Suministradores.nombreSuministrador, verde = c.cantCanaVerde, quemada = c.cantCanaQuemada,c.cepa,c.VariedadCana.nombreVariedad};
            //Fin datos

            //Enlazando datos
            DataSource = campos.ToList();

            this.campoCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "campo")});

            this.canaVerdeCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "verde")});

            this.canaQuemadaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "quemada")});


            this.cepaCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "cepa")});

            this.variedadCell.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "nombreVariedad")});


            totalVerdeCell.Text = campos.Sum(u => u.verde).ToString();
            totalQuemadaCell.Text = campos.Sum(u => u.quemada).ToString();
            //fin de enlace
        }

    }
}

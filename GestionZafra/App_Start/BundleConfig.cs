using System.Web;
using System.Web.Optimization;

namespace GestionZafra
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap.plugings").Include(
                "~/Scripts/affix.js",
                "~/Scripts/alert.js",
                "~/Scripts/button.js",
                "~/Scripts/carousel.js",
                "~/Scripts/collapse.js",
                "~/Scripts/dropdown.js",
                "~/Scripts/modal.js",
                "~/Scripts/popover.js",
                "~/Scripts/scrollspy.js",
                "~/Scripts/tab.js",
                "~/Scripts/tooltip.js",
                "~/Scripts/transition.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/theme/base/css").Include(
                        "~/Content/theme/base/jquery.ui.core.css",
                        "~/Content/theme/base/jquery.ui.resizable.css",
                        "~/Content/theme/base/jquery.ui.selectable.css",
                        "~/Content/theme/base/jquery.ui.accordion.css",
                        "~/Content/theme/base/jquery.ui.autocomplete.css",
                        "~/Content/theme/base/jquery.ui.button.css",
                        "~/Content/theme/base/jquery.ui.dialog.css",
                        "~/Content/theme/base/jquery.ui.slider.css",
                        "~/Content/theme/base/jquery.ui.tabs.css",
                        "~/Content/theme/base/jquery.ui.datepicker.css",
                        "~/Content/theme/base/jquery.ui.progressbar.css",
                        "~/Content/theme/base/jquery.ui.theme.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                
                 "~/Content/Bootstrap/css/bootstrap.min.css"));
            bundles.Add(new StyleBundle("~/Content/bootstrap-theme").Include(
                "~/Content/Bootstrap/css/bootstrap-theme.css"));
            bundles.Add(new ScriptBundle("~/Scripts/theme").Include(
                "~/Content/js/plugins/jquery/jquery-1.9.1.min.js",
                "~/Content/js/plugins/jquery/jquery-ui-1.10.1.custom.min.js",
                "~/Content/js/plugins/jquery/jquery-migrate-1.1.1.min.js",
                "~/Content/js/plugins/jquery/globalize.js",
                "~/Content/js/plugins/other/excanvas.js",
                "~/Content/js/plugins/other/jquery.mousewheel.min.js",
                "~/Content/js/plugins/bootstrap/bootstrap.min.js",
                "~/Content/js/plugins/cookies/jquery.cookies.2.2.0.min.js",
                "~/Content/js/plugins/jflot/jquery.flot.js",
                "~/Content/js/plugins/jflot/jquery.flot.stack.js",
                "~/Content/js/plugins/jflot/jquery.flot.pie.js",
                "~/Content/js/plugins/jflot/jquery.flot.resize.js",
                "~/Content/js/plugins/sparklines/jquery.sparkline.min.js",
                "~/Content/js/plugins/mcustomscrollbar/jquery.mCustomScrollbar.min.js",
                "~/Content/js/plugins/datatables/jquery.dataTables.min.js",
                "~/Content/js/plugins/uniform/jquery.uniform.min.js",
                "~/Content/js/plugins/shbrush/XRegExp.js",
                "~/Content/js/plugins/shbrush/shCore.js",
                "~/Content/js/plugins/shbrush/shBrushXml.js",
                "~/Content/js/plugins/shbrush/shBrushJScript.js",
                "~/Content/js/plugins/shbrush/shBrushCss.js",
                "~/Content/js/plugins.js",
                "~/Content/js/charts.js",
                "~/Content/js/actions.js"));
            bundles.Add(new StyleBundle("~/Content/theme").Include(
                "~/Content/css/stylesheets.css"));
        }
    }
}
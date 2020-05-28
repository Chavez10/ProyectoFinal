﻿using System.Web;
using System.Web.Optimization;

namespace ReservaDeVuelos
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //NO TOCAR
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));
            //NO TOCAR
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));
            //NO TOCAR
            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            //NO TOCAR
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));
            //TRABAJAR
            bundles.Add(new ScriptBundle("~/bundles/jsQuery").Include(
                "~/assets1/js/jquery-{version}.min.js",
                ""
                ));

            //TRABAJAR
            bundles.Add(new ScriptBundle("~/bundles/Bootstrap").Include(
                ""
                ));

            //TRABAJAR
            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                ""
                ));

            //NO TOCAR
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            //TRABAJAR
            bundles.Add(new StyleBundle("~/assets1/css").Include(
                "~/assets1/css/animate.css",
                ""
                ));
        }
    }
}

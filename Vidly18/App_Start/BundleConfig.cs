﻿using System.Web;
using System.Web.Optimization;

namespace Vidly18
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/DataTables-1.10.0/jquery.dataTables.js",
                        "~/Scripts/DataTables-1.10.0/dataTables.bootstrap.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/jquery.easy-autocomplete.js",
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/toastr.css",
                      "~/Content/easy-autocomplete.css",
                      "~/Content/DataTables-1.10.0/css/datatables.bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}

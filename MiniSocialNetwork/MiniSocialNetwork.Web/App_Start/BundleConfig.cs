using System.Web;
using System.Web.Optimization;

namespace MiniSocialNetwork.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/materialize").Include(
                "~/node_modules/materialize-css/dist/js/materialize.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/node_modules/jquery/dist/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                "~/Scripts/jquery.signalR-2.2.2.min.js",
                "~/signalr/hubs"));

            bundles.Add(new ScriptBundle("~/bundles/main").Include(
                "~/public/bundle.js"));
        }
    }
}

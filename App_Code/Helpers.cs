using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;
using System.Web.Hosting;

namespace roessner
{
    public static class Helpers
    {

        public static void AuthenticateAdmin(this HttpContext Context) {
            if (Context == null)
                throw new ArgumentNullException("Context");
            if (Context.Session == null)
                throw new ArgumentNullException("Context.Session");
            string user = (string)Context.Session["user"] ?? "";
            string pass = (string)Context.Session["pass"] ?? "";
            if ((user == "bherila" && pass == "eggbert") ||
                (user == "roessner" && pass == "lesley")) {

                return; // valid user
            }
            Context.Session["return"] = Context.Request.RawUrl;
            Context.Response.Redirect("AdminLogin.aspx?rid=" + Guid.NewGuid().ToString("N"), true);
        }

        private static string DataFile {
            get { return HostingEnvironment.MapPath("/App_Data/Pages.json.txt"); }
        }

        private static string NavigationFile {
            get { return HostingEnvironment.MapPath("/App_Data/Nav.json.txt"); }
        }

        private static string DataFileContents {
            get { return File.ReadAllText(DataFile); }
            set { File.WriteAllText(DataFile, value); }
        }

        public static List<ContentItem> GetContentItems() {
            var fc = (List<ContentItem>)HostingEnvironment.Cache["ci"];
            if (fc == null) {
                fc = JsonConvert.DeserializeObject<List<ContentItem>>(DataFileContents);
                HostingEnvironment.Cache.Add("ci", fc, null, DateTime.Now.AddSeconds(5), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, null);
                return fc ?? new List<ContentItem>();
            }
            else return fc;
        }

        public static void SaveContentItems(List<ContentItem> items) {
            HostingEnvironment.Cache.Remove("ci");
            DataFileContents = JsonConvert.SerializeObject(items, Formatting.Indented);
        }

        public static List<Navigation> GetNavigation() {
            if (File.Exists(NavigationFile)) {
                List<Navigation> ds = JsonConvert.DeserializeObject<List<Navigation>>(File.ReadAllText(NavigationFile));
                return ds;
            }
            else {
                return DefaultNavigation.topnav;
            }
        }

        public static void SaveNavigation(List<Navigation> navitems) {
            var fc = JsonConvert.SerializeObject(navitems);
            File.WriteAllText(NavigationFile, fc);
        }

        public static string GetContentURL(string name) {
            return "/" + name;
        }
    }
}
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
        private static string DataFile {
            get { return HostingEnvironment.MapPath("/App_Data/Pages.json.txt"); }
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

        public static string GetContentURL(string name) {
            return "/Content.aspx?id=" + name;
        }
    }
}
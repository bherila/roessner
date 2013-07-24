using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace roessner
{
    [JsonObject(MemberSerialization.OptOut)]
    public class Navigation
    {
        public string text { get; set; }
        public string contentid { get; set; }
        public List<Navigation> subitems { get; set; }
    }


    public static class DefaultNavigation
    {
        public static List<Navigation> topnav = new List<Navigation> {
            new Navigation() { contentid = "about-us", text = "About Us", subitems = new List<Navigation> {
                new Navigation() { contentid = "video", text = "Our Video" },
                new Navigation() { contentid = "clients", text = "Clients" }
            }}, 
            new Navigation() { contentid = "publication-design", text = "Publication Design", subitems = new List<Navigation> {
                new Navigation() { contentid = "annual-reports", text = "Annual Reports" },
                new Navigation() { contentid = "newsletters", text = "Newsletters" }, 
                new Navigation() { contentid = "illustration", text = "Illustration" }
            }},
            new Navigation() { contentid = "branding-design", text = "Branding Design" }, 
            new Navigation() { contentid = "web-design", text = "Web Design" }, 
            new Navigation() { contentid = "marketing-design", text = "Marketing Design", subitems = new List<Navigation> {
                new Navigation() { contentid = "brochures", text = "Brochures" }, 
                new Navigation() { contentid = "folders", text = "Folders"},
                new Navigation() { contentid = "advertising", text = "Advertising" },
                new Navigation() { contentid = "campaigns", text = "Campaigns" }
            }}, 
            new Navigation() { contentid = "event-graphics", text = "Event Graphics" },
            new Navigation() { contentid = "video-production", text = "Video Production" }, 
            new Navigation() { contentid = "contact", text = "Contact Us" }
        };
    }

}
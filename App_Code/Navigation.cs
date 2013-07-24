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
                new Navigation() { contentid = "about-us", text="Who We Are" },
                new Navigation() { contentid = "video", text = "Our Video" },
                new Navigation() { contentid = "clients", text = "Clients" },
                new Navigation() { contentid="testimonials", text = "Testimonials" },
            }}, 
            new Navigation() { contentid = "annual-reports-iridium-2011", text = "Publication Design", subitems = new List<Navigation> {
                new Navigation() { contentid = "annual-reports-iridium-2011", text = "Annual Reports" },
                new Navigation() { contentid = "newsletters-fhcds-magazine-design", text = "Newsletters" }, 
                new Navigation() { contentid = "illustration-design", text = "Illustration" }
            }},
            new Navigation() { contentid = "branding-design", text = "Branding Design" }, 
            new Navigation() { contentid = "bd-online-annual-report-web-design", text = "Web Design" }, 
            new Navigation() { contentid = "bcn-telecom-brochure", text = "Marketing Design", subitems = new List<Navigation> {
                new Navigation() { contentid = "bcn-telecom-brochure", text = "Brochures" }, 
                new Navigation() { contentid = "prudential-folder", text = "Folders"},
                new Navigation() { contentid = "bcn-telecom-ad-campaign", text = "Advertising" }
            }}, 
            new Navigation() { contentid = "marist-capital-campaign-collateral-design", text = "Event Graphics" },
            new Navigation() { contentid = "honeywell-video-production-design", text = "Video Production" }, 
            new Navigation() { contentid = "contact", text = "Contact Us" }
        };
    }

}
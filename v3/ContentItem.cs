using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace roessner
{

    [JsonObject(MemberSerialization.OptOut)]
    public class ContentItem
    {

        public string title { get; set; }
        public string body { get; set; }
        public string img { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public int l1order { get; set; }
        public int l2order { get; set; }
    }
}
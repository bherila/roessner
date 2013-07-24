using System.Collections.Generic;
using System.Xml.Serialization;

namespace Subtext.Web.SiteMap
{
    [XmlType(Namespace = "http://www.google.com/schemas/sitemap/0.84", TypeName = "urlset")]
    [XmlRootAttribute(Namespace = "http://www.google.com/schemas/sitemap/0.84", ElementName = "urlset", IsNullable = false)]
    public class UrlCollection : List<Url> { }
}

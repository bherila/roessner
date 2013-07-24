<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sitemap.aspx.cs" Inherits="roessner.Sitemap" %>
<%@ Import Namespace="Subtext.Web.SiteMap" %>
<%@ Import Namespace="System.Xml.Serialization" %>
<%@ Import Namespace="System.Xml" %>
<%@ Import Namespace="System.IO" %>
<script runat="server">

    public void GenerateSitemap(HttpContext context) {
        context.Response.ContentType = "text/xml";

        UrlCollection urlCollection = new UrlCollection();

        var items = roessner.Helpers.GetContentItems();
        foreach (var item in items) {
            DateTime modified = item.modified.HasValue ? item.modified.Value : DateTime.Now;
            Uri pageUri = new Uri(Request.Url.GetLeftPart(UriPartial.Authority) + roessner.Helpers.GetContentURL(item.name));
            urlCollection.Add(new Url(pageUri, modified, ChangeFrequency.Weekly, (decimal)0.5));
        }

        XmlSerializer serializer = new XmlSerializer(typeof(UrlCollection));
        XmlTextWriter xmlTextWriter = new XmlTextWriter(context.Response.OutputStream, Encoding.UTF8);
        serializer.Serialize(xmlTextWriter, urlCollection);

    }

    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        GenerateSitemap(Context);
    }
    
    
</script>
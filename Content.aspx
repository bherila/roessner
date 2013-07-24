<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeFile="Content.aspx.cs" Inherits="roessner.Content" Theme="RoessnerLight" EnableSessionState="False" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<asp:PlaceHolder runat="server" id="m_ph">
    <meta runat="server" id="d" clientidmode="Static" name="description" content="At Roessner & Co we take pride in being one of the premier annual report design teams out there. Contact us today to learn about our strategic design team!" />
    <meta runat="server" id="k" clientidmode="Static" name="keywords" content="Annual Report Design, Strategic Design, graphic design, Roessner & Co" />
</asp:PlaceHolder>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cmain" runat="server">

<div>

<asp:PlaceHolder runat="server" ID="m_img">
    <div class="fr_img">
        <asp:Image runat="server" ID="m_imgtag" AlternateText="Roessner &amp; Co - Professional Annual Report Designs" />
    </div></asp:PlaceHolder>

<asp:Literal runat="server" ID="m_content" />

</div>

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="cleft" enableviewstate="false">
    <ul runat="server" id="m_navleft" clientidmode="Static" enableviewstate="false"></ul>
</asp:Content>

<asp:Content runat="server" ID="bl" ContentPlaceHolderID="bottomLeft"><a id="seal" runat="server" href="/"><img border="0" style="border: none;" src="/images/seal.png" alt="Roessner & Co." /></a></asp:Content>
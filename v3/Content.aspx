<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="Content.aspx.cs" Inherits="roessner.Content" Theme="RoessnerLight" EnableSessionState="False" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cmain" runat="server">

<div>

<asp:PlaceHolder runat="server" ID="m_img">
    <div class="fr_img">
        <img src="<%= ImgSrc %>" alt="" />
    </div>
</asp:PlaceHolder>

<asp:Literal runat="server" ID="m_content" />
</div>

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="cleft" enableviewstate="false">
    <ul runat="server" id="m_navleft" clientidmode="Static" enableviewstate="false"></ul>
</asp:Content>

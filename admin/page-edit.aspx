<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="page-edit.aspx.cs" Inherits="roessner.admin.page_edit" ValidateRequest="false" EnableSessionState="False" Theme="RoessnerLight" %>
<%@ Register src="AdminLeft.ascx" tagname="AdminLeft" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cmain" runat="server">

<form runat="server">

<h1>Edit Page</h1>

<p><asp:Button runat="server" id="m_save" Text="Save and Publish" EnableViewState="false" /></p>

<textarea id="wmdinput" rows="20" cols="60" runat="server"></textarea>
<div class="wmd-preview"></div>

    <script type="text/javascript">
        // to set WMD's options programatically, define a "wmd_options" object with whatever settings
        // you want to override.  Here are the defaults:
        wmd_options = {
            // format sent to the server.  Use "Markdown" to return the markdown source.
            output: "Markdown",

            // line wrapping length for lists, blockquotes, etc.
            lineLength: 40,

            // toolbar buttons.  Undo and redo get appended automatically.
            buttons: "bold italic | link blockquote code image | ol ul heading hr",

            // option to automatically add WMD to the first textarea found
            autostart: true
        };
	</script> 
    <script type="text/javascript" src="wmd/wmd.js"></script> 
</form>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="cleft">
    <uc1:AdminLeft ID="AdminLeft1" runat="server" />
</asp:Content>


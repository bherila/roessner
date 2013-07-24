<%@ Page Title="" Language="C#" MasterPageFile="~/Template.master" AutoEventWireup="true" CodeBehind="pages.aspx.cs" Inherits="roessner.admin.pages" EnableSessionState="False" Theme="RoessnerLight" %>
<%@ Register src="AdminLeft.ascx" tagname="AdminLeft" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cmain" runat="server">



    <form id="form1" runat="server">

    <h1>Edit Pages</h1>

    <p>
        <img src="Info.png" style="vertical-align: text-bottom;" /> You can see your changes in <b>real time</b> above.</p>

    <asp:GridView ID="grid" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
        CellPadding="4" ForeColor="Black" GridLines="Vertical">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:HyperLinkField DataNavigateUrlFields="Name" 
                DataNavigateUrlFormatString="page-edit.aspx?id={0}" DataTextField="Name" 
                DataTextFormatString="{0}" HeaderText="Page" />
            <asp:BoundField HtmlEncode="false" DataField="L1Nav" HeaderText="L1Nav" ItemStyle-HorizontalAlign="Center" />
            <asp:BoundField HtmlEncode="false" DataField="L2Nav" HeaderText="L2Nav" ItemStyle-HorizontalAlign="Center" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>

    <h2>Create new page</h2>

    <p>Name: <asp:TextBox runat="server" ID="m_name" /></p>
    <p>Category: <asp:DropDownList runat="server" ID="m_category" /></p>
    <p><asp:Button runat="server" ID="m_create" Text="Create" /></p>
    </form>

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="cleft">
    
    <uc1:AdminLeft ID="AdminLeft1" runat="server" />
    
</asp:Content>


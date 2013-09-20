<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DynamicForm.aspx.cs" Inherits="FormGenerator.DynamicForm" MasterPageFile="~/Site.Master" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
    <script type="text/javascript" src="http://api.demandbase.com/autocomplete/widget.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.3.js"></script>
    <script type="text/javascript" src="http://code.jquery.com/ui/1.10.0/jquery-ui.js"></script>
    <script type="text/javascript" src="Scripts/DemandBase.js"></script>
    <script type="text/javascript" src="Scripts/FormGenerator.js"></script>
    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <h2>Welcome to the Form Generator</h2>
        <asp:PlaceHolder ID="plhDynamicForm" runat="server">
            <!--This will dynamically build the form on the page from the Esri.FormGenerator -->
            <asp:Panel ID="pnlContainer" runat="server">
                <%--Placement of the actual web form controls..--%>
                <%--Build dynamic panels (2)--%>
            </asp:Panel>
        </asp:PlaceHolder>
    </div>
</asp:Content>
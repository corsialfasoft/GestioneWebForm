<%@ Page Title="ViewCommessa" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewCommessa.aspx.cs" Inherits="GestioneWebForm.ViewCommessa" %>
<%@ Register TagName="ListCommessa" TagPrefix="TableC" Src="~/Controls/TabellaCommesse.ascx"%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>In questa sezione è possibile visualizza i giorni dedicati ad una determinata Commessa</h3>
    <br />
    <div class="text-warning">
        <h3><%=Message%></h3>
    </div>
    <br />
    <asp:Label runat="server">Nome Commessa</asp:Label>
    <asp:TextBox id="nomeCommessa" runat="server"></asp:TextBox>
    <asp:Button ID="Cerca" Text="CERCA" OnClick="Cerca_Click" runat="server"></asp:Button>
    <br />
    <div class="table" style="margin-top:25px">
        <asp:Table ID="ListaCommesse" runat="server" width="100%" CellPadding="10" GridLines="None" HorizontalAlign="Center"></asp:Table>
    </div>
    <TableC:ListCommessa VisualissaCommessa="true" AddGiorno="false" runat="server" ID="tableC"/>
    <br />
    <%if (commessa != null && commesse==null) {%>
        <div class="panel-heading"><%=commessa.Nome%></div>
        <div class="table" style="margin-top:25px">
            <asp:Table ID="ListaOreCommessa" runat="server" width="100%" CellPadding="10" GridLines="None" HorizontalAlign="Center"></asp:Table>
        </div>
    <%} %>
</asp:Content>

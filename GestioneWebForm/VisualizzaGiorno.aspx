<%@ Page Title="Registro Giorni" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisualizzaGiorno.aspx.cs" Inherits="GestioneWebForm._VisualizzaGiorno" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <br />
    <div class="text-warning" style="font-size:large">
        <%=Message %>
        <br />
    </div>
    <br />
    <div>
        <asp:Calendar runat="server" ID="data" OnSelectionChanged="SelezionaGiorno" OnLoad="SelezionaGiorno"></asp:Calendar>
    </div>
    <br>
    <%if (giorno!=null && giorno.Data.ToString("yyyy-MM-dd") != "0001-01-01") { %>
        <div>
            <h2>Dettagli del giorno selezionato:</h2>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading"><%=giorno.Data.ToShortDateString()%></div>
            <asp:Table ID="TabellaGiorno" runat="server" width="100%" CellPadding="10" GridLines="None" HorizontalAlign="Center" CssClass="table"></asp:Table>
        </div>
    <%} %>
</asp:Content>
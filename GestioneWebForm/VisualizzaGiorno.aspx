<%@ Page Title="Dettagli del Giorno" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VisualizzaGiorno.aspx.cs" Inherits="GestioneWebForm._VisualizzaGiorno" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
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
        <div class="panel panel-default">
            <div class="panel-heading"><%=giorno.Data.ToShortDateString()%></div>
            <div class="table">
                <table style="font-family: arial, sans-serif; border-collapse: collapse; width: 100%; text-align:center;">
                    <tr>
                        <td>Tipo</td>
                        <td>Totale ore</td>
                        <td>Commessa</td>
                        <td>Ore lavoro commessa</td>
                        <td>Note</td>
                    </tr>
                </table>
                <asp:Table ID="TabellaGiorno" runat="server" width="100%" CellPadding="10" GridLines="None" HorizontalAlign="Center"></asp:Table>
            </div>
        </div>
    <%} %>
</asp:Content>
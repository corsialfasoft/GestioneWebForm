<%@ Page Title="Registro Mese" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="VisualizzaMese.aspx.cs" 
    Inherits="GestioneWebForm.VisualizzaMese" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <br />
    <div class="text-warning" style="font-size:large">
        <%=Message%>
        <br />
    </div>
    <br />
    <div>
        <asp:select name="anno" id="anno" required></asp:select>
            <%for(int a = 2000;a<=DateTime.Now.Year; a++){%>
                <option value="a"><%=a%></option>
            <%}%>
            <option value="" selected="selected">Anno</option>
         <asp:LinkButton OnClick="VisualizzaMese" runat="server" style="color:white; background-color: #2196F3; background: #0b7dda;">Visualizza</asp:LinkButton>
    </div>
    <br>
    <%if(anno!= null) {
        string[] listMesi = { "Gennaio", "Febbraio","Marzo","Aprile","Maggio", "Giugno", "Luglio", "Agosto", "Settembre", "Ottobre", "Novembre", "Dicembre" };
    %>
        <br>
        <div class="panel panel-default">
            <table>
                <tr>
                    <td><%=Year%></td>
                    <% for(int index=0; index < listMesi.Length; index++) {
                        if(Month == index+1) {%>
                            <td><%=listMesi[index]%></td>                   
                        <%} else {%>
                            <td style="padding:0; background: #a6a6a6;">
                                <form action="/Home/VisualizzaMese" method="post">
                                    <input type="hidden" name="anno" value="<%=Year%>" />
                                    <input type="hidden" name="mese" value="<%=index+1%>" />
                                    <input type="submit" value="<%=listMesi[index]%>" class="btn btn-link" style="color:white; background: #a6a6a6; padding:0;" />
                                </form>
                            </td>
                        <% }%>
                    <%} %>
                </tr>
            </table>
        </div>
        <div>
            <h2>Dettagli del mese selezionato:</h2>
        </div>
        <div class="panel panel-default">
            <div class="panel-heading"><%=Mese%></div>
            <asp:Table ID="TabellaGiorno" runat="server" width="100%" CellPadding="10" GridLines="None" HorizontalAlign="Center" CssClass="table"></asp:Table>
        </div>
    <%} %>
</asp:Content>
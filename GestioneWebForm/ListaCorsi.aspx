<%@ Page Title="Lista Corso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListaCorsi.aspx.cs" Inherits="GestioneWebForm._ListaCorsi" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="text-warning">
        <%=Message%>
    </div>
    <h2><%: Title %></h2>
    <h3>Fai la tua ricerca</h3>

    <div class="container">
        <div class="row">
            <div class="col-md-3">
                Codice
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="codice" runat="server"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-3">
                Descrizione
            </div>
            <div class="col-md-6">
                <asp:TextBox ID="descrizione" runat="server"></asp:TextBox>
            </div>
        </div>
        <asp:Button OnClick="Cerca_Click" CssClass="btn btn-default" Text="Cerca" runat="server" />
        <asp:Button OnClick="MyCerca_Click" CssClass="btn btn-default" Text="CercaMieiCorsi" runat="server" />
    </div>
    
    <%if(corsi != null && corsi.Count>0) {%>
    <hr />
    <div class="row">
        <div class="col-md-2">
            <h3>Codice</h3>
        </div>
        <div class="col-md-8">
            <h3>Descrizone</h3>
        </div>
        <div class="col-md-2">
            <h3>Dettagli</h3>
        </div>
    </div>
    <asp:Table id="Table1"
            width="100%"
            CellPadding="10"
            GridLines="None"
            HorizontalAlign="Center"
            Runat="server"/>
    <%} %>
</asp:Content>
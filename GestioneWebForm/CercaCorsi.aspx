<%@ Page Title="Lista Corso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CercaCorsi.aspx.cs" Inherits="GestioneWebForm._CercaCorsi" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <%@ Register TagPrefix="GWF" TagName="CorsiTable" Src="~/Controls/ListaCorsi.ascx" %>
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
        <hr />
        <asp:Button OnClick="Cerca_Click" CssClass="btn btn-default" Text="Cerca" runat="server" />
        <asp:Button OnClick="MyCerca_Click" CssClass="btn btn-default" Text="CercaMieiCorsi" runat="server" />
        <%if(ut.Ruolo=="admin"){%>
            <asp:Button PostBackUrl="~/AggiungiCorso" CssClass="btn btn-default" Text="Aggiungi" runat="server" />
        <%}%>
        <GWF:CorsiTable  ID="corsiTable" runat="server" />
    </div>
    
</asp:Content>
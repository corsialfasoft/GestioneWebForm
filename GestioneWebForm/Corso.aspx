<%@ Page Title="Corso" 
    Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true" 
    CodeBehind="Corso.aspx.cs" 
    Inherits="GestioneWebForm._Corso" %>
<%@Register TagPrefix="GetLezioni" TagName="Lezione" Src="~/Controls/ListaLezioni.ascx"%>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %></h2>
     <div Class="text-warning">
        <%=Message%>
    </div>
    <div class="container">
       <div class="row">
            <div class="col-md-3">
               <b>Nome</b>
            </div>
            <div class="col-md-9">
                 <%=corso.Nome%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
               <b>Descrizione</b>
            </div>
            <div class="col-md-9">
                 <%=corso.Descrizione%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
               <b>Data Inizio</b>
            </div>
            <div class="col-md-9">
                 <%=corso.Inizio%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
              <b>Data Fine</b>
            </div>
            <div class="col-md-9">
                 <%=corso.Fine%>
            </div>
        </div>
        <%if(lezioni.Count>0){%>
                <GetLezioni:Lezione ID="Lezione" runat="server" IsEliminaEnabled="true" />
            <%}%>
        <%if(ut.Ruolo == "prof"){%>
            <asp:Button OnClick="AddLezione_Click" CssClass="btn btn-default" Text="Aggiungi Lezione" runat="server" />
        <%}%>
        <%if(ut.Ruolo == "studente"){%>
            <asp:Button OnClick="Iscriviti_Click" CssClass="btn btn-default" Text="Iscriviti" runat="server" />
        <%}%>
        <asp:Button PostBackUrl="~/CercaCorsi" CssClass="btn btn-default" Text="Torna Indietro" runat="server" />
        <hr />

    </div>
</asp:Content>

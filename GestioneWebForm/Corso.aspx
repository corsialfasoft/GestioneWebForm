<%@ Page Title="Corso" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Corso.aspx.cs" Inherits="GestioneWebForm._Corso" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %></h2>
     <div Class="text-warning">
        <%=Message%>
    </div>
    <div class="container">
       <div class="row">
            <div class="col-md-3">
               Nome   
            </div>
            <div class="col-md-9">
                 <%=corso%>
               
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
               Descrizone
            </div>
            <div class="col-md-9">
                <%=Prod.Descrizione%>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                Quantita Richiesta
            </div>
            <div class="col-md-9">
                <asp:TextBox ID="qta" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-3">
                <asp:Button OnClick="Aggiungi_Click" CssClass="btn btn-default" Text="Aggiungi al Carrello" runat="server" />
            </div>
            <div class="col-md-9">
                <asp:Button OnClick="Annulla_Click" CssClass="btn btn-default" Text="Clicca qui" runat="server" />
            </div>
        </div>
    </div>
</asp:Content>

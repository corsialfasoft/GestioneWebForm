<%@ Page Title="Aggiungi Lezione" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddLezione.aspx.cs" Inherits="GestioneWebForm.AddLezione" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Pagina per l'aggiunta di una lezione</h3>
    <div class="row">
        <div class="col-md-3">
            <label> Nome </label> <br />
             <asp:TextBox ID="nome" runat="server" placeholder="Inserisci nome"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <label> Descrizione </label><br />
             <asp:TextBox ID="descrizione" runat="server" placeholder="Inserisci una descrizione"></asp:TextBox>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <label> Durata </label><br />
            <asp:TextBox ID="Durata" runat="server" placeholder="Inserisci la durata del corso"></asp:TextBox>           
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">          
             <asp:Button OnClick="AddLezione_Click" runat="server" text="Aggiungi"/>
        </div>
    </div>
</asp:Content>

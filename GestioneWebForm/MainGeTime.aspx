<%@ Page Title="GeTime" Language="C#" MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" CodeBehind="MainGeTime.aspx.cs" 
    Inherits="GestioneWebForm.MainGeTime" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="btn-group-vertical">
        <asp:Button class="btn btn-primary" runat="server" PostBackUrl="~/AddGiorno" text="Aggiungi ore"></asp:Button>
        <br>
        <asp:Button class="btn btn-primary" runat="server" PostBackUrl="~/ViewGiorno" text="Visualizza giorno"></asp:Button>
        <br>
        <asp:Button class="btn btn-primary" runat="server" PostBackUrl="~/ViewCommessa" text="Visualizza commessa"></asp:Button>
    </div>
</asp:Content>

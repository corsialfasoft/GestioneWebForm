<%@ Page Title="Home Page"
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="AggiungiCorso.aspx.cs" 
    Inherits="GestioneWebForm._AggiungiCorso" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Benvenuto !</h1>
        <p class="lead">Qui potrai aggiungere un corso.</p>
    </div>
    <div class="text-warning">
        <%=Message  %>
    </div>
  <div class="col-sm-4">
        <asp:Label runat="server">Nome:  </asp:Label>
    </div>
    <div class="col-sm-8">
        <asp:TextBox runat="server" ID="nome"></asp:TextBox>
    </div>
    <div class="col-sm-4">
        <asp:Label runat="server">Data inizio: </asp:Label>
    </div>
    <div class="col-sm-8">
        <asp:TextBox runat="server" ID="inizio"></asp:TextBox>
    </div>
    <div class="col-sm-4">
        <asp:Label runat="server">Data fine: </asp:Label>
    </div>
    <div class="col-sm-8">
        <asp:TextBox runat="server" ID="fine"></asp:TextBox>
    </div>
    <div class="col-sm-4">
        <asp:Label runat="server">Descrizione: </asp:Label>
    </div>
    <div class="col-sm-8">
        <asp:TextBox runat="server" ID="descrizione"></asp:TextBox>
    </div>
     <asp:Button runat="server" OnClick="Crea_Click" class="btn btn-primary" Text="Crea" />
    <asp:Button runat="server" PostBackUrl="~/AggiungiCorso.aspx" class="btn btn-default" Text="ANNULLA" />
</asp:Content>
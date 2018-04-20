<%@ Page 
    Title="Percorso Studi" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="PerStud.aspx.cs"
    Inherits="GestioneWebForm._PerStud" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %></h2>
    <div class="container">
    <div class ="row">
        <div class="col-md-3">
            Titolo
        </div>
        <div class="col-md-3">
            <asp:TextBox ID="titolo" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3">
            Descrizione
        </div>
        <div class="col-md-3">
            <asp:TextBox ID="descrizione" runat="server"></asp:TextBox>
        </div>
    </div> 
    <div class ="row">
        <div class="col-md-3">
            Anno Inizio
        </div>
        <div class="col-md-3">
            <asp:TextBox TextMode="Number" ID="annoI" runat="server"></asp:TextBox>
        </div>
        <div class="col-md-3">
            Anno Fine
        </div>
        <div class="col-md-3">
            <asp:TextBox ID="annoF" TextMode="Number" runat="server"></asp:TextBox>
        </div>
    </div> 

    <asp:Button runat="server" OnClick="Go_Click" Text="Clicca"/>
    </div>
</asp:Content>

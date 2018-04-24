<%@ Page 
    Title="Percorso Studi" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="AddComp.aspx.cs"
    Inherits="GestioneWebForm._AddComp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%:Title %></h2>
    <div class="container">
        <div class ="row">
            <div class="col-md-3">
                Titolo
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="titolo" runat="server" Text=""></asp:TextBox>
            </div>
            <div class="col-md-3">
                Livello
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="livello" runat="server"></asp:TextBox>
            </div>
        </div> 
        <asp:Button runat="server" OnClick="Aggiungi_Click" Text="Aggiungi"/>

    </div>
    <br />
</asp:Content>

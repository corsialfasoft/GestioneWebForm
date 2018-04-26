<%@ Page 
    Title="Pagina Iniziale" 
    Language="C#" 
    MasterPageFile="~/Site.Master" 
    AutoEventWireup="true" 
    CodeBehind="ModLezione.aspx.cs"
    Inherits="GestioneWebForm._ModLezione" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <h3>Pagina per la modifica di una lezione</h3>
    <div class="row">
        <div class="col-md-3">
            <label> Argomento </label> <br />
             <asp:TextBox ID="argomento" runat="server" placeholder="Argomento"></asp:TextBox>
            <asp:RequiredFieldValidator CssClass="text-danger h4" ControlToValidate ="argomento" ErrorMessage=" * " runat="server"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">
            <label> Durata </label><br />
            <asp:TextBox ID="Durata" runat="server" placeholder="Inserisci la durata del corso"></asp:TextBox>     
            <asp:RequiredFieldValidator CssClass="text-danger h4" ControlToValidate ="Durata" ErrorMessage=" * " runat="server"/>
        </div>
    </div>
    <div class="row">
        <div class="col-md-3">          
             <asp:Button OnClick="ModLezione_Click" runat="server" text="Modifica"/>
        </div>
    </div>
</asp:Content>
